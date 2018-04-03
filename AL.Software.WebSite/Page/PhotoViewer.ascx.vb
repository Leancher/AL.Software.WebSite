
Partial Class Page_ViewerPhotoAlbum
    Inherits UserControl
    Public ListPhoto As String()
    Public NumberAlbum As String
    Public CategoryAlbum As String
    Public NumberPhoto As String
    Public CodeString As String
    Private Sub Page_ViewerPhotoAlbum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Index As Integer = 0
        NumberPhoto = Request.QueryString("Photo")
        NumberAlbum = Request.QueryString("ID")
        CategoryAlbum = Request.QueryString("category")
        Dim Path As String = Config.AppPath + "Pictures\" + CategoryAlbum + "\Album0" + NumberAlbum + "Preview"
        Try
            ListPhoto = IO.Directory.GetFiles(Path)
            'Удаление полного пути к рисункам, рисунок с полным путем не загружается
            For Each CurrentPhoto In ListPhoto
                Dim FileInfo As New System.IO.FileInfo(Path)
                ListPhoto(Index) = IO.Path.GetFileName(CurrentPhoto)
                Index = Index + 1
            Next
        Catch ex As Exception

        End Try
        Index = 0
    End Sub
    Private Sub ShowSinglePhoto()
        GalleryPlace.Visible = False
        SinglePhotoPlace.Visible = True
        Dim DecimalPlace As String = "0"
        If NumberAlbum.Length > 1 Then DecimalPlace = ""
        'Dim Path = "../Pictures/" + CategoryAlbum + "/Album" + DecimalPlace + NumberAlbum + "/" + ListPhoto(CInt(NumberPhoto))
        'SinglePhotoPlace.ImageUrl = Path
    End Sub
    Private Sub ShowGallery()
        GalleryPlace.Visible = True
        SinglePhotoPlace.Visible = False
        CodeString = "<div class='PhotoGrid'>"
        Try
            Dim Index As Integer = 0
            For Each CurrentPhoto In ListPhoto
                CodeString = CodeString + "<div class='PhotoCell'>"

                CodeString = CodeString + "<a href='" + Config.DefaultPage + "?category=" + CategoryAlbum + "&ID=" + NumberAlbum + "&Photo=" + Index.ToString + "'>"

                CodeString = CodeString + "<div>"
                CodeString = CodeString + "<img src='../Pictures/" + CategoryAlbum + "/album0" + NumberAlbum + "Preview/" + CurrentPhoto + "'/>"
                CodeString = CodeString + "</div>"

                CodeString = CodeString + "</a>"

                CodeString = CodeString + "</div>"
                Index = Index + 1
            Next
            CodeString = CodeString + "</div>"
        Catch ex As Exception
            If IsNothing(ListPhoto) = True Then CodeString = "Такого альбома не существует"
            Exit Sub
        End Try
        If ListPhoto.Length = 0 Then CodeString = "В этом альбоме нет фотографий"
        'GalleryPlace.Text = CodeString
    End Sub
    Protected Sub BtPrev_Click(sender As Object, e As EventArgs)
        NumberPhoto = (CInt(NumberPhoto) - 1).ToString
        'ShowSinglePhoto()
    End Sub
End Class
