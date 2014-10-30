<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Chat.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <asp:Label ID="LabelUser" runat="server" Text="Username:" />
        <asp:TextBox ID="TextBoxUserName" runat="server" />
        <br />
        <asp:Label ID="LabelMessage" runat="server" Text="Message:" />
        <asp:TextBox ID="TextBoxMessage" runat="server"/>
        <asp:Button ID="ButtonSend" runat="server" OnClick="ButtonSend_Click" Text="Send" />
        <br />

        <asp:UpdatePanel runat='server' ID='UpdatePanelTime' UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:ListView ID="ListViewMessages" runat="server" ItemType="Chat.Message">
                    <ItemTemplate>
                        User: <%#: Item.User %>
                        Message: <%#: Item.Text %>
                        <br />  
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500" OnTick="TimerTimeRefresh_Tick" />
    </form>
</body>
</html>
