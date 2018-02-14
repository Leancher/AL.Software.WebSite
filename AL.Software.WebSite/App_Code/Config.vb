Imports Microsoft.VisualBasic

Public Class Config
    Public Shared AppPath As String = AppDomain.CurrentDomain.BaseDirectory
    Public Shared ContentPage As String = "!ContentPage.aspx"
    Public Shared PictureFolder As String = "Pictures"
    Public Shared PreviewFolder As String = "Pictures/Preview"
    Public Shared PageMyProjects As String = "2"
    Public Shared PageMyPhoto As String = "4"

    Public Shared TypeContent As String = ""

    Public Shared TableMyProjects As String = "MyProjects"
    Public Shared TableCategory As String = "ListCategory"
    Public Shared TableAlbumPhoto As String = "PhotoAlbums"
    Public Shared TableHistory As String = "History"
    Public Shared TableMyNote As String = "MyNote"
    Public Shared TableRepairCar As String = "RepairCar"
End Class
