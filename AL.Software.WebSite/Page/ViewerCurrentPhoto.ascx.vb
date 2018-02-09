
Partial Class Page_ViewerCurrentPhoto
    Inherits System.Web.UI.UserControl
    Public Photo As String
    Public Album As String
    Private Sub Page_ViewerCurrentPhoto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Album = Request.QueryString("AlbumName")
        Photo = Request.QueryString("ShowPhoto")
    End Sub
End Class
