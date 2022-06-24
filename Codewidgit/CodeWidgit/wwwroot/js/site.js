//
//Sign Up View javaScript
//
$(document).ready(function () {
    $("#signup_submit").click(function (event) {
        var data = $("#UserForm").serialize();
        $.ajax({
            type: 'POST',
            url: '/Home/Sign_Up_User',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {
                alert('Successfully received Data ');
                console.log(result);
            },
            error: function () {
                alert('Failed to receive the Data');
                console.log('Failed ');
            }
        })
    });

});


