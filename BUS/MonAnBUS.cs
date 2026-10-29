using CafePOS_5._3_.DAL;
using CafePOS_5._3_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CafePOS_5._3_.BUS
{
    public class MonAnBUS
    {
        private MonAnDAL dal = new MonAnDAL();

        public DataTable GetCategories() => dal.GetCategories();
        public DataTable GetMenuWithCategory() => dal.GetMenuWithCategory();
        public DataTable GetByCategoryId(int catId) => dal.GetByCategoryId(catId);
        public bool Insert(MonAnDTO mon) => dal.Insert(mon);
        public bool Update(MonAnDTO mon) => dal.Update(mon);
        public bool Delete(int maMon) => dal.Delete(maMon);
    }
}
