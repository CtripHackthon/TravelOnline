<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravelClient.UX.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/login.css" rel="stylesheet" />
    <div class="login_wrap">
    
    <div class="content clearfix">
        <div class="lg_banner">
            
            <a data-ptp-cache-id="1.6c69m3iQ.Q4Gueuee.2.tPNrrg" data-ptp-idx="2" href="../Index.aspx" target="_blank" class="banner1"><img src="../Images/reg.jpg"></a>
        </div>
        <div class="lg_left" id="lg_content">
            <!-- 登录方式tab -->
            
            <div class="lg_form">
                <form method="post">
                    <!-- 正常登录 start -->
                    <div class="mod_box lo_mod_box" data-isshow="0">
                        <div class="lg_item lg_name">
                            <input maxlength="32" class="pwd_text uname" name="uname" placeholder="昵称/邮箱/手机号" style="border-color:#CFCFCF; color:#999;" type="text">
                        </div>
                        <div class="lg_item lg_pass">
                            <input maxlength="32" class="pwd_text upassword" name="pass" value="" placeholder="密码" style="border-color:#CFCFCF; color:#999;" type="password">
                        </div>
                    </div>
                    <!-- 正常登录 end -->
                    <!-- 手机号码登陆 start-->
                  
                    <!-- 手机号码登陆 end-->
                    <!-- 易购免登 start -->
                    
                    <!-- 易购免登 end -->
                    <div class="lg_remember">
                        <label><input value="1" name="remember" class="check" checked="checked" type="checkbox"><span> 2周内自动登录</span></label>
                        <a data-ptp-idx="6" class="findpwd" href="/usersecurity/findpwd">忘记密码？</a>
                    </div>
                    <div class="lg_login clearfix">
                        <input value="登录" class="sub" id="login" type="button">
                    </div>
                    <div class="lg_reg">
                        <a data-ptp-idx="8" class="regist" href="../Account/Register.aspx">新用户注册</a>
                    </div>
                   
                </form>
              
            </div>
        </div>
        <input value="" id="isban" type="hidden">
    </div>
</div>

     <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/account.js"></script>
    <script type="text/javascript">

        $(function () {
            account.init();
        });
    </script>
</asp:Content>
