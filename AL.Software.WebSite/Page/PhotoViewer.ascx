<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoViewer.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
<script type="text/javascript">
    document.addEventListener('DOMContentLoaded', ShowContent);

    var PhotoPlace, SinglePhoto;
    var CurrentDocument;
    var NumberAlbum;
    var CategoryAlbum;
    var ListPhotos;
    var BtNext, BtPrev, ReturnBack, CurrentNumberPhoto;
    
    function ShowContent() {
        CurrentDocument = document;
        Content = document.getElementById("Content");
        BtNext = document.getElementById("BtNext");
        BtPrev = document.getElementById("BtPrev");
        ReturnBack = document.getElementById("ReturnBack");
        GetQueryString();
        ShowGallery();
    }

    function GetQueryString() {
        var pairs = location.search.substring(1).split("&");
        for (var i = 0; i < pairs.length; i++)
        {
            var pos = pairs[i].indexOf('=');
		    if (pos == -1) continue;
            var name = pairs[i].substring(0, pos);
            var value = pairs[i].substring(pos + 1);
            if (name == 'category') CategoryAlbum = value;
            if (name == 'ID') NumberAlbum = value;
        }
    }
   
    function ShowGallery() {
        var Request = new XMLHttpRequest();
        Request.open('GET', 'Page/GetPhotos.aspx?Command=ListPhoto&Category=' + CategoryAlbum + '&Album=' + NumberAlbum, true);
        Request.onreadystatechange = function () {
            if (Request.readyState == 4) {
                var ResponseString = Request.responseText;
                ListPhotos = ResponseString.split(";");
                SetPhotoGrid();
            }
        }
        Request.send();
    }

    function SetPhotoGrid(event) {
        BtPrev.style.display = 'none';
        BtNext.style.display = 'none';
        ReturnBack.style.display = 'none';
        if (PhotoPlace != undefined) Content.removeChild(PhotoPlace);       
        PhotoPlace = CurrentDocument.createElement('div');
        for (var i = 0; i < ListPhotos.length; i++) {
            var PhotoCell = CurrentDocument.createElement('div');
            PhotoCell.className = 'PhotoCell';
            var img = CurrentDocument.createElement('img');
            img.src = 'Pictures/' + CategoryAlbum + '/album' + NumberAlbum + 'Preview/' + ListPhotos[i];
            var lnk = CurrentDocument.createElement('a');
            lnk.href = '#' + i;
            lnk.onclick = function () {
                var PhotoNumber = this.hash.substring(1);
                ShowPhoto(event,PhotoNumber);
                event.preventDefault();
            }
            lnk.appendChild(img);       
            PhotoCell.appendChild(lnk);
            PhotoPlace.appendChild(PhotoCell);
        }
        Content.appendChild(PhotoPlace);
        event.preventDefault();        
    }

    function ShowPhoto(event, PhotoNumber) {
        BtPrev.style.display = 'block';
        BtNext.style.display = 'block';
        ReturnBack.style.display = 'block';
        CurrentNumberPhoto = +PhotoNumber; // + означет, что переменная число
        Content.removeChild(PhotoPlace);
        PhotoPlace = CurrentDocument.createElement('div');
        SinglePhoto = CurrentDocument.createElement('img');
        SinglePhoto.className = 'CurrentPhoto';
        SinglePhoto.src = 'Pictures/' + CategoryAlbum + '/album' + NumberAlbum + '/' + ListPhotos[PhotoNumber];
        PhotoPlace.appendChild(SinglePhoto);
        Content.appendChild(PhotoPlace);
        event.preventDefault();
    }

    function BtNext_Click(event) {
        CurrentNumberPhoto = CurrentNumberPhoto + 1;  
        if (CurrentNumberPhoto > ListPhotos.length-1) CurrentNumberPhoto = ListPhotos.length-1;    
        SinglePhoto.src = 'Pictures/' + CategoryAlbum + '/album' + NumberAlbum + '/' + ListPhotos[CurrentNumberPhoto];
        event.preventDefault();        
    }
    function BtPrev_Click(event) {
        CurrentNumberPhoto = CurrentNumberPhoto - 1;
        if (CurrentNumberPhoto < 0) CurrentNumberPhoto = 0;                  
        SinglePhoto.src = 'Pictures/' + CategoryAlbum + '/album' + NumberAlbum + '/' + ListPhotos[CurrentNumberPhoto];
        event.preventDefault();
    }
</script>
<a href ="/" id="ReturnBack" onclick="SetPhotoGrid(event)" style="display:none" class="Text">Вернуться в галлерею</a>         
<div style ="display:flex">
    <div class="Button">
        <a href ="/" id="BtPrev" onclick ="BtPrev_Click(event)" style="display:block">         
            <img src="Pictures/Util/ArrowLDis.png" onmousemove="this.src='Pictures/Util/ArrowLEn.png'" onmouseout="this.src='Pictures/Util/ArrowLDis.png'" />
        </a>
    </div>
    <div id="Content" class="PhotoPlace">
        
    </div>
    <div class="Button">
        <a href ="/" id="BtNext" onclick ="BtNext_Click(event)" style="display:block">         
            <img src="Pictures/Util/ArrowRDis.png" onmousemove="this.src='Pictures/Util/ArrowREn.png'" onmouseout="this.src='Pictures/Util/ArrowRDis.png'" />
        </a>
    </div>
</div>