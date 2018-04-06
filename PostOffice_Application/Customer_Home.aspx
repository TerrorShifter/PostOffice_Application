<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Home.aspx.cs" Inherits="PostOffice_Application.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- This shows the little arrow for the drop down menu -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


    <title></title>
    <style>


        /*This is to change the entire page background color*/
        body {
    background-color: #f3f3f3;
}


         /*https://www.w3schools.com/howto/howto_css_dropdown_navbar.asp is where I got the below style code block for dropdown menu*/
        .navbar {
    overflow: hidden;
    background-color: #c1c1c1;
    font-family: Arial, Helvetica, sans-serif;
}
.navbar a {
    float: left;
    font-size: 16px;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}
.dropdown {
    float: left;
    overflow: hidden;
}
.dropdown .dropbtn {
    font-size: 16px;    
    border: none;
    outline: none;
    color: white;
    padding: 14px 16px;
    background-color: inherit;
    font-family: inherit;
    margin: 0;
}
.navbar a:hover, .dropdown:hover .dropbtn {
    background-color: #4d4d4d;
}
.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;
}
.dropdown-content a {
    float: none;
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    text-align: left;
}
.dropdown-content a:hover {
    background-color: #ddd;
}
.dropdown:hover .dropdown-content {
    display: block;
}





    /*Header style for double outline*/
    h2 {border-style: double;}





</style><!-- End of Style Block -->



</head>
<body>
    <h2>Customer Page</h2>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>



    <div class="navbar">
  <a href="Customer_Home.aspx">Home</a><!-- Links to my Customer_HomePage -->
  <a href="Customer_Tracking.aspx">Tracking</a> <!-- Links my Customer TrackingPage -->
  <div class="dropdown">
    <button class="dropbtn">More 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content"> <!-- This displays the tabs within the dropdown menu -->
      <a href="#">Account</a> <!--These are placeholders currently Linking no where -->
      <a href="#">Sign Out</a>
      <a href="#">Help</a>
    </div>
  </div> 
</div>


     <!-- Placeholder Text just to show that You are in the Home page -->
    <h3>Welcome to our Post Office Customer HomePage!</h3>



</body>

</html>
