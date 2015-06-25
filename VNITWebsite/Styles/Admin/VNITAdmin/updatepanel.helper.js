﻿function parseJson(str) {
    try {
        var json = $.parseJSON(str);
    } catch (e) {
        json = null;
    }
    return json;
}
function beginRequestHandler(sender, args) {
    //alert("begin");
    showLoadingbar();
    if (typeof optionalBeginRequestHandler == "function")
    { optionalBeginRequestHandler(); }
}
function endRequestHandler(sender, args) {
    // alert("end");
    var data = parseJson($("#server-message").html());
    // var data = JSON.parse($("#server-message").html());
    hideLoadingbar(function () {
        if (data != null)
            showNotice(data.Message, data.MessageType);
    });
    if (typeof optionalEndRequestHandler == "function")
    { optionalEndRequestHandler(); }
}

Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);