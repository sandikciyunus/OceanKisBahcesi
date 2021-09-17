function addProduct() {
    $.post("/Admin/AddProduct", {
        "Name": $("#name").val(),
        "Path": $("#path").val(),
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