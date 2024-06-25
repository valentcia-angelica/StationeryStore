using RAisoStationery.Dataset;
using RAisoStationery.Model;
using RAisoStationery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Handlers
{
    public class TransactionsHandler
    {
        public static List<object> getHistorybyUserId(string userId)
        {
            return TransactionRepository.transactionHistory(userId);
        }

        public static List<object> getDetail(string transactionId)
        {
            return TransactionRepository.detailTransaction(transactionId);
        }

        public static RAisoDataset getReport()
        {
            List<TransactionHeader> headerList = TransactionRepository.getHeaderList();
            return TransactionRepository.getDataset(headerList);
        }
    }
}