<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MainMenu.ascx.vb" Inherits="Page_MainMenu" %>
<%
    Dim NumberCategory As Integer
    Dim Database As New DatabaseConnect()
    Dim Category As String = ""
    Database.DatabaseOpen()
    Dim CountItem As Integer = Database.GetCountItem(Config.CategoryTable)
    For NumberCategory = 1 To CountItem
        Category = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Name")
        Response.Write("<a href ='" + Config.DefaultPage + "?category=" + Category + "'>")
        Response.Write(Database.GetItemByID(Config.CategoryTable, NumberCategory, "Caption"))
        Response.Write("</a>")
    Next NumberCategory
    Database.DatabaseClose()
%>