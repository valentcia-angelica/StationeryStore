using RAisoStationery.Controllers;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class Customer_CartPage : System.Web.UI.Page
    {
        RAisoDbEntitiesNew db = new RAisoDbEntitiesNew();
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

                    Cart_GV.DataSource = CartController.cart(id);
                    Cart_GV.AutoGenerateColumns = false;
                    Cart_GV.DataBind();
                    if (Cart_GV.Rows.Count == 0)
                    {
                        LblCheck.Text = "Cart is Empty";
                        BtnCheckOut.Visible = false;
                        
                    }
                    else
                    {
                        LblCheck.Visible = false;
                        BtnCheckOut.Visible = true;
                        
                    }
                }
                else if (Session["userId"] == null && Request.Cookies["userCookie"] == null)
                {

                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }


        }


        protected void Cart_GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = "";
            if (Session["userId"] != null || Request.Cookies["userCookie"] != null)
            {

                if (Request.Cookies["userCookie"] != null)
                {
                    id = Request.Cookies["userCookie"].Value;
                   
                }
                else
                {
                    id = (string)System.Web.HttpContext.Current.Session["userId"];
                }
            }
            int idNum = Convert.ToInt32(id);
            if (e.CommandName == "Select")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                int idx = row.RowIndex;
                string name = Cart_GV.Rows[idx].Cells[1].Text;
                int statId = StationeryController.getIdbyName(name);
                string url = string.Format("~/Views/Customer_UpdateCart.aspx?id=" + statId);
                Response.Redirect(url);
            }
            else if (e.CommandName == "Delete")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                int idx = row.RowIndex;
                string name = Cart_GV.Rows[idx].Cells[1].Text;
                int statId = StationeryController.getIdbyName(name);
                CartController.toDelete(idNum, statId);
                Response.Redirect("~/Views/Customer_CartPage.aspx");

            }
        }


        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {


            if (Session["userId"] != null || Request.Cookies["userCookie"] != null)
            {
                string role = "";
                string id = "";
                if (Request.Cookies["userCookie"] != null)
                {
                    id = Request.Cookies["userCookie"].Value;
                    //role = UserController.checkRoleByName(name);
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
                CartController.validateCO(id);
                Response.Redirect("~/Views/Customer_CartPage.aspx");
            }
        }

    }
}