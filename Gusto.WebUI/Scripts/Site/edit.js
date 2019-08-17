var datas = {};
var lastEdit;
$(document).ready(function() {
    datas["Id"] = $('#item').val();
});
$('span[data-edit-label]').click(function () {
    
    lastEdit = $(this).data('edit-name');
    $('#edit-name').val($('span[data-edit-name]').data('edit-name'));
    $('#edit-label').text($(this).data('edit-label') + ' düzenle');
    $('#edit-value').val($(this).data('edit-value'));
});

$('#save-changes').click(function () {
    datas[lastEdit] = $('#edit-value').val();
    datas["Id"] = $('#item').val();
    $.ajax({
        dataType: 'JSON',
        type: 'Get',
        url: '../../Domain/EditAjax',
        data: datas,
        contentType: 'application/json;',
        success: function (msg) {
            if (msg == 0) {
                notificationAlert3Parameter(false, "Hata", "Düzenleme sırasında hata oluştu");
            } else {

                notificationAlert3Parameter(true, "Başarılı !!!", "Düzenleme basarılı");
                $('input[name="' + lastEdit + '"]').val($('#edit-value').val());
            }
        }

    });
});

$('select[name="ProjeTipi"]').change(function () {
    datas["ProjeTipi"] = $(this).val();
    datas["Id"] = $('#item').val();
    $.ajax({
        dataType: 'JSON',
        type: 'Get',
        url: '../../Domain/EditAjax',
        data: datas,
        contentType: 'application/json;',
        success: function (msg) {
            if (msg == 0) {
                notificationAlert3Parameter(false, "Hata", "Düzenleme sırasında hata oluştu");
            } else {
                notificationAlert3Parameter(true, "Başarılı !!!", "Düzenleme basarılı");
                $('input[name="' + lastEdit + '"]').val($('#edit-value').val());
            }
        }

    });
});

$('input[name=SslVarmi]').click(function () {
    datas["SslVarmi"] = $(this).val();
    datas["Id"] = $('#item').val();
    if ((this).value == "true") {
        $.ajax({
            dataType: 'JSON',
            type: 'Get',
            url: '../../Domain/EditAjax',
            data: datas,
            contentType: 'application/json;',
            success: function (msg) {
                if (msg == 0) {
                    notificationAlert3Parameter(false, "Hata", "Düzenleme sırasında hata oluştu");
                } else {
                    $('#SslRow').removeAttr("hidden");
                    notificationAlert3Parameter(true, "Başarılı !!!", "Düzenleme basarılı");
                    $('input[name="' + lastEdit + '"]').val($('#edit-value').val());
                }
            }

        });
        
        return;
    }
    $.ajax({
        dataType: 'JSON',
        type: 'Get',
        url: '../../Domain/EditAjax',
        data: datas,
        contentType: 'application/json;',
        success: function (msg) {
            if (msg == 0) {
                notificationAlert3Parameter(false, "Hata", "Düzenleme sırasında hata oluştu");
            } else {
                $('#SslRow').attr("hidden", "hidden");
                notificationAlert3Parameter(true, "Başarılı !!!", "Düzenleme basarılı");
                $('input[name="' + lastEdit + '"]').val($('#edit-value').val());
            }
        }

    });
    
});

$('input[type="date"]').change(function () {
    datas["Id"] = $('#item').val();
    datas[$(this).attr('name')] = $(this).val();
    $.ajax({
        dataType: 'JSON',
        type: 'Get',
        url: '../../Domain/EditAjax',
        data: datas,
        contentType: 'application/json;',
        success: function (msg) {
            if (msg == 0) {
                notificationAlert3Parameter(false, "Hata", "Düzenleme sırasında hata oluştu");
            } else {
                notificationAlert3Parameter(true, "Başarılı !!!", "Düzenleme basarılı");
                $('input[name="' + lastEdit + '"]').val($('#edit-value').val());
            }
        }

    });
});