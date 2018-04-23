<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PostOffice_Application.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            display: block;
            margin-left: auto;
            margin-right: auto;
            /*width: 20%;*/
            margin-top: 84px;
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
        #Text1 {
            height: 32px;
            width: 303px;
            margin-left: 573px;
        }
        #inputBox {
            display: block;
            height: 37px;
            width: 288px;
            margin: auto;
            /*margin-left: auto;
            margin-right: auto;*/
            /*margin-left: 579px;*/
        }
                
        .auto-style3 {
            height: 196px;
            margin-top: 0px;
        }
        
        .auto-style5 {}

        .auto-style7 {
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }

        .auto-style8 {
            font-size: x-large;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style9 {}

        </style>
</head>
<body style="height: 73px">
    <ul>
        <li><a href="Start/Login.aspx">Login</a></li>               
    </ul>
    <form id="form1" runat="server">
        <div>
        </div>
        <p style="height: 187px; margin-bottom: 1px;">

            <img class="auto-style1" src="email-png-email-png-285.png" />

                <div align="center" class="auto-style3">

                    <asp:TextBox ID="txtBoxTracking" placeholder="Type Your Tracking Number" runat="server" CssClass="auto-style5" Height="36px" OnTextChanged="txtBoxTracking_TextChanged" Width="256px"></asp:TextBox>
                    <!--<input id="inputBox" placeholder="Type Your Tracking Number" type="text" />!-->
                    <asp:Button ID="btnTrack" runat="server" Height="42px" OnClick="Track_Click" style="font-size: medium; margin-left: 4px; margin-top: 4px; margin-bottom: 0px" Text="Track" Width="82px" />
                    <br />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Invalid Tracking Number" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="lblLocate" runat="server" CssClass="auto-style8" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblShipped" runat="server" CssClass="auto-style7" Text="Label"></asp:Label>
                    <asp:Image ID="imgCheck" runat="server" CssClass="auto-style9" Height="16px" ImageUrl="~/transparent-green-checkmark-hi.png" Width="26px" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

                </div>
        </p> 
    </form>
    </body>
</html>
