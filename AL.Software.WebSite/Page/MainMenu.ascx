<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MainMenu.ascx.vb" Inherits="Page_MainMenu" %>
<%
    Dim NumberCategory As Integer
    Dim Database As New DatabaseConnect()
    Dim WebPath As String = Request.Url.GetLeftPart(UriPartial.Authority)
    Database.DatabaseOpen()
    For NumberCategory = 1 To Config.ListCategory.Length
        Response.Write("<a href ='" + WebPath + "\Page\" + Config.DefaultPage + "?category=" + Config.ListCategory(NumberCategory - 1) + "&ID=0'>")
        Response.Write(Database.GetItemByID(Config.CategoryTable, NumberCategory, "Caption"))
        Response.Write("</a>")
    Next NumberCategory
    Database.DatabaseClose()
%>