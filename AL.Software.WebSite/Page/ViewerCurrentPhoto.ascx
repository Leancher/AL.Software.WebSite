<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewerCurrentPhoto.ascx.vb" Inherits="Page_ViewerCurrentPhoto" %>

<%
    Dim PathPhoto As String = "<img class='CurrentPhoto' src='../Pictures/Photo/" + Album + "/" + Photo + "' />"
    Response.Write(PathPhoto)
%>
