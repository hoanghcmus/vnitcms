<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Views/Admin.master" AutoEventWireup="true" CodeFile="CategoryAddOrEdit.aspx.cs" Inherits="Administrator_Views_CategoryAddOrEdit" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadExtension" runat="Server">
</asp:Content>
<asp:Content ID="FunctionTitle" runat="server" ContentPlaceHolderID="FunctionTitlePlaceHolder">
    Thêm thê loại mới
</asp:Content>
<asp:Content ID="Breadrum" runat="server" ContentPlaceHolderID="BreadrumPlaceHolder">

    <a href="javascript:void();">Trang chủ</a> &raquo; <a href="javascript:void();">Thể loại</a> &raquo; <a href="javascript:void();" class="active">Thêm thể loại mới</a>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row form-group">
        <div class="col-md-3">
            <label for="drlModule">Loại module &amp; thể loại cha</label>
        </div>
        <div class="col-md-3">
            <select class="form-control" id="drlModule">
                <option value="1">Bài viết</option>
                <option value="2">Hình Ảnh và Video</option>
                <option value="3">Khác</option>
            </select>
        </div>
        <div class="col-md-3">
            <select class="form-control" id="drlTheLoai">
                <option value="1">Thiết kế website</option>
                <option value="2">Tin tức và sự kiện</option>
                <option value="3">Lập trình phần mềm</option>
            </select>
        </div>
    </div>
    <div class="row form-group">
        <div class="col-md-3">
            <label for="<%=txtTitle.ClientID %>">Tiêu đề</label>
        </div>
        <div class="col-md-6">
            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Nhập tiêu đề"></asp:TextBox>
        </div>
    </div>

    <div class="row form-group">
        <div class="col-md-3">
            <label for="<%=txtDescription.ClientID %>">Mô tả</label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" placeholder="Nhập mô tả" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <%--<div class="row form-group">
        <div class="col-md-3">
            <label for="<%=txtFigure.ClientID %>">Ảnh minh họa</label>
        </div>
        <div class="col-md-6">
            <div class="input-group">
                <asp:TextBox runat="server" ID="txtFigure" CssClass="form-control" placeholder="Chọn ảnh từ thư viện hoặc từ liên kết ngoài..."></asp:TextBox>
                <span class="input-group-btn">
                    <a href="javascript:BrowseServer( 'Images:/','<%=txtFigure.ClientID %>');" class="btn btn-default">
                        <i class="fa fa-folder-open"></i>
                    </a>
                </span>
            </div>
        </div>
    </div>--%>


    <div class="row form-group">
        <div class="col-md-3">
            <label>Ảnh minh họa: </label>
        </div>
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div id="sthumb-container"></div>
                    <div class="sthumb add"><a href="javascript:BroewseFiles( 'Images:/');" class="btn btn-success">+</a></div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <asp:TextBox runat="server" ID="txtOptionalImages" CssClass="hide"></asp:TextBox>
    </div>


    <div class="row form-group">
        <div class="col-md-6">
        </div>
        <div class="col-md-3">
            <asp:LinkButton runat="server" ID="btnSaveItem" CssClass="btn btn-primary btn-block" Text="Lưu lại"></asp:LinkButton>
        </div>
    </div>

    <div class="row form-group">
        <div class="col-md-6">
            <span class="label label-success pull-left hide" style="padding: 5px;">Thông báo ở đây</span>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Foot" ContentPlaceHolderID="FootExtension" runat="Server">
    <script src="/Editors/ckfinder/popup.js"></script>
    <script src="/Editors/ckfinder/ckfinder.js"></script>
    <%-- Jquery for Update panel animation --%>
    <script src="/Styles/Admin/VNITAdmin/updatepanel.helper.js"></script>

    <script type="text/javascript">
        function BroewseFiles(startupPath) {
            var finder = new CKFinder();
            finder.selectActionFunction = CreatePreviewImage;
            finder.popup();
        }

        function CreatePreviewImage(fileUrl, data) {
            var txtImgs = $("#<%=txtOptionalImages.ClientID%>");
            appendSthumb(fileUrl);
            if (txtImgs.val() == "") txtImgs.val(fileUrl);
            else txtImgs.val(txtImgs.val() + ";" + fileUrl);
        }

        function appendSthumb(img) {
            var html = "<div class=\"sthumb\"><img src=\"" + img + "\"/><a href=\"javascript:{}\" class=\"fa fa-times text-danger del\"></a></div>";
            $("#sthumb-container").append(html);
        }

        function createImgBar() {
            var txtImgs = $("#<%=txtOptionalImages.ClientID%>");
            var imgs = txtImgs.val().split(";");
            for (var i = 0; i < imgs.length; i++) {
                if (imgs[i] != "") appendSthumb(imgs[i]);
            }
        }


        $(document).on("click", ".sthumb > a.del", function () {
            var txtImgs = $("#<%=txtOptionalImages.ClientID%>");
            var sthumb = $(this).parent();
            var imgPath = sthumb.find("img").attr("src");
            var imgPaths = txtImgs.val();
            imgPaths = imgPaths.replace(imgPath, "").replace(";;", ";");
            if (imgPaths.startsWith(";")) {
                imgPaths = imgPaths.substring(1);
            }
            if (imgPaths.endsWith(";") && imgPaths.length > 0) {
                imgPaths = imgPaths.substring(0, imgPaths.length - 1);
            }
            txtImgs.val(imgPaths);
            sthumb.remove();
        });

    </script>
</asp:Content>

