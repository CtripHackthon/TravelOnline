<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="game_pocket.aspx.cs" Inherits="TravelClient.UX.game.game_game_pocket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Pragma" content="no-cache" />
    <title>
        <%=Session["user_id"] %>
        的口袋</title>
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
    .gWright3{
	    width:172px;
	    height:404px;
	    margin-top: 26px;
	    margin-left: 6px;
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
    .pocket{ width:590px; margin-top:50px; margin-left:40px;}
    .pocket li{
	    float:left;
	    height: 137px;
	    width: 65px;
	    background-image: url(images/stone_back.gif);
	    background-repeat: no-repeat;
	    margin-right: 4px;
	    margin-left: 4px;
	    margin-top: 20px;
    }
    -->
    </style>

    <script type="text/javascript">
        var collect='<%=Session["collected"]%>';
      function LoginStateCheck(){
      if('<%=Session["user_id"]!=null %>'=='True')
      {
        document.getElementById("log_in_state").innerHTML='<%=Session["user_id"] %>'+' 欢迎你 '+'<a href="../logout.aspx" class="a">退出登录</a> &nbsp;&nbsp;';
      }
  }
    function load()
    {
        
        if(collect==""||collect==null)
        document.getElementById("compose").disabled=true;
        var check=document.getElementsByName("checkbox");
        for(var i=0;i<check.length;i++)
        {   
            var span=document.getElementById("span_"+check[i].value);
            var reg=new RegExp(check[i].value,"g");
            if(collect.match(reg))
            span.innerHTML= collect.match(reg).length;
            if(collect.indexOf(check[i].value)!=-1)
            continue;
            var img=document.getElementById("img_"+check[i].value);
            var checked=document.getElementById("check_"+check[i].value);
            checked.disabled=true;
            var srcStr=img.src;
            img.src="images/b"+img.name+".gif"
        }
    }
    function compose()
    {
        var check=document.getElementsByName("checkbox");
        var checkedStr="";
        var flag=false;
        for(var i=0;i<check.length;i++)
        if(check[i].checked==true)  
        {
            checkedStr+=check[i].value;
            flag=true;
        }
        if(flag==true)
        window.location="game_pocket.aspx?checked="+checkedStr;
        else
        alert("请选择需要的宝石");
        
    }
    </script>

</head>
<body onload="load();LoginStateCheck();">
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
                            <a href="../index.aspx">首页</a> | <a href="../article.aspx">社区热点</a> | <a href="../school_vendition/index_vendition.aspx">
                                活动专区</a> | <a href="../virtual_store/index_virtual_store.aspx">旗舰店</a> | <a href="../long_man_pk/index_long_man_pk.aspx">
                                    龙族风采</a> | <a href="../magazine/index_magazine.aspx">电子杂志</a></td>
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
                            &nbsp;<table border="0" cellpadding="0" cellspacing="0">
                                <tr align="center">
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                            height="70" width="48">
                                            <param name="movie" value="images/01-2.swf">
                                            <param name="quality" value="high">
                                            <param name="wmode" value="transparent">
                                            <embed height="70" pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high"
                                                src="images/01-2.swf" type="application/x-shockwave-flash" width="48" wmode="transparent"></embed>
                                        </object>
                                    </td>
                                    <td>
                                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                            height="70" width="48">
                                            <param name="movie" value="images/01-1.swf">
                                            <param name="quality" value="high">
                                            <param name="wmode" value="transparent">
                                            <embed height="70" pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high"
                                                src="images/01-1.swf" type="application/x-shockwave-flash" width="48" wmode="transparent"></embed>
                                        </object>
                                    </td>
                                    <td style="width: 49px">
                                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                            height="70" width="48">
                                            <param name="movie" value="images/01-3.swf">
                                            <param name="quality" value="high">
                                            <param name="wmode" value="transparent">
                                            <embed height="70" pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high"
                                                src="images/01-3.swf" type="application/x-shockwave-flash" width="48" wmode="transparent"></embed>
                                        </object>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="449" valign="top" background="images/mid_back2.jpg">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="640" valign="top">
                            <div class="pocket">
                                <ul>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle" style="width: 65px">
                                                    <img src="images/01.gif" id="img_e" name="01" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center" style="width: 65px">
                                                    <span id="span_e">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center" style="width: 65px">
                                                    <input type="checkbox" name="checkbox" value="e" id="check_e" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/02.gif" id="img_u" name="02" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_u">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="u" id="check_u" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/03.gif" id="img_r" name="03" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_r">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="r" id="check_r" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/04.gif" id="img_l" name="04" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_l">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="l" id="check_l" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/05.gif" id="img_o" name="05" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_o">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="o" id="check_o" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/06.gif" id="img_h" name="06" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_h">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="h" id="check_h" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/07.gif" id="img_n" name="07" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_n">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="n" id="check_n" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/08.gif" id="img_t" name="08" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_t">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="t" id="check_t" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/09.gif" id="img_p" name="09" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_p">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="p" id="check_p" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/10.gif" id="img_s" name="10" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_s">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="s" id="check_s" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/11.gif" id="img_a" name="11" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_a">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="a" id="check_a" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/12.gif" id="img_i" name="12" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_i">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="i" id="check_i" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 30px;">
                                            <tr>
                                                <td height="50" align="center" valign="middle">
                                                    <img src="images/13.gif" id="img_m" name="13" /></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <span id="span_m">0</span></td>
                                            </tr>
                                            <tr>
                                                <td height="20" align="center">
                                                    <input type="checkbox" name="checkbox" value="m" id="check_m" /></td>
                                            </tr>
                                        </table>
                                    </li>
                                </ul>
                            </div>
                        </td>
                        <td>
                            <div class="gWright3">
                                <ul>
                                    <li class="gW1">合成配方</li>
                                    <li class="gW3">这里是存放你收集到的秘宝的口袋。</li>
                                    <li class="gW3">秘宝上的字母隐藏着如何取得芯片配方的秘密。</li>
                                    <li class="gW3">当你洞悉这个秘密时，就来这里试试你的运气，想知道你猜的到底是对是错？请点击“合成”按钮。</li>
                                    <li class="gW5">
                                        <input type="button" value="  合成  " onclick="compose();" id="compose" />
                                    </li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/btm_bg.gif" width="858" height="68" /></td>
        </tr>
    </table>
</body>
</html>
