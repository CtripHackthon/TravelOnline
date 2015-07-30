(function () {
    var doc = $(document), w = $(window).width(); createSider(); sidelogin(); changeHeight(); doc.on('click', '#sider_login', function () { loginCas(); }); $(window).resize(function () { w = $(window).width(); changeHeight(); siderNavPos(); }); doc.on('click', '.JS_gotop', function () { $('html,body').animate({ scrollTop: '0px' }, 300); }); $(document).on('click', '.JS_close-sider', function () { var me = $(this), siderBox = me.parents('.global-sider'); siderBox.find('.global-apphide').fadeOut(); siderBox.animate({ right: -36 + 'px' }, 300, function () { me.next('.global-open-sider').animate({ left: -70 + 'px' }, 300); }); }); $(document).on('click', '.JS_open-sider', function () { var me = $(this); me.animate({ left: 80 + 'px' }, 300, function () { me.parents('.global-sider').animate({ right: 0 }, 300); }); }); function loginCas() { window.location = "http://login.lvmama.com/nsso/login?service=" + encodeURIComponent(document.location) }; function createSider() {
        var str = ("<div class=\"global-sider\">") +
        ("<div class=\"global-sider-app JS_siderbox\">") +
        ("<div class=\"JS_global-sider-btn\"><span><i class=\"lv_icon icon-flower\"></i></span>") +
        ("<span><i class=\"lv_icon icon-global-app\"></i></span>") +
        ("<strong>APP</strong></div>") +
        ("<div class=\"global-apphide JS_global-sider-hide\" style=\"display:block\">") + "<img src=\"http://pic.lvmama.com/img/v6/index_sider_app.png\" width=\"80\" height=\"172\"> " +
        ("<i class=\"global-sider-now\"></i>") +
        ("</div></div>") +
        ("<div class=\"newlogin\"></div>") +
        ("<div class=\"global-sider-bottom\">") +
        ("<a class=\"global-sider-fankui\" href=\"http://www.lvmama.com/userCenter/user/transItfeedBack.do\" target=\"_blank\"><i class=\"lv_icon icon_fankui\"></i><em>\u53cd\u9988</em></a>") +
        ("<span class=\"global-sider-gotop JS_gotop\"><i class=\"lv_icon icon_sider_gotop\"></i><em>TOP</em></span>") + "<span class=\"JS_close-sider global-close-sider\"><i class=\"lv_icon icon_sider_close\"></i></span><span class=\"JS_open-sider lv_icon global-open-sider\"></span>" +
        ("</div>") +
        ("</div>"); $('body').append(str); siderNavPos();
    }; function siderNavPos() { var openSider = $('.JS_open-sider'), globalSider = $('.global-sider'), globalApphide = $('.global-apphide'); if (w < 1280) { openSider.css({ 'left': -70 }); globalSider.css({ 'right': -36 }); globalApphide.hide(); } else { openSider.css({ 'left': 80 }); globalSider.css({ 'right': 0 }); } }; function sidelogin() {
        var username = ""; try { username = decodeURIComponent(document.cookie).match(/UN\=.+\^!\^/); } catch (e) { username = unescape(document.cookie).match(/UN\=.+\^!\^/); }; if (username != null) {
            var _message_url = "http://www.lvmama.com/message/index.php?r=PrivatePm/GetUnreadCount&callback=?"; $.getJSON(_message_url, function (json) {
                if (json.code == 200) {
                    var loginIn = ("<div class=\"my-lvmama\">") +
                    ("<a href=\"http://www.lvmama.com/myspace/index.do\">") +
                    ("<i class=\"lv_icon icon-global-use\"></i>") +
                    ("<span>\u6211\u7684\u9a74\u5988\u5988</span></a></div>") +
                    ("<div class=\"sider-msg JS_siderbox\">") +
                    ("<a class=\"JS_global-sider-btn\" href=\"http://www.lvmama.com/myspace/message.do\">") +
                    ("<i class=\"lv_icon icon-sidermsg\"></i><span>") + json.data.unreadCount +
                    ("</span></a>") +
                    ("</div>"); $('.newlogin').append(loginIn);
                }
            });
        } else { var loginbtn = ("<div class=\"global-sider-login\"><a id=\"sider_login\" href=\"javascript:;\" ><i class=\"lv_icon icon-global-use\"></i><span>\u767b\u5f55</span></a></div><a href=\"http://login.lvmama.com/nsso/register/registering.do\" class=\"global-sider-reg\"><span>\u6ce8\u518c</span></a>"); $('.newlogin').append(loginbtn); }
    }; $('.JS_siderbox').live('hover', function (event) { var showbox = $(this).find('.JS_global-sider-hide'); if (event.type == 'mouseenter') { showbox.show(); } else { showbox.hide(); } }); function changeHeight() { var h = document.documentElement.clientHeight; if (h < 550) h = 550; $('.global-sider').css('height', h + 'px'); };
})(window);