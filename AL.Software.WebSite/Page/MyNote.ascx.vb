Imports System.IO
Partial Class Page_MyNote
    Inherits UserControl
    Public NotesPreview As String()
    Public NotesCaption As String()

    Private Sub Page_MyNote_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Database As New DatabaseConnect()
        Dim CatName As String
        Dim Path As String
        Dim CountItem As Integer = 0
        Database.DatabaseOpen()
        CatName = Request.QueryString("category")
        CountItem = Database.GetCountItem(CatName)
        ReDim NotesPreview(CountItem)
        ReDim NotesCaption(CountItem)

        For index = 1 To CountItem
            NotesCaption(index - 1) = Database.GetItemByID(CatName, index, "Caption")
            Path = Config.AppPath + "Content" + "\" + "MyNote" + index.ToString + ".txt"
            Dim FileInfo As New FileInfo(Path)
            If FileInfo.Exists = True Then
                Using reader As New StreamReader(Path)
                    NotesPreview(index - 1) = reader.ReadToEnd()
                    NotesPreview(index - 1) = Left(NotesPreview(index - 1), 300)
                End Using
            End If
        Next
        Database.DatabaseClose()
    End Sub
End Class
