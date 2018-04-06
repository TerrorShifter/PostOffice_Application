<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="PostOffice_Application.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:grey;
        }
        .header{
            text-align:center;
            font-weight:bold;
        }
        .auto-style1 {
            height: 113px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="border:5px solid black; height: 260px; width: 428px; text-align:center; font-weight:bold; background-color:whitesmoke; position:fixed; margin-left:-214px; margin-top:-65px; top:25%; left:50%">
                <caption style="border:5px solid black; background-color:skyblue">Forgot Password?</caption>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Username/Email:"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBadEmail" runat="server" Text="Invalid Email" ForeColor="Red"></asp:Label></td>
                    <td>
                        <asp:Button ID="btnSend" runat="server" Text="Send" style="margin-left: 0px" Width="188px" OnClick="btnSend_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
