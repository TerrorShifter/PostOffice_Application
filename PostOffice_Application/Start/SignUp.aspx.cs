using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace PostOffice_Application
{
    public partial class SignIn : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSignUpInfo.Visible = false;

        }

        //checks if input password meets format requirements, or if it is empty.
        //At least one: digit, lowercase, special character. Length between 6 and 20.
        bool passwordCheck(string text)
        {
            var  passwordRegex =  new Regex("((?=.*\\d)(?=.*[a-z])(?=.*[\\W]).{6,20})");
            if (!passwordRegex.IsMatch(text)||text=="")
            {
                return false;
            }
            else
                return true;
        }

        bool emailCheck(string text)
        {
            if (text == "" || !text.Contains("@") || !text.Contains("."))
                return false;
            else
                return true;

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //Checks if input strings are properly formatted, or if they are entered at all.
            if (emailCheck(txtUsername.Text)==false|| passwordCheck(passwordText.Text)==false)
            {
                lblSignUpInfo.Text = "Invalid Email or Password.";
                lblSignUpInfo.ForeColor = System.Drawing.Color.Red;
                lblSignUpInfo.Visible = true;
            }
            else if(confirmPassword.Text=="")
            {
                lblSignUpInfo.Text = "Please confirm password.";
                lblSignUpInfo.ForeColor = System.Drawing.Color.Red;
                lblSignUpInfo.Visible = true;
            }
            else
            {
                try
                {
                    var constr = new SqlConnectionStringBuilder
                    {
                       DataSource = "team-4-post-office-dbs.database.windows.net",
                         InitialCatalog = "Post_Office",
                         UserID = "luisflores",
                         Password = "luisf%1220"
                     /* DataSource = ".\\SQLEXPRESS",
                        InitialCatalog = "LOGIN",
                        IntegratedSecurity = true*/


                    };
                    using (SqlConnection con = new SqlConnection(constr.ConnectionString))
                    {
                        con.Open();
                        //this query inserts given data from text boxes into correspoding login table in database.
                        string query = "INSERT INTO LOGIN (Username, Password, User_Type_ID) VALUES(@Username, @Password, 1)";
                        //Checks if an account has already been created using the given email.
                        string checkDuplicate = "SELECT COUNT(1) FROM LOGIN  WHERE Username=@Username";
                        SqlCommand d = new SqlCommand(checkDuplicate, con);
                        d.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
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
                            //adds info to login table of database, informs user of successful acount creation.
                            SqlCommand c = new SqlCommand(query, con);
                            c.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                            c.Parameters.AddWithValue("@Password", passwordText.Text.Trim());
                            c.ExecuteNonQuery();

                            lblSignUpInfo.Text = "Account Created.";
                            lblSignUpInfo.ForeColor = System.Drawing.Color.Green;
                            lblSignUpInfo.Visible = true;

                            try
                            {
                                MailMessage mailMessage = new MailMessage();
                                mailMessage.To.Add(txtUsername.Text.Trim());
                                mailMessage.From = new MailAddress("team4post.office@gmail.com");
                                mailMessage.Subject = "Registration Complete!";
                                mailMessage.Body = "Hello, \n\nThank you for registering with your friendly Team 4 Post Office! You may now login with the entered credentials. \n\nThanks, \n\nTeam 4";
                                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                                {
                                    Credentials = new NetworkCredential("team4post.office@gmail.com", "youvegotmail4"),
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network
                                };
                                smtpClient.Send(mailMessage);
                                Session["Username"] = null;
                                string display = "Registration Successful! Check your Email for our thank you message.";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('" + display + "');window.location='GuestPage.aspx';", true);
                            }
                            catch (Exception ex)
                            {
                                string display = "Could not send the Email - ERROR: " + ex.Message;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                            }                           
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