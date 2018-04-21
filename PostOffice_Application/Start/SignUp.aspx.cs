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
            txtEmplNum.Visible = chkEmployee.Checked;
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

        bool IsEmployee(SqlConnection sqlCon)
        {
            try
            {
                string query = "SELECT COUNT(1) FROM EMPLOYEE WHERE Employee_ID = @emp";
                SqlCommand d = new SqlCommand(query, sqlCon);
                d.Parameters.AddWithValue("@Username", txtEmplNum.Text.Trim());
                int count = Convert.ToInt32(d.ExecuteScalar());
                if (count == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
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
                    string display = "";                   
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
                        int usertype = 1;
                        //this query inserts given data from text boxes into correspoding login table in database.
                        string query = "INSERT INTO LOGIN (Username, Password, User_Type_ID) VALUES(@Username, @Password, @UserType)";
                        //Checks if an account has already been created using the given email.
                        string checkDuplicate = "SELECT COUNT(1) FROM LOGIN  WHERE Username=@Username";
                        SqlCommand d = new SqlCommand(checkDuplicate, con);
                        d.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());                       
                        if (txtEmplNum.Visible == true)
                        {
                            bool isEmp = IsEmployee(con);
                            if (isEmp)
                            {
                                usertype = 2;
                            }
                            else
                            {
                                display = "Must be an employee in order to register an employee account.";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('" + display + "');window.location='SignUp.aspx';", true);
                            }
                        }                        
                        int count = Convert.ToInt32(d.ExecuteScalar());
                        if (count == 1)
                        {
                            lblSignUpInfo.Text = "Account already exists.";
                            lblSignUpInfo.ForeColor = System.Drawing.Color.Red;
                            lblSignUpInfo.Visible = true;
                        }
                        else
                        {
                            try
                            {
                                //adds info to login table of database, informs user of successful acount creation.
                                SqlCommand c = new SqlCommand(query, con);
                                c.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                                c.Parameters.AddWithValue("@Password", passwordText.Text.Trim());
                                c.Parameters.AddWithValue("@UserType", usertype);
                                c.ExecuteNonQuery();

                                lblSignUpInfo.Text = "Account Created.";
                                lblSignUpInfo.ForeColor = System.Drawing.Color.Green;
                                lblSignUpInfo.Visible = true;
                            }
                            catch(SqlException ex)
                            {
                                display = "Could not send the Email - ERROR: " + ex.Message;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                            }

                            try
                            {
                                MailMessage mailMessage = new MailMessage();
                                mailMessage.To.Add(txtUsername.Text.Trim());
                                mailMessage.From = new MailAddress("team4post.office@gmail.com");
                                mailMessage.Subject = "Registration Complete!";
                                mailMessage.Body = "Hello, \n\nThank you for registering with your friendly Team 4 Post Office! You may now login with the entered credentials. \n\nThanks, \n\nTeam 4";
                                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                                {
                                    Credentials = new NetworkCredential("team4post.office@gmail.com", "mail!youve4got"),
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network
                                };
                                smtpClient.Send(mailMessage);
                                Session["Username"] = null;
                                display = "Registration Successful! Check your Email for our thank you message.";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('" + display + "');window.location='../Default.aspx';", true);
                            }
                            catch (Exception ex)
                            {
                                display = "Could not send the Email - ERROR: " + ex.Message;
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

        protected void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            txtEmplNum.Visible = chkEmployee.Checked;
        }
    }
}