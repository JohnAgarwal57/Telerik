<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EmployeeFormView.Main" %>

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
        <asp:FormView ID="FormViewEmployees" runat="server" AllowPaging="true" OnPageIndexChanging="FormViewEmployees_PageIndexChanging">
            <ItemTemplate>
                <h3><%#: Eval("FirstName")+ " " +Eval("LastName") %></h3>
                <table class="table table-striped table-hover">
                    <tr>
                        <td><b>Job Title: </b></td>
                        <td><%#:Eval("Title") %></td>
                    </tr>
                    <tr>
                        <td><b>Phone: </b></td>
                        <td><%#:Eval("HomePhone") %></td>
                    </tr>
                    <tr>
                        <td><b>Hire Date: </b></td>
                        <td><%#:Eval("HireDate") %></td>
                    </tr>
                    <tr>
                        <td><b>Notes: </b></td>
                        <td><%#:Eval("Notes") %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
