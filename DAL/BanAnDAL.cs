using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CafePOS_5._3_.DAL
{
    public class BanAnDAL
    {
        public DataTable GetAllTables()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaBan, TenBan, TrangThai FROM BanAn", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
