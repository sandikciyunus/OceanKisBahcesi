$(document).ready(function () {
    $('#ımageTable').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Turkish.json"
        }
    });
});

function addSubProductImage() {
    var data = new FormData();

    data.append('file', $('input[type=file]')[0].files[0]);
    data.append("Path", $("#path").val());
    jQuery.ajax({
        url: '/Admin/AddSubProductImage',
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


function deleteSubProductImage(id) {

    Swal.fire({
        title: 'Uyarı',
        text: "Silmek istediğinize emin misiniz?",
        showDenyButton: true,
        confirmButtonText: `Evet`,
        denyButtonText: `Hayır`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.post("/Admin/DeleteProductImage", {
                "id": id
            }, function (res) {
                if (res.success == true) {
                    window.location.reload();
                }
            })
        } else if (result.isDenied) {
            Swal.fire({
                icon: 'info',
                title: 'Bilgi',
                confirmButtonText: "Tamam",
                text: "Silme işlemi iptal edildi"
            })
        }
    })

}