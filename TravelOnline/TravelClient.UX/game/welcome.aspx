<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="welcome.aspx.cs" Inherits="TravelClient.UX.game.game_welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body background="images/back.gif">
    <form id="form1" runat="server">
    <div style="text-align: left">
        <br />
        <div style="width: 139px; height: 300px;text-align:center">
            <asp:Image ID="imwelcome" runat="server" ImageUrl="~/game/images/star.jpg" /><br />
            <br />
            <br />
            <span style="font-size: 9pt; font-family: 宋体">请单击地图中的<br />
                <br />
                一块空地,开始<br />
                <br />
                <span style="font-family: Times New Roman">建造新建筑 &nbsp; &nbsp; &nbsp;&nbsp; </span>
            </span>
        </div>
    
    </div>
    </form>
</body>
</html>
