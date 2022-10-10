using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Configuration;
using System.Web.Script.Serialization;
using OnlineMoviesSystem.Models;
namespace OnlineMoviesSystem.DataLayer
{
    public class DLBill
    {
        double totalBill=0;
        int invoiceRecent = 0;
        //calculate the total bill from database
        public double CalculateNow()
        {
            totalBill = 0;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetBill", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    totalBill = totalBill+Convert.ToDouble(rdr["moviePrice"]);
                }
                Console.Write(totalBill);
                sqlCon.Close();
            }
            return totalBill;
        }
        //make receipt accordingly from database
        public void MakeNewReceipt(int userId, string userName, double total)
        {

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddInBill", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@userId", userId);
                sqlCmd.Parameters.AddWithValue("@userName", userName);
                sqlCmd.Parameters.AddWithValue("@totalBill", total);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
           
          
        }
        //get the invoice of bill
        public int GetInvoice()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetFromBill", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    invoiceRecent = Convert.ToInt32(rdr["invoiceNo"]);
                }
                Console.Write(invoiceRecent);              
                sqlCon.Close();
            }
            return invoiceRecent;
        }
        //get the total of bill in list
        public List<Bill> GetTotalBill(int invoice)
        {
            List<Bill> myBill = new List<Bill>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetFinalBill", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@invoiceNo", invoice);
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    Bill bill = new Bill();
                    bill.billInvoice = Convert.ToInt32(rdr["invoiceNo"]);
                    bill.userId = Convert.ToInt32(rdr["userId"]);
                    bill.userName = rdr["userName"].ToString();               
                    bill.invoiceDate = Convert.ToDateTime(rdr["purchaseDate"]);
                    bill.totalBill = Convert.ToDouble(rdr["totalBill"]);
                    myBill.Add(bill);
                    Console.WriteLine(myBill);
                }
                sqlCon.Close();
            }
            return myBill;
        }
        //get the past purchase history in list
        public List<Bill> GetCustomerHistory(int userId)
        {
            List<Bill> myBill = new List<Bill>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetHistory", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    Bill bill = new Bill();
                    bill.billInvoice = Convert.ToInt32(rdr["invoiceNo"]);
                    bill.userId = Convert.ToInt32(rdr["userId"]);
                    bill.userName = rdr["userName"].ToString();
                    bill.invoiceDate = Convert.ToDateTime(rdr["purchaseDate"]);
                    bill.totalBill = Convert.ToDouble(rdr["totalBill"]);
                    myBill.Add(bill);
                    Console.WriteLine(myBill);
                }
                sqlCon.Close();
            }
            return myBill;
        }
        //delete by the invoice id
        public void DeleteHere(int invoiceNo)
        {
            // me yaha huuuuuuuu
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spDeleteFromBillInvoice", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@invoiceNo", invoiceNo);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

        }
    }
}