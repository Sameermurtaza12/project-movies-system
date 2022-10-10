using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.DataLayer;

namespace OnlineMoviesSystem.BusinessLayer
{
    public class BLAddGenre
    {
        //add genre
        public void Add(string genreName)
        {
            DLAddGenre addGenre = new DLAddGenre();
            addGenre.AddNow(genreName);
        }
    }
}