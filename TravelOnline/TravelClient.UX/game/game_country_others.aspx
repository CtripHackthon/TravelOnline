<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="game_country_others.aspx.cs"
    Inherits="TravelClient.UX.game.game_game_country_others" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Pragma" content="no-cache" />
    <title>
        <%=Session["user_id_others"] %>
        的村庄</title>

    <script type="text/javascript">
      window.onload=function()
      {
          if('<%=Session["user_id"]!=null %>'=='True')
          {
            document.getElementById("log_in_state").innerHTML='<%=Session["user_id"] %>'+' 欢迎你 '+'<a href="../logout.aspx" class="a">退出登录</a> &nbsp;&nbsp;';
          }
      }
      
    function LoadIframe(){
        document.getElementById("leftFrame").src="game_country_body_others.aspx";
    }
    
    function btReturnToMap_onclick() {
        window.location="game_map.aspx";
    }
    </script>

    <style type="text/css">
    <!--
    body,td,th {
	    font-size: 12px;
	    color: #000;
    }
    body {
	    margin: 0px;
	    background: #000 url(images/top_bg.gif) no-repeat center top;
    }
    ul{
	    margin: 0px;
	    padding: 0px;
	    list-style-type: none;
    }
    .gameWeb{margin-right:7px; margin-top:15px;}
    .gWright{
	    width:172px;
	    height:404px;
	    margin-top: 26px;
	    margin-left: 6px;
	    overflow-x:hidden;
	    overflow-y: scroll;
    }
    .gWright2{
	    margin-top: 100px;
	    width: 100px;
	    margin-left: 40px;
    }
    .gW1{
	    font-weight:bold;
	    font-size:11pt;
	    line-height: 30px;
	    height: 30px;
	    text-align: center;
	    width: 100%;
    }
    .gW2{
	    font-weight: bold;
	    line-height: 20px;
	    height: 20px;
	    width: 100%;
	    border-bottom: 1px dashed #000;
    }
    .gW3{
	    margin-top: 6px;
	    text-align: left;
	    text-indent: 24px;
	    line-height: 20px;
    }
    .gW4{
	    line-height: 20px;
	    height: 20px;
	    text-align: left;
    }
    .gW5{
	    text-align: center;
	    margin-bottom: 20px;
    }
    .gW6{}
    
    .gameLink a{
	    font-weight: bold;
	    color: #000;
	    text-decoration: none;
    }
    .otherTitle{
	    background-image: url(images/other_title.gif);
	    background-repeat: no-repeat;
	    height: 31px;
	    width: 350px;
	    text-align: center;
	    line-height: 31px;
	    font-weight: bold;
	    color: #FFFFFF;
	    position: relative;
	    margin-top: -496px;
	    margin-left: 250px;
    }
    .otherback{
	    text-align: center;
	    height: 24px;
	    width: 100px;
	    position: relative;
	    left: 377px;
    }
    -->
    </style>
</head>
<body onload="LoadIframe();">
    <form id="form1" runat="server">
        <div>
            <table width="858" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 41px;">
                <tr>
                    <td align="center">
                        <img src="images/top_bg2.gif" width="216" height="18" /></td>
                </tr>
            </table>
            <table width="858" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src="images/top_bg3.gif" width="858" height="28" /></td>
                </tr>
                <tr>
                    <td height="30" valign="top" background="images/top_bg4.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 7px;">
                            <tr>
                                <td width="74%" align="right" class="gameLink">
                                    <a href="../Account/Login.aspx">首页</a> | <a href="../article.aspx">社区热点</a> | <a href="../school_vendition/index_vendition.aspx">
                                        活动专区</a> | <a href="../virtual_store/index_virtual_store.aspx">旗舰店</a> |
                                    <a href="../long_man_pk/index_long_man_pk.aspx">龙族风采</a> | <a href="../magazine/index_magazine.aspx">
                                        电子杂志</a></td>
                                <td width="26%" align="center">
                                    <span id="log_in_state"><a href="../register_main.aspx">
                                        <img src="images/reg.gif" width="31" height="16" border="0" /></a>&nbsp;&nbsp;<a
                                            href="../Account/Login.aspx"><img src="images/login.gif" width="31" height="16" border="0" /></a></span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="82" background="images/top_bg5.gif">
                        <table width="100%" height="82" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="25%">
                                    &nbsp;</td>
                                <td width="18%" align="center" style="color: #FFFFFF; font-weight: bold;">
                                    <%=Session["user_id"] %>
                                    的土地</td>
                                <td width="34%">
                                    <table width="270" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr align="center" style="color: #FFFFFF;">
                                            <td width="90" height="30">
                                                <img src="images/wood.jpg" width="31" height="24" /></td>
                                            <td width="90">
                                                <img src="images/stone.jpg" width="23" height="24" /></td>
                                            <td>
                                                <img src="images/gold.jpg" width="22" height="22" /></td>
                                        </tr>
                                        <tr align="center">
                                            <td style="color: #FFFFFF;">
                                                木头
                                                <asp:Label ID="lbCurrentWoodCount" runat="server" Text="0"></asp:Label>/<asp:Label
                                                    ID="lbTotalWoodCount" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td style="color: #FFFFFF;">
                                                石料
                                                <asp:Label ID="lbCurrentStoneCount" runat="server" Text="0"></asp:Label>/<asp:Label
                                                    ID="lbTotalStoneCount" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td style="color: #FFFFFF;">
                                                龙币
                                                <asp:Label ID="lbCurrentMoneyCount" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="23%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="449" valign="top" background="images/mid_back4.jpg">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="646">
                                    <div class="gameWeb" style="padding-left: 125px;">
                                        <iframe width="600" height="427" src="" scrolling="no" frameborder="0" id="leftFrame">
                                        </iframe>
                                        &nbsp;</div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="images/btm_bg.gif" width="858" height="39" border="0" usemap="#Map" />
                        <div class="otherTitle">
                            <asp:Label ID="lbOtherPlayer" runat="server"></asp:Label>的村庄</div>
                        <div class="otherback">
                            <input type="button" value=" 返回地图 " id="btReturnToMap" onclick="return btReturnToMap_onclick()" /></div>
                    </td>
                </tr>
                <tr>
                    <td height="0">
                    </td>
                </tr>
            </table>
            <map name="Map" id="Map">
                <area shape="rect" coords="724,10,791,27" href="game_introduction.aspx" target="_blank" />
            </map>
        </div>
    </form>
</body>
</html>
