using RAisoStationery.Model;
using RAisoStationery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Handlers
{
    public class StationeryHandler
    {
        public static void checkToDelete(string id)
        {
            int idNum = Convert.ToInt32(id);
            MsStationery toDel = StationeryRepository.checkStatById(idNum);
            if(toDel != null)
            {
                StationeryRepository.deleteStationery(Convert.ToInt32(id));
            }
        }

        public static Boolean inputStationery(string name, int price)
        {
            MsStationery checkStat = StationeryRepository.checkStatByName(name);
            if (checkStat == null)
            {
                StationeryRepository.insertNewStationery(name, price);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static  Boolean updateStationery(string id, string name, string price)
        {
            MsStationery toUpdate = StationeryRepository.checkStatById(Convert.ToInt32(id));
            if(toUpdate != null)
            {
                StationeryRepository.updateNewStationery(id, name, price);
                return true;
            }return false;

            
        }
        public static List<object> getlist()
        {
            return StationeryRepository.showStationeriesList();
        }

        public static List<MsStationery> getAllList()
        {
            return StationeryRepository.showAllStationeryList();
        }

        public static int getId(string name)
        {
            MsStationery check = StationeryRepository.checkStatByName(name);
            if(check != null)
            {
                return check.StationeryID;
            }
            return 0;
        }

        public static string getNameById(string id)
        {
            int idNum = Convert.ToInt32(id);
            MsStationery check = StationeryRepository.checkStatById(idNum);
            if(check != null)
            {
                return check.StationeryName;
            }
            return null;
        }

        public static string getPriceById(string id)
        {
            int idNum = Convert.ToInt32(id);
            MsStationery check = StationeryRepository.checkStatById(idNum);
            if (check != null)
            {
                return check.StationeryPrice.ToString();
            }
            return null;
        }
        
    }
}