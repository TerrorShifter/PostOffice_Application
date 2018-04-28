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
        int count = 0, usertype = 0;
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
                    string query = "SELECT COUNT(1) AS cnt, L.User_Type_ID as usr FROM LOGIN L WHERE L.Username=@Username AND L.Password=@Password GROUP BY L.User_Type_ID";
                    SqlCommand checkCredentials = new SqlCommand(query, connection);
                    checkCredentials.Parameters.AddWithValue("@Username", textUsername.Value);
                    checkCredentials.Parameters.AddWithValue("@Password", textPassword.Value);                    
                    SqlDataReader dr = checkCredentials.ExecuteReader();
                    if (dr.HasRows)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('HasRows');", true);
                        while (dr.Read())
                        {
                            count = Convert.ToInt32(dr["cnt"]);
                            usertype = Convert.ToInt32(dr["usr"]);
                        }
                        dr.Close();
                    }
                    if (count == 1)
                    {
                        string user = "";
                        if (usertype == 1)
                            user = "Customer";
                        else if (usertype == 2)
                            user = "Employee";
                        Session["Username"] = textUsername.Value;
                        Session["UserType"] = user;

                        string getid = "SELECT C.Customer_ID FROM CUSTOMER C, LOGIN L WHERE C.Email = L.Username";
                        SqlCommand getcustid = new SqlCommand(getid, connection);
                        SqlDataReader idreader = getcustid.ExecuteReader();
                        Session["CustomerID"] = idreader.ToString();
                        idreader.Close();
                        string destination = "Login.aspx";
                        if (usertype == 1)
                            destination = "../Customer/Customer_Home.aspx";
                        else if (usertype == 2)
                            destination = "../Employee/EmployeeHome.aspx";
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
            if (string.IsNullOrWhiteSpace(textUsername.Value))
            {
                string display = "Username is required";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                textUsername.Focus();
            }
            else
            {
                Session["Username"] = textUsername.Value;
                Response.Redirect("ForgotPassword.aspx");
            }
        }
    }
}