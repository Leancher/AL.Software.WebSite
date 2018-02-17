Partial Class Page_Default
    Inherits Page
    Public PageName As String
    Public CategoryCaption As String
    Public LogoPicName As String
    Public PageDescription As String
    Public ShowException As String
    '1 - Main
    '2 - MyProjects
    '3 - RepairCar
    '4 - MyPhoto
    '5 - History
    '6 - MyNote
    Private Sub Page_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Content As Control
        Dim Database As New DatabaseConnect()
        Dim DecimalPlace As String = "0"
        Dim CategoryName As String
        Dim CategoryValue As String
        Database.DatabaseOpen()
        Try
            PageName = Request.QueryString("category")
            If PageName <> Nothing Then
                CategoryCaption = Database.GetCategoryValue(PageName, 1)
                PageDescription = Database.GetDescriptionPage(Config.TableCategory, PageName)
                LogoPicName = "../" + Config.PictureFolder + "/Logo/" + PageName + ".png"
                Dim IsTileGrid As String = Database.GetCategoryValue(PageName, 2)
                PageName = "Cat-" + PageName + ".ascx"
                If IsTileGrid = "1" Then PageName = "ShowTileGrid.ascx"
            Else
                CategoryName = Config.CategoryRepairCar
                CategoryValue = Request.QueryString(Config.CategoryRepairCar)
                If CategoryValue <> Nothing Then
                    PageDescription = Database.GetDescriptionPage(CategoryName, CategoryValue)
                    If CInt(CategoryValue) > 9 Then DecimalPlace = ""
                    PageName = "../Content/RepairCar" + DecimalPlace + CategoryValue + ".ascx"
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
            ShowException = ex.ToString
        End Try
        PageDescription = "<meta name='description' content='" + PageDescription + "' />"
        ContentHolder.Controls.Add(Content)
        Database.DatabaseClose()
    End Sub
End Class
