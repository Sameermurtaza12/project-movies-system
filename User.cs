using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.BusinessLayer;
namespace OnlineMoviesSystem.Models
{
    //this is my user class and its attributes
    public class User 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string type { get; set; }

        //method to check user authorization
        public string CheckUser(string name, string password)
        {
            BLUser user = new BLUser();
            return user.Fetch(name, password);
        }
        //check user id
        public int CheckId(string name, string password)
        {
            BLUser user = new BLUser();
            return user.FetchId(name, password);
        }
    }
}