//
//Log In View javaScript
//
$(document).ready(function () {
    $("#login_submit").click(function (event) {
        var email = $("#login_email").val();
        var password = $("#login_password").val();
        debugger;

        $.ajax({
            type: 'POST',
            url: '/Home/Log_In_User',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: {
                email: email, password: password
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
