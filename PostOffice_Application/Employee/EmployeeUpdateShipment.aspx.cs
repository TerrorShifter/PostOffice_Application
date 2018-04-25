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

        //Used on dropdown list and tracking number field
        bool isValidText(string text)
        {
            if (text == "")
                return false;
            else
                return true;
        }

        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        //Since the Delivery_Status value is an int type in the database, the dropdown list selection must be converted to a corresponding integer.
        int statusToInt(string status)
        {
            int stat_int = 0;
            switch (status)
            {
                case "In Transit":
                    stat_int = 1;
                    break;
                case "Out for Delivery":
                    stat_int = 2;
                    break;
                case "Delivered":
                    stat_int = 3;
                    break;
                case "Returned":
                    stat_int = 4;
                    break;
                case "Failed to Deliver":
                    stat_int = 5;
                    break;
                case "Processing":
                    stat_int = 6;
                    break;
            }
            return stat_int;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!isValidText(txtTrackingNumber.Text))
            {
                lblInvalidInfo.ForeColor = System.Drawing.Color.Red;
                lblInvalidInfo.Text = "Invalid tracking number.";
                lblInvalidInfo.Visible = true;
            }
            else if (!isValidText(DeliveryStatusList.SelectedValue))
            {
                lblInvalidInfo.ForeColor = System.Drawing.Color.Red;
                lblInvalidInfo.Text = "Please choose a new delivery status.";
                lblInvalidInfo.Visible = true;
            }
            else
            {
                lblInvalidInfo.Visible = false;
                try
                {
                    var constr = new SqlConnectionStringBuilder
                    {
                        DataSource = "team-4-post-office-dbs.database.windows.net",
                        InitialCatalog = "Post_Office",
                        UserID = "luisflores",
                        Password = "luisf%1220"
                    };

                    using (SqlConnection con = new SqlConnection(constr.ConnectionString))
                    {
                        //Updates a row in the shipment table that matches the given tracking number with the new given delivery status.
                        con.Open();
                        string updateShipmentQuery = "UPDATE DELIVERY_STATUS SET DELIVERY_STATUS.Status = @newStatus WHERE Delivery_Status_ID=(SELECT SHIPMENT.Delivery_Status FROM SHIPMENT WHERE SHIPMENT.Tracking_Num = @trackingNo); ";
                        SqlCommand cmd = new SqlCommand(updateShipmentQuery, con);
                        cmd.Parameters.AddWithValue("@newStatus", statusToInt(DeliveryStatusList.SelectedValue));
                        cmd.Parameters.AddWithValue("@trackingNo", txtTrackingNumber.Text.Trim());
                        cmd.ExecuteNonQuery();
                        lblInvalidInfo.ForeColor = System.Drawing.Color.Green;
                        lblInvalidInfo.Text = "Shipment Status Updated.";
                        lblInvalidInfo.Visible = true;
                        if(DeliveryStatusList.SelectedValue=="Delivered")
                        {
                            cmd.CommandText = "UPDATE DELIVERY_STATUS SET Arrival_Date = @cDate FROM DELIVERY_STATUS INNER JOIN SHIPMENT ON DELIVERY_STATUS.Delivery_Status_ID = SHIPMENT.Delivery_Status WHERE (SHIPMENT.Tracking_Num = @tNo)";
                            cmd.Parameters.AddWithValue("@tNo", txtTrackingNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@cDate", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            lblInvalidInfo.ForeColor = System.Drawing.Color.Green;
                            lblInvalidInfo.Text = "Shipment Status Updated. Since the package was delivered, arrival date was added.";
                            lblInvalidInfo.Visible = true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    lblInvalidInfo.ForeColor = System.Drawing.Color.Red;
                    lblInvalidInfo.Text = "There was an error querying the database. Please try again.";
                    lblInvalidInfo.Visible = true;
                    Console.WriteLine(ex.ToString());
                }
            }

        }
    }

}