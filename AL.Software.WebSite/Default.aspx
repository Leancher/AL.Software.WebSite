<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%
    Dim Link As String
    Link = Request.Url.GetLeftPart(UriPartial.Authority) + "\Page\" + Config.DefaultPage + "?category=main"
    Response.Redirect(Link)
%>