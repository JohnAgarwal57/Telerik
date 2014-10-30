<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Mobile.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-theme.min.css" />
    <link href="css/site.css" rel="stylesheet" type="text/css" />
    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/bootstrap/bootstrap.min.js"></script>
</head>
<body>
    <div class="well">
        <form id="form1" class="form-horizontal" runat="server">
            <fieldset>
                <div class="form-group">
                    <asp:Label for="DropDownListProducer" class="col-md-2 control-label" runat="server" Text="Producer:"/>
                    <div class="col-md-10">
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListProducer" OnSelectedIndexChanged="DropDownListCategory_SelectedIndexChanged" AutoPostBack="true" DataTextField="Name" DataValueField="Name">
                            <asp:ListItem>all</asp:ListItem>   
                        </asp:DropDownList>
                    </div> 
                </div>  
                <div class="form-group">
                    <asp:Label for="DropDownListModel" class="col-md-2 control-label" runat="server" Text="Model:"/>
                    <div class="col-md-10">
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListModel">
                            <asp:ListItem>all</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div> 
                <div class="form-group">
                    <asp:Label for="CheckBoxListExtras" class="col-md-2 control-label" runat="server" Text="Extras:"/>
                    <div class="col-md-10 checkbox">
                        <asp:CheckBoxList id="CheckBoxListExtras" runat="server" DataTextField="Name" DataValueField="Name"/>
                    </div> 
                </div> 
                <div class="form-group">
                    <asp:Label for="RadioButtonListEngine" class="col-md-2 control-label" runat="server" Text="Engine:"/>
                    <div class="col-md-10 radio">
                        <asp:RadioButtonList id="RadioButtonListEngine" runat="server"/>
                    </div>
                </div> 
                <div class="pull-right">
                    <asp:Button id="ButtonSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
                </div>
            </fieldset>
        </form>
    </div>

    <div class="well">
        <asp:Literal id="Summary" runat="server" />
    </div>
</body>
</html>
