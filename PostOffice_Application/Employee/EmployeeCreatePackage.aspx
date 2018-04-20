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
        Customer ID (<asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Button CommandName="NextView" ID="btnnext" runat="server" Text = "Create new customer" />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Button CommandName="PrevView" ID="btnprevious" runat="server" Text = "Cancel" />
                <br />
                Customer first name:
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                , last name:
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                <br />
                Customer phone number:
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                , email:
                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                <br />
                Customer address ID:
                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                , local post office ID:
                <asp:TextBox ID="TextBox12" runat="server" style="margin-right: 0px"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Generate new ID" />
            </asp:View>
        </asp:MultiView>
        ):
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
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Package_Type_string" DataValueField="Package_Type_ID">
            <asp:ListItem>Letter</asp:ListItem>
            <asp:ListItem>Package</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString2 %>" SelectCommand="SELECT [Package_Type_string], [Package_Type_ID] FROM [PACKAGE_TYPE]"></asp:SqlDataSource>
    </p>
    <p style="font-size: medium">
        Priority:
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Priority_Type" DataValueField="Priority_ID">
            <asp:ListItem>Standard</asp:ListItem>
            <asp:ListItem>First Class</asp:ListItem>
            <asp:ListItem>Overnight</asp:ListItem>
            <asp:ListItem>Same Day</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString2 %>" SelectCommand="SELECT [Priority_ID], [Priority_Type] FROM [PRIORITY]"></asp:SqlDataSource>
    </p>
    <p style="font-size: medium">
        Fragile?
        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
    </p>
    <p style="font-size: medium">
        <asp:Button ID="Button1" runat="server" PostBackUrl="CreateSuccess.aspx" Text="Submit" />
    </p>
</asp:Content>
