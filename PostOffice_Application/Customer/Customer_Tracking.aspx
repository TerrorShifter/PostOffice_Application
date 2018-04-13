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
    width: 20%; /* Full width */
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
</style>





</head>
<body>
    <h2>Customer Page</h2>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>


   
    <div class="navbar">
  <a href="Customer_Home.aspx">Home</a> <!-- Links to my Customer_HomePage -->
  <a href="Customer_Tracking.aspx">Tracking</a>  <!-- Links my Customer TrackingPage -->
  <div class="dropdown">
    <button class="dropbtn">More 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">  <!-- This displays the tabs within the dropdown menu -->
      <a href="#">Account</a>
      <a href="#">Sign Out</a>
      <a href="#">Help</a>
    </div>
  </div> 
</div>


     <!-- This is just a header to show you have changed to the Tracking Page from Home Page -->
    <h2>Tracking Page</h2>


   <!-- Form for entering Trackign Number-->
  <form>
    <label for="">Please enter your Tracking Number for your Package:</label>
      <br/> <!-- Breaks line  -->
    <input type="text" id="TrackingNum" name="Tracking Number" placeholder="Your Tracking Number.."/>
      <br/>

    <input type="submit" value="Submit"/>  <!--Submit Does nothing at the moment-->

  </form>



</body>

</html>
