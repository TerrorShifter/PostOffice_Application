<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PostOffice_Application.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 309px;
            height: 220px;
            margin-left: 594px;
            margin-right: 195px;
            margin-top: 80px;
            margin-bottom: 0px;
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
    </style>
</head>
<body style="height: 73px">
    <ul>
        <li><a href="Start/SignUp.aspx">Register</a></li> 
        <li><a href="Start/Login.aspx">Login</a></li>               
    </ul>
    <form id="form1" runat="server">
        <div>
        </div>
        <p style="height: 317px">
            <img class="auto-style1" src="email-png-email-png-285.png" /><asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" BackColor="#E0E0E0" BorderStyle="Groove" ForeColor="Black" Height="12%" OnTextChanged="TextBox1_TextChanged" style="text-align: left; font-size: large; margin-left: 554px; margin-right: 0px; margin-top: 0px; margin-bottom: 1px" Width="22%" OnLoad="TextBox1_Load">Type Your Tracking Number</asp:TextBox>
            <asp:Button ID="btnTrack" runat="server" Height="42px" OnClick="Track_Click" style="font-size: medium; margin-left: 4px; margin-top: 11px; margin-bottom: 0px" Text="Track" Width="82px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
