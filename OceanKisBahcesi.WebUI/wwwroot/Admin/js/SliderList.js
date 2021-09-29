$(document).ready(function () {
    $('#sliderTable').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Turkish.json"
        }
    });
});

function deleteSlider(id) {

    Swal.fire({
        title: 'Uyarı',
        text: "Silmek istediğinize emin misiniz?",
        showDenyButton: true,
        confirmButtonText: `Evet`,
        denyButtonText: `Hayır`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.post("/Admin/DeleteSlider", {
                "id": id
            }, function (res) {
                    if (res.success == true) {
                        window.location.reload();
                    } else {
                        Swal.fire({
                            icon: 'info',
                            title: 'Uyarı',
                            confirmButtonText: "Tamam",
                            text: res.message
                        })
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

