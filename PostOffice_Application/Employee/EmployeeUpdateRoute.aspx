<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeUpdateRoute.aspx.cs" Inherits="PostOffice_Application.Employee.EmployeeUpdateRoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
    <h2>    
        Check-in at a stop</h2>
    <p>
        Route ID:
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Route_ID" DataValueField="Route_ID" OnSelectedIndexChanged="ddl1_IndexChanged" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Route_ID] FROM [DELIVERY_ROUTE]"></asp:SqlDataSource>
        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="DELIVERY_ROUTE" OnClick="Lookup">Lookup</asp:LinkButton>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        Stop Address ID:
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Address_ID" DataValueField="Stop_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Stop_ID], [Address_ID] FROM [CURRENT_STOP] WHERE ([Route_ID] = @Route_ID)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="Route_ID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument="ADDRESS" OnClick="Lookup">Lookup</asp:LinkButton>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="UpdateSubmit" Text="Check-in" />
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
