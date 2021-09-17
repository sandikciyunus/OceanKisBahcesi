function updateProduct() {
    $.post("/Admin/UpdateProducts", {
        "Id": $("#id").val(),
        "Name": $("#name").val(),
        "LanguageId": $("#languageId").val()
    }, function (res) {
        if (res.success == true) {
            window.location.href = "/Admin/ProductList";
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