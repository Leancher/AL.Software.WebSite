<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoViewer.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
<script type="text/javascript">
    document.addEventListener("load", SelectContentToShow());
    
    var NumberAlbum;
    var Photo;
    var CategoryAlbum;
    var DecimalPlace = '0';
    var HTMLString = '';

    function SelectContentToShow() {
        GetValueQueryString();
        if (Photo != undefined)
        {
            ShowPhoto();
        }
        else
        {
            ShowGallery();
        }
          
    }

    function GetValueQueryString() {
        var pairs = location.search.substring(1).split("&");
        for (var i = 0; i < pairs.length; i++)
        {
            var pos = pairs[i].indexOf('=');
		    if (pos == -1) continue;
            var name = pairs[i].substring(0, pos);
            var value = pairs[i].substring(pos + 1);
            if (name == 'category') CategoryAlbum = value;
            if (name == 'ID') NumberAlbum = value;
            if (name == 'Photo') Photo = value;      
        }
    }
    var ListPhotos;
    
    function ShowGallery() {
        var Request = new XMLHttpRequest();
        Request.open('GET', 'GetPhotos.aspx?Command=ListPhoto&Category=' + CategoryAlbum + '&Album=' + NumberAlbum, true);
        Request.onreadystatechange = function () {
            if (Request.readyState == 4) {
                var ResponseString = Request.responseText;
                ListPhotos = ResponseString.split(";");
                SetPhotoGrid();
            }
        }
        Request.send();
    }
    var WebPath = location.origin+ '/Page/MainPage.aspx';
    function SetPhotoGrid() {
        for (var i = 0; i < ListPhotos.length; i++) {
            HTMLString = HTMLString + '<div class="PhotoCell">';
            HTMLString = HTMLString + '<a href="/" onclick="ShowPhoto(event, \u0027'+ ListPhotos[i] +'\u0027)">';
            HTMLString = HTMLString + '<div>';
            HTMLString = HTMLString + '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + 'Preview/' + ListPhotos[i] + '"/>';
            HTMLString = HTMLString + '</div>';
            HTMLString = HTMLString + '</a>';
            HTMLString = HTMLString + '</div>';
        }
        document.getElementById("ShowContent").innerHTML = HTMLString;
    }

    

    function ShowPhoto(event, Photo2) {
        //var Path = '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + 'Preview/' + Photo + '"/>';
        alert(Photo2);
        HTMLString = '<img src= "../Pictures/Noimage.jpg" />';
        document.getElementById("ShowContent").innerHTML = HTMLString;
        event.preventDefault();
    }

    function BtNext_Click(event) {
        HTMLString = '';
        HTMLString = '<img src="../Pictures/MyPhoto/Album01Preview/' + ListPhotos[5] + '" />';
        document.getElementById("ShowContent").innerHTML = HTMLString;
        event.preventDefault();        
    }
    function BtPrev_Click(event) {


        HTMLString = '';
        HTMLString = '<img src="../Pictures/MyPhoto/Album01Preview/' + ListPhotos[1] + '" />';
        document.getElementById("ShowContent").innerHTML = HTMLString;
        event.preventDefault();
    }
</script>
<div style ="display:flex">
    <div style="display: flex;align-items:center;height:75vh;width:50px">
        <button onclick="BtPrev_Click(event)">Prev</button>
    </div>
    <div id="ShowContent" style="margin:auto;margin-top:18px;border:1px black solid">
        
    </div>
    <div style="margin-left:auto; display: flex;align-items:center;height:75vh;width:50px ">
        <button onclick="BtNext_Click(event)">Next</button>
    </div>
</div>