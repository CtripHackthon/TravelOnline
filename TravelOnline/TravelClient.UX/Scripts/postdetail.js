(function (post, $, undefined) {
    post.getArticle = function () {
        // article id
        var r = window.location.search.split('=')[1];

        var url = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/PostAjax.aspx';

        $.ajax({
            url: url + "?queryType=getarticlebyid",
            type: "POST",
            dataType: "json",
            data: { id: r },
            timeout: 99000,
            beforeSend: function () {
                // //loadingArea.showLoading()();
            },
            error: function (xhr, status, error) {
                console.log(error);
            },
            success: function (result) {
                if (result != null) {
                    $('#slider').children().remove();

                    var str="";
    //                $.each(result.addrs,function(index,current){
                    
    //                    if (index == 0) {
    //                         str+= '<li style="display: list-item;" class="active">' +
    //                                          '<a target="_blank" class="con" href="#" style="background-image: url' +
    //'(' + current + ')">' +
    //'                                                <div class="overlay"></div>' +
    //'                                                <div class="title">' +
    //'                                                </div>' +
    //'                                            </a>' +
    //'                                        </li>';
    //                    }
    //                    else {
    //                         str+= '<li style="display: list-item;">' +
    //                                           '<a target="_blank" class="con" href="#" style="background-image: url' +
    //'(' + current + ')">' +
    //'                                                <div class="overlay"></div>' +
    //'                                                <div class="title">' +
    //'                                                </div>' +
    //'                                            </a>' +
    //'                                        </li>';
    //                    }

    //                });

                  //  $('#slider').append(str);

                    // load the article detail in the detail page
                    $('#articletitle').html("<a href='#'>" + result.title + "</a>");

                    $('#articledtail').html(HTMLDecode(result.content));

                    var tags = result.tags.split(';');
                    var stt = "";

                    $.each(tags, function (index, c) {
                        stt += "<li><a href='#'>"+c+"</a></li>";
                    });

                    $('.tags').append(stt);
                   
                }
            },
            complete: function () {
                // loadingArea.hideLoading();
            },
        });
    }


    function HTMLDecode(text) {
        var temp = document.createElement("div");
        temp.innerHTML = text;
        var output = temp.innerText || temp.textContent;
        temp = null;
        return output;
    }
})(window.post = window.post || {}, $, undefined);