using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.DataLayer;
namespace OnlineMoviesSystem.BusinessLayer
{
    public class BLUser
    {
        public string Fetch(string name, string password)
        {
            DLUser user = new DLUser();
            return user.FetchCredentials(name, password);
        }
        public int FetchId(string name, string password)
        {
            DLUser user = new DLUser();
            return user.FetchCredentialsId(name, password);
        }
    }
}