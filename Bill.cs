using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.BusinessLayer;
namespace OnlineMoviesSystem.Models
{
    public class Bill
    {
        public int billInvoice { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public DateTime invoiceDate { get; set; }
        public double totalBill { get; set; }

        public double CalcBill()
        {
            BLBill bill = new BLBill();
            return bill.Calculate();
        }
        public void MakeBillReceipt(int userId, string userName, double totalBill)
        {
            BLBill bill = new BLBill();
            bill.MakeReceipt(userId, userName, totalBill);
        }
        public int GetInvoice()
        {
            BLBill bill = new BLBill();
            return bill.GetInvoiceNo();
        }
        public List<Bill> FetchBill(int invoice)
        {
            BLBill bill = new BLBill();
            List<Bill> myBill = bill.FetchBillHere(invoice);
            return myBill;
        }
        public List<Bill> FetchHistory(int userId)
        {
            BLBill bill = new BLBill();
            List<Bill> myBill = bill.FetchHistoryHere(userId);
            return myBill;
        }
        public void Delete(int invoiceNo)
        {
            BLBill bill = new BLBill();
            bill.DeleteNow(invoiceNo);
        }
    }
}