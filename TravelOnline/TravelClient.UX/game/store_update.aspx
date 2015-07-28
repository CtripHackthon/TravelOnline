<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="store_update.aspx.cs" Inherits="TravelClient.UX.game.game_store_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>仓库</title>
</head>
<body background="images/back.gif">
    <form id="form1" runat="server">
    <div>
        <div id="u0_rtf">
            <span style="font-size: 11pt; color: #000000; font-family: ''cb'ce'cc'e5'"><b style="font-size: 10pt; font-family: 宋体">升级建筑</b></span><br />
            <br />
            <span style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'">&nbsp; <b>
                仓库<br />
            </b><span style="font-size: 12pt">------------------------</span><br />
                仓库是存储木材和石料的场所，升级可提高存储上限。<br />
                <br />
                &nbsp;当前等级:<asp:Label ID="lbcurrentlevel" runat="server" Text="Label"></asp:Label><br />
                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;升级材料:<br />
                &nbsp;木头
                <asp:Label ID="lbwoodneeded" runat="server" Text="Label"></asp:Label></span><span
                    style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'"> 石料
                    <asp:Label ID="lbstoneneeded" runat="server" Text="Label"></asp:Label></span><br />
            <span style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'">&nbsp;升级时间:<br />
                &nbsp;<asp:Label ID="lbhourneeded" runat="server" Text="Label"></asp:Label>小时<asp:Label
                    ID="lbminuteneeded" runat="server" Text="Label"></asp:Label>分<asp:Label ID="lbsecondcost"
                        runat="server" Text="00"></asp:Label>秒<br />
                <br />
                <asp:Button ID="btupdate" runat="server" Text="升级" OnClick="btupdate_Click" /><br />
                <br />
                <br />
            </span></div>
    
    </div>
    </form>
</body>
</html>
