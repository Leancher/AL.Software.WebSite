Partial Class _Default
    Inherits Page
    Private Database As New DatabaseConnect()
    Private CategoryName As String = ""
    Private Description As String
    Private TableName As String = ""

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Database.DatabaseOpen()
        CategoryName = Request.QueryString("category")
        If CategoryName = Nothing Then CategoryName = Config.CategoryMain
        If CategoryName = Config.CategoryMain Then SiteBody.Controls.Add(Page.LoadControl("Page/PageMain.ascx"))
        lbStat.NavigateUrl = Config.DefaultPage + "?category=statistics"
        LogoPic.ImageUrl = "../" + Config.PicturesFolder + "/Logo/" + CategoryName + ".png"
        TableName = Config.CategoryTable
        Description = Database.GetItemByName(TableName, CategoryName, "Description")
        Page.MetaDescription = "<meta name='description' content='" + Description + "' />"
        Page.Title = Database.GetItemByName(Config.CategoryTable, CategoryName, "Caption") + " - " + Config.SiteTitle
        If CategoryName = "statistics" Then Page.Title = "Статистика"
        Database.DatabaseClose()
    End Sub
End Class
