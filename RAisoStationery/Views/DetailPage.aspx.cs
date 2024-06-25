using RAisoStationery.Controllers;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class Customer_HomePage : System.Web.UI.Page
    {
        RAisoDbEntitiesNew db = new RAisoDbEntitiesNew();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string statId = Request.QueryString["id"];
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
                    BtnAddToCart.Visible = true;
                    Quantity.Visible = true;
                    TxbQty.Visible = true;
                    //statId = Request.QueryString["id"];
                    TxbStatName.Text = StationeryController.getNameById(statId);
                    TxbStatPrice.Text = StationeryController.getPriceById(statId);

                }
                TxbStatName.Text = StationeryController.getNameById(statId);
                TxbStatPrice.Text = StationeryController.getPriceById(statId);

            }
        }

        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            string id = "";
            if (HttpContext.Current.Request.Cookies["userCookie"] != null)
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
                LblError.Text = CartController.CheckToOrder(id, statId, qty);
                if (LblError.Text == "success")
                {
                    Response.Redirect("~/Views/HomePage.aspx");

                }
                
            }
        }



    }
}