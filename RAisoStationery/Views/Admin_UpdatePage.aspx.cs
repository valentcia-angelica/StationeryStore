using RAisoStationery.Controllers;
using RAisoStationery.Model;
using RAisoStationery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class Admin_UpdatePage : System.Web.UI.Page
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
                    if (!role.Equals("Admin"))
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }

                   TxbId.Text = Request.QueryString["id"];
                    string statId = TxbId.Text;
                    TxbName.Text = StationeryController.getNameById(statId);
                    TxbPrice.Text = StationeryController.getPriceById(statId);
                }
                else if (Session["userId"] == null && Request.Cookies["userCookie"] == null)
                {

                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id = TxbId.Text;
            string name = TxbName.Text;
            string price = TxbPrice.Text;

            if (string.IsNullOrEmpty(name))
            {
                LblError.Text = "Stationery name must be filled!";
            }
            if(string.IsNullOrEmpty(price))
            {
                LblError.Text = "Stationery name must be filled!";
            }
            if(!int.TryParse(price, out int numericValue))
            {
                LblError.Text = "Price must be numeric!";
            }
            else
            {


            LblError.Text = StationeryController.toUpdate(id, name, price);
            if (LblError.Text == "success")
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            }
        }
    }
}