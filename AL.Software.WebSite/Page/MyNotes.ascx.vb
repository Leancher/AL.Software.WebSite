Imports System.IO
Partial Class Page_MyNote
    Inherits UserControl
    Public NotesPreview As String()
    Public NotesCaption As String()
    Private Path As String
    Private CountItem As Integer = 0
    Dim Database As New DatabaseConnect()
    Private Sub Page_MyNote_Load(sender As Object, e As EventArgs) Handles Me.Load
        Database.DatabaseOpen()
        CountItem = Database.GetCountItem("MyNotes")
        Dim NumberNote As Integer = CInt(Request.QueryString("Note"))
        If NumberNote > 0 Then
            LoadSingleNote(NumberNote)
            Exit Sub
        End If
        For index = 1 To CountItem
            Dim NoteCaption As New Label With {
                .Text = Database.GetItemByID("MyNotes", index, "Caption")
            }
            NoteCaption.Font.Bold = True
            NoteCaption.Font.Size = 13
            Dim NotePreview As New Label()
            NotePreview.Text = GetPreviewNotes(index)
            Dim lnk As New HyperLink With {
                .NavigateUrl = Config.DefaultPage + "?category=MyNotes&Note=" + index.ToString,
                .Text = "Показать полностью..."
            }
            lnk.Style("text-decoration") = "none"
            lnk.CssClass = "Text"
            Dim br As New Literal With {
                .Text = "<br>"
            }
            Dim p As New Literal With {
                .Text = "<p>"
            }
            NotesPlace.Controls.Add(p)
            NotesPlace.Controls.Add(NoteCaption)
            NotesPlace.Controls.Add(br)
            NotesPlace.Controls.Add(NotePreview)
            NotesPlace.Controls.Add(lnk)

            'Response.Write("<p>")
            'Response.Write("<h4>" + NotesCaption(index) + "</h4>")
            'Response.Write(NotesPreview(index))
            'If NotesPreview(index) <> Nothing Then
            '    Response.Write("</br>")
            '    Response.Write("<a href ='" + Config.DefaultPage + "?category=MyNotes&Note=" + (index + 1).ToString + "'>")
            '    Response.Write("Читать дальше")
            '    Response.Write("</a>")
            'End If
        Next

        'ReDim NotesPreview(CountItem)
        'ReDim NotesCaption(CountItem)
        'LoadPreviewNotes()
        Database.DatabaseClose()
    End Sub
    Private Function GetPreviewNotes(NoteNumber As Integer) As String
        Path = Config.AppPath + "Content" + "\" + "MyNote" + NoteNumber.ToString + ".txt"
        Dim FileInfo As New FileInfo(Path)
        If FileInfo.Exists = True Then
            Using reader As New StreamReader(Path)
                Return Left(reader.ReadToEnd(), 300) + "&nbsp;&nbsp;&nbsp;"
            End Using
        End If
        Return ""
    End Function
    Private Sub LoadSingleNote(NoteNumber As Integer)
        Dim NoteCaption As New Label With {
            .Text = Database.GetItemByID("MyNotes", NoteNumber, "Caption")
        }
        NoteCaption.Font.Bold = True
        NoteCaption.Font.Size = 16
        Dim Note As New Label()
        Path = Config.AppPath + "Content" + "\" + "MyNote" + NoteNumber.ToString + ".txt"
        Dim FileInfo As New FileInfo(Path)
        If FileInfo.Exists = True Then
            Using reader As New StreamReader(Path)
                Note.Text = reader.ReadToEnd()
            End Using
        Else
            Note.Text = "Такой заметки не существует"
        End If
        Dim p As New Literal With {
                .Text = "<p>"
            }
        NotesPlace.Controls.Add(NoteCaption)
        NotesPlace.Controls.Add(p)
        NotesPlace.Controls.Add(Note)
    End Sub
End Class
