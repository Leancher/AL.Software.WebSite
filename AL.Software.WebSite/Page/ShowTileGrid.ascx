﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowTileGrid.ascx.vb" Inherits="Page_ShowTileGrid" %>
    <div class="TileGrid">
        <%
            Dim CurrentTile As Integer
            Dim Database As New DatabaseConnect()
            Dim TypeContent As String
            Dim PhotoPath As String = ""
            Dim Caption As String = ""
            Dim DecimalPlace As String = "0"
            Database.DatabaseOpen()
            TypeContent = Request.QueryString("category")

            For CurrentTile = 1 To Database.GetCountRow(TypeContent)
                If CurrentTile > 9 Then DecimalPlace = ""
                Response.Write("<div class='TileCell'>")
                Response.Write("<a href ='./" + Config.DefaultPage + "?" + TypeContent + "=" + CurrentTile.ToString + "'>")
                Response.Write("<div>")
                'Получаем полный путь для проверки наличия файла
                PhotoPath = Config.AppPath + "Pictures\Preview\" + TypeContent + DecimalPlace + CurrentTile.ToString + ".jpg"
                Dim FileInfo As New System.IO.FileInfo(PhotoPath)
                'Пока считаем, что файла не существует
                PhotoPath = "../" + Config.PictureFolder + "/Noimage.jpg"
                'Если файл существует, то делаем относительный путь к файлу, полный путь не загружает картинки
                If FileInfo.Exists = True Then PhotoPath = "../Pictures/Preview/" + TypeContent + DecimalPlace + CurrentTile.ToString + ".jpg"
                Response.Write("<img src=" + PhotoPath + " />")
                Caption = Database.GetRecordDB(TypeContent, CurrentTile, 1)
                'Если название длинное и выводится в две строки, то все сдвигается вверх. Добавляем несколько пробелов для коротких строк для приведения к одному виду
                If Len(Caption) < 40 Then Caption = Caption + "</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                Response.Write(Caption)
                Response.Write("</div>")
                Response.Write("</a>")
                Response.Write("</div>")
            Next CurrentTile
            Database.DatabaseClose()
        %>
    </div>
