<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewerCurrentPhoto.ascx.vb" Inherits="Page_ViewerCurrentPhoto" %>
<%
    Dim DecimalPlace As String = "0"
    If CInt(Album) > 9 Then DecimalPlace = ""
    Dim PathPhoto As String = "<img class='CurrentPhoto' src='../Pictures/Photo/Album" + DecimalPlace + Album + "/" + Photo + "' />"
    Response.Write(PathPhoto)
%>