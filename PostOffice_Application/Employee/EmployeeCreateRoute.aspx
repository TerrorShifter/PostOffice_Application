<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Employee/EmployeeMaster.Master" CodeBehind="EmployeeCreateRoute.aspx.cs" Inherits="PostOffice_Application.Employee.EmployeeCreateRoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Create New Delivery Route</h1>
    <p>
        Starting Address:
        <asp:TextBox ID="txtStartingAddr" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </p>
    <p>
        Destination Address:
        <asp:TextBox ID="txtDestinationAddr" runat="server"></asp:TextBox>
    </p>
    <p>
        Driver ID:
        <asp:TextBox ID="txtDriverID" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblCreateRouteInfo" runat="server" Visible="False"></asp:Label>
        <asp:Button ID="btnCreateRoute" runat="server" OnClick="btnCreateRoute_Click" Text="Create" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
