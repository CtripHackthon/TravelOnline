<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="game_map.aspx.cs" Inherits="TravelClient.UX.game.game_game_map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Pragma" content="no-cache" />
    <title>真龙大陆</title>
    <style type="text/css">
    <!--
    body,td,th {
	    font-size: 12px;
	    color: #000;
    }
    body {
	    margin: 0px;
	    background: #000 url(images/top_bg.gif) no-repeat center top;
    }
    ul{
	    margin: 0px;
	    padding: 0px;
	    list-style-type: none;
    }
    .gameWeb{margin-right:7px; margin-top:15px;}
    .gWright{
	    width:172px;
	    height:404px;
	    margin-top: 26px;
	    margin-left: 6px;
	    overflow-x:hidden;
	    overflow-y: scroll;
    }
    .gWright3{
	    width:172px;
	    height:404px;
	    margin-top: 26px;
	    margin-left: 6px;
    }
    .gWright2{
	    margin-top: 100px;
	    width: 100px;
	    margin-left: 40px;
    }
    .gW1{
	    font-weight:bold;
	    font-size:11pt;
	    line-height: 30px;
	    height: 30px;
	    text-align: center;
	    width: 100%;
    }
    .gW2{
	    font-weight: bold;
	    line-height: 20px;
	    height: 20px;
	    width: 100%;
	    border-bottom: 1px dashed #000;
    }
    .gW3{
	    margin-top: 6px;
	    text-align: left;
	    text-indent: 24px;
	    line-height: 20px;
    }
    .gW4{
	    line-height: 20px;
	    height: 20px;
	    text-align: left;
    }
    .gW5{
	    text-align: center;
	    margin-bottom: 20px;
    }
    .gW6{}
    .gameLink a{
	    font-weight: bold;
	    color: #000;
	    text-decoration: none;
    }
    .gameLink a:hover {
	    font-weight: bold;
	    color: #000;
	    text-decoration: underline;
    }
    .pocket{ width:590px; margin-top:50px; margin-left:40px;}
    .pocket li{
	    float:left;
	    height: 137px;
	    width: 65px;
	    background-image: url(images/stone_back.gif);
	    background-repeat: no-repeat;
	    margin-right: 4px;
	    margin-left: 4px;
	    margin-top: 20px;
    }
    .position{width:560px;position:absolute}
    .position li{
	    float: left;
    }
    .p1{position: relative;left: 244px;top: 18px;}

    .p2{position: relative;left: 172px;top: 37px;}
    .p3{position: relative;left: 190px;top: 37px;}

    .p4{position: relative;top: 55px;left: 55px;}
    .p5{position: relative;top: 60px;left: 68px;}
    .p6{position: relative;top: 55px;left: 95px;}

    .p7{position: relative;top: 70px;left: -119px;}
    .p8{position: relative;top: 80px;left: -100px;}
    .p9{position: relative;top: 79px;left: -70px;}
    .p10{position: relative;top: 79px;left: -50px;}

    .p11{position: relative;top: 95px;left: -325px;}
    .p12{position: relative;top: 95px;left: -315px;}
    .p13{position: relative;top: 58px;left: 255px;}
    .p14{position: relative;top: 60px;left: 275px;}
    .p15{position: relative;top: 60px;left: 295px;}

    .p16{position: relative;top: 75px;left: -55px;}
    .p17{position: relative;top: 75px;left: -30px;}
    .p18{position: relative;top: 75px;left:  -10px;}
    .p19{position: relative;top: 70px;left: 20px;}
    .p20{position: relative;top: 70px;left: 40px;}
    .p21{position: relative;top: 70px;left: 60px;}

    .p22{position: relative;top: 95px;left: -350px;}
    .p23{position: relative;top: 95px;left: -328px;}
    .p24{position: relative;top: 95px;left: -310px;}
    .p25{position: relative;top: 55px;left: 255px;}
    .p26{position: relative;top: 60px;left: 280px;}
    .p27{position: relative;top: 60px;left: 300px;}
    .p28{position: relative;top: 60px;left: 320px;}

    .p29{position: relative;top: 80px;left: -97px;}
    .p30{position: relative;top: 75px;left: -80px;}
    .p31{position: relative;top: 80px;left: -50px;}
    .p32{position: relative;top: 75px;left: -30px;}
    .p33{position: relative;top: 75px;left: 0px;}
    .p34{position: relative;top: 75px;left:20px;}

    .p35{position: relative;top: 90px;left: -330px;}
    .p36{position: relative;top: 90px;left: -305px;}
    .p37{position: relative;top: 60px;left: 250px;}
    .p38{position: relative;top: 55px;left: 275px;}
    .p39{position: relative;top: 60px;left: 300px;}

    .p40{position: relative;top: 75px;left: 20px;}
    .p41{position: relative;top: 75px;left: 40px;}
    .p42{position: relative;top: 75px;left: 60px;}
    .p43{position: relative;top: 75px;left: 80px;}

    .p44{position: relative;top: 90px;left: -120px;}
    .p45{position: relative;top: 90px;left: -100px;}
    .p46{position: relative;top: 90px;left: -75px;}

    .p47{position: relative;top: 110px;left: -225px;}
    .p48{position: relative;top: 110px;left: -200px;}

    .p49{position: relative;top: 100px;left: 255px;}
    .roll{
	    width: 200px;
	    line-height: 60px;
	    height: 60px;
	    margin-top: -430px;
	    margin-left: 640px;
    }
    .gameInfo {
	    width:734px;
	    height:128px;
	    overflow-x:hidden;
	    overflow-y: scroll;
	    margin-top: -4px;
	    margin-left: 62px;
    }
    .gameInfo li{}

    .isquare0{
        position:absolute;
        margin-top:115px;
        margin-left: 247px;
        width:66px;
        height:55px;
    }
    .isquare1{
        position:absolute;
        margin-top:65px;
        margin-left:180px;
        width:205px;
        height:170px;
    }
    .isquare2{
        position:absolute;
        margin-top:10px;
        margin-left: 115px;
        width:330px;
        height:275px;
    }
    .isquare3{
        position:absolute;
        margin-top:-40px;
        margin-left:30px;
        width:485px;
        height:385px;
    }
    .fsquare0{
        position:absolute;
        margin-top:115px;
        margin-left: 247px;
        width:66px;
        height:55px;
    }
    .fsquare1{
        position:absolute;
        margin-top:75px;
        margin-left:180px;
        width:205px;
        height:170px;
    }
    .fsquare2{
       position:absolute;
        margin-top:20px;
        margin-left: 115px;
        width:330px;
        height:275px;
    }
    .fsquare3{
       position:absolute;
        margin-top:-53px;
        margin-left:35px;
        width:485px;
        height:405px;
    }
    -->
    </style>

    <script type="text/javascript">
    document.write(navigator.appName);
    var list=[0,1,2,3,4,5,6];
    list[0]=[1,2,3,4,5,6,7];
    list[1]=[8,9,10,11,12,13,14];
    list[2]=[15,16,17,18,19,20,21];
    list[3]=[22,23,24,25,26,27,28];
    list[4]=[29,30,31,32,33,34,35];
    list[5]=[36,37,38,39,40,41,42];
    list[6]=[43,44,45,46,47,48,49];
     var mystroll=null;

      function LoginStateCheck(){
          if('<%=Session["user_id"]!=null %>'=='True')
          {
            document.getElementById("log_in_state").innerHTML='<%=Session["user_id"] %>'+' 欢迎你 '+'<a href="../logout.aspx" class="a">退出登录</a> &nbsp;&nbsp;';
          }
      }        
    
    function success(temp)
    {
        var reg=new RegExp("&random=[123]","g");
        var alink=null;
        for(var z=1;z<=49;z++)
        {
            alink=document.getElementById("a"+z);
            alink.href=alink.href.replace(reg,"");
            alink.onclick=click1;
        }
        for(var i=-temp;i<=temp;i++)
        {
            for(var j=-temp;j<=temp;j++)
             {
                  alink=document.getElementById("a"+list[3+i][3+j]);
                  alink.onclick=click2;
                  alink.href=alink.href+"&random="+temp;
             }
        }
    }
    function click2()
    {
         return
    }
    function click1()
    {
         alert("此处在行程之外");
         return false;
    }
    
    function createRandom()
    {
         window.clearTimeout(mystroll);
         var roll=document.getElementById("roll");
         roll.src="images/walk_dice00.gif";
         mystroll=setTimeout(stop,3000);
    }
    function stop()
    {
         var random=Math.floor((Math.random()*10)%3+1);
         var roll=document.getElementById("roll");
         roll.src="images/walk_dice0"+random+".gif";
         var square=document.getElementById("square");
        
         var choose1=document.getElementById("choose1");
          alert("掷出点数"+random);

          if(navigator.appName=="Microsoft Internet Explorer")
          {
          
             switch(random)
             {
                case 1:
                    document.getElementById("mysquare").innerHTML='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="isquare1" id="square" ><param name="movie" value="images/map/33.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/33.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="66" height="52" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                    break;
                case 2:
                     document.getElementById("mysquare").innerHTML='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="isquare2" id="square" ><param name="movie" value="images/map/55.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/55.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="66" height="52" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                    break;
                case 3:
                    document.getElementById("mysquare").innerHTML='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="isquare3" id="square" ><param name="movie" value="images/map/77.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/77.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="66" height="52" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                    break;
             }
         }
         else
         {         
            switch(random)
             {
                case 1:
                    document.getElementById("mysquare").innerHTML='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="fsquare1" id="square" ><param name="movie" value="images/map/33.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/33.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"  width="198" height="156" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                    break;
                case 2:
                     document.getElementById("mysquare").innerHTML='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="fsquare2" id="square" ><param name="movie" value="images/map/55.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/55.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="330" height="258" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                    break;
                case 3:
                    document.getElementById("mysquare").innerHTML='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="fsquare3" id="square" ><param name="movie" value="images/map/77.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/77.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="480" height="420" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                    break;
             }
         }
         success(random);
    }
    
    
    var scrollMoving;
    function startScrollFun(n)
    {
    scrollMoving=window.setInterval("contentContainerDiv.scrollTop+="+n,10);
    }
   function stopScrollFun()
    {
    window.clearInterval(scrollMoving);
    var scroll=document.getElementById("contentContainerDiv");
    scroll.scrollTop=0;
    }
    </script>

</head>
<body>
    <table width="858" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 41px;">
        <tr>
            <td align="center">
                <img src="images/top_bg2.gif" width="216" height="18" /></td>
        </tr>
    </table>
    <table width="858" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img src="images/top_bg3.gif" width="858" height="28" /></td>
        </tr>
        <tr>
            <td height="30" valign="top" background="images/top_bg4.gif">
              
            </td>
        </tr>
        <tr>
            <td background="images/top_bg5.gif" style="height: 69px">
                <table width="100%" height="82" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="25%">
                            &nbsp;</td>
                        <td width="18%" align="center" style="color: #FFFFFF; font-weight: bold;">
                            <%=Session["user_id"] %>
                            的土地</td>
                        <td width="34%">
                            <table width="270" border="0" align="left" cellpadding="0" cellspacing="0">
                                <tr align="center" style="color: #FFFFFF;">
                                    <td width="90" height="30">
                                        <img src="images/wood.jpg" width="31" height="24" /></td>
                                    <td width="90">
                                        <img src="images/stone.jpg" width="23" height="24" /></td>
                                    <td>
                                        <img src="images/gold.jpg" width="22" height="22" /></td>
                                </tr>
                                <tr align="center">
                                    <td style="color: #FFFFFF;">
                                        木头&nbsp;
                                        <asp:Label ID="lbCurrentWoodCount" runat="server" Text="0"></asp:Label>/<asp:Label
                                            ID="lbTotalWoodCount" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td style="color: #FFFFFF;">
                                        石料
                                        <asp:Label ID="lbCurrentStoneCount" runat="server" Text="0"></asp:Label>/<asp:Label
                                            ID="lbTotalStoneCount" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td style="color: #FFFFFF;">
                                        龙币
                                        <asp:Label ID="lbCurrentMoneyCount" runat="server" Text="0"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td width="23%">
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr align="center">
                                    <td style="height: 70px">
                                        &nbsp;</td>
                                    <td style="height: 70px">
                                        <div>
                                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                                width="48" height="70">
                                                <param name="movie" value="images/01-2.swf" />
                                                <param name="quality" value="high" />
                                                <param name="wmode" value="transparent" />
                                                <embed src="images/01-2.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                    type="application/x-shockwave-flash" width="48" height="70" wmode="transparent"></embed>
                                            </object>
                                        </div>
                                    </td>
                                    <td style="width: 49px; height: 70px">
                                        <div>
                                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                                width="48" height="70">
                                                <param name="movie" value="images/01-1-map.swf" />
                                                <param name="quality" value="high" />
                                                <param name="wmode" value="transparent">
                                                <embed src="images/01-1-map.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                    type="application/x-shockwave-flash" width="48" height="70" wmode="transparent"></embed>
                                            </object>
                                        </div>
                                    </td>
                                    <td style="height: 70px">
                                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                            width="48" height="70">
                                            <param name="movie" value="images/01-3.swf" />
                                            <param name="quality" value="high" />
                                            <param name="wmode" value="transparent">
                                            <embed src="images/01-3.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                type="application/x-shockwave-flash" width="48" height="70" wmode="transparent"></embed>
                                        </object>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="455" valign="top" background="images/mid_back3.jpg">
                <table width="560" height="326" border="0" cellpadding="0" cellspacing="0" style="margin-left: 138px;">
                    <tr>
                        <td valign="top">
                            <div>
                                <div id="mysquare">
                                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                        class="isquare0" id="square">
                                        <param name="movie" value="images/map/22.swf" id="choose1" />
                                        <param name="quality" value="high" />
                                        <param name="wmode" value="transparent" />
                                        <embed src="images/map/22.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                            type="application/x-shockwave-flash" width="66" height="52" id="choose2" wmode="transparent"></embed>
                                        <param name="wmode" value="Opaque" />
                                    </object>
                                </div>
                                <div class="position" runat="server" id="map_pic">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="gameInfo" id="contentContainerDiv" onmouseover="startScrollFun(1)" onmouseout="stopScrollFun();">
                    <asp:Literal ID="ltactivity" runat="server"></asp:Literal>
                </div>
                <div class="roll">
                    请掷骰子->
                    <img src="images/walk_dice01.gif" border="0" id="roll" onclick="createRandom();" /></div>
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/btm_bg.gif" width="858" height="39" border="0" usemap="#Map" /></td>
        </tr>
    </table>
    <map name="Map" id="Map">
        <area shape="rect" coords="724,10,791,27" href="game_introduction.aspx" target="_blank"/>
    </map>
</body>
</html>

<script type="text/javascript">
var center=document.getElementById("a25");
    center.onclick=click2;
</script>

