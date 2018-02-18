<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MainMenu.ascx.vb" Inherits="MainMenu" %>
<%
    Dim CurrentCategory As Integer
    Dim Database As New DatabaseConnect()
    Dim WebPath As String
    WebPath = Request.Url.GetLeftPart(UriPartial.Authority)
    Database.DatabaseOpen()
    For CurrentCategory = 1 To Database.GetCountRow(Config.TableCategory)
        Response.Write("<a href ='" + WebPath + "\Page\" + Config.DefaultPage + "?category=" + Database.GetDatabaseItem(Config.TableCategory, CurrentCategory, "Name") + "'>")
        Response.Write(Database.GetDatabaseItem(Config.TableCategory, CurrentCategory, "Caption"))
        Response.Write("</a>")
    Next CurrentCategory
    Database.DatabaseClose()
%>