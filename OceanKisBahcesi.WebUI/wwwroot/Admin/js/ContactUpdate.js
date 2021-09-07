$(function () {
$("#phone").mask("(999) 999-9999");
})


function updateContact() {
    $.post("/Admin/updateContact", {
        "Id": $("#Id").val(),
        "Address": $("#address").val(),
        "Email": $("#email").val(),
        "Phone": $("#phone").val(),
        "LanguageId": $("#languageId").val()
    }, function (res) {
            if (res.success == true) {
                window.location.href = "/Admin/ContactList";
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