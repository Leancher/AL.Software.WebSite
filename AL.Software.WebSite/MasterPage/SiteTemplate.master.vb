Partial Class SiteTemplate
    Inherits MasterPage

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

