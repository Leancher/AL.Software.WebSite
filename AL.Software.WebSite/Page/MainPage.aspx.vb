Partial Public Class Page_Default
    Inherits Page
    Public CategoryModule As String = ""
    Public ArticleModule As String = ""
    Public PhotoModule As String = ""
    Public Caption As String = ""
    Public LogoPicName As String = ""
    Public Description As String = ""
    Public ShowError As String = ""
    Public TitlePage As String = ""
    Private Database As New DatabaseConnect()
    Private CategoryName As String = ""
    Shadows ID As String = ""
    Private TableName As String = ""

    Private Sub Page_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Config.ShowError = ""
        Database.DatabaseOpen()
        CategoryName = Request.QueryString("category")
        ID = Request.QueryString("ID")
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
            Config.ShowError = "Такой страницы не существует"
        End Try
        UpdateCountView()
        LogoPicName = "../" + Config.PicturesFolder + "/Logo/" + CategoryName + ".png"
        Description = "<meta name='description' content='" + Description + "' />"
        TitlePage = Database.GetItemByName(Config.CategoryTable, CategoryName, "Caption")
        If CategoryName = "statistics" Then TitlePage = "Статистика"
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
        TableName = CategoryName
        ArticleModule = "../Content/" + CategoryName + ID + ".ascx"
        Dim IsPhotoAlbum As String = Database.GetItemByName(Config.CategoryTable, CategoryName, "IsPhotoAlbum")
        If IsPhotoAlbum = "1" Then
            PhotoModule = "PhotoViewer.ascx"
            ArticleModule = ""
        End If
        'If Request.QueryString("Photo") <> Nothing Then PhotoModule = "ViewerCurrentPhoto.ascx"
        Caption = Database.GetItemByID(TableName, ID, "Caption")
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
