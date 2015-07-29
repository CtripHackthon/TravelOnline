<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="building_in_manufacture.aspx.cs" Inherits="TravelClient.UX.game.game_building_in_manufacture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>建筑升级中</title>
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
            window.location.href="dealAccomplish.aspx?type=4";
            return;
         }
        setTimeout ("show()",1000);
    }
</script>
</head>
<body onload="show()" background="images/back.gif" style="width:135px">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="工厂生产" Width="84px"></asp:Label><br />
        <span style="font-size: 12pt">---------------------</span><br />
        <asp:Image ID="imgcpu" runat="server" Height="116px" Width="138px" /><br />
        <span style="font-size: 0.8em; font-family: 宋体">
        芯片名称：&nbsp; </span>
        <asp:Label ID="lcpuname" runat="server" Text="Label" Font-Size="Small"></asp:Label><br />
        <span style="font-size: 0.8em; font-family: 宋体">
        生产数量：</span><asp:Label ID="lcpucount" runat="server" Text="Label" Font-Size="Small"></asp:Label><br />
        <span style="font-size: 0.8em; font-family: 宋体">
        生产完成剩余时间：<br />
        </span><asp:Label ID="myclock" runat="server" Text="Label" Font-Size="Small" Width="135px"></asp:Label></div>
    </form>
</body>
</html>
