$(document).ready(function () {
    //$('#phone').inputmask('(999)-999-9999');
    $("#phone").keyup(function () {
        if (this.value.match(/[^0-9]/g)) {
            this.value = this.value.replace(/[^0-9]/g, '');
        }
    });
});  

function sendMail() {
     
 $.post("/Contact/SendMail", {
        "Fullname": $("#name").val(),
        "Email": $("#email").val(),
        "Phone": $("#phone").val(),
        "Subject": $("#subject").val(),
        "Message": $("#message").val()
    }, function (res) {
            if (res.success == false) {
                alert(res.message);
            } else {
                alert("Mesaj başarıyla gönderildi");
                $("#name").val("");
                $("#email").val("");
                $("#phone").val("");
                $("#subject").val("");
                $("#message").val("");
            }
    })
   
}

