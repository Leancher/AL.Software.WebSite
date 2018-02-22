<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MainMenu.ascx.vb" Inherits="Page_MainMenu" %>
<%
    Dim NumberCategory As Integer
    Dim CurrentCategory As String
    Dim Database As New DatabaseConnect()
    Dim WebPath As String
    WebPath = Request.Url.GetLeftPart(UriPartial.Authority)
    Database.DatabaseOpen()
    For NumberCategory = 1 To Config.ListCategory.Length
        CurrentCategory = Config.ListCategory(NumberCategory - 1)
        Response.Write("<a href ='" + WebPath + "\Page\" + Config.DefaultPage + "?category=" + CurrentCategory + "'>")
        Response.Write(Database.GetDatabaseItem(Config.TableCategory, NumberCategory, "Caption"))
        Response.Write("</a>")
    Next NumberCategory
    Database.DatabaseClose()
%>
