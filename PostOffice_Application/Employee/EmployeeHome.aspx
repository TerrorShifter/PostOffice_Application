<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="PostOffice_Application.EmployeeHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <p>
        Welcome, <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
    <h2>
        Generate a report</h2>
    <p>
        Report type: 
        <asp:DropDownList ID="ddl1" OnSelectedIndexChanged="ddl1_changeView" AutoPostBack="true" runat="server">
            <asp:ListItem Text="" Value="View1"></asp:ListItem>
            <asp:ListItem Text="Packages on shipment" Value="View2"></asp:ListItem>
            <asp:ListItem Text="Customer order history" Value="View3"></asp:ListItem>
            <asp:ListItem Text="Failed packages" Value="View4"></asp:ListItem>
            <asp:ListItem Text="Packages within a date range" Value="View5"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
            </asp:View>
            <asp:View ID="View2" runat="server">
                Enter route ID:<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Route_ID" DataValueField="Route_ID" OnSelectedIndexChanged="DropDownList1_ChangeSelection" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Route_ID] FROM [DELIVERY_ROUTE]"></asp:SqlDataSource>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument="DELIVERY_ROUTE" OnClick="Lookup">Lookup</asp:LinkButton> | 
                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument="EMPLOYEE" OnClick="Lookup">Employee Lookup</asp:LinkButton> | 
                <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument="ADDRESS" OnClick="Lookup">Address Lookup</asp:LinkButton>
                <br />  
                <asp:SqlDataSource
                    ID="SqlDataSource1" 
                    runat="server" 
                    DataSourceMode="DataReader" 
                    ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" 
                    SelectCommand="SELECT SHIPMENT.Tracking_Num, SHIPMENT.Weight, SHIPMENT.Sender_ID, SHIPMENT.Recipient_Address_ID, SHIPMENT.Recipient_Phone, SHIPMENT.Rate, SHIPMENT.Contents, SHIPMENT.Value_of_Contents, SHIPMENT.Recipient_FName, SHIPMENT.Recipient_LName, PACKAGE_TYPE.Package_Type_string, FRAGILITY.Fragility_Level, PRIORITY.Priority_Type FROM SHIPMENT INNER JOIN PACKAGES_AT_STOP ON SHIPMENT.Tracking_Num = PACKAGES_AT_STOP.Package_ID INNER JOIN PACKAGE_TYPE ON SHIPMENT.Package_Type = PACKAGE_TYPE.Package_Type_ID INNER JOIN DELIVERY_STATUS AS D ON SHIPMENT.Delivery_Status = D.Delivery_Status_ID INNER JOIN DELIVERY_STRING AS DS ON D.Status = DS.Status_ID INNER JOIN CURRENT_STOP AS CS ON PACKAGES_AT_STOP.Stop_ID = CS.Stop_ID INNER JOIN FRAGILITY ON SHIPMENT.Fragile = FRAGILITY.Fragility_ID INNER JOIN PRIORITY ON SHIPMENT.Priority_ID = PRIORITY.Priority_ID WHERE (CS.Route_ID = @Value) AND (DS.Status_String = 'In Transit')">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="Value" PropertyName="SelectedValue"  />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Tracking_Num" DataSourceID="SqlDataSource1" EmptyDataText="No packages found!" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False" OnRowDataBound="GridView1_RowDataBound1" ShowFooter="True">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Tracking #" InsertVisible="False" SortExpression="Tracking_Num" FooterText="Total:">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tracking_Num") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Tracking_Num") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Weight" SortExpression="Weight">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sender ID" SortExpression="Sender_ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Sender_ID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Sender_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recipient Address ID" SortExpression="Recipient_Address_ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Recipient_Address_ID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Recipient_Address_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recipient Phone #" SortExpression="Recipient_Phone">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Recipient_Phone") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Recipient_Phone") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contents" SortExpression="Contents">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Contents") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Contents") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Value of Contents" SortExpression="Value_of_Contents">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Value_of_Contents") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("Value_of_Contents") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label runat="server" ID="lblTotalValue" Text='<%# Eval("Value_of_Contents") %>'></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fragility" SortExpression="Fragility_Level">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Fragility_Level") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("Fragility_Level") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recipient First Name" SortExpression="Recipient_FName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Recipient_FName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("Recipient_FName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recipient Last Name" SortExpression="Recipient_LName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Recipient_LName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("Recipient_LName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Priority" SortExpression="Priority_Type">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Priority_Type") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("Priority_Type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate" SortExpression="Rate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Rate") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label runat="server" ID="lblTotalRate" Text='<%# Eval("Rate") %>'></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Package Type" SortExpression="Package_Type_string">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("Package_Type_string") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("Package_Type_string") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataRowStyle BorderStyle="None" />
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
                    </ContentTemplate>
                    <Triggers> <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" /> </Triggers>
                    </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View3" runat="server">
                From:
                <asp:TextBox ID="View3From" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="v3fLabel" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To:&nbsp;<asp:TextBox ID="View3To" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="v3tLabel" runat="server"></asp:Label>
                <br />
                Enter Customer ID:<asp:DropDownList ID="ddlCustID" runat="server" DataSourceID="SqlDataSource3" DataTextField="Customer_ID" DataValueField="Customer_ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>" SelectCommand="SELECT [Customer_ID] FROM [CUSTOMER]"></asp:SqlDataSource>
                <asp:LinkButton ID="lbtnCustomerLookup" runat="server" CommandArgument="CUSTOMER" OnClick="Lookup">Lookup</asp:LinkButton>
                &nbsp;
                <asp:Label ID="lblCustID" runat="server"></asp:Label>
                <br />
                <asp:Button ID="btnCustHistory" runat="server" OnClick="btnCustHistory_Click" Text="Fetch Package History" />
                <asp:GridView ID="CustHistoryTable" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No packages found!" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            </asp:View>
            <asp:View ID="View4" runat="server">
                From:<asp:TextBox ID="View4From" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="v4fLabel" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To:<asp:TextBox ID="View4To" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="v4tLabel" runat="server" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="btnFailedPackages" runat="server" OnClick="btnFailedPackages_Click" Text="Fetch Packages" />
                <asp:GridView ID="FailedShipmentsTable" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No packages found!" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            </asp:View>
            <asp:View ID="View5" runat="server">
                   From:<asp:TextBox ID="View5From" runat="server" TextMode="Date"></asp:TextBox>
                   &nbsp;<asp:Label ID="v5fLabel" runat="server"></asp:Label>
                   &nbsp;&nbsp;&nbsp;&nbsp; To:<asp:TextBox ID="View5To" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="v5tLabel" runat="server" align="right"></asp:Label>
                   <br />
                   <br />
                   <asp:Button ID="btnGetDateRangeReport" runat="server" OnClick="btnGetDateRangeReport_Click" Text="Fetch Packages" />
                <asp:GridView ID="DateRangeTable" runat="server" align="middle" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No packages found!">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            </asp:View>
        </asp:MultiView>
  
    
</asp:Content>
