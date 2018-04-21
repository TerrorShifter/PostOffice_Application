using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }
        }
        protected void Button1OnClick(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }

        bool isValidDate(string text)
        {
            if (text == "")
                return false;
            else
                return true;
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
                        string getPackageInfoQuery = "SELECT SHIPMENT.Tracking_Num AS [Tracking Number], SHIPMENT.Package_Type, SHIPMENT.Contents, SHIPMENT.Value_Of_Contents AS Value, DELIVERY_STATUS.Date_Shipped, concat(Address.Street_Address1, ' ', Address.Street_Address2, ' ', Address.Apartment_Num, ' ', Address.City, ', ', STATES.State_Name, ' ', Address.Zip, ', ', COUNTRY.Country_Name) AS Address FROM SHIPMENT LEFT JOIN Address ON SHIPMENT.Recipient_Address_ID = Address.Address_ID LEFT JOIN COUNTRY ON Address.Country_ID = Country.Country_ID LEFT JOIN STATES ON Address.State_ID = STATES.State_ID LEFT JOIN DELIVERY_STATUS ON SHIPMENT.Delivery_Status = DELIVERY_STATUS.Delivery_Status_ID WHERE NOT SHIPMENT.Delivery_Status = 3 AND NOT SHIPMENT.Delivery_Status = 2 AND DELIVERY_STATUS.Date_Shipped BETWEEN @startDate AND @endDate;";
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