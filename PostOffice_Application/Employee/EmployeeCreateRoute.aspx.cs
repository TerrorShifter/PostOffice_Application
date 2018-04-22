using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            lblCreateRouteInfo.Visible = false;
                int startID, endID;
                string getAddressIDQuery = " SELECT OFFICE_LOCATION.Office_Location_ID FROM OFFICE_LOCATION WHERE OFFICE_LOCATION.Office_Address_ID = (SELECT Address_ID FROM ADDRESS LEFT JOIN COUNTRY ON ADDRESS.Country_ID = Country.Country_ID LEFT JOIN STATES ON ADDRESS.State_ID = STATES.State_ID WHERE Country.Country_Name = @Country AND(STATES.State_Name = @State OR @State = '') AND City = @City AND Zip = @Zip AND Street_Address1 = @SA1 AND(Street_Address2 = @SA2 OR @SA2 = '')); ";

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

                        SqlCommand cmd = new SqlCommand(getAddressIDQuery, con);
                        cmd.Parameters.AddWithValue("@Country", txtStartCountry.Text);
                        cmd.Parameters.AddWithValue("@State", txtStartState.Text);
                        cmd.Parameters.AddWithValue("@City", txtStartCity.Text);
                        cmd.Parameters.AddWithValue("@Zip", txtStartZip.Text);
                        cmd.Parameters.AddWithValue("@SA1", txtStartStreet.Text);
                        cmd.Parameters.AddWithValue("@SA2", txtStartStreet2.Text);

                        startID = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd = new SqlCommand(getAddressIDQuery, con);
                        cmd.Parameters.AddWithValue("@Country", txtEndCountry.Text);
                        cmd.Parameters.AddWithValue("@State", txtEndState.Text);
                        cmd.Parameters.AddWithValue("@City", txtEndCity.Text);
                        cmd.Parameters.AddWithValue("Zip", txtEndZip.Text);
                        cmd.Parameters.AddWithValue("@SA1", txtEndStreet.Text);
                        cmd.Parameters.AddWithValue("@SA2", txtEndStreet2.Text);

                        endID = Convert.ToInt32(cmd.ExecuteScalar());

                        if (txtDriverID.Text == "")
                        {
                            lblCreateRouteInfo.Text = "Please enter a driver ID";
                            lblCreateRouteInfo.ForeColor = System.Drawing.Color.Red;
                            lblCreateRouteInfo.Visible = true;
                        }
                        else
                        {
                            cmd.CommandText = "INSERT INTO DELIVERY_ROUTE VALUES(@startID, @endID, @driverID); ";
                            cmd.Parameters.AddWithValue("@startID", startID);
                            cmd.Parameters.AddWithValue("endID", endID);
                            cmd.Parameters.AddWithValue("driverID", Convert.ToInt32(txtDriverID.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            
        }
    }
}