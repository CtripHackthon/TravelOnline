(function (site, $, undefined) {
    // Top navigation bar
    site.init = new function () {

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