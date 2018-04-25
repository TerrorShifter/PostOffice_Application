<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeUpdateShipment.aspx.cs" Inherits="PostOffice_Application.EmployeeUpdateShipment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update a shipment</h1>
    Tracking number:
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Tracking_Num" DataValueField="Tracking_Num">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Tracking_Num] FROM [SHIPMENT]"></asp:SqlDataSource>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="SHIPMENT" OnClick="Lookup">Lookup</asp:LinkButton>
    <br />
    <br />
    New Delivery status:
    <asp:DropDownList ID="DeliveryStatusList" runat="server" DataSourceID="SqlDataSource2" DataTextField="Status_String" DataValueField="Status_ID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Status_String], [Status_ID] FROM [DELIVERY_STRING]"></asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    </asp:Content>
