<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="building_permited.aspx.cs"
    Inherits="TravelClient.UX.game.long_game_building_permited" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>建造建筑</title>
    <style type="text/css">

</style>

    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
    </script>

</head>
<body background="images/back.gif">
    <form id="form1" runat="server">
        <div>
            <span style="font-size: 1em; font-family: 宋体"><strong>
                    建造新建筑 </strong></span></div>
        <p class="gW2" style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">研发所 </span>
        </p>
        <p class="gW2" style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                font-family: 宋体">------------------</span></p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">研发所是开发芯片的场所，当你获得了一张芯片配方，需要现在研究所里完成开发才能开始生产。
            </span>
        </p>
        <p style="padding: 10px 0; text-align: left;">
            &nbsp;<table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 51px;
                height: 50px">
                <tr>
                    <td align="center" background="images/house_bg.gif" valign="middle" style="width: 51px">
                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                            style="width: 53px; height: 51px">
                            <param name="movie" value="images/build/20.swf" />
                            <param name="quality" value="high" />
                            <param name="wmode" value="transparent" />
                        </object>
                    </td>
                </tr>
            </table>
        </p>
            <p style="padding-right: 0px; padding-left: 0px; padding-bottom: 10px; padding-top: 10px;
                text-align: left"><span style="font-size: 0.8em; font-family: 宋体">等级1 </span></p>
            <p><span style="font-size: 0.8em; font-family: 宋体">
                建筑材料:</span><asp:Label ID="lbDwoodneeded" runat="server" Text="8" Font-Size="Smaller"></asp:Label><span
                    style="font-size: 0.8em; font-family: 宋体">木头</span><asp:Label ID="lbDstoneneeded"
                        runat="server" Text="6" Font-Size="Smaller"></asp:Label><span style="font-size: 0.8em;
                            font-family: 宋体">石头</span></p>
            <p class="gW4" style="text-align: left"><span style="font-size: 0.8em;
                                font-family: 宋体">建筑时间:</span><span style="font-size: 0.8em; font-family: 宋体">0小时</span><asp:Label
                                    ID="lbDtimeneeded" runat="server" Text="2" Font-Size="Smaller"></asp:Label><span
                                        style="font-size: 0.8em; font-family: 宋体">分0秒 </span></p>
        <p class="gW5" style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">&nbsp;</span><asp:Button ID="btdeveloproom"
                runat="server" Height="23px" Text="建造" Width="61px" OnClick="btdeveloproom_Click" /></p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">工厂 </span>
        </p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">------------------</span></p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">工厂是生产芯片的场所，当你开发成功一款芯片后，可以在工厂进行批量生产。
            </span>
        </p>
        <p style="padding: 10px 0; text-align: left;">
            &nbsp;<table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 37px;
                height: 45px">
                <tr>
                    <td align="center" background="images/house_bg.gif" valign="middle">
                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                            style="width: 52px; height: 52px">
                            <param name="movie" value="images/build/30.swf" />
                            <param name="quality" value="high" />
                            <param name="wmode" value="transparent" />
                        </object>
                    </td>
                </tr>
            </table>
        </p>
            <p class="gW4" style="text-align: left"><span style="font-size: 0.8em; font-family: 宋体">
                等级1 </span></p>
            <p><span style="font-size: 0.8em; font-family: 宋体">
                建筑材料:</span><asp:Label ID="lbFwoodneeded" runat="server" Text="8" Font-Size="Smaller"></asp:Label><span
                    style="font-size: 0.8em; font-family: 宋体">木头</span><asp:Label ID="lbFstoneneeded"
                        runat="server" Text="8" Font-Size="Smaller"></asp:Label><span style="font-size: 0.8em;
                            font-family: 宋体">石料 </span></p>
            <p class="gW4" style="text-align: left"><span style="font-size: 0.8em; font-family: 宋体">
                建筑时间:0小时</span><asp:Label ID="lbFtimeneeded" runat="server" Text="2" Font-Size="Smaller"></asp:Label><span
                    style="font-size: 0.8em; font-family: 宋体">分0秒</span></p>
        <p class="gW4" style="text-align: left">
            <asp:Button ID="btfactory" runat="server" Height="23px" Text="建造" Width="61px" OnClick="btdeveloproom_Click" /><span
                style="font-size: 0.8em; font-family: 宋体"> </span>
        </p>
        <p class="gW4" style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                font-family: 宋体">市场 </span>
        </p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">------------------</span></p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">市场是出售芯片的场所，你生产出来的芯片都是在这里出售，换成龙币的。 </span>
        </p>
        <p style="padding: 10px 0; text-align: left;">
            &nbsp;<table align="center" border="0" cellpadding="0" cellspacing="0" height="55"
                width="55">
                <tr>
                    <td align="center" background="images/house_bg.gif" valign="middle">
                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" style="width: 51px; height: 56px">
                            <param name="movie" value="images/build/40.swf" />
                            <param name="quality" value="high" />
                            <param name="wmode" value="transparent" />
                        </object>
                    </td>
                </tr>
            </table>
        </p>
            <p class="gW4" style="text-align: left"><span style="font-size: 0.8em; font-family: 宋体">
                等级1</span></p>
            <p class="gW4" style="text-align: left"><span style="font-size: 0.8em; font-family: 宋体">
                建筑材料:</span><asp:Label ID="lbMwoodneeded" runat="server" Text="6" Font-Size="Smaller"></asp:Label><span
                    style="font-size: 0.8em; font-family: 宋体">木头 </span>
                <asp:Label ID="lbMstoneneeded" runat="server" Text="6" Font-Size="Smaller"></asp:Label><span
                    style="font-size: 0.8em; font-family: 宋体">石料 </span></p>
            <p class="gW4" style="text-align: left"><span style="font-size: 0.8em; font-family: 宋体">
                建筑时间:0小时</span><asp:Label ID="lbMtimeneeded" runat="server" Text="2" Font-Size="Smaller"></asp:Label><span
                    style="font-size: 0.8em; font-family: 宋体">分0秒 </span></p>
        <p class="gW5" style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体">&nbsp;</span><asp:Button ID="btmarket"
                runat="server" Height="23px" Text="建造" Width="61px" OnClick="btdeveloproom_Click" /><span
                    style="font-size: 0.8em; font-family: 宋体"> </span>
        </p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体;">仓库</span><span class="gW4"><span
                class="gW4"><span class="gW4"></p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体"></span>
            <span style="font-size: 0.8em; font-family: 宋体">------------------</span><span class="gW4"><span
                class="gW4"><span class="gW4"></span></p>
        <p style="text-align: left">
            <span style="font-size: 0.8em; font-family: 宋体"></span><span class="gW4"><span
                class="gW4"><span class="gW4"><span class="gW4">
                <span style="font-size: 0.8em; font-family: 宋体">储存一切原料(木头、石料)</span></span></span></span></p>
        <span class="gW4"><span style="font-size: 0.8em; font-family: 宋体">
            <p style="text-align: left">
                <table align="center" border="0" cellpadding="0" cellspacing="0" height="55" width="55">
                    <tr>
                        <td align="center" background="images/house_bg.gif" style="width: 58px" valign="middle">
                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                style="width: 54px; height: 54px">
                                <param name="movie" value="images/build/10.swf" />
                                <param name="quality" value="high" />
                                <param name="wmode" value="transparent" />
                            </object>
                        </td>
                    </tr>
                </table>
            </p>
                <p style="text-align: left">等级1<br />
        </span>
            <span style="font-size: 0.8em; font-family: 宋体"></span><p style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">建筑材料:</span><span
                    style="font-size: 0.8em; font-family: 宋体">木头:</span><asp:Label ID="lbSwoodneeded"
                        runat="server" Text="6" Font-Size="Smaller"></asp:Label><span style="font-size: 0.8em;
                            font-family: 宋体">石材:</span><asp:Label ID="lbSstoneneeded" runat="server" Text="6"
                                Font-Size="Smaller"></asp:Label></p>
            <p style="text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体">建筑时间:0小时</span><asp:Label
                    ID="lbStimeneeded" runat="server" Text="6" Font-Size="Smaller"></asp:Label><span
                        style="font-size: 0.8em; font-family: 宋体">分0秒 </span>
            <span style="font-size: 0.8em; font-family: 宋体"></span>
            </p>
            <p style="text-align: left">
                <asp:Button ID="btstore" runat="server" Height="23px" Text="建造" Width="61px" OnClick="btdeveloproom_Click" />&nbsp;</p>
        </span>
    </form>
</body>
</html>
