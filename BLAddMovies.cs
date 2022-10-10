using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.DataLayer;

namespace OnlineMoviesSystem.BusinessLayer
{
    public class BLAddMovies
    {
        //add movies
        public void Add(string movieName, double moviePrice, string movieRating, string genreName)
        {
            DLAddMovies addMovies = new DLAddMovies();
            addMovies.AddNow(movieName, moviePrice, movieRating, genreName);
        }
    }
}