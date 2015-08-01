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
    


        if (sessionUser != null && sessionUser != "") {
            // logined user
            $('.right-bar ul').remove();

            var userlogo = '<svg xmlns="http://www.w3.org/2000/svg" class="si-glyph-person-people" style="height: 20px;width: 20px;">' +
            '<use xlink:href="../Plugins/fonts/sprite.svg#si-glyph-person-people" style="height: 14px; width:15px" />' +
        '</svg>';
            var str = '<ul><li class="li-after"><a href="#" class="login">' + userlogo + '</a></li><li style="padding-left:10px"><a href="#" class="has-drop-menu login">' + sessionUser + '</a> <ul class="dropdown-menu"><li>注销</li></ul></li> </ul>';

            $('.right-bar').append(str);
        }
      
    }
    site.Top = new function () {
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