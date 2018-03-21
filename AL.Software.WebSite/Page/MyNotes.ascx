<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MyNotes.ascx.vb" Inherits="Page_MyNote" %>
<div class="ContentColumn">
<%
    Dim Note As String = CInt(Request.QueryString("Note"))
    If Note > 0 Then
        Response.Write("<h3>" + NotesCaption(Note - 1) + "</h3>")
        Response.Write(LoadSingleNote(Note))
        Exit Sub
    End If
    For index = 0 To NotesPreview.Length - 1
        Response.Write("<p>")
        Response.Write("<h4>" + NotesCaption(index) + "</h4>")
        Response.Write(NotesPreview(index))
        If NotesPreview(index) <> Nothing Then
            Response.Write("</br>")
            Response.Write("<a href ='" + Config.DefaultPage + "?category=MyNotes&Note=" + (index + 1).ToString + "'>")
            Response.Write("Читать дальше")
            Response.Write("</a>")
        End If
    Next
%>
</div>