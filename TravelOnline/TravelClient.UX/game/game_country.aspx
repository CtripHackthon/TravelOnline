<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="game_country.aspx.cs" Inherits="TravelClient.UX.game.game_game_country" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="Pragma" content="no-cache" />
    <title>
        <%=Session["user_id"] %>
        �Ĵ�ׯ</title>

    <script type="text/javascript">
      function LoginStateCheck(){
          if('<%=Session["user_id"]!=null %>'=='True')
          {
            document.getElementById("log_in_state").innerHTML='<%=Session["user_id"] %>'+' ��ӭ�� '+'<a href="../logout.aspx" class="a">�˳���¼</a> &nbsp;&nbsp;';
          }
      } 
         
    function show(){
        window.location.reload();    
    }
    
    function SetTimeOut(){
        timeSpan=<%=Session["time_span"] %>;
        setTimeout("show()",timeSpan*1000+1000);
    }
    
    function LoadIframe(){
        document.getElementById("leftFrame").src="game_country_body.aspx";
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
	    overflow-y: auto;
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
    .gameLink a{
	    font-weight: bold;
	    color: #000;
	    text-decoration: none;
    }
    -->
    
    </style>
</head>
<body onload="SetTimeOut();LoginStateCheck();LoadIframe();">
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
                                    <a href="../index.aspx">��ҳ</a> | <a href="../article.aspx">�����ȵ�</a> | <a href="../school_vendition/index_vendition.aspx">
                                        �ר��</a> | <a href="../virtual_store/index_virtual_store.aspx">�콢��</a> |
                                    <a href="../long_man_pk/index_long_man_pk.aspx">������</a> | <a href="../magazine/index_magazine.aspx">
                                        ������־</a></td>
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
                                    ������</td>
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
                                                ľͷ
                                                <asp:Label ID="lbCurrentWoodCount" runat="server" Text="0"></asp:Label>/<asp:Label
                                                    ID="lbTotalWoodCount" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td style="color: #FFFFFF;">
                                                ʯ��
                                                <asp:Label ID="lbCurrentStoneCount" runat="server" Text="0"></asp:Label>/<asp:Label
                                                    ID="lbTotalStoneCount" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td style="color: #FFFFFF;">
                                                ����
                                                <asp:Label ID="lbCurrentMoneyCount" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="23%">
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tr align="center">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                                    width="48" height="70">
                                                    <param name="movie" value="images/01-2.swf" />
                                                    <param name="quality" value="high" />
                                                    <param name="wmode" value="transparent" />
                                                    <embed src="images/01-2.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                        type="application/x-shockwave-flash" width="48" height="70" wmode="transparent"></embed>
                                                </object>
                                            </td>
                                            <td>
                                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                                    width="48" height="70">
                                                    <param name="movie" value="images/01-1.swf" />
                                                    <param name="quality" value="high" />
                                                    <param name="wmode" value="transparent">
                                                    <embed src="images/01-1.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                        type="application/x-shockwave-flash" width="48" height="70" wmode="transparent"></embed>
                                                </object>
                                            </td>
                                            <td>
                                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                                    width="48" height="70">
                                                    <param name="movie" value="images/01-3.swf" />
                                                    <param name="quality" value="high" />
                                                    <param name="wmode" value="transparent">
                                                    <embed src="images/01-3.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                        type="application/x-shockwave-flash" width="48" height="70" wmode="transparent"></embed>
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
                    <td height="449" valign="top" background="images/mid_back.jpg">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="646" align="right">
                                    <div class="gameWeb">
                                        <iframe id="leftFrame" name="leftFrame" width="600" height="427" src="" scrolling="no"
                                            frameborder="0"></iframe>
                                    </div>
                                </td>
                                <td valign="top">
                                    <div class="gWright">
                                        <iframe name="rightFrame" width="172" height="404" src="welcome.aspx" scrolling="auto"
                                            frameborder="0"></iframe>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="images/btm_bg.gif" width="858" height="39" border="0" usemap="#Map" /></td>
                </tr>
            </table>
            <map name="Map" id="Map">
                <area shape="rect" coords="724,10,791,27" href="game_introduction.aspx" target="_blank" />
            </map>
        </div>
    </form>
</body>
</html>
