(function (newpost, $, undefined) {
    newpost.Init = new function () {
        $('.newpost').live('click', function (e) {
            e.preventDefault();

            $('.selectPictureWin').showLoading();
        });

    }

})(window.newpost = window.newpost || {}, $, undefined);