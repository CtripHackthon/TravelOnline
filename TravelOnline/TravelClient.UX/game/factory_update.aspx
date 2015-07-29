<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="factory_update.aspx.cs" Inherits="TravelClient.UX.game.game_factory_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>市场销售 </title>
</head>
<body background="images/back.gif" style="font-size: 10pt; font-family: 宋体; width:130px">
    <form id="form1" runat="server">
    <div style="text-align: left">
        <span><strong>升级建筑<br />
            <br />
        工厂：&nbsp;</strong><br />
            <b><span style="font-size: 12pt"><span
                style="font-size: 12pt"><span style="font-size: 12pt">--------------<br />
                </span></span></span><br />
            </b>
            <span><span style="font-size: 1.1em"><span style="font-size: 1em"> <span style="font-size: 0.8em">工厂是生产芯片的场所，当你开发成功一款芯片后，可以在工厂进行批量生产。&nbsp;</span></span></span></span><br />
            当前等级：<asp:Label ID="lbcurrentlevel" runat="server" Text="Label"></asp:Label><br />
            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
            升级材料：&nbsp;<br />
            木头
            <asp:Label ID="lbwoodneeded" runat="server" Text="Label"></asp:Label></span><span
                style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'"> 石料
                <asp:Label ID="lbstoneneeded" runat="server" Text="Label"></asp:Label></span><br />
        <br />
        <span style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'"> 升级时间：<br />
            <asp:Label ID="lbhourneeded" runat="server" Text="Label"></asp:Label>小时<asp:Label
                ID="lbminuteneeded" runat="server" Text="Label"></asp:Label>分<asp:Label ID="lbsecondcost"
                    runat="server" Text="00"></asp:Label>秒<br />
            <asp:Button ID="btupdate" runat="server" Text="升级" OnClick="btupdate_Click" /><br />
            <br />
            <asp:GridView ID="gvchipdetail" runat="server" AutoGenerateColumns="False" ShowHeader="False" OnRowDataBound="GridView1_RowDataBound" PageSize="6" BorderWidth="0px" Font-Size="Small" Width="130px">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table style="width: 130px">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lbchipname" runat="server" Font-Size="Small" Height="28px" Text="Label"
                                            Width="130px" Font-Bold="True"></asp:Label><br />
                                        <span style="font-size: 12pt">---------------</span></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 17px; text-align: left">
                                        <asp:Image ID="imchippic" runat="server" Height="64px" Width="122px" /></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        生产成本：<asp:Label ID="lbchipcost" runat="server" Text="Label"></asp:Label>龙币</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        生产时间：<br />
                                        <asp:Label ID="lbhourcost" runat="server" Text="Label"></asp:Label>小时<asp:Label
                                            ID="lbminutecost" runat="server" Text="Label" Width="9px"></asp:Label>分<asp:Label ID="lbsecondcost"
                                                runat="server" Text="Label"></asp:Label>秒</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        生产数量：<asp:TextBox ID="tbchipnumber" runat="server" OnTextChanged="tbchipnumber_TextChanged" Width="53px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left">
                                        <asp:Button ID="btstart" runat="server" Text="开始生产" OnClick="btstart_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                    </td>
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
