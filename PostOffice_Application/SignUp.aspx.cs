using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostOffice_Application
{
    public partial class SignIn : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSignUpInfo.Visible = false;

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //Checks if input strings are properly formatted, or if they are entered at all.
            if (TextBox1.Text == "" || passwordText.Text == "")
            {
                lblSignUpInfo.Text = "Invalid Email or Password.";
                lblSignUpInfo.ForeColor = System.Drawing.Color.Red;
                lblSignUpInfo.Visible = true;
            }
            else if (TextBox1.Text.Contains("@") == false)
            {
                lblSignUpInfo.Text = "Invalid Email or Password.";
                lblSignUpInfo.ForeColor = System.Drawing.Color.Red;
                lblSignUpInfo.Visible = true;
            }
            else
            {
                try
                {
                    var localstr = new SqlConnectionStringBuilder
                    {
                        DataSource = "team-4-post-office-dbs.database.windows.net",
                        InitialCatalog = "Post_Office",
                        UserID = "luisflores",
                        Password = "luisf%1220"
                        

                };
                    using (SqlConnection con = new SqlConnection(localstr.ConnectionString))
                    {
                        con.Open();
                        string query = "INSERT INTO (Username, Password, User_Type_ID) LOGIN VALUES(@Username, @Password, 1)";
                        string checkDuplicate = "SELECT COUNT(1) FROM LOGIN  WHERE Username=@Username";
                        SqlCommand d = new SqlCommand(checkDuplicate, con);
                        d.Parameters.AddWithValue("@Username", TextBox1.Text.Trim());
                        d.Parameters.AddWithValue("@Password", passwordText.Text.Trim());
                        int count = Convert.ToInt32(d.ExecuteScalar());
                        if (count == 1)
                        {
                            lblSignUpInfo.Text = "Account already exists.";
                            lblSignUpInfo.ForeColor = System.Drawing.Color.Red;
                            lblSignUpInfo.Visible = true;
                        }
                        else
                        {
                            SqlCommand c = new SqlCommand(query, con);
                            c.Parameters.AddWithValue("@Email", TextBox1.Text.Trim());
                            c.Parameters.AddWithValue("@Password", passwordText.Text.Trim());
                            c.ExecuteNonQuery();

                            lblSignUpInfo.Text = "Account Created.";
                            lblSignUpInfo.ForeColor = System.Drawing.Color.Green;
                            lblSignUpInfo.Visible = true;

                            TextBox1.Text = "";
                            passwordText.Text = "";
                            confirmPassword.Text = "";
                        }
                    }
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            

        }
    }
}