using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace PostOffice_Application
{
    public partial class EmployeeCreatePackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnLogout = this.Master.FindControl("btnLogoff") as Button;
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList1.SelectedIndex = 0;
                DropDownList1.AppendDataBoundItems = true;
                DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList2.SelectedIndex = 0;
                DropDownList2.AppendDataBoundItems = true;
                DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList3.SelectedIndex = 0;
                DropDownList3.AppendDataBoundItems = true;
                DropDownList4.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList4.SelectedIndex = 0;
                DropDownList4.AppendDataBoundItems = true;
                DropDownList5.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList5.SelectedIndex = 0;
                DropDownList5.AppendDataBoundItems = true;
                DropDownList6.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList6.SelectedIndex = 0;
                DropDownList6.AppendDataBoundItems = true;
                DropDownList7.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList7.SelectedIndex = 0;
                DropDownList7.AppendDataBoundItems = true;
                DropDownList8.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList8.SelectedIndex = 0;
                DropDownList8.AppendDataBoundItems = true;
                DropDownList9.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList9.SelectedIndex = 0;
                DropDownList9.AppendDataBoundItems = true;
                DropDownList10.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList10.SelectedIndex = 0;
                DropDownList10.AppendDataBoundItems = true;
                DropDownList11.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                DropDownList11.SelectedIndex = 0;
                DropDownList11.AppendDataBoundItems = true;
            }
        }

        protected void Lookup(object sender, EventArgs e)
        {
            string url = "IDLookup.aspx?EntityTable=" + ((LinkButton)sender).CommandArgument.ToString();
            string s = "window.open('" + url + "', '_blank', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", s, true);
        }

        protected void CreateSubmit(object sender, EventArgs e)
        {
            try
            {
                Label15.Text = "";
                Label16.Text = "";
                Label17.Text = "";
                Label18.Text = "";
                Label19.Text = "";
                Label20.Text = "";
                Label26.Text = "";
                Label21.Text = "";
                Label22.Text = "";
                Label23.Text = "";
                Label24.Text = "";
                Label25.Text = "";
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Insert Into SHIPMENT (Weight, Recipient_FName, Recipient_LName, Recipient_Phone, Recipient_Address_ID, Sender_ID, Package_Type, Delivery_Status, Rate, Priority_ID, Fragile, Contents, Value_Of_Contents) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val7, @Val8, @Val9, @Val10, @Val11, @Val12, @Val13, @Val14)";
                sqlCmd.Connection = sqlConnection1;
                bool readyToSubmit = true;
                decimal ftemp = 0; int itemp = 0;
                if (TextBox1.Text == "")
                {
                    Label16.Text = "Required";
                    readyToSubmit = false;
                }
                else if(!decimal.TryParse(TextBox1.Text, out ftemp))
                {
                    Label16.Text = "Must be a decimal number";
                    readyToSubmit = false;
                }
                else if (ftemp <= 0)
                {
                    Label16.Text = "Must be greater than 0";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val1", decimal.Round(ftemp, 4));
                if (TextBox2.Text == "")
                {
                    Label17.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val2", TextBox2.Text);
                if (TextBox3.Text == "")
                {
                    Label18.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val3", TextBox3.Text);
                if (TextBox22.Text == "")
                {
                    Label19.Text = "Required";
                    readyToSubmit = false;
                }
                else if (!Int32.TryParse(TextBox22.Text, out itemp))
                {
                    Label19.Text = "Must be an integer";
                    readyToSubmit = false;
                }
                else if (itemp < 0)
                {

                    Label19.Text = "Cannot be negative";
                    readyToSubmit = false;
                }
                else if (TextBox22.Text.Length < 7)
                {
                    Label19.Text = "Must be at least 7 digits";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val4", itemp);
                if (DropDownList9.SelectedValue == "")
                {
                    Label20.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val5", DropDownList9.SelectedValue);
                if (DropDownList6.SelectedValue == "")
                {
                    Label5.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val7", DropDownList6.SelectedValue);
                if (DropDownList1.SelectedValue == "")
                {
                    Label24.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val8", DropDownList1.SelectedValue);
                sqlConnection1.Open();
                using (SqlCommand cmd = new SqlCommand("Insert Into DELIVERY_STATUS (Status, Estimated_Arrival, Employee) Output INSERTED.Delivery_Status_ID Values (6, DATEADD(week,2,current_timestamp), @Val1)", sqlConnection1))
                {
                    if (DropDownList11.SelectedValue == "")
                    {
                        Label15.Text = "Required";
                        readyToSubmit = false;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Val1", DropDownList11.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@Val9", (int)cmd.ExecuteScalar());
                    }
                }
                if (TextBox5.Text == "")
                {
                    Label22.Text = "Required";
                    readyToSubmit = false;
                }
                else if (!decimal.TryParse(TextBox5.Text, out ftemp))
                {
                    Label22.Text = "Must be a decimal number";
                    readyToSubmit = false;
                }
                else if (ftemp <= 0)
                {
                    Label22.Text = "Must be greater than 0";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val10", decimal.Round(ftemp, 2));
                if (DropDownList2.SelectedValue == "")
                {
                    Label25.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val11", DropDownList2.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@Val12", (CheckBox1.Checked) ? 2 : 1);

                if (TextBox23.Text == "")
                {
                    Label26.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val13", TextBox23.Text);
                if (TextBox6.Text == "")
                {
                    Label23.Text = "Required";
                    readyToSubmit = false;
                }
                else if(!decimal.TryParse(TextBox6.Text, out ftemp))
                {
                    Label23.Text = "Must be a decimal number";
                    readyToSubmit = false;
                }
                else if (ftemp <= 0)
                {
                    Label23.Text = "Must be greater than 0";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val14", decimal.Round(ftemp, 2));
                if (readyToSubmit)
                    sqlCmd.ExecuteNonQuery();
                sqlConnection1.Close();
            }
            catch (SqlException ex)
            {
                string display = "Could not create the Shipment - ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }
        protected void InternalSubmit1(object sender, EventArgs e)
        {
            try
            { 
                Label1.Text = "";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                Label5.Text = "";
                Label6.Text = "";
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Insert Into CUSTOMER (Cust_FName, Cust_LName, Phone_Num, Email, Address_ID, Local_Post_Office_ID) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val6)";
                sqlCmd.Connection = sqlConnection1;
                int itemp = 0;
                bool readyToSubmit = true;
                if (TextBox7.Text == "")
                {
                    Label1.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val1", TextBox7.Text);
                if (TextBox8.Text == "")
                {
                    Label2.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val2", TextBox8.Text);
                if (TextBox9.Text == "")
                {
                    Label3.Text = "Required";
                    readyToSubmit = false;
                }
                else if(!Int32.TryParse(TextBox9.Text, out itemp))
                {
                    Label3.Text = "Must be an integer";
                    readyToSubmit = false;
                }
                else if (itemp < 0)
                {
                    Label3.Text = "Cannot be negative";
                    readyToSubmit = false;
                }
                else if (TextBox9.Text.Length < 7)
                {
                    Label3.Text = "Must be at least 7 digits";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val3", itemp);
                if (TextBox10.Text == "")
                {
                    Label4.Text = "Required";
                    readyToSubmit = false;
                }
                else if (!emailCheck(TextBox10.Text))
                {
                    Label4.Text = "Must be a valid email";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val4", TextBox10.Text);
                if (DropDownList5.SelectedValue == "")
                {
                    Label5.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val5", DropDownList5.SelectedValue);
                if (DropDownList10.SelectedValue == "")
                {
                    Label6.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val6", DropDownList10.SelectedValue);
                if (readyToSubmit)
                {
                    sqlConnection1.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    DropDownList6.AppendDataBoundItems = false;
                    DropDownList6.DataBind();
                    DropDownList6.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    DropDownList6.SelectedIndex = DropDownList6.Items.Count - 1;
                    MultiView1.SetActiveView(View1);
                    createLogin();
                }
            }
            catch (SqlException ex)
            {
                string display = "Could not create the Customer - ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }

        protected void createLogin()
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
                };
                using (SqlConnection con = new SqlConnection(constr.ConnectionString))
                {
                    con.Open();
                    int usertype = 1;
                    string password = Membership.GeneratePassword(10, 1);
                    //this query inserts given data from text boxes into correspoding login table in database.
                    string query = "INSERT INTO LOGIN (Username, Password, User_Type_ID) VALUES(@Username, @Password, @UserType)";
                    //Checks if an account has already been created using the given email.
                    string checkDuplicate = "SELECT COUNT(1) FROM LOGIN  WHERE Username=@Username";
                    SqlCommand d = new SqlCommand(checkDuplicate, con);
                    d.Parameters.AddWithValue("@Username", TextBox10.Text.Trim());                   
                    int count = Convert.ToInt32(d.ExecuteScalar());
                    if (count == 1)
                    {
                        display = "Login already exists for this Email Address!";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                    }
                    else
                    {
                        try
                        {
                            //adds info to login table of database, informs user of successful acount creation.
                            SqlCommand c = new SqlCommand(query, con);
                            c.Parameters.AddWithValue("@Username", TextBox10.Text.Trim());                           
                            c.Parameters.AddWithValue("@Password", password);
                            c.Parameters.AddWithValue("@UserType", usertype);
                            c.ExecuteNonQuery();
                  
                        }
                        catch (SqlException ex)
                        {
                            display = "Could not create the Login - ERROR: " + ex.Message;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                        }

                        try
                        {
                            MailMessage mailMessage = new MailMessage();
                            mailMessage.To.Add(TextBox10.Text.Trim());
                            mailMessage.From = new MailAddress("team4post.office@gmail.com");
                            mailMessage.Subject = "Registration Complete!";
                            mailMessage.Body = "Hello, \n\nThank you for registering with your friendly Team 4 Post Office! You may now login with the following credentials.\n\nUsername = " + TextBox10.Text.Trim() + "\nPassword = " + password + "\n\nAfter logging in please reset your password to a personlized custom password. \n\nThanks, \n\nTeam 4";
                            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                            {
                                Credentials = new NetworkCredential("team4post.office@gmail.com", "mail!youve4got"),
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network
                            };
                            smtpClient.Send(mailMessage);
                            Session["Username"] = null;
                        }
                        catch (Exception ex)
                        {
                            display = "Could not send the Email - ERROR: " + ex.Message;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected void InternalSubmit2(object sender, EventArgs e)
        {
            try
            {
                Label7.Text = "";
                Label8.Text = "";
                Label9.Text = "";
                Label10.Text = "";
                Label27.Text = "";
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Insert Into ADDRESS (Country_ID, State_ID, City, Zip, Apartment_Num, Street_Address1, Street_Address2) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val6, @Val7)";
                sqlCmd.Connection = sqlConnection1;
                bool readyToSubmit = true;
                int itemp = 0;
                if (DropDownList3.SelectedValue == "")
                {
                    Label7.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val1", DropDownList3.SelectedValue);
                if (DropDownList4.SelectedValue == "")
                    sqlCmd.Parameters.AddWithValue("@Val2", DBNull.Value);
                else
                    sqlCmd.Parameters.AddWithValue("@Val2", DropDownList4.SelectedValue);
                if (TextBox11.Text == "")
                {
                    Label8.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val3", TextBox11.Text);
                if (TextBox12.Text == "")
                {
                    Label9.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val4", TextBox12.Text);
                if (TextBox13.Text == "")
                    sqlCmd.Parameters.AddWithValue("@Val5", DBNull.Value);
                else if(!Int32.TryParse(TextBox13.Text, out itemp))
                {
                    Label27.Text = "Must be an integer";
                    readyToSubmit = false;
                }
                else if(itemp < 0)
                {
                    Label27.Text = "Cannot be negative";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val5", TextBox13.Text);
                if (TextBox14.Text == "")
                {
                    Label10.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val6", TextBox14.Text);
                if (TextBox15.Text == "")
                    sqlCmd.Parameters.AddWithValue("@Val7", DBNull.Value);
                else
                    sqlCmd.Parameters.AddWithValue("@Val7", TextBox15.Text);
                if (readyToSubmit)
                {
                    sqlConnection1.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    DropDownList5.AppendDataBoundItems = false;
                    DropDownList5.DataBind();
                    DropDownList5.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    DropDownList5.SelectedIndex = DropDownList5.Items.Count - 1;
                    MultiView2.SetActiveView(View4);
                }
            }
            catch (SqlException ex)
            {
                string display = "Could not create the Address - ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }
        protected void InternalSubmit3(object sender, EventArgs e)
        {
            try
            {
                Label7.Text = "";
                Label8.Text = "";
                Label9.Text = "";
                Label10.Text = "";
                Label28.Text = "";
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Post_OfficeConnectionString"].ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "Insert Into ADDRESS (Country_ID, State_ID, City, Zip, Apartment_Num, Street_Address1, Street_Address2) Values (@Val1, @Val2, @Val3, @Val4, @Val5, @Val6, @Val7)";
                sqlCmd.Connection = sqlConnection1;
                bool readyToSubmit = true;
                int itemp = 0;
                if (DropDownList7.SelectedValue == "")
                {
                    Label11.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val1", DropDownList7.SelectedValue);
                if (DropDownList8.SelectedValue == "")
                    sqlCmd.Parameters.AddWithValue("@Val2", DBNull.Value);
                else
                    sqlCmd.Parameters.AddWithValue("@Val2", DropDownList8.SelectedValue);
                if (TextBox17.Text == "")
                {
                    Label12.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val3", TextBox17.Text);
                if (TextBox18.Text == "")
                {
                    Label13.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val4", TextBox18.Text);
                if (TextBox19.Text == "")
                    sqlCmd.Parameters.AddWithValue("@Val5", DBNull.Value);
                else if(!Int32.TryParse(TextBox19.Text, out itemp))
                {
                    Label28.Text = "Must be an integer";
                    readyToSubmit = false;
                }
                else if (itemp < 0)
                {
                    Label28.Text = "Cannot be negative";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val5", TextBox19.Text);
                if (TextBox20.Text == "")
                {
                    Label14.Text = "Required";
                    readyToSubmit = false;
                }
                else
                    sqlCmd.Parameters.AddWithValue("@Val6", TextBox20.Text);
                if (TextBox21.Text == "")
                    sqlCmd.Parameters.AddWithValue("@Val7", DBNull.Value);
                else
                    sqlCmd.Parameters.AddWithValue("@Val7", TextBox21.Text);
                if (readyToSubmit)
                {
                    sqlConnection1.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    MultiView3.SetActiveView(View6);
                    DropDownList9.AppendDataBoundItems = false;
                    DropDownList9.DataBind();
                    DropDownList9.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    DropDownList9.SelectedIndex = DropDownList9.Items.Count - 1;
                }
            }
            catch (SqlException ex)
            {
                string display = "Could not create the Address - ERROR: " + ex.Message;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            }
        }

        protected bool emailCheck(string text)
        {
            if (!text.Contains("@") || !text.Contains("."))
                return false;
            return true;
        }
    }
}