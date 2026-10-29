using System.Drawing;
using System.Windows.Forms;

namespace CafePOS_5._3_
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Control trên Form
        private TabControl tabControlMain;
        private TabPage tabPOS;
        private TabPage tabMenuMgmt;

        // Controls Tab POS
        private FlowLayoutPanel flpTables;
        private DataGridView dgvBill;
        private ComboBox cboCategory;
        private ComboBox cboFood;
        private NumericUpDown nudQuantity;
        private Button btnAddFood;
        private Button btnPay;
        private Label lblSelectedTable;
        private Label lblTotalMoney;
        private Label lblCat;
        private Label lblFood;
        private Label lblQty;

        // Controls Tab Quản Lý Thực Đơn
        private DataGridView dgvMenu;
        private TextBox txtFoodName;
        private TextBox txtPrice;
        private ComboBox cboCategoryMgmt;
        private Button btnAddMenu;
        private Button btnEditMenu;
        private Button btnDeleteMenu;
        private Label lblNameM;
        private Label lblCatM;
        private Label lblPriceM;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlMain = new TabControl();
            this.tabPOS = new TabPage();
            this.tabMenuMgmt = new TabPage();

            // POS Tab Controls
            this.flpTables = new FlowLayoutPanel();
            this.lblSelectedTable = new Label();
            this.lblCat = new Label();
            this.cboCategory = new ComboBox();
            this.lblFood = new Label();
            this.cboFood = new ComboBox();
            this.lblQty = new Label();
            this.nudQuantity = new NumericUpDown();
            this.btnAddFood = new Button();
            this.dgvBill = new DataGridView();
            this.lblTotalMoney = new Label();
            this.btnPay = new Button();

            // Menu Management Controls
            this.dgvMenu = new DataGridView();
            this.lblNameM = new Label();
            this.txtFoodName = new TextBox();
            this.lblCatM = new Label();
            this.cboCategoryMgmt = new ComboBox();
            this.lblPriceM = new Label();
            this.txtPrice = new TextBox();
            this.btnAddMenu = new Button();
            this.btnEditMenu = new Button();
            this.btnDeleteMenu = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPOS.SuspendLayout();
            this.tabMenuMgmt.SuspendLayout();
            this.SuspendLayout();

            // 
            // Form1
            // 
            this.ClientSize = new Size(1100, 680);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Bán Hàng & Quán Cafe (POS System)";

            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPOS);
            this.tabControlMain.Controls.Add(this.tabMenuMgmt);
            this.tabControlMain.Dock = DockStyle.Fill;
            this.tabControlMain.Location = new Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Size = new Size(1100, 680);

            // 
            // tabPOS
            // 
            this.tabPOS.Controls.Add(this.flpTables);
            this.tabPOS.Controls.Add(this.lblSelectedTable);
            this.tabPOS.Controls.Add(this.lblCat);
            this.tabPOS.Controls.Add(this.cboCategory);
            this.tabPOS.Controls.Add(this.lblFood);
            this.tabPOS.Controls.Add(this.cboFood);
            this.tabPOS.Controls.Add(this.lblQty);
            this.tabPOS.Controls.Add(this.nudQuantity);
            this.tabPOS.Controls.Add(this.btnAddFood);
            this.tabPOS.Controls.Add(this.dgvBill);
            this.tabPOS.Controls.Add(this.lblTotalMoney);
            this.tabPOS.Controls.Add(this.btnPay);
            this.tabPOS.Text = "Bán Hàng (POS)";

            // 
            // flpTables
            // 
            this.flpTables.AutoScroll = true;
            this.flpTables.BorderStyle = BorderStyle.FixedSingle;
            this.flpTables.Location = new Point(10, 10);
            this.flpTables.Size = new Size(420, 610);

            // 
            // lblSelectedTable
            // 
            this.lblSelectedTable.AutoSize = true;
            this.lblSelectedTable.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblSelectedTable.Location = new Point(440, 15);
            this.lblSelectedTable.Text = "Chưa chọn bàn";

            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new Point(440, 50);
            this.lblCat.Text = "Danh mục:";

            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategory.Location = new Point(520, 47);
            this.cboCategory.Size = new Size(180, 23);
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.CboCategory_SelectedIndexChanged);

            // 
            // lblFood
            // 
            this.lblFood.AutoSize = true;
            this.lblFood.Location = new Point(440, 85);
            this.lblFood.Text = "Món ăn:";

            // 
            // cboFood
            // 
            this.cboFood.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboFood.Location = new Point(520, 82);
            this.cboFood.Size = new Size(180, 23);

            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new Point(710, 50);
            this.lblQty.Text = "Số lượng:";

            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new Point(780, 47);
            this.nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.Size = new Size(60, 23);

            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = Color.LightSkyBlue;
            this.btnAddFood.Location = new Point(710, 78);
            this.btnAddFood.Size = new Size(130, 30);
            this.btnAddFood.Text = "Thêm Món";
            this.btnAddFood.Click += new System.EventHandler(this.BtnAddFood_Click);

            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBill.Location = new Point(440, 120);
            this.dgvBill.ReadOnly = true;
            this.dgvBill.Size = new Size(620, 430);

            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new Font("Arial", 13F, FontStyle.Bold);
            this.lblTotalMoney.ForeColor = Color.DarkRed;
            this.lblTotalMoney.Location = new Point(440, 565);
            this.lblTotalMoney.Text = "Tổng tiền: 0 VNĐ";

            // 
            // btnPay
            // 
            this.btnPay.BackColor = Color.LightGreen;
            this.btnPay.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.btnPay.Location = new Point(880, 560);
            this.btnPay.Size = new Size(180, 45);
            this.btnPay.Text = "Thanh Toán";
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);

            // 
            // tabMenuMgmt
            // 
            this.tabMenuMgmt.Controls.Add(this.dgvMenu);
            this.tabMenuMgmt.Controls.Add(this.lblNameM);
            this.tabMenuMgmt.Controls.Add(this.txtFoodName);
            this.tabMenuMgmt.Controls.Add(this.lblCatM);
            this.tabMenuMgmt.Controls.Add(this.cboCategoryMgmt);
            this.tabMenuMgmt.Controls.Add(this.lblPriceM);
            this.tabMenuMgmt.Controls.Add(this.txtPrice);
            this.tabMenuMgmt.Controls.Add(this.btnAddMenu);
            this.tabMenuMgmt.Controls.Add(this.btnEditMenu);
            this.tabMenuMgmt.Controls.Add(this.btnDeleteMenu);
            this.tabMenuMgmt.Text = "Quản Lý Thực Đơn";

            // 
            // dgvMenu
            // 
            this.dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenu.Location = new Point(20, 20);
            this.dgvMenu.ReadOnly = true;
            this.dgvMenu.Size = new Size(600, 580);
            this.dgvMenu.CellClick += new DataGridViewCellEventHandler(this.DgvMenu_CellClick);

            // 
            // lblNameM
            // 
            this.lblNameM.AutoSize = true;
            this.lblNameM.Location = new Point(640, 30);
            this.lblNameM.Text = "Tên món:";

            // 
            // txtFoodName
            // 
            this.txtFoodName.Location = new Point(730, 27);
            this.txtFoodName.Size = new Size(300, 23);

            // 
            // lblCatM
            // 
            this.lblCatM.AutoSize = true;
            this.lblCatM.Location = new Point(640, 70);
            this.lblCatM.Text = "Danh mục:";

            // 
            // cboCategoryMgmt
            // 
            this.cboCategoryMgmt.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategoryMgmt.Location = new Point(730, 67);
            this.cboCategoryMgmt.Size = new Size(300, 23);

            // 
            // lblPriceM
            // 
            this.lblPriceM.AutoSize = true;
            this.lblPriceM.Location = new Point(640, 110);
            this.lblPriceM.Text = "Đơn giá:";

            // 
            // txtPrice
            // 
            this.txtPrice.Location = new Point(730, 107);
            this.txtPrice.Size = new Size(300, 23);

            // 
            // btnAddMenu
            // 
            this.btnAddMenu.Location = new Point(640, 160);
            this.btnAddMenu.Size = new Size(95, 35);
            this.btnAddMenu.Text = "Thêm Món";
            this.btnAddMenu.Click += new System.EventHandler(this.BtnAddMenu_Click);

            // 
            // btnEditMenu
            // 
            this.btnEditMenu.Location = new Point(745, 160);
            this.btnEditMenu.Size = new Size(95, 35);
            this.btnEditMenu.Text = "Sửa Món";
            this.btnEditMenu.Click += new System.EventHandler(this.BtnEditMenu_Click);

            // 
            // btnDeleteMenu
            // 
            this.btnDeleteMenu.Location = new Point(850, 160);
            this.btnDeleteMenu.Size = new Size(95, 35);
            this.btnDeleteMenu.Text = "Xóa Món";
            this.btnDeleteMenu.Click += new System.EventHandler(this.BtnDeleteMenu_Click);

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPOS.ResumeLayout(false);
            this.tabPOS.PerformLayout();
            this.tabMenuMgmt.ResumeLayout(false);
            this.tabMenuMgmt.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}