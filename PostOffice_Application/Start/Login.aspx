<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PostOffice_Application.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .auto-style2 {
            height: 60px;
            width: 165px;
        }
        .auto-style4 {
            height: 60px;
            width: 128px;
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
            font-family: 'Bodoni MT';
            font-weight: bold;
        }

        li a:hover {
            background-color: skyblue;
            color: #111;
            font-family: 'Bodoni MT';
            font-weight: bold;
        }
        .home{
            float: left;
        }
        .auto-style7 {
            width: 165px;
            height: 85px;
        }
        .auto-style9 {
            height: 51px;
            width: 165px;
        }
        .auto-style10 {
            height: 51px;
            width: 128px;
        }
        .button {
            background-color: midnightblue;
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin-left: 4px; 
            margin-top: 4px; 
            margin-bottom: 0px;
            width: 180px;
            height: 50px;
            border-radius: 4px;
            text-align: center;
            font-family: 'Bodoni MT';
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
        }

        .button:active {
          background-color:dodgerblue;
          box-shadow: 0 5px #666;
          transform: translateY(4px);
        }
        input[type=text] {       
            height: 50px;
            width: 250px;
            background-position: 10px 10px;
            font-family: 'Bodoni MT';
            font-size: larger;
        }
        input[type=password] {       
            height: 50px;
            width: 250px;
            background-position: 10px 10px;
            font-family: 'Bodoni MT';
            font-size: larger;
        }
        .imge {
            display: block;
            margin-left: auto;
            margin-right: auto;
            margin-top: 0px;
            height: 1357px;
            width: 1078px;
        }
        table {
            border: 5px solid black;
            height: 400px;
            width: 500px;
            text-align: center;
            font-weight: bold;
            background-color: whitesmoke;
            margin-left: auto;
            margin-right: auto;
            margin-top: -800px;
            font-family: 'Bodoni MT';
            font-weight: bold;
            font-size: x-large;
        }
    </style>
</head>
<body style="background-image: url('../Images/background_paper.png');">
    <ul>      
        <li class="home"><a href="../Default.aspx">Home</a></li>
    </ul>
    <form id="form1" runat="server">           
        <div>
            <img class="imge" src="../Images/envelope_background.png" />
            <table>
                <caption style="border:5px solid black; background-color:skyblue; font-size:xx-large;">Login</caption>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label1" runat="server" Text="Username/Email:"></asp:Label></td>                    
                        <td><input type="text" id="textUsername" runat="server"/></td>
                </tr>
                    <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
                    <td class="auto-style4">
                        <input type="password" id="textPassword" runat="server"/>
                    </td>
                </tr>
                    <tr>
                    <td class="auto-style9">
                        <asp:Label ID="lblLoginError" runat="server" Text="Invalid login info" ForeColor="Red" Font-Names="Agency FB"></asp:Label>
                        &nbsp;</td>
                    <td class="auto-style10">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button"/></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnForgot" runat="server" Text="Forgot Password?" OnClick="btnForgot_Click" CssClass="button"/>
                        </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
