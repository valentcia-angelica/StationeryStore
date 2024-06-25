using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Repositories
{
    public class CartRepository
    {
        private static RAisoDbEntitiesNew db = DbSingleton.getInstance();
        public static void insertNewCart(Cart newCart)
        {
            db.Carts.Add(newCart);
            db.SaveChanges();
        }

        public static void addQuantity(Cart toUpdate, int qty)
        {
            if (toUpdate != null)
            {
                toUpdate.Quantity += qty;
                db.SaveChanges();
            }
        }

        public static Cart getCartByIds(int userId, int statIdNum)
        {
           return (from x in db.Carts where x.UserID == userId && x.StationeryID == statIdNum select x).FirstOrDefault();
        }

        //public static int getUserId(string userId, int statIdNum)
        //{
        //    return (from x in db.Carts where x.UserID == Convert.ToInt32(userId) && x.StationeryID == statIdNum select x.UserID).FirstOrDefault();
        //}

        //public static int getStatId_byName(string statName)
        //{

        //    return (from x in db.MsStationeries where x.StationeryName.Equals(statName) select x.StationeryID).FirstOrDefault();

        //}

        public static List<object> showListbyUserId(string userId)
        {
            int userIdNum = Convert.ToInt32(userId);
            var listCart = (from c in db.Carts
                            join s in db.MsStationeries on c.StationeryID equals s.StationeryID
                            where c.UserID == userIdNum
                            select new
                            {
                                s.StationeryName,
                                s.StationeryPrice,
                                c.Quantity
                            }).ToList();

            List<object> list = listCart.Select(x => (object)new
            {
                StationeryName = x.StationeryName,
                StationeryPrice = x.StationeryPrice,
                StationeryQuantity = x.Quantity
            }).ToList();
            return list;
        }

        public static void updateCart(string userId, string statId, string quantity)
        {
            int quantityNum = Convert.ToInt32(quantity);
            int statIdNum = Convert.ToInt32(statId);
            int userIdNum = Convert.ToInt32(userId);
            Cart currCart = getCartByIds(userIdNum, statIdNum);
            currCart.Quantity = quantityNum;

            db.SaveChanges();
        }

        public static List<Cart> getCart_byUserId(string userId)
        {
            int userIdNum = Convert.ToInt32(userId);
            return (from x in db.Carts where x.UserID == userIdNum select x).ToList();
        }

        public static void removeAllCartList(List<Cart> cartList)
        {
            foreach(var cart in cartList)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static void delCart(int userId, int statId)
        {
            Cart cartToDel = getCartByIds(userId, statId);
            db.Carts.Remove(cartToDel);
            db.SaveChanges();

        }
    }
}