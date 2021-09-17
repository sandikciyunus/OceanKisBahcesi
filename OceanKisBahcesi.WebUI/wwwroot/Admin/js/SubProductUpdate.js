function updateSubProduct() {
    $.post("/Admin/UpdateSubProducts", {
        "Id": $("#id").val(),
        "Name": $("#name").val(),
        "ProductId": $("#productId").val()
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