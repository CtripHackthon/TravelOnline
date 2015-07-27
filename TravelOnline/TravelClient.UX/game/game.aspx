<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="game.aspx.cs" Inherits="TravelClient.UX.game.game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <title>喵星人大陆</title>
    
    <link href="../Content/game.css" rel="stylesheet" />
    <script type="text/javascript">
        document.write(navigator.appName);
        var list = [0, 1, 2, 3, 4, 5, 6];
        list[0] = [1, 2, 3, 4, 5, 6, 7];
        list[1] = [8, 9, 10, 11, 12, 13, 14];
        list[2] = [15, 16, 17, 18, 19, 20, 21];
        list[3] = [22, 23, 24, 25, 26, 27, 28];
        list[4] = [29, 30, 31, 32, 33, 34, 35];
        list[5] = [36, 37, 38, 39, 40, 41, 42];
        list[6] = [43, 44, 45, 46, 47, 48, 49];
        var mystroll = null;

        function LoginStateCheck() {
            if ('<%=Session["user_id"]!=null %>' == 'True') {
              document.getElementById("log_in_state").innerHTML = '<%=Session["user_id"] %>' + ' 欢迎你 ' + '<a href="../logout.aspx" class="a">退出登录</a> &nbsp;&nbsp;';
          }
      }

      function success(temp) {
          var reg = new RegExp("&random=[123]", "g");
          var alink = null;
          for (var z = 1; z <= 49; z++) {
              alink = document.getElementById("a" + z);
              alink.href = alink.href.replace(reg, "");
              alink.onclick = click1;
          }
          for (var i = -temp; i <= temp; i++) {
              for (var j = -temp; j <= temp; j++) {
                  alink = document.getElementById("a" + list[3 + i][3 + j]);
                  alink.onclick = click2;
                  alink.href = alink.href + "&random=" + temp;
              }
          }
      }
      function click2() {
          return
      }
      function click1() {
          alert("此处在行程之外");
          return false;
      }

      function createRandom() {
          window.clearTimeout(mystroll);
          var roll = document.getElementById("roll");
          roll.src = "images/walk_dice00.gif";
          mystroll = setTimeout(stop, 3000);
      }
      function stop() {
          var random = Math.floor((Math.random() * 10) % 3 + 1);
          var roll = document.getElementById("roll");
          roll.src = "images/walk_dice0" + random + ".gif";
          var square = document.getElementById("square");

          var choose1 = document.getElementById("choose1");
          alert("掷出点数" + random);

          if (navigator.appName == "Microsoft Internet Explorer") {

              switch (random) {
                  case 1:
                      document.getElementById("mysquare").innerHTML = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="isquare1" id="square" ><param name="movie" value="images/map/33.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/33.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="66" height="52" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                      break;
                  case 2:
                      document.getElementById("mysquare").innerHTML = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="isquare2" id="square" ><param name="movie" value="images/map/55.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/55.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="66" height="52" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                      break;
                  case 3:
                      document.getElementById("mysquare").innerHTML = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="isquare3" id="square" ><param name="movie" value="images/map/77.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/77.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="66" height="52" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                      break;
              }
          }
          else {
              switch (random) {
                  case 1:
                      document.getElementById("mysquare").innerHTML = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="fsquare1" id="square" ><param name="movie" value="images/map/33.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/33.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"  width="198" height="156" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                      break;
                  case 2:
                      document.getElementById("mysquare").innerHTML = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="fsquare2" id="square" ><param name="movie" value="images/map/55.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/55.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="330" height="258" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                      break;
                  case 3:
                      document.getElementById("mysquare").innerHTML = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" class="fsquare3" id="square" ><param name="movie" value="images/map/77.swf" id="choose1"/><param name="quality" value="high" /><param name="wmode" value="transparent" /><embed src="images/map/77.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="480" height="420" id="choose2" wmode="transparent"></embed><param name="wmode" value="Opaque" /></object> ';
                      break;
              }
          }
          success(random);
      }


      var scrollMoving;
      function startScrollFun(n) {
          scrollMoving = window.setInterval("contentContainerDiv.scrollTop+=" + n, 10);
      }
      function stopScrollFun() {
          window.clearInterval(scrollMoving);
          var scroll = document.getElementById("contentContainerDiv");
          scroll.scrollTop = 0;
      }
    </script>

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
                                        <param name="wmode" value="Opaque" /></object>
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

<script type="text/javascript">
    var center = document.getElementById("a25");
    center.onclick = click2;
</script>
</asp:Content>
