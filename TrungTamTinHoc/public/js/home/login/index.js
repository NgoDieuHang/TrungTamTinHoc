/*
 * Các xử lý cho trang login
 * Author       :   HangNTD - 29/05/2018 - create  
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
$(document).ready(function () {
    InitLogin();
    InitEventLogin();
});
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :    HangNTD - 29/05/2018 - create
 * Param        :
 * Output       :
 */
function InitLogin () {
    try {
        FillRemember();
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Login:</b> ' + e.message, 4);
    }
}
/*
 * Khởi tạo các sự kiện cho trang
 * Author       :    HangNTD - 29/05/2018 - create
 * Param        :
 * Output       :
 */
function InitEventLogin() {
    try {
        $('#btn-login').on('click', function () {
            SubmitLogin();
        });
        $('#btn-login-FB').on('click', function ()
        {
            loginByFB();
        });
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event Login:</b> ' + e.message, 4);
    }
    
}
/*
 * Thực hiện kiểm tra thông tin người dùng
 * Author       :   HangNTD - 29/05/2018 - create
 * Param        :   
 * Output       :
 */
function SubmitLogin() {
    try {
        if (!validate('#form-login')) {
            $.ajax({
                type: 'POST',
                url: $('#form-login').attr('action'),
                data: {
                    Username: $('#Username').val(), 
                    Password: calcMD5($('#Password').val())
                },
                success: CheckLoginSuccess
        });
        } else {
            
        }
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Submit Login:</b> ' + e.message, 4);
    }
}
/*
 * Thực hiện xử lý dữ liệu sau khi kiểm tra đăng nhập
 * Author       :   HangNTD - 29/05/2018 - create
 * Param        :   res - response trả về từ server 
 * Output       :
 */
function CheckLoginSuccess(res) {
    try {
        if (res.Code == 200) {
            $.cookie('token', Base64.encode(res.ThongTinBoSung1), { expires: 1, path: '/' });
            CheckRemember();
            window.location = "/";
        } else {
            if (res.Code == 200) {
                fillError(res.ListError);
            } else {
                if (res.Code == 204 || res.Code == 202) {
                    jMessage(res.MsgNo, function(ok) {});
                } else {
                    jMessage(0, function (ok) { },
                        createMessage(res.MsgNo, res.ThongTinBoSung1,'', ''),4);
                }
            }
        }
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Check Login Success:</b> ' + e.message, 4);
    }
}
/*
 * Thực hiện việc lưu tài khoản và mật khẩu vào localStorage nếu nhấn CheckRemember,
 * ngược lại thì xóa dữ liệu tài khoản và mật khẩu có trong localStorage 
 * Author       :   HangNTD - 29/05/2018 - create
 * Param        :
 * Output       :
 */
function CheckRemember() {
    try {
        if ($('#Remember').is(':checked')) {
            window.localStorage.setItem('Username', Base64.encode($('#Username').val()));
            window.localStorage.setItem('Password', Base64.encode($('#Password').val()));
        } else {
                window.localStorage.removeItem('Username');
                window.localStorage.removeItem('Password');
        }
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Check Remember:</b> ' + e.message, 4);
    } 
}
/*
 * Thực hiện việc show username và password lấy từ localStorage lên view
 * Author       :   HangNTD - 29/05/2018 - create
 * Param        :
 * Output       :
 */
function FillRemember() {
    try {
        if (window.localStorage.getItem('Username')) {
            $('#Username').val(Base64.decode(window.localStorage.getItem('Username')));
            $('#Password').val(Base64.decode(window.localStorage.getItem('Password')));
            $('#Remember').prop('checked', true);
        }
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Fill Remember:</b> ' + e.message, 4);
    } 
}