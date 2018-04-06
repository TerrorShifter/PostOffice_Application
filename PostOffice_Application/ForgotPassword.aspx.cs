using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace PostOffice_Application
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBadEmail.Visible = false;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(txtUsername.Text.Trim());
                mailMessage.From = new MailAddress("team4post.office@gmail.com");
                mailMessage.Subject = "Team 4 Post Office Password Reset";
                mailMessage.Body = "Your new password is ";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("team4post.office@gmail.com", "youvegotmail4"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };                
                smtpClient.Send(mailMessage);
                Response.Write("Email sent!");
            }
            catch(Exception ex)
            {
                Response.Write("Could not send the Email - ERROR: " + ex.Message);
            }
        }
    }
}