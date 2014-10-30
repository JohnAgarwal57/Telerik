<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="FileUpload.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/kendo.common.min.css" rel="stylesheet" />
    <link href="Styles/kendo.default.min.css" rel="stylesheet" />
    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/kendo.web.min.js"></script>
</head>
<body>
    <input name="uploaded" id="uploaded" type="file" runat="server" />

    <script>
        $(document).ready(function () {
            $("#uploaded").kendoUpload({
                async: {
                    saveUrl: "Upload",
                    removeUrl: "Remove",
                    autoUpload: true,
                }
            });
        });
    </script>
</body>
</html>