<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MyNote.ascx.vb" Inherits="Page_MyNote" %>
<div class="ContentColumn">
<%
    For index = 0 To NotesPreview.Length - 1
        Response.Write("<p>")
        Response.Write("<h4>" + NotesCaption(index) + "</h4>")
        'Response.Write("</br></br>")
        Response.Write(NotesPreview(index))
        If NotesPreview(index) <> Nothing Then
            Response.Write("</br>")
            Response.Write("<a href ='" + Config.WebPath + "\Page\" + Config.DefaultPage + "?category=MyNote&Note=" + (index + 1).ToString + "'>")
            Response.Write("Читать дальше")
            Response.Write("</a>")
        End If
    Next

%>
</div>