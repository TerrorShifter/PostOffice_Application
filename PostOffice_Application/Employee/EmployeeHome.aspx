<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="PostOffice_Application.EmployeeHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
        .auto-style2 {
            margin-left: 280px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Welcome, &lt;name&gt;.</p>
    <h2>
        Generate a report</h2>
    <p>
        Report type: </p>
    <p class="auto-style1">
        Date Range:
        <asp:TextBox ID="beginDate" runat="server" align="middle"></asp:TextBox>
        To:
        <asp:TextBox ID="endDate" runat="server" align="middle"></asp:TextBox>
        <asp:Label ID="lblDateRangeError" runat="server" ForeColor="Red" Text="Invalid Date." Visible="False" align="right"></asp:Label>
    </p>
    <p class="auto-style2">
        <asp:Button ID="btnGetDateRangeReport" runat="server" OnClick="btnGetDateRangeReport_Click" Text="Get Shipments" />
    </p>
    <asp:GridView ID="DateRangeTable" runat="server" align="middle">
    </asp:GridView>
</asp:Content>
