<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>   
    <link rel="stylesheet" href="../Style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="HeaderTitle">
                <a href ="Default.aspx">
                    <asp:Image ID="LogoPic" runat="server" />
                    LEANCHER 
                </a>
            </div>
            <div style="margin-left:auto;margin-right:18px">
                <asp:HyperLink id="lbStat" runat="server" CssClass ="HeaderMenu" Text="Статистика" />
            </div>          
        </div>
        <div class="Body">
            <asp:PlaceHolder runat="server" ID="SiteBody" />
        </div>
    </form>
</body>
</html>