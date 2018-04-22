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
    public partial class CustomerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null)
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
                     

                            string getid = "SELECT C.Customer_ID FROM CUSTOMER C, LOGIN L WHERE C.Email = L.Username";
                            SqlCommand getcustid = new SqlCommand(getid, connection);
                            SqlDataReader idreader = getcustid.ExecuteReader();
                            Session["CustomerID"] = idreader.ToString();

                            
                        
                        
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }


























                WelcomeLabel.Text = "Welcome to our Post Office Customer HomePage! "+ Session["Username"].ToString() + " Also your customerID = " + Session["CustomerID"]; //Session[Username] give the username 
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