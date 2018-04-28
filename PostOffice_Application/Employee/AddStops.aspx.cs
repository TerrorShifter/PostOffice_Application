using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace PostOffice_Application.Employee
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList1.SelectedIndex = 0;
                DropDownList1.AppendDataBoundItems = true;
            }
        }
        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        protected void ddl1_IndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
            {
                addressGrid.Visible = false;
                stopsGrid.Visible = false;
            }
            else
            {
                addressGrid.Visible = true;
                stopsGrid.Visible = true;
                stopsGrid.DataBind();
            }
        }

        protected void SqlDataSource1_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            stopsGrid.DataBind();
        }

        protected void addressGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStopExists.Visible = false;
            ClientScriptManager CSM = Page.ClientScript;
            string display = "<script>if(!window.confirm('Are you sure?')){window.location.href='AddStops.aspx'}</script>";
            CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", display, false);
            GridViewRow row = addressGrid.SelectedRow;
            int rowAddress;
            if (int.TryParse(row.Cells[1].Text, out rowAddress))
            {
                try
                {
                    var cb = new SqlConnectionStringBuilder();
                    cb.DataSource = "team-4-post-office-dbs.database.windows.net";
                    cb.UserID = "ServerAdmin";
                    cb.Password = "UmaThurman18";
                    cb.InitialCatalog = "Post_Office";

                    using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
                    {
                        connection.Open();
                        string prequery = "SELECT Route_ID FROM CURRENT_STOP AS C WHERE (C.Address_ID = @address) AND (C.Route_ID = @route)";
                        SqlCommand sel = new SqlCommand(prequery, connection);
                        sel.Parameters.AddWithValue("@address", rowAddress);
                        sel.Parameters.AddWithValue("@route", DropDownList1.SelectedValue);
                        object o = (object)sel.ExecuteScalar();
                        if (o == null)
                        {
                            string query = "INSERT INTO CURRENT_STOP(Address_ID, Route_ID) VALUES(@address, @route)";
                            SqlCommand ins = new SqlCommand(query, connection);
                            ins.Parameters.AddWithValue("@address", rowAddress);
                            ins.Parameters.AddWithValue("@route", DropDownList1.SelectedValue);
                            ins.ExecuteNonQuery();
                            stopsGrid.DataBind();
                            display = "Stop added to delivery route.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                        }
                        else
                        {
                            lblStopExists.Visible = true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    display = "Could not add stop - ERROR: " + ex.Message;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                }
            }
        }
    }
}