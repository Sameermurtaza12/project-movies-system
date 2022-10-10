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
    public class DLNewCustomer
    {
        int id;
        //add new customer in customer table in database
        public void RegisterCustomer(string name, string password, string userType, string fullName, string contact, string address, string city, string country, string state, int age)
        {
            AddInUser(name, password, userType);
            id = GetId(name, password);
            AddInCustomer(fullName, contact, address, city, country, state, age, id);
        }
        //add by the given parameters
        public void AddInCustomer(string fullName, string contact, string address, string city, string country, string state, int age, int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddInCustomer", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@customerName", fullName);
                sqlCmd.Parameters.AddWithValue("@customerContact", contact);
                sqlCmd.Parameters.AddWithValue("@customerAddress", address);
                sqlCmd.Parameters.AddWithValue("@customerCity", city);
                sqlCmd.Parameters.AddWithValue("@customerCountry", country);
                sqlCmd.Parameters.AddWithValue("@customerState", state);
                sqlCmd.Parameters.AddWithValue("@customerAge", age);
                sqlCmd.Parameters.AddWithValue("@userId", id);


                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        //get user id from database
        public int GetId(string name, string password)
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
                    id = Convert.ToInt32( rdr[0]);
                }
                Console.Write(id);
                sqlCon.Close();
            }
            return id;
        }
        //add in user table
        public void AddInUser(string name, string password, string userType)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddInUser", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@userName", name);
                sqlCmd.Parameters.AddWithValue("@userPassword", password);
                sqlCmd.Parameters.AddWithValue("@userType", userType);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}