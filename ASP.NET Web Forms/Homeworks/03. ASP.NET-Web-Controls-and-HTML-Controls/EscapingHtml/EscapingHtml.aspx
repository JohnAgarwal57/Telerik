<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscapingHtml.aspx.cs" Inherits="EscapingHtml.EscapingHtml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML Escaping</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2><asp:Literal runat="server" Text="Test in Firefox for the script alert"/></h2>
        <asp:TextBox id="TextFieldInput" runat="server"> &lt;script&gt;alert(&quot;bug!&quot;)&lt;/script&gt;</asp:TextBox>
        <asp:Button id="ButtonUnsafeSubmit" runat="server" Text="Unsafe" OnClick="ButtonUnsafeSubmit_Click"/>
        <asp:Button id="ButtonSafeSubmit" runat="server" Text="Safe" OnClick="ButtonSafeSubmit_Click"/>
        <br />
        <asp:TextBox id="TextFieldResult" runat="server" /> 
        <br />       
        <asp:Label id="LabelResult" runat="server"/>
    </form>
</body>
</html>
