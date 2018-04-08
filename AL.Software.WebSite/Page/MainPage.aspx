<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/SiteTemplate.master" AutoEventWireup="false" CodeFile="MainPage.aspx.vb" Inherits="Page_Default" %>
<%@ MasterType VirtualPath="~/MasterPage/SiteTemplate.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" Runat="Server">
    <div class="ContentLocate">
        <label class="ContentCaption" runat="server" id="Caption"></label> 
        <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" />

        <div class="ContentColumn">     
            <asp:PlaceHolder ID="ArticlePlaceHolder" runat="server" /> 
        </div>

        <asp:PlaceHolder ID="PhotoPlaceHolder" runat="server" />
        <% Response.Write(Config.ShowError) %>
    </div> 
</asp:Content>