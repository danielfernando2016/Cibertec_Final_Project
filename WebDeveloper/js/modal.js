$(document).ready(function () {
    $(".datepicker").datepicker();
});

function getModal(url) {
    $.get(url, function (data) {
        $('.modal-body').html(data);        
    });
}

function closeModal()
{     
    $("button[data-dismiss='modal']").click();
    window.location.reload();
}
