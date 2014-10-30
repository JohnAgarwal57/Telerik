<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegisterStudent.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label for="TextFieldFirstName" runat="server" Text="FirstName:"/>
        <asp:TextBox id="TextFieldFirstName" runat="server" />
        <br />
        <asp:Label for="TextFieldLastName" runat="server" Text="LastName:"/>
        <asp:TextBox id="TextFieldLastName" runat="server" />
        <br />
        <asp:Label for="TextFieldFNumber" runat="server" Text="Faculty number:"/>
        <asp:TextBox id="TextFieldFNumber" runat="server" />
        <br />
        <asp:Label for="ListBoxUniversity" runat="server" Text="University:"/>
        <asp:DropDownList id="DropDownListUniversity" runat="server" />
        <br />
        <asp:Label for="ListBoxSpecialty" runat="server" Text="Specialty :"/>
        <asp:DropDownList  id="DropDownListSpecialty" runat="server" />
        <br />
        <asp:Label for="ListBoxCourses" runat="server" Text="Courses :"/>
        <asp:ListBox id="ListBoxCourses" runat="server" AutoPostBack="False" SelectionMode="Multiple" DataTextField="Text" DataValueField="Id"/>
        <br />
        <asp:Button id="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
        <br /> 
        <br />
        <div id="Summary" runat="server">
            <h2 id="SummaryHeader" runat="server"></h2>
        </div>
    </form>
</body>
</html>
