/*
 * Các xử lý cho việc đăng nhập bằng facebook
 * Author       :   HangNTD - 02/06/2018 - create  
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
(function (d, s, id) {
    var lang = 'vi_VN';
    lang = getLang();
    if (lang = 'en') {
        lang = 'en_US';
    }
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/" + lang + "/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :    HangNTD - 02/06/2018 - create
 * Param        :
 * Output       :
 */
window.fbAsyncInit = function () {
    FB.init({
        appId: $('meta[property="fb:app_id"]').attr('content'),
        status: true,
        cookie: true,
        xfbml: false,
        version: 'v3.0'
    });
};
/*
 * Thực hiện xử lý dữ liệu sau khi nhấn nút facebook
 * Author       :   HangNTD - 02/06/2018 - create
 * Param        :   response
 * Output       :
 */
function loginByFB() {
    FB.getLoginStatus(function(response) {
        if (response.status === 'connected') {
            CheckLoginFB(response.authResponse.accessToken);
        } else {
            FB.login(function(response) {
                    CheckLoginFB(response.authResponse.accessToken);
                },
                { scope: 'public_profile,email' });
        }
    });
}
/*
 * Dùng ajax gửi access token
 * Author       :   HangNTD - 02/06/2018 - create
 * Param        :   accessToken
 * Output       :
 */
function CheckLoginFB(accessToken) {
    $.ajax({
        type: 'GET',
        url: url.loginFB + '?accessToken=' + accessToken,
        success: CheckLoginSuccess
    });
}
