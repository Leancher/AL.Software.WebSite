
Partial Class Page_MainPage
    Inherits System.Web.UI.UserControl

    Private Sub Page_MainPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim img1 As Image = New Image()
        img1.Visible = True
        img1.ImageUrl = "/Pictures/Noimage.jpg"
        Panel1.Controls.Add(img1)
    End Sub
End Class