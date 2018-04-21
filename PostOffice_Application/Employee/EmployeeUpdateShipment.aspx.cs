using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application
{
    public partial class EmployeeUpdateShipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        bool isValidText(string text)
        {
            if (text == "")
                return false;
            else
                return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!isValidText(txtTrackingNumber.Text))
            {
                lblInvalidInfo.Text = "Invalid tracking number.";
                lblInvalidInfo.Visible = true;
            }
            else if (DeliveryStatusList.SelectedValue == "")
            {
                lblInvalidInfo.Text = "Please choose a new delivery status.";
                lblInvalidInfo.Visible = true;
            }
            else
            {
               
            }

        }
    }
}