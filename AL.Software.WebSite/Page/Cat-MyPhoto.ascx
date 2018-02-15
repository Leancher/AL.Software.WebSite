<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cat-MyPhoto.ascx.vb" Inherits="Page_04_MyPhoto" %>
    <div class="TileGrid">
        <%
            Dim CurrentTile As Integer
            Dim TypeContent As String = "ShowAlbum"
            Dim Database As New DatabaseConnect()
            Database.DatabaseOpen()
            For CurrentTile = 1 To Database.GetCountRow(Config.CategoryPhotoAlbums)
                Response.Write("<div class='TileCell'>")
                Response.Write("<a href ='./" + Config.DefaultPage + "?" + TypeContent + "=" + CurrentTile.ToString + "'>")

                Response.Write("<div>")
                Response.Write("<img src='../" + Config.PreviewFolder + "/album0" + CurrentTile.ToString + ".jpg' />")
                Response.Write(Database.GetRecordDB(Config.CategoryPhotoAlbums, CurrentTile, 1))
                Response.Write("</div>")

                Response.Write("</a>")
                Response.Write("</div>")
            Next CurrentTile
            Database.DatabaseClose()
        %>
    </div>