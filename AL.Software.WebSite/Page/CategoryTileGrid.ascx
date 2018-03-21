﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CategoryTileGrid.ascx.vb" Inherits="Page_ShowTileGrid" %>
<div class="TileGrid">
    <%
        Dim CurrentTile As Integer
        Dim Database As New DatabaseConnect()
        Dim CatName As String
        Dim PhotoPath As String = ""
        Dim Caption As String = ""
        Database.DatabaseOpen()
        CatName = Request.QueryString("category")
        For CurrentTile = 1 To Database.GetCountItem(CatName)
            Response.Write("<div class='TileCell'>")
            Response.Write("<a href ='" + Config.DefaultPage + "?category=" + CatName + "&ID=" + CurrentTile.ToString + "'>")
            'Получаем полный путь для проверки наличия файла
            PhotoPath = Config.AppPath + "Pictures\Preview\" + CatName + CurrentTile.ToString + ".jpg"
            Dim FileInfo As New System.IO.FileInfo(PhotoPath)
            'Пока считаем, что файла не существует
            PhotoPath = "../" + Config.PicturesFolder + "/Noimage.jpg"
            'Если файл существует, то делаем относительный путь к файлу, полный путь не загружает картинки
            If FileInfo.Exists = True Then PhotoPath = "../Pictures/Preview/" + CatName + CurrentTile.ToString + ".jpg"
            Response.Write("<div class='TileCellPic'>")
            Response.Write("<img src=" + PhotoPath + ">")
            Response.Write("</div>")
            Caption = Database.GetItemByID(CatName, CurrentTile, "Caption")
            'Если название длинное и выводится в две строки, то все сдвигается вверх. Добавляем несколько пробелов для коротких строк для приведения к одному виду
            If Len(Caption) < 40 Then Caption = Caption + "</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
            Response.Write("<div class='TileCellCaption'>")
            Response.Write(Caption)
            Response.Write("</div>")
            Response.Write("</a>")
            Response.Write("</div>")
        Next CurrentTile
        Database.DatabaseClose()
    %>
</div>
