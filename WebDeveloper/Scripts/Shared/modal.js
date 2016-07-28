function getModal(url) {
    $.get(url, function (data) {
        $('.modal-body').html(data);        
    });
}

function closeModal()
{     
    $("button[data-dismiss='modal']").click();
    $('.modal-body').html('');
    reloadPartial();
}
