<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="market_update.aspx.cs" Inherits="TravelClient.UX.game.game_market_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>市场</title>
    <script type="text/javascript">
     if('<%=IsPostBack%>'=="True")
       {
            window.parent.location.reload()
       }
    </script>
</head>
<body background="images/back.gif" style="font-size: 10pt; font-family: 宋体; width:130px">
    <form id="form1" runat="server">
    <div style="text-align: left">
        <span><strong>升级建筑<br />
            <br />
        市场：&nbsp;</strong><b><br />
            </b><span style="font-size: 12pt">---------------</span><br />
            <span style="font-size: 9pt"> 市场是出售芯片的场所，你生产出来的芯片都是在这里出售，换成龙币的。</span><br />
            <br />
            当前等级:<asp:Label ID="lbcurrentlevel" runat="server" Text="Label"></asp:Label><br />
            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
            升级材料:<br />
            木头
            <asp:Label ID="lbwoodneeded" runat="server" Text="Label"></asp:Label></span><span
                style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'"> 石料<asp:Label ID="lbstoneneeded" runat="server" Text="Label"></asp:Label></span><br />
        <br />
        <span style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'"> 升级时间:<br />
            <asp:Label ID="lbhourneeded" runat="server" Text="Label"></asp:Label>小时<asp:Label
                ID="lbminuteneeded" runat="server" Text="Label"></asp:Label>分<asp:Label ID="lbsecondcost"
                    runat="server" Text="00"></asp:Label>秒<br />
            <br />
            <asp:Button ID="btupdate" runat="server" Text="升级" OnClick="btupdate_Click" /><br />
            <asp:GridView ID="gvchipdetail" runat="server" AutoGenerateColumns="False" PageSize="6" OnRowDataBound="gvchipdetail_RowDataBound" BorderWidth="0px" Font-Size="Small" Width="130px">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table style="width:130px">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lbchipname" runat="server" Height="32px" Text="Label" Width="130px" Font-Size="Small" Font-Bold="True"></asp:Label><br />
                                        <span style="font-size: 12pt">----------------</span></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left">
                                        <asp:Image ID="imchip" runat="server" Height="70px" Width="115px" BorderWidth="0px" /></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <span style="font-size: 1em; font-family: 宋体">
                                        库存数量：</span><asp:Label ID="lbtotalnumber" runat="server" Text="Label" Font-Size="Small"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <span style="font-size: 1em; font-family: 宋体">单价</span>：<asp:Label ID="lbeachcost" runat="server" Text="Label" Font-Size="Small"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <span style="font-size: 1em; font-family: 宋体">出售数量</span>：<asp:TextBox ID="tbsalecount" runat="server" Font-Size="Smaller" Width="53px"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left">
                                        <asp:Button ID="btsale" runat="server" Text="售出" OnClick="btsale_Click" /></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </span></div>
    </form>
</body>
</html>
