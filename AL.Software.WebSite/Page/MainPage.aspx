<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MainPage.aspx.vb" Inherits="Page_Default" %>

<asp:Content id="Content0" ContentPlaceHolderID ="MetaDescription" runat="server">
    <% Response.Write(Description) %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogoPlaceHolder" Runat="Server">
    <% Response.Write("<img src='" + LogoPicName + "' />") %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID ="Statistics" runat ="server" >
    <%  
        Dim WebPath As String
        WebPath = Request.Url.GetLeftPart(UriPartial.Authority)
        Response.Write("<a href ='" + WebPath + "\Page\" + Config.DefaultPage + "?category=statistics'>")
        Response.Write("Статистика")
        Response.Write("</a>")
    %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" Runat="Server">
    <div class="MainMenuLocate">
        <div id="MainMenu">
            <asp:PlaceHolder ID="MainMenuHolder" runat="server" /> 
        </div>
    </div>
    <div class="ContentLocate">
        <div class="ContentCaption">
            <% Response.Write(Caption) %>
        </div>
        <% Response.Write(ShowError) %>
        <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" />

        <div class="ContentColumn">     
            <asp:PlaceHolder ID="ArticlePlaceHolder" runat="server" /> 
        </div>

        <asp:PlaceHolder ID="PhotoPlaceHolder" runat="server" /> 
    </div> 
</asp:Content>