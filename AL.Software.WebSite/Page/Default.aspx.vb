Partial Class Page_Default

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
                If NumberCategory = 2 Then Config.TypeContent = Config.CategoryMyProjects
                If NumberCategory = 3 Then Config.TypeContent = Config.CategoryRepairCar
                If NumberCategory = 4 Then Config.TypeContent = Config.CategoryPhotoAlbums
                If Config.TypeContent <> "" Then PageName = "ShowTileGrid.ascx"
            Else
                Dim DecimalPlace As String = "0"
                If Request.QueryString(Config.CategoryRepairCar) <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(Config.CategoryRepairCar, Request.QueryString(Config.CategoryRepairCar))

                    If CInt(Request.QueryString(Config.CategoryRepairCar)) > 9 Then DecimalPlace = ""
                    PageName = "../Content/RepairCar" + DecimalPlace + Request.QueryString(Config.CategoryRepairCar) + ".ascx"
                End If
                If Request.QueryString(Config.CategoryMyProjects) <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(Config.CategoryMyProjects, Request.QueryString(Config.CategoryMyProjects))
                    PageName = "../Content/Project0" + Request.QueryString(Config.CategoryMyProjects) + ".ascx"
                End If
                If Request.QueryString(Config.CategoryPhotoAlbums) <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(Config.CategoryPhotoAlbums, Request.QueryString(Config.CategoryPhotoAlbums))
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
