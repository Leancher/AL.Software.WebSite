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
            If Request.QueryString("category") <> Nothing Then
                Dim NumberCategory = CInt(Request.QueryString("category"))

                CategoryCaption = Database.GetRecordDB(Config.TableCategory, NumberCategory, 1)
                PageName = Database.GetRecordDB(Config.TableCategory, NumberCategory, 2)
                PageDescription = Database.GetDescriptionPage(Config.TableCategory, NumberCategory)
                LogoPicName = "../" + Config.PictureFolder + "/Logo-" + PageName + ".png"
                PageName = "Cat-" + PageName + ".ascx"
                Config.TypeContent = ""
                If NumberCategory = 2 Then Config.TypeContent = "project"
                If NumberCategory = 3 Then Config.TypeContent = "repaircar"
                If NumberCategory = 4 Then Config.TypeContent = "PhotoAlbum"
                If Config.TypeContent <> "" Then PageName = "ShowTileGrid.ascx"
            Else
                If Request.QueryString("ShowProject") <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(Config.TableMyProjects, Request.QueryString("ShowProject"))
                    PageName = "Sub-Project0" + Request.QueryString("ShowProject") + ".ascx"
                End If
                If Request.QueryString("PhotoAlbum") <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(Config.TableAlbumPhoto, Request.QueryString("PhotoAlbum"))
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