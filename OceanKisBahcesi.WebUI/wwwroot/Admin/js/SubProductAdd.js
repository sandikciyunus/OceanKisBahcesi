function addSubProduct() {
    $.post("/Admin/AddSubProduct", {
        "Name": $("#name").val(),
        "ProductId": $("#productId").val(),
        "Path": $("#path").val(),
        "LanguageId": $("#languageId").val()
    }, function (res) {
        if (res.success == true) {
            window.location.href = "/Admin/SubProductList";
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