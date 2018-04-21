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

        int statusToInt(string status)
        {
            int stat_int = 0;
            switch (status)
            {
                case "Shipped":
                    stat_int = 1;
                    break;
                case "Delivered":
                    stat_int = 2;
                    break;    
            }
            return stat_int;
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
                        con.Open();
                        string updateShipmentQuery = "UPDATE SHIPMENT SET SHIPMENT.Delivery_Status = @newStatus WHERE SHIPMENT.Tracking_Num = @trackingNo";

                        SqlCommand cmd = new SqlCommand(updateShipmentQuery, con);
                        cmd.Parameters.AddWithValue("@newStatus", statusToInt(DeliveryStatusList.SelectedValue));
                        cmd.Parameters.AddWithValue("@trackingNo", txtTrackingNumber.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }
    }

}