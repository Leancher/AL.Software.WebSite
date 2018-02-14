<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowTileGrid.ascx.vb" Inherits="Page_ShowTileGrid" %>
    <div class="TileGrid">
        <%
            Dim CurrentTile As Integer
            Dim Database As New DatabaseConnect()
            Dim PhotoPath As String = ""

            Database.DatabaseOpen()
            For CurrentTile = 1 To Database.GetCountRow(Config.TypeContent)
                Response.Write("<div class='TileCell'>")
                Response.Write("<a href ='./" + Config.ContentPage + "?" + Config.TypeContent + "=" + CurrentTile.ToString + "'>")

                Response.Write("<div>")

                'Получаем полный путь для проверки наличия файла
                PhotoPath = Config.AppPath + "Pictures\Preview\" + Config.TypeContent + "0" + CurrentTile.ToString + ".jpg"
                Dim FileInfo As New System.IO.FileInfo(PhotoPath)
                'Пока считаем, что файла не существует
                PhotoPath = "../" + Config.PictureFolder + "/Noimage.jpg"
                'Если файл существует, то делаем относительный путь к файлу, полный путь не загружает картинки
                If FileInfo.Exists = True Then PhotoPath = "../Pictures/Preview/" + Config.TypeContent + "0" + CurrentTile.ToString + ".jpg"

                Response.Write("<img src=" + PhotoPath + " />")
                Response.Write(Database.GetRecordDB(Config.TypeContent, CurrentTile, 1))
                Response.Write("</div>")

                Response.Write("</a>")
                Response.Write("</div>")
            Next CurrentTile
            Database.DatabaseClose()
        %>
    </div>
