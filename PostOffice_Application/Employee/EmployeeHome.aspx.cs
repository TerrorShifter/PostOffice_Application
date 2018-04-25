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

        //used for view5, date report
        bool isValidText(string text)
        {

            if (text == "")
                return false;
            else
                return true;
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

            if (!isValidText(beginDate.Text) || !isValidText(endDate.Text))
                lblDateRangeError.Visible = true;

            else
            {
                string begin = beginDate.Text.Trim();
                string end = endDate.Text.Trim();
                lblDateRangeError.Visible = false;
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
                        string getPackageInfoQuery = "SELECT SHIPMENT.Tracking_Num AS [Tracking Number], DELIVERY_STRING.Status_String AS [Delivery Status],PRIORITY.Priority_Type AS Priority, Package_Type.Package_Type_string AS [Package Type], SHIPMENT.Contents, SHIPMENT.Weight, SHIPMENT.Value_Of_Contents AS Value, SHIPMENT.Rate AS [Rate], DELIVERY_STATUS.Date_Shipped AS [Date Shipped], concat(CUSTOMER.Cust_FName, ' ', CUSTOMER.Cust_LName) AS [Sender Name] ,concat(SHIPMENT.Recipient_FName ,' ', SHIPMENT.Recipient_LName) AS [Recipient Name],concat(Address.Street_Address1, ' ', Address.Street_Address2, ' ', Address.Apartment_Num, ' ', Address.City, ', ', STATES.State_Name, ' ', Address.Zip, ', ', COUNTRY.Country_Name) AS Address FROM SHIPMENT LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID LEFT JOIN DELIVERY_STRING ON DELIVERY_STATUS.Status = DELIVERY_STRING.Status_ID LEFT JOIN PRIORITY ON SHIPMENT.Priority_ID = Priority.Priority_ID LEFT JOIN Address ON SHIPMENT.Recipient_Address_ID = Address.Address_ID LEFT JOIN COUNTRY ON Address.Country_ID = Country.Country_ID LEFT JOIN STATES ON Address.State_ID = STATES.State_ID LEFT JOIN PACKAGE_TYPE ON PACKAGE_TYPE.Package_Type_ID=SHIPMENT.Package_Type LEFT JOIN CUSTOMER ON SHIPMENT.Sender_ID=CUSTOMER.Customer_ID WHERE NOT SHIPMENT.Delivery_Status = 5 AND NOT SHIPMENT.Delivery_Status = 6 AND DELIVERY_STATUS.Date_Shipped BETWEEN @startDate AND @endDate ORDER BY DELIVERY_STATUS.Date_Shipped ASC";
                        SqlCommand cmd = new SqlCommand(getPackageInfoQuery, con);
                        cmd.Parameters.AddWithValue("@startDate", begin);
                        cmd.Parameters.AddWithValue("@endDate", end);
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
                }
            }
        }

        protected void btnFailedPackages_Click(object sender, EventArgs e)
        {
            string getFailedPackagesQuery = "SELECT Tracking_Num AS [Tracking Number], concat(CUSTOMER.Cust_FName, ' ', CUSTOMER.Cust_LName) AS [Sender Name], CUSTOMER.Phone_Num AS [Sender Phone Number], CUSTOMER.Email AS [Sender Email], concat(Recipient_FName, ' ', Recipient_LName) AS [Recipient Name], DELIVERY_STATUS.Date_Shipped AS [Date Shipped] FROM SHIPMENT LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID LEFT JOIN CUSTOMER ON  SHIPMENT.Sender_ID = CUSTOMER.Customer_ID WHERE DELIVERY_STATUS.Status = 5; ";
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

        protected void ddl2_ChangeSelection(object sender, EventArgs e)
        {
            string getCustHistoryQuery = "SELECT SHIPMENT.Tracking_Num AS [Tracking Number], DELIVERY_STRING.Status_String AS [Delivery Status],PRIORITY.Priority_Type AS Priority, Package_Type.Package_Type_string AS [Package Type], SHIPMENT.Contents, SHIPMENT.Weight, SHIPMENT.Value_Of_Contents AS Value, SHIPMENT.Rate AS [Rate], DELIVERY_STATUS.Date_Shipped AS [Date Shipped], concat(CUSTOMER.Cust_FName, ' ', CUSTOMER.Cust_LName) AS [Sender Name] ,concat(SHIPMENT.Recipient_FName ,' ', SHIPMENT.Recipient_LName) AS [Recipient Name],concat(Address.Street_Address1, ' ', Address.Street_Address2, ' ', Address.Apartment_Num, ' ', Address.City, ', ', STATES.State_Name, ' ', Address.Zip, ', ', COUNTRY.Country_Name) AS Address FROM SHIPMENT LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID LEFT JOIN DELIVERY_STRING ON DELIVERY_STATUS.Status = DELIVERY_STRING.Status_ID LEFT JOIN PRIORITY ON SHIPMENT.Priority_ID = Priority.Priority_ID LEFT JOIN Address ON SHIPMENT.Recipient_Address_ID = Address.Address_ID LEFT JOIN COUNTRY ON Address.Country_ID = Country.Country_ID LEFT JOIN STATES ON Address.State_ID = STATES.State_ID LEFT JOIN PACKAGE_TYPE ON PACKAGE_TYPE.Package_Type_ID=SHIPMENT.Package_Type LEFT JOIN CUSTOMER ON SHIPMENT.Sender_ID=CUSTOMER.Customer_ID WHERE Customer.Customer_ID = @cID;";
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
                    cmd.Parameters.AddWithValue("@cID", DropDownList2.SelectedValue);
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
    }
}