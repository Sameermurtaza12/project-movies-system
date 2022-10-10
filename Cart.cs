using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMoviesSystem.BusinessLayer;
namespace OnlineMoviesSystem.Models
{
    public class Cart
    {
        public int invoiceNo { get; set; }
        public int userId { get; set; }

        public string movieName { get; set; }
        public double moviePrice { get; set; }

        public DateTime purchaseDate { get; set; }
        public List<Cart> FetchNow(int id)
        {
            BLCart cart = new BLCart();
            List<Cart> myCart = cart.FetchCart(id);
            return myCart;
        }
        public void Delete(int id)
        {
            BLCart cart = new BLCart();
            cart.DeleteNow(id);
        }
   
        public void RemoveCart(int userId)
        {
            BLCart cart = new BLCart();
            cart.Remove(userId);
        }
    }

}