﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="TravelClient.UX.Posts.PostDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <link href="../Content/home.css" rel="stylesheet" />
    <div class="main-wrap">
        <div class="container">
            <div class="focus">
                <div class="headlines">
                    <div class="img-title-wrap">
                        <ul>
                            <li class="item">
                                <div id="slider-wrap">
                                    <ul id="slider">
                                        <li style="display: list-item;" class="active">
                                            <a target="_blank" class="con" href="http://www.pingwest.com/keplar-452b-might-be-some-other-life-forms-mother-planet/" style="background-image: url(http://cdn.pingwest.com/wp-content/uploads/2015/07/keplar-452b-header.jpg)">
                                                <div class="overlay"></div>
                                                <div class="title">
                                                    <span class="category">真相</span>
                                                    <h2>那颗被NASA新发现的类地行星，究竟是谁的家园？</h2>
                                                </div>
                                            </a>
                                        </li>
                                        <li style="display: none;" class="">
                                            <a target="_blank" class="con" href="http://www.pingwest.com/obstacle-avoidance-drone/" style="background-image: url(http://cdn.pingwest.com/wp-content/uploads/2015/07/avoidance-obstacle-header.jpg)">
                                                <div class="overlay"></div>
                                                <div class="title">
                                                    <span class="category">真相</span>
                                                    <h2>无人机避障系统大盘点</h2>
                                                </div>
                                            </a>
                                        </li>
                                        <li style="display: none;" class="">
                                            <a target="_blank" class="con" href="http://www.pingwest.com/syncsf2015/" style="background-image: url(http://cdn.pingwest.com/wp-content/uploads/2015/07/sync-2015sf.jpg)">
                                                <div class="overlay"></div>
                                                <div class="title">
                                                    <span class="category">其它</span>
                                                    <h2>【抢票中！】PingWest品玩旧金山年度SYNC大会：新一代美国科技公司们的“东游历险记”</h2>
                                                </div>
                                            </a>
                                        </li>
                                        <li style="display: none;" class="">
                                            <a target="_blank" class="con" href="http://www.pingwest.com/20-question-to-baozoumanhua/" style="background-image: url(http://cdn.pingwest.com/wp-content/uploads/2015/07/manzoudashijian.png)">
                                                <div class="overlay"></div>
                                                <div class="title">
                                                    <span class="category">真相</span>
                                                    <h2>20 问王尼玛：暴走漫画为什么这么火？（结尾彩蛋）</h2>
                                                </div>
                                            </a>
                                        </li>
                                        <li style="display: none;" class="">
                                            <a target="_blank" class="con" href="http://www.pingwest.com/thomasluo-uniqlo/" style="background-image: url(http://cdn.pingwest.com/wp-content/uploads/2015/07/10252149_125144501134_2.jpg)">
                                                <div class="overlay"></div>
                                                <div class="title">
                                                    <span class="category">托马斯专栏</span>
                                                    <h2>托马斯骆专栏 | 我们都可能像优衣库那样成为网络暴力的受害者</h2>
                                                </div>
                                            </a>
                                        </li>
                                    </ul>
                                    <span class="btns" id="next">>
                                    </span>
                                    <div class="btns" id="previous"></div>
                                    <div id="pagination-wrap">
                                        <ul>
                                            <li class="active"></li>
                                            <li class=""></li>
                                            <li class=""></li>
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
                  <li>
                      <h1>这是标题</h1>
                  </li>
                  <li>
                      <div>
                          <h3>这是文章正文</h3>
                      </div>
                  </li>
                  <li>
                      组别：
                      <ul class="tags">
                          <li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li>
                      </ul>
                  </li>
                  <li>
                      标签：
                      <ul class="tags">
                          <li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li><li>标签1</li>
                      </ul>
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

                    <li class="demo-item">
                        <div>
                            <a class="pw-news" target="_blank" href="http://no.pingwest.com/n/video/siri">
                                <div class="news-title">
                                    <span>不好啦！Siri要自杀！</span>
                                </div>

                            </a>
                        </div>
                    </li>

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

</asp:Content>
