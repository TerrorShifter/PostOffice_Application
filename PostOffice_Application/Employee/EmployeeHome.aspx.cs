using System;
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
    }
}