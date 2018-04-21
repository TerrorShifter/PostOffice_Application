<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeCustomerCreation.aspx.cs" Inherits="PostOffice_Application.Employee.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <h2>Create a new customer</h2>
    <p>
        Customer first name:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        , last name:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p>
        Phone number:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p>
        Email:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </p>
    <p>
        Address ID(<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
            <asp:View ID="View2" runat="server">
                <br />
                Country:
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country_Name" DataValueField="Country_ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString2 %>" SelectCommand="SELECT [Country_Name], [Country_ID] FROM [COUNTRY]"></asp:SqlDataSource>
                , State:
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="State_Name" DataValueField="State_ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString2 %>" SelectCommand="SELECT * FROM [STATES]"></asp:SqlDataSource>
                (<asp:CheckBox ID="CheckBox1" runat="server" Text="Not Applicable" />
                &nbsp; ), City:
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                , Zip:
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <br />
                Apartment Number (optional):
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                <br />
                Street Address 1:
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                <br />
                Street Address 2 (optional):
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Submit" />
                <asp:Button ID="Button3" CommandName="NextView" runat="server" Text="Close" />
            </asp:View>
            <asp:View ID="View1" runat="server">
                <asp:Button ID="Button1" CommandName="PrevView" runat="server" Text="Create new" />
            </asp:View>
        </asp:MultiView>
        ):
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
    </p>
    <p>
        Local Post Office ID:
        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" OnClientClick="CreateSubmit" Text="Submit" />
    </p>
</asp:Content>
