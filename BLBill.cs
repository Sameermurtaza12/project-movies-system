using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.DataLayer;
using OnlineMoviesSystem.Models;

namespace OnlineMoviesSystem.BusinessLayer
{
    public class BLBill
    {
        //calculate bill
        public double Calculate()
        {
            DLBill bill = new DLBill();
            return bill.CalculateNow();
        }
        //make receipt
        public void MakeReceipt(int userId, string userName, double totalBill)
        {
            DLBill bill = new DLBill();
            bill.MakeNewReceipt(userId, userName, totalBill);
        }
        //get invoice id
        public int GetInvoiceNo()
        {
            DLBill bill = new DLBill();
            return bill.GetInvoice();
        }
        //fetch the bill
        public List<Bill> FetchBillHere(int invoice)
        {

            DLBill bill = new DLBill();
            List<Bill> myBill = bill.GetTotalBill(invoice);
            return myBill;
        }
        //fetch the bill history
        public List<Bill> FetchHistoryHere(int userId)
        {

            DLBill bill = new DLBill();
            List<Bill> myBill = bill.GetCustomerHistory(userId);
            return myBill;
        }
        //delete from bill
        public void DeleteNow(int invoiceNo)
        {
            DLBill bill = new DLBill();
            bill.DeleteHere(invoiceNo);
        }
    }
}