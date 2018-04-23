<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Employee/EmployeeMaster.Master" EnableEventValidation="false" CodeBehind="EmployeeCreateRoute.aspx.cs" Inherits="PostOffice_Application.EmployeeCreateRoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
    <h1>Create New Delivery Route</h1>
    <br />
         Starting Address ID(<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
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
                <asp:TextBox ID="TextBox5" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label8" runat="server"></asp:Label>
                , Zip:
                <asp:TextBox ID="TextBox6" runat="server" MaxLength="7"></asp:TextBox>
                <asp:Label ID="Label9" runat="server"></asp:Label>
                <br />
                Apartment Number (optional):
                <asp:TextBox ID="TextBox7" runat="server" MaxLength="19"></asp:TextBox>
                <br />
                Street Address 1:
                <asp:TextBox ID="TextBox8" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label10" runat="server"></asp:Label>
                <br />
                Street Address 2 (optional):
                <asp:TextBox ID="TextBox9" runat="server" MaxLength="50"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="InternalSubmit1"/>
                <asp:Button ID="Button3" CommandName="NextView" runat="server" Text="Close" />
            </asp:View>
            <asp:View ID="View1" runat="server">
                <asp:Button ID="Button1" CommandName="PrevView" runat="server" Text="Create new" />
            </asp:View>
        </asp:MultiView>
        ):
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource5" DataTextField="Address_ID" DataValueField="Address_ID">
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Address_ID] FROM [ADDRESS]"></asp:SqlDataSource>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="Lookup" CommandArgument="ADDRESS">Lookup</asp:LinkButton>
        </ContentTemplate>
        <Triggers> <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" /> </Triggers>
    </asp:UpdatePanel>
    <br />
         Destination Address ID(<asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="1">
            <asp:View ID="View3" runat="server">
                <br />
                Country:
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country_Name" DataValueField="Country_ID">
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server"></asp:Label>
                , State:
                <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource2" DataTextField="State_Name" DataValueField="State_ID">
                </asp:DropDownList>
                , City:
                <asp:TextBox ID="TextBox1" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label2" runat="server"></asp:Label>
                , Zip:
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="7"></asp:TextBox>
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <br />
                Apartment Number (optional):
                <asp:TextBox ID="TextBox3" runat="server" MaxLength="19"></asp:TextBox>
                <br />
                Street Address 1:
                <asp:TextBox ID="TextBox4" runat="server" MaxLength="50"></asp:TextBox>
                <asp:Label ID="Label4" runat="server"></asp:Label>
                <br />
                Street Address 2 (optional):
                <asp:TextBox ID="TextBox10" runat="server" MaxLength="50"></asp:TextBox>
                <br />
                <asp:Button ID="Button4" runat="server" Text="Submit" OnClick="InternalSubmit2"/>
                <asp:Button ID="Button5" CommandName="NextView" runat="server" Text="Close" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Button ID="Button6" CommandName="PrevView" runat="server" Text="Create new" />
            </asp:View>
        </asp:MultiView>
        ):
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataSource5" DataTextField="Address_ID" DataValueField="Address_ID">
            </asp:DropDownList>
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="Lookup" CommandArgument="ADDRESS">Lookup</asp:LinkButton>
        </ContentTemplate>
        <Triggers> <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" /> </Triggers>
    </asp:UpdatePanel>
    <p>
        Driver ID:
        <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="SqlDataSource7" DataTextField="Employee_ID" DataValueField="Employee_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Employee_ID] FROM [EMPLOYEE]"></asp:SqlDataSource>
        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="EMPLOYEE" OnClick="Lookup">Lookup</asp:LinkButton>
        <asp:Label ID="Label11" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnCreateRoute" runat="server" OnClick="CreateSubmit" Text="Submit" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
