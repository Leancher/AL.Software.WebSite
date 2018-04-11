<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PageContent.ascx.vb" Inherits="Page_ContentPage" %>
<asp:Panel ID="MenuBlock" runat="server" CssClass="MainMenuLocate">
    <div class="MenuList">
        <asp:PlaceHolder ID="MainMenuHolder" runat="server" /> 
    </div>
</asp:Panel>
<asp:Panel id="ContentBlock" class="ContentRegularWidth" runat="server" >
    <asp:Label class="ContentCaption" runat="server" id="TextCaption" Text=""/>
    <asp:PlaceHolder ID="CategoryHolder" runat="server" />
    <div class="ContentColumn">     
        <asp:PlaceHolder ID="ArticleHolder" runat="server" /> 
    </div>
    <asp:PlaceHolder ID="PhotoHolder" runat="server" />
    <asp:Label runat="server" id="ErrorMessage" Text=""/>
</asp:Panel>