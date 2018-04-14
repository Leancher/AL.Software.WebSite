Partial Class Page_GetPhotos
    Inherits Page

    Private Sub Page_GetPhotos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Command = Request.QueryString("Command")
        Dim NumberPhoto = Request.QueryString("Photo")
        Dim NumberAlbum = Request.QueryString("Album")
        Dim CategoryAlbum = Request.QueryString("Category")
        Dim ResponseString As String = ""
        If Command = "ListPhoto" Then
            Dim Index As Integer = 0
            Dim Path As String = Config.AppPath + "Pictures\" + CategoryAlbum + "\Album" + NumberAlbum + "Preview"
            Try
                Dim ListPhoto As String() = IO.Directory.GetFiles(Path)
                'Удаление полного пути к рисункам, рисунок с полным путем не загружается
                For Each CurrentPhoto In ListPhoto
                    Dim FileInfo As New System.IO.FileInfo(Path)
                    ListPhoto(Index) = IO.Path.GetFileName(CurrentPhoto)
                    ResponseString = ResponseString + ";" + ListPhoto(Index)
                    Index = Index + 1
                Next
                ResponseString = Right(ResponseString, ResponseString.Length - 1)
            Catch ex As Exception

            End Try
            Index = 0
            Response.Write(ResponseString)
        End If
    End Sub
End Class
