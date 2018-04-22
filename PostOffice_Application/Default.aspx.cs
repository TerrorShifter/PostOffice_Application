using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace PostOffice_Application
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string trackingNum = " ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtBoxTracking.Text = null;
                lblError.Visible = false;
                lblShipped.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx"); //redirect to Login Page
        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx"); //redirect to Sign Up Page
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
        }
        
  
        protected void Track_Click(object sender, EventArgs e)
        {
            long parseInt = 1;
            trackingNum = txtBoxTracking.Text;
            if (!long.TryParse(trackingNum, out parseInt) ) //if input tracking number is invalid(contains letters), show error
            {
                lblError.Visible = true;
                lblShipped.Visible = false;
            }
            else
            {
                lblError.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                try
                {
                    var constr = new SqlConnectionStringBuilder
                    {
                        DataSource = "team-4-post-office-dbs.database.windows.net",
                        InitialCatalog = "Post_Office",
                        UserID = "eniolakunle",
                        Password = "%Eniola1997%"
                    };

                    using (SqlConnection conn = new SqlConnection(constr.ConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT Status_String FROM SHIPMENT, DELIVERY_STRING, DELIVERY_STATUS WHERE Tracking_Num = @TrackingID AND Delivery_Status_ID = Delivery_Status AND Status = Status_ID";
                        SqlCommand showStatus = new SqlCommand(query, conn);
                        showStatus.Parameters.AddWithValue("@TrackingID", trackingNum);
                        lblShipped.Text = showStatus.ExecuteScalar().ToString();
                        checkStatus(lblShipped.Text, conn);
                        lblShipped.Visible = true;
                        conn.Close();

                    }
                    
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (NullReferenceException ex) //tracking number does not exist, NULL package
                {
                    Console.WriteLine(ex.ToString());
                    lblError.Visible = true;
                }

            }

        }

        void checkStatus(string status, SqlConnection connect)
        {
            string shipQuery = "SELECT Date_Shipped FROM SHIPMENT, DELIVERY_STRING, DELIVERY_STATUS WHERE Tracking_Num = @TrackingID AND Delivery_Status_ID = Delivery_Status";
            string estQuery = "SELECT Estimated_Arrival FROM SHIPMENT, DELIVERY_STRING, DELIVERY_STATUS WHERE Tracking_Num = @TrackingID AND Delivery_Status_ID = Delivery_Status";
            string arrQuery = "SELECT Arrival_Date FROM SHIPMENT, DELIVERY_STRING, DELIVERY_STATUS WHERE Tracking_Num = @TrackingID AND Delivery_Status_ID = Delivery_Status";

            switch (status)
            {
                case "In Transit":
                    SqlCommand trans = new SqlCommand(shipQuery, connect);
                    trans.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label1.Text = "Date Shipped: " + trans.ExecuteScalar().ToString();
                    Label1.Visible = true;
                    trans = new SqlCommand(estQuery, connect);
                    trans.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label2.Text = "Est. Arrival: " + trans.ExecuteScalar().ToString();
                    Label2.Visible = true;
                    break;
                case "Out for Delivery":
                    SqlCommand outFor = new SqlCommand(shipQuery, connect);
                    outFor.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label1.Text = "Date Shipped: " + outFor.ExecuteScalar().ToString();
                    Label1.Visible = true;
                    outFor = new SqlCommand(estQuery, connect);
                    outFor.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label2.Text = "Est. Arrival: " + outFor.ExecuteScalar().ToString();
                    Label2.Visible = true;
                    break;
                case "Delivered":
                    SqlCommand deliv = new SqlCommand(shipQuery, connect);
                    deliv.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label1.Text = "Date Shipped: " + deliv.ExecuteScalar().ToString();
                    Label1.Visible = true;
                    deliv = new SqlCommand(arrQuery, connect);
                    deliv.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label2.Text = "Date Arrived: " + deliv.ExecuteScalar().ToString();
                    Label2.Visible = true;
                    break;
                case "Returned":
                    SqlCommand retur = new SqlCommand(shipQuery, connect);
                    retur.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label1.Text = "Date Shipped: " + retur.ExecuteScalar().ToString();
                    Label1.Visible = true;
                    retur = new SqlCommand(arrQuery, connect);
                    retur.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label2.Text = "Date Arrived: " + retur.ExecuteScalar().ToString();
                    Label2.Visible = true;
                    break;
                case "Failed to Deliver":
                    SqlCommand fail = new SqlCommand(shipQuery, connect);
                    fail.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label1.Text = "Date Shipped: " + fail.ExecuteScalar().ToString();
                    Label1.Visible = true;
                    fail = new SqlCommand(arrQuery, connect);
                    fail.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label2.Text = "Attempted Delivery: " + fail.ExecuteScalar().ToString();
                    Label2.Visible = true;
                    break;
                case "Processing":
                    SqlCommand process = new SqlCommand(estQuery, connect);
                    process.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label1.Text = "Est. Shipping: " + process.ExecuteScalar().ToString();
                    Label1.Visible = true;
                    break;

            }
        }

        protected void txtBoxTracking_TextChanged(object sender, EventArgs e)
        {

        }
    }
}