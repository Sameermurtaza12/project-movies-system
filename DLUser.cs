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
    public class DLUser
    {
        string userType;
        int userId;
        //get the user name and password from the user table and verify it by type
        public string FetchCredentials(string name, string password)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("login", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(new SqlParameter("@userName", name.Trim()));
                sqlCmd.Parameters.Add(new SqlParameter("@userpassword", password.Trim()));

                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    userType = rdr[0].ToString();
                }
                Console.Write(userType);
                sqlCon.Close();
            }
            return userType;
   
        }
        //fetch credentials by user name and password
        public int FetchCredentialsId(string name, string password)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetId", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add(new SqlParameter("@userName", name.Trim()));
                sqlCmd.Parameters.Add(new SqlParameter("@userpassword", password.Trim()));

                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    userId =Convert.ToInt32( rdr[0]);
                }
                Console.Write(userId);
                sqlCon.Close();
            }
            return userId;

        }
    }
    
}