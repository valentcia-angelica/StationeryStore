using RAisoStationery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        public static int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null || Request.Cookies["userCookie"] != null)
                {
                    string role = "";
                    string userId = "";
                    if (HttpContext.Current.Request.Cookies["userCookie"] != null)
                    {
                        userId = Request.Cookies["userCookie"].Value;
                        
                    }
                    else if (HttpContext.Current.Request.Cookies["userCookie"] == null)
                    {
                        userId = (string)System.Web.HttpContext.Current.Session["userId"];
                    }
                    role = UserController.checkRoleById(userId);
                    
                    Response.Redirect("~/Views/HomePage.aspx");
                    
                }
                
            }
           
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxbName.Text;
            string password = TxbPass.Text;
            bool isRemember = RememberMe.Checked;

            string result = UserController.ValidateLogin(username, password);
            if(result == null)
            {
                LblError.Text = "Wrong username or password!";
            }
            else
            {
                
                string id = UserController.checkIdByName(username);
                Session["userId"] = id;
                
                if (isRemember)
                {
                    HttpCookie userCookie = new HttpCookie("userCookie");
                    userCookie.Value = id;
                    userCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userCookie);

                }
                
                Response.Redirect("~/Views/HomePage.aspx");
               

            }
        }
    }
}