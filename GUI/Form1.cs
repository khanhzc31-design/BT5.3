using CafePOS_5._3_.BUS;
using CafePOS_5._3_.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CafePOS_5._3_
{
    public partial class Form1 : Form
    {
        private BanAnBUS banAnBUS = new BanAnBUS();
        private MonAnBUS monAnBUS = new MonAnBUS();
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();

        private int selectedTableId = -1;
        private string selectedTableName = "";

        public Form1()
        {
            InitializeComponent();
            LoadTables();
            LoadCategories();
            LoadMenuManagementData();
        }

        private void LoadTables()
        {
            flpTables.Controls.Clear();
            DataTable dt = banAnBUS.GetAllTables();

            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button
                {
                    Width = 90,
                    Height = 90,
                    Text = $"{row["TenBan"]}\n({row["TrangThai"]})",
                    Tag = Convert.ToInt32(row["MaBan"]),
                    Font = new Font("Arial", 9, FontStyle.Bold)
                };

                string status = row["TrangThai"].ToString();
                btn.BackColor = status == "Trống" ? Color.LightGreen : Color.LightCoral;
                btn.Click += TableButton_Click;

                flpTables.Controls.Add(btn);
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            selectedTableId = (int)btn.Tag;
            selectedTableName = btn.Text.Split('\n')[0];
            lblSelectedTable.Text = $"Đang chọn: {selectedTableName}";

            LoadBillForTable(selectedTableId);
        }

        private void LoadBillForTable(int tableId)
        {
            int billId = hoaDonBUS.GetUnpaidBillId(tableId);

            if (billId == -1)
            {
                dgvBill.DataSource = null;
                lblTotalMoney.Text = "Tổng tiền: 0 VNĐ";
                return;
            }

            DataTable dt = hoaDonBUS.GetBillDetails(billId);
            dgvBill.DataSource = dt;

            decimal total = 0;
            foreach (DataRow r in dt.Rows)
            {
                total += Convert.ToDecimal(r["ThanhTien"]);
            }
            lblTotalMoney.Text = $"Tổng tiền: {total:#,##0} VNĐ";
        }

        private void LoadCategories()
        {
            DataTable dt = monAnBUS.GetCategories();
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "TenDanhMuc";
            cboCategory.ValueMember = "MaDanhMuc";

            DataTable dt2 = dt.Copy();
            cboCategoryMgmt.DataSource = dt2;
            cboCategoryMgmt.DisplayMember = "TenDanhMuc";
            cboCategoryMgmt.ValueMember = "MaDanhMuc";
        }

        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedValue == null || !(cboCategory.SelectedValue is int)) return;

            int catId = Convert.ToInt32(cboCategory.SelectedValue);
            cboFood.DataSource = monAnBUS.GetByCategoryId(catId);
            cboFood.DisplayMember = "TenMon";
            cboFood.ValueMember = "MaMon";
        }

        private void BtnAddFood_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn ăn trước khi thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboFood.SelectedValue == null) return;

            int foodId = Convert.ToInt32(cboFood.SelectedValue);
            int quantity = (int)nudQuantity.Value;

            hoaDonBUS.AddFoodToBill(selectedTableId, foodId, quantity);
            LoadTables();
            LoadBillForTable(selectedTableId);
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int billId = hoaDonBUS.GetUnpaidBillId(selectedTableId);
            if (billId == -1)
            {
                MessageBox.Show("Bàn hiện tại không có hóa đơn chưa thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal totalMoney = 0;
            if (dgvBill.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    totalMoney += Convert.ToDecimal(row["ThanhTien"]);
                }
            }

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận thanh toán cho {selectedTableName}?\nTổng tiền: {totalMoney:#,##0} VNĐ",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            bool success = hoaDonBUS.PayBillWithTransaction(selectedTableId, billId, totalMoney);
            if (success)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadTables();
            LoadBillForTable(selectedTableId);
        }

        private void LoadMenuManagementData()
        {
            DataTable dt = monAnBUS.GetMenuWithCategory();
            dgvMenu.DataSource = dt;
            if (dgvMenu.Columns["MaDanhMuc"] != null)
            {
                dgvMenu.Columns["MaDanhMuc"].Visible = false;
            }
        }

        private void DgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMenu.Rows[e.RowIndex];
            txtFoodName.Text = row.Cells["TenMon"].Value.ToString();
            txtPrice.Text = Convert.ToDecimal(row.Cells["DonGia"].Value).ToString("0.##");
            cboCategoryMgmt.SelectedValue = Convert.ToInt32(row.Cells["MaDanhMuc"].Value);
        }

        private bool ValidateMenuInput(out MonAnDTO mon)
        {
            mon = new MonAnDTO();
            mon.TenMon = txtFoodName.Text.Trim();
            mon.MaDanhMuc = cboCategoryMgmt.SelectedValue != null ? Convert.ToInt32(cboCategoryMgmt.SelectedValue) : -1;

            if (string.IsNullOrEmpty(mon.TenMon))
            {
                MessageBox.Show("Tên món ăn không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFoodName.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số lớn hơn hoặc bằng 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            mon.DonGia = price;
            return true;
        }

        private void BtnAddMenu_Click(object sender, EventArgs e)
        {
            if (!ValidateMenuInput(out MonAnDTO mon)) return;

            if (monAnBUS.Insert(mon))
            {
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenuManagementData();
                LoadCategories();
            }
        }

        private void BtnEditMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenu.CurrentRow == null) return;
            if (!ValidateMenuInput(out MonAnDTO mon)) return;

            mon.MaMon = Convert.ToInt32(dgvMenu.CurrentRow.Cells["MaMon"].Value);
            if (monAnBUS.Update(mon))
            {
                MessageBox.Show("Cập nhật thông tin món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenuManagementData();
                LoadCategories();
            }
        }

        private void BtnDeleteMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenu.CurrentRow == null) return;

            int foodId = Convert.ToInt32(dgvMenu.CurrentRow.Cells["MaMon"].Value);
            string foodName = dgvMenu.CurrentRow.Cells["TenMon"].Value.ToString()!;

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa món '{foodName}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            if (monAnBUS.Delete(foodId))
            {
                MessageBox.Show("Đã xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenuManagementData();
                LoadCategories();
            }
        }
    }
}