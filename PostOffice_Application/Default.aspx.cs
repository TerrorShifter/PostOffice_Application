﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace PostOffice_Application
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx"); //redirect to Login Page
        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx"); //redirect to Sign Up Page
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
        }

        protected void Track_Click(object sender, EventArgs e)
        {

        }
    }
}