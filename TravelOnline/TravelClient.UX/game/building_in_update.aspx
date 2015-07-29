<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="building_in_update.aspx.cs"
    Inherits="TravelClient.UX.game.game_building_in_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>建筑升级中</title>

    <script type="text/javascript">
    var total='<%=Session["eof_dt"]%>';
//    window.parent.frames[0].location.reload();
    function show()
    {
        var myclock=document.getElementById("myclock");
        var hour = Math.floor(total / 3600);
        var minuit = Math.floor(total % 3600 / 60);
        var second = Math.floor(total % 60);
        myclock.innerHTML="<font size=2px>"+hour+"小时"+minuit+"分钟"+second+"秒</font>";
        total--;
         if (total==0)
         {
            window.location.href="dealAccomplish.aspx?type=2";
            return;
         }
        setTimeout ("show()",1000);
    }
    </script>

</head>
<body background="images/back.gif" onload="show();" style="width: 130px">
    <form id="form1" runat="server">
        <div style="text-align: left">
            <p>
                <strong><span style="font-size: 0.8em; font-family: 宋体">升级建筑</span></strong>&nbsp;</p>
            <p>
                <span style="font-size: 0.8em; font-family: 宋体"><span style="font-size: 12pt; font-family: Times New Roman">
                    <span style="font-size: 12pt">
                        <asp:Label ID="lbbuildingtype" runat="server" Font-Bold="True" Height="14px" Text="Label"
                            Width="62px" Font-Size="Smaller"></asp:Label></span></span></span>&nbsp;</p>
            <p>
                <span style="font-size: 0.8em; font-family: 宋体"><span style="font-size: 12pt; font-family: Times New Roman">
                    <span style="font-size: 12pt">---------------------</span></span></span><br />
                <asp:Label ID="lbdescription" runat="server" Height="60px" Text="Label" Width="103px"
                    Font-Size="Small" Font-Names="宋体"></asp:Label></p>
            <br />
            <span style="font-size: 0.8em; font-family: 宋体">
                <asp:Label ID="lbcurrenttitle" runat="server" Height="12px" Text="Label" Width="130px"
                    Font-Size="Small" Font-Names="宋体"></asp:Label></span><br />
            <table style="width: 129px">
                <tr>
                    <td>
                        <span style="font-size: 0.8em; font-family: 宋体">
                            <asp:Label ID="lbcurrentwoodtitle" runat="server" Height="20px" Text="木头:" Width="42px"
                                Visible="False" Font-Size="Small"></asp:Label>
                        </span>
                    </td>
                    <td>
                        <span style="font-size: 0.8em; font-family: 宋体">
                            <asp:Label ID="lbcurrentability" runat="server" Height="17px" Text="Label" Width="50px"
                                Font-Size="Small"></asp:Label></span></td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 0.8em; font-family: 宋体">
                            <asp:Label ID="lbcurrentstonetitle" runat="server" Height="12px" Text="石料:" Width="40px"
                                Visible="False" Font-Size="Small"></asp:Label></span>
                    </td>
                    <td>
                        <span style="font-size: 0.8em; font-family: 宋体">
                            <asp:Label ID="lbcurrentability1" runat="server" Height="6px" Text="Label" Width="50px"
                                Visible="False" Font-Size="Small"></asp:Label></span></td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lbnexttitle" runat="server" Height="12px" Text="Label" Width="130px"
                Font-Size="Small" Font-Names="宋体"></asp:Label><span style="font-size: 0.8em; font-family: 宋体"><br />
                </span><span style="font-size: 0.8em; font-family: 宋体"></span>
            <table style="width: 122px">
                <tr>
                    <td>
                        <asp:Label ID="lbnextwoodtitle" runat="server" Height="12px" Text="木头:" Visible="False"
                            Width="35px" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbnextability" runat="server" Text="Label" Width="54px" Font-Size="Small"
                            Height="13px"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbnextstonetitle" runat="server" Height="12px" Text="石料:" Visible="False"
                            Width="30px" Font-Size="Small"></asp:Label></td>
                    <td>
                        <asp:Label ID="lbnextability1" runat="server" Text="Label" Width="56px" Visible="False"
                            Font-Size="Small" Height="15px"></asp:Label></td>
                </tr>
            </table>
            <br />
            <span style="font-size: 0.8em; font-family: 宋体">距离升级完成还有：<br />
            </span>
            <asp:Label ID="myclock" runat="server" Text="Label" Font-Size="Small" Width="130px"></asp:Label><br />
            <br />
        </div>
    </form>
</body>
</html>
