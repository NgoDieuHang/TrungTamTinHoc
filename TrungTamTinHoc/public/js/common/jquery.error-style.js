
jQuery.fn.errorStyle = function (message, style) {
    try {
        return (this.each(function (index, dom) {
            try {
                message = jQuery.castString(message);
                if (message !== '') {
                    style = jQuery.castString(style);
                    if (style === '') {
                        style = 'item-error';
                    }
                    if (!jQuery(this).hasClass(style)) {
                        jQuery(this).addClass(style);
                        if (style == 'item-error') {
                            jQuery(this).balloontip(message);
                        } else {
                            jQuery(this).balloontip(message, 'focus');
                        }
                    }
                }
            } catch (e) {
                console.log('errorStyle: ' + e.message);
                return (false);
            }
        }));
    } catch (e) {
        console.log('errorStyle: ' + e.message);
        return (this.each(function (index, dom) {
        }));
    }
};
jQuery.fn.removeErrorStyle = function (style) {
    try {
        return (this.each(function (index, dom) {
            try {
                style = jQuery.castString(style);
                if (style === '') {
                    style = 'item-error';
                }
                jQuery(this).removeClass(style).removeBalloontip();
            } catch (e) {
                console.log('removeErrorStyle' + e.message);
                return (false);
            }
        }));
    } catch (e) {
        console.log('removeErrorStyle' + e.message);
        return (this.each(function (index, dom) {
        }));
    }
};
var _xOffset = 10;
var _yOffset = 0;
var _balloontipId = 'has-balloontip-class';
var _toottipAttr = 'has-balloontip-message';

function _balloontipMousefocus(event, object, callback) {
    try {
        if (jQuery('#' + _balloontipId).size() > 0) {
            jQuery('#' + _balloontipId).remove();
        }
        var balloontipMessage = jQuery
            .castString(object.attr(_toottipAttr));
        if (balloontipMessage !== '') {
            var parent = object.parent();
            var position = object.position();
            jQuery('body').append(
                '<p id="' + _balloontipId + '"><span class="arrow"></span>' + balloontipMessage
                + '</p>');

            var erroutHeight = jQuery('#' + _balloontipId).outerHeight();
            var errHeight = jQuery('#' + _balloontipId).height();
            var errlineHeight = jQuery('#' + _balloontipId).css('line-height');
            var errorgHeight = parseInt(errlineHeight) + erroutHeight - errHeight;
            var widowWidth = $(window).width();
            var left = object.offset().left + event['target'].offsetWidth - 40;
            var ballmsgWidth = jQuery('#' + _balloontipId).outerWidth();
            if (widowWidth < (left + ballmsgWidth)) {
                var right = widowWidth - object.offset().left - event['target'].offsetWidth;
                var css = {
                    'top': (object.offset().top - errorgHeight - 7) + 'px',
                    'right': right + 'px',
                    'position': 'absolute',
                    'z-index': '99999'
                };
                jQuery('#' + _balloontipId).find('span.arrow').removeClass('arrow').addClass('arrow-right');
            } else {
                var css = {
                    'top': (object.offset().top - errorgHeight - 7) + 'px',
                    'left': left + 'px',
                    'position': 'absolute',
                    'z-index': '99999'
                };
            }
            jQuery('#' + _balloontipId).css(css);

            if (callback) {
                callback(jQuery('#' + _balloontipId));
            }
            jQuery('#' + _balloontipId).fadeIn(300, null);
        }
    } catch (e) {
        console.log('balloontipMouseover' + e.message);
    }
}

function _balloontipMouseover(event, object, callback) {
    try {
        if (jQuery('#' + _balloontipId).length > 0) {
            jQuery('#' + _balloontipId).remove();
        }
        var balloontipMessage = jQuery
            .castString(object.attr(_toottipAttr));
        if (balloontipMessage !== '') {
            var parent = object.parent();
            var position = object.position();
            jQuery('body').append(
                '<p id="' + _balloontipId + '"><span class="arrow"></span>' + balloontipMessage
                + '</p>');

            var erroutHeight = jQuery('#' + _balloontipId).outerHeight();
            var errHeight = jQuery('#' + _balloontipId).height();
            var errlineHeight = jQuery('#' + _balloontipId).css('line-height');
            var errorgHeight = parseInt(errlineHeight) + erroutHeight - errHeight;
            var css = {
                'top': (object.offset().top - errorgHeight - 7) + 'px',
                'left': (object.offset().left - errorgHeight + 10) + 'px',
                'position': 'absolute',
                'z-index': '99999'
            };

            jQuery('#' + _balloontipId).css(css);

            if (callback) {
                callback(jQuery('#' + _balloontipId, parent));
            }
            jQuery('#' + _balloontipId, parent).fadeIn(300,
                null);
        }
    } catch (e) {
        console.log('balloontipMouseover' + e.message);
    }
}

function _balloontipMouseout(event, object) {
    try {
        var isFocus = $(object).is(":focus");
        if (!isFocus) {
            jQuery('#' + _balloontipId, object.parents('body')).remove();
        }
        _showErrorFocus();
    } catch (e) {
        console.log('balloontipMouseout' + e.message);
    }
}

function _balloontipMousemove(event, object, callback) {
    try {
        var parent = object.parent();

        var balloontip = jQuery('#' + _balloontipId, parent);
        var width = balloontip.outerWidth(true);
        var height = balloontip.outerHeight(true);
        var x = parseInt(event['pageX'], 10) + _xOffset;
        var y = parseInt(event['pageY'], 10) + _yOffset;
        var windowWidth = jQuery(window).width();
        var windowHeight = jQuery(window).height();
        var windowLeft = jQuery(window).scrollLeft();
        var windowTop = jQuery(window).scrollTop();
        var xOffset = 0;
        var yOffset = 0;
        if (x + width > windowWidth + windowLeft) {
            x = parseInt(windowWidth + windowLeft - width - _xOffset, 10);
            yOffset = -1 * height - 10;
        }
        if (y + height > windowHeight + windowTop) {
            y = parseInt(windowHeight + windowTop - height - _yOffset, 10);
        }
        var objectOffset = object.offset();
        var position = object.position();
        var css = {
            'left': (x - objectOffset.left - 25 + position.left) + 'px',
        };
        var erroutHeight = jQuery('#' + _balloontipId).outerHeight();
        var errHeight = jQuery('#' + _balloontipId).height();
        var errlineHeight = jQuery('#' + _balloontipId).css('line-height');
        var errorgHeight = parseInt(errlineHeight) + erroutHeight - errHeight;
        var css = {
            'top': (object.offset().top - errorgHeight - 7) + 'px',
            'left': (parseInt(event['pageX']) - 10) + 'px',
            'position': 'absolute',
            'z-index': '99999'
        };

        jQuery('#' + _balloontipId).css(css);
        if (callback) {
            callback(jQuery('#' + _balloontipId, parent));
        }

    } catch (e) {
        console.log('balloontipMousemove' + e.message);
    }
}

jQuery.fn.balloontip = function (message, option) {
    try {
        return (this.each(function (index, dom) {
            try {
                if (option == 'focus') {
                    jQuery(this).attr(_toottipAttr, message).focus(function (event) {
                        if (jQuery(this).parent().find('i.fa').length > 0) {
                            _balloontipMousefocus(event, jQuery(this), function (el) {
                                var left = el.position().left + 17;
                                el.css({ 'left': left });
                            });
                        } else {
                            _balloontipMousefocus(event, jQuery(this));
                        }
                    }).focusout(function (event) {
                        _balloontipMouseout(event, jQuery(this));
                    });

                } else {
                    jQuery(this).attr(_toottipAttr, message).mouseover(function (event) {
                        _balloontipMouseover(event, jQuery(this));
                    }).mouseout(function (event) {
                        _balloontipMouseout(event, jQuery(this));
                    }).focusout(function (event) {
                        _balloontipMouseout(event, jQuery(this));
                    });
                }

            } catch (e) {
                console.log('balloontip' + e.message);
                return (false);
            }
        }));
    } catch (e) {
        console.log('balloontip' + e.message);
        return (this.each(function (index, dom) {
        }));
    }
};

jQuery.fn.removeBalloontip = function () {
    try {
        return (this.each(function (index, dom) {
            try {
                jQuery(this).removeAttr(_toottipAttr).unbind('mouseover',
                    _balloontipMouseover).unbind('focus',
                    _balloontipMouseover).unbind('mouseout',
                    _balloontipMouseout).unbind('focusout',
                    _balloontipMouseout);

                jQuery('#' + _balloontipId).remove();
            } catch (e) {
                console.log('removeBalloontip' + e.message);
                return (false);
            }
        }));
    } catch (e) {
        console.log('removeBalloontip' + e.message);
        return (this.each(function (index, dom) {
        }));
    }
};

jQuery.castString = function (target) {
    try {
        if (target == null) {
            return ('');
        } else {
            return (target.toString());
        }
    } catch (e) {
        console.log('castString' + e.message);
        return ('');
    }
};

function _showErrorFocus() {
    try {
        $('body').find('.item-error:focus').each(function () {
            _balloontipMouseover('', jQuery(this));
        });
    } catch (e) {
        console.log('_showErrorFocus' + e.message);
    }
}
