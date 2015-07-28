<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="build_factory.aspx.cs" Inherits="TravelClient.UX.game.game_build_factory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Pragma" content="no-cache" />
    <title>无标题页</title>
</head>
<body background="images/back.gif">
    <form id="form1" runat="server">
        <div>
            <span style="font-size: 9pt; font-family: 宋体"><strong>工厂
                <br />
            </strong></span><span style="font-size: 0.8em; font-family: 宋体">------------------</span><p
                style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">工厂是生产芯片的场所，当你开发成功一款芯片后</span><span
                    style="font-size: 0.8em; font-family: 宋体">，可以在工厂进行批量生产。 </span>
            </p>
            <p style="padding-right: 0px; padding-left: 0px; padding-bottom: 10px; padding-top: 10px;
                text-align: left">
                &nbsp;<table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 37px;
                    height: 45px">
                    <tr>
                        <td align="center" background="images/house_bg.gif" valign="middle" style="width: 53px">
                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                style="width: 52px; height: 52px">
                                <param name="movie" value="images/build/30.swf">
                                <param name="quality" value="high">
                                <param name="wmode" value="transparent">
                                <embed src="images/build/30.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                    type="application/x-shockwave-flash" width="48" height="48" wmode="transparent"></embed>
                            </object>
                        </td>
                    </tr>
                </table>
            </p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">等级1 </span>
            </p>
            <p>
                <span style="font-size: 0.8em; font-family: 宋体">建筑材料:</span></p>
            <p>
                <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                    font-family: 宋体">木头:<asp:Label ID="lbFwoodneeded" runat="server" Font-Size="Small"
                        Text="8"></asp:Label>,</span><span style="font-size: 0.8em; font-family: 宋体">石料:<asp:Label
                            ID="lbFstoneneeded" runat="server" Font-Size="Small" Text="8"></asp:Label></span></p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">建筑时间:</span></p>
            <p class="gW4" style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">0小时</span><asp:Label ID="lbFtimeneeded"
                    runat="server" Font-Size="Small" Text="2"></asp:Label><span style="font-size: 0.8em;
                        font-family: 宋体">分0秒</span></p>
            <p class="gW4" style="text-align: left">
                <asp:Button ID="btfactory" runat="server" Height="23px" OnClick="btdeveloproom_Click"
                    Text="建造" Width="61px" /><span style="font-size: 0.8em; font-family: 宋体">
                        <asp:Button ID="btcancel" runat="server" OnClick="btcancel_Click" Text="返回" Width="61px" /></span></p>
        </div>
    </form>
</body>
</html>
