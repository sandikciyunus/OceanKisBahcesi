$(document).ready(function () {
    $('#featureTable').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Turkish.json"
        }
    });
});



function addSubProductFeature() {
    $.post("/Admin/AddSubProductFeature", {
        "ProductId": $("#productId").val(),
        "Path": $("#path").val(),
        "LanguageId": $("#languageId").val(),
        "IsSubProduct": 1,
        "Feature": $("#feature").val()
    }, function (res) {
        if (res.success == false) {
            Swal.fire({
                icon: 'error',
                title: 'Uyarı',
                confirmButtonText: "Tamam",
                text: res.message
            })
        } else {
            window.location.reload();
        }
    })
}

function deleteSubProductFeature(id) {

    Swal.fire({
        title: 'Uyarı',
        text: "Silmek istediğinize emin misiniz?",
        showDenyButton: true,
        confirmButtonText: `Evet`,
        denyButtonText: `Hayır`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.post("/Admin/DeleteSubProductFeature", {
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