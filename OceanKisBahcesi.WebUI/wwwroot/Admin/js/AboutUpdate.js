function updateAbout() {
    $.post("/Admin/UpdateAbout", {
        "Id": $("#Id").val(),
        "AboutDescription": $("#about").val(),
        "OurVisionDescription": $("#vision").val(),
        "OurMission": $("#mission").val(),
        "LanguageId": $("#languageId").val()
    }, function (res) {
            if (res.success == true) {
                window.location.href = "/Admin/AboutList";
            }
    })
}