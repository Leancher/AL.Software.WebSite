<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoViewer.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
<script type="text/javascript">
    document.addEventListener('DOMContentLoaded', SelectContentToShow);
    
    var NumberAlbum;
    var Photo;
    var CategoryAlbum;
    var DecimalPlace = '0';
    var HTMLString = '';
    var PhotoPlace;
    var ListPhotos;
    var CurrentNumberPhoto;

    function SelectContentToShow() {

        PhotoPlace = document.getElementById("PhotoPlace");
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

    function SetPhotoGrid() {

        for (var i = 0; i < ListPhotos.length; i++) {
            HTMLString = HTMLString + '<div class="PhotoCell">';
            HTMLString = HTMLString + '<a href="/" onclick="ShowPhoto(event, \u0027'+ i +'\u0027)">';
            HTMLString = HTMLString + '<div>';
            HTMLString = HTMLString + '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + 'Preview/' + ListPhotos[i] + '"/>';
            HTMLString = HTMLString + '</div>';
            HTMLString = HTMLString + '</a>';
            HTMLString = HTMLString + '</div>';
        }
        PhotoPlace.innerHTML = HTMLString;
    }

    function ShowPhoto(event, PhotoNumber) {
        CurrentNumberPhoto = +PhotoNumber; // + означет, что переменная число
        HTMLString = '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + '/' + ListPhotos[PhotoNumber] + '" class="CurrentPhoto"/>';
        PhotoPlace.innerHTML = HTMLString;
        event.preventDefault();
    }

    function BtNext_Click(event) {
        CurrentNumberPhoto = CurrentNumberPhoto + 1;  
        if (CurrentNumberPhoto > ListPhotos.length-1) {
            CurrentNumberPhoto = ListPhotos.length-1;
        }                        
        HTMLString = '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + '/' + ListPhotos[CurrentNumberPhoto] + '" class="CurrentPhoto"/>';
        PhotoPlace.innerHTML = HTMLString;
        event.preventDefault();        
    }
    function BtPrev_Click(event) {
        CurrentNumberPhoto = CurrentNumberPhoto - 1;
        if (CurrentNumberPhoto < 0) {
            CurrentNumberPhoto = 0;
        }                   
        HTMLString = '<img src="../Pictures/' + CategoryAlbum + '/album0' + NumberAlbum + '/' + ListPhotos[CurrentNumberPhoto] + '" class="CurrentPhoto"/>';
        PhotoPlace.innerHTML = HTMLString;
        event.preventDefault();
    }
</script>
<div style ="display:flex">
    <div style="margin-right:auto ; display: flex;align-items:center;height:75vh;width:50px;border:1px black solid">
        <button id="BtPrev" onclick="BtPrev_Click(event)">Prev</button>
    </div>
    <div id="PhotoPlace" class="PhotoPlace">
        
    </div>
    <div style="margin-left:auto; display: flex;align-items:center;height:75vh;width:50px;border:1px black solid ">
        <button id="BtNext" onclick="BtNext_Click(event)">Next</button>
    </div>
</div>