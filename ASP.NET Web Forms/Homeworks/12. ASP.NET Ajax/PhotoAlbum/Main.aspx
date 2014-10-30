<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="PhotoAlbum.Main" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web gallery</title>
    <script src="libs/jquery-1.10.1.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
</head>
<body>
    <form id="main" runat="server">
        <div class="well">
            <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

            <asp:Image ID="img" runat="server" Height="500" class="Image" />

            <ajaxToolkit:SlideShowExtender ID="Image1_SlideShowExtender" runat="server"
                Enabled="True" ImageDescriptionLabelID="txtDesc"
                SlideShowServiceMethod="GetSlides" AutoPlay="false"
                NextButtonID="btnNext" PreviousButtonID="btnPrev"
                TargetControlID="img">
            </ajaxToolkit:SlideShowExtender>
            <br />

            <div id="Controls" class="text-center">
                <asp:Button ID="btnPrev" runat="server" Text="Previous" CssClass="btn btn-primary" />
                <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary"/>
            </div>
        </div>
    </form>

    <script src="scripts/zoom.js"></script>
</body>
</html>
