<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoViewer.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
<script type="text/javascript">
    document.addEventListener("load", SelectContentToShow());
    
    var NumberAlbum;
    var Photo;
    var CategoryAlbum;
    var DecimalPlace = '0';

    function SelectContentToShow() {
        GetValueQueryString();
        if (Photo == undefined)
        {
            ShowGallery();
        }
        else
        {
            //var Path = '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + 'Preview/' + Photo + '"/>';
            alert (location.href);
            var Path1 = '<div><img src= "../Pictures/MyPhoto/Album01Preview/photo01.JPG" /></div>';
            alert(Path1);
        document.getElementById("ShowContent").innerHTML = Path1;
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
    var HTMLString = '';
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
    var WebPath = location.origin + '/Page/MainPage.aspx';
    function SetPhotoGrid() {
        for (var i = 0; i < ListPhotos.length; i++) {
            HTMLString = HTMLString + '<div class="PhotoCell">';
            HTMLString = HTMLString + '<a href="' + WebPath + '?category=' + CategoryAlbum + '&ID=' + NumberAlbum + '&Photo=' + ListPhotos[i] + '">';
            HTMLString = HTMLString + '<div>';
            HTMLString = HTMLString + '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + 'Preview/' + ListPhotos[i] + '"/>';
            HTMLString = HTMLString + '</div>';
            HTMLString = HTMLString + '</a>';
            HTMLString = HTMLString + '</div>';
        }       
        document.getElementById("ShowContent").innerHTML = HTMLString;     
    }

    //function BtNext_Click(event) {
    //    Number = Number + 1;
    //    Path = '<img src="../Pictures/MyPhoto/Album01Preview/' + ListPhotos[Number-1] + '" />';
    //    Content.innerHTML = Path;
    //    event.preventDefault();
    //}
    //function BtPrev_Click(event) {
    //    Number = Number - 1;
    //    Path = '<img src="../Pictures/MyPhoto/Album01Preview/' + ListPhotos[Number-1] + '" />';
    //    Content.innerHTML = Path;
    //    event.preventDefault();
    //}
</script>
<div style ="display:flex">
    <div style="display: flex;align-items:center;height:75vh;width:50px">
        <button onclick="BtPrev_Click(event)">Prev</button>
    </div>
    <div id="ShowContent" style="margin:auto;margin-top:18px">
        <asp:Image ID="SinglePhotoPlace" CssClass ="CurrentPhoto" runat ="server" />
        <asp:Label ID = "GalleryPlace" runat="server"/>
    </div>
    <div style="margin-left:auto; display: flex;align-items:center;height:75vh;width:50px ">
        <button onclick="BtNext_Click(event)">Next</button>
    </div>
</div>