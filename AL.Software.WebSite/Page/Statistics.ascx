<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Statistics.ascx.vb" Inherits="Page_Statistics" %>
<script type="text/javascript">
   
    let currentDocument = '';
    let statBlock;

    const showContent = () => {
        currentDocument = document;
        statBlock = document.getElementById("StatBlock");
        statBlock1 = document.getElementById("Column1");
        statBlock2 = document.getElementById("Column2");
        getCountView();
    };

    const getCountView = () => {
        const Request = new XMLHttpRequest();
        Request.open('GET', 'Page/RequsetProcessor.aspx?Command=GetCountView', true);
        Request.onreadystatechange = () => {
            if (Request.readyState == 4) {
                const responseString = Request.responseText;
                showData(responseString);
            }
        }
        Request.send();
    };

    const showData = (responseString) => {
        let rawList = responseString.split(";");
        const listCountView = rawList.map((item) => {
            const objItem = item.split(">");
            return { name: objItem[0], count: objItem[1] };
        });
        listCountView.sort((a, b) => b.count - a.count);
        const len = listCountView.length;
        for (const index in listCountView) {
            const curItem = currentDocument.createElement('label');
            curItem.innerHTML = listCountView[index].name + ' - ' + listCountView[index].count + '<br>';
            if (index < len / 2) {
                statBlock1.appendChild(curItem);
            }
            else {
                statBlock2.appendChild(curItem);
            } 
        };
    };
    document.addEventListener('DOMContentLoaded', showContent);

</script>
<table style="width:100%">
    <tr>
        <td id="Column1" style="width:50%"></td>
        <td id="Column2" style="width:50%"></td>
    </tr>
</table>
<div id="StatBlock"/>