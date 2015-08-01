(function (site, $, undefined) {
    // Top navigation bar
    site.init = function (sessionUser) {

        $(window).scroll(function () {
           scrollHide();
            if ($(this).scrollTop() > 500) {
                if (!$('#top-header').hasClass('header-hide')) {
                    $('#top-header').addClass('header-hide');
                }
            } else {
                $('#top-header').removeClass('header-hide');
            }
        });

        function scrollHide() {
            $('.nav-dropdown').children().removeClass('visible');
        }

        $('.nav-dropdown').live('click', function (e) {
            //取消事件冒泡  
            e.stopPropagation();
            $(this).find('.dropdown-menu').toggleClass('visible');
            $(this).siblings().find('.dropdown-menu').removeClass('visible');
        });
    
        // user login status
        site.Top.userLoad(sessionUser);
        site.Top.init();
      

    }
    site.Top = new function () {

        this.init = function () {
            $('.username').live('click', function (e) {
                e.preventDefault();
                if ($('#userbehavior').hasClass('hide')) {
                    $('#userbehavior').removeClass('hide');
                }
                else {
                    $('#userbehavior').addClass('hide');
                }
            });
            $('.signoff').live('click', function (e) {
                var baseurl = "http://" + window.location.hostname + ':' + window.location.port;

                $.ajax({
                    url: baseurl + '/Ajax/UserAjax.aspx',
                    cache: false,
                    type: 'Get',
                    data: { queryType: 'signoff' },
                    dataType: 'json',
                    timeout: 60000,
                    beforeSend: function () {
                    },
                    complete: function () {
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert('status :' + XMLHttpRequest.status + '; readyState:' + XMLHttpRequest.readyState + '; textStatus:' + textStatus);
                    },
                    success: function (result) {
                        window.location.href = "../Home.aspx";
                    }
                });
            });
        }
        this.userLoad = function (sessionUser) {
            if (sessionUser != null && sessionUser != "") {
                $('#usersession').val(sessionUser);
                // logined user
                $('.right-bar ul').remove();

                var userlogo = '<svg xmlns="http://www.w3.org/2000/svg" class="si-glyph-person-people" style="height: 20px;width: 20px;">' +
                '<use xlink:href="../Plugins/fonts/sprite.svg#si-glyph-person-people" style="height: 14px; width:15px" />' +
            '</svg>';
                var str = '<ul><li class="li-after"><a href="../Account/PersonalBoard.aspx" class="login">' + userlogo + '</a></li><li style="padding-left:10px"><a href="#" class="has-drop-menu login username">' + sessionUser + '</a> </li><li class="hide" id="userbehavior" style="margin-top:10px"><a class="signoff">注销</a></li> </ul>';

                $('.right-bar').append(str);
            }
        }

       

        
    }

    // Registration and login 
    site.login = new function () { }
    site.registration = new function () { }
    // Footer 
    site.footer = new function () { }
    // Others
    site.Util = new function () {
    }


})(window.site = window.site || {}, $, undefined);