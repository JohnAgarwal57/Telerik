<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EmployeesDetailsView.Main" %>

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
        <asp:GridView id="GridViewEmployees" runat="server" AutoGenerateColumns="false" AllowPaging="true" class="table table-striped table-hover">
            <Columns>
                <asp:BoundField DataField="TitleOfCourtesy" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:HyperLinkField Text="Details" DataNavigateUrlFields="EmployeeId"
                    DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" />
             </Columns>
        </asp:GridView>
    </form>
</body>
</html>
