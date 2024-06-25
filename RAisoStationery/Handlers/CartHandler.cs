using RAisoStationery.Factories;
using RAisoStationery.Model;
using RAisoStationery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Handlers
{
    public class CartHandler
    {
        public static void toOrder(string userId, string statId, int qty)
        {
            int statIdNum = Convert.ToInt32(statId);
            int userIdNum = Convert.ToInt32(userId);
            Cart carts = CartRepository.getCartByIds(userIdNum, statIdNum);

            if (carts == null)
            {
                Cart newCart = CartFactory.createNewCart(userIdNum, statIdNum, qty);
                CartRepository.insertNewCart(newCart);
            }
            else
            {
                CartRepository.addQuantity(carts, qty);
            }
        }

        public static List<object> getlist(string userid)
        {
            return CartRepository.showListbyUserId(userid);
        }

        public static void updateCartQuantity(string userId, string statId, string quantity)
        {

            CartRepository.updateCart(userId, statId, quantity);

        }

        public static void checkOutCart(string userId)
        {
            List<Cart> listCart = CartRepository.getCart_byUserId(userId);
            if(listCart != null)
            {
                TransactionHeader newHeader = TransactionFactory.createNewHeader(userId);
                TransactionRepository.addNewHeader(newHeader);

                List<TransactionDetail> transactionDetail = TransactionFactory.createTransactionDetail(newHeader, listCart);
                TransactionRepository.addNewDetail(transactionDetail);

                CartRepository.removeAllCartList(listCart);
            }
        }

        public static void checkToDel(int userId, int statId)
        {
            
            Cart toDel = CartRepository.getCartByIds(userId, statId);
            if(toDel != null)
            {
                CartRepository.delCart(userId, statId);
            }
        }
    }
}