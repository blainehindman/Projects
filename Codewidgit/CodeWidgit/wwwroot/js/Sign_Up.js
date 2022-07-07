//
//Sign Up View javaScript
//
$(document).ready(function () {
    $("#signup_submit").click(function (event) {
        var first_name = $("#signup_first_name").val();
        var last_name = $("#signup_last_name").val();
        var email = $("#signup_email").val();
        var username = $("#signup_username").val();
        var password = $("#signup_password").val();
        var birthday = $("#signup_birthday").val();
        var repassword = $("#signup_repassword").val();
        debugger;

        $.ajax({
            type: 'POST',
            url: '/Home/Sign_Up_User',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: {
                first_name: first_name, last_name: last_name, email: email, username: username,
                password: password, birthday: birthday, repassword: repassword
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

