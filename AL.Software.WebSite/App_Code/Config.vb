﻿Imports Microsoft.VisualBasic

Public Class Config
    Public Shared WebPath As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority)
    Public Shared SiteName As String = "myleancher.ru"
    Public Shared AppPath As String = AppDomain.CurrentDomain.BaseDirectory

    Public Shared DefaultPage As String = WebPath + "/Page/MainPage.aspx"
    Public Shared PicturesFolder As String = "Pictures"
    Public Shared PreviewFolder As String = "Pictures/Preview"
    Public Shared ContentPhotoFolder As String = "Pictures/Content"
    Public Shared ShowError As String = ""
    Public Shared CategoryTable As String = "Main"
    Public Shared CategoryMain As String = "Main"
    Public Shared SiteTitle As String = "Leancher web site"
End Class
