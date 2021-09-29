function updateService() {
    $.post("/Admin/UpdateService", {
        "Id": $("#id").val(),
        "Title": $("#title").val(),
        "Description": $("#description").val(),
        "LanguageId": $("#languageId").val(),
        "Logo":$("#logo").val()
    }, function (res) {
            if (res.success == false) {
                Swal.fire({
                    icon: 'error',
                    title: 'Uyarı',
                    confirmButtonText: "Tamam",
                    text: res.message
                })
            } else {
                window.location.href = "/Admin/ServiceList";
            }
    })
}