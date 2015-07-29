<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="build_developroom.aspx.cs"
    Inherits="TravelClient.UX.game.game_build_developroom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Pragma" content="no-cache" />
    <title>无标题页</title>

    <script type="text/javascript">
    function LeftFrameRefresh(){
    window.parent.frames[0].location.reload();
    }</script>

</head>
<body background="images/back.gif">
    <form id="form1" runat="server">
        <div>
            <span style="font-size: 9pt; font-family: 宋体"><strong>研发所
                <br />
            </strong></span><span style="font-size: 0.8em; font-family: 宋体">------------------<br />
            </span><span style="font-size: 0.8em; font-family: 宋体">
                <br />
                研发所是开发芯片的场所，当你获得了一张芯片配方，需要现在研究所里完成开发才能开始生产.</span><p style="padding-right: 0px; padding-left: 0px;
                    padding-bottom: 10px; padding-top: 10px; text-align: center">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 51px;
                        height: 50px">
                        <tr>
                            <td align="center" background="images/house_bg.gif" style="width: 51px; text-align: center;"
                                valign="middle">
                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                    style="width: 53px; height: 51px">
                                    <param name="movie" value="images/build/20.swf">
                                    <param name="quality" value="high">
                                    <param name="wmode" value="transparent">
                                    <embed src="images/build/20.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                        type="application/x-shockwave-flash" width="48" height="48" wmode="transparent"></embed>
                                </object>
                            </td>
                        </tr>
                    </table>
                    <span style="font-size: 0.8em; font-family: 宋体"></span>
                </p>
            <p>
                <span style="font-size: 9pt; font-family: 宋体">等级1</span></p>
            <p>
                <span style="font-size: 9pt; font-family: 宋体"></span><span style="font-size: 0.8em;
                    font-family: 宋体">建筑材料</span></p>
            <p>
                <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                    font-family: 宋体">木头:<asp:Label ID="lbDwoodneeded" runat="server" Font-Size="Small"
                        Text="8"></asp:Label>,</span><span style="font-size: 0.8em; font-family: 宋体">石料:<asp:Label
                            ID="lbDstoneneeded" runat="server" Font-Size="Small" Text="6"></asp:Label></span></p>
            <p style="padding-right: 0px; padding-left: 0px; padding-bottom: 10px; padding-top: 10px;
                text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                    font-family: 宋体">建筑时间:</span><span style="font-size: 0.8em; font-family: 宋体">0小时</span><asp:Label
                        ID="lbDtimeneeded" runat="server" Font-Size="Small" Text="2"></asp:Label><span style="font-size: 0.8em;
                            font-family: 宋体">分0秒 </span>
            </p>
            <p style="padding-right: 0px; padding-left: 0px; padding-bottom: 10px; padding-top: 10px;
                text-align: left">
                <span style="font-size: 0.8em; font-family: 宋体"></span><span style="font-size: 0.8em;
                    font-family: 宋体">
                    <asp:Button ID="btdeveloproom" runat="server" Height="23px" OnClick="btdeveloproom_Click"
                        Text="建造" Width="61px" /></span>&nbsp;<asp:Button ID="btcancel" runat="server" OnClick="btcancel_Click"
                            Text="返回" Width="61px" /></p>
        </div>
    </form>
</body>
</html>
