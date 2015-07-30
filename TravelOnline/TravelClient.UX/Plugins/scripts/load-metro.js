/// <reference path="" />
$(function(){
    if ((document.location.host.indexOf('.dev') > -1) || (document.location.host.indexOf('modernui') > -1) ) {
        $("<script/>").attr('src', '../Plugins/scripts/metro/metro-loader.js').appendTo($('body'));
    } else {
        $("<script/>").attr('src', '../Plugins/scripts/metro.min.js').appendTo($('body'));
    }
})