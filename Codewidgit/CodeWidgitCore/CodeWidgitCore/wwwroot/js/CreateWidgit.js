//
//Create Widgit JavaScript
//
$(document).ready(function () {
    $("#widgit_submit").click(function (event) {
        var WidgitName = $("#WidgitName").val();
        var WidgitDescription = $("#WidgitDescription").val();
        var WidgitPrice = $("#WidgitPrice").val();
        var WidgitFile = $("#WidgitFile").val();
        debugger;

        $.ajax({
            type: 'POST',
            url: '/Widgits/Create',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: {
                WidgitName: WidgitName, WidgitDescription: WidgitDescription, WidgitPrice: WidgitPrice, WidgitFile: WidgitFile
            },
            success: function (result) {
                alert(result);
                console.log(result);
            },
            error: function () {
                alert('Failed to receive the Data');
                console.log('Failed');
            }
        })
    });

});

