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
                        Session["UserType"] = DropDownList1.Text.Trim();

                        string getid = "SELECT C.Customer_ID FROM CUSTOMER C, LOGIN L WHERE C.Email = L.Username";
                        SqlCommand getcustid = new SqlCommand(getid, connection);
                        SqlDataReader idreader = getcustid.ExecuteReader();
                        Session["CustomerID"] = idreader.ToString();

                        string destination = "";
                        if (DropDownList1.Text.Trim() == "Customer")
                            destination = "/Customer/Customer_Home.aspx";
                        else
                            destination = "/Employee/EmployeeHome.aspx";
                        Response.Redirect(destination);
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
            if(string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                string display = "Username is required";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                txtUsername.Focus();
            }
            else
            {
                Session["Username"] = txtUsername.Text.Trim();
                Response.Redirect("ForgotPassword.aspx");
            }
        }
    }
}