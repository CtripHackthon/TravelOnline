<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalBoard.aspx.cs" Inherits="TravelClient.UX.Account.PersonalBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <title></title>
    <link href="../Content/personal.css" rel="stylesheet" />
    <link href="../Plugins/css/metro-bootstrap.css" rel="stylesheet" />

    <body class="metro">
        <div class="wrapper">

            <div class="header">
                <div class="metro2">
                    <div class="left">
                        <div class="description">
                            <div id="oldUserPhoto">
                                <%--<asp:Image CssClass="owner-image" runat="server" ID="owner_image_id" />--%>
                                <span class="edit_pic">
                                    <a href="ProfileEdit.aspx" style="color: white; text-decoration: none">修改头像</a>
                                </span>
                            </div>
                            <asp:HyperLink CssClass="" runat="server" ID="owner_name_id" NavigateUrl="#"></asp:HyperLink>
                        </div>
                    </div>
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

</asp:Content>
