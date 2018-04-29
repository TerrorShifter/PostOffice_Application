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
            margin-top: 0px;
            height: 1357px;
            width: 1078px;
        }
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
            font-family: 'Bodoni MT';
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

        .label {
            font-family: 'Agency FB';
            font-weight: bold;
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
            width: 120px;
            height: 50px;
            border-radius: 4px;
            font-family: 'Bodoni MT';
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
        }

        .button:active {
          background-color:dodgerblue;
          box-shadow: 0 5px #666;
          transform: translateY(4px);
        }
        
        input[type=text] {
            background-image: url('Images/textbox-icon.png');
            background-repeat: no-repeat;
            height: 50px;
            width: 250px;
            background-position: 10px 10px;
            padding-left: 75px;
            font-family: 'Bodoni MT';
        }

        .auto-style7 {
            font-size: large;
            font-family: 'Bodoni MT';
            text-align: center;
            font-weight: bold;
        }

        .auto-style8 {
            font-size: x-large;
            font-family: 'Bodoni MT';
            font-weight: bold;
        }

        .lbl {
            font-family: 'Bodoni MT';
            font-weight: bold;
        }
        .auto-style9 {}
        </style>
</head>
<body style="background-image: url('Images/background_paper.png');">
    <ul>
        <li><a href="Start/Login.aspx">Login</a></li>               
    </ul>
    <form id="form1" runat="server">
        <div>
        </div>
        <p style="height: 187px; margin-bottom: 1px;">

            <img class="auto-style1" src="Images/tracking_background.png" />

                <div align="center" class="auto-style3" style="margin-top:475px">

                    
                    <input type="text" id="txtTracking" placeholder="Type Your Tracking Number" runat="server"/>
                    <!--<input id="inputBox" placeholder="Type Your Tracking Number" type="text" />!-->
                    <asp:Button ID="btnTrack" runat="server" OnClick="Track_Click" CssClass="button" Text="Track" />
                    <br />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Invalid Tracking Number" Visible="False" CssClass="label"></asp:Label>
                    <br />
                    <asp:Label ID="lblLocate" runat="server" CssClass="auto-style8" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblShipped" runat="server" CssClass="auto-style7" Text="Label"></asp:Label>
                    <asp:Image ID="imgCheck" runat="server" CssClass="auto-style9" Height="16px" ImageUrl="~/Images/transparent-green-checkmark-hi.png" Width="26px" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="lbl"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="lbl"></asp:Label>

                </div>
        </p> 
    </form>
    </body>
</html>
