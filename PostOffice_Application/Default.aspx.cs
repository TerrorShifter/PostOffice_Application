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
                txtTracking.Value = null;
                lblError.Visible = false;
                lblShipped.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                lblLocate.Visible = false;
                imgCheck.Visible = false;
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
            trackingNum = txtTracking.Value.Trim();
            if (!long.TryParse(trackingNum, out parseInt) ) //if input tracking number is invalid(contains letters), show error
            {
                lblError.Visible = true;
                lblShipped.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                lblLocate.Visible = false;
                imgCheck.Visible = false;
            }
            else
            {
                lblError.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                lblLocate.Visible = false;
                lblShipped.ForeColor = System.Drawing.Color.Black;
                lblShipped.Visible = false;
                imgCheck.Visible = false;
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
            string shipQuery = "SELECT Date_Shipped FROM SHIPMENT, DELIVERY_STRING, DELIVERY_STATUS WHERE " +
                "Tracking_Num = @TrackingID AND Delivery_Status_ID = Delivery_Status";
            string delivQuery = "SELECT DISTINCT Street_Address1 FROM ADDRESS, SHIPMENT WHERE " +
                "Tracking_Num = @TrackingID AND Recipient_Address_ID = Address_ID";
            string deliv2Query = "SELECT DISTINCT CONCAT(City, ', ', State_ID) FROM ADDRESS, SHIPMENT WHERE " +
                "Tracking_Num = @TrackingID AND Recipient_Address_ID = Address_ID";
            string estQuery = "SELECT Estimated_Arrival FROM SHIPMENT, DELIVERY_STRING, DELIVERY_STATUS WHERE " +
                "Tracking_Num = @TrackingID AND Delivery_Status_ID = Delivery_Status";
            string arrQuery = "SELECT Arrival_Date FROM SHIPMENT, DELIVERY_STRING, DELIVERY_STATUS WHERE " +
                "Tracking_Num = @TrackingID AND Delivery_Status_ID = Delivery_Status";
            string locQuery = "SELECT DISTINCT Street_Address1 FROM ADDRESS AS A, SHIPMENT, PACKAGES_AT_STOP AS P, CURRENT_STOP AS C WHERE " +
                "P.Package_ID = @TrackingID AND P.Stop_ID = C.Stop_ID AND C.Address_ID = A.Address_ID";
            string cityQuery = "SELECT DISTINCT CONCAT(City, ', ', State_ID) FROM ADDRESS AS A, SHIPMENT, PACKAGES_AT_STOP AS P, CURRENT_STOP AS C WHERE " +
                "P.Package_ID = @TrackingID AND P.Stop_ID = C.Stop_ID AND C.Address_ID = A.Address_ID";

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

                    trans = new SqlCommand(locQuery, connect);
                    trans.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text = "Last Location: " + trans.ExecuteScalar().ToString() + ", ";
                    trans = new SqlCommand(cityQuery, connect);
                    trans.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text += trans.ExecuteScalar().ToString();
                    lblLocate.Visible = true;
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

                    outFor = new SqlCommand(locQuery, connect);
                    outFor.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text = "Last Location: " + outFor.ExecuteScalar().ToString() + ", ";
                    lblLocate.Visible = true;
                    outFor = new SqlCommand(cityQuery, connect);
                    outFor.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text += outFor.ExecuteScalar().ToString();
                    lblLocate.Visible = true;
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

                    deliv = new SqlCommand(delivQuery, connect);
                    deliv.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text = "Last Location: " + deliv.ExecuteScalar().ToString() + ", ";
                    lblLocate.Visible = true;
                    deliv = new SqlCommand(deliv2Query, connect);
                    deliv.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text += deliv.ExecuteScalar().ToString();
                    lblLocate.Visible = true;

                    lblShipped.ForeColor = System.Drawing.Color.Green;
                    imgCheck.Visible = true;
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

                    retur = new SqlCommand(locQuery, connect);
                    retur.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text = "Last Location: " + retur.ExecuteScalar().ToString() + ", ";
                    retur = new SqlCommand(cityQuery, connect);
                    retur.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text += retur.ExecuteScalar().ToString();
                    
                    lblLocate.Visible = true;
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

                    fail = new SqlCommand(locQuery, connect);
                    fail.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text = "Last Location: " + fail.ExecuteScalar().ToString() + ", ";
                    fail = new SqlCommand(cityQuery, connect);
                    fail.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text += fail.ExecuteScalar().ToString();
                    
                    lblLocate.Visible = true;
                    break;
                case "Processing":
                    SqlCommand process = new SqlCommand(estQuery, connect);
                    process.Parameters.AddWithValue("@TrackingID", trackingNum);
                    Label1.Text = "Est. Arrival: " + process.ExecuteScalar().ToString();
                    Label1.Visible = true;

                    process = new SqlCommand(locQuery, connect);
                    process.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text = "Last Location: " + process.ExecuteScalar().ToString() + ", ";
                    process = new SqlCommand(cityQuery, connect);
                    process.Parameters.AddWithValue("@TrackingID", trackingNum);
                    lblLocate.Text += process.ExecuteScalar().ToString();

                    lblLocate.Visible = true;
                    break;

            }
        }
    }
}