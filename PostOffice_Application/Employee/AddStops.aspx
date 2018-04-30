<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="AddStops.aspx.cs" Inherits="PostOffice_Application.Employee.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="position:fixed; margin-left:-214px; margin-top:-65px; top:25%; left:50%; font-family:'Bodoni MT'">
        <asp:Label ID="Label1" runat="server" Text="Route ID: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Route_ID" DataValueField="Route_ID" OnSelectedIndexChanged="ddl1_IndexChanged" AutoPostBack="True" Font-Names="Bodoni MT">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Route_ID] FROM [DELIVERY_ROUTE]"></asp:SqlDataSource>
        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="DELIVERY_ROUTE" OnClick="Lookup">Lookup</asp:LinkButton>

        &nbsp;|
        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument="EMPLOYEE">Employee Lookup</asp:LinkButton>
&nbsp;|
        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument="ADDRESS">Address Lookup</asp:LinkButton>

        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Route# is a required field." ForeColor="Red" Font-Names="Agency FB"></asp:RequiredFieldValidator>

    </div>
    <div style="position:fixed; margin-left:-350px; margin-top:0px; top:25%; left:25%; right: 313px; font-family:'Bodoni MT';">
        <asp:GridView ID="addressGrid" runat="server" DataSourceID="addressData" Visible="False" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Caption="Available Stops" DataKeyNames="Address_ID" OnSelectedIndexChanged="addressGrid_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField HeaderText="Address_ID" ReadOnly="True" DataField="Address_ID" InsertVisible="False" SortExpression="Address_ID" />
                <asp:BoundField HeaderText="Street_Address1" DataField="Street_Address1" SortExpression="Street_Address1" />
                <asp:BoundField HeaderText="City" DataField="City" SortExpression="City" />
                <asp:BoundField HeaderText="State_ID" DataField="State_ID" SortExpression="State_ID" />
                <asp:BoundField HeaderText="Zip" DataField="Zip" SortExpression="Zip" />
                <asp:BoundField HeaderText="Country_ID" DataField="Country_ID" SortExpression="Country_ID" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="addressData" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT ADDRESS.Address_ID, ADDRESS.Street_Address1, ADDRESS.City, ADDRESS.State_ID, ADDRESS.Zip, ADDRESS.Country_ID FROM ADDRESS INNER JOIN OFFICE_LOCATION ON ADDRESS.Address_ID = OFFICE_LOCATION.Office_Address_ID"></asp:SqlDataSource>
    </div>
    <div style="position:fixed; margin-left:-400px; margin-top:0px; top:25%; left:75%; font-family:'Bodoni MT';">
        <asp:GridView ID="stopsGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Stop_ID" DataSourceID="SqlDataSource1" Visible="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Caption="Stops on Route" EmptyDataText="No stops exist on route" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="routeGrid_IndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Stop_ID" HeaderText="Stop_ID" InsertVisible="False" ReadOnly="True" SortExpression="Stop_ID" />
                <asp:BoundField DataField="Street_Address1" HeaderText="Street_Address1" ReadOnly="True" SortExpression="Street_Address1" />
                <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" SortExpression="City" />
                <asp:BoundField DataField="State_ID" HeaderText="State_ID" ReadOnly="True" SortExpression="State_ID" />
                <asp:BoundField DataField="Zip" HeaderText="Zip" ReadOnly="True" SortExpression="Zip" />
                <asp:BoundField DataField="Country_ID" HeaderText="Country_ID" ReadOnly="True" SortExpression="Country_ID" />
                <asp:CommandField ShowSelectButton="True" SelectText="Remove" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT CURRENT_STOP.Stop_ID, ADDRESS.Street_Address1, ADDRESS.City, ADDRESS.State_ID, ADDRESS.Zip, ADDRESS.Country_ID FROM ADDRESS INNER JOIN CURRENT_STOP ON ADDRESS.Address_ID = CURRENT_STOP.Address_ID INNER JOIN DELIVERY_ROUTE ON CURRENT_STOP.Route_ID = DELIVERY_ROUTE.Route_ID WHERE DELIVERY_ROUTE.Route_ID = @routeid" OnUpdated="SqlDataSource1_Updated" DeleteCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="routeid" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lblStopExists" runat="server" Text="Stop already on route" ForeColor="Red" Visible="False" Font-Names="Agency FB"></asp:Label>
    </div>
    </asp:Content>
