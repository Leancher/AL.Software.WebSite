<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MainMenu.ascx.vb" Inherits="MainMenu" %>
<%
    Dim CurrentCategory As Integer
    Dim Database As New DatabaseConnect()
    Database.DatabaseOpen()
    For CurrentCategory = 1 To Database.GetCountRow(Config.TableCategory)
        Response.Write("<a href ='./" + Config.DefaultPage + "?category=" + CurrentCategory.ToString + "'>")
        Response.Write(Database.GetRecordDB(Config.TableCategory, CurrentCategory, 1))
        Response.Write("</a>")
    Next CurrentCategory
    Database.DatabaseClose()
%>