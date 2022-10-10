using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineMoviesSystem.Models;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OnlineMoviesSystem
{
    public partial class BillReceipt : System.Web.UI.Page
    {
        //static variable only can be accessed in static function 
        public static int invoice;
        public static int userId;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //saving username in session and getting user id from the session
            head.InnerText = "Thanks for buying MR " + Session["userName"];
            userId = Convert.ToInt32(Session["userId"]);
            //bill object to be filled 
            Bill bill = new Bill();
            bill.totalBill = bill.CalcBill();
            bill.userId = Convert.ToInt32(Session["userId"]);
            bill.userName = Session["userName"].ToString();
            //this function will make the bill receipt
            bill.MakeBillReceipt(bill.userId, bill.userName, bill.totalBill);
            //getting the bill invoice
            bill.billInvoice = bill.GetInvoice();
            invoice = Convert.ToInt32(bill.billInvoice);
        }

        [WebMethod]
        //this method will show the bill of the respective customer
        public static string ShowMyBill()
        {
            Bill bill = new Bill();
            List<Bill> myBill = new List<Bill>();
            //making the list to show in datatable
            myBill = bill.FetchBill(invoice);
            JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(myCart));
            string jason = js.Serialize(myBill);
            return jason; 
        }
        protected void Logout(object sender, EventArgs e) //this function is for logout
        {
            Session.Contents.Remove("userName"); //it will remove username and password on logout
            Session.Contents.Remove("password");
            Session.Contents.Remove("userId");
            Cart cart = new Cart();
            cart.RemoveCart(userId);//remove the cart
            Response.Redirect("userLogin.aspx"); //it will again open the login page 
        }
        protected void BackLoad(object sender, EventArgs e) //this function is for going back
        {
            Response.Redirect("CartView.aspx"); //it will again open the cart view page
        }

    }
}