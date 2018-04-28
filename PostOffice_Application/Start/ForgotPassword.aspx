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
            height: 180px;
            width: 242px;
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
        table {
            border: 5px solid black;
            height: 400px;
            width: 700px;
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
        .auto-style2 {
            height: 180px;
            width: 260px;
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
            width: 275px;
            height: 75px;
            border-radius: 4px;
            text-align: center;
            font-family: 'Bodoni MT';
            font-size:larger;
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
        }

        .button:active {
          background-color:dodgerblue;
          box-shadow: 0 5px #666;
          transform: translateY(4px);
        }
        input[type=text] {       
            height: 50px;
            width: 375px;
            background-position: 10px 10px;
            font-family: 'Bodoni MT';
            font-size: larger;
            background-image: url('../Images/textbox-icon.png');
            background-repeat: no-repeat;
            padding-left: 75px;
        }
        .imge {
            display: block;
            margin-left: auto;
            margin-right: auto;
            margin-top: 0px;
            height: 1357px;
            width: 1078px;
        }
        .auto-style3 {
            width: 260px;
        }
        .auto-style4 {
            width: 242px;
        }
    </style>
</head>
<body style="background-image: url('../Images/background_paper.png');">
    <ul>      
        <li><a href="Login.aspx">Login</a></li>
        <li class="home"><a href="../Default.aspx">Home</a></li>
    </ul>
    <form id="form1" runat="server">
        <div>
            <img class="imge" src="../Images/envelope_background.png" />
            <table>
                <caption style="border:5px solid black; background-color:skyblue; font-size:xx-large;">Forgot Password?</caption>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Username/Email:"></asp:Label></td>
                    <td class="auto-style1">
                        <input type="text" id="textUsername" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblBadEmail" runat="server" Text="Invalid Email" ForeColor="Red" Font-Names="Agency FB"></asp:Label></td>
                    <td class="auto-style4">
                        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="button" OnClick="btnSend_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
