<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewerCurrentPhoto.ascx.vb" Inherits="Page_ViewerCurrentPhoto" %>
<div class="CurrentPhoto">
<script type="text/javascript">
    var PictureHeight = document.documentElement.clientHeight - 210;
    var Album;
    var Photo;
    var DecimalPlace = '0';
    var QueryString = location.search.substring(1);
    var pairs = QueryString.split("&");	
    for (var i = 0; i < pairs.length; i++)
    {
        var pos = pairs[i].indexOf('=');
		if (pos == -1) continue;
        var name = pairs[i].substring(0, pos);
        var value = pairs[i].substring(pos + 1);
        if (name == 'ID') Album = value;
        if (name == 'Photo') Photo = value;      
    }
    if (Album.length > 1) DecimalPlace = '';
    var Path = '../Pictures/MyPhoto/Album' + DecimalPlace + Album + '/' + Photo;
    document.write('<img style="height:' + PictureHeight + 'px;" src ="' + Path + '" />');
</script>
</div>