using RAisoStationery.Controllers;
using RAisoStationery.Dataset;
using RAisoStationery.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class TransactionReport : System.Web.UI.Page
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


                }
                else if (Session["userId"] == null && Request.Cookies["userCookie"] == null)
                {

                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
            TransReport transactionReport = new TransReport();
            RAisoDataset rAisoDataset = TransactionController.showReport();
            transactionReport.SetDataSource(rAisoDataset);
            CRV_transaction.ReportSource = transactionReport;
        }
    }
}