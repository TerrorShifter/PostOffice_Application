using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application
{
    public partial class EmployeeCreateRoute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList1.SelectedIndex = DropDownList1.Items.Count - 1;
                DropDownList1.AppendDataBoundItems = true;
                DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList2.SelectedIndex = DropDownList2.Items.Count - 1;
                DropDownList2.AppendDataBoundItems = true;
                DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList3.SelectedIndex = DropDownList3.Items.Count - 1;
                DropDownList3.AppendDataBoundItems = true;
                DropDownList4.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList4.SelectedIndex = DropDownList4.Items.Count - 1;
                DropDownList4.AppendDataBoundItems = true;
                DropDownList5.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList5.SelectedIndex = DropDownList5.Items.Count - 1;
                DropDownList5.AppendDataBoundItems = true;
                DropDownList6.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList6.SelectedIndex = DropDownList6.Items.Count - 1;
                DropDownList6.AppendDataBoundItems = true;
            }
        }


        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        protected void InternalSubmit1(object sender, EventArgs e)
        {
            Label7.Text = "";
            Label8.Text = "";
            Label9.Text = "";
            Label10.Text = "";
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
            System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.CommandText = "Insert Into ADDRESS (Country_ID, State_ID, City, Zip, Apartment_Num, Street_Address1, Street_Address2) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val6, @Val7)";
            sqlCmd.Connection = sqlConnection1;
            bool readyToSubmit = true;
            if (DropDownList1.SelectedValue == "")
            {
                Label7.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val1", DropDownList1.SelectedValue);
            if (DropDownList2.SelectedValue == "")
                sqlCmd.Parameters.AddWithValue("@Val2", DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue("@Val2", DropDownList2.SelectedValue);
            if (TextBox5.Text == "")
            {
                Label8.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val3", TextBox5.Text);
            if (TextBox6.Text == "")
            {
                Label9.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val4", TextBox6.Text);
            if (TextBox7.Text == "")
                sqlCmd.Parameters.AddWithValue("@Val5", DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue("@Val5", TextBox7.Text);
            if (TextBox8.Text == "")
            {
                Label10.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val6", TextBox8.Text);
            if (TextBox9.Text == "")
                sqlCmd.Parameters.AddWithValue("@Val7", DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue("@Val7", TextBox9.Text);
            if (readyToSubmit)
            {
                sqlConnection1.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConnection1.Close();
                DropDownList5.AppendDataBoundItems = false;
                DropDownList5.DataBind();
                DropDownList5.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList5.SelectedIndex = DropDownList5.Items.Count - 1;
                MultiView1.SetActiveView(View1);
            }
        }

        protected void InternalSubmit2(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
            System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.CommandText = "Insert Into ADDRESS (Country_ID, State_ID, City, Zip, Apartment_Num, Street_Address1, Street_Address2) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val6, @Val7)";
            sqlCmd.Connection = sqlConnection1;
            bool readyToSubmit = true;
            if (DropDownList3.SelectedValue == "")
            {
                Label1.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val1", DropDownList3.SelectedValue);
            if (DropDownList4.SelectedValue == "")
                sqlCmd.Parameters.AddWithValue("@Val2", DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue("@Val2", DropDownList4.SelectedValue);
            if (TextBox1.Text == "")
            {
                Label2.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val3", TextBox1.Text);
            if (TextBox2.Text == "")
            {
                Label3.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val4", TextBox2.Text);
            if (TextBox3.Text == "")
                sqlCmd.Parameters.AddWithValue("@Val5", DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue("@Val5", TextBox3.Text);
            if (TextBox4.Text == "")
            {
                Label4.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val6", TextBox4.Text);
            if (TextBox10.Text == "")
                sqlCmd.Parameters.AddWithValue("@Val7", DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue("@Val7", TextBox10.Text);
            if (readyToSubmit)
            {
                sqlConnection1.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConnection1.Close();
                DropDownList6.AppendDataBoundItems = false;
                DropDownList6.DataBind();
                DropDownList6.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList6.SelectedIndex = DropDownList6.Items.Count - 1;
                MultiView2.SetActiveView(View4);
            }
        }

        protected void CreateSubmit(object sender, EventArgs e)
        {
            Label5.Text = "";
            Label6.Text = "";
            Label11.Text = "";
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
            System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand sqlCmd2 = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlCommand sqlCmd3 = new System.Data.SqlClient.SqlCommand();
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.CommandText = "Insert Into DELIVERY_ROUTE (Starting_ID, Destination_ID, Driver) Values (@Val1, @Val2, @Val3)";
            sqlCmd.Connection = sqlConnection1;
            bool readyToSubmit = true;
            sqlConnection1.Open();
            if (DropDownList5.SelectedValue == "")
            {
                Label5.Text = "Required";
                readyToSubmit = false;
            }
            else
            {
                System.Data.SqlClient.SqlCommand sqlCmdT = new System.Data.SqlClient.SqlCommand();
                sqlCmdT.CommandType = System.Data.CommandType.Text;
                sqlCmdT.CommandText = "Select O.Office_Location_ID From OFFICE_LOCATION AS O Where O.Office_Address_ID = @Val1";
                sqlCmdT.Parameters.AddWithValue("@Val1", DropDownList5.SelectedValue);
                sqlCmdT.Connection = sqlConnection1;
                if (sqlCmdT.ExecuteScalar() == null)
                {
                    sqlCmd2.CommandType = System.Data.CommandType.Text;
                    sqlCmd2.CommandText = "Insert Into OFFICE_LOCATION (Office_Address_ID) Output INSERTED.Office_Location_ID Values (@Val1)";
                    sqlCmd2.Parameters.AddWithValue("@Val1", DropDownList5.SelectedValue);
                    sqlCmd2.Connection = sqlConnection1;
                    sqlCmd.Parameters.AddWithValue("@Val1", (int)sqlCmd2.ExecuteScalar());
                }
                else
                {
                    int i = (int)sqlCmdT.ExecuteScalar();
                    sqlCmd.Parameters.AddWithValue("@Val1", i);
                }
            }
            if (DropDownList6.SelectedValue == "")
            {
                Label6.Text = "Required";
                readyToSubmit = false;
            }
            else
            {
                System.Data.SqlClient.SqlCommand sqlCmdT = new System.Data.SqlClient.SqlCommand();
                sqlCmdT.CommandType = System.Data.CommandType.Text;
                sqlCmdT.CommandText = "Select O.Office_Location_ID From OFFICE_LOCATION AS O Where O.Office_Address_ID = @Val1";
                sqlCmdT.Parameters.AddWithValue("@Val1", DropDownList6.SelectedValue);
                sqlCmdT.Connection = sqlConnection1;
                if (sqlCmdT.ExecuteScalar() == null)
                {
                    sqlCmd3.CommandType = System.Data.CommandType.Text;
                    sqlCmd3.CommandText = "Insert Into OFFICE_LOCATION (Office_Address_ID) Output INSERTED.Office_Location_ID Values (@Val1)";
                    sqlCmd3.Parameters.AddWithValue("@Val1", DropDownList6.SelectedValue);
                    sqlCmd3.Connection = sqlConnection1;
                    sqlCmd.Parameters.AddWithValue("@Val2", (int)sqlCmd3.ExecuteScalar());
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val2", (int)sqlCmdT.ExecuteScalar());
            }
            if (DropDownList7.SelectedValue == "")
            {
                Label11.Text = "Required";
                readyToSubmit = false;
            }
            else
                sqlCmd.Parameters.AddWithValue("@Val3", DropDownList7.SelectedValue);
            if (readyToSubmit)
            {
                sqlCmd.ExecuteNonQuery();
            }
            sqlConnection1.Close();
        }
    }
}