Partial Public Class Page_Default
    Inherits Page
    Private CategoryModule As String = ""
    Private ArticleModule As String = ""
    Private PhotoModule As String = ""
    Private Database As New DatabaseConnect()
    Private CategoryName As String = ""
    Shadows ID As String = ""
    Private TableName As String = ""
    Private SiteTemplate As ASP.page_sitetemplate_master
    Private Description As String

    Private Sub Page_Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        SiteTemplate = Master
        'SiteTemplate.ErrorMessageProperty.Text = ""
        'ShowMainPage()
        Database.DatabaseOpen()
        CategoryName = Request.QueryString("category")
        ID = Request.QueryString("ID")

        'SiteTemplate.MenuFilePath = "MainMenu.ascx"
        'SiteTemplate.MenuFilePath = "Empty.ascx"
        If ID = "0" Then CategoryName = Config.CategoryMain
        If CategoryName = Nothing Then CategoryName = Config.CategoryMain
        If CategoryName = Config.CategoryMain Then SiteTemplate.SiteBodyProperty.Controls.Add(Page.LoadControl("PageMain.ascx"))
        If CInt(ID) > 0 Then ShowArticle()
        If ID = Nothing Then ShowCategory()
        CheckModule()

        Try
            'SiteTemplate.PhotoModule = PhotoModule
            'SiteTemplate.ArticleModule = ArticleModule
            'SiteTemplate.CategoryModule = CategoryModule
        Catch ex As Exception
            'SiteTemplate.ErrorMessageProperty.Text = "Такой страницы не существует"
        End Try
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        'UpdateCountView()
        '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        SiteTemplate.LnkStat = Config.DefaultPage + "?category=statistics"
        SiteTemplate.LogoPicture = "../" + Config.PicturesFolder + "/Logo/" + CategoryName + ".png"
        SiteTemplate.Page.MetaDescription = "<meta name='description' content='" + Description + "' />"
        SiteTemplate.Page.Title = Database.GetItemByName(Config.CategoryTable, CategoryName, "Caption") + " - " + Config.SiteTitle
        If CategoryName = "statistics" Then SiteTemplate.Page.Title = "Статистика"
        Database.DatabaseClose()
    End Sub
    Private Sub ShowMainPage()
        'SiteTemplate.MenuBlockProperty.Visible = False
        'SiteTemplate.ContentBlockProperty.CssClass = "ContentAllWidth"
        'SiteTemplate.CaptionProperty.Visible = False
        'SiteTemplate.ErrorMessageProperty.Visible = False
        'SiteTemplate.ImgBackgroundProperty.Visible = True

    End Sub
    Private Sub CheckModule()
        If CategoryModule = Nothing Then CategoryModule = "Empty.ascx"
        If ArticleModule = Nothing Then ArticleModule = "Empty.ascx"
        If PhotoModule = Nothing Then PhotoModule = "Empty.ascx"
    End Sub
    Private Sub ShowCategory()
        If CategoryName = "statistics" Then
            'SiteTemplate.CaptionProperty.Text = "Статистика"
            CategoryModule = "Statistics.ascx"
            Exit Sub
        End If
        CategoryModule = CategoryName + ".ascx"
        TableName = Config.CategoryTable
        Dim IsTileGrid As String = Database.GetItemByName(TableName, CategoryName, "IsTileGrid")
        If IsTileGrid = "1" Then CategoryModule = "CategoryTileGrid.ascx"
        ID = Database.GetItemByName(TableName, CategoryName, "ID")
        'SiteTemplate.CaptionProperty.Text = Database.GetItemByName(TableName, CategoryName, "Caption")
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
        'SiteTemplate.CaptionProperty.Text = Database.GetItemByID(TableName, ID, "Caption")
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
