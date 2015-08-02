(function (product, $, undefined) {
    product.Init = function () {
        var baseUrl = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/PostAjax.aspx';

        $.ajax({
            url: baseUrl + "?queryType=getproducts",
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
                if (result != null) {
                    var str = "";
                    $.each(result, function (index, c) {
                        str+='  <li id="" class="">' +
                    '<a class="group-pic J_hotelItem" href="../Product/ProductDetail.aspx" ' +
                        'data-cid="345040" title="' + c.productName + '" target="_blank">' +
                                                '<img src="http://images4.c-ctrip.com/target/tuangou/791/349/537/3f40bbe9e93c427e887352912b74a0f1_360_240.jpg'
                        +'" onerror="defaultImg(this)" class="group-'
                        + 'img" alt="">' +
                                        '        <div class="pic">' +



                                                    '<div class="shop-area J_ajaxEl" ' + 'style="display: none;">' +
                                                        '<span class="area"><i class="icon-area"></i>' + c.productName + '</span>' +
                        '</div>' +

                    '</div>' +
                    '<div class="shop-' + 'txt">' +
                            '<div class="shop-info">' +
                                '<p class="name">' + c.productName + '</p>' +

                                '<p class="tips">贵宾房2晚+每日双早+1次双人自助晚餐-</p>' +


           '                     <div class="grogshop-star">' +
                                    '<em class="star" title="国家旅游局评定' + '为五星级（携程用户评定为5钻）">五星级</em><em class="star" title="客户点评4.6分，总分5分。">4.6分</em>' +
                    '            </div>' +
                            '</div>' +
                            '<div class="price-set">' +
                     '           <dfn>¥</dfn><strong class="price"><b class="p_o36_0"></b><b class="p_o36_1"></b><b class="p_o36_9"></b><b ' + 'class="p_o36_9"></b></strong>' +
                        '<em class="primary-price">¥8551</em>' +
                           '     <em class="sell">已售1823</em>' +
                            '</div>' +
                        '</div>' +

                    '</a>' +
 '                   <div class="shop-tag">' +
                    '</div>' +
                '</li>';
                    });

                    $('#clisttest').append(str);
                }
            },
            complete: function () {
                //loadingArea.hideLoading();
            },
        });
    }
})(window.product = window.product || {}, $, undefined);
