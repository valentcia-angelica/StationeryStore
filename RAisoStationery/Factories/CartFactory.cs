using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Factories
{
    public class CartFactory
    {
        public static Cart createNewCart(int userId, int statId, int qty)
        {
            Cart carts = new Cart();
            carts.UserID = userId;
            carts.StationeryID = statId;
            carts.Quantity = qty;
            return carts;
        }
    }
}