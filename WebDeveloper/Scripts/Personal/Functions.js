
var pageSize = 10;
function getSize(size) {
    pageSize = size;
    $('#firstPage').click();
}

var fullUrl;
function goToPage(url, page) {
    fullUrl = url + "?page=" + page + "&size=" + pageSize;
    $.get(fullUrl, function (data) {
        $('#personContent').html(data);
    });
}

function reloadPartial() {
    if (fullUrl) {
        $.get(fullUrl, function (data) {
            $('#personContent').html(data);
        });
    }
}
$(function () {
    $('#firstPage').click();
});