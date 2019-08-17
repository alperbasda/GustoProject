$('input[name=SslVarmi]').click(function () {
    if ((this).value == "true") {
        $('#SslRow').removeAttr("hidden");
        return;
    }
    $('#SslRow').attr("hidden", "hidden");
});