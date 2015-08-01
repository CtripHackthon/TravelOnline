<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="TravelClient.UX.Posts.NewPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/newpost.css" rel="stylesheet" />
    <link href="../Plugins/css/wangEditor-1.3.css" rel="stylesheet" />

    <div class="wrapper">
        <ul id="report-list">
            <li>
                <ul style="width: 600px; height: 30px" id="artcle-information-board">
                    <li>
                        <a class="addPic">上传封面</a>

                    </li>
                    <li>
                         <div class="pictureShowDiv">
                        <ul class="pict-show-in-body">
                        </ul>
                    </div>
                        
                    </li>
                    <li class="a"><b>标题:</b></li>
                    <li class="a">
                        <input type="text" class="article-title-text" placeholder="标题..." tabindex="0" />
                        <label style="color: red; margin-left: 10px;" class="hide">* 标题不能为空</label>
                    </li>

                    <li class="a"><b>简介:</b></li>
                    <li style="width: 1200px; margin: 0 auto; margin-top: 10px;">
                        <div class="head">
                            <textarea id="editor1" name="editor1" tabindex="5"
                                style="width: 200px; height: 420px"></textarea>
                            <label style="color: red;" class="hide">* 文章内容不能为空</label>

                            <p class="edit-tag-btns" style="float: right; margin-top: 30px;"><a id="submitarticle" href="#" class="__saveTagBtn save-tag-btn sc-btn" type="submit"><span>保存</span></a><a href="#" class="__cancelBtn cancel-btn sc-btn" type="submit"><span>取消</span></a></p>
                        </div>
                    </li>


                </ul>
            </li>


            <%--  <li><a href="#" class="addPic">添加图片...</a></li>--%>
        </ul>
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
                                    <input type="file" accept="image/*" style="display: none" id="loadFileBt" />

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
                                    <input class="okBt" type="submit" value="确定" />
                                    <input class="resetBt" type="reset" value="取消" />
                                </div>
                            </div>
                        </div>
        <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/post.js"></script>
    <script src="../Plugins/scripts/jquery.bpopup.min.js"></script>
    <script src="../Plugins/scripts/jquery.showLoading.js"></script>
    <script src="../Plugins/scripts/wangEditor-1.3.js"></script>

    <script type="text/javascript">
        (function (post, $, undefined) {
        })(window.post = window.post || {}, $, undefined);

        $(function () {
            post.Init();
        });
    </script>
</asp:Content>
