<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoViewer.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
<asp:PlaceHolder ID ="TableHolder1" runat ="server" />
<asp:Label ID="lab1" runat="server"/>
<div style ="display:flex">
    <div style="display: flex;align-items:center;height:75vh;width:50px">
        <asp:Button ID="BtPrev" Text="<" Font-Size="30px" runat ="server" Height="150px"/>
    </div>
    <div style="margin:auto">
    <%
        If NumberPhoto <> Nothing Then
            Response.Write("<div class='CurrentPhoto'>")
            Dim DecimalPlace As String = "0"
            If NumberAlbum.Length > 1 Then DecimalPlace = ""
            Dim Path = "../Pictures/" + CategoryAlbum + "/Album" + DecimalPlace + NumberAlbum + "/" + ListPhoto(CInt(NumberPhoto))
            Response.Write("<img src='" + Path + "'/>")

            Response.Write("</div>")
        Else
            Response.Write("<div class='PhotoGrid'>")
            Try
                Dim Index As Integer = 0
                For Each CurrentPhoto In ListPhoto
                    Response.Write("<div class='PhotoCell'>")

                    Response.Write("<a href='" + Config.DefaultPage + "?category=" + CategoryAlbum + "&ID=" + NumberAlbum + "&Photo=" + Index.ToString + "'>")

                    Response.Write("<div>")
                    Response.Write("<img src='../Pictures/" + CategoryAlbum + "/album0" + NumberAlbum + "Preview/" + CurrentPhoto + "'/>")
                    Response.Write("</div>")

                    Response.Write("</a>")

                    Response.Write("</div>")
                    Index = Index + 1
                Next
            Catch ex As Exception
                If IsNothing(ListPhoto) = True Then Config.ShowError = "Такого альбома не существует"
                Exit Sub
            End Try
            If ListPhoto.Length = 0 Then Config.ShowError = "В этом альбоме нет фотографий"
            Response.Write("</div>")
        End If
    %>
    </div>
    <div style="margin-left:auto; display: flex;align-items:center;height:75vh;width:50px ">
        <asp:Button  ID="BtNext" Text=">" Font-Size="30px" runat ="server" Height="150px"/>
    </div>
</div>