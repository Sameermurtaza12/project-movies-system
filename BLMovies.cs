using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.DataLayer;
using OnlineMoviesSystem.Models;
namespace OnlineMoviesSystem.BusinessLayer
{
    public class BLMovies
    {
        //get movies list
        public List<Movies> FetchMovies()
        {
           
            DLMovies movie = new DLMovies();
            List<Movies> movies = movie.GetAllMovies();
            return movies;
        }
        public void DeleteNow(int id)
        {
            DLMovies movie = new DLMovies();
            movie.DeleteRow(id);
        }
    }
}