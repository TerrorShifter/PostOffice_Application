using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace PostOffice_Application
{
    public partial class EmployeeHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnLogout = this.Master.FindControl("btnLogoff") as Button;
            Label1.Text = (string)Session["Username"];

        }

        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        protected void ddl1_changeView(object sender, EventArgs e)
        {
            switch (ddl1.SelectedValue)
            {
                case "View1":
                    mv1.SetActiveView(View1);
                    break;
                case "View2":
                    mv1.SetActiveView(View2);
                    break;
                case "View3":
                    mv1.SetActiveView(View3);
                    break;
                case "View4":
                    mv1.SetActiveView(View4);
                    break;
                case "View5":
                    mv1.SetActiveView(View5);
                    break;
            }
        }

        protected void DropDownList1_ChangeSelection(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
                GridView1.Visible = false;
            else
            {
                GridView1.Visible = true;
                GridView1.DataBind();
            }
        }

        protected void btnGetDateRangeReport_Click(object sender, EventArgs e)
        {
            DateRangeTable.Visible = false;
            v5fLabel.Text = "";
            v5tLabel.Text = "";
            bool readyToSubmit = true;
            DateTime temp = new DateTime(0), temp2 = new DateTime(0);
            if (!DateTime.TryParse(View5From.Text, out temp))
            {
                v5fLabel.Text = "Please select a valid start date.";
                readyToSubmit = false;
            }
            if (!DateTime.TryParse(View5To.Text, out temp2))
            {
                v5tLabel.Text = "Please select a valid end date.";
                readyToSubmit = false;
            }
            if(readyToSubmit)
            {
                if (temp2.Ticks >= temp.Ticks)
                {
                    DateRangeTable.Visible = true;
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
                            //Returns a table with the columns: Tracking Number, Package Type, Contents, Value of the contents, and the full address associated with the package
                            //based on given dates
                            string getPackageInfoQuery = "SELECT SHIPMENT.Tracking_Num AS [Tracking Number], DELIVERY_STRING.Status_String AS [Delivery Status],PRIORITY.Priority_Type AS Priority, Package_Type.Package_Type_string AS [Package Type], SHIPMENT.Contents, SHIPMENT.Weight, SHIPMENT.Value_Of_Contents AS Value, SHIPMENT.Rate AS [Rate], DELIVERY_STATUS.Date_Shipped AS [Date Shipped], concat(CUSTOMER.Cust_FName, ' ', CUSTOMER.Cust_LName) AS [Sender Name] ,concat(SHIPMENT.Recipient_FName ,' ', SHIPMENT.Recipient_LName) AS [Recipient Name],concat(Address.Street_Address1, ' ', Address.Street_Address2, ' ', Address.Apartment_Num, ' ', Address.City, ', ', STATES.State_Name, ' ', Address.Zip, ', ', COUNTRY.Country_Name) AS Address FROM SHIPMENT LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID LEFT JOIN DELIVERY_STRING ON DELIVERY_STATUS.Status = DELIVERY_STRING.Status_ID LEFT JOIN PRIORITY ON SHIPMENT.Priority_ID = Priority.Priority_ID LEFT JOIN Address ON SHIPMENT.Recipient_Address_ID = Address.Address_ID LEFT JOIN COUNTRY ON Address.Country_ID = Country.Country_ID LEFT JOIN STATES ON Address.State_ID = STATES.State_ID LEFT JOIN PACKAGE_TYPE ON PACKAGE_TYPE.Package_Type_ID=SHIPMENT.Package_Type LEFT JOIN CUSTOMER ON SHIPMENT.Sender_ID=CUSTOMER.Customer_ID WHERE NOT SHIPMENT.Delivery_Status = 5 AND NOT SHIPMENT.Delivery_Status = 6 AND DELIVERY_STATUS.Date_Shipped BETWEEN @startDate AND @endDate";
                            SqlCommand cmd = new SqlCommand(getPackageInfoQuery, con);
                            cmd.Parameters.AddWithValue("@startDate", View5From.Text);
                            cmd.Parameters.AddWithValue("@endDate", View5To.Text);
                            cmd.CommandType = System.Data.CommandType.Text;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            DateRangeTable.DataSource = dt;
                            DateRangeTable.DataBind();
                            con.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.ToString());
                        v5tLabel.Text = "SQLERROR: " + e.ToString();
                    }
                }
                else
                    v5tLabel.Text = "To date must come after From date";
            }

        }

        protected void btnFailedPackages_Click(object sender, EventArgs e)
        {
            FailedShipmentsTable.Visible = false;
            v4fLabel.Text = "";
            v4tLabel.Text = "";
            DateTime temp = new DateTime(0), temp2 = new DateTime(0);
            bool readyToSubmit = true;
            if (!DateTime.TryParse(View4From.Text, out temp))
            {
                v4fLabel.Text = "Please select a valid start date.";
                readyToSubmit = false;
            }
            if (!DateTime.TryParse(View4To.Text, out temp2))
            {
                v4tLabel.Text = "Please select a valid end date.";
                readyToSubmit = false;
            }
            if(readyToSubmit)
            {
                if (temp2.Ticks >= temp.Ticks)
                {
                    FailedShipmentsTable.Visible = true;
                    string getFailedPackagesQuery = "SELECT Tracking_Num AS [Tracking Number], concat(CUSTOMER.Cust_FName, ' ', CUSTOMER.Cust_LName) AS [Sender Name], CUSTOMER.Phone_Num AS [Sender Phone Number], CUSTOMER.Email AS [Sender Email], concat(Recipient_FName, ' ', Recipient_LName) AS [Recipient Name], DELIVERY_STATUS.Date_Shipped AS [Date Shipped] FROM SHIPMENT LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID LEFT JOIN CUSTOMER ON  SHIPMENT.Sender_ID = CUSTOMER.Customer_ID WHERE DELIVERY_STATUS.Status = 5 AND Date_Shipped BETWEEN @startDate AND @endDate;";
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
                            SqlCommand cmd = new SqlCommand(getFailedPackagesQuery, con);
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("@startDate", View4From.Text);
                            cmd.Parameters.AddWithValue("@endDate", View4To.Text);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            FailedShipmentsTable.DataSource = dt;
                            FailedShipmentsTable.DataBind();
                            con.Close();
                        }

                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }
                else
                    v4tLabel.Text = "To date must come after From date";
            }
        }

        protected void btnCustHistory_Click(object sender, EventArgs e)
        {
            CustHistoryTable.Visible = false;
            lblCustID.Text = "";
            v3fLabel.Text = "";
            v3tLabel.Text = "";
            DateTime temp = new DateTime(0), temp2 = new DateTime(0);
            bool readyToSubmit = true;
            if (ddlCustID.SelectedValue == "")
            {
                lblCustID.Text = "Required";
                readyToSubmit = false;
            }
            if (!DateTime.TryParse(View3From.Text, out temp))
            {
                v3fLabel.Text = "Please select a valid start date.";
                readyToSubmit = false;
            }
            if (!DateTime.TryParse(View3To.Text, out temp2))
            {
                v3tLabel.Text = "Please select a valid end date.";
                readyToSubmit = false;
            }
            if(readyToSubmit)
            {
                if (temp2.Ticks >= temp.Ticks)
                {
                    CustHistoryTable.Visible = true;
                    string getCustHistoryQuery = "SELECT SHIPMENT.Tracking_Num AS [Tracking Number], DELIVERY_STRING.Status_String AS [Delivery Status],PRIORITY.Priority_Type AS Priority, Package_Type.Package_Type_string AS [Package Type], SHIPMENT.Contents, SHIPMENT.Weight, SHIPMENT.Value_Of_Contents AS Value, SHIPMENT.Rate AS [Rate], DELIVERY_STATUS.Date_Shipped AS [Date Shipped], concat(CUSTOMER.Cust_FName, ' ', CUSTOMER.Cust_LName) AS [Sender Name] ,concat(SHIPMENT.Recipient_FName ,' ', SHIPMENT.Recipient_LName) AS [Recipient Name],concat(Address.Street_Address1, ' ', Address.Street_Address2, ' ', Address.Apartment_Num, ' ', Address.City, ', ', STATES.State_Name, ' ', Address.Zip, ', ', COUNTRY.Country_Name) AS Address FROM SHIPMENT LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID LEFT JOIN DELIVERY_STRING ON DELIVERY_STATUS.Status = DELIVERY_STRING.Status_ID LEFT JOIN PRIORITY ON SHIPMENT.Priority_ID = Priority.Priority_ID LEFT JOIN Address ON SHIPMENT.Recipient_Address_ID = Address.Address_ID LEFT JOIN COUNTRY ON Address.Country_ID = Country.Country_ID LEFT JOIN STATES ON Address.State_ID = STATES.State_ID LEFT JOIN PACKAGE_TYPE ON PACKAGE_TYPE.Package_Type_ID=SHIPMENT.Package_Type LEFT JOIN CUSTOMER ON SHIPMENT.Sender_ID=CUSTOMER.Customer_ID WHERE Customer.Customer_ID = @cID AND Date_Shipped BETWEEN @startDate AND @endDate;";
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
                            SqlCommand cmd = new SqlCommand(getCustHistoryQuery, con);
                            cmd.Parameters.AddWithValue("@cID", ddlCustID.SelectedValue);
                            cmd.Parameters.AddWithValue("@startDate", View3From.Text);
                            cmd.Parameters.AddWithValue("@endDate", View3To.Text);
                            cmd.CommandType = System.Data.CommandType.Text;
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            CustHistoryTable.DataSource = dt;
                            CustHistoryTable.DataBind();
                            con.Close();
                        }

                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }
                else
                    v3tLabel.Text = "To date must come after From date";
            }
        }

    }
}