Partial Class SiteTemplate
    Inherits MasterPage
    'Public Property ContentBlockProperty As Panel
    '    Get
    '        Return ContentBlock
    '    End Get
    '    Set(value As Panel)
    '        ContentBlock = value
    '    End Set
    'End Property
    'Public Property MenuBlockProperty As Panel
    '    Get
    '        Return MenuBlock
    '    End Get
    '    Set(value As Panel)
    '        MenuBlock = value
    '    End Set
    'End Property
    'Public Property CaptionProperty As Label
    '    Get
    '        Return TextCaption
    '    End Get
    '    Set(value As Label)
    '        TextCaption = value
    '    End Set
    'End Property
    'Public Property ImgBackgroundProperty As Image
    '    Get
    '        Return ImgBackground
    '    End Get
    '    Set(value As Image)
    '        ImgBackground = value
    '    End Set
    'End Property
    'Public Property ErrorMessageProperty As Label
    '    Get
    '        Return ErrorMessage
    '    End Get
    '    Set(value As Label)
    '        ErrorMessage = value
    '    End Set
    'End Property
    'Public Property PhotoModule As String
    '    Get
    '        Return PhotoHolder.Controls.ToString
    '    End Get
    '    Set(value As String)
    '        PhotoHolder.Controls.Add(Page.LoadControl(value))
    '    End Set
    'End Property
    'Public Property ArticleModule As String
    '    Get
    '        Return ArticleHolder.Controls.ToString
    '    End Get
    '    Set(value As String)
    '        ArticleHolder.Controls.Add(Page.LoadControl(value))
    '    End Set
    'End Property
    'Public Property CategoryModule As String
    '    Get
    '        Return CategoryHolder.Controls.ToString
    '    End Get
    '    Set(value As String)
    '        CategoryHolder.Controls.Add(Page.LoadControl(value))
    '    End Set
    'End Property
    'Public Property MenuFilePath As String
    '    Get
    '        Return MainMenuHolder.Controls.ToString
    '    End Get
    '    Set(value As String)
    '        MainMenuHolder.Controls.Add(Page.LoadControl(value))
    '    End Set
    'End Property
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
    Public Property SiteBodyProperty As PlaceHolder
        Get
            Return SiteBody
        End Get
        Set(value As PlaceHolder)
            SiteBody = value
        End Set
    End Property
End Class