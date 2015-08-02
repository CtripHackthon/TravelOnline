<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TravelClient.UX.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Plugins/css/lvmm1.css" rel="stylesheet" />
    <link href="../Plugins/css/lvmm2.css" rel="stylesheet" />
    <link href="Content/home.css" rel="stylesheet" />
    <link rel="icon" href="http://webresource.c-ctrip.com/ResUnionOnline/R3/float/pic/log.png" />
</head>

<body class="home" allyes_city="SH">
    <form runat="server">
        <input type="hidden" id="usersession" style="display:none"/>
        <input type="hidden" id="usersessionid" style="display:none"/>

        <div id="top-header" class="header2 header-show">
            <div class="container clearfix">
                <div class="logo-wrap">
                    <a href="../Home.aspx" class="logo">
                        <img src="http://pic.c-ctrip.com/common/c_logo2013.png"></a>
                    <span class="des"><span style="font-weight: bold">穷游路上... 且行且珍惜</span></span>
                </div>
                <a href="javascript:;" class="btn-menu icon-menu"></a>
                <div class="global-nav">
                    <ul class="main-menu">
                        <li>
                            <a href="../Home.aspx">家园</a></li>
                        <li class="dropdown nav-dropdown">
                            <a class="has-drop-menu" href="javascript:;">个性旅途</a>
                            <ul class="dropdown-menu">
                                <div class="sort channel clearfix">
                                    <p class="title">分类</p>
                                    <ul>
                                        <li id="menu-item-42026" class="menu-item"><a href="http://www.pingwest.com/category/figure/">人物</a></li>
                                    </ul>
                                </div>
                                <div class="tags channel clearfix">
                                    <p class="title">标签</p>
                                    <ul>
                                        <li><a href="/hot-tags/airbnb/">Airbnb</a></li>
                                        <li><a href="/hot-tags/xiaomi/">小米</a></li>
                                        <li><a href="/hot-tags/tesla/">Tesla</a></li>
                                        <li><a href="/hot-tags/uber/">Uber</a></li>
                                        <li><a href="/hot-tags/weixin/">微信</a></li>
                                        <li><a href="/tags/">更多</a></li>
                                    </ul>
                                </div>
                            </ul>
                        </li>
                        <li class="dropdown nav-dropdown">
                            <a class="has-drop-menu" href="javascript:;">召集令</a>
                            <ul class="dropdown-menu nav-events">
                                <li class="nav-events-item">
                                    <b><a target="_blank" href="http://www.pingwest.com/market/screen-salon/">PingWest品玩 沙龙：小屏幕 の 新看法</a></b>
                                    <p class="meta">
                                        <span class="time">6月26日</span>
                                    </p>
                                    <span class="status">已结束</span>
                                </li>
                                <li class="nav-events-item">
                                    <b><a target="_blank" href="http://events.pingwest.com/nlvc-lighting-2/">北极光创投 Lighting 第二期：企业级服务的黄金五年</a></b>
                                    <p class="meta">
                                        <span class="time">6月11日</span>
                                    </p>
                                    <span class="status">已结束</span>
                                </li>
                                <li class="nav-events-item">
                                    <b><a target="_blank" href="http://events.pingwest.com/sequoia_capital/">红杉大讲堂第二季——从实验室到日常消费，智能硬件该如何落地</a></b>
                                    <p class="meta">
                                        <span class="time">5月17日</span>
                                    </p>
                                    <span class="status">已结束</span>
                                </li>
                                <li class="nav-events-item">
                                    <b><a target="_blank" href="http://events.pingwest.com/nlvc-lighting-1/">北极光创投 Lighting 2015第一期 ：新航海时代—中国互联网全球化之路</a></b>
                                    <p class="meta">
                                        <span class="time">4月3日</span>
                                    </p>
                                    <span class="status">已结束</span>
                                </li>

                                <div class="more-events">
                                    <a target="_blank" href="http://events.pingwest.com">更多活动<i class="icon-more"></i></a>
                                </div>
                            </ul>
                        </li>
                        <li><a href="../game/index_game.aspx">喵星探险</a></li>

                        <!-- <li class="nav-en"><a href="http://en.pingwest.com/" target="_blank">ENGLISH</a></li> -->

                    </ul>

                </div>
                <div class="right-bar">
                    <ul>
                        <li class="li-after">
                            <a href="../Account/Login.aspx" class="login">登录</a>
                        </li>
                        <li style="padding-left: 10px">
                            <a href="../Account/Register.aspx" class="login">注册</a>
                        </li>
                    </ul>
                </div>



            </div>
        </div>
        <div class="lv-ban">
            <div class="lv-ban-wrap">

                <ul class="lv-ban-imgs" id="js_allyes_1">
                    <li class="active"><a href="#" target="_blank">
                        <img src="http://pic.lvmama.com/opi/sy01-mdd-sh.jpg" to_trd="null" height="400" width="1920"></a></li>
                </ul>
            </div>
        </div>

        <div class="wrap">



            <!-- 景点门票开始 -->
            <div class="public-box clearfix count-first" data-count-first="景点门票">
                <div class="public-tit">
                    <h3 class="fl"><strong>景点门票</strong></h3>

                    <a class="public-tit-more fr" href="http://ticket.lvmama.com" target="_blank">更多景点门票<i class="icon-v7 icon-v7-more"></i></a>
                </div>
                <div class="ticket-box clearfix">
                    <!-- 公共左边导航模块开始 -->
                    <div class="public-asidebg fl count-first" data-count-first="左侧导航">
                        <div class="public-asidenav">
                            <dl>
                                <dt>
                                    <h3>热门景点目的地</h3>
                                </dt>

                                <dd><a href="http://ticket.lvmama.com/scenic-103518" title="上海奉贤碧海金沙" target="_blank">上海奉贤碧海金沙</a>

                                    <a class="r" href="http://www.lvmama.com/zt/promo/dongfangmingzhu/" title="东方明珠游船" target="_blank">东方明珠游船</a></dd>

                                <dd><a href="http://ticket.lvmama.com/scenic-100792" title="上海东方明珠" target="_blank">上海东方明珠</a>

                                    <a class="r" href="http://dujia.lvmama.com/tour/shanghaihuanqiujinrongzhongxinguanguangting175652" title="上海环球金融中心观光厅" target="_blank">上海环球金融中心观光厅</a></dd>

                                <dd><a href="http://ticket.lvmama.com/scenic-102843" title="上海野生动物园" target="_blank">上海野生动物园</a>

                                    <a class="r" href="http://ticket.lvmama.com/scenic-100683" title="上海东方绿舟" target="_blank">上海东方绿舟</a></dd>

                                <dd><a href="http://ticket.lvmama.com/scenic-103057" title="上海动物园" target="_blank">上海动物园</a>

                                    <a class="r" href="http://ticket.lvmama.com/scenic-150300" title="上海星期8小镇" target="_blank">上海星期8小镇</a></dd>

                                <dd><a href="http://ticket.lvmama.com/scenic-151490" title="东滩帐篷星空" target="_blank">东滩帐篷星空</a>

                                    <a class="r" href="http://ticket.lvmama.com/scenic-151480" title="上海海湾荷花节" target="_blank">上海海湾荷花节</a></dd>


                                <dt>
                                    <h3>景点主题</h3>
                                </dt>

                                <dd><a href="http://s.lvmama.com/ticket/K310000T27?keyword=%E4%B8%8A%E6%B5%B7#list" title="森林公园" target="_blank">森林公园</a>

                                    <a class="r" href="http://www.lvmama.com/zt/promo/evcard/" title="开EV游嘉定" target="_blank">开EV游嘉定</a></dd>

                                <dd><a href="http://s.lvmama.com/ticket/T5K310000?keyword=%E4%B8%8A%E6%B5%B7#list" title="暑期亲子" target="_blank">暑期亲子</a>

                                    <a class="r" href="http://s.lvmama.com/ticket/K310000?keyword=%E9%83%BD%E5%B8%82%E8%A7%82%E5%85%89#list" title="都市观光" target="_blank">都市观光</a></dd>

                                <dd><a href="http://s.lvmama.com/ticket/K310000T5?keyword=%E4%B8%8A%E6%B5%B7#list" title="激情乐园" target="_blank">激情乐园</a>

                                    <a class="r" href="http://s.lvmama.com/ticket/K310000T17?keyword=%E4%B8%8A%E6%B5%B7#list" title="博物馆" target="_blank">博物馆</a></dd>

                                <dd><a href="http://s.lvmama.com/ticket/T11K310000?keyword=%E4%B8%8A%E6%B5%B7#list" title="田园度假" target="_blank">田园度假</a>

                                    <a class="r" href="http://s.lvmama.com/ticket/K310000T9?keyword=%E4%B8%8A%E6%B5%B7#list" title="动植物园" target="_blank">动植物园</a></dd>


                            </dl>
                        </div>
                    </div>
                    <!-- 公共左边导航模块结束 -->

                    <!-- 侧边产品list -->
                    <div class="public-pro clearfix fl count-first" data-count-first="右侧图片列表">
                        <div class="pro-list fl">
                            <ul class="css3_liy-5 css3_run">
                                <li class="w485_243">
                                    <p class="pro-list-pic"><a href="http://ticket.lvmama.com/scenic-10624956" title="东方明珠特色餐船" target="_blank">
                                        <img src="http://s3.lvjs.com.cn/uploads/pc/place2/84107/1436160659742.jpg" alt="东方明珠特色餐船" height="243" width="485"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>114</em>起</span><a href="http://ticket.lvmama.com/scenic-10624956" title="东方明珠特色餐船" target="_blank">东方明珠特色餐船</a></p>
                                </li>



                                <li class="w235_243">
                                    <p class="pro-list-pic"><a href="http://ticket.lvmama.com/scenic-120044" title="上海欢乐谷暑期夜场" target="_blank">
                                        <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84107/1437983980264.jpg" alt="上海欢乐谷暑期夜场" height="243" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>65</em>起</span><a href="http://ticket.lvmama.com/scenic-120044" title="上海欢乐谷暑期夜场" target="_blank">上海欢乐谷暑期夜场</a></p>
                                </li>



                                <li>
                                    <p class="pro-list-pic"><a href="http://ticket.lvmama.com/scenic-157953" title="上海玛雅海滩水公园" target="_blank">
                                        <img src="http://s2.lvjs.com.cn/uploads/pc/place2/2015-07-20/91073cf7-eebf-452a-bc77-b45d1b6e0be0.jpg" alt="上海玛雅海滩水公园" height="157" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>130</em>起</span><a href="http://ticket.lvmama.com/scenic-157953" title="上海玛雅海滩水公园" target="_blank">上海玛雅海滩水公园</a></p>
                                </li>


                                <li>
                                    <p class="pro-list-pic"><a href="http://ticket.lvmama.com/scenic-157197" title="寻梦园香草农场" target="_blank">
                                        <img src="http://s3.lvjs.com.cn/uploads/pc/place2/2015-07-20/c207353f-d314-4d2a-9e8a-b1e928e07d3e.jpg" alt="寻梦园香草农场" height="157" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>50</em>起</span><a href="http://ticket.lvmama.com/scenic-157197" title="寻梦园香草农场" target="_blank">寻梦园香草农场</a></p>
                                </li>


                                <li>
                                    <p class="pro-list-pic"><a href="http://ticket.lvmama.com/scenic-105607" title="锦江乐园-柯南展" target="_blank">
                                        <img src="http://s1.lvjs.com.cn/uploads/pc/place2/2015-07-15/a68f84ae-be23-43f2-9984-8d5efb6d67e5.jpg" alt="锦江乐园-柯南展" height="157" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>57</em>起</span><a href="http://ticket.lvmama.com/scenic-105607" title="锦江乐园-柯南展" target="_blank">锦江乐园-柯南展</a></p>
                                </li>


                            </ul>
                        </div>

                        <!-- 特卖会 -->
                        <div class="public-tuango fr">
                            <a href="http://www.lvmama.com/zt/tuangou/temai/index.htm#header" title="特价1折起 每日限量抢" target="_blank">
                                <img src="http://s2.lvjs.com.cn/uploads/pc/place2/84302/1423815986577.jpg" alt="特价1折起 每日限量抢" height="435" width="195">
                                <div class="tuango-info yellow">
                                    <strong>特卖</strong>
                                    <p>特价1折起 每日限量抢</p>
                                    <p class="tuango-price"><i>￥</i><em>99</em>起</p>
                                </div>
                            </a>
                        </div>

                    </div>

                </div>
            </div>
            <!-- 景点门票结束 -->


            <!-- 周边游开始 -->
            <div class="public-box clearfix count-first" data-count-first="周边游">
                <div class="public-tit">
                    <h3 class="fl"><strong>周边游</strong><span>拎包就走,轻松出游</span></h3>
                    <ul class="JS_public public-sub">
                        <li class="active" paramdatasearchname="自由行" paramdatacode="Week_HotPlace_zyx" paramid="tab1" parenttype="picWeek">自由行<em class="icon-v7 icon-v7-sub"></em>
                        </li>
                        <li paramdatasearchname="跟团游" paramdatacode="Week_HotPlace_gty" paramid="tab2" parenttype="picWeek">跟团游<em class="icon-v7 icon-v7-sub"></em>
                        </li>
                        <li paramdatasearchname="手机专享" paramdatacode="Week_HotPlace_wxzx" paramid="tab3" parenttype="picWeek">
                            <i class="icon-v7 icon-v7-mobile"></i>手机专享<em class="icon-v7 icon-v7-sub"></em>
                        </li>
                    </ul>
                    <a class="public-tit-more fr" href="http://www.lvmama.com/freetour" target="_blank">更多周边游<i class="icon-v7 icon-v7-more"></i></a>
                </div>
                <div class="weekend-box clearfix">
                    <!-- 公共左边导航模块开始 -->
                    <div class="public-asidebg fl count-first" data-count-first="左侧导航">
                        <div class="public-asidenav">
                            <dl>
                                <dt>
                                    <h3>热门目的地</h3>
                                </dt>
                                <dd><a href="http://dujia.lvmama.com/tour/shanghai79/freetour" title="上海" target="_blank">上海</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/changzhou86/freetour-I86#list" title="常州" target="_blank">常州</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/hangzhou100/freetour" title="杭州" target="_blank">杭州</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/s-592976ee6e56/freetour" title="天目湖" target="_blank">天目湖</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/wuxi83/freetour" title="无锡" target="_blank">无锡</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/s-4e096e055c71/freetour-D0#list" title="三清山" target="_blank">三清山</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/s-897f5858/freetour" title="西塘" target="_blank">西塘</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/anji110/freetour" title="安吉" target="_blank">安吉</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/huangshan127/freetour " title="黄山" target="_blank">黄山</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/xiamen137/freetour" title="厦门" target="_blank">厦门</a></dd>
                                <dt>
                                    <h3>当季热门</h3>
                                </dt>
                                <dd><a href="http://dujia.lvmama.com/tour/s-4eb25b50/freetour-D0#list" title="亲子出游" target="_blank">亲子出游</a>

                                    <a class="r" href="http://dujia.lvmama.com/tour/shanghai79/freetour" title="节日出游" target="_blank">节日出游</a></dd>

                                <dd><a href="http://dujia.lvmama.com/tour/s-8e0f9752/freetour" title="周边踏青" target="_blank">周边踏青</a>

                                    <a class="r" href="http://www.lvmama.com/zt/promo/mingshan/" title="名山游览" target="_blank">名山游览</a></dd>

                                <dd><a href="http://dujia.lvmama.com/tour/s-4e5056ed/freetour-D0#list" title="主题乐园" target="_blank">主题乐园</a>

                                    <a class="r" href="http://www.lvmama.com/zt/promo/shanghua2/" title="周边赏花" target="_blank">周边赏花</a></dd>

                                <dd><a href="http://dujia.lvmama.com/tour/s-53e49547/freetour-D0#list" title="古镇村落" target="_blank">古镇村落</a>

                                    <a class="r" href="http://dujia.lvmama.com/tour/s-5c716c34666f89c2/freetour-D0#list" title="山水景观" target="_blank">山水景观</a></dd>

                                <dd><a href="http://dujia.lvmama.com/tour/s-91d1724c/freetour-D0#list" title="金牌产品" target="_blank">金牌产品</a>

                                    <a class="r" href="http://dujia.lvmama.com/tour/s-5c3e623f/freetour-D0#list" title="尾房甩卖" target="_blank">尾房甩卖</a></dd>

                            </dl>
                        </div>
                    </div>
                    <!-- 公共左边导航模块结束 -->

                    <!-- 侧边产品list -->
                    <div class="public-pro clearfix fl count-first" data-count-first="右侧图片列表">
                        <div class="pro-list fl">
                            <ul class="css3_liy-5 css3_run">
                                <li class="w485_243">
                                    <p class="pro-list-pic"><a href="http://dujia.lvmama.com/freetour/440539" title="上海玛雅海滩水乐园 不湿透 不够嗨" target="_blank">
                                        <img src="http://s3.lvjs.com.cn/uploads/pc/place2/2015-07-16/0d01c811-0dd5-42f4-b78a-f507176ab34d.jpg" alt="上海玛雅海滩水乐园 不湿透 不够嗨" height="243" width="485"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>643</em>起</span><a href="http://dujia.lvmama.com/freetour/440539" title="上海玛雅海滩水乐园 不湿透 不够嗨" target="_blank">上海玛雅海滩水乐园 不湿透 不够嗨</a></p>
                                </li>
                                <li class="w235_243">
                                    <p class="pro-list-pic"><a href="http://dujia.lvmama.com/freetour/560353" title="绍兴诸暨2天1晚" target="_blank">
                                        <img src="http://s2.lvjs.com.cn//uploads/pc/place2/2015-07-10/d6df1735-47b2-4207-9de1-d923d24f6648.jpg" alt="绍兴诸暨2天1晚" height="243" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>468</em>起</span><a href="http://dujia.lvmama.com/freetour/560353" title="绍兴诸暨2天1晚" target="_blank">绍兴诸暨2天1晚</a></p>
                                </li>
                                <li>
                                    <p class="pro-list-pic"><a href="http://dujia.lvmama.com/tour/s-4e5056ed/freetour-I87#list" title="苏州水乐园" target="_blank">
                                        <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84135/1438249483627.jpg" alt="苏州水乐园" height="157" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>266</em>起</span><a href="http://dujia.lvmama.com/tour/s-4e5056ed/freetour-I87#list" title="苏州水乐园" target="_blank">苏州水乐园</a></p>
                                </li>
                                <li>
                                    <p class="pro-list-pic"><a href="http://dujia.lvmama.com/tour/maoshanfengjingqu100194/freetour" title="镇江茅山限时秒杀" target="_blank">
                                        <img src="http://s2.lvjs.com.cn/uploads/pc/place2/2015-07-21/fc17d1e6-fa73-4980-9aeb-16179e3c1254.jpg" alt="镇江茅山限时秒杀" height="157" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>199</em>起</span><a href="http://dujia.lvmama.com/tour/maoshanfengjingqu100194/freetour" title="镇江茅山限时秒杀" target="_blank">镇江茅山限时秒杀</a></p>
                                </li>
                                <li>
                                    <p class="pro-list-pic"><a href="http://dujia.lvmama.com/freetour/559472" title="杭州2日游" target="_blank">
                                        <img src="http://s2.lvjs.com.cn//uploads/pc/place2/2015-07-08/4fa12d1e-8fc3-4ba1-b2b9-c9b5024f15fa.jpg" alt="杭州2日游" height="157" width="235"></a></p>
                                    <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>439</em>起</span><a href="http://dujia.lvmama.com/freetour/559472" title="杭州2日游" target="_blank">杭州2日游</a></p>
                                </li>
                            </ul>
                        </div>

                        <!-- 特卖会 -->
                        <div class="public-tuango fr">
                            <a href="http://www.lvmama.com/tuangou/deal-564074" title="横店6大景点双人套餐" target="_blank">
                                <img src="http://s3.lvjs.com.cn/uploads/pc/place2/2015-07-21/fe0edd68-07db-4f5b-a183-e74ba6783032.jpg" alt="横店6大景点双人套餐" height="435" width="195">
                                <div class="tuango-info green">
                                    <strong>特卖</strong>
                                    <p>横店6大景点双人套餐</p>
                                    <p class="tuango-price"><i>￥</i><em>920</em>起</p>
                                </div>
                            </a>
                        </div>

                    </div>

                </div>
            </div>
            <!-- 周末游结束 -->

            <!-- 出境游开始 -->
            <div class="public-box clearfix count-first JS_chujing" data-count-first="出境游">
                <div class="public-tit">
                    <h3 class="fl"><strong>出境游</strong><span>世界有多大,我就玩多远</span></h3>
                    <ul class="JS_public public-sub">
                        <li class="active" paramdatasearchname="跟团游" paramdatacode="cjy_ShortPlace_gty" paramid="tab1" parenttype="piccjy">跟团游<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="自由行" paramdatacode="cjy_ShortPlace_zyx" paramid="tab2" parenttype="piccjy">自由行<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="手机专享" paramdatacode="cjy_ShortPlace_wxzx" paramid="tab3" parenttype="piccjy"><i class="icon-v7 icon-v7-mobile"></i>手机专享<em class="icon-v7 icon-v7-sub"></em></li>
                    </ul>
                    <a class="public-tit-more fr" href="http://www.lvmama.com/abroad" target="_blank">更多出境游<i class="icon-v7 icon-v7-more"></i></a>
                </div>
                <div class="chujing-box clearfix">
                    <!-- 公共左边导航模块开始 -->
                    <div class="public-asidebg fl count-first" data-count-first="左侧导航">
                        <div class="public-asidenav">
                            <dl>
                                <dt>
                                    <h3>海外热门</h3>
                                    <strong>短途</strong>
                                </dt>
                                <dd><a href="http://dujia.lvmama.com/tour/changtandao3607/route-H9
							"
                                    title="长滩岛" target="_blank">长滩岛</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/pujidao3563/route-D9#list
							"
                                        title="普吉岛" target="_blank">普吉岛</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/taiguo3542/route-H9
							"
                                    title="泰国" target="_blank">泰国</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/riben3543/route-H9
							"
                                        title="日本" target="_blank">日本</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/balidao3545/route-H9
							"
                                    title="巴厘岛" target="_blank">巴厘岛</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/xianggang398/route-D9#list
							"
                                        title="香港" target="_blank">香港</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/xinjiapo3569/route-H9
							"
                                    title="新加坡" target="_blank">新加坡</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/saibandao3547/route-H9
							"
                                        title="塞班岛" target="_blank">塞班岛</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/jianpuzhai3623/route-H9
							"
                                    title="柬埔寨" target="_blank">柬埔寨</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/yuenan3624
							"
                                        title="越南" target="_blank">越南</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/guandao3633
							"
                                    title="关岛" target="_blank">关岛</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/hanguo3544/route-H9
							"
                                        title="韩国" target="_blank">韩国</a></dd>
                                <dt>
                                    <strong>长途</strong>
                                </dt>
                                <dd><a href="http://dujia.lvmama.com/tour/aodaliya3596/route-D9#list
							"
                                    title="澳大利亚" target="_blank">澳大利亚</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/maoliqiusi3629/route-D9#list
							"
                                        title="毛里求斯" target="_blank">毛里求斯</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/tuerqi3574/route-D9#list
							"
                                    title="土耳其" target="_blank">土耳其</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/meiguo3571/group-D9P3#list
							"
                                        title="美国" target="_blank">美国</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/faguo3559/route-D9#list
							"
                                    title="法国" target="_blank">法国</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/tuerqi3574/route-Y4D9#list
							"
                                        title="斯里兰卡" target="_blank">斯里兰卡</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/xila3634/route-D9#list
							"
                                    title="希腊" target="_blank">希腊</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/maerdaifu3546/route-D9#list
							"
                                        title="马尔代夫" target="_blank">马尔代夫</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/yingguo3558/route-D9#list
							"
                                    title="英国" target="_blank">英国</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/dibai3581/route-D9#list
							"
                                        title="迪拜" target="_blank">迪拜</a></dd>
                                <dt>
                                    <h3>主题旅游</h3>
                                </dt>
                                <dd><a href="http://www.lvmama.com/zt/promo/chujingdaren/
							"
                                    title="达人专享" target="_blank">达人专享</a>
                                    <a class="r" href="http://www.lvmama.com/zt/promo/freetour/
							"
                                        title="当地玩乐" target="_blank">当地玩乐</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/s-8d2d72698fd473b0#list
							"
                                    title="DFS返现" target="_blank">DFS返现</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/kenniya3630/route-H9
							"
                                        title="肯尼亚大迁徙" target="_blank">肯尼亚大迁徙</a></dd>
                                <dd><a href="http://s.lvmama.com/all/Y4H9?keyword=%E6%B8%B8%E5%AD%A6#list
							"
                                    title="游学系列" target="_blank">游学系列</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/s-51fa5883/route-J279#list
							"
                                        title="亲子出游" target="_blank">亲子出游</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/s-51fa5883/route-J87#list
							"
                                    title="假日海岛" target="_blank">假日海岛</a>
                                    <a class="r" href="http://s.lvmama.com/all/Y4K310000H9?keyword=%E8%87%AA%E9%A9%BE%E7%B3%BB%E5%88%97#list
							"
                                        title="自驾系列" target="_blank">自驾系列</a></dd>
                                <dd><a href="http://s.lvmama.com/all/H9K310000?keyword=%E9%AB%98%E5%B0%94%E5%A4%AB%E7%B3%BB%E5%88%97#list
							"
                                    title="高尔夫系列" target="_blank">高尔夫系列</a>
                                    <a class="r" href="http://s.lvmama.com/all/H9K310000?keyword=%E6%BD%9C%E6%B0%B4%E7%B3%BB%E5%88%97#list
							"
                                        title="潜水系列" target="_blank">潜水系列</a></dd>
                            </dl>
                        </div>
                    </div>
                    <!-- 公共左边导航模块结束 -->

                    <!-- 侧边产品list -->
                    <div class="public-pro clearfix fl count-first" data-count-first="右侧图片列表">
                        <div class="pro-list fl">
                            <ul class="css3_liy-5 css3_run">

                                <li class="w485_243">
                                    <p class="pro-list-pic">
                                        <a href="http://dujia.lvmama.com/tour/balidao3545/route-H9  
										"
                                            title="巴厘岛" target="_blank">
                                            <span class="pro-list-float"><strong>浪漫巴厘</strong>8月-10月超值出游</span>
                                            <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84142/1438254937836.jpg" alt="巴厘岛" height="243" width="485">
                                        </a>
                                    </p>
                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>4199</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://dujia.lvmama.com/tour/balidao3545/route-H9
										"
                                            title="巴厘岛" target="_blank">巴厘岛</a>
                                    </p>
                                </li>
                                <li class="w235_243">
                                    <p class="pro-list-pic">
                                        <a href="http://s.lvmama.com/route/H9K310000?keyword=%E8%BF%AA%E6%8B%9C&amp;k=0#list
										"
                                            title="迪拜" target="_blank">
                                            <img src="http://s2.lvjs.com.cn/uploads/pc/place2/84142/1437995134250.jpg" alt="迪拜" height="243" width="235"></a>
                                    </p>

                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>4999</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://s.lvmama.com/route/H9K310000?keyword=%E8%BF%AA%E6%8B%9C&amp;k=0#list
										"
                                            title="迪拜" target="_blank">迪拜</a>
                                    </p>
                                </li>
                                <li>
                                    <p class="pro-list-pic">
                                        <a href="http://dujia.lvmama.com/tour/ouzhou3644/route-Y4H9#list
										"
                                            title="欧洲" target="_blank">
                                            <img src="http://s3.lvjs.com.cn/uploads/pc/place2/84142/1429063220453.jpg" alt="欧洲" height="157" width="235"></a>
                                    </p>
                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>8499</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://dujia.lvmama.com/tour/ouzhou3644/route-Y4H9#list
										"
                                            title="欧洲" target="_blank">欧洲</a>
                                    </p>
                                </li>
                                <li>
                                    <p class="pro-list-pic">
                                        <a href="http://s.lvmama.com/route/H9K310000?keyword=%E7%BE%8E%E5%9B%BD&amp;k=0#list
										"
                                            title="美国" target="_blank">
                                            <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84142/1437968157667.jpg" alt="美国" height="157" width="235"></a>
                                    </p>
                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>5999</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://s.lvmama.com/route/H9K310000?keyword=%E7%BE%8E%E5%9B%BD&amp;k=0#list
										"
                                            title="美国" target="_blank">美国</a>
                                    </p>
                                </li>
                                <li>
                                    <p class="pro-list-pic">
                                        <a href="http://dujia.lvmama.com/tour/sililanka3656/route-D9#list
										"
                                            title="斯里兰卡" target="_blank">
                                            <img src="http://s2.lvjs.com.cn/uploads/pc/place2/84142/1435645244880.jpg" alt="斯里兰卡" height="157" width="235"></a>
                                    </p>
                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>4250</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://dujia.lvmama.com/tour/sililanka3656/route-D9#list
										"
                                            title="斯里兰卡" target="_blank">斯里兰卡</a>
                                    </p>
                                </li>
                            </ul>
                        </div>

                        <!-- 特卖会 -->
                        <div class="public-tuango fr">
                            <a href="http://www.lvmama.com/tuangou/sale-561452" title="上海-清迈5日直降300" target="_blank">
                                <img src="http://s3.lvjs.com.cn/uploads/pc/place2/2015-07-21/5ce9f148-1e4c-4547-8266-93e3bc52b38e.jpg" alt="上海-清迈5日直降300" height="435" width="195">
                                <div class="tuango-info blue">
                                    <strong>特卖</strong>
                                    <p>上海-清迈5日直降300</p>
                                    <p class="tuango-price"><i>￥</i><em>3699</em>起</p>
                                </div>
                            </a>
                        </div>
                    </div>

                    <!-- 游轮签证 -->
                    <div class="youlun-qianzheng clearfix fl">
                        <div class="youlun-box fl">
                            <div class="public-tit">
                                <a class="public-tit-more fr" href="http://www.lvmama.com/youlun/" target="_blank">更多<i class="icon-v7 icon-v7-more"></i></a>
                                <h3><strong>邮轮</strong></h3>
                            </div>
                            <div class="youlun-list">
                                <ul class="css3_liy-5 css3_run clearfix">
                                    <li>
                                        <p class="pro-list-pic">
                                            <a target="_blank" title="日韩航线" href="http://www.lvmama.com/youlun/line-l660-s0-b0-m0.html?sort=18">
                                                <img alt="日韩航线" src="http://s1.lvjs.com.cn/uploads/pc/place2/84146/1422530633285.jpg" height="157" width="235">
                                            </a>
                                        </p>
                                        <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>2200</em>起</span><a target="_blank" title="日韩航线" href="http://www.lvmama.com/youlun/line-l660-s0-b0-m0.html?sort=18">日韩航线</a></p>
                                    </li>
                                    <li>
                                        <p class="pro-list-pic">
                                            <a target="_blank" title="加勒比航线" href="http://www.lvmama.com/youlun/line-l663-s0-b0-m0.html?sort=18">
                                                <img alt="加勒比航线" src="http://s2.lvjs.com.cn/uploads/pc/place2/84146/1422523104398.jpg" height="157" width="235">
                                            </a>
                                        </p>
                                        <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>5500</em>起</span><a target="_blank" title="加勒比航线" href="http://www.lvmama.com/youlun/line-l663-s0-b0-m0.html?sort=18">加勒比航线</a></p>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <div class="qianzheng-box fr">
                            <div class="public-tit">
                                <a class="public-tit-more fr" href="http://www.lvmama.com/zt/promo/qianzheng/" target="_blank">更多<i class="icon-v7 icon-v7-more"></i></a>
                                <h3><strong>签证</strong></h3>

                            </div>
                            <!-- 签证模块修改 -->
                            <div class="qianzhengNew">
                                <ul class="css3_liy-5 css3_run clearfix">
                                    <li>
                                        <p class="qianzheng-pic">
                                            <em class="fr">出签率 93%</em>
                                            <a target="_blank" href="http://www.lvmama.com/visa/meiguo" title="美国">
                                                <img src="http://s3.lvjs.com.cn/uploads/pc/place2/84145/1422523023545.jpg" alt="美国" height="55" width="110"></a>
                                        </p>
                                        <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>1350</em>起</span><a href="http://www.lvmama.com/visa/meiguo" title="美国" target="_blank">美国</a></p>
                                    </li>
                                    <li>
                                        <p class="qianzheng-pic">
                                            <em class="fr">出签率 91%</em>
                                            <a target="_blank" href="http://www.lvmama.com/visa/riben" title="日本">
                                                <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84145/1422523038077.jpg" alt="日本" height="55" width="110"></a>
                                        </p>
                                        <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>400</em>起</span><a href="http://www.lvmama.com/visa/riben" title="日本" target="_blank">日本</a></p>
                                    </li>
                                    <li>
                                        <p class="qianzheng-pic">
                                            <em class="fr">出签率 98%</em>
                                            <a target="_blank" href="http://www.lvmama.com/visa/hanguo" title="韩国">
                                                <img src="http://s2.lvjs.com.cn/uploads/pc/place2/84145/1422523053349.jpg" alt="韩国" height="55" width="110"></a>
                                        </p>
                                        <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>300</em>起</span><a href="http://www.lvmama.com/visa/hanguo" title="韩国" target="_blank">韩国</a></p>
                                    </li>
                                    <li>
                                        <p class="qianzheng-pic">
                                            <em class="fr">出签率 97.8%</em>
                                            <a target="_blank" href="http://www.lvmama.com/visa/taiguo" title="泰国">
                                                <img src="http://s3.lvjs.com.cn/uploads/pc/place2/84145/1422523067526.jpg" alt="泰国" height="55" width="110"></a>
                                        </p>
                                        <p class="pro-list-tit"><span class="pro-list-price fr"><i>￥</i><em>248</em>起</span><a href="http://www.lvmama.com/visa/taiguo" title="泰国" target="_blank">泰国</a></p>
                                    </li>
                                </ul>
                            </div>
                            <!-- 签证模块修改end -->

                        </div>
                    </div>

                </div>
            </div>
            <!-- 出境游结束 -->

            <!-- 国内游开始 -->
            <div class="public-box clearfix count-first" data-count-first="国内游">
                <div class="public-tit">
                    <h3 class="fl"><strong>国内游</strong><span>行走山水间,足迹遍中国</span></h3>
                    <ul class="JS_public public-sub">
                        <li class="active" paramdatasearchname="热卖" paramdatacode="gny_HotPlace_remai" paramid="tab1" parenttype="picgny">热卖<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="手机专享" paramdatacode="gny_HotPlace_wxzx" paramid="tab2" parenttype="picgny"><i class="icon-v7 icon-v7-mobile"></i>手机专享<em class="icon-v7 icon-v7-sub"></em></li>
                    </ul>
                    <a class="public-tit-more fr" href="http://www.lvmama.com/destroute" target="_blank">更多国内游<i class="icon-v7 icon-v7-more"></i></a>
                </div>
                <div class="guonei-box clearfix">
                    <!-- 公共左边导航模块开始 -->
                    <div class="public-asidebg fl count-first" data-count-first="左侧导航">
                        <div class="public-asidenav">
                            <dl>
                                <dt>
                                    <h3>热门目的地</h3>
                                </dt>
                                <dd><a href="http://dujia.lvmama.com/tour/zhangjiajie221
							"
                                    title="张家界" target="_blank">张家界</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/jiuzhaigou3698/route-D9#list
							"
                                        title="九寨沟" target="_blank">九寨沟</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/lijiang320
							"
                                    title="丽江" target="_blank">丽江</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/beijing1
							"
                                        title="北京" target="_blank">北京</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/shennongjia3668/route-D9#list
							"
                                    title="神农架" target="_blank">神农架</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/sanya272
							"
                                        title="三亚" target="_blank">三亚</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/xiamen137
							"
                                    title="厦门" target="_blank">厦门</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/guilin254
							"
                                        title="桂林" target="_blank">桂林</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/xizang331
							"
                                    title="西藏" target="_blank">西藏</a>
                                    <a class="r" href="http://dujia.lvmama.com/tour/gansu350
							"
                                        title="甘肃" target="_blank">甘肃</a></dd>
                                <dd><a href="http://s.lvmama.com/route/D9K310000H9?keyword=%E5%86%85%E8%92%99%E5%8F%A4#list
							"
                                    title="内蒙古" target="_blank">内蒙古</a>
                                    <a class="r" href="http://s.lvmama.com/all/D9H9K310000?keyword=%E9%95%BF%E7%99%BD%E5%B1%B1#list
							"
                                        title="长白山" target="_blank">长白山</a></dd>
                                <dd><a href="http://dujia.lvmama.com/tour/guizhou300
							"
                                    title="贵州" target="_blank">贵州</a>
                                    <a class="r" href="http://s.lvmama.com/all/D9H9K310000?keyword=%E5%A4%A7%E7%90%86#list
							"
                                        title="大理" target="_blank">大理</a></dd>
                                <dt>
                                    <h3>热门主题</h3>
                                </dt>
                                <dd><a href="http://www.lvmama.com/zt/promo/shujia/?ac=sh" title="今夏放肆浪" target="_blank">今夏放肆浪</a>
                                    <a class="r" href="http://www.lvmama.com/zt/i/caoyuan" title="绝美西北" target="_blank">绝美西北</a></dd>
                                <dd><a href="http://www.lvmama.com/zt/i/shuqishanshui" title="逍遥山水" target="_blank">逍遥山水</a>
                                    <a class="r" href="http://s.lvmama.com/route/H9I272K310000?keyword=%E6%B5%B7%E6%BB%A8%E5%B2%9B%E5%B1%BF#list" title="海滨岛屿" target="_blank">海滨岛屿</a></dd>
                                <dd><a href="http://www.lvmama.com/zt/i/xiyanghong#zt_anchor1_3" title="孝行天下" target="_blank">孝行天下</a>
                                    <a class="r" href="http://s.lvmama.com/route/H9I221K310000?keyword=%E5%8F%A4%E9%95%87%E6%9D%91%E8%90%BD#list" title="古镇村落" target="_blank">古镇村落</a></dd>
                            </dl>
                        </div>
                    </div>
                    <!-- 公共左边导航模块结束 -->

                    <!-- 侧边产品list -->
                    <div class="public-pro clearfix fl count-first" data-count-first="右侧图片列表">
                        <div class="pro-list fl">
                            <ul class="css3_liy-5 css3_run">
                                <li class="w485_243">
                                    <p class="pro-list-pic">
                                        <a href="http://s.lvmama.com/freetour/D9K310000H9?keyword=%E6%A1%82%E6%9E%97#list
										"
                                            title="桂林" target="_blank">
                                            <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84149/1436412649921.jpg" alt="桂林" height="243" width="485"></a>
                                    </p>

                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>1460</em>起</span><span class="pro-tag">自由行<em>|</em>
                                        </span><a href="http://s.lvmama.com/freetour/D9K310000H9?keyword=%E6%A1%82%E6%9E%97#list
										"
                                            title="桂林" target="_blank">桂林</a>
                                    </p>
                                </li>
                                <li class="w235_243">
                                    <p class="pro-list-pic">
                                        <a href="http://s.lvmama.com/group/H9K310000?keyword=%E5%BC%A0%E5%AE%B6%E7%95%8C#list
										"
                                            title="张家界" target="_blank">
                                            <img src="http://s2.lvjs.com.cn/uploads/pc/place2/84149/1432518031176.jpg" alt="张家界" height="243" width="235"></a>
                                    </p>

                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>1299</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://s.lvmama.com/group/H9K310000?keyword=%E5%BC%A0%E5%AE%B6%E7%95%8C#list
										"
                                            title="张家界" target="_blank">张家界</a>
                                    </p>
                                </li>
                                <li>
                                    <p class="pro-list-pic">
                                        <a href="http://s.lvmama.com/group/H9K310000P1?keyword=27#list
										"
                                            title="内蒙古" target="_blank">
                                            <img src="http://s3.lvjs.com.cn/uploads/pc/place2/84149/1432518233364.jpg" alt="内蒙古" height="157" width="235"></a>
                                    </p>

                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>999</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://s.lvmama.com/group/H9K310000P1?keyword=27#list
										"
                                            title="内蒙古" target="_blank">内蒙古</a>
                                    </p>
                                </li>
                                <li>
                                    <p class="pro-list-pic">
                                        <a href="http://s.lvmama.com/freetour/D9H9K310000?keyword=%E5%8E%A6%E9%97%A8#list
										"
                                            title="厦门" target="_blank">
                                            <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84149/1422528502142.jpg" alt="厦门" height="157" width="235"></a>
                                    </p>

                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>1030</em>起</span><span class="pro-tag">自由行<em>|</em>
                                        </span><a href="http://s.lvmama.com/freetour/D9H9K310000?keyword=%E5%8E%A6%E9%97%A8#list
										"
                                            title="厦门" target="_blank">厦门</a>
                                    </p>
                                </li>
                                <li>
                                    <p class="pro-list-pic">
                                        <a href="http://s.lvmama.com/group/H9K310000?keyword=%E8%A5%BF%E8%97%8F#list
										"
                                            title="西藏" target="_blank">
                                            <img src="http://s2.lvjs.com.cn/uploads/pc/place2/84149/1432518504435.jpg" alt="西藏" height="157" width="235"></a>
                                    </p>

                                    <p class="pro-list-tit">
                                        <span class="pro-list-price fr"><i>￥</i><em>2900</em>起</span><span class="pro-tag">跟团游<em>|</em>
                                        </span><a href="http://s.lvmama.com/group/H9K310000?keyword=%E8%A5%BF%E8%97%8F#list
										"
                                            title="西藏" target="_blank">西藏</a>
                                    </p>
                                </li>
                            </ul>
                        </div>

                        <!-- 特卖会 -->
                        <div class="public-tuango fr">
                            <a href="http://www.lvmama.com/tuangou/deal-419594" title="丝绸之路户外品质半自助】甘肃青海湖、敦煌、莫高窟、鸣沙山月牙泉、雅丹魔鬼城、嘉峪关、祁连山9日游【暑期限时特卖】" target="_blank">
                                <img src="http://s3.lvjs.com.cn/uploads/pc/place2/84176/1435639588527.jpg" alt="丝绸之路户外品质半自助】甘肃青海湖、敦煌、莫高窟、鸣沙山月牙泉、雅丹魔鬼城、嘉峪关、祁连山9日游【暑期限时特卖】" height="435" width="195">
                                <div class="tuango-info skyblue">
                                    <strong>特卖</strong>
                                    <p>丝绸之路户外品质半自助】甘肃青海湖、敦煌、莫高窟、鸣沙山月牙泉、雅丹魔鬼城、嘉峪关、祁连山9日游【暑期限时特卖】</p>
                                    <p class="tuango-price"><i>￥</i><em>2980</em>起</p>
                                </div>
                            </a>
                        </div>

                    </div>

                </div>
            </div>
            <!-- 国内游结束 -->

            <!-- 旅游攻略开始 -->
            <div class="public-box clearfix count-first" data-count-first="旅游攻略">
                <div class="public-tit">
                    <h3 class="fl"><strong>旅游攻略</strong><span>晒晒旅程，分享快乐</span></h3>
                    <ul class="JS_public public-sub">
                        <li class="active" paramdatasearchname="三亚" paramdatacode="lygl_RecommendTab_Tab1" paramid="tab1" parenttype="piclygl">三亚<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="斐济" paramdatacode="lygl_RecommendTab_Tab2" paramid="tab2" parenttype="piclygl">斐济<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="日本" paramdatacode="lygl_RecommendTab_Tab3" paramid="tab3" parenttype="piclygl">日本<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="青海湖" paramdatacode="lygl_RecommendTab_Tab4" paramid="tab4" parenttype="piclygl">青海湖<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="西藏" paramdatacode="lygl_RecommendTab_Tab5" paramid="tab5" parenttype="piclygl">西藏<em class="icon-v7 icon-v7-sub"></em></li>
                        <li paramdatasearchname="九寨沟" paramdatacode="lygl_RecommendTab_Tab6" paramid="tab6" parenttype="piclygl">九寨沟<em class="icon-v7 icon-v7-sub"></em></li>
                    </ul>
                    <a class="public-tit-more fr" href="http://www.lvmama.com/lvyou" target="_blank">更多旅游攻略<i class="icon-v7 icon-v7-more"></i></a>
                </div>

                <div class="gonlue-box clearfix">
                    <div class="lvyoubao fl">
                        <img src="http://s1.lvjs.com.cn/img/v6/lvyoubao.png" alt="驴游宝我的游记钱包" height="112" width="211">
                        <div class="lvyoubao-info">
                            <i class="icon-v7 icon-v7-yhl"></i>
                            <i class="icon-v7 icon-v7-yhr"></i>
                            <ul class="JS_lyb">
                            </ul>
                        </div>
                        <a class="lvyoubao-link" href="http://www.lvmama.com/trip/lvyoubao" target="_blank">也要赚钱<i class="icon-v7 icon-v7-goradiu"></i></a>
                    </div>

                    <!--  游记 -->
                    <div class="gonlue-youji clearfix fl">
                        <div class="gonlue-pic fl">
                            <a href="http://www.lvmama.com/trip/show/52909" title=" 这个夏天，三亚畅玩蜈支洲，品三亚海鲜大餐，2015最详细三亚攻略" target="_blank">
                                <img src="http://s2.lvjs.com.cn/uploads/pc/place2/84178/1438152708547.jpg" alt=" 这个夏天，三亚畅玩蜈支洲，品三亚海鲜大餐，2015最详细三亚攻略" height="243" width="485">
                                <p><span>这个夏天，三亚畅玩蜈支洲，品三亚海鲜大餐，2015最详细三亚攻略</span></p>
                            </a>
                            <i class="triangle"></i>
                        </div>
                        <div class="gonlue-info bd fl">
                            <h3>官方攻略</h3>
                            <div class="gonlue-hot">
                                <input id="gonglueid" value="272" type="hidden">
                                <div class="gonlue-hot-pic">
                                    <a href="" target="_blank">
                                        <img src="" alt="" height="120" width="80">&nbsp;</a>
                                </div>
                                <a href="" target="_blank"><strong>&nbsp;</strong></a>
                                <span>&nbsp;</span>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                            </div>
                            <h3><a href="" target="_blank">相关游记</a></h3>
                            <ul>
                                <li><a href="http://www.lvmama.com/trip/show/51314" title="【旅行不要停】#跟着电影去旅行#走进非诚勿扰2——亚龙湾热带天堂森林公园" target="_blank"><i class="icon-v7 icon-v7-point"></i>【旅行不要停】#跟着电影去旅行#走进非诚勿扰2——亚龙湾热带天堂森林公园</a></li>
                                <li><a href="http://www.lvmama.com/trip/show/60333" title="#我要出书#【我是达人】去不了可可西里，陪我去三亚看海" target="_blank"><i class="icon-v7 icon-v7-point"></i>#我要出书#【我是达人】去不了可可西里，陪我去三亚看海</a></li>

                            </ul>
                        </div>

                    </div>

                    <ul class="gonlue-other css3_liy-5 css3_run fr">
                        <li>
                            <a href="http://www.lvmama.com/lvyou/d-daxidi3598.html" title="大溪地——黑珍珠的故乡" target="_blank">
                                <img src="http://s3.lvjs.com.cn/uploads/pc/place2/84184/1438141251052.jpg" alt="大溪地——黑珍珠的故乡" height="114" width="195">
                                <p><span>大溪地——黑珍珠的故乡</span></p>
                            </a>
                        </li>
                        <li>
                            <a href="http://www.lvmama.com/lvyou/d-hulunbeier34.html" title="呼伦贝尔——茵茵绿草，策马扬鞭" target="_blank">
                                <img src="http://s1.lvjs.com.cn/uploads/pc/place2/84184/1438141313312.jpg" alt="呼伦贝尔——茵茵绿草，策马扬鞭" height="114" width="195">
                                <p><span>呼伦贝尔——茵茵绿草，策马扬鞭</span></p>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
            <!-- 旅游攻略结束 -->

        </div>

        <div class="footer_links">

            <!-- 右侧漂浮导航 -->
            <div style="display: block; top: 200px;" class="nav-right">
                <div class="nav-right-nav">
                    <ul id="clist" class="clearfix">
                        <%--<li class="active">
                            <h3>门票</h3>
                        </li>
                        <li class="">
                            <h3>周边</h3>
                        </li>
                        <li class="">
                            <h3>出境</h3>
                        </li>
                        <li class="">
                            <h3>国内</h3>
                        </li>
                        <li class="last">
                            <h3>攻略</h3>
                        </li>--%>
                    </ul>
                </div>
            </div>
            <!-- 公用js-->
            <script src="//hm.baidu.com/hm.js?cb09ebb4692b521604e77f4bf0a61013"></script>
            <script src="http://pic.lvmama.com/stacac/ga.js" async="" type="text/javascript"></script>
        </div>


        <script src="../Scripts/jquery-1.10.2.min.js"></script>

        <script src="Scripts/site.js"></script>
        <script src="Scripts/test.js"></script>
<script src="Scripts/home.js"></script>
       

        <script type="text/javascript">

            (function (site, home, $, undefined) {

            })(window.site = window.site || {}, window.home = window.home || {}, $, undefined);

            $(function () {

                var sessionUser = '<%= Session["UserName"]%>';
                var sessionUserId = '<%= Session["UserId"]%>';

                site.init(sessionUser, sessionUserId);

            });
        </script>
    </form>

</body>
</html>
