/*
 * Các xử lý cho trang  forget password
 * Author       : HangNTD  - 21/06/2018 - Create
 * copyright    :Team Noname
 *  Version     :   1.0.0
 * */

$(document).ready(function () {
    InitForgetPass();
    InitEventForgetPass();
});
/*
 * Khởi tạo các giá trị cho trang
 * Author    : HangNTD  - 21/06/2018 - Create
 * copyright :Team Noname
 *  Version      :   1.0.0
 * */
function InitForgetPass() {
    try {

    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>InitLossPass :</b>' + e.message, 4);
    }
}
/*
 * xử lý các sự kiện trong trang
 * Author    : HangNTD  - 21/06/2018 - Create
 * Package   : public/home
 * copyright :Team Noname
 *  Version      :   1.0.0
 * */
function InitEventForgetPass() {
    try {
        $('#btn-forgetpassword').on('click', function () {
            alert("ahhi");
            CheckEmail();
        });
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>InitEventForgetPass :</b>' + e.message, 4);
    }
}

/*
 * Thuc hien kiem tra thong tin nguoi dung
 * Author    : HangNTD  - 21/06/2018 - Create
 * Package   : public/home
 * copyright :Team Noname
 *  Version      :   1.0.0
 * */
function CheckEmail() {
    try {
        if (!validate('#form-lostpassword')) {
            $.ajax({
                type: 'POST',
                url: $('#form-lostpassword').attr('action'),
                data: {
                    email: $('#Email').val()
                },
                success: CheckEmailSuccess

            });
        } else {
        }
    } catch (e) {

    }
}
function CheckEmailSuccess(res) {
    try {
        if (res.Code == 200) {
            alert('Bạn vui lòng vào mail để nhận lại password');
        } else {
            jMessage(0, function (ok) { },
                createMessage(res.MsgNo, res.ThongTinBoSung1, '', ''), 4);
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Create Account Response:</b> ' + e.message, 4);
        return true;
    }
}