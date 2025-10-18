(function () {
    $("#toggleDiv").prop("checked", false);
    $(".hiddiv").attr("hidden", true); // 加上 hidden → 隐藏
    $("#toggleDiv").change(function () {
        if ($(this).is(":checked")) {
            $(".hiddiv").removeAttr("hidden");
        } else {
            $(".hiddiv").attr("hidden", true); // 加上 hidden → 隐藏
        }
    });
    var gotp = function (e) {
        let cc = 0;
        switch (e) {
            case "11": { cc = 20500; break; }
            case "10": { cc = 19900; break; }
            case "9": { cc = 19100; break; }
            case "8": { cc = 17850; break; }
            case "7": { cc = 16350; break; }
            case "6": { cc = 14600; break; }
            case "5": { cc = 12600; break; }
            case "4": { cc = 9900; break; }
            case "3": { cc = 6900; break; }
            case "2": { cc = 3600; break; }
            case "1": { cc = 0; break; }
            case "0": { cc = 0; break; }
        }
        return cc;
    }
    var gotbasefo = function (e) {
        let cc = 0;
        switch (e) {
            case "11": { cc = 0; break; }
            case "10": { cc = 400; break; }
            case "9": { cc = 1000; break; }
            case "8": { cc = 1800; break; }
            case "7": { cc = 3050; break; }
            case "6": { cc = 4550; break; }
            case "5": { cc = 6300; break; }
            case "4": { cc = 8300; break; }
            case "3": { cc = 11000; break; }
            case "2": { cc = 14000; break; }
            case "1": { cc = 17300; break; }
            case "0": { cc = 20900; break; }
        }
        return cc;
    }
    $('#btn').click(function () {
        let tl = $('#s1').val();
        var c = 0;
        if (tl == "初境" || tl == "基境" || tl == "心境") c = 4;
        if (tl == "白虹" || tl == "星移" || tl == "登峰" || tl == "造极") c = 5;
        if (tl == "入化" || tl == "炎黄" || tl == "玄武" || tl == "地庭") c = 6;

        var p = $('#s1').find('option:selected').attr('id');
        var cc1 = gotbasefo(p);
        let lev = $('#lev').val() - 1;
        let ppp = Number($('#src').val());
        var kpst = (11 - p) * 50 + 100;
        var lls = kpst * (lev) + cc1 * 1 + ppp * 1;
        var targetfo = Number(gotbasefo("0")) * 1;
        if ($("#toggleDiv").prop("checked")) {
            var biglv = $('#s2').find('option:selected').attr('id');
            var slev = Number($('#lev2').val()) * 1 - 1;
            var kpst2 = (11 - Number(biglv)) * 50 + 100;
            targetfo = Number(gotbasefo(biglv)) + (kpst2 * slev);
        }
        var time1 = Date.parse(new Date());
        var time2 = Date.parse(new Date($('#endtime').html()));
        var nDays = Math.abs(Math.ceil((time2 - time1) / 1000 / 3600 / 24));

        if ($("#toggleDiv").prop("checked")) {
            console.log("高级模式");
        }
        else {
            console.log("登顶模式");
        }
        if (targetfo <= lls) {
            $('#text').html("你已经达到目标了！恭喜！");
            return;
        }
        var temp = Math.ceil((targetfo - lls) / 300);
        console.log("正常天：" + temp);
        var retext = "差" + (targetfo - lls) + "分达到目标,<br />算上今天还有" + nDays + "天<br />" + "不加场次，你需要" + temp + "天达成目标";
        if (temp > nDays) {
            var pce = (targetfo - lls) - nDays * 300;
            var nDayspce = Math.abs(Math.ceil(pce / 60));
            retext += "，但时间不够了，<br />你需要补充" + nDayspce + "场";
            if (nDayspce > nDays * 5) {
                retext += "，<br />但时间仍然不够";
            }
        }
        $('#text').html(retext);
    });
})();