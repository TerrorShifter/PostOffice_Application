﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_ShipmentDetail.aspx.cs" Inherits="PostOffice_Application.Customer.Customer_ShipmentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- This shows the little arrow for the drop down menu -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>

    <title></title>

    <style>


        /*This is to change the entire page background color*/
        body {
            background-color: #f3f3f3;
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
        .btn{
            background-color: #333;
            color: white;
        }
        .btn:hover{
            background-color: skyblue;
            color: #111;
            font-weight: bold;
        }

    /*Header style for double outline*/
    h2 {border-style: double;}





</style><!-- End of Style Block -->
</head>
<body>
    <form id="form1" runat="server">
         <ul>
            <li><asp:Button ID="btnLogoff" runat="server" Text="Logoff" OnClick="btnLogoff_Click" CssClass="btn" Height="55px"/></li>
            <li><a href="../Common/Password_Reset.aspx">Reset Password</a></li>
            <li><a href="Customer_Tracking.aspx">Tracking</a></li>
        </ul>
    </form>
    <p>
        PLACEHOLDER</p>
</body>
</html>
