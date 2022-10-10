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
    public partial class History : System.Web.UI.Page
    {
        public static int userId;
        // i am saving user name in session and getting user id from session
        protected void Page_Load(object sender, EventArgs e)
        {
            
            head.InnerText = "Have a look on your past invoices MR " + Session["userName"];
            userId = Convert.ToInt32(Session["userId"]);
        }
        [WebMethod]
        //this is my method for showing the previous purchases of the respective customer with his id
        public static string ShowMyHistory()
        {
            Bill bill = new Bill();
            List<Bill> myBill = new List<Bill>();
            myBill = bill.FetchHistory(userId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(myCart));
            string jason = js.Serialize(myBill);
            return jason;
        }
        [WebMethod]
        //this is my method to clear the unwanted history
        public static void DeleteHistory(int data)
        {
            Bill bill = new Bill();
            bill.Delete(data);           
        }
        protected void Logout(object sender, EventArgs e) //this function is for logout
        {
            Session.Contents.Remove("userName"); //it will remove username and password on logout
            Session.Contents.Remove("password");
            Session.Contents.Remove("userId");
            Cart cart = new Cart();//when the customer is logged out his cart will be deleted 
            cart.RemoveCart(userId);
            Response.Redirect("userLogin.aspx"); //it will again open the login page 
        }
        protected void BackLoad(object sender, EventArgs e) //this function is for going back
        {
            Response.Redirect("customerPage.aspx"); //it will again redirect to the customer page
        }
    }
}