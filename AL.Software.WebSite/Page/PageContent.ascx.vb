Partial Class Page_ContentPage
    Inherits UserControl
    Private CategoryModule As String = ""
    Private ArticleModule As String = ""
    Private PhotoModule As String = ""
    Private Database As New DatabaseConnect()
    Private CategoryName As String = ""
    Shadows ID As String = ""
    Private TableName As String = ""
    Private Description As String
    Private Sub Page_ContentPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        ErrorMessage.Text = ""
        Database.DatabaseOpen()
        SetMenu()
        CategoryName = Request.QueryString("category")
        ID = Request.QueryString("ID")
        If CInt(ID) > 0 Then ShowArticle()
        If ID = Nothing Then ShowCategory()
        CheckModule()
        Try
            PhotoBlock.Controls.Add(Page.LoadControl(PhotoModule))
            ArticleBlock.Controls.Add(Page.LoadControl(ArticleModule))
            CategoryBlock.Controls.Add(Page.LoadControl(CategoryModule))
        Catch ex As Exception
            ErrorMessage.Text = "Такой страницы не существует"
        End Try
        Database.DatabaseClose()
    End Sub
    Private Sub CheckModule()
        If CategoryModule = Nothing Then CategoryModule = Config.PageFolder + "Empty.ascx"
        If ArticleModule = Nothing Then ArticleModule = Config.PageFolder + "Empty.ascx"
        If PhotoModule = Nothing Then PhotoModule = Config.PageFolder + "Empty.ascx"
    End Sub
    Private Sub ShowCategory()
        If CategoryName = "statistics" Then
            Caption.Text = "Статистика"
            CategoryModule = Config.PageFolder + "Statistics.ascx"
            Exit Sub
        End If
        CategoryModule = Config.PageFolder + CategoryName + ".ascx"
        TableName = Config.CategoryTable
        Dim IsTileGrid As String = Database.GetItemByName(TableName, CategoryName, "IsTileGrid")
        If IsTileGrid = "1" Then CategoryModule = Config.PageFolder + "CategoryTileGrid.ascx"
        ID = Database.GetItemByName(TableName, CategoryName, "ID")
        Caption.Text = Database.GetItemByName(TableName, CategoryName, "Caption")
        Description = Database.GetItemByName(TableName, CategoryName, "Description")
    End Sub
    Private Sub ShowArticle()
        TableName = CategoryName
        ArticleModule = "Content/" + CategoryName + ID + ".ascx"
        Dim IsPhotoAlbum As String = Database.GetItemByName(Config.CategoryTable, CategoryName, "IsPhotoAlbum")
        If IsPhotoAlbum = "1" Then
            PhotoModule = Config.PageFolder + "PhotoViewer.ascx"
            ArticleModule = ""
        End If
        Caption.Text = Database.GetItemByID(TableName, ID, "Caption")
        Description = Database.GetItemByID(TableName, ID, "Description")
    End Sub
    Private Sub SetMenu()
        Dim Category As String
        For NumberCategory = 1 To Database.GetCountItem(Config.CategoryTable)
            Dim ItemLink As New HyperLink()
            Category = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Name")
            ItemLink.NavigateUrl = Config.DefaultPage + "?category=" + Category
            ItemLink.Text = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Caption")
            MenuBlock.Controls.Add(ItemLink)
        Next NumberCategory
    End Sub
End Class
