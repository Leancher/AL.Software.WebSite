Partial Class Page_Default
    Inherits Page
    Public PageName As String = ""
    Public Caption As String
    Public LogoPicName As String
    Public Description As String
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
        Dim ID As String = ""
        Database.DatabaseOpen()
        Try
            CategoryName = Request.QueryString("category")
            If CategoryName <> Nothing Then
                Caption = Database.GetCategoryProperty(CategoryName, "Caption")
                Description = Database.GetCategoryProperty(CategoryName, "Description")
                ID = Database.GetCategoryProperty(CategoryName, "ID")
                PageName = "Cat-" + CategoryName + ".ascx"
                Dim IsTileGrid As String = Database.GetCategoryProperty(CategoryName, "IsTileGrid")
                If IsTileGrid = "1" Then PageName = "ShowTileGrid.ascx"
            Else

                CategoryValue = Request.QueryString(Config.CategoryRepairCar)
                If CategoryValue <> Nothing Then
                    CategoryName = Config.CategoryRepairCar
                    Description = Database.GetDatabaseItem(CategoryName, CategoryValue, "Description")
                    If CInt(CategoryValue) > 9 Then DecimalPlace = ""
                    PageName = "../Content/RepairCar" + DecimalPlace + CategoryValue + ".ascx"
                End If

                CategoryValue = Request.QueryString(Config.CategoryMyProjects)
                If CategoryValue <> Nothing Then
                    CategoryName = Config.CategoryMyProjects
                    Description = Database.GetDatabaseItem(CategoryName, CategoryValue, "Description")
                    If CInt(CategoryValue) > 9 Then DecimalPlace = ""
                    PageName = "../Content/Project" + DecimalPlace + CategoryValue + ".ascx"
                End If

                CategoryValue = Request.QueryString(Config.CategoryPhotoAlbums)
                If CategoryValue <> Nothing Then
                    CategoryName = Config.CategoryPhotoAlbums
                    Description = Database.GetDatabaseItem(CategoryName, CategoryValue, "Description")
                    PageName = "ViewerPhotoAlbum.ascx"
                End If

                If Request.QueryString("ShowPhoto") <> Nothing Then
                    CategoryName = Config.CategoryPhotoAlbums
                    PageName = "ViewerCurrentPhoto.ascx"
                End If
            End If
            LogoPicName = "../" + Config.PictureFolder + "/Logo/" + CategoryName + ".png"
            If PageName = "" Then PageName = "Cat-Main.ascx"
            Content = Page.LoadControl(PageName)
        Catch ex As Exception
            Content = Page.LoadControl("Page404.ascx")
            ShowException = ex.ToString
        End Try
        Description = "<meta name='description' content='" + Description + "' />"
        ContentHolder.Controls.Add(Content)
        Database.DatabaseClose()
    End Sub
End Class
