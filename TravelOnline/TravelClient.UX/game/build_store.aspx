<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="build_store.aspx.cs" Inherits="TravelClient.UX.game.game_build_store" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Pragma" content="no-cache" />
    <title>无标题页</title>
</head>
<body background="images/back.gif">
    <form id="form1" runat="server">
        <div>
            <span style="font-size: 9pt; font-family: 宋体"><strong style="font-size: 10pt; font-family: 宋体">
                仓库<br />
            </strong></span><span class="gW4"><span class="gW4"><span class="gW4"><span style="font-size: 0.8em;
                font-family: 宋体">------------------</span><span class="gW4"></span><span class="gW4"></span><span
                    class="gW4"></span><p style="text-align: left">
                        <span style="font-size: 0.8em; font-family: 宋体"></span><span class="gW4"></span>
                        <span class="gW4"><span class="gW4"><span class="gW4"><span style="font-size: 0.8em;
                            font-family: 宋体">储存一切原料(木头、石料)</span></span></span></span></p>
                <span class="gW4"><span style="font-size: 0.8em; font-family: 宋体">
                    <p style="text-align: left">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" height="55" width="55">
                            <tr>
                                <td align="center" background="images/house_bg.gif" style="width: 58px" valign="middle">
                                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                        style="width: 54px; height: 54px">
                                        <param name="movie" value="images/build/10.swf">
                                        <param name="quality" value="high">
                                        <param name="wmode" value="transparent">
                                        <embed src="images/build/10.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                            type="application/x-shockwave-flash" width="48" height="48" wmode="transparent"></embed>
                                    </object>
                                </td>
                            </tr>
                        </table>
                    </p>
                    <p style="text-align: left">
                    </p>
                    等级1</span><p style="text-align: left">
                        <span style="font-size: 0.8em; font-family: 宋体">建筑材料:</span></p>
                    <p style="text-align: left">
                        <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                            font-family: 宋体">木头:</span><asp:Label ID="lbSwoodneeded" runat="server" Font-Size="Small"
                                Text="6"></asp:Label>,<span style="font-size: 0.8em; font-family: 宋体">石料:</span><asp:Label
                                    ID="lbSstoneneeded" runat="server" Font-Size="Small" Text="6"></asp:Label></p>
                    <p>
                        <span style="font-size: 10pt; font-family: 宋体"><span style="font-size: 9pt; font-family: 宋体">
                            建筑时间</span>:</span></p>
                    <p>
                        <span style="font-size: 10pt; font-family: 宋体">0小时</span><asp:Label ID="lbStimeneeded"
                            runat="server" Font-Size="Small" Text="6"></asp:Label><span style="font-size: 0.8em;
                                font-family: 宋体">分0秒 </span><span style="font-size: 0.8em; font-family: 宋体"></span>
                    </p>
                    <p style="text-align: left">
                        <asp:Button ID="btstore" runat="server" Height="23px" OnClick="btdeveloproom_Click"
                            Text="建造" Width="61px" />&nbsp;<asp:Button ID="btcancel" runat="server" OnClick="btcancel_Click"
                                Text="返回" Width="61px" /></p>
                </span></span></span></span>
        </div>
    </form>
</body>
</html>
