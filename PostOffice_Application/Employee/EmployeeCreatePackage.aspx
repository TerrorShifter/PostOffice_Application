<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeCreatePackage.aspx.cs" Inherits="PostOffice_Application.EmployeeCreatePackage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Text1 {
            margin-top: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Create a new shipment</h2>
    <p style="font-size: medium">
        Employee ID:
        <asp:DropDownList ID="DropDownList11" runat="server" DataSourceID="SqlDataSource9" DataTextField="Employee_ID" DataValueField="Employee_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Employee_ID] FROM [EMPLOYEE]"></asp:SqlDataSource>
        <asp:Label ID="Label15" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Package weight:
        <asp:TextBox ID="TextBox1" runat="server" MaxLength="11"></asp:TextBox>
        <asp:Label ID="Label16" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Recipient first name:
        <asp:TextBox ID="TextBox2" runat="server" MaxLength="25"></asp:TextBox>
        <asp:Label ID="Label17" runat="server"></asp:Label>
        , last name:
        <asp:TextBox ID="TextBox3" runat="server" MaxLength="25"></asp:TextBox>
        <asp:Label ID="Label18" runat="server"></asp:Label>
        , phone number:
        <asp:TextBox ID="TextBox22" runat="server" MaxLength="19"></asp:TextBox>
        <asp:Label ID="Label19" runat="server"></asp:Label>
        ,
        Address ID(<asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="1">
            <asp:View ID="View5" runat="server">
                <br />
                Country:
                <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="SqlDataSource3" DataTextField="Country_Name" DataValueField="Country_ID">
                </asp:DropDownList>
                <asp:Label ID="Label11" runat="server"></asp:Label>
                , State:
                <asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="SqlDataSource4" DataTextField="State_Name" DataValueField="State_ID">
                </asp:DropDownList>
                , City:
                <asp:TextBox ID="TextBox17" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label12" runat="server"></asp:Label>
                , Zip:
                <asp:TextBox ID="TextBox18" runat="server" MaxLength="7"></asp:TextBox>
                <asp:Label ID="Label13" runat="server"></asp:Label>
                <br />
                Apartment Number (optional):
                <asp:TextBox ID="TextBox19" runat="server" MaxLength="10"></asp:TextBox>
                <asp:Label ID="Label28" runat="server"></asp:Label>
                <br />
                Street Address 1:
                <asp:TextBox ID="TextBox20" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label14" runat="server"></asp:Label>
                <br />
                Street Address 2 (optional):
                <asp:TextBox ID="TextBox21" runat="server" MaxLength="50"></asp:TextBox>
                <br />
                <asp:Button ID="Button6" runat="server" Text="Submit" OnClick="InternalSubmit3"/>
                <asp:Button ID="Button7" CommandName="NextView" runat="server" Text="Close" />
            </asp:View>
            <asp:View ID="View6" runat="server">
                <asp:Button ID="Button8" CommandName="PrevView" runat="server" Text="Create new" />
            </asp:View>
        </asp:MultiView>
        ):
        <asp:DropDownList ID="DropDownList9" runat="server" DataSourceID="SqlDataSource5" DataTextField="Address_ID" DataValueField="Address_ID">
        </asp:DropDownList>
        <asp:Label ID="Label20" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Customer ID (<asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Button CommandName="NextView" ID="btnnext" runat="server" Text = "Create new" />
            </asp:View>
        <asp:View ID="View2" runat="server">
        <br />
                Customer first name:
        <asp:TextBox ID="TextBox7" runat="server" MaxLength="25"></asp:TextBox>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        , last name:
        <asp:TextBox ID="TextBox8" runat="server" MaxLength="25"></asp:TextBox>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        Phone number:
        <asp:TextBox ID="TextBox9" runat="server" MaxLength="10"></asp:TextBox>
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        Email:
        <asp:TextBox ID="TextBox10" runat="server" MaxLength="50"></asp:TextBox>
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        Address ID(<asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="1">
            <asp:View ID="View3" runat="server">
                <br />
                Country:
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="Country_Name" DataValueField="Country_ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Country_Name], [Country_ID] FROM [COUNTRY]"></asp:SqlDataSource>
                <asp:Label ID="Label7" runat="server"></asp:Label>
                , State:
                <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource4" DataTextField="State_Name" DataValueField="State_ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT * FROM [STATES]"></asp:SqlDataSource>
                , City:
                <asp:TextBox ID="TextBox11" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label8" runat="server"></asp:Label>
                , Zip:
                <asp:TextBox ID="TextBox12" runat="server" MaxLength="7"></asp:TextBox>
                <asp:Label ID="Label9" runat="server"></asp:Label>
                <br />
                Apartment Number (optional):
                <asp:TextBox ID="TextBox13" runat="server" MaxLength="10"></asp:TextBox>
                <asp:Label ID="Label27" runat="server"></asp:Label>
                <br />
                Street Address 1:
                <asp:TextBox ID="TextBox14" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label10" runat="server"></asp:Label>
                <br />
                Street Address 2 (optional):
                <asp:TextBox ID="TextBox15" runat="server" MaxLength="50"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="InternalSubmit2"/>
                <asp:Button ID="Button3" CommandName="NextView" runat="server" Text="Close" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Button ID="Button4" CommandName="PrevView" runat="server" Text="Create new" />
            </asp:View>
        </asp:MultiView>
        ):
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource5" DataTextField="Address_ID" DataValueField="Address_ID">
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Address_ID] FROM [ADDRESS]"></asp:SqlDataSource>
        </ContentTemplate>
        <Triggers> <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" /> </Triggers>
    </asp:UpdatePanel>
    <br />
        Local Post Office ID:
            <asp:DropDownList ID="DropDownList10" runat="server" DataSourceID="SqlDataSource7" DataTextField="Office_Location_ID" DataValueField="Office_Location_ID">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Office_Location_ID] FROM [OFFICE_LOCATION]"></asp:SqlDataSource>
        <asp:Label ID="Label6" runat="server"></asp:Label>
    <br />
        <asp:Button ID="Button5" runat="server" OnClick="InternalSubmit1" Text="Submit" />
            <asp:Button ID="Button9" runat="server" CommandName="NextView" Text="Close" />
            </asp:View>
        </asp:MultiView>
        ):
        <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataSource6" DataTextField="Customer_ID" DataValueField="Customer_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Customer_ID] FROM [CUSTOMER]"></asp:SqlDataSource>
        <asp:Label ID="Label21" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Rate:
        <asp:TextBox ID="TextBox5" runat="server" MaxLength="20"></asp:TextBox>
        <asp:Label ID="Label22" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Value of Contents:
        <asp:TextBox ID="TextBox6" runat="server" MaxLength="20"></asp:TextBox>
        <asp:Label ID="Label23" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Package Type:
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Package_Type_string" DataValueField="Package_Type_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Package_Type_string], [Package_Type_ID] FROM [PACKAGE_TYPE]"></asp:SqlDataSource>
        <asp:Label ID="Label24" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Priority:
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Priority_Type" DataValueField="Priority_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Priority_ID], [Priority_Type] FROM [PRIORITY]"></asp:SqlDataSource>
        <asp:Label ID="Label25" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        Fragile?
        <asp:CheckBox ID="CheckBox1" runat="server" />
    </p>
    <p style="font-size: medium">
        Contents:
        <asp:TextBox ID="TextBox23" runat="server" Height="44px" MaxLength="50" Width="298px" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="Label26" runat="server"></asp:Label>
    </p>
    <p style="font-size: medium">
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="CreateSubmit" />
    </p>
</asp:Content>
