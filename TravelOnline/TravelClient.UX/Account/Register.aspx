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

                <form action="register_do.jsp" id="regform" name="regform" method="post">
                    <input id="returnback" name="returnback" value="" type="hidden">
                    <input id="shoppingId" name="shoppingId" value="" type="hidden">
                    <input id="skuId" name="skuId" value="" type="hidden">
                    <input id="checkcode" value="ajaxCheckRegImgYzm" type="hidden">
                    <input id="page" value="reg" type="hidden">
                    <input id="codekey" name="codekey" value="cb91bf31464dccda294ee721732588b3" type="hidden">
                    <input id="codekeyFormobile" name="codekeyFormobile" value="6e120dfce05a6a59b333bd0f08200f39" type="hidden">
                    <div class="css3 loginContent">
                        <div class="loginTitle"><span class="lc1"></span><span class="lcr">已有  账号 ? <a id="reg_link" href="login.jsp">登录</a></span></div>
                       

                       
                        <ul class="loginInput">
                          
                        </ul>

                    </div>
                </form>


            </div>
        </div>
    </body>
</asp:Content>
