<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EmployeesRepeater.Main" %>

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
        <asp:Repeater ID="RepeaterEmployees" runat="server">
            <HeaderTemplate>
            <table class="table table-striped table-hover">
                <tr>
                    <th>Title</th>
                    <th>Names</th>
                    <th>Home Phone</th>
                    <th>Hire Date</th>
                    <th>Notes</th>
                </tr>
            </HeaderTemplate>
            
            <ItemTemplate>
                <tr>
                    <td><%#: DataBinder.Eval(Container.DataItem, "Title") %></td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "FirstName") + " " + DataBinder.Eval(Container.DataItem, "LastName") %></td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "HomePhone") %></td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "HireDate") %></td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "Notes") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
