using RAisoStationery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RAisoStationery.Views
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {

                if (Session["userId"] != null || Request.Cookies["userCookie"] != null)
                {
                    string role = "";
                    string id = "";
                    if (Request.Cookies["userCookie"] != null)
                    {
                        id = Request.Cookies["userCookie"].Value;
                    }
                    else
                    {
                        id = (string)System.Web.HttpContext.Current.Session["userId"];
                    }
                    role = UserController.checkRoleById(id);
                   if(role != "Admin" && role != "Customer")
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }

                    
                    TxbName.Text = UserController.checkNameById(id);
                    TxbAddress.Text = UserController.getAddressById(id);
                    
                    TxbPhone.Text = UserController.getPhoneById(id);
                    TxbPass_Old.Text = UserController.getOldPassById(id);
                }
                else if (Session["userId"] == null && Request.Cookies["userCookie"] == null)
                {

                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            
            string id = "";
            if (Request.Cookies["userCookie"] != null)
            {
                id = Request.Cookies["userCookie"].Value;
            }
            else
            {
                id = (string)System.Web.HttpContext.Current.Session["userId"];
            }

            string gender = "";
            bool genderSelected = true;
            if (RadBtn_Male.Checked)
            {
                gender = RadBtn_Male.Text;
            }
            else if (RadBtn_Female.Checked)
            {
                gender = RadBtn_Female.Text;
            }
            else
            {
                genderSelected = false;
            }
            string newPhone = TxbPhone.Text;
            string newAddress = TxbAddress.Text;
            string newPass = TxbPass_New.Text;
            
            string newUsername = TxbName.Text;

            string dob = "";
            if (Cld.SelectedDates.Count == 0)
            {
                dob = "";
            }
            else
            {
                dob = Cld.SelectedDate.ToString("dd-MM-yyyy");
            }


            LblError.Text = UserController.toUpdate(id, newUsername, gender, genderSelected, newPass, newAddress, newPhone, dob);
          
        }
    }
}