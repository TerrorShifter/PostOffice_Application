<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IDLookup.aspx.cs" Inherits="PostOffice_Application.IDLookup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image: url('../Images/background_paper.png'); font-family: 'Bodoni MT';">
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Post_OfficeConnectionString %>">
            </asp:SqlDataSource>
        </div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" BackColor="#ddf5ff">
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="Error: Invalid input" Visible="False"></asp:Label>
    </form>
</body>
</html>
