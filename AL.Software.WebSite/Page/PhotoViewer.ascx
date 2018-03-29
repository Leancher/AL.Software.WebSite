<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoViewer.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
    <%
        Dim Photo = Request.QueryString("Photo")
        If Photo <> Nothing Then
            Response.Write("<div class='CurrentPhoto'>")
            Dim DecimalPlace As String = "0"
            If NumberAlbum.Length > 1 Then DecimalPlace = ""
            Dim Path = "../Pictures/" + CategoryAlbum + "/Album" + DecimalPlace + NumberAlbum + "/" + Photo
            Response.Write("<img src='" + Path + "'/>")

            Response.Write("</div>")
        Else
            Response.Write("<div class='PhotoGrid'>")
            Try
                For Each CurrentPhoto In ListPhoto
                    Response.Write("<div class='PhotoCell'>")

                    Response.Write("<a href='" + Config.DefaultPage + "?category=" + CategoryAlbum + "&ID=" + NumberAlbum + "&Photo=" + CurrentPhoto + "'>")

                    Response.Write("<div>")
                    Response.Write("<img src='../Pictures/" + CategoryAlbum + "/album0" + NumberAlbum + "Preview/" + CurrentPhoto + "'/>")
                    Response.Write("</div>")

                    Response.Write("</a>")

                    Response.Write("</div>")
                Next
            Catch ex As Exception
                If IsNothing(ListPhoto) = True Then Config.ShowError = "Такого альбома не существует"
                Exit Sub
            End Try
            If ListPhoto.Length = 0 Then Config.ShowError = "В этом альбоме нет фотографий"
            Response.Write("</div>")
        End If
    %>