<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalBoard.aspx.cs" Inherits="TravelClient.UX.Account.PersonalBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/personal.css" rel="stylesheet" />
    <link href="../Plugins/css/metro-bootstrap.css" rel="stylesheet" />
<link href="../Plugins/css/hui.css" rel="stylesheet" />
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

                     <div class="jsajaxshowpage">
        <ul class="gui_jnlist clearfix">
            <li class="gui_jnlist_item">
                <div class="gui_jnlist_item_pic">
                    <a href="http://guide.qyer.com/ha-long-bay/"
                       target="_blank" data-bn-ipg="20-1-1-1">
                        <img width="100" height="150" title="下龙湾穷游锦囊"
                             alt="下龙湾穷游锦囊" src="../Images/100_150(6).jpg">
                    </a>
                    <span class="new"></span><a title="下龙湾穷游锦囊" class="mask" href="http://guide.qyer.com/ha-long-bay/"
                                                target="_blank" data-bn-ipg="20-1-1-1"></a>
                </div>
                <p class="gui_jnlist_item_tit">
                    <a title="下龙湾" href="http://guide.qyer.com/ha-long-bay/"
                       target="_blank" data-bn-ipg="20-1-1-2">下龙湾</a>
                </p>
                <p class="gui_jnlist_item_text">越南<br>2015-07-31更新</p>
            </li>
            <li class="gui_jnlist_item">
                <div class="gui_jnlist_item_pic">
                    <a href="http://guide.qyer.com/berlin/"
                       target="_blank" data-bn-ipg="20-1-2-1">
                        <img width="100" height="150" title="柏林穷游锦囊"
                             alt="柏林穷游锦囊" src="../Images/100_150(7).jpg">
                    </a>
                    <a title="柏林穷游锦囊" class="mask" href="http://guide.qyer.com/berlin/"
                       target="_blank" data-bn-ipg="20-1-2-1"></a>
                </div>
                <p class="gui_jnlist_item_tit">
                    <a title="柏林" href="http://guide.qyer.com/berlin/"
                       target="_blank" data-bn-ipg="20-1-2-2">柏林</a>
                </p>
                <p class="gui_jnlist_item_text">德国<br>2015-07-31更新</p>
            </li>
            <li class="gui_jnlist_item">
                <div class="gui_jnlist_item_pic">
                    <a href="http://guide.qyer.com/xiamen/"
                       target="_blank" data-bn-ipg="20-1-3-1">
                        <img width="100" height="150" title="厦门穷游锦囊"
                             alt="厦门穷游锦囊" src="../Images/100_150(8).jpg">
                    </a>
                    <span class="new"></span><a title="厦门穷游锦囊" class="mask" href="http://guide.qyer.com/xiamen/"
                                                target="_blank" data-bn-ipg="20-1-3-1"></a>
                </div>
                <p class="gui_jnlist_item_tit">
                    <a title="厦门" href="http://guide.qyer.com/xiamen/"
                       target="_blank" data-bn-ipg="20-1-3-2">厦门</a>
                </p>
                <p class="gui_jnlist_item_text">福建<br>2015-07-31更新</p>
            </li>
            <li class="gui_jnlist_item">
                <div class="gui_jnlist_item_pic">
                    <a href="http://guide.qyer.com/xi%27an/"
                       target="_blank" data-bn-ipg="20-1-4-1">
                        <img width="100" height="150" title="西安穷游锦囊"
                             alt="西安穷游锦囊" src="../Images/100_150(9).jpg">
                    </a>
                    <span class="new"></span><a title="西安穷游锦囊" class="mask" href="http://guide.qyer.com/xi%27an/"
                                                target="_blank" data-bn-ipg="20-1-4-1"></a>
                </div>
                <p class="gui_jnlist_item_tit">
                    <a title="西安" href="http://guide.qyer.com/xi%27an/"
                       target="_blank" data-bn-ipg="20-1-4-2">西安</a>
                </p>
                <p class="gui_jnlist_item_text">陕西<br>2015-07-31更新</p>
            </li>
            <li class="gui_jnlist_item">
                <div class="gui_jnlist_item_pic">
                    <a href="http://guide.qyer.com/uk-railway/"
                       target="_blank" data-bn-ipg="20-1-5-1">
                        <img width="100" height="150" title="英国铁路穷游锦囊"
                             alt="英国铁路穷游锦囊" src="../Images/100_150(10).jpg">
                    </a>
                    <span class="new"></span><a title="英国铁路穷游锦囊" class="mask" href="http://guide.qyer.com/uk-railway/"
                                                target="_blank" data-bn-ipg="20-1-5-1"></a>
                </div>
                <p class="gui_jnlist_item_tit">
                    <a title="英国铁路" href="http://guide.qyer.com/uk-railway/"
                       target="_blank" data-bn-ipg="20-1-5-2">英国铁路</a>
                </p>
                <p class="gui_jnlist_item_text">英国<br>2015-07-31更新</p>
            </li>
        </ul>
        <div class="border"></div>
        </div>

                    <div class="last-item"></div>
                </div>
            </div>
        </div>
    </body>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/personal.js"></script>
    <script src="../Scripts/site.js"></script>
    <script src="../Plugins/scripts/jquery/jquery.cookie.js"></script>
    

    <script src="../Plugins/scripts/load-metro.js"></script>
    
    <script src="../Plugins/scripts/jquery.showLoading.js"></script>
    <script src="../Plugins/scripts/jquery.bpopup.min.js"></script>
    <!--Metro script-->
    <script src="../Plugins/scripts/jquery/jquery.widget.min.js"></script>
    <script src="../Plugins/scripts/jquery/jquery.easing.1.3.min.js"></script>
    <script src="../Plugins/scripts/metro/metro-loader.js"></script>
    <script src="../Plugins/scripts/metro.min.js"></script>
    <script type="text/javascript">
        $(function () {
            URP.criteria.TileId = 2;
            URP.ReportsGet.SiteGet();
            URP.initiate();
        });
    </script>
</asp:Content>
