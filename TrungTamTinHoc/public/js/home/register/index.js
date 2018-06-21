/*
 * Các xử lý cho trang Register
 * Author       :   HangNTD - 16/06/2018 - create  
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
$(document).ready(function () {
    InitRegister();
    InitEventRegister();
});
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :    HangNTD - 16/06/2018 - create
 * Param        :
 * Output       :
 */
function InitRegister() {
    try {
        $("#datepicker").datepicker(
            { dateFormat: 'dd/mm/yy' });
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Register:</b> ' + e.message, 4);
    }
}
/*
 * Khởi tạo các sự kiện cho trang
 * Author       :    HangNTD - 16/06/2018  - create
 * Param        :
 * Output       :
 */
function InitEventRegister() {
    try {
        $('#btn-register').on('click', function () {
            validate('#form-register');
            checkMatchingPasswords();
            submitRegister()
        });
        
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event Register:</b> ' + e.message, 4);
    }

}

function submitRegister() {
    try {
        if (!validate('#form-register')) {
            $.ajax({
                url: $('#form-register').attr('action'),
                type: 'POST',
                data: {
                    Username: $('#Username').val(),
                    Ho: $('#Firstname').val(),
                    Ten: $('#Lastname').val(),
                    GioiTinh: $('#Gender').val() == 'nam' ? true : false,
                    NgaySinh: $('#datepicker').val(),
                    Email: $('#Email').val(),
                    Password: calcMD5($('#Password').val()),
                    ConfirmPassword: calcMD5($('#ConfirmPassword').val()),
                    Agree: true
                },
                success: checkRegisterSuccess
            });
        }
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>SubmitLogin:</b> ' + e.message, 4);
    }
}
/*
 * Thực hiện xử lý dữ liệu sau khi đăng nhập
 * Author       :   HangNTD - 29/05/2018 - create
 * Packet       :   public/home
 * Param        :   res - response trả về từ server   
 * Output       :   
 */
function checkRegisterSuccess(res) {
    try {
        if (res.Code === 200) {
            window.location = "/home/kich-hoat";
        }
        else if (res.Code === 200) {
            fillError(res.ListError);
        }
        else if (res.Code === 204 || res.Code === 202) {
            jMessage(res.MsgNo, function (ok) { });
        }
        else {
            jMessage(res.MsgNo, function (ok) { }, createMessage(res.MsgNo, res.ThongTinBoSung1, '', ''), 4);
        }
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Check register success:</b> ' + e.message, 4);
    }
}

/*
 * Kiểm tra Password và Confirm password có khớp với nhau hay không
 * Author       :   HangNTD - 16/06/2018 - create
 * Param 
 * Output       :
 */
function checkMatchingPasswords() {
    try {
        var lang = getLang();
        if ($('#Password').val() !== $('#ConfirmPassword').val()) { 
            $('#ConfirmPassword').errorStyle(_text[lang][34]);
        }
    } catch (e) {
        jMessage(0, function (ok) {
            return false;
        }, '<b>Check Matching Passwords</b> ' + e.message, 4);
    }
}