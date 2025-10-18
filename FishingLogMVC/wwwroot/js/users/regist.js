
$(document).ready(function () {

    const $target = $('#hoverTarget');
    const $box = $('#hoverBox');
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
        addParamAndReload("lan", "en");
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
    $('#regist-btn').click(function (event) {
        if ($('#rpa').val() != $('#rrepa').val()) {
            alert("Your password is not matched");
            return;
        }
        event.preventDefault(); // 阻止默认表单提交
        var formData = {
            username: $('#rid').val(),
            password: $('#rpa').val()
        };
        console.log(formData);
        $.ajax({
            type: 'POST',
            url: '/api/users/RegistData',
            data: formData,
            success: function (response) {
                if (response == "-1") {
                    alert("Fail!It has same Account in Database!");
                }
                else {
                    alert("success!");
                    window.location.href = '/users/login';
                }
            },
            error: function (xhr) {
                alert("service error.");
            }
        });
    });
});