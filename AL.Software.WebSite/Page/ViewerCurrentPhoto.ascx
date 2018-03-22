<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewerCurrentPhoto.ascx.vb" Inherits="Page_ViewerCurrentPhoto" %>
<%
    Dim DecimalPlace As String = "0"
    If CInt(Album) > 9 Then DecimalPlace = ""
    Dim PathPhoto As String = "<img class='CurrentPhoto' src='../Pictures/" + Request.QueryString("category") + "/Album" + DecimalPlace + Album + "/" + Photo + "' />"
    'Response.Write(PathPhoto)
%>
<div style="border:1px solid black;">
<%--    <img style="height:300px;" src ="../Pictures/MyPhoto/Album01/photo01.JPG" />--%>

<script type="text/javascript">
    var args = {};	
    var query = location.search.substring(1);
    var pairs = query.split("&");	
    for (var i = 0; i < pairs.length; i++)
    {		                                    // Для каждого фрагмента
        var pos = pairs[i].indexOf('=');		// Отыскать пару имя/значение
		if (pos == -1) continue;				// Не найдено - пропустить
        var name = pairs[i].substring(0, pos);	// Извлечь имя
        var value = pairs[i].substring(pos + 1);	// Извлечь значение
        args[i] = value;					    // Сохранить в виде свойства
    }
    var AreaHeight = document.body.clientHeight;
    document.write('<img style="height:' + 300 + 'px;" src ="../Pictures/MyPhoto/Album01/photo01.JPG" />');
    document.write('</br>');
    var cat = args[0];
    //document.write(cat);
    //document.write('</br>');
    //document.write(query);
    //document.write('</br>');
    //document.write('</br>');
    document.write(document.body.clientWidth);
    document.write('</br>');
    document.write(document.body.clientHeight);
    document.write('</br>');


</script>
</div>