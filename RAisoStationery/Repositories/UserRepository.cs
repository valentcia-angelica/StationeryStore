using RAisoStationery.Factories;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace RAisoStationery.Repositories
{
    public class UserRepository
    {
        private static RAisoDbEntitiesNew db = DbSingleton.getInstance();

        public static void InsertNewUser(string name, string gender, string pass, string address, string role, string phone, string dob)
        {
            MsUser lastUser = (from x in db.MsUsers orderby x.UserID descending select x).FirstOrDefault();
            int id = 0;
            if (lastUser != null)
            {
                id = lastUser.UserID;
            }
            MsUser newUser = UserFactory.CreateUser(name, gender, pass, address, role, phone, dob);
            db.MsUsers.Add(newUser);
            db.SaveChanges();
            //db.MsUsers.Add(newUser);
            //db.SaveChanges();

            
        }


        public static MsUser checkName(string name)
        {
            return (from x in db.MsUsers where x.UserName.Equals(name) select x).FirstOrDefault();

        }
        

        public static MsUser checkId(string userId)
        {
            int id_Num = Convert.ToInt32(userId);
            return (from x in db.MsUsers where x.UserID == id_Num select x).FirstOrDefault();
        }

        
        public static MsUser Login(string name, string password)
        {
            MsUser users = (from x in db.MsUsers where x.UserName.Equals(name) && x.UserPassword.Equals(password) select x).FirstOrDefault();

            return users;
        }

        public static void updateUser(string userId, string newUsername, string gender, string newPass, string newAddress, string newPhone, string dob)
        {
           
            MsUser currUser = checkId(userId);
            currUser.UserName = newUsername;
            currUser.UserAddress = newAddress;
            currUser.UserGender=gender;
            currUser.UserDOB = DateTime.ParseExact(dob, "dd-MM-yyyy", null);
            currUser.UserPhone = newPhone;
            currUser.UserPassword = newPass;
            db.SaveChanges();
        }
    }
}