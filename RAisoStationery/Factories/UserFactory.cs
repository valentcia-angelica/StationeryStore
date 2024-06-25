using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAisoStationery.Factories
{
    public class UserFactory
    {
        public static MsUser CreateUser(string name, string gender, string pass, string address, string role, string phone, string dob)
        {

            MsUser users = new MsUser();
            users.UserName = name;
            users.UserGender = gender;
            users.UserPassword = pass;
            users.UserRole = role;
            users.UserDOB = DateTime.ParseExact(dob, "dd-MM-yyyy", null);
            users.UserPhone = phone;
            users.UserAddress = address;
            return users;
        }

    }
}