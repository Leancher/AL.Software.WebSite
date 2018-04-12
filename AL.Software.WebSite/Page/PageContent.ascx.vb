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
        MenuBlock.Controls.Add(Page.LoadControl("Page/MainMenu.ascx"))
        ErrorMessage.Text = ""
        Database.DatabaseOpen()
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
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'UpdateCountView()
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
            PhotoModule =Config.PageFolder + "PhotoViewer.ascx"
            ArticleModule = ""
        End If
        Caption.Text = Database.GetItemByID(TableName, ID, "Caption")
        Description = Database.GetItemByID(TableName, ID, "Description")
    End Sub
    Private Sub UpdateCountView()
        If CategoryName = "statistics" Then Exit Sub
        If Request.QueryString("Note") <> Nothing Then
            ID = Request.QueryString("Note")
            TableName = "MyNotes"
        End If
        Dim CountView As Integer = 0
        CountView = CInt(Database.GetItemByID(TableName, ID, "Viewed")) + 1
        Database.UpdateViewValue(TableName, ID, CountView.ToString)
    End Sub
End Class
