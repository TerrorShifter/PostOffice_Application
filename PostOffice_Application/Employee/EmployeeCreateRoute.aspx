<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Employee/EmployeeMaster.Master" CodeBehind="EmployeeCreateRoute.aspx.cs" Inherits="PostOffice_Application.Employee.EmployeeCreateRoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Create New Delivery Route</h1>
    <p>
        Starting Address:
        </p>
    <p class="auto-style1">
        Street:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStartStreet" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Street 2:<asp:TextBox ID="txtStartStreet2" runat="server"></asp:TextBox>
&nbsp;City:
        <asp:TextBox ID="txtStartCity" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    </p>
    <p class="auto-style1">
        State:<asp:TextBox ID="txtStartState" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Zip:&nbsp;
        <asp:TextBox ID="txtStartZip" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Country:<asp:TextBox ID="txtStartCountry" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        &nbsp;</p>
    <p>
        Destination Address:
        </p>
    <p class="auto-style1">
        Street:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEndStreet" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Street 2:<asp:TextBox ID="txtEndStreet2" runat="server"></asp:TextBox>
&nbsp; City:
        <asp:TextBox ID="txtEndCity" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    </p>
    <p class="auto-style1">
        State:<asp:TextBox ID="txtEndState" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Zip:&nbsp;
        <asp:TextBox ID="txtEndZip" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Country:<asp:TextBox ID="txtEndCountry" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style1">
        &nbsp;</p>
    <p>
        Driver ID:
        <asp:TextBox ID="txtDriverID" runat="server"></asp:TextBox>
        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="EMPLOYEE" OnClick="Lookup">Lookup</asp:LinkButton>
    </p>
    <p>
        <asp:Button ID="btnCreateRoute" runat="server" OnClick="btnCreateRoute_Click" Text="Create" />
        <asp:Label ID="lblCreateRouteInfo" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
