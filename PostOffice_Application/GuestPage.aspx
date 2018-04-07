<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestPage.aspx.cs" Inherits="PostOffice_Application.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 73px">
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:Button ID="Button2" runat="server" Height="31px" OnClick="Button2_Click" style="margin-left: 1318px" Text="Log In" Width="79px" />
            <asp:Button ID="Button1" runat="server" Height="31px" OnClick="Button1_Click" style="margin-left: 4px" Text="Sign Up" Width="79px" />
        </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" BorderStyle="Groove" ForeColor="Black" Height="36px" OnTextChanged="TextBox1_TextChanged" style="text-align: left; font-size: large; margin-left: 545px; margin-right: 0px; margin-top: 196px; margin-bottom: 0px" Width="328px"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Height="42px" OnClick="Button3_Click" style="font-size: medium; margin-left: 4px; margin-top: 11px; margin-bottom: 0px" Text="Track" Width="82px" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
