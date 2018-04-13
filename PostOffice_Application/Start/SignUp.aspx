<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PostOffice_Application.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 220px;
            width: 470px;
            position: fixed;
            top: 15%;
            left: 47%;
        }
        .auto-style2 {
            height: 55px;
            width: 318px;
        }
        .auto-style3 {
            width: 191px;
            height: 40px;
        }
        .auto-style4 {
            width: 191px;
            height: 41px;
        }
        .auto-style5 {
            width: 150px;
            height: 41px;
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
        .home{
            float: left;
        }
        </style>
</head>
<body>
    <ul>      
        <li><a href="Login.aspx">Login</a></li> 
        <li class="home"><a href="GuestPage.aspx">Home</a></li>
    </ul>
    <form id="form1" runat="server">
        <div>
            <table style="border:5px solid black; text-align:center;margin-left:-214px; margin-top:-65px; " class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Label ID="Title" runat="server" Text="Register"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Email" runat="server" Text="Username/Email"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        Password</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="passwordText" runat="server" TextMode="Password" ValidationGroup="password"></asp:TextBox>
                    </td>
                    <td class="auto-style4">

                        &nbsp;</td>

                   
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lblConfirmPW" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style4">

                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="passwordText" ControlToValidate="confirmPassword" CultureInvariantValues="True" ErrorMessage="CompareValidator" ForeColor="Red" ValueToCompare="passwordText">Passwords don&#39;t match.</asp:CompareValidator>
                    </td>

                   
                </tr>
                <tr>
                    <td class="auto-style5" >
                        <asp:Label ID="lblSignUpInfo" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </td>
                    <td class="auto-style3" >
                        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" display="inline-block" OnClick="btnSignUp_Click" Width="136px"/>
                    </td>
                    <td class="auto-style4" >
                    </td>
                </tr>
                   </table>        
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
