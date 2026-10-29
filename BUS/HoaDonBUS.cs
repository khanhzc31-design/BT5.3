using CafePOS_5._3_.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CafePOS_5._3_.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public int GetUnpaidBillId(int tableId) => dal.GetUnpaidBillId(tableId);
        public DataTable GetBillDetails(int billId) => dal.GetBillDetails(billId);
        public void AddFoodToBill(int tableId, int foodId, int quantity) => dal.AddFoodToBill(tableId, foodId, quantity);
        public bool PayBillWithTransaction(int tableId, int billId, decimal totalMoney) => dal.PayBillWithTransaction(tableId, billId, totalMoney);
    }
}
