// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#doeID').on('change', function () {
        var _id = $(this).val();
        $.ajax({
            type: "POST",
            url: "/Operation_1/GetDOEDateByDOEID",
            data: { id: _id },
            dataType: "json",
            success: function (response) {
                if (response != "") {
                    $("#DoeDateFromDOE").val(response);
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});
