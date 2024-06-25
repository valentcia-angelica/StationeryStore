using RAisoStationery.Controllers;
using RAisoStationery.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class HomePage : System.Web.UI.Page
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

                    if (role.Equals("Admin"))
                    {

                        Stationery_GV.Visible = true;


                        Stationery_GV.DataSource = StationeryController.allStationeryList();
                        Stationery_GV.DataBind();
                        foreach (GridViewRow row in Stationery_GV.Rows)
                        {
                            Button btnUpdate = (Button)row.FindControl("btnUpdate");
                            Button btnDelete = (Button)row.FindControl("btnDelete");

                            btnUpdate.Visible = true;
                            btnDelete.Visible = true;
                            btnInsert.Visible = true;


                        }
                        //Stationery_GV_Guest.Visible = false;

                    }
                    //else if (role.Equals("Customer"))
                    else if (role.Equals("Customer"))
                    {
                        Stationery_GV_Cust.DataSource = StationeryController.statList();
                        Stationery_GV_Cust.AutoGenerateColumns = false;
                        Stationery_GV_Cust.DataBind();
                        foreach (GridViewRow row in Stationery_GV_Cust.Rows)
                        {
                            Stationery_GV_Cust.Visible = true;
                            Button btnDetail = (Button)row.FindControl("BtnDetail");
                            btnDetail.Visible = true;
                        }
                        //Stationery_GV_Guest.Visible = false;
                    }
                }
                else if (Session["userId"] == null || Request.Cookies["userCookie"] == null)
                {

                    Stationery_GV_Cust.DataSource = StationeryController.statList();
                    Stationery_GV_Cust.AutoGenerateColumns = false;
                    Stationery_GV_Cust.DataBind();
                    foreach (GridViewRow row in Stationery_GV_Cust.Rows)
                    {
                        Stationery_GV_Cust.Visible = true;
                        Button btnDetail = (Button)row.FindControl("BtnDetail");
                        btnDetail.Visible = true;
                    }



                }


            }

        }




        protected void Stationery_GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idx = e.RowIndex;
            string id = Stationery_GV.Rows[idx].Cells[1].Text;
            StationeryController.toDelete(id);
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin_InsertPage.aspx");
        }



        protected void Stationery_GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                int idx = row.RowIndex;
                string id = Stationery_GV.Rows[idx].Cells[1].Text;
                string url = string.Format("~/Views/Admin_UpdatePage.aspx?id=" + id);
                Response.Redirect(url);

            }
        }

        protected void Stationery_GV_Cust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;
                int idx = row.RowIndex;
                string name = Stationery_GV_Cust.Rows[idx].Cells[1].Text;
                int id = StationeryController.getIdbyName(name);
                string url = string.Format("~/Views/DetailPage.aspx?id=" + id);
                Response.Redirect(url);
            }

        }




      
    }
}