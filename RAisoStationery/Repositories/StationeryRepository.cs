using RAisoStationery.Factories;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Repositories
{
    public class StationeryRepository
    {
        private static RAisoDbEntitiesNew db = DbSingleton.getInstance();

        public static void deleteStationery(int id)
        {
            MsStationery stats = (from x in db.MsStationeries where x.StationeryID == id select x).FirstOrDefault();
            db.MsStationeries.Remove(stats);
            db.SaveChanges();
        }

        public static MsStationery checkStatById(int id)
        {
            
            return (from x in db.MsStationeries where x.StationeryID == id select x).FirstOrDefault();
        }

        public static MsStationery checkStatByName(string name)
        {
            return (from x in db.MsStationeries where x.StationeryName.Equals(name) select x).FirstOrDefault();
        }

        public static void insertNewStationery(string name, int price)
        {
            MsStationery newStat = StationeryFactory.createStationery(name, price);
            db.MsStationeries.Add(newStat);
            db.SaveChanges();
        }

        public static void updateNewStationery(string id, string name, string price)
        {
            int idNum = Convert.ToInt32(id);
            MsStationery stat = (from x in db.MsStationeries where x.StationeryID == idNum select x).FirstOrDefault();
            stat.StationeryName = name;
            int priceNum = Convert.ToInt32(price);
            stat.StationeryPrice = priceNum;
            db.SaveChanges();
        }

        public static List<object> showStationeriesList()
        {
            //int userIdNum = Convert.ToInt32(userId);
            var listCart = (from  s in db.MsStationeries
                            select new
                            {
                                s.StationeryName,
                                
                               
                            }).ToList();

            List<object> list = listCart.Select(x => (object)new
            {
                StationeryName = x.StationeryName
                
            }).ToList();
            return list;
        }

        public static List<MsStationery> showAllStationeryList()
        {
            List<MsStationery> stationeries = (from x in db.MsStationeries select x).ToList();
            return stationeries;
        }
    }
}