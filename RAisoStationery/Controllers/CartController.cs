using RAisoStationery.Handlers;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace RAisoStationery.Controllers
{
    public class CartController
    {
        public static string CheckToOrder(string userId, string statId, string qty)
        {

            int qtyNum = Convert.ToInt32(qty);
            if (qtyNum <= 0)
            {
                return "Quantity must > 0";
            }

            CartHandler.toOrder(userId, statId, qtyNum);
            return "success";


        }



        public static List<object> cart(string userId)
        {
            return CartHandler.getlist(userId);
        }

        public static string toUpdate(string userId, string statId, string quantity)
        {
            int quantityNum = Convert.ToInt32(quantity);
            if (quantityNum <= 0)
            {
                return "Quantity must > 0";
            }
            else
            {
                CartHandler.updateCartQuantity(userId, statId, quantity);
                return "success";
            }
        }

        public static void validateCO(string userId)
        {
            CartHandler.checkOutCart(userId);
        }

        public static void toDelete(int userId, int statId)
        {
            CartHandler.checkToDel(userId, statId);
        }
    }
}