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
