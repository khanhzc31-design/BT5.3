using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CafePOS_5._3_.DAL
{
    public class HoaDonDAL
    {
        public int GetUnpaidBillId(int tableId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0", conn);
                cmd.Parameters.AddWithValue("@MaBan", tableId);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public DataTable GetBillDetails(int billId)
        {
            string query = @"SELECT m.TenMon, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien
                             FROM ChiTietHoaDon c JOIN MonAn m ON c.MaMon = m.MaMon
                             WHERE c.MaHoaDon = @MaHoaDon";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", billId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddFoodToBill(int tableId, int foodId, int quantity)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                int billId = GetUnpaidBillId(tableId);

                if (billId == -1)
                {
                    SqlCommand cmdBill = new SqlCommand("INSERT INTO HoaDon (MaBan, GioVao, TrangThai) OUTPUT INSERTED.MaHoaDon VALUES (@MaBan, GETDATE(), 0)", conn);
                    cmdBill.Parameters.AddWithValue("@MaBan", tableId);
                    billId = (int)cmdBill.ExecuteScalar();

                    SqlCommand cmdTable = new SqlCommand("UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @MaBan", conn);
                    cmdTable.Parameters.AddWithValue("@MaBan", tableId);
                    cmdTable.ExecuteNonQuery();
                }

                SqlCommand cmdPrice = new SqlCommand("SELECT DonGia FROM MonAn WHERE MaMon = @MaMon", conn);
                cmdPrice.Parameters.AddWithValue("@MaMon", foodId);
                decimal price = Convert.ToDecimal(cmdPrice.ExecuteScalar());

                SqlCommand cmdCheck = new SqlCommand("SELECT SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @MaHD AND MaMon = @MaMon", conn);
                cmdCheck.Parameters.AddWithValue("@MaHD", billId);
                cmdCheck.Parameters.AddWithValue("@MaMon", foodId);
                object existQty = cmdCheck.ExecuteScalar();

                if (existQty != null)
                {
                    SqlCommand cmdUp = new SqlCommand("UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @SoLuong WHERE MaHoaDon = @MaHD AND MaMon = @MaMon", conn);
                    cmdUp.Parameters.AddWithValue("@SoLuong", quantity);
                    cmdUp.Parameters.AddWithValue("@MaHD", billId);
                    cmdUp.Parameters.AddWithValue("@MaMon", foodId);
                    cmdUp.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmdIn = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia) VALUES (@MaHD, @MaMon, @SoLuong, @DonGia)", conn);
                    cmdIn.Parameters.AddWithValue("@MaHD", billId);
                    cmdIn.Parameters.AddWithValue("@MaMon", foodId);
                    cmdIn.Parameters.AddWithValue("@SoLuong", quantity);
                    cmdIn.Parameters.AddWithValue("@DonGia", price);
                    cmdIn.ExecuteNonQuery();
                }
            }
        }

        public bool PayBillWithTransaction(int tableId, int billId, decimal totalMoney)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE HoaDon SET GioRa = GETDATE(), TongTien = @TongTien, TrangThai = 1 WHERE MaHoaDon = @MaHoaDon", conn, transaction);
                    cmd1.Parameters.AddWithValue("@TongTien", totalMoney);
                    cmd1.Parameters.AddWithValue("@MaHoaDon", billId);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @MaBan", conn, transaction);
                    cmd2.Parameters.AddWithValue("@MaBan", tableId);
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
