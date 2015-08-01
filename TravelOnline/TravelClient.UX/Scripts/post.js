(function (post, $, undefined) {
    post.Init = function () {
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
                URP.util.RemoveImage(currentReports, $('.tab_box'), function (result) {
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
                    str += "<li><div class='item'><input type='image' class='innerPic' src='" + $(current).attr('src') + "' /><div>主图片:<input type='radio' class='set-feature-bt' name='setMain'/><input type='image' src='../Images/cycle.jpg' class='removePicture' /> </div></div></li>";
                });

                $('.pictureShowDiv ul').append(str);
                $('.pictureShowDiv').show();
            });

            // Upload image dialog
            $('#loadFileBt').live('change', function () {
                var str = '';
                if ($('#loadFileBt').val() != '') {
                    var file = $('#loadFileBt').prop('files');
                    alert(file.length);
                    var alertBool = false;
                    if (file[0].type.toLowerCase().indexOf('gif') > 0) {
                        // GIF file max is 3M
                        if (file[0].size > 3145728) {
                            alertBool = true;
                        }
                    }
                    else {
                        if (file[0].size > 3145728 * 5) {
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
                        var imageData = { PicturePath: imagePath, PictureSize: file[0].size, FileName: file[0].name };
                        UploadImage(imageData, $('.tab_box'), function (result) {
                            // show the picture in the demo zone
                            str = "<li><div class='pict-item'><div class='pict-head'><input type='image' class='innerPic' src='" + result.FilePath + "' /></div><div class='pict-actions'><input type='image' src='../Images/cycle.jpg' class='removePicture' style='margin:0px,2px;' /> </div></div></li>";
                            $('.pict-items').append(str);
                        });
                    }
                }
            });
            function UploadImage(pictureData, loadingArea, callBack) {
                var baseUrl = GetBaseUrl();
                $.ajax({
                    url: baseUrl + "?queryType=addPicture",
                    type: "POST",
                    dataType: "json",
                    data: { queryParam: JSON.stringify(pictureData) },
                    timeout: 99000,
                    beforeSend: function () {
                        loadingArea.showLoading();
                    },
                    error: function (xhr, status, error) {
                        alert('Error loading report');
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
                URP.util.RemoveImage(removedPictureList, $('.tab_box'), function (result) {
                    itemParent.remove();
                });
            });

            // Remove one picture from the list
            $('.addPicBt').live('click', function () {
                $('#loadFileBt').click();
            });
            $('#addNewPict').live('click', function () {
                // Get current pictures
                if ($('.pict-items').children().length == 10) {
                    alert('你已经上传了8张图片，本次不再支持上传');
                    $(this).hide();
                    $('.okBt').focus();
                }
                else {
                    $('#loadFileBt').click();
                }
            });

    }
})(window.post = window.post || {}, $, undefined);