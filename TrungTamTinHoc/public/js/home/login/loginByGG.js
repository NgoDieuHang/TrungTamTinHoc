/*
 * Các xử lý cho việc đăng nhập bằng google
 * Author       :   HangNTD - 16/06/2018 - create  
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
function startApp() {
    gapi.load('auth2', function () {
        auth2 = gapi.auth2.init({
            client_id: $('meta[name="google-signin-client_id"]').attr('content'),
            cookiepolicy: 'single_host_origin',
            scope: "https://www.googleapis.com/auth/plus.login"
        });
        attachSignin(document.getElementById('btn-login-GG'));
    });
};

function attachSignin(element) {
    auth2.attachClickHandler(element, {},
        function (googleUser) {
            checkLoginByGG(googleUser.getAuthResponse().access_token);
        }, function (error) {
            alert(JSON.stringify(error, undefined, 2));
        });
}
/*
 * Dùng ajax gửi access token
 * Author       :   HangNTD - 16/06/2018 - create
 * Param        :   accessToken
 * Output       :
 */
function checkLoginByGG(accessToken) {
    if (accessToken !== null) {
        $.ajax({
            type: 'GET',
            url: url.loginGG + '?accessToken=' + accessToken,
            success: CheckLoginSuccess
        });
    }
}