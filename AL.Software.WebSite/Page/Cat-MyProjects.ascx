<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cat-MyProjects.ascx.vb" Inherits="Page_MyProjects" %>
    <div class="TileGrid">
        <%
            Dim CurrentTile As Integer
            Dim Database As New DatabaseConnect()
            Database.DatabaseOpen()
            For CurrentTile = 1 To Database.GetCountRow(Config.CategoryMyProjects)
                Response.Write("<div class='TileCell'>")
                Response.Write("<a href ='./" + Config.DefaultPage + "?ShowProject=" + CurrentTile.ToString + "'>")
                Response.Write("<div>")
                Response.Write("<img src='../" + Config.PreviewFolder + "/Project0" + CurrentTile.ToString + ".jpg'>")
                Response.Write(Database.GetRecordDB(Config.CategoryMyProjects, CurrentTile, 1))
                Response.Write("</div>")
                Response.Write("</a>")
                Response.Write("</div>")
            Next CurrentTile
            Database.DatabaseClose()
        %>
    </div>
