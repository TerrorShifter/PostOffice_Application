<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Tracking.aspx.cs" Inherits="PostOffice_Application.Customer_Tracking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- This shows the little arrow for the drop down menu -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>


    <title></title>

    <!-- Page Style for My Customer Page -->
    <style>

        /*https://www.w3schools.com/howto/howto_css_contact_form.asp this link is where I got the style block below for my tracking form. I made some slight modifications to the design attributes*/
        /* Style inputs with type="text", select elements and textareas */
        input[type=text], select, textarea {
            /* Full width */
            padding: 12px; /* Some padding */  
            border: 1px solid #ccc; /* Gray border */
            border-radius: 4px; /* Rounded borders */
            box-sizing: border-box; /* Make sure that padding and width stays in place */
            margin-top: 6px; /* Add a top margin */
            margin-bottom: 16px; /* Bottom margin */
            resize: vertical /* Allow the user to vertically resize the textarea (not horizontally) */
        }
        /* Style the submit button with a specific background color etc */
        input[type=submit] {
            background-color: #c1c1c1;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        /* When moving the mouse over the submit button, add a darker green color */
        input[type=submit]:hover {
            background-color: #4d4d4d;
        }

        /* Add a background color and some padding around the form */
        .container {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px;
        }


        /*This is to change the entire page background color*/
        body {
            background-color: #f3f3f3;
            height: 629px;
            position: relative;
            top: 0px;
            left: 0px;
        }


        /*https://www.w3schools.com/howto/howto_css_dropdown_navbar.asp is where I got the below style code block for dropdown menu*/
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
        .auto-style1 {
            text-decoration: underline;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <ul>
            <li><asp:Button ID="btnLogoff" runat="server" Text="Logoff" OnClick="btnLogoff_Click" CssClass="btn" Height="55px"/></li>
            <li><a href="../Common/Password_Reset.aspx">Reset Password</a></li>
            <li class="home"><a href="Customer_Home.aspx">Home</a></li>
             <li class="home"><a href="Customer_PackageChecking.aspx">Check Package</a></li>
        </ul>
   

    


   <!-- Form for entering Trackign Number-->
    <label for="">Please enter your Tracking Number for your Package:</label>
      <br/> <!-- Breaks line  -->
    <input type="text" id="TrackingNum" name="Tracking Number" placeholder="Your Tracking Number.."/>
      <br/>

    <input type="submit" value="Submit"/>  <!--Submit Does nothing at the moment-->

     
    </form>
   

 


   </body>

</html>
