<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CookieLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelLoggedIn" runat="server" Text="Not logged"></asp:Label>
        <br />
    </div>
    <div>
        <asp:Button ID="ButtonLogMe" runat="server" Text="Log Me" OnClick="ButtonLogMe_Click" />
    </div>
    </form>
</body>
</html>
