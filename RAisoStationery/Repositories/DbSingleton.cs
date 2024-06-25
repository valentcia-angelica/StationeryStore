using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Repositories
{
    public class DbSingleton
    {
        private static RAisoDbEntitiesNew instance;
        public static RAisoDbEntitiesNew getInstance()
        {
            if (instance == null)
            {
                instance = new RAisoDbEntitiesNew();
            }
            return instance;
        }
    }
}