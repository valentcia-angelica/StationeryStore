using RAisoStationery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null || Request.Cookies["userCookie"] != null)
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

                    if (role.Equals("Admin"))
                    {
                        
                        BtnLogout.Visible = true;
                        BtnTransactionReport.Visible = true;
                        BtnUpdProfileAdmin.Visible = true;
                    }else if(role.Equals("Customer"))
                    {
                        
                        BtnLogout.Visible = true;
                        BtnCart.Visible = true;
                        BtnTransactionHistory.Visible = true;
                        BtnUpdProfileCustomer.Visible = true;
                    }
                    
                }
                else if(Session["userId"] == null && Request.Cookies["userCookie"] == null)
                {
                    
                    BtnRegister.Visible = true;
                    btnLogin.Visible = true;

                }
                
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies["userCookie"].Expires = DateTime.Now.AddDays(-2);
            Session.Remove("userId");
            
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void BtnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Customer_CartPage.aspx");
        }

        

        protected void BtnTransactionHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }

        protected void BtnTransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionReportPage.aspx");
        }

        protected void BtnUpdProfileCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfilePage.aspx");
        }

        protected void BtnUpdProfileAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/UpdateProfilePage.aspx");

        }


        protected void btnHomeAdmin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");

        }

        protected void btnHomeCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void HomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");

        }
    }
}