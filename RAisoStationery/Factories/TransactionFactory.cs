using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader createNewHeader(string userId)
        {
            int userIdNum = Convert.ToInt32(userId);
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.UserID = userIdNum;
            transactionHeader.TransactionDate = DateTime.Now;
            return transactionHeader;
        }

        public static List<TransactionDetail> createTransactionDetail(TransactionHeader newHeader, List<Cart> cartList)
        {
            List<TransactionDetail> detailList = new List<TransactionDetail>();
            foreach(var cart in cartList)
            {
                TransactionDetail transactionDetail = new TransactionDetail(); 
                transactionDetail.TransactionID = newHeader.TransactionID;
                transactionDetail.StationeryID = cart.StationeryID;
                transactionDetail.Quantity = cart.Quantity;
                detailList.Add(transactionDetail);
            }
            return detailList;
        }
    }
}