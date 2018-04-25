using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PostOffice_Application
{
    public partial class EmployeeUpdateShipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList1.SelectedIndex = 0;
                DropDownList1.AppendDataBoundItems = true;
                DeliveryStatusList.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DeliveryStatusList.SelectedIndex = 0;
                DeliveryStatusList.AppendDataBoundItems = true;
            }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            bool readyToSubmit = true;
            if (DropDownList1.SelectedValue == "")
            {
                Label2.Text = "Required";
                readyToSubmit = false;
            }
            if (DeliveryStatusList.SelectedValue == "")
            {
                Label1.Text = "Required";
                readyToSubmit = false;
            }
            if(readyToSubmit)
            {
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
                        cmd.Parameters.AddWithValue("@newStatus", Convert.ToInt32(DeliveryStatusList.SelectedValue));
                        cmd.Parameters.AddWithValue("@trackingNo", Convert.ToInt32(DropDownList1.SelectedValue));
                        cmd.ExecuteNonQuery();
                        lblSuccess.ForeColor = System.Drawing.Color.Green;
                        
                        if (DeliveryStatusList.SelectedValue == "3")
                        {
                            cmd.CommandText = "UPDATE DELIVERY_STATUS SET Arrival_Date = @cDate FROM DELIVERY_STATUS INNER JOIN SHIPMENT ON DELIVERY_STATUS.Delivery_Status_ID = SHIPMENT.Delivery_Status WHERE (SHIPMENT.Tracking_Num = @tNo)";
                            cmd.Parameters.AddWithValue("@tNo", DropDownList1.SelectedValue);
                            cmd.Parameters.AddWithValue("@cDate", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            lblSuccess.ForeColor = System.Drawing.Color.Green;
                            lblSuccess.Text = "Shipment Status Updated. Since package was delivered, arrival date was added.";
                        }
                        else if (DeliveryStatusList.SelectedValue == "1")
                        {
                            cmd.CommandText = "UPDATE DELIVERY_STATUS SET Date_Shipped = @cDate FROM DELIVERY_STATUS INNER JOIN SHIPMENT ON DELIVERY_STATUS.Delivery_Status_ID = SHIPMENT.Delivery_Status WHERE (SHIPMENT.Tracking_Num = @tNo)";
                            cmd.Parameters.AddWithValue("@tNo", DropDownList1.SelectedValue);
                            cmd.Parameters.AddWithValue("@cDate", DateTime.Now);
                            cmd.ExecuteNonQuery();

                            lblSuccess.ForeColor = System.Drawing.Color.Green;
                            lblSuccess.Text = "Shipment Status Updated. Since the package was delivered, arrival date was added.";
                            lblSuccess.Visible = true;
                        }
                        else
                            lblSuccess.Text = "Shipment Status Updated.";
                        cmd.CommandText = "SELECT SHIPMENT.Tracking_Num AS [Tracking Number], DELIVERY_STATUS.Date_Shipped AS [Date Shipped], DELIVERY_STATUS.Arrival_Date AS [Arrival Date], DELIVERY_STRING.Status_String AS [Updated Shipping Status] FROM SHIPMENT LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID LEFT JOIN DELIVERY_STRING ON DELIVERY_STATUS.Status = DELIVERY_STRING.Status_ID WHERE Tracking_Num = @tNo;";
                       
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        updateGrid.DataSource = dt;
                        updateGrid.DataBind();
                        con.Close();
                    }
                }
                catch (SqlException ex)
                {
                    lblSuccess.ForeColor = System.Drawing.Color.Red;
                    lblSuccess.Text = "There was an error querying the database. Please try again.";
                    lblSuccess.Visible = true;
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }

        }
    }

}