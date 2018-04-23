using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application
{
    public partial class EmployeeCustomerCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList1.SelectedIndex = 0;
                DropDownList1.AppendDataBoundItems = true;
                DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList2.SelectedIndex = 0;
                DropDownList2.AppendDataBoundItems = true;
                DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList3.SelectedIndex = 0;
                DropDownList3.AppendDataBoundItems = true;
                DropDownList4.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList4.SelectedIndex = 0;
                DropDownList4.AppendDataBoundItems = true;
            }
        }

        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        protected void CreateSubmit(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = "";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                Label5.Text = "";
                Label6.Text = "";
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Insert Into CUSTOMER (Cust_FName, Cust_LName, Phone_Num, Email, Address_ID, Local_Post_Office_ID) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val6)";
                sqlCmd.Connection = sqlConnection1;
                bool readyToSubmit = true;
                if (TextBox1.Text == "")
                {
                    Label1.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val1", TextBox1.Text);
                if (TextBox2.Text == "")
                {
                    Label2.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val2", TextBox2.Text);
                if (TextBox3.Text == "")
                {
                    Label3.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val3", TextBox3.Text);
                if (TextBox4.Text == "")
                {
                    Label4.Text = "Required";
                    readyToSubmit = false;
                }
                else if (!emailCheck(TextBox4.Text))
                {
                    Label4.Text = "Must be a valid email";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val4", TextBox4.Text);
                if (DropDownList3.SelectedValue == "")
                {
                    Label5.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val5", DropDownList3.SelectedValue);
                if (DropDownList4.SelectedValue == "")
                {
                    Label6.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val6", DropDownList4.SelectedValue);
                if (readyToSubmit)
                {
                    sqlConnection1.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    CustomerCreated.Visible = true;
                }
            }
            catch(SqlException ex)
            {

            }
        }

        protected void InternalSubmit(object sender, EventArgs e)
        {
            try
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
                    DropDownList3.AppendDataBoundItems = false;
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    DropDownList3.SelectedIndex = DropDownList3.Items.Count - 1;
                    MultiView1.SetActiveView(View1);
                    AddressCreated.Visible = true;
                }
            }
            catch (SqlException ex)
            {

            }
        }

        protected bool emailCheck(string text)
        {
            if (!text.Contains("@") || !text.Contains("."))
                return false;
            return true;
        }
    }
}