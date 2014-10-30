<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="styles.css" type="text/css" />
    <script>
      function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }
   </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel class="center" runat="server" BackColor="gainsboro">
            <asp:TextBox id="CalcArea" onkeypress="return isNumberKey(event)" class="calcArea" runat="server"/>
        </asp:Panel>

        <asp:Panel class="center" runat="server" BackColor="gainsboro">
            <asp:Button class="buttons" id="ButtonOne" runat="server" Text="1" CommandName="1" OnCommand="OnCommand"/>
            <asp:Button class="buttons" id="ButtonTwo" runat="server" Text="2" CommandName="2" OnCommand="OnCommand"/>
            <asp:Button class="buttons" id="ButtonThree" runat="server" Text="3" CommandName="3" OnCommand="OnCommand"/>

            <asp:Button class="buttons" id="ButtonPlus" runat="server" Text="+" OnClick="ButtonPlus_Click"/>

            <asp:Button class="buttons" id="ButtonFour" runat="server" Text="4" CommandName="4" OnCommand="OnCommand"/>
            <asp:Button class="buttons" id="ButtonFive" runat="server" Text="5" CommandName="5" OnCommand="OnCommand"/>
            <asp:Button class="buttons" id="ButtonSix" runat="server" Text="6" CommandName="6" OnCommand="OnCommand"/>

            <asp:Button class="buttons" id="ButtonMinus" runat="server" Text="-" OnClick="ButtonMinus_Click"/>

            <asp:Button class="buttons" id="ButtonSeven" runat="server" Text="7" CommandName="7" OnCommand="OnCommand"/>
            <asp:Button class="buttons" id="ButtonEight" runat="server" Text="8" CommandName="8" OnCommand="OnCommand"/>
            <asp:Button class="buttons" id="ButtonNine" runat="server" Text="9" CommandName="9" OnCommand="OnCommand"/>

            <asp:Button class="buttons" id="ButtonMultiply" runat="server" Text="*" OnClick="ButtonMultiply_Click"/>

            <asp:Button class="buttons" id="ButtonClear" runat="server" Text="Clear"/>
            <asp:Button class="buttons" id="ButtonZero" runat="server" Text="0" CommandName="0" OnCommand="OnCommand"/>

            <asp:Button class="buttons" id="ButtonDevide" runat="server" Text="/" OnClick="ButtonDevide_Click"/>
            <asp:Button class="buttons" id="ButtonSqr" runat="server" Text="Sqr" OnClick="ButtonSqr_Click"/>

            <asp:Button class="buttonEqual" id="ButtonEqual" runat="server" Text="=" OnClick="ButtonEqual_Click"/>

		    <asp:Label Text="" runat="server" ID="LabelOperation" Visible="false"/>
		    <asp:Label Text="0" runat="server" ID="LabelCurrentNumber" Visible="false"/>
            <asp:Label Text="0" runat="server" ID="LabelNewNumber" Visible="false"/>
		    <asp:Label Text="false" runat="server" ID="LabelCalculate" Visible="false"/>
        </asp:Panel>
    </form>
</body>
</html>
