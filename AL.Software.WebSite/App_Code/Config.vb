Imports Microsoft.VisualBasic

Public Class Config
    Public Shared AppPath As String = AppDomain.CurrentDomain.BaseDirectory
    Public Shared ContentPage As String = "!ContentPage.aspx"
    Public Shared PictureFolder As String = "Pictures"
    Public Shared PreviewFolder As String = "Pictures/Preview"
    Public Shared PageMyProjects As String = "2"
    Public Shared PageMyPhoto As String = "4"

    Public Shared TypeContent As String = ""

    Public Shared TableCategory As String = "ListCategory"
    Public Shared CategoryMyProjects As String = "MyProjects"
    Public Shared CategoryPhotoAlbums As String = "PhotoAlbums"
    Public Shared CategoryHistory As String = "History"
    Public Shared CategoryMyNote As String = "MyNote"
    Public Shared CategoryRepairCar As String = "RepairCar"
End Class
