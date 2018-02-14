
Partial Class Page_ViewerPhotoAlbum
    Inherits UserControl
    Public ListPhoto As String()
    Public NumberAlbum As String
    Private Sub Page_ViewerPhotoAlbum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Index As Integer = 0
        NumberAlbum = Request.QueryString("PhotoAlbum")
        Dim Path As String = Config.AppPath + "Pictures\Photo\Album0" + NumberAlbum + "Preview"
        Try
            ListPhoto = IO.Directory.GetFiles(Path)
            'Удаление полного пути к рисункам, рисунок с полным путем не загружается
            For Each CurrentPhoto In ListPhoto
                ListPhoto(Index) = IO.Path.GetFileName(CurrentPhoto)
                Index = Index + 1
            Next
        Catch ex As Exception

        End Try
        Index = 0
    End Sub
End Class
