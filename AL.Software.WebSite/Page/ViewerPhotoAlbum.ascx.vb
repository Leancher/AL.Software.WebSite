
Partial Class Page_ViewerPhotoAlbum
    Inherits UserControl
    Public ListPhoto As String()
    Public NumberAlbum As String
    Private Sub Page_ViewerPhotoAlbum_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Index As Integer = 0
        Dim LenNameFile As Integer
        NumberAlbum = Request.QueryString("ShowAlbum")
        Dim Path As String = Config.AppPath + "Pictures\Photo\album0" + NumberAlbum + "Preview"
        Try
            ListPhoto = IO.Directory.GetFiles(Path)
            'Удаление полного пути к рисункам, рисунок с полным путем не загружается
            For Each CurrentPhoto In ListPhoto
                LenNameFile = Len(ListPhoto(Index)) - Len(Path) - 1
                ListPhoto(Index) = Right(CurrentPhoto, LenNameFile)
                Index = Index + 1
            Next
        Catch ex As Exception

        End Try
        Index = 0
    End Sub
End Class
