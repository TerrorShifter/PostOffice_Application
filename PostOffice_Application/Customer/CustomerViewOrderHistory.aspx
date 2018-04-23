<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerViewOrderHistory.aspx.cs" Inherits="PostOffice_Application.Customer.CustomerViewOrderHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        /*https://www.w3schools.com/howto/howto_css_contact_form.asp this link is where I got the style block below for my tracking form. I made some slight modifications to the design attributes*/
        /* Style inputs with type="text", select elements and textareas */
        input[type=text], select, textarea {
            /* Full width */
            padding: 12px; /* Some padding */  
            border: 1px solid #ccc; /* Gray border */
            border-radius: 4px; /* Rounded borders */
            box-sizing: border-box; /* Make sure that padding and width stays in place */
            margin-top: 6px; /* Add a top margin */
            margin-bottom: 16px; /* Bottom margin */
            resize: vertical /* Allow the user to vertically resize the textarea (not horizontally) */
        }
        /* Style the submit button with a specific background color etc */
        input[type=submit] {
            background-color: #c1c1c1;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        /* When moving the mouse over the submit button, add a darker green color */
        input[type=submit]:hover {
            background-color: #4d4d4d;
        }

        /* Add a background color and some padding around the form */
        .container {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px;
        }


        /*This is to change the entire page background color*/
        body {
            background-color: #f3f3f3;
            height: 629px;
            position: relative;
            top: 0px;
            left: 0px;
        }


        /*https://www.w3schools.com/howto/howto_css_dropdown_navbar.asp is where I got the below style code block for dropdown menu*/
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
        }

        li {
            float: right;
        }

        li a {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        li a:hover {
            background-color: skyblue;
            color: #111;
            font-weight: bold;
        }
        .home{
            float: left;
        }
        .btn{
            background-color: #333;
            color: white;
        }
        .btn:hover{
            background-color: skyblue;
            color: #111;
            font-weight: bold;
        }


    /*Header style for double outline*/
    h2 {border-style: double;}
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul>
            <li><asp:Button ID="btnLogoff" runat="server" Text="Logoff" OnClick="btnLogoff_Click" CssClass="btn" Height="55px"/></li>
            <li><a href="../Common/Password_Reset.aspx">Reset Password</a></li>
            <li><a href="Customer_PackageChecking.aspx">Check Package</a></li>
            <li class="home"><a href="Customer_Home.aspx">Home</a></li>
        </ul>
   
        <div>
        </div>
        <h1 <span class="auto-style3"> <span class="auto-style2">&nbsp; View Shipment History&nbsp;&nbsp; </span> </span></h1>
        <p style="margin-left: 40px">
  <!--      <h2>View Shipment History</h2> -->
        <p>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT S.Weight, S.Recipient_Phone, S.Rate, S.Contents, S.Value_of_Contents, S.Recipient_FName, S.Recipient_LName, S.Tracking_Num, PA.Package_Type_string, FR.Fragility_Level, PR.Priority_Type, DS.Status_String FROM SHIPMENT AS S INNER JOIN DELIVERY_STATUS AS D ON S.Delivery_Status = D.Delivery_Status_ID INNER JOIN DELIVERY_STRING AS DS ON D.Status = DS.Status_ID INNER JOIN PRIORITY AS PR ON S.Priority_ID = PR.Priority_ID INNER JOIN FRAGILITY AS FR ON S.Fragile = FR.Fragility_ID INNER JOIN PACKAGE_TYPE AS PA ON S.Package_Type = PA.Package_Type_ID INNER JOIN CUSTOMER AS C ON S.Sender_ID = C.Customer_ID WHERE (C.Email = @Email)">
                <SelectParameters>
                    <asp:SessionParameter Name="Email" SessionField="Username" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Tracking_Num" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Tracking_Num" HeaderText="Tracking #" InsertVisible="False" ReadOnly="True" SortExpression="Tracking_Num" />
                    <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />
                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                    <asp:BoundField DataField="Contents" HeaderText="Contents" SortExpression="Contents" />
                    <asp:BoundField DataField="Value_of_Contents" HeaderText="Value of Contents" SortExpression="Value_of_Contents" />
                    <asp:BoundField DataField="Recipient_FName" HeaderText="Recipient First Name" SortExpression="Recipient_FName" />
                    <asp:BoundField DataField="Recipient_LName" HeaderText="Recipient Last Name" SortExpression="Recipient_LName" />
                    <asp:BoundField DataField="Recipient_Phone" HeaderText="Recipient Phone #" SortExpression="Recipient_Phone" />
                    <asp:BoundField DataField="Package_Type_string" HeaderText="Package Type" SortExpression="Package_Type_string" />
                    <asp:BoundField DataField="Fragility_Level" HeaderText="Fragility" SortExpression="Fragility_Level" />
                    <asp:BoundField DataField="Priority_Type" HeaderText="Priority" SortExpression="Priority_Type" />
                    <asp:BoundField DataField="Status_String" HeaderText="Status" SortExpression="Status_String" />
                </Columns>
            </asp:GridView>
        </p>
    </form>
</body>
</html>
