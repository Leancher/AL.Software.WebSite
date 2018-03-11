Partial Public Class Page_Default
    Inherits Page
    Public PageName As String = ""
    Public Caption As String = ""
    Public LogoPicName As String = ""
    Public Description As String = ""
    Public ShowException As String = ""
    Public ShowError As String = ""
    Private Database As New DatabaseConnect()
    Private DecimalPlace As String = "0"
    Private CategoryName As String = ""
    Private TableName As String = ""
    Private ItemID As String = ""
    Shadows ID As String = ""

    Private Sub Page_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadListCategory()
        Dim LoadMenu = Page.LoadControl("MainMenu.ascx")
        MainMenuHolder.Controls.Add(LoadMenu)
        LoadContent()
    End Sub
    Private Sub LoadListCategory()
        Dim NumberCategory As Integer
        Database.DatabaseOpen()
        Dim CountItem As Integer = Database.GetCountItem(Config.CategoryTable)
        ReDim Config.ListCategory(CountItem - 1)
        For NumberCategory = 1 To CountItem
            Config.ListCategory(NumberCategory - 1) = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Name")
        Next NumberCategory
        Database.DatabaseClose()
    End Sub

    Private Sub LoadContent()
        Database.DatabaseOpen()
        Caption = ""
        CategoryName = Request.QueryString("category")
        ID = Request.QueryString("ID")
        If CategoryName = Nothing Then
            CategoryName = Config.CategoryMain
            ID = "0"
        End If
        Try
            If ID <> "0" And ID <> Nothing Then
                TableName = CategoryName
                If CInt(ID) > 9 Then DecimalPlace = ""
                PageName = "../Content/" + CategoryName + DecimalPlace + ID + ".ascx"
                Dim LoadArticle As Control
                Try
                    LoadArticle = Page.LoadControl(PageName)
                Catch ex As Exception
                    LoadArticle = Page.LoadControl("Empty.ascx")
                End Try
                ShowArticle.Controls.Add(LoadArticle)
                Dim IsPhotoAlbum As String = Database.GetItemByName(Config.CategoryTable, CategoryName, "IsPhotoAlbum")
                If IsPhotoAlbum = "1" Then
                    Dim LoadPhotoAlbum = Page.LoadControl("ViewerPhotoAlbum.ascx")
                    If Request.QueryString("Photo") <> Nothing Then LoadPhotoAlbum = Page.LoadControl("ViewerCurrentPhoto.ascx")
                    ShowPhotoAlbum.Controls.Add(LoadPhotoAlbum)
                End If
            End If
            If ID = "0" Then
                TableName = Config.CategoryTable
                ID = Database.GetItemID(TableName, CategoryName)
                PageName = CategoryName + ".ascx"
                Dim IsTileGrid As String = Database.GetItemByID(TableName, ID, "IsTileGrid")
                If IsTileGrid = "1" Then PageName = "CategoryTileGrid.ascx"
                Dim LoadCategory = Page.LoadControl(PageName)
                ShowCategory.Controls.Add(LoadCategory)
            End If
            Caption = Database.GetItemByID(TableName, ID, "Caption")
            LogoPicName = "../" + Config.PicturesFolder + "/Logo/" + CategoryName + ".png"
            Description = Database.GetItemByID(TableName, ID, "Description")
            Description = "<meta name='description' content='" + Description + "' />"
        Catch ex As Exception
            ShowError = "Такой страницы не существует"
        End Try
        Database.DatabaseClose()

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
    Private Sub UpdateCountView()
        Dim CountView As Integer = 0
        CountView = CInt(Database.GetItemByID(TableName, ItemID, "Viewed")) + 1
        Database.UpdateViewValue(TableName, ItemID, CountView.ToString)
    End Sub
    Private Sub ShowMainPage()
        CategoryName = Config.CategoryMain
        TableName = Config.CategoryTable
        Caption = Database.GetCategoryProperty(CategoryName, "Caption")
        Description = Database.GetCategoryProperty(CategoryName, "Description")
        ItemID = Database.GetCategoryProperty(CategoryName, "ID")
        PageName = "Cat-" + CategoryName + ".ascx"
        UpdateCountView()
    End Sub
End Class
