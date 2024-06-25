using RAisoStationery.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace RAisoStationery.Controllers
{
    public class UserController
    {
        public static string ValidateRegistration(string name, string gender, bool genderSelected, string pass, string address, string role, string phone, string dob)
        {
           
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name must be filled";
            }
            if (name.Length < 5 || name.Length > 50)
            {
                return "Name length must be between 5 and 50 characters";
            }
            if (string.IsNullOrWhiteSpace(gender))
            {
                return "Gender must be filled";
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                return "Address must be filled";
            }
            if (!genderSelected)
            {
                return "Must select gender";
            }
            if (string.IsNullOrWhiteSpace(pass))
            {
                return "Password must be filled";
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                return "Phone must be filled";
            }
            if (!IsAlphaNumeric(pass))
            {
                return "Password must be alphanumeric";
            }
            if (string.IsNullOrWhiteSpace(dob))
            {
                return "Date of Birth must be filled";
            }

            DateTime dobDateTime;
            if (!DateTime.TryParse(dob, out dobDateTime))
            {
                return "Invalid Date of Birth";
            }
            if (DateTime.Now.AddYears(-1) < dobDateTime)
            {
                return "Must be at least 1 year old";
            }
            else
            {

                if (UserHandler.RegisterNewUser(name, gender, pass, address, role, phone, dob) == true)
                {
                    return "Registered success!";
                }
                else
                {
                    return "Name already registered!";
                }
            }


        }

        public static bool IsAlphaNumeric(string password)
        {
            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                
                if (hasLetter && hasDigit)
                {
                    return true;
                }
            }

            return false;
        }

        public static string ValidateLogin(string name, string password)
        {
            if (UserHandler.doLogin(name, password) != null)
            {
                return "Login success";
            }
            else
            {
                return null;
            }
        }

       

        public static string checkIdByName(string name)
        {
            return UserHandler.checkId(name);
        }

        public static string getAddressById(string userId)
        {
            return UserHandler.checkAddress(userId);
        }

        public static string getPhoneById(string userId)
        {
            return UserHandler.checkPhone(userId);
        }

        public static string getOldPassById(string userId)
        {
            return UserHandler.checkOldPass(userId);
        }
        
        public static string toUpdate(string userId, string newUsername, string gender, bool genderSelected, string newPass, string newAddress, string newPhone, string dob)
        {
           
            if (string.IsNullOrWhiteSpace(newUsername))
            {
                return "Name must be filled";
            }
            if (newUsername.Length < 5 || newUsername.Length > 50)
            {
                return "Name length must be between 5 and 50 characters";
            }
            if (string.IsNullOrWhiteSpace(gender))
            {
                return "Gender must be filled";
            }
            if (string.IsNullOrWhiteSpace(newAddress))
            {
                return "Address must be filled";
            }
            if (string.IsNullOrWhiteSpace(newPhone))
            {
                return "Phone must be filled";
            }
            if (!genderSelected)
            {
                return "Must select gender";
            }
            if (string.IsNullOrWhiteSpace(newPass))
            {
                return "Password must be filled";
            }
            if (!IsAlphaNumeric(newPass))
            {
                return "Password must be alphanumeric";
            }
            if (dob == "")
            {
                return "Date of Birth must be filled";
            }

            DateTime dobDateTime;
            if (!DateTime.TryParse(dob, out dobDateTime))
            {
                return "Invalid Date of Birth";
            }
            if (DateTime.Now.AddYears(-1) < dobDateTime)
            {
                return "Must be at least 1 year old";
            }
            else
            {

                if (UserHandler.updateProfile(userId, newUsername, gender, newPass, newAddress, newPhone, dob) == true)
                {
                    return "success";
                }
                else
                {
                    return "Name is not unique!";
                }
            }


        }

        public static string checkRoleById(string userId)
        {
            return UserHandler.checkRoleById(userId);
        }

        public static string checkNameById(string userId)
        {
            return UserHandler.checkName(userId);
        }
    }
}