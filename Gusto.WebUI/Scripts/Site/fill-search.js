(function () {
    var inputs = document.querySelectorAll('input');
    if (inputs != null) {
        for (var i = 0, iLen = inputs.length; i < iLen; i++) {
            inputs[i].value = getQueryVariable(inputs[i].name);
        }
    }
})();
function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split('&');
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split('=');
        if (decodeURIComponent(pair[0]) == variable) {
            return decodeURIComponent(pair[1]);
        }
    }
    return "";
}