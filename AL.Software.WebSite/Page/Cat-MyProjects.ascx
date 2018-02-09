<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cat-MyProjects.ascx.vb" Inherits="Page_MyProjects" %>
    <div class="TileGrid">
        <%
            Dim CurrentTile As Integer
            Dim Database As New DatabaseConnect()
            Database.DatabaseOpen()
            For CurrentTile = 1 To Database.GetCountRow(Config.TableMyProjects)
                Response.Write("<div class='TileCell'>")
                Response.Write("<a href ='./" + Config.ContentPage + ".aspx?ShowProject=" + CurrentTile.ToString + "'>")
                Response.Write("<div>")
                Response.Write("<img src='../" + Config.PictureFolder + "/Photo/Projects/Project0" + CurrentTile.ToString + "Preview.jpg'>")
                Response.Write(Database.GetRecordDB(Config.TableMyProjects, CurrentTile, 1))
                Response.Write("</div>")
                Response.Write("</a>")
                Response.Write("</div>")
            Next CurrentTile
            Database.DatabaseClose()
        %>
    </div>
