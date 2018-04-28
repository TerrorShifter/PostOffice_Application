<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password_Reset.aspx.cs" Inherits="PostOffice_Application.Common.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
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
        .pass{
            position:fixed; 
            margin-left:-214px; 
            margin-top:-65px; 
            top:25%; 
            left:50%;
        }
        .auto-style1 {
            height: 28px;
        }
        input[type=password] {       
            height: 50px;
            width: 250px;
            background-position: 10px 10px;
            font-family: 'Bodoni MT';
            font-size: larger;
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
            width: 185px;
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
<body>
    <form id="pwresetform" runat="server">
        <ul>
            <li><asp:Button ID="btnLogoff" runat="server" Text="Logoff" OnClick="btnLogoff_Click" CssClass="btn" Height="55px"/></li>             
        </ul>
        <div>
            <img class="imge" src="../Images/envelope_background.png" />
            <table>
                <tr>
                    <td align="center" colspan="2">Change Your Password</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrPassword">Password:</asp:Label>
                    </td>
                    <td>
                        <input type="password" id="CurrPassword" runat="server"/>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPass">New Password:</asp:Label>
                    </td>
                    <td>
                        <input type="password" id="NewPass" runat="server"/>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPass" ErrorMessage="New Password is required." ToolTip="New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNew">Confirm New Password:</asp:Label>
                    </td>
                    <td>
                        <input type="password" id="ConfirmNew" runat="server"/>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNew" ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPass" ControlToValidate="ConfirmNew" Display="Dynamic" ErrorMessage="The passwords don't match." ValidationGroup="ChangePassword1" Font-Names="Agency FB"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="color:Red;">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">
                        <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Change Password" ValidationGroup="ChangePassword1" CssClass="button" OnClick="ChangePasswordPushButton_Click" />
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="button" OnClick="CancelPushButton_Click1" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

