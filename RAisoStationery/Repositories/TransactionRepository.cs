using RAisoStationery.Dataset;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RAisoStationery.Repositories
{
    public class TransactionRepository
    {
        private static RAisoDbEntitiesNew db = DbSingleton.getInstance();

        public static void addNewHeader(TransactionHeader newHeader)
        {
            db.TransactionHeaders.Add(newHeader);
            db.SaveChanges();
        }

        public static void addNewDetail(List<TransactionDetail> newDetailList)
        {
            foreach(var detail in newDetailList)
            {
                db.TransactionDetails.Add(detail);
            }
            db.SaveChanges();
        }

        public static List<object> transactionHistory(string userId)
        {
            int userIdNum = Convert.ToInt32(userId);
            var getHistory = (from th in db.TransactionHeaders
                              join mu in db.MsUsers on th.UserID equals mu.UserID
                              
                              where th.UserID == userIdNum
                              select new
                              {
                                  th.TransactionID,
                                  th.TransactionDate,
                                  mu.UserName
                              }).ToList();

            List<object> historyList = getHistory.Select(x => (object)new
            {
                TransactionId = x.TransactionID,
                TransactionDate = x.TransactionDate,
                UserName = x.UserName
            }).ToList();

            return historyList;
        }

        public static List<object> detailTransaction(string transactionId)
        {
            int transIdNum = Convert.ToInt32(transactionId);
            var details = (from td in db.TransactionDetails
                           join ms in db.MsStationeries on td.StationeryID equals ms.StationeryID
                           where td.TransactionID == transIdNum
                           select new
                           {
                               ms.StationeryName,
                               ms.StationeryPrice,
                               td.Quantity
                           }).ToList();
            List<object> detailList = details.Select(x => (object)new
            {
                StationeryName = x.StationeryName,
                StationeryPrice = x.StationeryPrice,
                StationeryQuantity = x.Quantity
            }).ToList();

            return detailList;
        }

        

        public static RAisoDataset getDataset(List<TransactionHeader> headerList)
        {
            RAisoDataset dataset = new RAisoDataset();

            
            foreach (TransactionHeader th in headerList)
            {
                var headerRow = dataset.TransactionHeader.NewRow();
                headerRow["transactionId"] = th.TransactionID;
                headerRow["userId"] = th.UserID;
                headerRow["transactionDate"] = th.TransactionDate;

                int subTotal = 0; 
                foreach (TransactionDetail td in th.TransactionDetails)
                {
                    var detailRow = dataset.TransactionDetail.NewRow();
                    detailRow["transactionId"] = th.TransactionID; 
                    detailRow["stationeryName"] = td.MsStationery.StationeryName;
                    detailRow["quantity"] = td.Quantity;
                    detailRow["stationeryPrice"] = td.MsStationery.StationeryPrice;

                    int detailSubTotal = td.Quantity * td.MsStationery.StationeryPrice;
                    detailRow["subTotal"] = detailSubTotal;

                    subTotal += detailSubTotal;
                    dataset.TransactionDetail.Rows.Add(detailRow);
                }
                headerRow["grandTotal"] = subTotal; 
                dataset.TransactionHeader.Rows.Add(headerRow);
            }
            return dataset;
        }


        public static List<TransactionHeader> getHeaderList()
        {
            return db.TransactionHeaders.ToList();

        }
    }
}