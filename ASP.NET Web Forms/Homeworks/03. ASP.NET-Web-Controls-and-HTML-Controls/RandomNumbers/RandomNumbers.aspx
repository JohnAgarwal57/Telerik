<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="RandomNumbers.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random numbers</title>
</head>
<body>
    <form id="form1" runat="server">
        <label for="TextFieldMinNumber">Min number:</label>
        <input id="TextFieldMinNumber" type="text" runat="server" />
        <label for="TextFieldMaxNumber">Max number:</label>
        <input id="TextFieldMaxNumber" type="text" runat="server" />
        <input id="ButtonSubmit" type="button" runat="server" value="Generate" onserverclick="ButtonSubmit_ServerClick" />
        <label id="LabelResult" runat="server"></label>
    </form>
</body>
</html>
