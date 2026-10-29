using CafePOS_5._3_.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CafePOS_5._3_.BUS
{
    public class BanAnBUS
    {
        private BanAnDAL dal = new BanAnDAL();
        public DataTable GetAllTables() => dal.GetAllTables();
    }
}
