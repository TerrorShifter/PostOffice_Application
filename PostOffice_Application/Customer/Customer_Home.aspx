﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_Home.aspx.cs" Inherits="PostOffice_Application.CustomerPage" %>

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
            font-family: 'Bodoni MT';
        }
        h1 {
            font-family: 'Bodoni MT';
            border: 5px solid black;
            background-color: lightsteelblue;
        }
        body {
            background-image: url('../Images/background_paper.png');
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
          <li><a href="Customer_Account.aspx">Account</a></li>-
            <li><a href="CustomerViewOrderHistory.aspx">View Shipment History</a></li>
            <asp:Label ID="USERNAME" runat="server" Text=" Label" Font-Names="Bodoni MT"></asp:Label>
        </ul>
   
    <p>
            &nbsp;</p>
   

    
        <h1 <span class="auto-style3"> <span class="">&nbsp; Select a Tracking Number to view the package details&nbsp;&nbsp; </span> </span></h1>
        <p style="margin-left: 40px">
            &nbsp;</p>


        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Tracking_Num" DataValueField="Tracking_Num" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False" ondatabound="DropDownList1_DataBound" Height="48px" Width="199px" Font-Names="Bodoni MT" border-radius="4px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Tracking_Num] FROM [SHIPMENT], [CUSTOMER] WHERE [Sender_ID] = [Customer_ID] AND ([Email] = @Email)">
            <SelectParameters>
                <asp:SessionParameter Name="Email" SessionField="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
         <!--Sidenote to myself Where session = Username -->
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Tracking_Num" DataSourceID="SqlDataSource2" Width="696px" style="height: 0px; z-index: 1; left: 7px; top: 268px; position: absolute; width: 696px; background-color: #F3F3F3;" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Bodoni MT">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Tracking_Num" HeaderText="Tracking_Num" InsertVisible="False" ReadOnly="True" SortExpression="Tracking_Num" />
                        <asp:BoundField DataField="Status_String" HeaderText="Status_String" SortExpression="Status_String" />
                        <asp:BoundField DataField="Priority_Type" HeaderText="Priority_Type" SortExpression="Priority_Type" />
                        <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />
                        <asp:BoundField DataField="Fragility_Level" HeaderText="Fragility_Level" SortExpression="Fragility_Level" />
                        <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                        <asp:BoundField DataField="Value_of_Contents" HeaderText="Value_of_Contents" SortExpression="Value_of_Contents" />
                        <asp:BoundField DataField="Contents" HeaderText="Contents" SortExpression="Contents" />
                        <asp:BoundField DataField="Recipient_FName" HeaderText="Recipient_FName" SortExpression="Recipient_FName" />
                        <asp:BoundField DataField="Recipient_LNAme" HeaderText="Recipient_LNAme" SortExpression="Recipient_LNAme" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Tracking_Num], [Status_String],[Priority_Type], [Weight], [Fragility_Level], [Rate], [Value_of_Contents],[Contents],[Recipient_FName],[Recipient_LNAme] FROM [SHIPMENT], [DELIVERY_STRING], [DELIVERY_STATUS], [PRIORITY], [FRAGILITY] WHERE ([Tracking_Num] = @Tracking_Num) AND [Delivery_Status] = [Delivery_Status_ID] AND [Status] = [Status_ID] AND ([SHIPMENT].Priority_ID = [PRIORITY].Priority_ID) AND ([Fragile] = [Fragility_ID]) ">
                    <SelectParameters>
                        <asp:SessionParameter Name="Tracking_Num" SessionField="TrackingID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:View>
        </asp:MultiView>
    </form>
   

 


   </body>

</html>
