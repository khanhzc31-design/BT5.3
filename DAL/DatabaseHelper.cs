using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafePOS_5._3_.DAL
{
    public class DatabaseHelper
    {
        public static string ConnectionString = @"Server=.;Database=Cafe;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
