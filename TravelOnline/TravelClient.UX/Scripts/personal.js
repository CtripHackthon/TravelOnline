(function (URP, $, undefined) {
    URP.criteria = { TileId: 0, SiteType: 'teamsite', SortAttribute: "Title", SortAscending: true, currentPage: 0, PageSize: 10, FilterEntityList: [] };

    URP.ReportsGet = new function () {
        var Site = null;
        this.SiteGet = function () {
            alert('test');
            URP.criteria.SiteType = 'myreport';

            var criteriaString = $.cookie('criteriaString');
            if (criteriaString != null) {
                var criteriaObj = $.parseJSON(criteriaString);
                if (criteriaObj.SiteType == 'myreport') {
                    URP.criteria = criteriaObj;
                    URP.criteria.CurrentPage = 0;
                    $.removeCookie('criteriaString');
                }
            }

            URP.util.GetSite($('.header'), getSiteCallBack);
        };
        function getSiteCallBack(result) {
            var final = [];
            Site = result;
            $.each(result, function (index, content) {
                var str = "";

                var imageZone = "";
                imageZone += "<div class='container'>" +
                "  <div class='tile double live' data-role='live-tile' effect='slideLeft'>" +
                " <div class='tile-content image'>" +
                    "<img src='../Images/person/1.jpg' />" +
                "</div>" +
                "<div class='tile-content image'>" +
                    "<img src='../Images/person/2.jpg' />" +
                "</div>" +
                "<div class='tile-content image'>" +
                    "<img src='../Images/person/3.jpg' />" +
                "</div>" +
                "<div class='tile-content image'>" +
                    "<img src='../Images/person/4.jpg' />" +
                "</div>" +
                "<div class='tile-content image'>" +
                    "<img src='../Images/person/5.jpg' />" +
                "</div>" +
                "<div class='tile-status bg-dark opacity'>" +
                    "<span class='label'>";

                if (URP.criteria.TileId != 0) {
                    // Show the default selected tile
                    if (URP.criteria.TileId == content.Id) {
                        str += "<dl class='tile-selected' id='" + content.Id + "' tabindex=0><dt>" + content.ReportCount + '</dt><dd>' + content.TileName + '<dd></dl>';
                        //$('<dl class="tile tile-selected" id="' + content.Id + '" tabindex="0"><dt>' + content.ReportCount + '</dt><dd>' + content.TileName + '</dd></dl>').appendTo($('.tile-status')).appendTo($('.tileRow1'));
                    }
                    else {
                        str += "<dl class='' id='" + content.Id + "' tabindex=0><dt>" + content.ReportCount + '</dt><dd>' + content.TileName + '<dd></dl>';
                    }
                }

                else {
                    if (content.Id == 1) {
                        str += '<dl class="tile-selected" id="' + content.Id + '" tabindex="0"><dt>' + content.ReportCount + '</dt><dd>' + content.TileName + '</dd></dl>';
                    }
                    else {
                        str += '<dl class="" id="' + content.Id + '" tabindex="0"><dt>' + content.ReportCount + '</dt><dd>' + content.TileName + '</dd></dl>';
                    }
                }
                str += "</span>";

                str += "</div></div></div></div>";

                $('.tileRow1').append(imageZone + str);
            });

            $('.metro2').show();
            $('.tile').click(
                function (e) {
                    if ($(this).find('dl').hasClass("tile-selected")) {
                        return;
                    }
                    else {
                        $('.container dl').removeClass("tile-selected");
                        $(this).find('dl').addClass("tile-selected");
                    }
                    OnTileSelected();
                }
                );
            OnTileSelected();
        }
        function OnTileSelected() {
            // update the report category text
            $(".reportCategory").html($(".tile-selected").find("dd").html() + "( " + $(".tile-selected").find("dt").html() + " )");
            var tileId = 2;
            URP.criteria.TileId = tileId;
            //load the filter controls 
            URP.Report.getReport(false);
            URP.Filter.getFilter(tileId);
        }
    };

    URP.Filter = new function () {
        this.initial = function () {
            // Inite user image
            $('#oldUserPhoto').live('hover', function (e) {
                $('.edit_pic').css({ 'position': 'absolute', 'left': '0px', 'top': '30px' }).show();
            }).live('mouseleave', function () {
                $('.edit_pic').hide();
            });

            // Initiate the behaviors on the filter 
            $('.filterCollopse').live("click", function (e) {
                e.preventDefault();
                $(this).removeClass("filterCollapse").addClass("filterExpand");
                $(this).parent().children("ul").slideDown();
            });
            $('.filterExpand').live("click", function (e) {
                e.preventDefault();
                $(this).removeClass("filterExpand").addClass("filterCollapse");
                $(this).parent().children("ul").slideUp();
            });
            $('.checkAll').live("click", function (e) {
                $(this).parentsUntil('.top-ul').parent().find('input[type=checkbox]').prop('checked', $(this).prop('checked'));
            });
            $('.childFilter').live("click", function (e) {
                if (!$(this).prop('checked')) {
                    $(this).parentsUntil('.top-ul').parent().find('.checkAll').prop('checked', $(this).prop('checked'));
                }
            });

            $('.filterOK').live('click', function () {
                var exsitEmpty = false;
                var emptyText = '';
                $('.filter .filterItem').each(function () {
                    if ($(this).find('input[type=checkbox]:checked').length == 0) {
                        exsitEmpty = true;
                        emptyText = $(this).children('.filterItemText').text();
                        return false;
                    }
                });
                if (exsitEmpty) {
                    alert('请在: ' + emptyText + '中至少选择一个筛选条件!');
                    return;
                }
                //$(this).attr('disabled', 'disabled')
                onOKorClearclick();
            });
            $('.filterClear').live('click', function () {
                $('.filter input[type=checkbox]').prop('checked', true);
                onOKorClearclick();
            });
            function onOKorClearclick() {
                FetchSearchCretia();
                URP.Report.getReport();
                if ($(document).scrollTop() > $('.reportCategory').offset().top) {
                    $(document).scrollTop($('.reportCategory').offset().top);
                }
            }


            $('.checkItem').live('click', function () {
                if (!$(this).prop('checked')) {
                    //$(this).parent().parent().find('.checkAll').prop('checked', false);
                    $(this).parentsUntil('.top-ul').parent().find('.checkAll').prop('checked', false);
                }
            });
        };
        this.getFilter = function (tileId) {
            URP.util.GetFilter($('.leftbar'), tileId, GetFilterEntityList);
            function GetFilterEntityList() {
                FetchSearchCretia();
            }
        };
        function FetchSearchCretia() {
            var filterEntityList = [];
            $('.filterItem').each(function () {
                var filterEntity = {};
                filterEntity.FilterType = $(this).children('.filterItemText').attr('tag');
                filterEntity.FilterItemList = [];
                if ($(this).find('.checkAll').prop('checked')) {
                    return true;
                }

                if (filterEntity.FilterType == 'Category') {
                    filterEntity.FilterType = 'Sub Category';
                }
                if (filterEntity.FilterType == 'Team Tags') {

                    filterEntity.FilterType = 'Tag';
                }
                $(this).find('.checkItem').each(function () {
                    if ($(this).prop('checked')) {
                        var filterItem = {};
                        filterItem.Value = $(this).val();
                        filterEntity.FilterItemList.push(filterItem);
                    }
                });


                filterEntityList.push(filterEntity);
            });
            URP.criteria.FilterEntityList = filterEntityList;
        }
    };
    URP.initiate = function () {
        // Initiate the click 
        $.ajaxSetup({
            crossDomain: true,
            cache: false,
            async: true
        });
        $('.addReport, .action').live('click', function () {
            var criteriaString = JSON.stringify(URP.criteria);
            $.cookie('criteriaString', criteriaString, { expires: 1 });
        });
        $(document).scroll(function (e) {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {

                var itemNum = $('.content .list-item').length;
                if (itemNum != 0 && /^\d+$/.test(itemNum / URP.criteria.PageSize)) {
                    URP.Report.getReport(true);
                }
            }
        });
        URP.Filter.initial();
        URP.Report.initial();
    };
    URP.Report = new function () {
        this.initial = function () {
            $('.reportExpanded').live('click', function (x) {
                x.preventDefault();
                $(this).removeClass("reportExpanded");
                $(this).addClass("reportCollapse");
                // Show the short message under the table
                $(this).parent().parent().find('.item-description').show();
                $(this).parent().parent().find('.item-footer').show();
                $(this).parent().parent().find('.item-detail').slideUp();

            });

            $('.reportCollapse').live('click', function (x) {
                x.preventDefault();
                $(this).removeClass("reportCollapse");
                $(this).addClass("reportExpanded");
                //$(this).parent().parent().find('.item-description').hide();
                $(this).parent().parent().find('.item-footer').hide();
                var loadingArea = $(this).parent().parent().find('.item-detail');
                var reportId = $(this).parent().parent().find('.reportTitle').attr('tag');
                var reportHeader = $(this).parent().parent().find('.item-header');


                $(this).parent().parent().find('.item-detail').slideDown('fast', function () {
                    // Get one report detail
                    URP.util.GetReportDetail(loadingArea, reportId, function (result) {
                        loadingArea.children().remove();
                        // Load the report detail
                        var detailString = '';
                        //detailString = "<div class='detail-desc'>" + result.ReportDescription + "</div>"
                        //                + "<table style='width:100%' class='detail-table'><tbody>"
                        //                   + "<tr class='even'><td>Report Name</td><td>" + result.ReportName + "</td></tr>"
                        //                   + "<tr><td>Report Owner</td><td>" + result.ReportOwner + "</td></tr>"
                        //                   + "<tr class='even'><td>Report Status</td><td>" + result.ReprotStatus + "</td></tr>"
                        //                   + "<tr><td>Report URL</td><td>" + result.ReportURL + "</td></tr>"
                        //                + "</tbody></table>"
                        //                + "<div class=''><a href='#' class='action'>Edit</a><a href='#' class='action'>Recommend</a><a href='#' class='action'>Subscribe</a></div>";

                        var textMatches = URP.util.subContent(result.Content);

                        detailString = "<ul class='contentlist'>" +
                            "<li><img class='contentimage' src='" + textMatches.pictureSrc + "' /></li>" +
                            "<li><ul class='contentcomments'></ul></li>" +
                            "<li></li>"
                            + "</ul>"
                        loadingArea.html(detailString);
                    });
                });
            });

            $('.ordersel').change(function () {
                if ($('.content .list-item').length == 0) {
                    return;
                }
                URP.criteria.SortAscending = $(this).val();
                URP.Report.getReport();
            });

            $('.reportTitle').live('click', function (e) {
                e.preventDefault();
                alert('test');
            });
        };
        this.getReport = function (scrolling, briefCallBack, detailCallBack) {
            // Set the sort order
            $('.ordersel').val(URP.criteria.SortAscending);
            // Set the loading area
            var loadingArea;
            if (scrolling) {
                URP.criteria.currentPage++;
                loadingArea = $('.last-item');
            }
            else {
                URP.criteria.currentPage = 0;
                loadingArea = $('div .content');
            }

            if (briefCallBack) {
                URP.Report.briefCallBack = briefCallBack;
            }
            if (detailCallBack) {
                URP.Report.detailCallBack = detailCallBack;
            }

            if (URP.Report.briefCallBack) {
                briefCallBack = URP.Report.briefCallBack;
                URP.util.GetReport(loadingArea, briefCallBack);
            }

            if (URP.Report.detailCallBack) {
                URP.util.GetReport(loadingArea, detailCallBack);
            }
        };

    };


    URP.util = new function () {
        this.getOwnersFromArray = function (owners) {
            var ownerStr = "";
            $.each(owners, function (index, current) {
                ownerStr += current.UserName + ";";
            });
            return ownerStr;
        }
        this.UploadImage = function (pictureData, loadingArea, callBack) {
            var baseUrl = this.GetBaseUrl();
            alert('sending jquery request');
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
        this.RemoveImage = function (pictureData, loadingArea, callBack) {
            var baseUrl = this.GetBaseUrl();

            $.ajax({
                url: baseUrl + "?queryType=removePicture",
                type: "POST",
                dataType: "json",
                data: { queryParam: JSON.stringify(pictureData) },
                timeout: 99000,
                beforeSend: function () {
                    loadingArea.showLoading();
                },
                error: function (xhr, status, error) {
                    alert('Error removing pictures');
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
        this.GetBaseUrl = function () {
            var url = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/PersonalInformationAjax.aspx';
            return url;
        };
        this.GetSite = function (loadingArea, callBack) {
            var url1 = this.GetBaseUrl();

            // Send the ajax call 
            $.ajax({
                url: url1,
                type: 'Get',
                timeout: 9900000,
                data: { requestType: 'gettiles' },
                dataType: 'json',
                beforeSend: function () {
                    //loadingArea.showLoading();
                },
                success: function (result) {
                    if (callBack) callBack(result);
                },
                error: function (jqXHR, textStatus, errorThrown) { alert(textStatus); },

                complete: function () {
                    //loadingArea.hideLoading();
                }
            });
        };
        this.GetTeam = function (loadingArea, callBack) {
            var url1 = this.GetBaseUrl();

            // Send the ajax call 
            $.ajax({
                url: url1,
                type: 'Get',
                timeout: 9900000,
                data: { queryType: 'teamdetail', SiteGUID: GetQueryString('SiteGUID') },
                dataType: 'json',
                beforeSend: function () {
                    //loadingArea.showLoading();
                },
                success: function (result) {
                    if (callBack) callBack(result);
                },
                error: function (jqXHR, textStatus, errorThrown) { alert('ttt'); },

                complete: function () {
                    //loadingArea.hideLoading();
                }
            });
        };
        function GetQueryString(name) {
            var r = window.location.search.split('=')[1];
            return r;
        }
        this.HTMLEncode = function (html) {
            var temp = document.createElement("div");
            (temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
            var output = temp.innerHTML;
            temp = null;
            return output;
        }
        this.HTMLDecode = function (text) {
            var temp = document.createElement("div");
            temp.innerHTML = text;
            var output = temp.innerText || temp.textContent;
            temp = null;
            return output;
        }
        this.GetFilter = function (loadingArea, tileId, callBack) {
            var url = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/TeamAdminAjax?queryType=reportfilter';

            // Send the ajax call 
            $.ajax({
                url: url,
                type: 'Get',
                timeout: 30000,
                data: { tileId: tileId, SiteGuid: GetQueryString(""), siteType: URP.criteria.SiteType },
                dataType: 'json',
                beforeSend: function () {
                    loadingArea.showLoading();
                },
                success: function (result) {
                    $('.filter').html('');
                    var filterItemListString = '<h3 style="margin-top:20px;margin-bottom:10px;font-size:16px">筛选</h3>';
                    var levelOneList = null;
                    if (URP.criteria.SiteType != 'teamsite') {
                        levelOneList = result.FilterList.filter(function (x) {
                            return x.FilterType != 'Sub Category' && x.FilterType != 'Tag';
                        });
                    } else {
                        levelOneList = result.FilterList.filter(function (x) {
                            return x.FilterType != 'Sub Category' && x.FilterType != 'Team Tags';
                        });
                    }

                    var subCategoryList = result.FilterList.filter(function (x) {
                        return x.FilterType == 'Sub Category';
                    });
                    var subTeamSiteTagList = result.FilterList.filter(function (x) {
                        return x.FilterType == 'Tag' && URP.criteria.SiteType != 'teamsite';
                    });
                    $.each(levelOneList, function (outIndex, outContent) {
                        var tag = outContent.FilterType
                        var tagTrans = "";
                        if (tag == "Tag") {
                            tagTrans = '<svg xmlns="http://www.w3.org/2000/svg" class="si-glyph-tag">' +
                            '<use xlink:href="../css/sprite.svg#si-glyph-tag" />' +
                        '</svg><span>标签</span>';
                        }
                        if (tag == "Owner") {
                            tagTrans = '<svg xmlns="http://www.w3.org/2000/svg" class="si-glyph-person-2">' +
                            '<use xlink:href="../css/sprite.svg#si-glyph-person-2" />' +
                        '</svg><span>作者</span>';
                        }
                        if (tag == "Category") {
                            tagTrans = '<svg xmlns="http://www.w3.org/2000/svg" class="si-glyph-calendar-empty">' +
                           '<use xlink:href="../css/sprite.svg#si-glyph-calendar-empty" />' +
                       '</svg><span>分类</span>';
                        }


                        filterItemListString += '<div class="filterItem"><a href="#" class="filterCollopse"></a><span class="filterItemText" tag="' + tag + '">' + tagTrans + '</span>';
                        if (outContent.FilterType == 'Category') {
                            filterItemListString += '<ul ' + outContent.FilterType.replace(' ', '').toLowerCase() + ' style="padding-left:5px;" class="top-ul"><li><input  style="margin-left:10px;" class="checkAll" checked="checked" type="checkbox" value="All" /><label>全部</label></li>';
                        }
                        else {
                            filterItemListString += '<ul ' + outContent.FilterType.replace(' ', '').toLowerCase() + ' class="top-ul"><li><input class="checkAll" checked="checked" type="checkbox" value="All" /><label>全部</label></li>';
                        }
                        $.each(outContent.FilterItemList, function (innerIndex, innerContent) {
                            switch (outContent.FilterType) {
                                case 'Category':
                                    filterItemListString += ' <li title=\'' + URP.util.HTMLEncode(innerContent.Name) + '\'><a href="#" class="filterCollopse"></a><span class="filterItemText">' + innerContent.Name + '</span><ul class="leveTwoUl">';
                                    var tempCategoryItemList = subCategoryList[0].FilterItemList.filter(function (x) { return x.ParentValue == innerContent.Value });
                                    $.each(tempCategoryItemList, function (secondIndex, secondContent) {
                                        filterItemListString += ' <li title=\'' + URP.util.HTMLEncode(secondContent.Name) + '\'><input class="checkItem" type="checkbox" checked="checked"  value="' + secondContent.Value + '" /><label>' + secondContent.Name + ' (' + secondContent.Count + ')</label></li>';
                                    });
                                    filterItemListString += '</ul></li>';
                                    break;
                                case 'Team Tags':
                                    if (URP.criteria.SiteType != 'teamsite') {
                                        filterItemListString += ' <li title=\'' + URP.util.HTMLEncode(innerContent.Name) + '\'><a href="#" class="filterCollopse"></a><span class="filterItemText">' + innerContent.Name + '</span><ul class="leveTwoUl">';
                                        var tempTeamTagItemList = subTeamSiteTagList[0].FilterItemList.filter(function (x) { return x.ParentValue == innerContent.Value });
                                        $.each(tempTeamTagItemList, function (secondIndex, secondContent) {
                                            filterItemListString += ' <li title=\'' + URP.util.HTMLEncode(secondContent.Name) + '\'><input class="checkItem" type="checkbox" checked="checked"  value="' + secondContent.Value + '" /><label>' + secondContent.Name + ' (' + secondContent.Count + ')</label></li>';
                                        });
                                        filterItemListString += '</ul></li>';
                                    }
                                    break;

                                default:
                                    filterItemListString += ' <li title=\'' + URP.util.HTMLEncode(innerContent.Name) + '\'><input class="checkItem" type="checkbox" checked="checked"  value="' + innerContent.Value + '" /><label>' + innerContent.Name + ' (' + innerContent.Count + ')</label></li>';
                                    break;
                            }

                        });
                        filterItemListString += '</ul></div>';
                    });
                    if (result.FilterList.length > 0) {
                        filterItemListString += '<div class="filterApply"><input EventType="filterclick" class="filterOK" type="button" value="查找" /> <input class="filterClear" type="button" value="重置" /></div>';
                    }
                    $('.filter').html(filterItemListString);
                    $('.filterItem ul').each(function () {
                        if ($(this).find('li').length > 6) {
                            $(this).addClass('scroll');
                        }
                    });
                    if (URP.criteria.FilterEntityList.length > 0) {
                        $('.filterItem').each(function () {
                            var that = $(this);
                            var filterItemText = that.find('span.filterItemText').text();
                            if (filterItemText.indexOf('Category') > -1) {
                                filterItemText = 'Sub Category'
                            }
                            if (filterItemText.indexOf('Team Tags') > -1) {
                                filterItemText = 'Tag'
                            }
                            $.each(URP.criteria.FilterEntityList, function (index, outContent) {
                                if (filterItemText == outContent.FilterType) {
                                    that.find('input[type=checkbox]').prop('checked', false);
                                    $.each(outContent.FilterItemList, function (index, innerContent) {
                                        that.find('input[type=checkbox][value=' + innerContent.Value + ']').prop('checked', true);
                                    });
                                }
                            });
                        });
                    }
                    if (callBack) {
                        callBack(result)
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) { alert(textStatus); },

                complete: function () { loadingArea.hideLoading(); }
            });

            // Read the cookied to find which filter has been checked before this 
            if (URP.criteria.FilterEntityList.length > 0) {
                $('.filterItem').each(function () {
                    var that = $(this);
                    var filterItemText = that.find('span.parentFilter').text();

                    $.each(URP.criteria.FilterEntityList, function (index, outContent) {
                        if (filterItemText == outContent.FilterType) {
                            that.find('input[type=checkbox]').prop('checked', false);
                            $.each(outContent.FilterItemList, function (index, innerContent) {
                                that.find('input[type=checkbox][value=' + innerContent.Value + ']').prop('checked', true);
                            });
                        }
                    });
                });
            }
        };
        this.GetReport = function (loadingArea, callBack) {
            var url = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/TeamAdminAjax';

            if (URP.util.GetReport.sequenceNum == undefined) {
                URP.util.GetReport.sequenceNum = 0;
            } else {
                URP.util.GetReport.sequenceNum++;
            }
            var requestNum = URP.util.GetReport.sequenceNum;

            var url3 = url + "?queryType=reportsList&siteType=" + URP.criteria.SiteType;

            $.ajax({
                url: url3,
                type: "POST",
                dataType: "json",
                // TO-DO: Need to find the report with the query 
                data: { queryParam: JSON.stringify(URP.criteria), SiteGuid: GetQueryString("") },
                timeout: 99000,
                beforeSend: function () {

                    if (URP.util.GetReport.oncalling != true) {
                        URP.util.GetReport.oncalling = true;
                        loadingArea.showLoading();
                    }
                },
                error: function (xhr, status, error) {
                    alert('Error loading report');
                    console.log(error);
                },
                success: function (result) {
                    if (requestNum != URP.util.GetReport.sequenceNum) {
                        return;
                    }

                    if (callBack) {
                        callBack(result);
                    }
                },
                complete: function () {
                    if (requestNum != URP.util.GetReport.sequenceNum) {
                        return;
                    }
                    URP.util.GetReport.oncalling = false;
                    loadingArea.hideLoading();
                },
            });
        };
        this.GetReportDetail = function (loadingArea, reportId, callBack) {
            // Send the ajax call to the function
            var url = "http://" + window.location.hostname + ':' + window.location.port + '/Ajax/TeamAdminAjax' + "?queryType=reportDetail&reportId=" + reportId;
            $.ajax({
                url: url,
                type: "Get",
                timeout: 30000,
                dataType: "json",
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

        this.subContent = function (content) {
            var contentDesc = {};

            content = URP.util.HTMLDecode(content);
            var pattern = '<img src="(.*?)".+?>';
            var matched = content.match(pattern);

            if (matched != null) {
                contentDesc.pictureSrc = matched[1];
            }
            else {
                contentDesc.pictureSrc = "../Images/blank.jpg";
            }

            var patternLongestText = "<p>[a-z,A-Z,0-9,\u4E00-\u9FA5].+</p>";
            var matched2 = content.match(patternLongestText);
            if (matched2 != null) {
                contentDesc.descriptionText = matched2[0];
            }
            else {
                contentDesc.descriptionText = "";
            }
            return contentDesc;
        };
    };
})(window.URP = window.URP || {}, $, undefined);