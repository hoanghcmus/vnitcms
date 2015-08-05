function parseJson(str) {
    try {
        var json = $.parseJSON(str);
    } catch (e) {
        json = null;
    }
    return json;
}
function beginRequestHandler(sender, args) {
    showLoadingbar();
    if (typeof optionalBeginRequestHandler == "function")
    { optionalBeginRequestHandler(); }
}
function endRequestHandler(sender, args) {
    var data = parseJson($("#server-message").html());
    // var data = JSON.parse($("#server-message").html());
    var callback = parseJson($("#callback-function").html());
    hideLoadingbar(function () {
        if (data != null)
            showNotice(data.Message, data.MessageType);
        if (callback != null) {
            var funcs = callback.Message.split(";");
            for (var i = 0; i < funcs.length; i++) {
                if (funcs[i] != "")
                    if (callback.Option != "")
                        window[funcs[i]](callback.Option);
                    else
                        window[funcs[i]]();
            }
        }
    });
    if (typeof optionalEndRequestHandler == "function")
    { optionalEndRequestHandler(); }
}

Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);