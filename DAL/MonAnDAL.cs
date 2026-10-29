using CafePOS_5._3_.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CafePOS_5._3_.DAL
{
    public class MonAnDAL
    {
        public DataTable GetCategories()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetMenuWithCategory()
        {
            string query = @"SELECT m.MaMon, m.TenMon, d.TenDanhMuc, m.DonGia, m.MaDanhMuc
                             FROM MonAn m JOIN DanhMuc d ON m.MaDanhMuc = d.MaDanhMuc";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetByCategoryId(int catId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT MaMon, TenMon FROM MonAn WHERE MaDanhMuc = @MaDanhMuc", conn);
                cmd.Parameters.AddWithValue("@MaDanhMuc", catId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool Insert(MonAnDTO mon)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES (@Ten, @MaDM, @Gia)", conn);
                cmd.Parameters.AddWithValue("@Ten", mon.TenMon);
                cmd.Parameters.AddWithValue("@MaDM", mon.MaDanhMuc);
                cmd.Parameters.AddWithValue("@Gia", mon.DonGia);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(MonAnDTO mon)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE MonAn SET TenMon = @Ten, MaDanhMuc = @MaDM, DonGia = @Gia WHERE MaMon = @MaMon", conn);
                cmd.Parameters.AddWithValue("@Ten", mon.TenMon);
                cmd.Parameters.AddWithValue("@MaDM", mon.MaDanhMuc);
                cmd.Parameters.AddWithValue("@Gia", mon.DonGia);
                cmd.Parameters.AddWithValue("@MaMon", mon.MaMon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maMon)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM MonAn WHERE MaMon = @MaMon", conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
