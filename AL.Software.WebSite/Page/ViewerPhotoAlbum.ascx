<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewerPhotoAlbum.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
    <div class="PhotoGrid">
    <%
        For Each CurrentPhoto In ListPhoto
            Response.Write("<div class='PhotoCell'>")

            Response.Write("<a href ='./" + Config.ContentPage + ".aspx?ShowPhoto=" + CurrentPhoto + "&AlbumName=album0" + NumberAlbum + "'>")

            Response.Write("<div>")
            Response.Write("<img src='../Pictures/Photo/album0" + NumberAlbum + "Preview/" + CurrentPhoto + "' />")
            Response.Write("</div>")

            Response.Write("</a>")

            Response.Write("</div>")
        Next
    %>
</div> 