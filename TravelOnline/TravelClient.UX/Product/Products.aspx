<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TravelClient.UX.Product.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/productlist.css" rel="stylesheet" />
    <div class="search-shop-box group-shop-mode search-shop-abtest" style="width:1200px; margin:0 auto; padding-top:30px;">
        <div class="pic-list">
            <ul id="clisttest">
                <%--<li id="" class="">
                    <a class="group-pic J_hotelItem" href="/group/1952795.html#ctm_ref=grh_sr_pm_def_b" data-cid="345040" title="【长宁区】上海龙之梦大酒店" target="_blank">
                        <img src="http://images4.c-ctrip.com/target/tuangou/791/349/537/3f40bbe9e93c427e887352912b74a0f1_360_240.jpg" onerror="defaultImg(this)" class="group-img" alt="">
                        <div class="pic">



                            <div class="shop-area J_ajaxEl" style="display: none;">
                                <span class="area"><i class="icon-area"></i>上海国际体操中心、衡山公园、衡山路</span>
                            </div>

                        </div>
                        <div class="shop-txt">
                            <div class="shop-info">
                                <p class="name">【长宁区】上海龙之梦大酒店</p>

                                <p class="tips">贵宾房2晚+每日双早+1次双人自助晚餐-</p>


                                <div class="grogshop-star">
                                    <em class="star" title="国家旅游局评定为五星级（携程用户评定为5钻）">五星级</em><em class="star" title="客户点评4.6分，总分5分。">4.6分</em>
                                </div>
                            </div>
                            <div class="price-set">
                                <dfn>¥</dfn><strong class="price"><b class="p_o36_0"></b><b class="p_o36_1"></b><b class="p_o36_9"></b><b class="p_o36_9"></b></strong>
                                <em class="primary-price">¥8551</em>
                                <em class="sell">已售1823</em>
                            </div>
                        </div>

                    </a>
                    <div class="shop-tag">
                    </div>
                </li>

              --%>

            </ul>
            
        </div>


    </div>

    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/products.js"></script>
    <script type="text/javascript">
        (function (product, $, undefined) {

        })(window.product = window.product || {}, $, undefined);



        $(function () {
            product.Init();
        });
            </script>
</asp:Content>
