(function (site, home, $, undefined) {

    home.Init = function () {
        // get the category list
        var allCategories = [];

        var baseUrl = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/PostAjax.aspx';

        $('.category').children().remove();

        $.ajax({
            url: baseUrl + "?queryType=getcategory",
            type: "POST",
            dataType: "json",
            timeout: 99000,
            beforeSend: function () {
                //loadingArea.showLoading()();
            },
            error: function (xhr, status, error) {
                console.log(error);
            },
            success: function (result) {
                var str = "";
                if (result != null) {
                    $.each(result, function (index, cc) {
                        allCategories.push({ categoryId: cc.categoryId, categoryName: cc.categoryName });

                        if (index == 0) {
                            // show the categories in the list 
                            str+='<li class="active"><h3>' + cc.categoryName + '</h3></li>';
                        }
                        else {
                            str+='<li><h3>' + cc.categoryName + '</h3></li>';
                        }
                    });

                    $('#clist').append(str);
                }
            },
            complete: function () {
                //loadingArea.hideLoading();
            },
        });



        // based on the category list add tags and featured article list
        $.ajax({
            url: baseUrl + "?queryType=getpostsbycategoryid",
            type: "POST",
            dataType: "json",
            data: { category: allCategories },
            timeout: 99000,
            beforeSend: function () {
                //loadingArea.showLoading()();
            },
            error: function (xhr, status, error) {
                console.log(error);
            },
            success: function (result) {
                var str = "";
                if (result != null) {
                    $.each(result, function (index, cc) {
                     
                       
                    });
                }
            },
            complete: function () {
                //loadingArea.hideLoading();
            },
        });


    }
})(window.site = window.site || {}, window.home = window.home || {}, $, undefined);
