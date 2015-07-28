<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="build_welcome.aspx.cs" Inherits="TravelClient.UX.game.game_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body background="images/back.gif" style="text-align: left">
    <form id="form1" runat="server">
        <div style="font-size: 10pt; font-family: 宋体">
            <strong>建造新建筑<br />
            </strong>------------------<br />
            <br />
            你当前选中的是一片空地，<br />
            可以在此空地上建筑以下建筑<br />
            <br />
            <table>
                <tr>
                    <td style="width: 81px; height: 17px; text-align: left">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 51px;
                            height: 50px">
                            <tr>
                                <td align="center" background="images/house_bg.gif" style="width: 51px" valign="middle">
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
                    </td>
                    <td style="width: 87px; height: 17px; text-align: left;">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" style="width: 37px;
                            height: 45px">
                            <tr>
                                <td align="center" background="images/house_bg.gif" valign="middle">
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
                    </td>
                </tr>
                <tr>
                    <td style="width: 81px; height: 21px; text-align: center;">
                        <asp:HyperLink ID="HyperLink4" runat="server" Font-Size="Small" NavigateUrl="~/game/build_developroom.aspx">研发所</asp:HyperLink>
                    </td>
                    <td style="width: 87px; height: 21px; text-align: center;">
                        &nbsp;<asp:HyperLink ID="HyperLink5" runat="server" Font-Size="Small" NavigateUrl="~/game/build_factory.aspx">工厂</asp:HyperLink></td>
                </tr>
            </table>
        </div>
        <table>
            <tr>
                <td style="width: 79px">
                </td>
                <td style="width: 88px">
                </td>
            </tr>
            <tr>
                <td style="width: 79px">
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
                </td>
                <td style="width: 88px">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" height="55" width="55">
                        <tr>
                            <td align="center" background="images/house_bg.gif" style="width: 58px; height: 55px;"
                                valign="middle">
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
                </td>
            </tr>
            <tr>
                <td style="width: 79px; text-align: center">
                    <asp:HyperLink ID="HyperLink3" runat="server" Font-Size="Small" NavigateUrl="~/game/build_market.aspx">市场</asp:HyperLink></td>
                <td style="width: 88px; text-align: center">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/game/build_store.aspx">仓库</asp:HyperLink></td>
            </tr>
        </table>
    </form>
</body>
</html>
