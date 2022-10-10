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
    public partial class CartView : System.Web.UI.Page
    {
        public static int userId;
        // save the username in session and get user id from the session
        protected void Page_Load(object sender, EventArgs e)
        {
            head.InnerText = "This is your cart MR " + Session["userName"];
            userId = Convert.ToInt32(Session["userId"]);
            //ShowMyCart();
        }
        [WebMethod]
        //this is my method to show the cart that was created for the customer 
        public static string ShowMyCart()
        {
            //list of cart items will be shown by using datatable
            Cart cart = new Cart();
            List<Cart> myCart = new List<Cart>();
            myCart = cart.FetchNow(userId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Write(js.Serialize(myCart));
            string jason = js.Serialize(myCart);
            return jason;
        }
        [WebMethod]
        //this is my method to delete the cart by the id
        public static void DeleteCart(int data)
        {
            Cart cart = new Cart();
            cart.Delete(data);
           // HttpContext.Current.Response.Redirect("CartView.aspx");
        }
        [WebMethod]
        //this method will redirect to the bill page
        protected void CheckOut(object sender, EventArgs e)
        {
            Response.Redirect("BillReceipt.aspx");
        }
        protected void Logout(object sender, EventArgs e) //this function is for logout
        {
            Session.Contents.Remove("userName"); //it will remove username and password on logout
            Session.Contents.Remove("password");
            Session.Contents.Remove("userId");
            Cart cart = new Cart();
            cart.RemoveCart(userId);//cart will be cleared
            Response.Redirect("userLogin.aspx"); //it will again open the login page 
        }
        protected void BackLoad(object sender, EventArgs e) //this function is for going back
        {
            Response.Redirect("customerPage.aspx"); //it will again open the customer page
        }
    }
}