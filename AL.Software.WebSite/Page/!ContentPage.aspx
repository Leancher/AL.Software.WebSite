<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="!ContentPage.aspx.vb" Inherits="Page_ContentPage" %>

<asp:Content id="Content0" ContentPlaceHolderID ="MetaDescription" runat="server">
    <% Response.Write(PageDescription) %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogoPlaceHolder" Runat="Server">
    <% Response.Write("<img src='" + LogoPicName + "' />") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" Runat="Server">
    <div class="CategoryCaption">
        <% Response.Write(CategoryCaption) %>
    </div>
    <% Response.Write(ShowExceprion) %>
   <%-- <img class="CurrentPhoto" src="../Pictures/Photo/Album01/photo05.JPG" />--%>
    <asp:PlaceHolder ID="ContentHolder" runat="server" />
</asp:Content>