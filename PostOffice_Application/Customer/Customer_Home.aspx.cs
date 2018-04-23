using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PostOffice_Application
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null)
            {
                USERNAME.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");


                USERNAME.Text = "Account: " + Session["Username"].ToString();
                DropDownList1.Visible = true;
               // WelcomeLabel.Text = "Welcome to your Post Office HomePage! "; //Session[Username] give the username 
            }
            else
            {
                DropDownList1.Enabled = false;
                // WelcomeLabel.Text = "Welcome to our Post Office Customer HomePage! There seems to be an error with your session. Please log off and try again!";
            }
        }

        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Contents.RemoveAll();
            Response.Redirect("../Start/Login.aspx");
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["TrackingID"] = DropDownList1.SelectedValue;
            // int SelectedValue = int.Parse(DropDownList1.SelectedValue.Trim());
            MultiView1.SetActiveView(View1);

            //Response.Redirect("Customer_ShipmentDetail.aspx?id=@Tracking_Num");
        }
        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            DropDownList1.Items.Insert(0, new ListItem("--Select Tracking Number--", "0"));
        }
    }
}