using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.BusinessLayer;
namespace OnlineMoviesSystem.Models
{
    //this is my movies class with attributes 
    public class Movies
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public double moviePrice { get; set; }
        public string movieRating { get; set; }
        public string genreName { get; set; }
        //get the movies list from the database
        public List<Movies> Fetch()
        {
            BLMovies movie = new BLMovies();
            List<Movies> movies = movie.FetchMovies();
            return movies;
        }
        //add new movies
        public void AddIntoMovies(string movieName, double moviePrice, string movieRating, string genreName)
        {
            BLAddMovies addMovies = new BLAddMovies();
            addMovies.Add(movieName, moviePrice, movieRating, genreName);
        }
        public void AddInCart(int id, int userId)
        {
            BLCart cart = new BLCart();
            cart.AddCart(id,userId);
        }
        public void Delete(int id)
        {
            BLMovies movie = new BLMovies();
            movie.DeleteNow(id);
        }
    }
}