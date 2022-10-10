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
    public partial class userLogin : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        protected void UserLogin(object sender, EventArgs e)
        {
            // user object to access variables and save user name password and id for later user
            User user = new User();
            user.name = name.Text.Trim();
            user.password = password.Text.Trim();
            user.type = user.CheckUser(user.name, user.password);
            user.id = user.CheckId(user.name, user.password);
            //checks for redirecting to respective pages
            if (user.type == "admin")
            {
                Session["userName"] = name.Text.Trim(); //saving name in session
                Session["password"] = password.Text.Trim(); //saving password in session
                Session["userId"] = user.id;
                Console.Write(Session["userId"]);
                Response.Redirect("adminPage.aspx"); //opening new page to display data 

            }
            else if(user.type=="customer")
            {
                Session["userName"] = name.Text.Trim(); //saving name in session
                Session["password"] = password.Text.Trim(); //saving password in session
                Session["userId"] = user.id;
                
                Console.Write(Session["userId"]);
                Response.Redirect("customerPage.aspx"); //opening new page to display data 
            }
            else
            {             
                Response.Redirect("userLogin.aspx");
            }

        }
        //this is my method to creating new account
        protected void CreateAccount(object sender, EventArgs e)
        {
            Response.Redirect("RegisterNewUser.aspx");
        }
    }
}