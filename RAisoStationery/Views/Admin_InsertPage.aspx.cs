using RAisoStationery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class Admin_InsertPage : System.Web.UI.Page
    {
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
                    if (!role.Equals("Admin"))
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }

                }
                else if (Session["userId"] == null && Request.Cookies["userCookie"] == null)
                {

                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string stationeryName = TxbName.Text;
            int price = Convert.ToInt32(TxbPrice.Text);

            lblError.Text = StationeryController.toInsertStationery(stationeryName, price);
            if (lblError.Text == "success")
            {
                Response.Redirect("~/Views/HomePage.aspx");

            }

        }
    }
}