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
namespace OnlineMoviesSystem.DataLayer
{
    public class DLAddMovies
    {
        //add new movies in movie table
        public void AddNow(string movieName, double moviePrice, string movieRating, string genreName)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddInMovies", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@movieName", movieName);
                sqlCmd.Parameters.AddWithValue("@moviePrice", moviePrice);
                sqlCmd.Parameters.AddWithValue("@movieRating", movieRating);
                sqlCmd.Parameters.AddWithValue("@genreName", genreName);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}