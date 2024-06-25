using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Factories
{
    public class StationeryFactory
    {
        public static MsStationery createStationery(string name, int price)
        {
            MsStationery msStationery = new MsStationery();
            msStationery.StationeryName = name;
            msStationery.StationeryPrice= price;
            return msStationery;
        }
    }
}