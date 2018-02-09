Partial Class Page_ContentPage
    Inherits Page
    Public PageName As String
    Public CategoryCaption As String
    Public LogoPicName As String
    Public PageDescription As String
    Public ShowExceprion As String
    '1 - Main
    '2 - MyProjects
    '3 - RepairCar
    '4 - MyPhoto
    '5 - History
    '6 - MyNote
    Private Sub Page_ContentPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Content As Control
        Dim Database As New DatabaseConnect()
        Database.DatabaseOpen()
        Try
            If Request.QueryString("NumberPage") <> Nothing Then
                Dim NumberPage = CInt(Request.QueryString("NumberPage"))

                CategoryCaption = Database.GetRecordDB(Config.TableCategory, NumberPage, 1)
                PageName = Database.GetRecordDB(Config.TableCategory, NumberPage, 2)
                PageDescription = Database.GetDescriptionPage(Config.TableCategory, NumberPage)
                LogoPicName = "../" + Config.PictureFolder + "/Logo-" + PageName + ".png"
                PageName = "Cat-" + PageName + ".ascx"
            Else
                If Request.QueryString("ShowProject") <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(Config.TableMyProjects, Request.QueryString("ShowProject"))
                    PageName = "Sub-Project0" + Request.QueryString("ShowProject") + ".ascx"
                End If
                If Request.QueryString("ShowAlbum") <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(Config.TableAlbumPhoto, Request.QueryString("ShowAlbum"))
                    PageName = "ViewerPhotoAlbum.ascx"
                End If
                If Request.QueryString("ShowPhoto") <> Nothing Then PageName = "ViewerCurrentPhoto.ascx"
            End If
            Content = Page.LoadControl(PageName)
        Catch ex As Exception
            Content = Page.LoadControl("Page404.ascx")
            ShowExceprion = ex.ToString
        End Try
        PageDescription = "<meta name='description' content='" + PageDescription + "' />"
        ContentHolder.Controls.Add(Content)
        Database.DatabaseClose()
    End Sub
End Class