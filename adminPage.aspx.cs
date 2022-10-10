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
    public partial class adminPage : System.Web.UI.Page
    {
        //[System.Web.Script.Services.ScriptService]
       
        protected void Page_Load(object sender, EventArgs e)
        {
            head.InnerText = "WELCOME MR " + Session["userName"];
            //ShowMovies();

        }
        [WebMethod]
        
        protected void Logout(object sender, EventArgs e) //this function is for logout
        {
            Session.Contents.Remove("userName"); //it will remove username and password on logout
            Session.Contents.Remove("password");
            Session.Contents.Remove("userId");
            Response.Redirect("userLogin.aspx"); //it will again open the login page 
        }
        protected void AddMovies(object sender, EventArgs e)
        {
            Response.Redirect("AddMovies.aspx");
        }
        protected void AddGenre(object sender, EventArgs e)
        {
            Response.Redirect("AddGenre.aspx");
        }
        [WebMethod]
        public static string ShowMovies()
        {
            Movies movie = new Movies();
            List<Movies> movies = new List<Movies>();
            movies = movie.Fetch();
            JavaScriptSerializer js = new JavaScriptSerializer();
           // Context.Response.Write(js.Serialize(movies));
            string jason = js.Serialize(movies);
            return jason;
        }
        [WebMethod]
        //this is my method to delete the cart by the id
        public static void DeleteMovie(int data)
        {
            Movies movie = new Movies();
            movie.Delete(data);        
        }

    }
}