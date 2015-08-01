<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="TravelClient.UX.Posts.NewPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/newpost.css" rel="stylesheet" />
    <link href="../Plugins/css/wangEditor-1.3.css" rel="stylesheet" />
    <div class="addtagdiv">
        <div>
            标签名: <input type="text" placeholder="标签名字" id="tagname"/>
        </div>
        <div>
            <div class="actionArea">
                                    <input class="okBt actionbt"  id="savetag" value="确定" />
                                    <input class="resetBt actionbt" id="canceltag" value="取消" />
                                </div>
        </div>
    </div>
    <div class="selectPictureWin" style="display: none">
                            <div class="tab">
                                <div class="tab_menu">
                                    <ul>
                                        <li class="selected">本地上传</li>
                                        <li>空间上传</li>
                                    </ul>
                                </div>
                                <div class="tab_box">
                                    <input type="text" value="" style="display: none" id="loadFileBt" />

                                    <div class="selected">
                                        <div class="secondAddPicBt">
                                            <input type="image" src="../Images/add2.png" id="addNewPict" />
                                            <ul class="pict-items">
                                            </ul>
                                        </div>
                                        <div class="cleanZone">
                                            <input type="image" src="../Images/add-pic.png" class="addPicBt" />
                                            <div class="pic-desc">
                                                最多64张图片，JPG/JPEG/BMP/PNG，最大15M，GIF最大3M
                               
                                            </div>
                                        </div>
                                    </div>
                                    <div class="hide">空间图片</div>

                                </div>
                                <div class="actionArea">
                                    <input class="okBt actionbt" type="submit" value="确定" />
                                    <input class="resetBt actionbt" type="reset" value="取消" />
                                </div>
                            </div>
                        </div>
    <div class="wrapper">
        <ul id="report-list">
            <li>
                <ul style="width: 800px; height: 30px; margin-bottom:10px; margin-left:-70px;" id="artcle-information-board">
                    <li>
                        <a class="addPic">
<svg xmlns="http://www.w3.org/2000/svg" class="si-glyph-camera" style="height:80px; width:80px"><use xlink:href="../Plugins/fonts/sprite.svg#si-glyph-camera" /></svg>
                        </a>
                    </li>
                    <li>
                         <div class="pictureShowDiv">
                        <ul class="pict-show-in-body">
                        </ul>
                    </div>
                        
                    </li>
                 


                </ul>
                <br />
                
            </li>


            <%--  <li><a href="#" class="addPic">添加图片...</a></li>--%>
        </ul>


        <ul style="width: 800px; height: 30px">
                    <li class="ab">
                        <input type="text" class="article-title-text" placeholder="标题..." tabindex="0" />
                        <label style="color: red; margin-left: 10px;" class="hide">* 标题不能为空</label>
                    </li>

               <li class="ab"><b>分类:</b></li>
                    <li >
                        <select class="category">
                        </select>
                    </li>

             <li class="ab"><b>标签:</b></li>
                    <li>
                        <svg id="addnewtag" xmlns='http://www.w3.org/2000/svg' class='si-glyph-button-plus' style='height: 20px;width: 20px;'><use xlink:href='../Plugins/fonts/sprite.svg#si-glyph-button-plus' /></svg>
                        <ul id="addedtags">

                        </ul>
                    </li>
                    <li class="ab" style="width: 800px; margin: 0 auto; margin-top: 10px;">
                        <div class="head">
                            <textarea id="editor1" name="editor1" tabindex="5" placeholder="简介"
                                style="width: 200px; height: 420px"></textarea>
                            <label style="color: red;" class="hide">* 文章内容不能为空</label>

                            <p class="edit-tag-btns" style="float: right; margin-top: 30px;"><a id="submitarticle" href="#" class="actionbt __saveTagBtn save-tag-btn sc-btn" type="submit"><span>保存</span></a><a href="#" class="actionbt __cancelBtn cancel-btn sc-btn" type="submit"><span>取消</span></a></p>
                        </div>
                    </li>
                </ul>
    </div>
        <script src="../Scripts/jquery-1.10.2.min.js"></script>
       <script src="../Plugins/scripts/jquery.bpopup.min.js"></script>
    <script src="../Plugins/scripts/jquery.showLoading.js"></script>
    <script src="../Scripts/post.js"></script>
 
    <script src="../Plugins/scripts/wangEditor-1.3.js"></script>
<script src="../Plugins/scripts/jquery/jquery.browse.js"></script>
    <script src="../Plugins/scripts/jquery/jquery.upload.js"></script>
    <script type="text/javascript">
        (function (post, $, undefined) {
        })(window.post = window.post || {}, $, undefined);

        $(function () {
            post.Init();
        });
    </script>
</asp:Content>
