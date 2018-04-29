<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Account.aspx.cs" Inherits="PostOffice_Application.Customer.Customer_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>



<style>


        /*This is to change the entire page background color*/
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
        .btn{
            background-color: #333;
            color: white;
            font-family: 'Bodoni MT';
        }
        .btn:hover{
            background-color: skyblue;
            color: #111;
            font-weight: bold;
        }

        .Titlelbl {
            font-family: 'Bodoni MT';
            font-weight:800;
            font-size:x-large;
            text-decoration: underline;
        }
        .lbl {
            font-family: 'Bodoni MT';
            font-weight: bold;
            font-size: medium;
        }
        .txt {
            font-family: 'Bodoni MT';
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
        .home{
            float: left;
        }
        h1 {
            font-family: 'Bodoni MT';
            border: 5px solid black;
            background-color: lightsteelblue;
        }

</style><!-- End of Style Block -->






</head>
<body style="background-image: url('../Images/background_paper.png');">
    <form id="form1" runat="server">

         <ul>
            <li><asp:Button ID="btnLogoff" runat="server" Text="Logoff" OnClick="btnLogoff_Click" CssClass="btn" Height="55px"/></li>
            <li><a href="../Common/Password_Reset.aspx">Reset Password</a></li>
          <li><a href="Customer_PackageChecking.aspx">Check Package</a></li>
            <li class="home"><a href="Customer_Home.aspx">Home</a></li>
        </ul>


        <div>
        </div>
         <p>
             <h1 <span class="auto-style3"> <span class="">&nbsp; Customer Account Information:&nbsp;&nbsp; </span> </span></h1>
         </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Email_Label" runat="server" Text="Email:" CssClass="lbl"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="Email_Textbox" runat="server" CssClass="txt"></asp:TextBox>
         </p>
         <p>
             <asp:Label ID="FName_Label" runat="server" Text="First Name:" CssClass="lbl"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="FName_Textbox" runat="server" CssClass="txt"></asp:TextBox>
         </p>
&nbsp;&nbsp;&nbsp;
         <p>
             <asp:Label ID="LName_Label" runat="server" Text="Last Name:" CssClass="lbl"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="LName_TextBox" runat="server" CssClass="txt"></asp:TextBox>
         </p>
&nbsp;&nbsp;&nbsp;
         <p>
             <asp:Label ID="Phone_Num_Label" runat="server" Text="Phone Number:" CssClass="lbl"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="Phone_Num_Textbox" runat="server" CssClass="txt"></asp:TextBox>
         </p>
         <p>
             &nbsp;</p>
         <p style="margin-left: 120px">
             <asp:Button ID="Update_Submit" runat="server" OnClick="UpdateInfo_Click" Text="Update Information" CssClass="button" />
         </p>
    </form>
</body>
</html>
