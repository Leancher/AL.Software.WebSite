Partial Public Class Page_Default
    Inherits Page
    Public CategoryModule As String = ""
    Public ArticleModule As String = ""
    Public PhotoModule As String = ""
    Public Caption As String = ""
    Public LogoPicName As String = ""
    Public Description As String = ""
    Public ShowError As String = ""
    Private Database As New DatabaseConnect()
    Private CategoryName As String = ""
    Shadows ID As String = ""
    Private TableName As String = ""

    Private Sub Page_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Database.DatabaseOpen()
        CategoryName = Request.QueryString("category")
        ID = Request.QueryString("ID")
        LoadListCategory()
        MainMenuHolder.Controls.Add(Page.LoadControl("MainMenu.ascx"))
        If ID = "0" Then CategoryName = Config.CategoryMain
        If CategoryName = Nothing Then CategoryName = Config.CategoryMain
        If CInt(ID) > 0 Then ShowArticle()
        If ID = Nothing Then ShowCategory()
        CheckModule()
        Try
            PhotoPlaceHolder.Controls.Add(Page.LoadControl(PhotoModule))
            ArticlePlaceHolder.Controls.Add(Page.LoadControl(ArticleModule))
            CategoryPlaceHolder.Controls.Add(Page.LoadControl(CategoryModule))
        Catch ex As Exception
            ShowError = "Такой страницы не существует"
        End Try
        UpdateCountView()
        LogoPicName = "../" + Config.PicturesFolder + "/Logo/" + CategoryName + ".png"
        Description = "<meta name='description' content='" + Description + "' />"
        Database.DatabaseClose()
    End Sub
    Private Sub CheckModule()
        If CategoryModule = Nothing Then CategoryModule = "Empty.ascx"
        If ArticleModule = Nothing Then ArticleModule = "Empty.ascx"
        If PhotoModule = Nothing Then PhotoModule = "Empty.ascx"
    End Sub
    Private Sub ShowCategory()
        If CategoryName = "statistics" Then
            Caption = "Статистика"
            CategoryModule = "Statistics.ascx"
            Exit Sub
        End If
        CategoryModule = CategoryName + ".ascx"
        TableName = Config.CategoryTable
        Dim IsTileGrid As String = Database.GetItemByName(TableName, CategoryName, "IsTileGrid")
        If IsTileGrid = "1" Then CategoryModule = "CategoryTileGrid.ascx"
        ID = Database.GetItemByName(TableName, CategoryName, "ID")
        Caption = Database.GetItemByName(TableName, CategoryName, "Caption")
        Description = Database.GetItemByName(TableName, CategoryName, "Description")
    End Sub
    Private Sub ShowArticle()
        Dim DecimalPlace As String = "0"
        TableName = CategoryName
        If CInt(ID) > 9 Then DecimalPlace = ""
        ArticleModule = "../Content/" + CategoryName + DecimalPlace + ID + ".ascx"
        Dim IsPhotoAlbum As String = Database.GetItemByName(Config.CategoryTable, CategoryName, "IsPhotoAlbum")
        If IsPhotoAlbum = "1" Then PhotoModule = "ViewerPhotoAlbum.ascx"
        If Request.QueryString("Photo") <> Nothing Then PhotoModule = "ViewerCurrentPhoto.ascx"
        Caption = Database.GetItemByID(TableName, ID, "Caption")
        Description = Database.GetItemByID(TableName, ID, "Description")
    End Sub
    Private Sub UpdateCountView()
        If CategoryName = "statistics" Then Exit Sub
        Dim CountView As Integer = 0
        CountView = CInt(Database.GetItemByID(TableName, ID, "Viewed")) + 1
        Database.UpdateViewValue(TableName, ID, CountView.ToString)
    End Sub
    Private Sub LoadListCategory()
        Dim NumberCategory As Integer
        Dim CountItem As Integer = Database.GetCountItem(Config.CategoryTable)
        ReDim Config.ListCategory(CountItem - 1)
        For NumberCategory = 1 To CountItem
            Config.ListCategory(NumberCategory - 1) = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Name")
        Next NumberCategory
    End Sub
    Private Sub LoadContent()
        'Database.DatabaseOpen()
        'Caption = ""
        'Try
        '    If CInt(ID) > 0 Then
        '        TableName = CategoryName
        '        If CInt(ID) > 9 Then DecimalPlace = ""
        '        ArticleModule = "../Content/" + CategoryName + DecimalPlace + ID + ".ascx"
        '        Dim LoadArticle As Control
        '        Try
        '            LoadArticle = Page.LoadControl(CategoryModule)
        '        Catch ex As Exception
        '            LoadArticle = Page.LoadControl("Empty.ascx")
        '        End Try
        '        ShowArticle.Controls.Add(LoadArticle)
        '        Dim IsPhotoAlbum As String = Database.GetItemByName(Config.CategoryTable, CategoryName, "IsPhotoAlbum")
        '        If IsPhotoAlbum = "1" Then
        '            Dim LoadPhotoAlbum = Page.LoadControl("ViewerPhotoAlbum.ascx")
        '            If Request.QueryString("Photo") <> Nothing Then LoadPhotoAlbum = Page.LoadControl("ViewerCurrentPhoto.ascx")
        '            ShowPhotoAlbum.Controls.Add(LoadPhotoAlbum)
        '        End If
        '    End If
        '    If ID = "0" Or ID = Nothing Then
        '        TableName = Config.CategoryTable
        '        ID = Database.GetItemID(TableName, CategoryName)
        '        CategoryModule = CategoryName + ".ascx"
        '        Dim IsTileGrid As String = Database.GetItemByName(Config.CategoryTable, CategoryName, "IsTileGrid")
        '        If IsTileGrid = "1" Then CategoryModule = "CategoryTileGrid.ascx"

        '        Dim LoadCategory = Page.LoadControl(CategoryModule)
        '        CategoryPlaceHolder.Controls.Add(LoadCategory)
        '    End If
        '    Caption = Database.GetItemByID(TableName, ID, "Caption")

        '    Description = Database.GetItemByID(TableName, ID, "Description")

        'Catch ex As Exception
        '    ShowError = "Такой страницы не существует"
        'End Try
        'Database.DatabaseClose()

        'If CategoryName <> Nothing Then
        '    TableName = Config.CategoryTable
        '    Caption = Database.GetCategoryProperty(CategoryName, "Caption")
        '    Description = Database.GetCategoryProperty(CategoryName, "Description")
        '    ItemID = Database.GetCategoryProperty(CategoryName, "ID")
        '    PageName = "Cat-" + CategoryName + ".ascx"
        '    Dim IsTileGrid As String = Database.GetCategoryProperty(CategoryName, "IsTileGrid")
        '    If IsTileGrid = "1" Then PageName = "ShowTileGrid.ascx"
        'Else

        '    Dim index As Integer = 0
        '    For index = 0 To Config.ListCategory.Length - 1
        '        ItemID = Request.QueryString(Config.ListCategory(index))
        '        If ItemID = "0" Then
        '            TableName = Config.CategoryTable
        '            Caption = Database.GetItemByID(Config.CategoryTable, index, "Caption")
        '            Description = Database.GetItemByID(Config.CategoryTable, index, "Description")

        '        Else
        '            IsContent = True
        '            TableName = Config.ListCategory(index)
        '            CategoryName = Config.ListCategory(index)
        '            Caption = Database.GetItemByID(CategoryName, ItemID, "Caption")
        '            Description = Database.GetItemByID(CategoryName, ItemID, "Description")
        '            If CInt(ItemID) > 9 Then DecimalPlace = ""
        '            Exit For
        '        End If
        '    Next index
        '    If CategoryName = Config.CategoryRepairCar Then PageName = "../Content/RepairCar" + DecimalPlace + ItemID + ".ascx"
        '    If CategoryName = Config.CategoryMyProjects Then PageName = "../Content/Project" + DecimalPlace + ItemID + ".ascx"
        '    If CategoryName = Config.CategoryHistory Then PageName = "../Content/History" + DecimalPlace + ItemID + ".ascx"
        '    If CategoryName = Config.CategoryPhotoAlbums Then PageName = "ViewerPhotoAlbum.ascx"

        '    If Request.QueryString("ShowPhoto") <> Nothing Then
        '        CategoryName = Config.CategoryPhotoAlbums
        '        PageName = "ViewerCurrentPhoto.ascx"
        '    End If
        'End If
        'If CategoryName = "statistics" Then
        '    PageName = "Statistics.ascx"
        '    Caption = "Статистика"
        'End If
        'If PageName = "" Then ShowMainPage()
        'Try
        '    Content = Page.LoadControl(PageName)
        'Catch ex As Exception
        '    Content = Page.LoadControl("Page404.ascx")
        '    ShowException = ex.ToString
        'End Try
        'LogoPicName = "../" + Config.PicturesFolder + "/Logo/" + CategoryName + ".png"
        'Description = "<meta name='description' content='" + Description + "' />"
        'Try
        '    UpdateCountView()
        'Catch ex As Exception

        'End Try
        'ContentHolder.Controls.Add(Content)
        'Database.DatabaseClose()
    End Sub

End Class
