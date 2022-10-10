using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.DataLayer;
namespace OnlineMoviesSystem.BusinessLayer
{
    public class BLNewCustomer
    {
        //add new customer
        public void Add(string name, string password, string userType, string fullName, string contact, string address, string city, string country, string state, int age)
        {
            DLNewCustomer newCustomer = new DLNewCustomer();
            newCustomer.RegisterCustomer(name, password, userType, fullName, contact, address, city, country, state, age);
        }

    }
}