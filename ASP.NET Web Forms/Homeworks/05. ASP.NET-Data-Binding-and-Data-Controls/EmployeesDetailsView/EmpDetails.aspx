<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="EmployeesDetailsView.EmpDetails" %>

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
    <div class="well">
        <form id="form1" class="form-horizontal" runat="server">
            <asp:DetailsView ID="DetailsViewEmployee" AutoGenerateRows="true" runat="server" class="table table-striped table-hover">
            </asp:DetailsView>

            <fieldset>
                <div class="pull-right">
                    <asp:Button id="ButtonBack" class="btn btn-primary" runat="server" Text="Back" OnClick="ButtonBack_Click" />
                </div>
            </fieldset>
        </form>
    </div>
</body>
</html>
