<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalBoard.aspx.cs" Inherits="TravelClient.UX.Account.PersonalBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/personal.css" rel="stylesheet" />
    <link href="../Plugins/css/metro-bootstrap.css" rel="stylesheet" />

    <body class="metro">
        <div class="wrapper">

            <div class="header">
                <div class="metro2">
                    
                    <div class="right">
                        <div class="slider">
                            <div class="container">
                                <ul class="viewport">
                                    <li class="tileRow1"></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="contentzone">
                <div class="leftbar">
                    <h2 class="reportCategory" style="color: #000">所有游记</h2>
                    <a class="addReport" href="../Posts/NewPost.aspx">提交新游记</a>
                    <aside class="filter">
                    </aside>

                </div>
                <div class="content">
                    <div class="sorter">
                        <span>排序：</span>
                        <select class="ordersel">
                            <option value="true">游记名字 (A-Z)</option>
                            <option value="false">游记名字 (Z-A)</option>
                        </select>
                    </div>
                    <div class="last-item"></div>
                </div>
            </div>
        </div>
    </body>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/site.js"></script>
    <script src="../Plugins/scripts/jquery.showLoading.js"></script>
    <script src="../Plugins/scripts/jquery/jquery.cookie.js"></script>
    <script src="../Scripts/personal.js"></script>
    <script src="../Plugins/scripts/load-metro.js"></script>
    <script src="../Plugins/scripts/jquery.bpopup.min.js"></script>

    <!--Metro script-->
    <script src="../Plugins/scripts/jquery/jquery.widget.min.js"></script>
    <script src="../Plugins/scripts/jquery/jquery.easing.1.3.min.js"></script>
    <script src="../Scripts/docs.js"></script>
    <script src="../Plugins/scripts/metro/metro-loader.js"></script>
    <script src="../Plugins/scripts/metro.min.js"></script>
    <script type="text/javascript">

        (function (URP, $, undefined) {

            URP.ReportsGet = new function () {
                var Site = null;
                this.SiteGet = function () {
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
})(window.URP = window.URP || {}, $, undefined);
        $(function () {
            URP.criteria.TileId = 2;

            URP.ReportsGet.SiteGet();
            URP.initiate();
        });
    </script>
</asp:Content>
