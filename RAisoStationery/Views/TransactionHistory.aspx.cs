using RAisoStationery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
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
                    
                    
                    History_GV.DataSource = TransactionController.showHistorybyUserId(id);
                    History_GV.AutoGenerateColumns = false;
                    History_GV.DataBind();
                }
                else if (Session["userId"] == null && Request.Cookies["userCookie"] == null)
                {

                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }
        }


        protected void History_GV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string transactionId = History_GV.SelectedRow.Cells[1].Text;
            string url = string.Format("~/Views/DetailTransactionHistory.aspx?id=" + transactionId);
            Response.Redirect(url);
        }

        
    }
}