<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MainPage.aspx.vb" Inherits="Page_Default" %>

<asp:Content id="Content0" ContentPlaceHolderID ="MetaDescription" runat="server">
    <% Response.Write(Description) %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogoPlaceHolder" Runat="Server">
    <% Response.Write("<img src='" + LogoPicName + "' />") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" Runat="Server">
    <div class="CategoryCaption">
        <% Response.Write(Caption)

            %>
    </div>
    <%      Dim Database As New DatabaseConnect()
        Database.DatabaseOpen()
        'Database.UpdateDB()
        Response.Write(Database.RecordDB)
        Response.Write(Database.GetCategoryProperty("MyProjects", "Name"))
        Database.DatabaseClose()
        %>
    <asp:PlaceHolder ID="ContentHolder" runat="server" />
</asp:Content>