function addSubProductVideo() {
    $.post("/Admin/SubProductAddVideo", {
        "Url": $("#url").val(),
        "Path": $("#path").val()
    }, function (res) {
            if (res.success == true) {
                window.location.reload();
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Uyarı',
                    confirmButtonText: "Tamam",
                    text: res.message
                })
            }
    })
}

function deleteVideo(id) {
    $.post("/Admin/DeleteVideo", {
        "Id": id
    }, function (res) {
            if (res.success == true) {
                window.location.reload();
            }
    })
}