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
    public class DLMovies
    {
        //get all movies list from the database
        public List<Movies> GetAllMovies()
        {
            List<Movies> movies = new List<Movies>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spGetMovies", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while(rdr.Read())
                {
                    Movies movie = new Movies();
                    movie.movieId = Convert.ToInt32(rdr["movieId"]);
                    movie.movieName = rdr["movieName"].ToString();
                    movie.moviePrice = Convert.ToDouble(rdr["moviePrice"]);
                    movie.movieRating = rdr["movieRating"].ToString();
                    movie.genreName = rdr["genreName"].ToString();
                    movies.Add(movie);
                }
                sqlCon.Close();
            }
            return movies;
        }
        public void DeleteRow(int movieId)
        {
            // me yaha huuuuuuuu
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("spDeleteFromMovies", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@movieId", movieId);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

        }
    }
}