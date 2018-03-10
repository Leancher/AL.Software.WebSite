<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Statistics.ascx.vb" Inherits="Page_Statistics" %>

<%
    Dim Database As New DatabaseConnect()
    Dim CountCategory As Integer
    Dim CountItemCategory As Integer
    Dim CountView As String
    Dim StatStr As String = ""
    Dim Caption As String = ""
    Database.DatabaseOpen()
    CountCategory = Database.GetCountItem(Config.CategoryTable)
    For NumberCategory = 1 To CountCategory
        CountView = Database.GetDatabaseItem(Config.CategoryTable, NumberCategory, "Viewed")
        If CountView <> "0" Then
            Caption = Database.GetDatabaseItem(Config.CategoryTable, NumberCategory, "Caption")
            StatStr = Caption + " - " + CountView
            Response.Write(StatStr)
            Response.Write("</br>")
        End If
    Next NumberCategory
    For NumberCategory = 1 To CountCategory
        CountItemCategory = Database.GetCountItem(Config.ListCategory(NumberCategory - 1))
        Dim NumberItem As Integer
        For NumberItem = 1 To CountItemCategory
            CountView = Database.GetDatabaseItem(Config.ListCategory(NumberCategory - 1), NumberItem, "Viewed")
            If CountView <> "0" Then
                Caption = Database.GetDatabaseItem(Config.ListCategory(NumberCategory - 1), NumberItem, "Caption")
                StatStr = Caption + " - " + CountView
                Response.Write(StatStr)
                Response.Write("</br>")
            End If
        Next NumberItem
    Next NumberCategory
    If StatStr = "" Then Response.Write("Нет просмотров")
    Database.DatabaseClose()
%>
