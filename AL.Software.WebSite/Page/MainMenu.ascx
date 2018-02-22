<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MainMenu.ascx.vb" Inherits="Page_MainMenu" %>
<%
    Dim NumberCategory As Integer
    Dim CurrentCategory As String
    Dim Database As New DatabaseConnect()
    Dim WebPath As String
    Dim CountItem As Integer
    WebPath = Request.Url.GetLeftPart(UriPartial.Authority)
    Database.DatabaseOpen()
    CountItem = Database.GetCountItem(Config.TableCategory)
    ReDim Config.ListCategory(CountItem - 1)
    For NumberCategory = 1 To CountItem
        CurrentCategory = Database.GetDatabaseItem(Config.TableCategory, NumberCategory, "Name")
        Config.ListCategory(NumberCategory - 1) = CurrentCategory
        Response.Write("<a href ='" + WebPath + "\Page\" + Config.DefaultPage + "?category=" + CurrentCategory + "'>")
        Response.Write(Database.GetDatabaseItem(Config.TableCategory, NumberCategory, "Caption"))
        Response.Write("</a>")
    Next NumberCategory
    Database.DatabaseClose()
%>
