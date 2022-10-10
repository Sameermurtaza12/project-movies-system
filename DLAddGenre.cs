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
    public class DLAddGenre
    {
        //add the new genre in database
        public void AddNow(string genreName)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddInGenre", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@genreName", genreName);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}