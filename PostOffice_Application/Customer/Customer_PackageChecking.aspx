<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_PackageChecking.aspx.cs" Inherits="PostOffice_Application.Customer.WebForm1" %>

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
            resize: vertical /* Allow the user to vertically resize the textarea (not horizontally) */;
            z-index: 1;
            left: 3px;
            top: 171px;
            position: absolute;
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
        .auto-style2 {
            background-color: #F3F3F3;
        }
        .auto-style3 {
            color: #000000
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">
        <ul>
            <li><asp:Button ID="btnLogoff" runat="server" Text="Logoff" OnClick="btnLogoff_Click" CssClass="btn" Height="55px"/></li>
            <li><a href="../Common/Password_Reset.aspx">Reset Password</a></li>
            <li><a href="CustomerViewOrderHistory.aspx">View Shipment History</a></li>
            <li class="home"><a href="Customer_Home.aspx">Home</a></li>
        </ul>
   

    
        <p>
            &nbsp;</p>
   

    
        <h1 <span class="auto-style3"> <span class="auto-style2">&nbsp; Select a Tracking Number to view the package details&nbsp;&nbsp; </span> </span></h1>
        <p style="margin-left: 40px">
            &nbsp;</p>


        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Tracking_Num" DataValueField="Tracking_Num" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False" ondatabound="DropDownList1_DataBound" >
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Tracking_Num] FROM [SHIPMENT], [CUSTOMER] WHERE [Sender_ID] = [Customer_ID] AND ([Email] = @Email)">
            <SelectParameters>
                <asp:SessionParameter Name="Email" SessionField="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
         <!--Sidenote to myself Where session = Username -->
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Tracking_Num" DataSourceID="SqlDataSource2" Width="696px" style="height: 0px; z-index: 1; left: 7px; top: 268px; position: absolute; width: 696px; background-color: #F3F3F3;">
                    <Columns>
                        <asp:BoundField DataField="Tracking_Num" HeaderText="Tracking_Num" InsertVisible="False" ReadOnly="True" SortExpression="Tracking_Num" />
                        <asp:BoundField DataField="Status_String" HeaderText="Status_String" SortExpression="Status_String" />
                        <asp:BoundField DataField="Priority_Type" HeaderText="Priority_Type" SortExpression="Priority_Type" />
                        <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />
                        <asp:BoundField DataField="Fragility_Level" HeaderText="Fragility_Level" SortExpression="Fragility_Level" />
                        <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                        <asp:BoundField DataField="Value_of_Contents" HeaderText="Value_of_Contents" SortExpression="Value_of_Contents" />
                        <asp:BoundField DataField="Contents" HeaderText="Contents" SortExpression="Contents" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Tracking_Num], [Status_String],[Priority_Type], [Weight], [Fragility_Level], [Rate], [Value_of_Contents],[Contents] FROM [SHIPMENT], [DELIVERY_STRING], [DELIVERY_STATUS], [PRIORITY], [FRAGILITY] WHERE ([Tracking_Num] = @Tracking_Num) AND [Delivery_Status] = [Delivery_Status_ID] AND [Status] = [Status_ID] AND ([SHIPMENT].Priority_ID = [PRIORITY].Priority_ID) AND ([Fragile] = [Fragility_ID]) ">
                    <SelectParameters>
                        <asp:SessionParameter Name="Tracking_Num" SessionField="TrackingID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:View>
        </asp:MultiView>
    </form>
   

 


   </body>

</html>
