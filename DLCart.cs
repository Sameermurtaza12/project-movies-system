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

namespace OnlineMoviesSystem.DataLayer
{
    public class DLCart
    {
        string movieName;
        double moviePrice;
        int userId;
        //add in cart temporary table
        public void AddNow(int id, int userID)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetDetailsById", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@movieId", id));
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    movieName = rdr["movieName"].ToString();
                    moviePrice = Convert.ToDouble(rdr["moviePrice"]);
                }
                Console.Write(movieName);
                Console.Write(moviePrice);
                sqlCon.Close();
             
            }
            userId = userID;
            MakeCart(userId,movieName, moviePrice);
        }
        //make the new cart
        public void MakeCart(int userId, string movieName, double moviePrice)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spAddInCartNow", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userId", userId);
                sqlCmd.Parameters.AddWithValue("@movieName", movieName);
                sqlCmd.Parameters.AddWithValue("@moviePrice", moviePrice);                              
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

        }
        //delete whole row in cart
        public void DeleteRow(int invoiceNo)
        {
            // me yaha huuuuuuuu
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spDeleteFromCart", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@invoiceNo", invoiceNo);              
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

        }
        //drop the cart
        public void RemoveNow(int userId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spDropCart", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userId", userId);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        //get all items from the cart
        public List<Cart> GetAllItems(int id)
        {
            List<Cart> myCart = new List<Cart>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetCartItems", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@userId", id);
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cart cart = new Cart();
                    cart.invoiceNo = Convert.ToInt32(rdr["invoiceNo"]);
                    cart.userId = Convert.ToInt32(rdr["userId"]);
                    cart.movieName = rdr["movieName"].ToString();
                    cart.moviePrice = Convert.ToDouble(rdr["moviePrice"]);
                    cart.purchaseDate = Convert.ToDateTime(rdr["purchaseDate"]);
                 
                    myCart.Add(cart);
                    Console.WriteLine(myCart);
                }
                sqlCon.Close();
            }
            return myCart;
        }
    }
}