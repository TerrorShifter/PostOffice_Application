﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PostOffice_Application
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null)
            {
                USERNAME.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");


                USERNAME.Text = "Account: " + Session["Username"].ToString();
                WelcomeLabel.Text = "Welcome to your Post Office HomePage! "; //Session[Username] give the username 
            }
            else
            {
                WelcomeLabel.Text = "Welcome to our Post Office Customer HomePage! There seems to be an error with your session. Please log off and try again!";
            }
        }

        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Contents.RemoveAll();
            Response.Redirect("../Start/Login.aspx");
        }
    }
}