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
    public partial class RegisterNewUser : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        //this is my method for registering new customer all attributes will be saved in the customer table in database and it will login the customer 
        protected void RegisterCustomer(object sender, EventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            newCustomer.name = name.Text.Trim();
            newCustomer.password = password.Text.Trim();
            newCustomer.userType = "customer";
            newCustomer.fullName = fullName.Text.Trim();
            newCustomer.contact = contact.Text.Trim();
            newCustomer.address = address.Text.Trim();
            newCustomer.city = city.Text.Trim();
            newCustomer.country = country.Text.Trim();
            newCustomer.state = state.Text.Trim();
            newCustomer.age = Convert.ToInt32(age.Text);
            newCustomer.AddCustomer(newCustomer.name, newCustomer.password, newCustomer.userType, newCustomer.fullName, newCustomer.contact, newCustomer.address, newCustomer.city, newCustomer.country, newCustomer.state, newCustomer.age);
            Session["userName"] = name.Text.Trim(); //saving name in session
            Session["password"] = password.Text.Trim(); //saving password in session

            Response.Redirect("customerPage.aspx");
        }
    }
}