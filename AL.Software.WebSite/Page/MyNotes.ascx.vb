Imports System.IO
Partial Class Page_MyNote
    Inherits UserControl
    Public NotesPreview As String()
    Public NotesCaption As String()
    Private Path As String
    Private CountItem As Integer = 0
    Private Sub Page_MyNote_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim Database As New DatabaseConnect()
        Database.DatabaseOpen()
        CountItem = Database.GetCountItem("MyNotes")
        ReDim NotesPreview(CountItem)
        ReDim NotesCaption(CountItem)
        For index = 1 To CountItem
            NotesCaption(index - 1) = Database.GetItemByID("MyNotes", index, "Caption")
        Next
        LoadPreviewNotes()
        Database.DatabaseClose()
    End Sub
    Private Sub LoadPreviewNotes()
        For index = 1 To CountItem
            Path = Config.AppPath + "Content" + "\" + "MyNote" + index.ToString + ".txt"
            Dim FileInfo As New FileInfo(Path)
            If FileInfo.Exists = True Then
                Using reader As New StreamReader(Path)
                    NotesPreview(index - 1) = Left(reader.ReadToEnd(), 300)
                End Using
            End If
        Next
    End Sub
    Public Function LoadSingleNote(Number As Integer) As String
        Path = Config.AppPath + "Content" + "\" + "MyNote" + Number.ToString + ".txt"
        Dim FileInfo As New FileInfo(Path)
        If FileInfo.Exists = True Then
            Using reader As New StreamReader(Path)
                Return reader.ReadToEnd()
            End Using
        Else
            Return "Такой заметки не существует"
        End If
    End Function
End Class
