<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="game_country_body.aspx.cs"
    Inherits="TravelClient.UX.game.game_game_country_body" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript"> 
    <!--
    function SetSquarePosition(){
        Wave(1);
    }
    //用户的浏览器是IE返回true，否则返回false   
    function CheckUserBrowser(){
        var re=true;
        var browser=navigator.appName;
        if(browser=='Microsoft Internet Explorer'){
            re=true;
        }
        else{
            re=false;
        }
        return re;
    }
    function Wave(field){
        if(CheckUserBrowser()){
            switch(field){
                case 1:
                    document.getElementById("square").className="l1";
                    break;
                case 2:
                    document.getElementById("square").className="l2";
                    break;
                case 3:
                    document.getElementById("square").className="l3";
                    break;
                case 4:
                    document.getElementById("square").className="l4";
                    break;
                case 5:
                    document.getElementById("square").className="l5";
                    break;
                case 6:
                    document.getElementById("square").className="l6";
                    break;
                case 7:
                    document.getElementById("square").className="l7";
                    break;
                case 8:
                    document.getElementById("square").className="l8";
                    break;
                case 9:
                    document.getElementById("square").className="l9";
                    break;
                case 10:
                    document.getElementById("square").className="l10";
                    break;
                case 11:
                    document.getElementById("square").className="l11";
                    break;
                case 12:
                    document.getElementById("square").className="l12";
                    break;
                case 13:
                    document.getElementById("square").className="l13";
                    break;
                case 14:
                    document.getElementById("square").className="l14";
                    break;
                case 15:
                    document.getElementById("square").className="l15";
                    break;                
                case 16:
                    document.getElementById("square").className="l16";
                    break;
                case 17:
                    document.getElementById("square").className="l17";
                    break;
                case 18:
                    document.getElementById("square").className="l18";
                    break;
                case 19:
                    document.getElementById("square").className="l19";
                    break;
                case 20:
                    document.getElementById("square").className="l20";
                    break;
                }
            }
            else{
                switch(field){
                    case 1:
                        document.getElementById("square").className="fl1";
                        break;
                    case 2:
                        document.getElementById("square").className="fl2";
                        break;
                    case 3:
                        document.getElementById("square").className="fl3";
                        break;
                    case 4:
                        document.getElementById("square").className="fl4";
                        break;
                    case 5:
                        document.getElementById("square").className="fl5";
                        break;
                    case 6:
                        document.getElementById("square").className="fl6";
                        break;
                    case 7:
                        document.getElementById("square").className="fl7";
                        break;
                    case 8:
                        document.getElementById("square").className="fl8";
                        break;
                    case 9:
                        document.getElementById("square").className="fl9";
                        break;
                    case 10:
                        document.getElementById("square").className="fl10";
                        break;
                    case 11:
                        document.getElementById("square").className="fl11";
                        break;
                    case 12:
                        document.getElementById("square").className="fl12";
                        break;
                    case 13:
                        document.getElementById("square").className="fl13";
                        break;
                    case 14:
                        document.getElementById("square").className="fl14";
                        break;
                    case 15:
                        document.getElementById("square").className="fl15";
                        break;                
                    case 16:
                        document.getElementById("square").className="fl16";
                        break;
                    case 17:
                        document.getElementById("square").className="fl17";
                        break;
                    case 18:
                        document.getElementById("square").className="fl18";
                        break;
                    case 19:
                        document.getElementById("square").className="fl19";
                        break;
                    case 20:
                        document.getElementById("square").className="fl20";
                        break;
                }
            }
        }
    //-->    
    </script>

    <style type="text/css">
<!--
body {
	margin: 0px;
}
ul{
	margin: 0px;
	padding: 0px;
	list-style-type: none;
}
.hours{ width:100%;}
.hours li{
	float:left;
}

.H1{position: relative;top: 140px;left: 70px; z-index:6}
.H2{position: relative;top: 174px;left: -65px; z-index:7}
.H3{position: relative;top: 71px;left: 192px; z-index:8}
.H4{position: relative;top: 106px;left: 62px; z-index:9}
.H5{position: relative;top: 140px;left: -68px; z-index:10}
.H6{position: relative;top: 174px;left: -198px; z-index:11}
.H7{position: relative;top: 208px;left: -326px; z-index:12}
.H8{position: relative;top: 139px;left: -138px; z-index:13}
.H9{position: relative;top: 174px;left: -266px; z-index:14}
.H10{position: relative;top: 140px;left: 198px; z-index:15}
.H11{position: relative;top: 172px;left: 69px; z-index:16}
.H12{position: relative;top: 72px;left: 322px; z-index:17}
.H13{position: relative;top: 106px;left: 192px; z-index:18}
.H14{position: relative;top: 140px;left: 62px; z-index:19}
.H15{position: relative;top: 171px;left: -70px; z-index:20}
.H16{position: relative;top: 204px;left: -196px; z-index:21}
.H17{position: relative;top: 140px;left: -8px; z-index:22}
.H18{position: relative;top: 172px;left: -140px; z-index:23}
.H19{position: relative;top: 136px;left: 324px; z-index:24}
.H20{position: relative;top: 170px;left: 194px; z-index:25}

.l1{
    position:absolute;
    top:146px;
    left: 70px;
    width:66px;
    height:55px;
    }
.l2{
    position:absolute;
    top:181px;
    left: 5px;
    width:66px;
    height:55px;
    }
.l3{
    position:absolute;
    top:79px;
    left: 328px;
    width:66px;
    height:55px;
    }
.l4{
    position:absolute;
    top:112px;
    left: 263px;
    width:66px;
    height:55px;
    }
.l5{
    position:absolute;
    top:146px;
    left: 199px;
    width:66px;
    height:55px;
    }   
.l6{
    position:absolute;
    top:180px;
    left: 134px;
    width:66px;
    height:55px;
    }
.l7{
    position:absolute;
    top:215px;
    left: 69px;
    width:66px;
    height:55px;
    }
.l8{
    position:absolute;
    top:146px;
    left: 327px;
    width:66px;
    height:55px;
    }
.l9{
    position:absolute;
    top:181px;
    left: 262px;
    width:66px;
    height:55px;
    }   
.l10{
    position:absolute;
    top:215px;
    left: 199px;
    width:66px;
    height:55px;
    }
.l11{
    position:absolute;
    top:246px;
    left: 134px;
    width:66px;
    height:55px;
    } 
.l12{
    position:absolute;
    top:146px;
    left: 455px;
    width:66px;
    height:55px;
    }   
.l13{
    position:absolute;
    top:182px;
    left: 391px;
    width:66px;
    height:55px;
    }
.l14{
    position:absolute;
    top:215px;
    left: 322px;
    width:66px;
    height:55px;
    }
.l15{
    position:absolute;
    top:246px;
    left: 262px;
    width:66px;
    height:55px;
    }
.l16{
    position:absolute;
    top:279px;
    left: 198px;
    width:66px;
    height:55px;
    }   
.l17{
    position:absolute;
    top:215px;
    left: 455px;
    width:66px;
    height:55px;
    }
.l18{
    position:absolute;
    top:246px;
    left: 391px;
    width:66px;
    height:55px;
    }    
.l19{
    position:absolute;
    top:279px;
    left: 324px;
    width:66px;
    height:55px;
    }
.l20{
    position:absolute;
    top:313px;
    left: 260px;
    width:66px;
    height:55px;
    }    
    
.fl1{
    position:absolute;
    top:143px;
    left: 76px;
    width:66px;
    height:55px;
    }
.fl2{
    position:absolute;
    top:178px;
    left: 10px;
    width:66px;
    height:55px;
    }
.fl3{
    position:absolute;
    top:76px;
    left: 332px;
    width:66px;
    height:55px;
    }
.fl4{
    position:absolute;
    top:109px;
    left: 267px;
    width:66px;
    height:55px;
    }
.fl5{
    position:absolute;
    top:143px;
    left: 203px;
    width:66px;
    height:55px;
    }   
.fl6{
    position:absolute;
    top:177px;
    left: 138px;
    width:66px;
    height:55px;
    }
.fl7{
    position:absolute;
    top:212px;
    left: 79px;
    width:66px;
    height:55px;
    }
.fl8{
    position:absolute;
    top:143px;
    left: 331px;
    width:66px;
    height:55px;
    }
.fl9{
    position:absolute;
    top:178px;
    left: 266px;
    width:66px;
    height:55px;
    }   
.fl10{
    position:absolute;
    top:212px;
    left: 203px;
    width:66px;
    height:55px;
    }
.fl11{
    position:absolute;
    top:246px;
    left: 141px;
    width:69px;
    height:55px;
    } 
.fl12{
    position:absolute;
    top:143px;
    left: 459px;
    width:66px;
    height:55px;
    }   
.fl13{
    position:absolute;
    top:179px;
    left: 395px;
    width:66px;
    height:55px;
    }
.fl14{
    position:absolute;
    top:212px;
    left: 330px;
    width:66px;
    height:55px;
    }
.fl15{
    position:absolute;
    top:243px;
    left: 266px;
    width:66px;
    height:55px;
    }
.fl16{
    position:absolute;
    top:276px;
    left: 202px;
    width:66px;
    height:55px;
    }   
.fl17{
    position:absolute;
    top:212px;
    left: 459px;
    width:66px;
    height:55px;
    }
.fl18{
    position:absolute;
    top:243px;
    left: 395px;
    width:66px;
    height:55px;
    }    
.fl19{
    position:absolute;
    top:276px;
    left: 328px;
    width:66px;
    height:55px;
    }
.fl20{
    position:absolute;
    top:310px;
    left: 264px;
    width:66px;
    height:55px;
    }                                             
-->
</style>
</head>
<body onload="SetSquarePosition()">
    <form id="form1" runat="server">
        <div>
            <table width="600" height="427" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" background="images/gameback.jpg">
                        <div class="hours">
                            <div>
                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                    class="l1" id="square" name="square">
                                    <param name="movie" value="images/build/wave.swf" id="choose1" />
                                    <param name="quality" value="high" />
                                    <param name="wmode" value="transparent" />
                                    <param name="wmode" value="Opaque" />
                                    <embed src="images/build/wave.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="48" height="70" wmode="transparent"></embed>
                                </object>
                            </div>
                            <ul>
                                <li class="H1">
                                    <div id="a">
                                    </div>
                                </li>
                                <li class="H2">
                                    <div id="b">
                                    </div>
                                </li>
                                <li class="H3">
                                    <div id="c">
                                    </div>
                                </li>
                                <li class="H4">
                                    <div id="d">
                                    </div>
                                </li>
                                <li class="H5">
                                    <div id="e">
                                    </div>
                                </li>
                                <li class="H6">
                                    <div id="f">
                                    </div>
                                </li>
                                <li class="H7">
                                    <div id="g">
                                    </div>
                                </li>
                                <li class="H8">
                                    <div id="h">
                                    </div>
                                </li>
                                <li class="H9">
                                    <div id="i">
                                    </div>
                                </li>
                                <li class="H10">
                                    <div id="j">
                                    </div>
                                </li>
                                <li class="H11">
                                    <div id="k">
                                    </div>
                                </li>
                                <li class="H12">
                                    <div id="l">
                                    </div>
                                </li>
                                <li class="H13">
                                    <div id="m">
                                    </div>
                                </li>
                                <li class="H14">
                                    <div id="n">
                                    </div>
                                </li>
                                <li class="H15">
                                    <div id="o">
                                    </div>
                                </li>
                                <li class="H16">
                                    <div id="p">
                                    </div>
                                </li>
                                <li class="H17">
                                    <div id="q">
                                    </div>
                                </li>
                                <li class="H18">
                                    <div id="r">
                                    </div>
                                </li>
                                <li class="H19">
                                    <div id="s">
                                    </div>
                                </li>
                                <li class="H20">
                                    <div id="t">
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <%PartInfoPickUp(); %>
        <%ConstructingOrUpdating(); %>
    </form>
</body>
</html>
