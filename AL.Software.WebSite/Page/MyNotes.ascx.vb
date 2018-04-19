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
        Dim NumberNote As Integer = CInt(Request.QueryString("Note"))

        If NumberNote > 0 Then
            Response.Write("<h3>" + NotesCaption(NumberNote - 1) + "</h3>")
            'Response.Write(LoadSingleNote(NumberNote))
            Exit Sub
        End If
        For index = 1 To CountItem
            Dim Paragraph As New Label()
            Paragraph.Text = Database.GetItemByID("MyNotes", index, "Caption")

            Dim lnk As New HyperLink()
            lnk.NavigateUrl = Config.DefaultPage + "?category=MyNotes&Note=" + index.ToString
            lnk.Text = "Читать дальше"

            Dim lt As New Literal With {
                .Text = "<br>"
            }
            NotesPlace.Controls.Add(Paragraph)
            NotesPlace.Controls.Add(lt)
            NotesPlace.Controls.Add(lnk)
            NotesPlace.Controls.Add(lnk)

            NotesPlace.Controls.Add(lt)
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
    'Private Function LoadPreviewNotes(NoteNumber As Integer) As String
    '    Path = Config.AppPath + "Content" + "\" + "MyNote" + NoteNumber.ToString + ".txt"
    '    Dim FileInfo As New FileInfo(Path)
    '    If FileInfo.Exists = True Then
    '        Using reader As New StreamReader(Path)
    '            Return Left(reader.ReadToEnd(), 300)
    '        End Using
    '    End If
    '    Return ""
    'End Function
    'Public Function LoadSingleNote(Number As Integer) As String
    '    Path = Config.AppPath + "Content" + "\" + "MyNote" + Number.ToString + ".txt"
    '    Dim FileInfo As New FileInfo(Path)
    '    If FileInfo.Exists = True Then
    '        Using reader As New StreamReader(Path)
    '            Return reader.ReadToEnd()
    '        End Using
    '    Else
    '        Return "Такой заметки не существует"
    '    End If
    'End Function
End Class
