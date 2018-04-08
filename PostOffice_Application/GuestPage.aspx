<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestPage.aspx.cs" Inherits="PostOffice_Application.WebForm1" %>

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
            margin-top: 58px;
        }
    </style>
</head>
<body style="height: 73px">
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:Button ID="Button2" runat="server" Height="31px" OnClick="Button2_Click" style="margin-left: 1318px" Text="Log In" Width="79px" />
            <asp:Button ID="Button1" runat="server" Height="31px" OnClick="Button1_Click" style="margin-left: 4px" Text="Sign Up" Width="79px" />
        </p>
        <p style="height: 317px">
            <img class="auto-style1" src="email-png-email-png-285.png" /><asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" BackColor="#E0E0E0" BorderStyle="Groove" ForeColor="Black" Height="12%" OnTextChanged="TextBox1_TextChanged" style="text-align: left; font-size: large; margin-left: 554px; margin-right: 0px; margin-top: 0px; margin-bottom: 1px" Width="22%" OnLoad="TextBox1_Load">Type Your Tracking Number</asp:TextBox>
            <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" style="font-size: medium; margin-left: 4px; margin-top: 11px; margin-bottom: 0px" Text="Track" Width="82px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
