<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Statistics.ascx.vb" Inherits="Page_Statistics" %>
<%
    Dim Database As New DatabaseConnect()
    Dim CountItem As Integer
    Dim CountView As String
    Dim StatStr As String = ""
    Database.DatabaseOpen()
    CountItem = Database.GetCountItem(Config.CategoryTable)
    For NumberCategory = 1 To CountItem
        CountView = Database.GetDatabaseItem(Config.CategoryTable, NumberCategory, "Viewed")
        If CountView <> "0" Then
            StatStr = Config.ListCategory(NumberCategory - 1) + " - " + CountView
            Response.Write(StatStr)
        End If
    Next NumberCategory
    If StatStr = "" Then Response.Write("Нет просмотров")
    Database.DatabaseClose()
%>
