<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PageMain.ascx.vb" Inherits="Page_MainPage" %>
<asp:Image runat="server" ImageUrl="~/Pictures/background.jpg" Width="100%" ID="ImgBackground" />

<asp:Panel runat="server" CssClass="TileGrid">
<%
    Dim NumberCategory As Integer
    Dim Database As New DatabaseConnect()
    Dim Category As String
    Dim PhotoPath As String = ""
    Dim Caption As String = ""
    Database.DatabaseOpen()
    Dim CountItem As Integer = Database.GetCountItem(Config.CategoryTable)
    For NumberCategory = 2 To CountItem
        Category = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Name")
        Response.Write("<div class='TileCell'>")
        Response.Write("<a href ='" + Config.DefaultPage + "?category=" + Category + "'>")
        'Получаем полный путь для проверки наличия файла
        PhotoPath = Config.AppPath + "Pictures\Preview\" + Category + NumberCategory.ToString + ".jpg"
        Dim FileInfo As New System.IO.FileInfo(PhotoPath)
        'Пока считаем, что файла не существует
        PhotoPath = "../" + Config.PicturesFolder + "/Noimage.jpg"
        'Если файл существует, то делаем относительный путь к файлу, полный путь не загружает картинки
        If FileInfo.Exists = True Then PhotoPath = "../Pictures/Preview/" + Category + NumberCategory.ToString + ".jpg"
        Response.Write("<div class='TileCellPic'>")
        Response.Write("<img src=" + PhotoPath + ">")
        Response.Write("</div>")
        Caption = Database.GetItemByID(Config.CategoryTable, NumberCategory, "Caption")
        'Если название длинное и выводится в две строки, то все сдвигается вверх. Добавляем несколько пробелов для коротких строк для приведения к одному виду
        If Len(Caption) < 40 Then Caption = Caption + "</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
        Response.Write("<div class='TileCellCaption'>")
        Response.Write(Caption)
        Response.Write("</div>")
        Response.Write("</a>")
        Response.Write("</div>")
    Next NumberCategory
    Database.DatabaseClose()
%>
</asp:Panel>