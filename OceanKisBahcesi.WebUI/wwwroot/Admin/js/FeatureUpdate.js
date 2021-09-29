CKEDITOR.replace('editor1');

function updateFeature() {
    var data = new FormData();

    data.append('file', $('input[type=file]')[0].files[0]);
    data.append("Id", $("#id").val());
    data.append("Name", CKEDITOR.instances['editor1'].getData());
    data.append("LanguageId", $("#languageId").val());
    data.append("Sort", $("#sort").val());
    jQuery.ajax({
        url: '/Admin/UpdateFeature',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        method: 'POST',
        type: 'POST', // For jQuery < 1.9
        success: function (res) {
            if (res.success == true) {
                window.location.href="/Admin/FeatureList";
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Uyarı',
                    confirmButtonText: "Tamam",
                    text: res.message
                })
            }
        }
    });
}