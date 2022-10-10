using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.DataLayer;
using OnlineMoviesSystem.Models;
namespace OnlineMoviesSystem.BusinessLayer
{
    public class BLCart
    {
        //add in cart
        public void AddCart(int id, int userId)
        {
            DLCart cart = new DLCart();
            cart.AddNow(id, userId);
        }
        //get cart list
        public List<Cart> FetchCart(int id)
        {

            DLCart cart = new DLCart();
            List<Cart> myCart = cart.GetAllItems(id);
            return myCart;
        }
        //delete cart
        public void DeleteNow(int id)
        {
            DLCart cart=new DLCart();
            cart.DeleteRow(id);
        }
        //remove user
     
        public void Remove(int userId)
        {
            DLCart cart = new DLCart();
            cart.RemoveNow(userId);
        }
    }
}