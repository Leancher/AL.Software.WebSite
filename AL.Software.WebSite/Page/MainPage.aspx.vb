Partial Class Page_Default
    Inherits Page
    Public PageName As String = ""
    Public Caption As String = ""
    Public LogoPicName As String = ""
    Public Description As String = ""
    Public ShowException As String = ""
    Dim Database As New DatabaseConnect()
    Dim DecimalPlace As String = "0"
    Dim CategoryName As String = ""
    Dim CategoryValue As String = ""
    Dim ID As String = ""

    Private Sub Page_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadContent()
    End Sub
    Private Sub LoadContent()
        Dim Content As Control
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
                Dim index As Integer = 0
                For index = 0 To Config.ListCategory.Length - 1
                    CategoryValue = Request.QueryString(Config.ListCategory(index))
                    If CategoryValue <> Nothing Then
                        CategoryName = Config.ListCategory(index)
                        Description = Database.GetDatabaseItem(CategoryName, CategoryValue, "Description")
                        If CInt(CategoryValue) > 9 Then DecimalPlace = ""
                        Exit For
                    End If
                Next index
                If CategoryName = Config.CategoryRepairCar Then PageName = "../Content/RepairCar" + DecimalPlace + CategoryValue + ".ascx"
                If CategoryName = Config.CategoryMyProjects Then PageName = "../Content/Project" + DecimalPlace + CategoryValue + ".ascx"
                If CategoryName = Config.CategoryHistory Then PageName = "../Content/History" + DecimalPlace + CategoryValue + ".ascx"
                If CategoryName = Config.CategoryPhotoAlbums Then PageName = "ViewerPhotoAlbum.ascx"
                If Request.QueryString("ShowPhoto") <> Nothing Then
                    CategoryName = Config.CategoryPhotoAlbums
                    PageName = "ViewerCurrentPhoto.ascx"
                End If
            End If
            If PageName = "" Then ShowMainPage()
            Content = Page.LoadControl(PageName)
        Catch ex As Exception
            Content = Page.LoadControl("Page404.ascx")
            ShowException = ex.ToString
        End Try
        LogoPicName = "../" + Config.PictureFolder + "/Logo/" + CategoryName + ".png"
        Description = "<meta name='description' content='" + Description + "' />"
        ContentHolder.Controls.Add(Content)
        Database.DatabaseClose()
    End Sub
    Private Sub ShowMainPage()
        CategoryName = Config.CategoryMain
        Caption = Database.GetCategoryProperty(CategoryName, "Caption")
        Description = Database.GetCategoryProperty(CategoryName, "Description")
        PageName = "Cat-" + CategoryName + ".ascx"
    End Sub
End Class
