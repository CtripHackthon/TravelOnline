<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="build_market.aspx.cs" Inherits="TravelClient.UX.game.game_build_market" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Pragma" content="no-cache" />
    <title>无标题页</title>
</head>
<body background="images/back.gif">
    <form id="form1" runat="server">
        <div>
            <span style="font-size: 9pt; font-family: 宋体"><strong>市场
                <br />
            </strong></span><span style="font-size: 0.8em; font-family: 宋体">------------------<br />
                <br />
            </span><span style="font-size: 0.8em; font-family: 宋体">市场是出售芯片的场所，你生产出来的芯片都是在这里出售，换成龙币的.</span><p
                style="padding-right: 0px; padding-left: 0px; padding-bottom: 10px; padding-top: 10px;
                text-align: center">
                <table align="center" border="0" cellpadding="0" cellspacing="0" height="55" width="55">
                    <tr>
                        <td align="center" background="images/house_bg.gif" valign="middle">
                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                style="width: 51px; height: 56px">
                                <param name="movie" value="images/build/40.swf">
                                <param name="quality" value="high">
                                <param name="wmode" value="transparent">
                                <embed src="images/build/40.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                    type="application/x-shockwave-flash" width="48" height="48" wmode="transparent"></embed>
                            </object>
                        </td>
                    </tr>
                </table>
            </p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">等级1</span></p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">建筑材料:</span></p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                    font-family: 宋体">木头:<asp:Label ID="lbMwoodneeded" runat="server" Font-Size="Small"
                        Text="6"></asp:Label>,</span><span style="font-size: 0.8em; font-family: 宋体">石料:<asp:Label
                            ID="lbMstoneneeded" runat="server" Font-Size="Small" Text="6"></asp:Label></span></p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">建筑时间:</span></p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                    font-family: 宋体">0小时</span><asp:Label ID="lbMtimeneeded" runat="server" Font-Size="Small"
                        Text="2"></asp:Label><span style="font-size: 0.8em; font-family: 宋体">分0秒&nbsp;</span></p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体"></span>
                <asp:Button ID="btmarket" runat="server" Height="23px" OnClick="btdeveloproom_Click"
                    Text="建造" Width="61px" /><span style="font-size: 0.8em; font-family: 宋体">
                        <asp:Button ID="btcancel" runat="server" OnClick="btcancel_Click" Text="返回" Width="61px" /></span></p>
        </div>
    </form>
</body>
</html>
