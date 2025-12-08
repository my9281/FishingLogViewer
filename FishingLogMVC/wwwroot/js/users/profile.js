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

    $('#profile-btn').click(function (event) {
        event.preventDefault();
        var formData = {
            Username: $('#pid').val(),
            Nickname: $('#pnick').val(),
            Location: $('#ploc').val(),
            Birthday: $('#pbirth').val()
        };
        $.ajax({
            type: 'POST',
            url: '/api/users/Profile',
            data: formData,
            success: function (response) {
                if (response.success) {
                    alert($('#profile-btn').data('success'));
                }
                else {
                    alert($('#profile-btn').data('fail'));
                }
            },
            error: function () {
                alert($('#profile-btn').data('fail'));
            }
        });
    });
});
