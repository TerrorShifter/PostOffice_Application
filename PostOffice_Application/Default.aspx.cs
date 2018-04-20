using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
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
                lblLastArrived.Visible = false;
                lblDelivered.Visible = false;
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
            if (!long.TryParse(trackingNum, out parseInt) || trackingNum.Length != 10) //if input tracking number is invalid(contains letters or not long enough), show error
            {
                lblError.Visible = true;
                lblShipped.Visible = false;
                lblLastArrived.Visible = false;
                lblDelivered.Visible = false;
            }
            else
            {
                lblError.Visible = false;
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
                        string query = "SELECT Delivery_Status FROM SHIPMENT WHERE Tracking_Num = @TrackingID";
                        SqlCommand showStatus = new SqlCommand(query, conn);
                        showStatus.Parameters.AddWithValue("@TrackingID", trackingNum);
                        lblShipped.Text = showStatus.ExecuteScalar().ToString();
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

        protected void txtBoxTracking_TextChanged(object sender, EventArgs e)
        {

        }
    }
}