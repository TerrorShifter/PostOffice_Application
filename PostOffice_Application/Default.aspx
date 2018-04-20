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
            height: 96px;
            margin-top: 0px;
        }
        
        .auto-style4 {
            height: 112px;
            width: 875px;
            margin: auto;
            overflow: hidden;
        }
        
        .auto-style5 {}

        .leftPane, .rightPane, .midPane{
            float: left;
            width: 291px;
            height: 112px;
        }

        .auto-style7 {
            z-index: 1;
            left: 341px;
            top: 450px;
            position: absolute;
            height: 38px;
            width: 127px;
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style8 {
            z-index: 1;
            left: 628px;
            position: absolute;
            height: 38px;
            width: 200px;
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
            top: 450px;
        }
        .auto-style9 {
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
            z-index: 1;
            left: 923px;
            top: 453px;
            position: absolute;
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
        <p style="height: 187px; margin-bottom: 1px;">
            <img class="auto-style1" src="email-png-email-png-285.png" />
                <div align="center" class="auto-style3">
                    <asp:TextBox ID="txtBoxTracking" placeholder="Type Your Tracking Number (10 Digits)" runat="server" CssClass="auto-style5" Height="36px" OnTextChanged="txtBoxTracking_TextChanged" Width="256px"></asp:TextBox>
                    <!--<input id="inputBox" placeholder="Type Your Tracking Number" type="text" />!-->
                    <asp:Button ID="btnTrack" runat="server" Height="42px" OnClick="Track_Click" style="font-size: medium; margin-left: 4px; margin-top: 4px; margin-bottom: 0px" Text="Track" Width="82px" />
                    <br />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Invalid Tracking Number" Visible="False"></asp:Label>
                </div>
        </p> 
    <div class="auto-style4">
        <div class ="leftPane">

        &nbsp;
            <asp:Label ID="lblShipped" runat="server" CssClass="auto-style7" Text="Not Shipped" Visible="False"></asp:Label>

        </div>
        <div class ="midPane">

            <asp:Label ID="lblLastArrived" runat="server" CssClass="auto-style8" Text="Last Office Arrived" Visible="False"></asp:Label>

        </div>
        <div class ="rightPane">

            <asp:Label ID="lblDelivered" runat="server" CssClass="auto-style9" Text="Delivered" Visible="False"></asp:Label>

        </div>
        
    </div>
    </form>
    </body>
</html>
