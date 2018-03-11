Imports Microsoft.VisualBasic

Public Class Config
    Public Shared AppPath As String = AppDomain.CurrentDomain.BaseDirectory
    Public Shared DefaultPage As String = "MainPage.aspx"
    Public Shared PicturesFolder As String = "Pictures"
    Public Shared PreviewFolder As String = "Pictures/Preview"
    Public Shared ContentPhotoFolder As String = "Pictures/Content"

    Public Shared ListCategory() As String

    Public Shared CategoryTable As String = "Main"
    Public Shared CategoryMain As String = "Main"
    Public Shared CategoryMyProjects As String = "MyProjects"
    Public Shared CategoryPhotoAlbums As String = "PhotoAlbums"
    Public Shared CategoryHistory As String = "History"
    Public Shared CategoryMyNote As String = "MyNote"
    Public Shared CategoryRepairCar As String = "RepairCar"
End Class
