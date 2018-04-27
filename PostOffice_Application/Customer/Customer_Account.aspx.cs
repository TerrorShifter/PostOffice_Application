using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PostOffice_Application.Customer
{
    public partial class Customer_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
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
                        //string query = "SELECT COUNT(1) FROM LOGIN L, USER_TYPE U WHERE L.Username=@Username AND L.Password=@Password AND U.User_Type_Name=@UserType AND L.User_Type_ID=U.User_Type_ID";
                        //SqlCommand checkCredentials = new SqlCommand(query, connection);
                        //checkCredentials.Parameters.AddWithValue("@Username", txtUsername.Text.Trim()); //checks unique
                        //checkCredentials.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        //checkCredentials.Parameters.AddWithValue("@UserType", DropDownList1.Text.Trim());

                        // int count = Convert.ToInt32(checkCredentials.ExecuteScalar());
                        // if (count == 1)
                        // {
                        //Session["Username"] = txtUsername.Text.Trim();
                        //Session["UserType"] = DropDownList1.Text.Trim();

                        string getid = "SELECT * FROM CUSTOMER , LOGIN  WHERE Username = Email AND Email = @Username";
                        SqlCommand checkCredentials = new SqlCommand(getid, connection);
                        checkCredentials.Parameters.AddWithValue("@Username", Session["Username"].ToString());


                        //SqlCommand getcustid = new SqlCommand(getid, connection);

                        SqlDataReader idreader = checkCredentials.ExecuteReader();
                        while (idreader.Read())
                        {
                            FName_Textbox.Text = (idreader["Cust_FName"].ToString());//(idreader["Cust_FName"].ToString());
                            LName_TextBox.Text = (idreader["Cust_LName"].ToString());
                            Phone_Num_Textbox.Text = (idreader["Phone_Num"].ToString());
                            Email_Textbox.Text = (idreader["Email"].ToString());
                            //Session["FName"] = idreader.ToString();
                            //FName_Textbox.Text = Session["FName"].ToString();
                        }


                        //string destination = "";
                        //if (DropDownList1.Text.Trim() == "Customer")
                        //  destination = "/Customer/Customer_Home.aspx";
                        //else
                        //   destination = "/Employee/EmployeeHome.aspx";
                        // Response.Redirect(destination);
                        // }
                        //else { lblLoginError.Visible = true; }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Contents.RemoveAll();
            Response.Redirect("../Start/Login.aspx");
        }

        protected void UpdateInfo_Click(object sender, EventArgs e)
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
                    string query = "UPDATE CUSTOMER SET Password = @Password, Cust_FName = @FName, Cust_LName = @LName WHERE Email = @Username";
                    SqlCommand c = new SqlCommand(query, connection);
                    c.Parameters.AddWithValue("@Cust_LName", LName_TextBox.Text.Trim());
                    c.Parameters.AddWithValue("@PCust_FName", FName_Textbox.Text.Trim());
                    c.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                    c.ExecuteNonQuery();
                    connection.Close();
                    if (IsPostBack)
                    {
                        Response.Redirect("Customer_Home.aspx");
                    }
                    //string display = "Password Reset Successful.";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('" + display + "');window.location='" + prevPage + "';", true);
                }
            }
            catch (SqlException ex)
            {
                //string display = "Could not reset password - ERROR: " + ex.Message;
               // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }
    }
}