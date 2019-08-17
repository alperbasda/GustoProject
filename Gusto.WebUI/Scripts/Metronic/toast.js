
$(document).ready(function() {
    notificationAlert();
});

function notificationAlert() {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    var result = "";
    result = getParameterByName('notificationSuccess');
    if (result != null) {
        toastr.success(result, "Başarılı!!!");
    }
    result = getParameterByName('notificationError');
    if (result != null) {
        toastr.error(result, "Hata");
    }
}

function notificationAlertParameter(param1,param2) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    toastr.success(param2, param1);
    
}
function notificationAlert3Parameter(success, param1, param2) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    if (success == true) {
        toastr.success(param2, param1);
    } else {
        toastr.error(param2, param1);
    }




}
function successAlert(title, message) {

    $('body').xmalert({
        x: 'right',
        y: 'top',
        xOffset: 30,
        yOffset: 30,
        alertSpacing: 40,
        lifetime: 6000,
        fadeDelay: 0.3,
        template: 'messageSuccess',
        title: title,
        paragraph: message
    });
}


function getParameterByName(name) {
    var url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function getBaseUrl() {
    var getUrl = window.location;
    return getUrl.protocol + "//" + getUrl.host + "/";
}