using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application.Employee
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateSubmit(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Post_OfficeConnectionString2");
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand("Insert Into CUSTOMER (Cust_FName, Cust_LName, Phone_Num, Email, Address_ID, Local_Post_Office_ID) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val6)", connection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlCmd.Parameters.AddWithValue("@Val1", TextBox1.Text);
            sqlCmd.Parameters.AddWithValue("@Val2", TextBox2.Text);
            sqlCmd.Parameters.AddWithValue("@Val3", TextBox3.Text);
            sqlCmd.Parameters.AddWithValue("@Val4", TextBox4.Text);
            sqlCmd.Parameters.AddWithValue("@Val5", TextBox10.Text);
            sqlCmd.Parameters.AddWithValue("@Val6", TextBox11.Text);
            connection.Close();
        }
    }
}