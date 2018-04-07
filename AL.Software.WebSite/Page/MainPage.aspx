<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MainPage.aspx.vb" Inherits="Page_Default" %>

<asp:Content id="Content4" ContentPlaceHolderID ="SiteTitle" runat="server">
    <% Response.Write(TitlePage + " - " + Config.SiteTitle) %>
</asp:Content>

<asp:Content id="Content0" ContentPlaceHolderID ="MetaDescription" runat="server">
    <% Response.Write(Description) %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogoPlaceHolder" Runat="Server">
    <asp:Image ID="LogoPic" runat ="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID ="Statistics" runat ="server" >
    <asp:HyperLink id="Stat" runat="server" CssClass ="Text" Text="Статистика" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" Runat="Server">
    <div class="MainMenuLocate">
        <div class="MainMenu">
            
            <asp:PlaceHolder ID="MainMenuHolder" runat="server" /> 
        </div>
    </div>
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