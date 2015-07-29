<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="developroom_working.aspx.cs" Inherits="TravelClient.UX.game.game_developroom_working" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <script type="text/javascript">
    var total='<%=Session["eof_dt"]%>';
    function show()
    {
        var myclock=document.getElementById("myclock");
        var hour = Math.floor(total / 3600);
        var minuit = Math.floor(total % 3600 / 60);
        var second = Math.floor(total % 60);
        myclock.innerHTML=hour+"小时"+minuit+"分钟"+second+"秒";
        total--;
         if (total==0)
         {
            window.location.href="dealAccomplish.aspx?type=3";
            return;
         }
        setTimeout ("show()",1000);
    }
</script>
</head>
<body background="images/back.gif" onload="show();" style="font-size: 12pt; width:130px">
    <form id="form1" runat="server">
    <div style="text-align: left">
        <strong style="font-size: 10pt; font-family: 宋体">研发所研发中<br />
        </strong><span>--------------------</span><br />
        <span style="font-size: 0.8em">芯片名称</span>：<asp:Label ID="lbcpuname" runat="server" Text="Label" Font-Size="Small"></asp:Label><br />
        <table style="width: 150px">
            <tr>
                <td style="width: 4px">
                </td>
                <td style="width: 150px">
        <asp:Image ID="imcpu" runat="server" Height="69px" Width="98px" /></td>
                <td style="width: 23885px">
                </td>
            </tr>
            <tr>
                <td style="width: 4px">
                </td>
                <td style="width: 150px">
                    <span style="font-size: 9pt">离研发结束还剩:</span></td>
                <td style="width: 23885px">
                </td>
            </tr>
            <tr>
                <td style="width: 4px">
                </td>
                <td style="width: 150px">
                    <span style="font-size: 9pt">
                    <asp:Label ID="myclock" runat="server" Text="Label" Font-Size="Small" Width="147px"></asp:Label></span></td>
                <td style="width: 23885px">
                </td>
            </tr>
            <tr>
                <td style="width: 4px">
                </td>
                <td style="width: 150px">
                    <span style="font-size: 9pt">芯片简介：</span></td>
                <td style="width: 23885px">
                </td>
            </tr>
            <tr>
                <td style="width: 4px">
                </td>
                <td style="width: 150px">
        <asp:Label ID="lbcpudescription" runat="server" Height="191px" Text="Label" Width="146px" Font-Size="Small"></asp:Label></td>
                <td style="width: 23885px">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
