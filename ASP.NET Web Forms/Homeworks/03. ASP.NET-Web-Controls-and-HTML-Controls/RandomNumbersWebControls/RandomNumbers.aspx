<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="RandomNumbersWebControls.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random numbers</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label for="TextFieldMinNumber" runat="server" Text="Min number:"/>
        <asp:TextBox id="TextFieldMinNumber" runat="server" />
        <asp:Label for="TextFieldMaxNumber" runat="server" Text="Max number:"/>
        <asp:TextBox id="TextFieldMaxNumber" runat="server" />
        <asp:Button id="ButtonSubmit" runat="server" Text="Generate" OnClick="ButtonSubmit_Click" />
        <asp:Label id="LabelResult" runat="server"/>
    </form>
</body>
</html>
