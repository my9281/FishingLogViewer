
$(document).ready(function () {



    const $target = $('#hoverTarget');
    const $box = $('#hoverBox');








    var socket = new WebSocket("ws://localhost:5038/ws");

    socket.onopen = function (event) {
        console.log("WebSocket connected.");
        socket.send("Hello Server!");
    };

    socket.onmessage = function (event) {

        $("#login-qrcode").empty();
        var dataObj = JSON.parse(event.data); // 解析成 JS 对象 
        if (dataObj.Status == "Login") { 
            window.location.href = '/';
            console.log(dataObj);
        }
        else {
            var pp = window.location.origin + "/api/Users/Loginbyqr?id=" + dataObj.Id;
            console.log(pp);
            var qrcode = new QRCode(document.getElementById("login-qrcode"), {
                text: pp,
                width: 256,
                height: 256,
                colorDark: "#000000",
                colorLight: "#ffffff",
                correctLevel: QRCode.CorrectLevel.H
            });
        } 
    };

    socket.onclose = function (event) {
        console.log("WebSocket closed.");
    };

    socket.onerror = function (error) {
        console.error("WebSocket error:", error);
    };
     










    $target.on('mouseenter', function () {
        const offset = $target.offset();
        const height = $target.outerHeight();

        $box.css({
            left: offset.left + 'px',
            top: (offset.top + height) + 'px'
        }).show();
    });

    $target.on('mouseleave', function () {
        setTimeout(function () {
            if (!$box.is(':hover')) {
                $box.hide();
            }
        }, 100);
    });

    $box.on('mouseenter', function () {
        $box.show();
    });

    $box.on('mouseleave', function () {
        $box.hide();
    });
    function addParamAndReload(paramName, paramValue) {
        const urlObj = new URL(window.location.href);
        urlObj.searchParams.set(paramName, paramValue);
        window.location.href = urlObj.toString();
    }
    $('#lan-en').click(function (e) {
        addParamAndReload("lan","en");
    });
    $('#lan-Zh').click(function (e) {
        addParamAndReload("lan", "zh-CN");
    });
    $('#lan-TW').click(function (e) {
        addParamAndReload("lan", "zh-TW");
    });
    $('#login-btn').click(function (event) {
        event.preventDefault(); // 阻止默认表单提交
        var formData = {
            username: $('#uid').val(),
            password: $('#upa').val()
        };
        console.log(formData);
        $.ajax({
            type: 'POST',
            url: '/api/users/Login',
            data: formData,
            success: function (response) {
                if (response == "-1") {
                    alert("Wrong user or password.");
                }
                else {
                    window.location.href = '/';
                }
            },
            error: function (xhr) { 
                alert("service error.");
            }
        });
    });
});