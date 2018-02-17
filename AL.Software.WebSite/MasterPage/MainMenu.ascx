<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MainMenu.ascx.vb" Inherits="MainMenu" %>
<%
    Dim CurrentCategory As Integer
    Dim Database As New DatabaseConnect()
    Database.DatabaseOpen()
    For CurrentCategory = 1 To Database.GetCountRow(Config.TableCategory)
        Response.Write("<a href ='./" + Config.DefaultPage + "?category=" + Database.GetMenuItem(2, CurrentCategory) + "'>")
        Response.Write(Database.GetMenuItem(1, CurrentCategory))
        Response.Write("</a>")
    Next CurrentCategory
    Database.DatabaseClose()
%>