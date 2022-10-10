using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.BusinessLayer;
namespace OnlineMoviesSystem.Models
{
    public class Genre
    {
        public string genreName { get; set; }
        public void AddIntoGenre(string genreName)
        {
            BLAddGenre addGenre = new BLAddGenre();
            addGenre.Add(genreName);
        }
    }
}