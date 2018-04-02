using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PostOffice_Application
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                    string query = "SELECT COUNT(1) FROM LOGIN L, USER_TYPE U WHERE L.Username=@Username AND L.Password=@Password AND U.User_Type_Name=@UserType AND L.User_Type_ID=U.User_Type_ID";
                    SqlCommand checkCredentials = new SqlCommand(query, connection);
                    checkCredentials.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    checkCredentials.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    checkCredentials.Parameters.AddWithValue("@UserType", DropDownList1.Text.Trim());
                    int count = Convert.ToInt32(checkCredentials.ExecuteScalar());
                    if (count == 1)
                    {
                        Session["Username"] = txtUsername.Text.Trim();
                        string display = "Login Successful!";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                    }
                    else { lblLoginError.Visible = true; }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected void btnForgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}