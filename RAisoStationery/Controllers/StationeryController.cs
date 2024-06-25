using RAisoStationery.Dataset;
using RAisoStationery.Handlers;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Controllers
{
    public class StationeryController
    {
        public static void toDelete(string id)
        {
            StationeryHandler.checkToDelete(id);
        }

        public static string toInsertStationery(string name, int price)
        {
            string priceString = price.ToString();
            if (name == "")
            {
                return "Name must be filled";
            }if(name.Length < 3 || name.Length > 50)
            {
                return "name length must 3-50 characters!";
            }
            int priceValue;
            if (!int.TryParse(priceString, out priceValue))
            {
                return "Price must be numeric";
            }
            if (price < 2000)
            {
                return "price must be >= 2000!";
            }
            else
            {
                if(StationeryHandler.inputStationery(name, price) == true)
                {
                    return "success";
                }
                else
                {
                    return "Stationery already inserted";
                }
            }
        }

        public static string toUpdate(string id, string name, string price)
        {
            int priceNum = Convert.ToInt32(price);
            if(name == "")
            {
                return "Name must be filled!";
            }
            if (name.Length < 3 || name.Length > 50)
            {
                return "name length must 3-50 characters!";
            }
            
            if (priceNum < 2000)
            {
                return "price must be >= 2000!";
            }
            else
            {
                if(StationeryHandler.updateStationery(id, name, price) == true)
                {
                    return "success";
                }
                
                
                return "";
                
            }
        }

        public static List<object> statList()
        {
            return StationeryHandler.getlist();
        }

        public static List<MsStationery> allStationeryList()
        {
            return StationeryHandler.getAllList();
        }

        public static int getIdbyName(string name)
        {
            return StationeryHandler.getId(name);
        }

        public static string getNameById(string id)
        {
            return StationeryHandler.getNameById(id);
        }

        public static string getPriceById(string id)
        {
            return StationeryHandler.getPriceById(id);
        }

        
    }
}