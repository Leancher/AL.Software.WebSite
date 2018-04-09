Partial Class SiteTemplate
    Inherits MasterPage
    Public Property Caption As String
        Get
            Return TextCaption.Text
        End Get
        Set(value As String)
            TextCaption.Text = value
        End Set
    End Property
    Public Property ShowError As String
        Get
            Return LbError.Text
        End Get
        Set(value As String)
            LbError.Text = value
        End Set
    End Property
    Public Property PhotoModule As String
        Get
            Return PhotoHolder.Controls.ToString
        End Get
        Set(value As String)
            PhotoHolder.Controls.Add(Page.LoadControl(value))
        End Set
    End Property
    Public Property ArticleModule As String
        Get
            Return ArticleHolder.Controls.ToString
        End Get
        Set(value As String)
            ArticleHolder.Controls.Add(Page.LoadControl(value))
        End Set
    End Property
    Public Property CategoryModule As String
        Get
            Return CategoryHolder.Controls.ToString
        End Get
        Set(value As String)
            CategoryHolder.Controls.Add(Page.LoadControl(value))
        End Set
    End Property
    Public Property MainMenuModule As String
        Get
            Return MainMenuHolder.Controls.ToString
        End Get
        Set(value As String)
            MainMenuHolder.Controls.Add(Page.LoadControl(value))
        End Set
    End Property
    Public Property LnkStat As String
        Get
            Return lbStat.NavigateUrl
        End Get
        Set(value As String)
            lbStat.NavigateUrl = value
        End Set
    End Property
    Public Property LogoPicture As String
        Get
            Return LogoPic.ImageUrl
        End Get
        Set(value As String)
            LogoPic.ImageUrl = value
        End Set
    End Property
End Class

