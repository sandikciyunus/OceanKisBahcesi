var isActive = $('#IsActive').val();
$('#IsActive').change(function () {
    if ($('#IsActive').is(':checked')) {
        isActive = 1;

    } else {
        isActive = 0;
    }
});



function addSlider() {
    var data = new FormData();

    data.append('file', $('input[type=file]')[0].files[0]);
    data.append("IsActive", isActive);
    jQuery.ajax({
        url: '/Admin/SliderAdd',
        data: data,
        cache: false,
        contentType: false,
        processData: false,
        method: 'POST',
        type: 'POST', // For jQuery < 1.9
        success: function (res) {
            if (res.success == true) {
                window.location.href = "/Admin/SliderList";
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