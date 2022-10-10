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
    public partial class AddGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        //this method is to add new genre in the genre table
        protected void AddGenreNow(object sender, EventArgs e)
        {
            Genre genre = new Genre();
        
            genre.genreName = name.Text.Trim();
            genre.AddIntoGenre(genre.genreName);
            Response.Redirect("adminPage.aspx");
        }
        protected void Logout(object sender, EventArgs e) //this function is for logout
        {
            Session.Contents.Remove("userName"); //it will remove username and password on logout
            Session.Contents.Remove("password");
            Session.Contents.Remove("userId");
            Response.Redirect("userLogin.aspx"); //it will again open the login page 
        }
        protected void BackLoad(object sender, EventArgs e) //this function is for going back
        {
            Response.Redirect("adminPage.aspx"); //it will again open the admin page 
        }
    }
}