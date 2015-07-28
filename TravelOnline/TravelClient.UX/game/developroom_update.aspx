<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="developroom_update.aspx.cs" Inherits="TravelClient.UX.game.game_developroom_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>研发所</title>
</head>
<body background="images/back.gif" style="font-size: 10pt; font-family: 宋体; width:130px">
    <form id="form1" runat="server">
    <div style="text-align: left">
        <span><strong>升级建筑<br />
            <br />
        研发所</strong><br />
            <b><span style="font-size: 12pt"><span style="font-size: 12pt">--------------</span></span><br />
            </b><span style="font-family: 宋体"><span style="font-size: 1em">
                <br />
                <span>研发所是开发芯片的场所，当你获得了一张芯片配方，需要现在研究所里完成开发才能开始生产。</span></span></span><br />
            &nbsp; &nbsp;<br />
            当前等级:<asp:Label ID="lbcurrentlevel" runat="server" Text="Label" Font-Size="Small"></asp:Label><br />
            &nbsp; &nbsp;&nbsp;&nbsp;<br />
            升级材料:<br />
            木头<asp:Label ID="lbwoodneeded" runat="server" Text="Label" Font-Size="Small"></asp:Label></span><span
                style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'"> 
                <br />
                石料<asp:Label ID="lbstoneneeded" runat="server" Text="Label" Font-Size="Small"></asp:Label></span><br />
        <br />
        <span style="font-size: 10pt; color: #000000; font-family: ''cb'ce'cc'e5'">升级时间:<br />
            <asp:Label
            ID="lbhourneeded" runat="server" Text="Label" Font-Size="Small"></asp:Label>小时<asp:Label ID="lbminuteneeded"
                runat="server" Text="Label" Font-Size="Small"></asp:Label>分<asp:Label ID="lbsecondcost"
                    runat="server" Font-Size="Small" Text="00"></asp:Label>秒<br />
            <asp:Button ID="btupdate" runat="server" Text="升级" OnClick="btupdate_Click" /><br />
            <asp:GridView ID="gvchipdetail" runat="server" AutoGenerateColumns="False" PageSize="6"
                ShowHeader="False" OnRowDataBound="gvchipdetail_RowDataBound" BorderWidth="0px" Width="130px" Font-Size="Small">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table style="width: 130px; height: 31px">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lbchipname" runat="server" Font-Size="Small" Height="28px" Text="Label"
                                            Width="100px" Font-Bold="True"></asp:Label><br />
                                        <span style="font-size: 12pt">
                                            <br />
                                            ----------------</span></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lbchipdetail" runat="server" Height="150px" Text="Label" Width="130px" Font-Size="Small" Font-Bold="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        研发经费:<asp:Label ID="lbchipcost" runat="server" Text="Label" Font-Size="Small"></asp:Label>金币</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        研发时间:<br />
                                        <asp:Label ID="lbhourcost" runat="server" Text="Label" Font-Size="Small"></asp:Label>小时<asp:Label
                                            ID="lbminutecost" runat="server" Text="Label" Font-Size="Small"></asp:Label>分<asp:Label ID="lbsecondcost"
                                                runat="server" Text="Label" Font-Size="Small"></asp:Label>&nbsp; 秒</td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: left">
                                        <asp:Button ID="btstart" runat="server" Text="开始研发" OnClick="btstart_Click" /></td>
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
