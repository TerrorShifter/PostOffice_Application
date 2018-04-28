using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PostOffice_Application.Common
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }
        }

        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Contents.RemoveAll();
            Response.Redirect("../Start/Login.aspx");
        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
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
                    string query = "UPDATE LOGIN SET Password = @Password WHERE Username = @Username";
                    SqlCommand c = new SqlCommand(query, connection);
                    c.Parameters.AddWithValue("@Password", NewPass.Value);
                    c.Parameters.AddWithValue("@Username", Session["Username"].ToString());                 
                    c.ExecuteNonQuery();
                    string display = "Password Reset Successful.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('" + display + "');window.location='" + prevPage + "';", true);
                }
            }
            catch (SqlException ex)
            {
                string display = "Could not reset password - ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }

        protected void CancelPushButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}