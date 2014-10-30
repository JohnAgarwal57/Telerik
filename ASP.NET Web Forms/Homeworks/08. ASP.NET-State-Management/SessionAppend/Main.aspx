<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SessionAppend.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="main" runat="server">
        <div>
            <asp:TextBox ID="TextBoxInput" runat="server" Text=""></asp:TextBox>
             <asp:Button ID="ButtonAddLoad" runat="server" Text="Post Back"
                OnClick="ButtonAddLoad_Click" />           
        </div>
        <div>
            <asp:Label ID="LabelOutput" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
