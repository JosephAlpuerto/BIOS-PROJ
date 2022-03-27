<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="BIOSproject.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-3.5.1.min.js"></script>
    <link href="select2/select2.css" rel="stylesheet" />
    <script src="select2/select2.js"></script>

    <style>
        body
        {
            font: 11px verdana;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:DropDownList ID="DropBranch" runat="server" AutoPostBack="true" CssClass="input1" Width="200px">
                        <asp:ListItem Selected="True" Text=""></asp:ListItem>
                        </asp:DropDownList>
        </div>

        <script>
            $(document).ready(function () { $("#DropBranch").select2(); });
        </script>
    </form>
</body>
</html>
