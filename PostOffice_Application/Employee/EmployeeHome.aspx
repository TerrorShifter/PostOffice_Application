<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="PostOffice_Application.EmployeeHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Welcome, <asp:Label ID="Label1" runat="server" Text='<%= Session["Username"]%>'></asp:Label></p>
    <h2>
        Generate a report</h2>
    <p>
        Report type: 
        <asp:DropDownList ID="ddl1" OnSelectedIndexChanged="ddl1_changeView" AutoPostBack="true" runat="server">
            <asp:ListItem Text="" Value="View1"></asp:ListItem>
            <asp:ListItem Text="Packages on shipment" Value="View2"></asp:ListItem>
            <asp:ListItem Text="Customer order history" Value="View3"></asp:ListItem>
            <asp:ListItem Text="Incomplete packages" Value="View4"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
            </asp:View>
            <asp:View ID="View2" runat="server">
                Enter stop ID:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Fetch packages" OnClick="Button1OnClick" />
                <br />  
                <asp:SqlDataSource
                    ID="SqlDataSource1" 
                    runat="server" 
                    DataSourceMode="DataReader" 
                    ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" 
                    SelectCommand="SELECT S.Tracking_Num, S.Weight, S.Sender_ID, S.Recipient_Address_ID, S.Recipient_Phone, S.Package_Type, S.Delivery_Status, S.Rate, S.Priority_ID, S.Fragile, S.Contents, S.Value_of_Contents FROM SHIPMENT AS S INNER JOIN DELIVERY_STRING AS DS ON S.Delivery_Status = DS.Status_ID CROSS JOIN DELIVERY_ROUTE AS D CROSS JOIN CURRENT_STOP AS C WHERE (DS.Status_String = 'In Transit') AND (S.Recipient_Address_ID = C.Address_ID) AND (C.Stop_ID IN D.Stops)">
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Tracking_Num" DataSourceID="SqlDataSource1" EmptyDataText="No packages found!" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="Tracking_Num" HeaderText="Tracking_Num" InsertVisible="False" ReadOnly="True" SortExpression="Tracking_Num" />
                        <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />
                        <asp:BoundField DataField="Sender_ID" HeaderText="Sender_ID" SortExpression="Sender_ID" />
                        <asp:BoundField DataField="Recipient_Address_ID" HeaderText="Recipient_Address_ID" SortExpression="Recipient_Address_ID" />
                        <asp:BoundField DataField="Recipient_Phone" HeaderText="Recipient_Phone" SortExpression="Recipient_Phone" />
                        <asp:BoundField DataField="Package_Type" HeaderText="Package_Type" SortExpression="Package_Type" />
                        <asp:BoundField DataField="Delivery_Status" HeaderText="Delivery_Status" SortExpression="Delivery_Status" />
                        <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                        <asp:BoundField DataField="Priority_ID" HeaderText="Priority_ID" SortExpression="Priority_ID" />
                        <asp:BoundField DataField="Fragile" HeaderText="Fragile" SortExpression="Fragile" />
                        <asp:BoundField DataField="Contents" HeaderText="Contents" SortExpression="Contents" />
                        <asp:BoundField DataField="Value_of_Contents" HeaderText="Value_of_Contents" SortExpression="Value_of_Contents" />
                    </Columns>
                    <EmptyDataRowStyle BorderStyle="None" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="View3" runat="server">
                View3
            </asp:View>
            <asp:View ID="View4" runat="server">
                View4
            </asp:View>
        </asp:MultiView>
    </p>
</asp:Content>
