<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TravelClient.UX.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/register.css" rel="stylesheet" />
    <body class="bodyBk register">
        <div class="loginBk">
            <div class="warp">

                <form id="regform" name="regform" method="post">
                    <input id="returnback" name="returnback" value="" type="hidden">
                    <input id="shoppingId" name="shoppingId" value="" type="hidden">
                    <input id="skuId" name="skuId" value="" type="hidden">
                    <input id="checkcode" value="ajaxCheckRegImgYzm" type="hidden">
                    <input id="page" value="reg" type="hidden">
                    <input id="codekey" name="codekey" value="cb91bf31464dccda294ee721732588b3" type="hidden">
                    <input id="codekeyFormobile" name="codekeyFormobile" value="6e120dfce05a6a59b333bd0f08200f39" type="hidden">
                    <div class="css3 loginContent">
                        <div class="loginTitle"><span class="lc1"></span><span class="lcr">已有  账号 ? <a id="reg_link" href="login.jsp">登录</a></span></div>

                        <div class="loginzone">
                            <span class="regtitle">用户名:</span> <span>
                                <input id="username" type="text" /></span>
                        </div>

                        <div class="loginzone">
                            <span class="regtitle">密码:</span><span><input id="password" type="password" /></span>
                        </div>
                        <div class="loginzone">
                            <span class="regtitle">邮箱:</span><span><input id="mail" type="text" /></span>
                        </div>
                        <div class="loginzone">
                            <span class="regtitle">验证码:</span><span><input type="password" /></span>

                        </div>

                        <div class="item">
                            <span class="label">&nbsp;</span>
                            <input type="button" class="btn-img btn-regist" id="registsubmit" value="立即注册" tabindex="8" clstag="regist|keycount|personalreg|07" onclick="reg();">
                        </div>
                    </div>
                </form>


            </div>
        </div>
    </body>

    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/account.js"></script>
    <script type="text/javascript">
        
        $(function () {
            account.init();
        });
    </script>
</asp:Content>
