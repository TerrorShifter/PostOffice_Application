using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace PostOffice_Application
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            lblBadEmail.Visible = false;
        }

        protected string saveTempPassword()
        {
            string password = Membership.GeneratePassword(10, 1);
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
                    string query = "UPDATE LOGIN SET Password=@Password WHERE Username=@Username";
                    SqlCommand checkCredentials = new SqlCommand(query, connection);
                    checkCredentials.Parameters.AddWithValue("@Password", password);
                    checkCredentials.Parameters.AddWithValue("@Username", Session["Username"]);
                    int count = Convert.ToInt32(checkCredentials.ExecuteScalar());
                }              
            }
            catch (SqlException ex)
            {
                string display = "Could not generate new password - ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
            return password;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string tempPW = saveTempPassword();
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(txtUsername.Text.Trim());
                mailMessage.From = new MailAddress("team4post.office@gmail.com");
                mailMessage.Subject = "Your Post Office password has been reset";
                mailMessage.Body = "Hello, \n\nWe've assigned a new temporary password to " + Session["Username"] + " as requested. The new password is " + tempPW + " and you may use it to login and reset to a new custom password. \n\nThanks, \n\nTeam 4";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("team4post.office@gmail.com", "youvegotmail4"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };                
                smtpClient.Send(mailMessage);
                Session["Username"] = null;
                string display = "New Password Emailed";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');window.location='Login.aspx';", true);
            }
            catch(Exception ex)
            {
                string display = "Could not send the Email - ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }
    }
}