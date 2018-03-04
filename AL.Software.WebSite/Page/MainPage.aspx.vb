Partial Public Class Page_Default
    Inherits Page
    Public PageName As String = ""
    Public Caption As String = ""
    Public LogoPicName As String = ""
    Public Description As String = ""
    Public ShowException As String = ""
    Public IsContent As Boolean = False
    Private Database As New DatabaseConnect()
    Private DecimalPlace As String = "0"
    Private CategoryName As String = ""
    Private TableName As String = ""
    Private ItemID As String = ""
    Private Content As Control
    Private Sub Page_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadListCategory()
        Content = Page.LoadControl("MainMenu.ascx")
        MainMenuHolder.Controls.Add(Content)
        LoadContent()
    End Sub
    Private Sub LoadListCategory()
        Dim CountItem As Integer
        Dim NumberCategory As Integer
        Database.DatabaseOpen()
        CountItem = Database.GetCountItem(Config.CategoryTable)
        ReDim Config.ListCategory(CountItem - 1)
        For NumberCategory = 1 To CountItem
            Config.ListCategory(NumberCategory - 1) = Database.GetDatabaseItem(Config.CategoryTable, NumberCategory, "Name")
        Next NumberCategory
        Database.DatabaseClose()
    End Sub

    Private Sub LoadContent()
        Database.DatabaseOpen()
        Caption = ""
        IsContent = False
        CategoryName = Request.QueryString("category")
        If CategoryName <> Nothing Then
            TableName = Config.CategoryTable
            Caption = Database.GetCategoryProperty(CategoryName, "Caption")
            Description = Database.GetCategoryProperty(CategoryName, "Description")
            ItemID = Database.GetCategoryProperty(CategoryName, "ID")
            PageName = "Cat-" + CategoryName + ".ascx"
            Dim IsTileGrid As String = Database.GetCategoryProperty(CategoryName, "IsTileGrid")
            If IsTileGrid = "1" Then PageName = "ShowTileGrid.ascx"
        Else

            Dim index As Integer = 0
            For index = 0 To Config.ListCategory.Length - 1
                ItemID = Request.QueryString(Config.ListCategory(index))
                If ItemID <> Nothing Then
                    IsContent = True
                    TableName = Config.ListCategory(index)
                    CategoryName = Config.ListCategory(index)
                    Caption = Database.GetDatabaseItem(CategoryName, ItemID, "Caption")
                    Description = Database.GetDatabaseItem(CategoryName, ItemID, "Description")
                    If CInt(ItemID) > 9 Then DecimalPlace = ""
                    Exit For
                End If
            Next index
            If CategoryName = Config.CategoryRepairCar Then PageName = "../Content/RepairCar" + DecimalPlace + ItemID + ".ascx"
            If CategoryName = Config.CategoryMyProjects Then PageName = "../Content/Project" + DecimalPlace + ItemID + ".ascx"
            If CategoryName = Config.CategoryHistory Then PageName = "../Content/History" + DecimalPlace + ItemID + ".ascx"
            If CategoryName = Config.CategoryPhotoAlbums Then PageName = "ViewerPhotoAlbum.ascx"

            If Request.QueryString("ShowPhoto") <> Nothing Then
                CategoryName = Config.CategoryPhotoAlbums
                PageName = "ViewerCurrentPhoto.ascx"
            End If
        End If
        If PageName = "" Then ShowMainPage()

        Try
            Content = Page.LoadControl(PageName)
        Catch ex As Exception
            Content = Page.LoadControl("Page404.ascx")
            ShowException = ex.ToString
        End Try
        LogoPicName = "../" + Config.PicturesFolder + "/Logo/" + CategoryName + ".png"
        Description = "<meta name='description' content='" + Description + "' />"
        Try
            UpdateCountView()
        Catch ex As Exception

        End Try
        ContentHolder.Controls.Add(Content)
        Database.DatabaseClose()
    End Sub
    Private Sub UpdateCountView()
        Dim CountView As Integer = 0
        CountView = CInt(Database.GetDatabaseItem(TableName, ItemID, "Viewed")) + 1
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
