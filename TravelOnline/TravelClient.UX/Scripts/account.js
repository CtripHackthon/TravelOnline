﻿(function (account, $, undefined) {

    account.init =  function () {

        $('#registsubmit').live('click', function (e) {
            var username = $('#username').val().trim();
            var password = $('#password').val().trim();
            account.register.regUser(username, password);
        });

        $('#login').live('click', function (e) {
            var username = $('.uname').val().trim();
            var password = $('.upassword').val().trim();
            account.login.loginUser(username, password);
        });

    }

    account.register = new function () {

        this.getBaseUrl = function () {
            var url = "http://" + window.location.hostname + ':' + window.location.port;
            return url;

        }

        var baseurl = this.getBaseUrl();
        
        this.regUser = function (username, password) {
            var userjson = JSON.stringify({'UserName': username, 'Password': password});
            $.ajax({
                url: baseurl + '/Ajax/UserAjax.aspx',
                cache: false,
                type: 'Get',
                data: { queryType: 'register', user: userjson },
                dataType: 'json',
                timeout: 60000,
                beforeSend: function () {
                },
                complete: function () {
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert('status :' + XMLHttpRequest.status + '; readyState:' + XMLHttpRequest.readyState + '; textStatus:' + textStatus);
                },
                success: function (result) {
                    if (result != null) {
                        if (result.register == '1') {
                            window.location.href = "../Home.aspx";
                        }
                        else {
                            alert('login failed');
                        }
                    }
                }
            });
        };

    }
    account.login = new function () {
        this.getBaseUrl = function () {
            var url = "http://" + window.location.hostname + ':' + window.location.port;
            return url;

        }

        var baseurl = this.getBaseUrl();

        this.loginUser = function (username, password) {
            var userjson = JSON.stringify({ 'UserName': username, 'Password': password });
            $.ajax({
                url: baseurl + '/Ajax/UserAjax.aspx',
                cache: false,
                type: 'Get',
                data: { queryType: 'login', user: userjson },
                dataType: 'json',
                timeout: 60000,
                beforeSend: function () {
                },
                complete: function () {
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert('status :' + XMLHttpRequest.status + '; readyState:' + XMLHttpRequest.readyState + '; textStatus:' + textStatus);
                },
                success: function (result) {
                    // if login successfully navigate customer to the welcome page
                    if (result != null) {
                        if (result.login == '1') {
                            window.location.href = "../Account/PersonalBoard.aspx";
                        }
                        else {
                            alert('login failed');
                        }
                    }
                }
            });
        };
    }
    account.util = new function () {
        
    }

})(window.account = window.account || {}, $, undefined);