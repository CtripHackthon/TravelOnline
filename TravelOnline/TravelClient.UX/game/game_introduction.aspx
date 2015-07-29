<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="game_introduction.aspx.cs"
    Inherits="TravelClient.UX.game.game_game_introduction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>真龙大陆</title>
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
    .gW6{
	    height: 75px;
	    text-align: center;
	    width: 100%;
    }
    .gameLink a{
	    font-weight: bold;
	    color: #000;
	    text-decoration: none;
    }
    .gameLink a:hover {
	    font-weight: bold;
	    color: #000;
	    text-decoration: underline;
    }
    -->
    </style>

    <script type="text/javascript">
      function LoginStateCheck()
      {
          if('<%=Session["user_id"]!=null %>'=='True')
          {
            document.getElementById("log_in_state").innerHTML='<%=Session["user_id"] %>'+' 欢迎你 '+'<a href="../logout.aspx" class="a">退出登录</a> &nbsp;&nbsp;';
          }
      } 
    </script>

</head>
<body onload="LoginStateCheck();">
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
                    <td height="68" background="images/mid_back7.jpg">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td height="449" valign="top" background="images/mid_back6.jpg">
                        <img src="images/01.jpg" width="858" height="279" /><br />
                        <img src="images/02.jpg" width="858" height="277" /><br />
                        <img src="images/03.jpg" width="858" height="256" border="0" usemap="#Map2" /><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="images/btm_bg.gif" width="858" height="39" border="0" usemap="#Map" /></td>
                </tr>
            </table>
            <map name="Map" id="Map">
                <area shape="rect" coords="724,10,791,27" href="#" />
            </map>
            <map name="Map2" id="Map2">
                <area shape="rect" coords="130,76,233,94" href="../virtual_store/cpu_shop.aspx" />
            </map>
        </div>
    </form>
</body>
</html>
