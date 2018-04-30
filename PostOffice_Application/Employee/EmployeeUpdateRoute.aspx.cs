using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application.Employee
{
    public partial class EmployeeUpdateRoute : System.Web.UI.Page
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
            }
        }

        protected void ddl1_IndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
                Panel1.Visible = false;
            else
            {
                Panel1.Visible = true;
                DropDownList2.AppendDataBoundItems = false;
                DropDownList2.DataBind();
            }
        }

        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', '_blank', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        protected void UpdateSubmit(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            bool readyToSubmit = true;
            System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
            sqlConnection1.Open();
            System.Data.SqlClient.SqlCommand selCmd = new System.Data.SqlClient.SqlCommand();
            selCmd.CommandType = System.Data.CommandType.Text;
            selCmd.CommandText = "SELECT Curent_Stop FROM DELIVERY_ROUTE WHERE (Route_ID = @route) AND (Curent_Stop = @stop)";
            selCmd.Connection = sqlConnection1;
            selCmd.Parameters.AddWithValue("@route", DropDownList1.SelectedValue);
            selCmd.Parameters.AddWithValue("@stop", DropDownList2.SelectedValue);
            object temp = (object)selCmd.ExecuteScalar();
            if(temp != null)
            {
                Label3.Text = "Already checked in here";
                readyToSubmit = false;
            }
            if (DropDownList1.SelectedValue == "")
            {
                Label2.Text = "Required";
                readyToSubmit = false;
            }
            if (DropDownList2.SelectedValue == "" && Panel1.Visible)
            {
                Label1.Text = "Required";
                readyToSubmit = false;
            }
            if (readyToSubmit)
            {
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Insert Into CHECKIN (Stop_ID, Route_ID, Timestamp) Values (@stop, @route, @time)";
                sqlCmd.Connection = sqlConnection1;
                sqlCmd.Parameters.AddWithValue("@route", DropDownList1.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@stop", DropDownList2.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@time", DateTime.Now);
                sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = "Update DELIVERY_ROUTE Set Curent_Stop = @stop Where Route_ID = @route;";
                sqlCmd.ExecuteNonQuery();
                Label3.Text = "Successfully checked in";
                sqlConnection1.Close();
            }

        }
    }
}