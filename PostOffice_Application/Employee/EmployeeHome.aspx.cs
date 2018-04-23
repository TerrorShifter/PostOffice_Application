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

        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        //used for view5, date report
        bool isValidDate(string text)
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
            
            if (!isValidDate(beginDate.Text) || !isValidDate(endDate.Text))
                lblDateRangeError.Visible = true;

            else
            {
                string begin = beginDate.Text;
                string end = endDate.Text;
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
                        string getPackageInfoQuery = "SELECT SHIPMENT.Tracking_Num AS [Tracking Number], SHIPMENT.Package_Type AS [Package Type], SHIPMENT.Contents, SHIPMENT.Weight, SHIPMENT.Value_Of_Contents AS Value, DELIVERY_STATUS.Date_Shipped, concat(Address.Street_Address1, ' ', Address.Street_Address2, ' ', Address.Apartment_Num, ' ', Address.City, ', ', STATES.State_Name, ' ', Address.Zip, ', ', COUNTRY.Country_Name) AS Address FROM SHIPMENT LEFT JOIN Address ON SHIPMENT.Recipient_Address_ID = Address.Address_ID LEFT JOIN COUNTRY ON Address.Country_ID = Country.Country_ID LEFT JOIN STATES ON Address.State_ID = STATES.State_ID LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID WHERE NOT SHIPMENT.Delivery_Status = 5 AND NOT SHIPMENT.Delivery_Status = 6 AND DELIVERY_STATUS.Date_Shipped BETWEEN @startDate AND @endDate;";
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
    }
}