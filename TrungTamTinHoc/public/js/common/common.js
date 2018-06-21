/*
 * Chứa các function và sự kiện sẽ sử dụng chung và nhiều lần trong dự án
 * Author       :   DungNTP - 24/09/2017 - create  
 * Package      :   Scripts/Common
 * Copyright    :   ĐHBKĐN
 * Version      :   1.0.0
 */
// Format for datepicker
var date_option = { format: 'DD/MM/YYYY', minDate: '1900', maxDate: '9999' };
// Format for monthpicker
var month_option = { format: 'MM/YYYY', minDate: '1900', maxDate: '9999' };
// Convert Date to string width format dd/mm/yyyy
Date.prototype.ddmmyyyy = function() {
  var mm = this.getMonth() + 1; // getMonth() is zero-based
  var dd = this.getDate();
  return [(dd > 9 ? '' : '0') + dd,
          (mm>9 ? '' : '0') + mm,
          this.getFullYear()
         ].join('/');
};
$(document).ready(function () {
    // Gắn datepicker cho tất cả các input có class là datetimepicker
    //<div class="input-group datetimepicker">
    //    <input type="text" class="form-control date" maxlength="8" />
    //    <span class="input-group-addon">
    //        <span class="glyphicon glyphicon-calendar"></span>
    //    </span>
    //</div>
    try {
        $(".datetimepicker").datetimepicker(date_option).on("dp.show", function () {
            return $(this).data('DateTimePicker').defaultDate(new Date());
        });
    }catch(e){}
    // Gắn monthpicker cho tất cả các input có class là datetimepicker
    //<div class="input-group monthpicker">
    //    <input type="text" class="form-control date" maxlength="8" />
    //    <span class="input-group-addon">
    //        <span class="glyphicon glyphicon-calendar"></span>
    //    </span>
    //</div>
    try{
        $(".monthpicker").datetimepicker(month_option).on("dp.show", function () {
            return $(this).data('DateTimePicker').defaultDate(new Date());
        });
    } catch (e) { }
    //Hiển thị số dạng money (100,000 ) cho các thẻ cha test như span, td,...
    $('.text-money').each(function () {
        $(this).text(formatMoney($(this).text().replace(/,/g, '')));
    });
    //Sự kiện chung cho nút in
    $('#btn-print').on('click', function () {
        var printContents = document.getElementById("printableArea").innerHTML;
        var originalContents = document.body.innerHTML;
        document.body.innerHTML = printContents;
        $('body').css('height', 'auto');
        window.print();
        document.body.innerHTML = originalContents;
        window.location = window.location;
    });
    $('.lang').on('click', function () {
        $.cookie('lang', Base64.encode($(this).attr('lang')), { expires: 7, path: '/' });
        window.location = window.location;
    });
    //Khởi tạo sự kiện cho các input nhập tiền tệ
    $('.money').trigger('blur');
    //Khởi tạo sự kiện cho các input nhập số thực
    $('.decimal').trigger('blur');
});
/*
 * Sự kiện xóa thông báo lỗi khi thay đổi gái trị của input nếu input đó có lỗi
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('change', 'input, textarea', function () {
    if ($(this).val() != '') {
        $(this).removeClass('item-error');
        $(this).removeAttr('has-balloontip-message');
        $("#has-balloontip-class").remove();
    }
});
/*
 * Sự kiện xóa thông báo lỗi khi thay đổi gái trị của select nếu input đó có lỗi
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('change', 'select', function () {
    if ($(this).val() != -1) {
        $(this).removeClass('item-error');
        $(this).removeAttr('has-balloontip-message');
        $("#has-balloontip-class").remove();
    }
});
/*
 * Bôi đen tất cả giá trị trong input khi forcus vào input đó
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('focus', 'input, textarea', function () {
    $(this).select();
});
/*
 * Chuyển type của tất cả ác input nhập đa phần là số về tel
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('focus', 'input.numeric,input.money,input.date,input.phone', function (e) {
    $(this).attr('type', 'tel');
});
/*
 * Các input nhập tiền thì chỉ cho nhập số
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('keydown', 'input.money', function (event) {
    try {
        var negativeEnabled = false;
        if ($(this).attr('negative')) {
            negativeEnabled = $(this).attr('negative');
        }
        if (event.keyCode == 229) {
            $(this).val('');
        }
        if (event.keyCode == 53) {
            return true;
        }
        if (!((event.keyCode > 47 && event.keyCode < 58)
                || (event.keyCode > 95 && event.keyCode < 106)
                || event.keyCode == 116
                || event.keyCode == 46
                || event.keyCode == 37
                || event.keyCode == 39
                || event.keyCode == 8
                || event.keyCode == 9
                || event.ctrlKey
                || event.keyCode == 229)
                || (negativeEnabled == false
                && event.keyCode == 189 || event.keyCode == 109)) {
            event.preventDefault();
        }
        if (negativeEnabled && (event.keyCode == 189 || event.keyCode == 109)) {
            var val = $(this).val();
            var negative = '-' + val.replace(/-/g, '');
            $(this).val(negative);
        }
    } catch (e) {
        console.log(e.message);
    }
});
/*
 * Quy định các ký tự được nhập cho các input theo định dạng như bên dưới
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('keydown', 'input.date, input.month, input.numeric', function (event) {
    if ((!((event.keyCode > 47 && event.keyCode < 58)
            || (event.keyCode > 95 && event.keyCode < 106) // numpad
            || event.keyCode == 116 // F5
            || event.keyCode == 46 // del
            || event.keyCode == 35 // end
            || event.keyCode == 36 // home
            || event.keyCode == 37 // ←
            || event.keyCode == 39 // →
            || event.keyCode == 8 // backspace
            || event.keyCode == 9 // tab
            || event.keyCode == 191 // forward slash
            || event.keyCode == 92 // forward slash
            || event.keyCode == 111 // divide
            || (event.shiftKey && event.keyCode == 35) // shift
            || (event.shiftKey && event.keyCode == 36)
            || event.ctrlKey))
            || (event.shiftKey && (event.keyCode > 47 && event.keyCode < 58))) {
        event.preventDefault();
    }
});
/*
 * Quy định các ký tự được nhập cho các input số thực
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('blur', 'input.decimal:enabled', function () {
    try {
        var negativeEnabled = false;
        if ($(this).attr('negative')) {
            negativeEnabled = $(this).attr('negative');
        }
        if (event.keyCode == 229) {
            $(this).val('');
        }
        if (event.keyCode == 53) {
            return true;
        }
        if (!((e.keyCode > 47 && e.keyCode < 58)
				|| (e.keyCode > 95 && e.keyCode < 106)
				|| ((e.keyCode == 190 || e.keyCode == 110) && $(this).val().indexOf('.') === -1)
				|| e.keyCode == 173
				|| e.keyCode == 109
				|| e.keyCode == 189
				|| e.keyCode == 116
				|| e.keyCode == 46
				|| e.keyCode == 37
				|| e.keyCode == 39
				|| e.keyCode == 8 
				|| e.keyCode == 9
				|| e.keyCode == 229
				|| ($.inArray(e.keyCode,[ 65, 67, 86, 88, 116 ]) !== -1 && e.ctrlKey === true)
				|| ($.inArray(e.keyCode,[9]) !== -1 && e.shiftKey === true)
				|| (e.keyCode >= 35 && e.keyCode <= 39)
                || (negativeEnabled == true
                && event.keyCode == 189 || event.keyCode == 109))) {
            event.preventDefault();
        }
        if (negativeEnabled && (event.keyCode == 189 || event.keyCode == 109)) {
            var val = $(this).val();
            var negative = '-' + val.replace(/-/g, '');
            $(this).val(negative);
        }
    } catch (e) {
        console.log(e.message);
    }
});
/*
 * Khi focus vào input nhập ngày tháng thì sẽ xóa hết các dấu phân cách và chỉ cho nhập số
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('focus', 'input.date', function () {
    try{
        var string = $(this).val();
        var reg = /^[0-9]{2}[\/.][0-9]{2}[\/.][0-9]{4}$/;
        if (string.match(reg)) {
            $(this).val(string.replace(/\D/g, ''));
        }
    } catch (e) {
        console.log(e.message);
        $(this).val('');
    }
});
/*
 * Tự động thêm các dấu phân cách sau khi đã nhập ngày tháng và blur ra khỏi input nhập
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('blur', 'input.date ', function () {
    try{
        var string = $(this).val();
        var reg1 = /^[0-9]{8}$/;
        var reg2 = /^[0-9]{2}[\/.][0-9]{2}[\/.][0-9]{4}$/;
        if (string.match(reg1)) {
            $(this).val(
                    string.substring(0, 2) + '/'
                            + string.substring(2, 4) + '/'
                            + string.substring(4));
        } else if (string.match(reg2)) {
            $(this).val(string);
        } else {
            $(this).val('');
        }
        if (!validateDate($(this).val())) {
            $(this).val('');
        }
    } catch (e) {
        console.log(e.message);
        $(this).val('');
    }
});
/*
 * Khi focus vào input nhập tiền tệ thì sẽ xóa hết các dấu phân cách và chỉ cho nhập số
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('focus', 'input.money', function () {
    $(this).val($(this).val().replace(/,/g, ''));
    $(this).select();
});
/*
 * Tự động thêm các dấu phân cách phần ngàn sau khi đã nhập tiền và blur ra khỏi input nhập
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('blur', 'input.money', function () {
    try{
        if ($(this).val() == '') {
            return;
        }
        var val = parseInt($(this).val());
        if (isNaN(val) || val == 0) {
            $(this).val('');
            return;
        }
        $(this).val(formatMoney(val));
    } catch (e) {
        console.log(e.message);
        $(this).val('');
    }
});
/*
 * Tự động kiểm tra gái trị numeric khi blur
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('blur', 'input.numeric', function () {
    try {
        if (!validateNumber($(this).val())) {
            $(this).val('');
        }
    } catch (e) {
        console.log(e.message);
    }
});
/*
 * Khi blur ra khỏi input nhập số thực thì sẽ cho giá trị trong input hiển thị theo định dạng 123,456.12
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).on('blur','input.decimal:enabled',function() {
    try {
        var negativeEnabled 	= $(this).attr('negative');
        var val 				= $(this).val();
        if (typeof val != undefined && val != ''){
            var negative 			= val.indexOf('-') > -1;
            var negative_1			= val.indexOf('－') > -1;
            if (negative || negative_1) {
                val = val.substring(1);
            }
            var old = val;
            val = val.replace('.', '');
            val = old;
            var dc = 1 * $(this).attr('decimal');
            var result = parseFloat(val.replace(/,/g, ""));
            if (result || result === 0) {
                result = result.toFixed(dc);
                if (result.indexOf('.') > -1) {
                    var integer = result.substring(0,result.indexOf('.')).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                    var decimal = result.substring(result.indexOf('.'));
                    var ml = typeof $(this).attr('maxlength') != 'undefined' ? parseInt($(this).attr('maxlength')) : 0;
                    if(ml > 0 && integer.length > (ml-2)){
                        var num = ml-dc-1;
                        var tmp = $(this).val().replace('.', "");
                        integer = parseFloat(tmp.substring(0,num));
                        decimal = parseFloat('0.'+tmp.substring(num,num+dc));
                    }
                    val = integer + decimal;
                } else {
                    val = result.replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                }
            } else {
                val = '';
            }
            if(!isNaN(val)){
                $(this).val((val != '' && val != '0' && val != 'NaN' && negativeEnabled && negative) ? ('-' + val) : val);	
            }else{
                $(this).val('');
            }
        }
    } catch (e) {
        console.log(e.message);
    }
});
/*
 * Xóa thông báo lỗi của 1 input
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   item - string - id của input cần xóa
 * Param        :   msg - string - loại message cần xóa
 * Output       :   
 */
function clearErrorItem(item, msg) {
    try {
        var err = $(item).attr("has-balloontip-message");
        if (msg === err) {
            $(item).removeAttr("has-balloontip-message");
            $(item).removeClass('item-error');
            $("#has-balloontip-class").remove();
        }
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Clear Error Item:</b> ' + e.message, 4);
    }
}
/*
 * Xóa tất cả thông báo lỗi của 1 input
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   input - string - id của input cần xóa
 * Output       :   
 */
function clearError(input) {
    try {
        $(input).removeAttr("has-balloontip-message");
        $(input).removeClass('item-error');
        $("#has-balloontip-class").remove();
    } catch (e) {
        Message(0, function (ok) {
        }, '<b>Clear Error:</b> ' + e.message, 4);
    }
}
/*
 * Xóa tất cả thông báo lỗi của tất cả input trong 1 vùng nhất định
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   input - string - id của vùng có các input cần xóa
 * Output       :   
 */
function clearAllError(selector) {
    try {
        $(selector).find('.item-error').each(function () {
            $(this).removeAttr("has-balloontip-message");
            $(this).removeClass('item-error');
        });
        $("#has-balloontip-class").remove();
    } catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Clear All Error:</b> ' + e.message, 4);
    }
}
/*
 * Kiểm tra 1 chuỗi có phải là chuỗi số hay không
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   string - string - chuỗi cần kiểm tra
 * Output       :   bool - kết quả kiểm tra (true: là chuổi chỉ chứa số, false: là chuỗi có chứa ký tự khác ngoài số)
 */
function validateNumber(string) {
    try {
        var regexp = /^-*[0-9]+$/;
        if (regexp.test(string) || string == '') {
            return true;
        } else {
            return false;
        }
    } catch (e) {
        jMessage(0, function (ok) {
            return false;
        }, '<b>Validate Number:</b> ' + e.message, 4);
    }
}
/*
 * Kiểm tra 1 chuỗi có phải là email hay không
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   string - string - chuỗi cần kiểm tra
 * Output       :   bool - kết quả kiểm tra (true: là email, false: không phải là email)
 */
function validateEmail(string) {
    try{
        if (string === '') {
            return false;
        }
        var patt = /^[\w-.+]+@[a-zA-Z0-9_-]+?\.[a-zA-Z0-9._-]*$/;
        return patt.test(string);
    } catch (e) {
        jMessage(0, function (ok) {
            return false;
        }, '<b>Validate Email:</b> ' + e.message, 4);
    }
}
/*
 * Kiểm tra 1 chuỗi có phải là ngày tháng không (định dạng dd/MM/yyyy)
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   string - string - chuỗi cần kiểm tra
 * Output       :   bool - kết quả kiểm tra (true: là ngày tháng, false: không phải là ngày tháng)
 */
function validateDate(string) {
    try{
        if (string == '') {
            return true;
        }
        if (string.length == 8) {
            string = string.substring(0, 2) + '/' + string.substring(2, 4) + '/'
                    + string.substring(6);
        }
        var reg = /^(31[\/.](0[13578]|1[02])[\/.]((19|[2-9][0-9])[0-9]{2}))|((29|30)[\/.](01|0[3-9]|1[0-2])[\/.](19|[2-9][0-9])[0-9]{2})|((0[1-9]|1[0-9]|2[0-8])[\/.](0[1-9]|1[0-2])[\/.](19|[2-9][0-9])[0-9]{2})|(29[\/.](02)[\/.](((19|[2-9][0-9])(04|08|[2468][048]|[13579][26]))|2000))$/;
        if (string.match(reg)) {
            return true;
        } else {
            return false;
        }
    } catch (e) {
        jMessage(0, function (ok) {
            return false;
        }, '<b>Validate Date:</b> ' + e.message, 4);
    }
}
/*
 * Kiểm tra khoảng thời gian từ ngày bắt đầu đến ngày kết thúc có đúng không, nếu ngày bắt đầu lớn hơn ngày kết thúc thì trả về là sai
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   inputDateFrom - string - ngày bắt đầu (dd/MM/yyyy)
 * Param        :   inputDateTo - string - ngày kết thúc (dd/MM/yyyy)
 * Output       :   bool - kết quả kiểm tra
 */
function validateFromToDate(inputDateFrom, inputDateTo) {
    try {
        var lang = getLang();
        var from = $(inputDateFrom).val();
        var to = $(inputDateTo).val();
        if (from != '' && to != '') {
            var fromDate = new Date(parseInt(from.substring(6), 10),
                                    parseInt(from.substring(3, 5), 10) - 1,
                                    parseInt(from.substring(0, 2), 10));
            var toDate = new Date(parseInt(to.substring(6), 10),
                                  parseInt(to.substring(3, 5), 10) - 1,
                                  parseInt(to.substring(0, 2), 10));
            if (fromDate.getTime() > toDate.getTime()) {
                $(inputDateFrom).errorStyle(_text[lang][7]);
                $(inputDateTo).errorStyle(_text[lang][7]);
                return false;
            }
        }
        return true;
    } catch (e) {
        jMessage(0, function (ok) {
            return false;
        }, '<b>Validate From To Date:</b> ' + e.message, 4);
    }
}
/*
 * Kiểm tra 1 chuỗi có phải là Password (có chữ thường, chữ hoa,số, độ dài >=8 )
 * Author       :   HangNTD - 16/06/2018 - create
 * Param        :   string - string - chuỗi cần kiểm tra
 * Output       :   bool - kết quả kiểm tra (true: là Password, false: không phải là Password)
 */
function validatePassword(string) {
    try {
        if (string === '') {
            return false;
        }
        var patt = /^(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*\d).*$/;
        return patt.test(string);
    } catch (e) {
        jMessage(0, function (ok) {
            return false;
        }, '<b>Validate Password:</b> ' + e.message, 4);
    }
}
/*
 * Kiểm tra đã chọn giới tính chưa
 * Author       :   HangNTD - 18/06/2018 - create
 * Param        :   string - string - chuỗi cần kiểm tra
 * Output       :   bool - kết quả kiểm tra (true: thõa mãn, false: không thỏa mãn)
 */
function validateGender(string) {
    try {
        if (string == '') {
            return false;
        }
        else return true;

    } catch (e) {
        jMessage(0, function (ok) {
            return false;
        }, '<b>Validate Date:</b> ' + e.message, 4);
    }
}

/*
 * Kiểm tra dữ liệu nhập của tất cả các input trong 1 vùng theo id
 * 1. Kiểm tra bắt buột - input có class required
 * 2. Kiểm tra lớn hơn 0 - input có class gr-zero
 * 3. Kiểm tra maxlength - input có thuộc tính maxlength
 * 4. Kiểm tra email - input có type = email
 * 5. Kiểm tra định dạng ngày tháng (dd/MM/yyyy) - input có class date
 * 33.Kiểm tra password - input có type = password
 * Author       :   DungNTP - 24/09/2017 - create
 * Update       :   HangNTD - 16/06/2018
 * Param        :   id - string - id của vùng có các input cần kiểm tra
 * Output       :   bool - kết quả kiểm tra (true: có lỗi, flase: không có lỗi)
 */
function validate(selector) {
    var error = false;
    try {
        clearAllError(selector);
        var lang = getLang();
        $(selector).find('.required').each(function () {
            var val = $(this).val() + '';
            if (val === '' || val === '-1') {
                $(this).errorStyle(msg_required);
                error = true;
            }
        });
        $(selector).find('.gr-zero').each(function () {
            var val = parseInt($(this).val());
            if (!isNaN(val) && val <= 0) {
                $(this).errorStyle(_text[lang][11]);
                error = true;
            }
        });
        $(selector).find('input[type=text],input[type=tel],input[type=password],textarea').each(function () {
            var maxlength = $(this).attr('maxlength')
            if (maxlength != undefined && maxlength != null && (maxlength + '' != '')) {
                val = $(this).val() + '';
                if ($(this).hasClass('money')) {
                    val = val.replace(/,/g, '');
                }
                if ($(this).hasClass('date')) {
                    val = val.replace(/\//g, '');
                }
                if (val.length > maxlength) {
                    $(this).errorStyle(_text[lang][2]);
                    error = true;
                }
            }
        });
        $(selector).find('input[type=email]').each(function () {
            if (!validateEmail($(this).val())) {
                $(this).errorStyle(_text[lang][5]);
                error = true;
            }
        });
        $(selector).find('.format-date').each(function () {
            if (!validateDate($(this).val())) {
                $(this).errorStyle(_text[lang][4]);
                error = true;
            }
        });
        $(selector).find('input[type=password]').each(function () {
            if (!validatePassword($(this).val())) {
                $(this).errorStyle(_text[lang][33]);
                error = true;
            }
        });
        $(selector).find('.gender').each(function () {
            var abc = $(this).val();
            if (!validateGender($(this).val())) {
                $(this).errorStyle(_text[lang][34]);
                error = true;
            }
        });
    } catch (e) {
        error = true;
        jMessage(0, function (ok) {
        }, '<b>Validate:</b> ' + e.message, 4);
    }
    return error;
}
function fillError(errors) {
    try {
        for (var err in errors) {
            if (errors.hasOwnProperty(err)) {
                $('[name="' + err + '"]').errorStyle(errors[err]);
            }
        }
    } catch (e) {
        error = true;
        //jMessage(0, function (ok) {
        //}, '<b>Fill Error:</b> ' + e.message, 4);
    }
}
/*
 * Định dạng 1 chuỗi thành chuỗi tiền tề
 * Author       :   DungNTP - 24/09/2017 - create
 * Param        :   num - string - chuỗi cần định dạng
 * Output       :
 */
function formatMoney(num) {
    try{
        var str = num.toString(), parts = false, output = [], i = 1, formatted = null;
        if (str.indexOf(".") > 0) {
            parts = str.split(".");
            str = parts[0];
        }
        str = str.split("").reverse();
        for (var j = 0, len = str.length; j < len; j++) {
            if (str[j] != ",") {
                output.push(str[j]);
                if (i % 3 == 0 && j < (len - 1)) {
                    output.push(",");
                }
                i++;
            }
        }
        formatted = output.reverse().join("");
        return (formatted.replace('-,', '-') + ((parts) ? "." + parts[1].substr(0, 2) : ""));
    } catch (e) {
        jMessage(0, function (ok) {
            return '';
        }, '<b>Format Money:</b> ' + e.message, 4);
    }
}
/*
 * Change link in url dont need load page
 * Author       :   DungNP - 24/02/2018 - create
 * Param        :   
 * Output       :
 */
function ChangeUrl(page, url) {
    if (typeof (history.pushState) != "undefined") {
        var obj = { Page: page, Url: url };
        history.pushState(obj, obj.Page, obj.Url);
    } else {
        alert("Browser does not support HTML5.");
    }
}
/*
 * Reset value of form such as begin
 * Author       :   DungNP - 24/02/2018 - create
 * Param        :   
 * Output       :
 */
function resetValue(id) {
    try {
        $('#' + id).find('.field-validation-error').each(function () {
            $(this).empty();
        });
        $('#' + id).find('select').each(function () {
            $(this).val($(this).find('option:first').val());
        });
        $('#' + id).find('input').each(function () {
            $(this).val('');
        });
        $('#' + id).find('error').each(function () {
            $(this).val('');
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
            return '';
        }, '<b>Reset Value:</b> ' + e.message, 4);
    }
}
/*
 * Sự kiện được gọi trước khi ajax khởi chạy, dùng để hiển thị màn hình loading lúc gọi ajax
 * Author       :   QuyPN - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).ajaxStart(function () {
    callLoading();
});
/*
 * Sự kiện được gọi sau khi ajax chạy xong, dùng để tắt màn hình loading sau khi gọi ajax
 * Author       :   QuyPN - 24/09/2017 - create
 * Param        :
 * Output       :
 */
$(document).ajaxComplete(function () {
    closeLoading();
});

function callLoading() {
    $('#call-ajax-fade').addClass('load-ajax-fade');
    $('#call-ajax-content').addClass('load-ajax-content');
}

function closeLoading() {
    $('#call-ajax-fade').removeClass('load-ajax-fade');
    $('#call-ajax-content').removeClass('load-ajax-content');
}
/*
 * Get language from cookie
 * Author       :   QuyPN - 26/05/2018 - create
 * Param        :
 * Output       :   language code
 */
function getLang() {
    try {
        var lang =Base64.decode($.cookie('lang'));
        if (lang != 'vi' && lang != 'en') {
            return 'vi';
        }
        return lang;
    }
    catch (e) {
        return 'vi';
    }
}
/*
 * 
 * Author       :   
 * Param        :
 * Output       :   thông báo hoàn chỉnh
 */

function createMessage(msgNo, text1, text2, text3) {
    try {
        var Lang = getLang();
        console.log(msgNo,Lang);
        console.log(_text[Lang][msgNo].replace('{0}', text1).replace('{1}', text2).replace('{2}', text3));
        return _text[Lang][msgNo].replace('{0}', text1) .replace('{1}', text2).replace('{2}', text3);

    } catch (e) {
        console.log(e);
        return _text[Lang][msgNo];
    } 
}
