<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PostOffice_Application.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:grey;
        }
        .auto-style2 {
            height: 60px;
            width: 165px;
        }
        .auto-style3 {
            width: 128px;
        }
        .auto-style4 {
            height: 60px;
            width: 128px;
        }
        .auto-style6 {
            width: 165px;
        }
        .dropdown{
            text-align: center;
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
        <li><a href="SignUp.aspx">Register</a></li> 
        <li class="home"><a href="GuestPage.aspx">Home</a></li>
    </ul>
    <form id="form1" runat="server">
        <div>
            <table style="border:5px solid black; height: 260px; width: 428px; text-align:center; font-weight:bold; background-color:whitesmoke; position:fixed; margin-left:-214px; margin-top:-65px; top:25%; left:50%">
                <caption style="border:5px solid black; background-color:skyblue">Login</caption>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label1" runat="server" Text="Username/Email:"></asp:Label></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtUsername" runat="server" Width="160px"></asp:TextBox></td> 
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is a required field." ForeColor="Yellow"></asp:RequiredFieldValidator>
                </tr>
                 <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td class="auto-style2">
                        
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="Post_Office" DataTextField="User_Type_Name" DataValueField="User_Type_Name" Width="160px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Post_Office" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [User_Type_Name] FROM [USER_TYPE] ORDER BY [User_Type_Name]"></asp:SqlDataSource>
                        
                        </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="160px" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblLoginError" runat="server" Text="Invalid login info" ForeColor="Red"></asp:Label></td>
                    <td class="auto-style4">
                        <asp:Button ID="btnForgot" runat="server" Text="Forgot Password?" Width="160px" OnClick="btnForgot_Click" />
                        </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
