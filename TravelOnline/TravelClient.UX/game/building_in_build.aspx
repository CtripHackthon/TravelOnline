<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="building_in_build.aspx.cs" Inherits="TravelClient.UX.game.game_building_in_build" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>建造建筑中</title>
    <script type="text/javascript">
    var total='<%=Session["eof_dt"]%>';
//     window.parent.frames[0].location.reload();
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
            window.location.href="dealAccomplish.aspx?type=1";
            return;
         }
        setTimeout ("show()",1000);
    }
</script>
</head>
<body background="images/back.gif" onload="show();">
    <form id="form1" runat="server">
    <div style="list-style-position: outside; list-style-type: circle; text-align: left">
      <span>建造建筑<br />
      </span><span style="font-size: 12pt">-------------------</span></div>
            <p style="list-style-position: outside; list-style-type: circle; text-align: left">
        <asp:Label ID="lbbuildingtype" runat="server" Font-Bold="True" Height="20px" Text="Label"
            Width="129px" Font-Size="Small"></asp:Label>&nbsp;</p>
            <p>
                &nbsp;<asp:Label ID="lbdescription" runat="server" Height="81px" Text="Label" Width="126px" Font-Size="Small"></asp:Label></p>
            <p><span style="font-size: 0.8em; font-family: 宋体">
        等级: 1</span></p>
            <p><span style="font-size: 0.8em">距离建造完成还有:</span></p>
        <p>
            <asp:Label ID="myclock" runat="server" Text="Label" Font-Size="Small" Width="110px"></asp:Label>&nbsp;</p>
    </form>
  <div id="my" runat="server">
  </div>
</body>
</html>
