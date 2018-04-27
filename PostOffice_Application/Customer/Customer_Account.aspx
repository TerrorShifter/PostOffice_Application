<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Account.aspx.cs" Inherits="PostOffice_Application.Customer.Customer_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>



<style>


        /*This is to change the entire page background color*/
        body {
            background-color: #f3f3f3;
        }

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
        .btn{
            background-color: #333;
            color: white;
        }
        .btn:hover{
            background-color: skyblue;
            color: #111;
            font-weight: bold;
        }





</style><!-- End of Style Block -->






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
         <p>
             <asp:Label ID="Text" runat="server" style="font-weight: 700; font-size: large; text-decoration: underline" Text="Customer Account Information:"></asp:Label>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Email_Label" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="Email_Textbox" runat="server"></asp:TextBox>
         </p>
         <p>
             <asp:Label ID="FName_Label" runat="server" Text="First Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="FName_Textbox" runat="server"></asp:TextBox>
         </p>
&nbsp;&nbsp;&nbsp;
         <p>
             <asp:Label ID="LName_Label" runat="server" Text="Last Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="LName_TextBox" runat="server"></asp:TextBox>
         </p>
&nbsp;&nbsp;&nbsp;
         <p>
             <asp:Label ID="Phone_Num_Label" runat="server" Text="Phone Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="Phone_Num_Textbox" runat="server"></asp:TextBox>
         </p>
         <p>
             &nbsp;</p>
         <p style="margin-left: 120px">
             <asp:Button ID="Update_Submit" runat="server" OnClick="UpdateInfo_Click" Text="Update Information" />
         </p>
    </form>
</body>
</html>
