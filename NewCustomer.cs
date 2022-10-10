using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.BusinessLayer;
namespace OnlineMoviesSystem.Models
{
    //this is my new customer class with attributes
    public class NewCustomer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public string fullName { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public int age { get; set; }
        //add new customer method with the parameters
        public void AddCustomer(string name, string password, string userType, string fullName, string contact, string address, string city, string country, string state, int age)
        {
            BLNewCustomer newCustomer = new BLNewCustomer();
            newCustomer.Add(name, password, userType, fullName, contact, address, city, country, state, age);
        }

    }
}