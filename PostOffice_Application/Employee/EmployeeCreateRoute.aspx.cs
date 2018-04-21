using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application.Employee
{
    public partial class EmployeeCreateRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateRoute_Click(object sender, EventArgs e)
        {
            if(txtDestinationAddr.Text=="")
            {
                lblCreateRouteInfo.ForeColor = System.Drawing.Color.Red;
                lblCreateRouteInfo.Text = "Please enter a destination";
                lblCreateRouteInfo.Visible = true;
            }
            else if (txtDriverID.Text=="")
            {
                lblCreateRouteInfo.ForeColor = System.Drawing.Color.Red;
                lblCreateRouteInfo.Text = "Please enter a driver ID";
                lblCreateRouteInfo.Visible = true;
            }
            else if(txtStartingAddr.Text=="")
            {
                lblCreateRouteInfo.ForeColor = System.Drawing.Color.Red;
                lblCreateRouteInfo.Text = "Please enter a starting address";
                lblCreateRouteInfo.Visible=true;

            }
            else
            {

            }
        }
    }
}