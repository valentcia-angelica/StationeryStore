using Microsoft.SqlServer.Server;
using RAisoStationery.Model;
using RAisoStationery.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RAisoStationery.Handlers
{
    public class UserHandler
    {
        public static Boolean RegisterNewUser(string name, string gender, string pass, string address, string role, string phone, string dob)
        {
            MsUser checkName = UserRepository.checkName(name);
            if (checkName == null)
            {
                UserRepository.InsertNewUser(name, gender, pass, address, role, phone, dob);
                return true;
            }
            return false;

        }

        public static Boolean updateProfile(string userId, string newUsername, string gender, string newPass, string newAddress, string newPhone, string dob)
        {
            MsUser checkName = UserRepository.checkName(newUsername);
            if (checkName == null)
            {
                UserRepository.updateUser(userId, newUsername, gender, newPass, newAddress, newPhone, dob);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static MsUser doLogin(string name, string password)
        {
            if (checkNamePassword(name, password))
            {
                MsUser user = UserRepository.Login(name, password);
                return user;

            }
            else
            {
                return null;
            }

        }

        public static Boolean checkNamePassword(string name, string password)
        {
            MsUser user = UserRepository.checkName(name);
            //string nameVal = UserRepository.takeNameVal(name);
            if (user == null)
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (user.UserName[i] != name[i])
                {
                    return false;
                    
                }
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (user.UserPassword[i] != password[i])
                {
                    return false;
                    
                }
            }
            return true;
        }

        public static string checkRole(string name)
        {
            MsUser user = UserRepository.checkName(name);
            if (user != null)
            {
                return user.UserRole;
            }
            else
            {
                return null;
            }
        }

        public static string checkId(string name)
        {
            MsUser user = UserRepository.checkName(name);
            if (user != null)
            {
                return user.UserID.ToString();
            }
            else
            {
                return "";
            }

        }

        public static string checkName(string id)
        {
            MsUser user = UserRepository.checkId(id);
            if (user != null)
            {
                return user.UserName;
            }
            else
            {
                return "";
            }
        }

        public static string checkRoleById(string userId)
        {
            MsUser user = UserRepository.checkId(userId);
            if (user != null)
            {
                return user.UserRole;
            }
            else
            {
                return "";
            }
        }

        public static string checkAddress(string userId)
        {
            MsUser user = UserRepository.checkId(userId);
            if (user != null)
            {
                return user.UserAddress;
            }
            else
            {
                return "";
            }
        }

        public static string checkPhone(string userId)
        {
            MsUser user = UserRepository.checkId(userId);
            if (user != null)
            {
                return user.UserPhone;
            }
            else
            {
                return "";
            }
        }

        public static string checkOldPass(string userId)
        {
            MsUser user = UserRepository.checkId(userId);
            if (user != null)
            {
                return user.UserPassword;
            }
            else
            {
                return "";
            }
        }


    }
}