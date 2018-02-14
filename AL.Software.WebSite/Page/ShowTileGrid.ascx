<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowTileGrid.ascx.vb" Inherits="Page_ShowTileGrid" %>
    <div class="TileGrid">
        <%
            Dim CurrentTile As Integer
            Dim Database As New DatabaseConnect()
            Database.DatabaseOpen()
            For CurrentTile = 1 To Database.GetCountRow(Config.TableAlbumPhoto)
                Response.Write("<div class='TileCell'>")
                Response.Write("<a href ='./" + Config.ContentPage + "?" + Config.TypeContent + "=" + CurrentTile.ToString + "'>")

                Response.Write("<div>")
                Response.Write("<img src='../" + Config.PreviewFolder + "/" + Config.TypeContent + "0" + CurrentTile.ToString + ".jpg' />")
                Response.Write(Database.GetRecordDB(Config.TableAlbumPhoto, CurrentTile, 1))
                Response.Write("</div>")

                Response.Write("</a>")
                Response.Write("</div>")
            Next CurrentTile
            Database.DatabaseClose()
        %>
    </div>
