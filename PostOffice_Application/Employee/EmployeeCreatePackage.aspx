<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeCreatePackage.aspx.cs" Inherits="PostOffice_Application.EmployeeCreatePackage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Text1 {
            margin-top: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        New package</p>
    <p style="font-size: medium">
        Package weight:
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Number"></asp:TextBox>
    </p>
    <p style="font-size: medium">
        Recipient first name:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        , last name:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: medium">
        Customer ID:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: medium">
        Recipient address ID:
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: medium">
        Return address ID:
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: medium">
        Package type:
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Letter</asp:ListItem>
            <asp:ListItem>Package</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p style="font-size: medium">
        Priority:
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Standard</asp:ListItem>
            <asp:ListItem>First Class</asp:ListItem>
            <asp:ListItem>Overnight</asp:ListItem>
            <asp:ListItem>Same Day</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p style="font-size: medium">
        Fragile?
        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
    </p>
    <p style="font-size: medium">
        <asp:Button ID="Button1" runat="server" PostBackUrl="CreateSuccess.aspx" Text="Submit" />
    </p>
</asp:Content>
