<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoViewer.ascx.vb" Inherits="Page_ViewerPhotoAlbum" %>
<script type="text/javascript">
    document.addEventListener("load", SelectContentToShow());
    var Album;
    var Photo;
    var Category;
    var DecimalPlace = '0';
    function SelectContentToShow() {
        GetValueQueryString();
        if (Photo == undefined) ShowGallery();
    }
    function GetValueQueryString() {
        var pairs = location.search.substring(1).split("&");
        for (var i = 0; i < pairs.length; i++)
        {
            var pos = pairs[i].indexOf('=');
		    if (pos == -1) continue;
            var name = pairs[i].substring(0, pos);
            var value = pairs[i].substring(pos + 1);
            if (name == 'category') Category = value;
            if (name == 'ID') Album = value;
            if (name == 'Photo') Photo = value;      
        }
    }
    var Photos;
    var ShowPhoto = document.getElementById("ShowPhoto");
    var Path;
    function ShowGallery() {
        var Request = new XMLHttpRequest();
        Request.open('GET', 'GetPhotos.aspx?Command=ListPhoto&Category=' + Category + '&Album=' + Album, true);
        Request.onreadystatechange = function () {
            if (Request.readyState == 4) {
                var ResponseString = Request.responseText;
                Photos = ResponseString.split(";");
                ShowPhoto.innerHTML = Path;
            }
        }
        Request.send();
    }
    function BtNext_Click(event) {
        Number = Number + 1;
        Path = '<img src="../Pictures/MyPhoto/Album01Preview/' + Photos[Number-1] + '" />';
        Ph1.innerHTML = Path;
        event.preventDefault();
    }
    function BtPrev_Click(event) {
        Number = Number - 1;
        Path = '<img src="../Pictures/MyPhoto/Album01Preview/' + Photos[Number-1] + '" />';
        Ph1.innerHTML = Path;
        event.preventDefault();
    }
</script>
<div style ="display:flex">
    <div style="display: flex;align-items:center;height:75vh;width:50px">
        <button onclick="BtPrev_Click(event)">Prev</button>
    </div>
    <div id="ShowPhoto" style="margin:auto;margin-top:18px">
        <asp:Image ID="SinglePhotoPlace" CssClass ="CurrentPhoto" runat ="server" />
        <asp:Label ID = "GalleryPlace" runat="server"/>
    </div>
    <div style="margin-left:auto; display: flex;align-items:center;height:75vh;width:50px ">
        <button onclick="BtNext_Click(event)">Next</button>
    </div>
</div>