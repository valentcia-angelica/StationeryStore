using RAisoStationery.Dataset;
using RAisoStationery.Handlers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace RAisoStationery.Controllers
{
    public class TransactionController
    {
        public static List<object> showHistorybyUserId(string userId)
        {
            return TransactionsHandler.getHistorybyUserId(userId);
        }

        public static List<object> showDetail(string transactionId)
        {
            return TransactionsHandler.getDetail(transactionId);
        }

        public static RAisoDataset showReport()
        {
            return TransactionsHandler.getReport();
        }
    }
}