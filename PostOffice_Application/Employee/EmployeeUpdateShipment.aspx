<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeUpdateShipment.aspx.cs" Inherits="PostOffice_Application.EmployeeUpdateShipment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update a shipment</h1>
    Tracking number:
    <asp:TextBox ID="txtTrackingNumber" runat="server"></asp:TextBox>
    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="SHIPMENT" OnClick="Lookup">Lookup</asp:LinkButton>
    <br />
    <br />
    New Delivery status:
    <asp:DropDownList ID="DeliveryStatusList" runat="server">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>In Transit</asp:ListItem>
        <asp:ListItem>Out for Delivery</asp:ListItem>
        <asp:ListItem>Delivered</asp:ListItem>
        <asp:ListItem>Returned</asp:ListItem>
        <asp:ListItem>Failed to Deliver</asp:ListItem>
        <asp:ListItem>Processing</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Label ID="lblInvalidInfo" runat="server" ForeColor="Red" Text="lblInvalidInfo" Visible="False"></asp:Label>
</asp:Content>
