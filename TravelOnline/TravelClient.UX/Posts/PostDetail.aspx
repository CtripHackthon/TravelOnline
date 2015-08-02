<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="TravelClient.UX.Posts.PostDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/home.css" rel="stylesheet" />
    <div class="main-wrap" style="padding:20px">
        <div class="container" style="width:1200px; margin: 0 auto">
            <div class="focus">
                <div class="headlines">
                    <div class="img-title-wrap">
                        <ul>
                            <li class="item">
                                <div id="slider-wrap">
                                    <ul id="slider">
                                       
                                    </ul>
                                    <span class="btns" id="next">>
                                    </span>
                                    <div class="btns" id="previous"></div>
                                    <div id="pagination-wrap">
                                        <ul>
                                            <li class="active"></li>
                                            <li class=""></li>
                                            <li class=""></li>
                                            
                                        </ul>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
            <div class="news-list index-news">
                <ul>
                    <li style="padding-bottom: 40px; text-align:center">
                        <h1 id="articletitle"></h1>
                    </li>
                    <li style="padding-bottom: 40px;">标签：
                     
                        <ul class="tags">
                            
                        </ul>
                    </li>
                    <li>
                        <div id="articledtail">
                            
                        </div>
                    </li>
                    
                    
                </ul>
            </div>
        </div>
    </div>
    <div class="demo-wrap">
        <div class="pic_for_gift500_uni">
        </div>
        <div class="container">
            <div class="demo-wall">

                <ul>


                </ul>
            </div>
            <div style="display: none; height: 45px; padding-top: 0px; margin-top: 0px; padding-bottom: 0px; margin-bottom: 0px;" class="demo-btn">
                <a target="_blank" href="http://no.pingwest.com">
                    <span>查看更多</span>
                </a>
            </div>
        </div>
    </div>

    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/slider.js"></script>

    <script src="../Plugins/scripts/jquery.bpopup.min.js"></script>
    <script src="../Plugins/scripts/jquery.showLoading.js"></script>
    <script src="../Scripts/postdetail.js"></script>
    <script src="../Plugins/scripts/wangEditor-1.3.js"></script>
    <script type="text/javascript">
        (function (post, $, undefined) {
           
        })(window.post = window.post || {}, $, undefined);

       

        $(function () {
            post.getArticle();
        });
            </script>
</asp:Content>
