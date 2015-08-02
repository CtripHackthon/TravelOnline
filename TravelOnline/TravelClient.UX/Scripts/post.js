(function (post, $, undefined) {
    post.Init = function () {

        var myDate = new Date();
        myDate.getYear();      //获取当前年份(2位)  
        myDate.getFullYear(); //获取完整的年份(4位,1970-????)  
        myDate.getMonth();      //获取当前月份(0-11,0代表1月)  
        myDate.getDate();      //获取当前日(1-31)  
        myDate.getDay();        //获取当前星期X(0-6,0代表星期天)  
        myDate.getTime();      //获取当前时间(从1970.1.1开始的毫秒数)  
        myDate.getHours();      //获取当前小时数(0-23)  
        myDate.getMinutes();    //获取当前分钟数(0-59)  
        myDate.getSeconds();    //获取当前秒数(0-59)  
        myDate.getMilliseconds(); //获取当前毫秒数(0-999)  
        myDate.toLocaleDateString();    //获取当前日期  
        var mytime = myDate.getFullYear() + "-" + myDate.getMonth() + "-" + myDate.getDate();    //获取当前时间

        var articleTitle;
        var articleCategory = {};
        var articleTags;
        var articleContent;
        var currentTime = mytime;
        var articleImages = [];

            $('.article-title-text').focus();

            $('#editor1').wangEditor({
                'uploadUrl': '../Posts/Utility/data.ashx'
            });

            // Add butoon click
            $('.addPic').live('click', function (x) {
                x.preventDefault();
                if ($('.pictureShowDiv').find('.innerPic').length > 9) {
                    alert('你已经成功上传了10个图片文件，不能继续上传了');
                    return;
                }

                $('.selectPictureWin').bPopup({ modalClose: false });
                $('.pict-items').children().remove();
            });

            // Select photo dialog
            var div_li = $("div.tab_menu ul li");
            $("div.tab_menu ul li").click(function () {
                $(this).addClass("selected")
                       .siblings().removeClass("selected");
                var index = div_li.index(this);
                $("div.tab_box > div")
                        .eq(index).show()
                        .siblings().hide();
            }).hover(function () {
                $(this).addClass("hover");
            }, function () {
                $(this).removeClass("hover");
            });

            // Save reset actions
            $('.resetBt').live('click', function () {
                // Remove the pictures this time customer has uploaded
                var currentReports = [];
                $.each($('.innerPic'), function (index, current) {
                    currentReports.push($(current).attr('src'));
                });
               RemoveImage(currentReports, $('.tab_box'), function (result) {
                    // DO - Nothing
                });
                $('.pict-items').val('');
                $('.cleanZone').show();
                $('#loadFileBt').val('');
                $('.secondAddPicBt').hide();
                $('.selectPictureWin').bPopup().close();
            });

            $('.okBt').live('click', function () {
                var str = "";

                // If current selected picture and the existing picture count added up greater than 9, then we will disable adding
                var added_pics = $('.pict-items').find('.innerPic');
                var existing_pics = $('.pictureShowDiv').find('.innerPic');
                if (added_pics.length + existing_pics.length > 10) {
                    var alertMsg = '你已成功上传' + existing_pics.length + ' 照片，本次上传最多' + (10 - existing_pics.length);
                    alert(alertMsg);
                    return;
                }

                $('.selectPictureWin').bPopup().close();
                $('.cleanZone').show();
                $('.secondAddPicBt').hide();

                // Add the picture div to the 
                $.each(added_pics, function (index, current) {
                    str += "<li><div class='item'><input type='image' class='innerPic' src='" + $(current).attr('src') + "' /><div class='removePicture'> <svg xmlns='http://www.w3.org/2000/svg' class='si-glyph-basket-error' style='height: 20px;width: 20px; margin-left:40px;margin-right:8px'><use xlink:href='../Plugins/fonts/sprite.svg#si-glyph-basket-error' /></svg>删除</div></div></li>";
                });

                $('.pictureShowDiv ul').append(str);
                $('.pictureShowDiv').show();
            });

            var fileinput = $('#loadFileBt').browseElement();

            // Upload image dialog
            $(fileinput).change(function () {
                var str = '';
                    var file = $(fileinput)[0].files['0'];

                    if (file != null) {
                        var alertBool = false;
                        if (file.type.toLowerCase().indexOf('gif') > 0) {
                            // GIF file max is 3M
                            if (file.size > 3145728) {
                                alertBool = true;
                            }
                        }
                        else {
                            if (file.size > 3145728 * 5) {
                                alertBool = true;
                            }
                        }
                        if (alertBool) {
                            $('#loadFileBt').val('');
                            alert('你的图片文件太大，JPG/JPEG/BMP/PNG，最大15M，GIF最大3M');
                        }
                        else {
                            $('.cleanZone').hide();
                            $('.secondAddPicBt').show();
                            // Call the api ajax method to upload the picture to the server 
                            var imagePath = $('#loadFileBt').val();
                            var imageData = { PicturePath: imagePath, PictureSize: file.size, FileName: file.name };
                            UploadImage(file, $('.tab_box'), function (result) {
                                // show the picture in the demo zone
                                str = "<li><div class='pict-item'><div class='pict-head'><input type='image' class='innerPic' src='" + result + "' /></div><div class='pict-actions removePicture'><svg xmlns='http://www.w3.org/2000/svg' class='si-glyph-basket-error' style='height: 20px;width: 20px; margin-left:40px;margin-right:8px'><use xlink:href='../Plugins/fonts/sprite.svg#si-glyph-basket-error' /></svg>删除</div></div></li>";
                                $('.pict-items').append(str);
                            });
                        }
                    }
                    
            });
            function UploadImage(pictureData, loadingArea, callBack) {
                var baseUrl = GetBaseUrl();
                $.upload(baseUrl + "?queryType=addPicture", pictureData,callBack);
            };
            function RemoveImage(pictureData, loadingArea, callBack) {
                var baseUrl = GetBaseUrl();

                $.ajax({
                    url: baseUrl + "?queryType=removePicture",
                    type: "POST",
                    dataType: "json",
                    data: { queryParam: JSON.stringify(pictureData) },
                    timeout: 99000,
                    beforeSend: function () {
                        //loadingArea.showLoading()();
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    },
                    success: function (result) {
                        if (callBack) {
                            callBack(result);
                        }
                    },
                    complete: function () {
                        loadingArea.hideLoading();
                    },
                });
            };
            function GetBaseUrl() {
                var url = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/PostAjax.aspx';
                return url;
            }
            // Remove one picture from the list
            $('.removePicture').live('click', function (x) {
                // Send ajax request to server to remove this image
                x.preventDefault();
                var removedPictureList = [];

                var itemParent = $(this).parentsUntil('li');
                var currentPictSrc = itemParent.find('.innerPic').attr('src');
                removedPictureList.push(currentPictSrc);
                RemoveImage(removedPictureList, $('.tab_box'), function (result) {
                    itemParent.remove();
                });
            });

            // Remove one picture from the list
            $('.addPicBt').live('click', function (e) {
                e.preventDefault();
                $(fileinput).trigger('click');
            });
            $('#addNewPict').live('click', function () {
                // Get current pictures
                if ($('.pict-items').children().length == 10) {
                    alert('你已经上传了8张图片，本次不再支持上传');
                    $(this).hide();
                    $('.okBt').focus();
                }
                else {
                    $(fileinput).trigger('click');
                }
            });

            $('#addnewtag').live('click', function (e) {
                $('.addtagdiv').bPopup();
            });

            $('#savetag').live('click', function (e) {
                // send post to add tag
                articleTags += $('#tagname').val()+";";
                // show tags in th list
                var str2 = "<li><a class='newtaga'>" + $('#tagname').val() + "</a></li>";
                $('#addedtags').append(str2);
                $('.addtagdiv').bPopup().close();
            });

            $('#canceltag').live('click', function (e) {
                $('.addtagdiv').bPopup().close();
            });

            $('.category').live('click', function (e) {
                var baseUrl = GetBaseUrl();
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
                        if (result != null) {
                            var str = "";
                            $.each(result, function(index,current){
                                str += "<option valuetag='" + current.categoryId + "'>" + current.categoryName + "</option>";
                            });

                            $('.category').append(str);
                        }
                    },
                    complete: function () {
                        //loadingArea.hideLoading();
                    },
                });

            });

            $('.category option').live('click', function (e) {
                articleCategory = { categoryId: $(this).attr('valuetag'), categoryName: $(this).val()};
            });
            $('#submitarticle').live('click', function (e) {
                var baseUrl = GetBaseUrl();

                $.each($('.pict-show-in-body .innerPic'), function (index, current2) {
                    if ($(current2).attr('src') != '') {
                        articleImages.push($(current2).attr('src'));
                    }
                });
                var article = {
                    userId: $('#usersessionid').val(),
                    title: $('.article-title-text').val(),
                    content: HTMLEncode($('#editor1').val()),
                    tags: articleTags,
                    belongCategory: articleCategory,
                    addrs: articleImages,
                    publishTime: currentTime
                };


                $.ajax({
                    url: baseUrl + "?queryType=savearticle",
                    type: "POST",
                    dataType: "json",
                    data: { queryParam: JSON.stringify(article) },
                    timeout: 99000,
                    beforeSend: function () {
                       // //loadingArea.showLoading()();
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    },
                    success: function (result) {
                        if (result != null) {
                            alert(result);
                            window.location.href = "../Posts/PostDetail.aspx?id="+result;
                        }
                    },
                    complete: function () {
                       // loadingArea.hideLoading();
                    },
                });
            });

            $('#cancelArticle').live('click', function (e) {
                window.location.href = "../Account/PersonalBoard.aspx";
            });

          function HTMLEncode (html) {
                var temp = document.createElement("div");
                (temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
                var output = temp.innerHTML;
                temp = null;
                return output;
            }
          function HTMLDecode(text) {
                var temp = document.createElement("div");
                temp.innerHTML = text;
                var output = temp.innerText || temp.textContent;
                temp = null;
                return output;
            }

    }
})(window.post = window.post || {}, $, undefined);