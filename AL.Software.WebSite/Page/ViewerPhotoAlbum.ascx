<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewerPhotoAlbum.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
    <div class="PhotoGrid">
    <%
        Try
            For Each CurrentPhoto In ListPhoto
                Response.Write("<div class='PhotoCell'>")

                Response.Write("<a href ='./" + Config.DefaultPage + "?category=" + CategoryAlbum + "&ID=" + NumberAlbum + "&Photo=" + CurrentPhoto + "'>")

                Response.Write("<div>")
                Response.Write("<img src='../Pictures/" + CategoryAlbum + "/album0" + NumberAlbum + "Preview/" + CurrentPhoto + "' />")
                Response.Write("</div>")

                Response.Write("</a>")

                Response.Write("</div>")
            Next
        Catch ex As Exception
        End Try
        If IsNothing(ListPhoto) = True Then Config.ShowError = "Такого альбома не существует"
        If ListPhoto.Length = 0 Then Config.ShowError = "В этом альбоме нет фотографий"
    %>
</div> 