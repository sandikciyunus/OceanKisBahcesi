function updateVideo() {
    var data = new FormData();

    data.append('file', $('input[type=file]')[0].files[0]);
    data.append("Id", $("#id").val());
    jQuery.ajax({
        url: '/Admin/UpdateHomeVideo',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        method: 'POST',
        type: 'POST', // For jQuery < 1.9
        success: function (res) {
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
        }
    });
}