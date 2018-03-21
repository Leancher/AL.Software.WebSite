<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewerCurrentPhoto.ascx.vb" Inherits="Page_ViewerCurrentPhoto" %>
<%
    Dim DecimalPlace As String = "0"
    If CInt(Album) > 9 Then DecimalPlace = ""
    Dim PathPhoto As String = "<img class='CurrentPhoto' src='../Pictures/" + Request.QueryString("category") + "/Album" + DecimalPlace + Album + "/" + Photo + "' />"
    Response.Write(PathPhoto)
%>
<%--<div>
    <img class="CurrentPhoto" src ="../Pictures/MyPhoto/Album01/photo01.JPG" />
</div>--%>