﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeCustomerCreation.aspx.cs" Inherits="PostOffice_Application.EmployeeCustomerCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <p>
        &nbsp;</p>
    <h2>Create a new customer</h2>
    <p>
        Customer first name:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        , last name:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </p>
    <p>
        Phone number:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </p>
    <p>
        Email:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server"></asp:Label>
    </p>
    <p>
        Address ID(<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
            <asp:View ID="View2" runat="server">
                <br />
                Country:
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country_Name" DataValueField="Country_ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Country_Name], [Country_ID] FROM [COUNTRY]"></asp:SqlDataSource>
                <asp:Label ID="Label7" runat="server"></asp:Label>
                , State:
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="State_Name" DataValueField="State_ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT * FROM [STATES]"></asp:SqlDataSource>
                , City:
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:Label ID="Label8" runat="server"></asp:Label>
                , Zip:
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <asp:Label ID="Label9" runat="server"></asp:Label>
                <br />
                Apartment Number (optional):
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                <br />
                Street Address 1:
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                <asp:Label ID="Label10" runat="server"></asp:Label>
                <br />
                Street Address 2 (optional):
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="InternalSubmit"/>
                <asp:Button ID="Button3" CommandName="NextView" runat="server" Text="Close" />
            </asp:View>
            <asp:View ID="View1" runat="server">
                <asp:Button ID="Button1" CommandName="PrevView" runat="server" Text="Create new" />
            </asp:View>
        </asp:MultiView>
        ):
        </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="Address_ID" DataValueField="Address_ID">
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Address_ID] FROM [ADDRESS]"></asp:SqlDataSource>
        </ContentTemplate>
        <Triggers> <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" /> </Triggers>
    </asp:UpdatePanel>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Local Post Office ID:
        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" OnClick="CreateSubmit" Text="Submit" />
    </p>
</asp:Content>