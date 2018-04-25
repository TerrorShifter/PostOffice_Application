using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application
{
    public partial class IDLookup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "Select * From ";
            List<string> whitelist = new List<string>();
            whitelist.Add("ADDRESS");
            whitelist.Add("CUSTOMER");
            whitelist.Add("EMPLOYEE");
            whitelist.Add("SHIPMENT");
            whitelist.Add("DELIVERY_ROUTE");
            whitelist.Add("OFFICE_LOCATION");
            if (!String.IsNullOrEmpty(Request.QueryString["EntityTable"]))
            {
                string qstring = Request.QueryString["EntityTable"];
                if (!whitelist.Contains(qstring))
                {
                    GridView1.Visible = false;
                    Label1.Visible = true;
                    return;
                }
                query = query + qstring;
            }
            else
                query = query + "ADDRESS";
            SqlDataSource1.SelectCommand = query;
        }
    }
}