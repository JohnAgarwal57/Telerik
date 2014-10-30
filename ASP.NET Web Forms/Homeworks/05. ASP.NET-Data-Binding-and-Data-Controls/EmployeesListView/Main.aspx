<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EmployeesListView.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="css/site.css" type="text/css" />
    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/bootstrap/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListView ID="EmployeeListView" runat="server" ItemType="Northwind.Employee">
            <LayoutTemplate>
                <h2 class="text-center">Employees</h2>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="well">
                    <h3><%#: Item.FirstName + " "+ Item.LastName %></h3>
                    Job Title: <%#: Item.Title %>
                    <br />
                    Phone: <%#: Item.HomePhone %>
                    <br />
                    HireDate: <%#: Item.HireDate %>
                    <br />
                    Notes: <%#: Item.Notes %>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
