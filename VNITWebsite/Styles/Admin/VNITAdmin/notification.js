function showLoadingbar() {
    $("#ajax-loadingbar").animate({ right: 0 }, 200);
}
function hideLoadingbar(fn) {
    $("#ajax-loadingbar").animate({ right: "-165px" }, 200, function () {
        if (typeof fn === "function") fn();
    });
}
function showNotice(message, classname, fn) {
    if (message != null && message.length > 0) {
        $("#notice-bar").attr("class", classname);
        $("#notice-bar").find("span").html(message);
        $("#notice-bar").animate({ top: 0 }, 200).delay(2000).animate({ top: "-60px" }, 350, function () {
            if (typeof fn === "function") fn();
        });
    }
}