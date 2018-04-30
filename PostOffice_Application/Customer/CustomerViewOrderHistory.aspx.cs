using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application.Customer
{
    public partial class CustomerViewOrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Contents.RemoveAll();
            Response.Redirect("../Start/Login.aspx");
        }

        protected void Search_Button_Click(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedIndex == 0)
            {
                GridView1.DataSourceID = "";
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                GridView1.DataSourceID = "";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                GridView1.DataSourceID = "";
                GridView1.DataSource = SqlDataSource4;
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 3)
            {
                GridView1.DataSourceID = "";
                GridView1.DataSource = SqlDataSource6;
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 4)
            {
                GridView1.DataSourceID = "";
                GridView1.DataSource = SqlDataSource7;
                GridView1.DataBind();
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "";
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }
    }
}