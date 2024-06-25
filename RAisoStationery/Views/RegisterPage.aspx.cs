using RAisoStationery.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAisoStationery.Views
{
    public partial class ResgisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            String name = TxbName.Text;
            string gender = "";
            bool genderSelected = true;
            if (RadBtn_Male.Checked)
            {
                gender = RadBtn_Male.Text;
            }
            else if(RadBtn_Female.Checked)
            {
                gender = RadBtn_Female.Text;
            }else
            {
                genderSelected = false;
            }
            string phone = TxbPhone.Text;
            string address = TxbAddress.Text;
            string pass = TxbPass.Text;
            string role = "Customer";
            string dob = "";
            if(Cld.SelectedDates.Count == 0)
            {
                dob = "";
            }
            else
            {

             dob = Cld.SelectedDate.ToString("dd-MM-yyyy");
            }

            LblError.Text = UserController.ValidateRegistration(name, gender,genderSelected, pass, address, role, phone, dob);

            
        }

    }
}