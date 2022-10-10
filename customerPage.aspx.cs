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

namespace OnlineMoviesSystem
{
    public partial class customerPage : System.Web.UI.Page
    {
      public static int userId;
        
        //storing the user name in session and getting the user id from the session
        protected void Page_Load(object sender, EventArgs e)
        {
            head.InnerText = "WELCOME MR " + Session["userName"];
            userId =Convert.ToInt32(Session["userId"]);

        }
        [WebMethod]
        //this is my method to add the selected movie in the cart 
        public static void AddToCart(int data)
        {
            Movies movie = new Movies();
            // movie.movieId = Convert.ToInt32(data);
          //  userId = Convert.ToInt32(Session["userId"]);
            movie.AddInCart(data, userId);
            Console.WriteLine(data);
        }
        protected void Logout(object sender, EventArgs e) //this function is for logout
        {
            Session.Contents.Remove("userName"); //it will remove username and password on logout
            Session.Contents.Remove("password");
            Session.Contents.Remove("userId");
            Cart cart = new Cart();
            cart.RemoveCart(userId);//it will clear the cart when customer is logged out
            Response.Redirect("userLogin.aspx"); //it will again open the login page 
        }
        //this method is to show cart
        public void ViewCart(object sender, EventArgs e)
        {
            Response.Redirect("CartView.aspx");
        }
        //this method is to show history
        public void ViewHistory(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx");
        }
    }
}