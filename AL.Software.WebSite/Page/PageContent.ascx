<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PageContent.ascx.vb" Inherits="Page_ContentPage" %>
<asp:Panel runat="server" CssClass="MainMenuLocate">
    <div class="MenuList">
        <asp:PlaceHolder ID="MenuBlock" runat="server" /> 
    </div>
</asp:Panel>
<asp:Panel id="ContentBlock" class="ContentRegularWidth" runat="server" >
    <asp:Label class="ContentCaption" runat="server" id="Caption" Text=""/>
    <asp:PlaceHolder ID="CategoryBlock" runat="server" />
    <div class="ContentColumn">     
        <asp:PlaceHolder ID="ArticleBlock" runat="server" /> 
    </div>
    <asp:PlaceHolder ID="PhotoBlock" runat="server" />
    <asp:Label runat="server" id="ErrorMessage" Text=""/>
</asp:Panel>