using RAisoStationery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class Customer_UpdateCart : System.Web.UI.Page
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
                    if (!role.Equals("Customer"))
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                    string statId = Request.QueryString["id"];
                    TxbStatName.Text = StationeryController.getNameById(statId);
                    TxbStatPrice.Text = StationeryController.getPriceById(statId);

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


            string statId = Request.QueryString["id"];
            string statName = TxbStatName.Text;
            string statPrice = TxbStatPrice.Text;
            string qty = TxbQty.Text;
            if (string.IsNullOrWhiteSpace(qty))
            {
                LblError.Text = "Quantity must be filled!";
            }
            else
            {

                LblError.Text = CartController.toUpdate(id, statId, qty);
                if (LblError.Text == "success")
                {
                    Response.Redirect("~/Views/Customer_CartPage.aspx");
                }
            }
        }


    }
}