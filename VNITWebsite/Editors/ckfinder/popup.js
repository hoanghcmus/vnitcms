function BrowseServer(startupPath, functionData) {
    var finder = new CKFinder();
    /*finder.basePath = '/plugins/ckfinder/';*/
    /*finder.startupPath = startupPath;*/
    /*finder.id = "defckf";*/
    finder.selectActionFunction = SetFileField;
    finder.selectActionData = functionData;
    finder.selectThumbnailFunction = SetFileField;
    finder.selectThumbnailFunctionData = functionData;
    finder.popup();
}
function SetFileField(fileUrl, data) {
    document.getElementById(data["selectActionData"]).value = fileUrl;
}