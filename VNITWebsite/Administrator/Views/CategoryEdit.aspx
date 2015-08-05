<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Views/Admin.master" AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="CategoryEdit" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadExtension" runat="Server">
</asp:Content>
<asp:Content ID="FunctionTitle" runat="server" ContentPlaceHolderID="FunctionTitlePlaceHolder">
<<<<<<< HEAD
    <asp:Literal runat="server" ID="ltrTitile"></asp:Literal>
</asp:Content>
<asp:Content ID="Breadrum" runat="server" ContentPlaceHolderID="BreadrumPlaceHolder">

    <a href="Default.aspx">Trang chủ</a> &raquo; <a href="CategoryManager.aspx">Thể loại</a> &raquo; <a href="javascript:void();" class="active">Chi tiết thể loại</a>
=======
    Thêm thê loại mới
</asp:Content>
<asp:Content ID="Breadrum" runat="server" ContentPlaceHolderID="BreadrumPlaceHolder">

    <a href="javascript:void();">Trang chủ</a> &raquo; <a href="javascript:void();">Thể loại</a> &raquo; <a href="javascript:void();" class="active">Thêm thể loại mới</a>
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="Server">

    <asp:UpdatePanel ID="CatEditUpdatePanel" runat="server">
        <ContentTemplate>

            <div class="row form-group">
                <div class="col-md-3">
<<<<<<< HEAD
                    <label for="<%=drlModule.ClientID %>">Loại module &amp; thể loại cha</label>
=======
                    <label for="drlModule">Loại module &amp; thể loại cha</label>
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drlModule" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
<<<<<<< HEAD

                <div class="col-md-3">
                    <asp:DropDownList ID="drlTheLoai" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="ModuleRequiredFieldValidator" ControlToValidate="drlModule"
                        SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">Vui lòng chọn module</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=drlLanguage.ClientID %>">Chọn ngôn ngữ</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drlLanguage" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drlLanguage_SelectedIndexChanged">
                        <asp:ListItem Value="vi" Text="Tiếng Việt"></asp:ListItem>
                        <asp:ListItem Value="en" Text="Tiếng Anh"></asp:ListItem>
                    </asp:DropDownList>
                </div>
=======
                <div class="col-md-3">
                    <asp:DropDownList ID="drlTheLoai" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
            </div>
            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=txtTitle.ClientID %>">Tiêu đề</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Nhập tiêu đề"></asp:TextBox>
                </div>
<<<<<<< HEAD
                <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="TitleRequiredFieldValidator" runat="server" ControlToValidate="txtTitle" ErrorMessage="*" CssClass="red">*</asp:RequiredFieldValidator>
                </div>
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=txtDescription.ClientID %>">Mô tả</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" placeholder="Nhập mô tả" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=txtFigure.ClientID %>">Ảnh minh họa</label>
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtFigure" CssClass="form-control" placeholder="Chọn ảnh từ thư viện hoặc từ liên kết ngoài..."></asp:TextBox>
                        <span class="input-group-btn">
<<<<<<< HEAD
                            <a href="javascript:BrowseFiles( 'Images:/');" class="btn btn-default">
=======
                            <a href="javascript:BroewseFiles( 'Images:/');" class="btn btn-default">
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
                                <%--<a href="javascript:BrowseServer( 'Images:/','<%=txtFigure.ClientID %>');" class="btn btn-default">--%>
                                <i class="fa fa-folder-open"></i>
                            </a></span>
                    </div>
                </div>
            </div>


            <div class="row form-group">
                <div class="col-md-3">
                    <%-- <label>Ảnh minh họa: </label>--%>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div id="sthumb-container"></div>
<<<<<<< HEAD
                            <div class="sthumb add"><a href="javascript:BrowseFiles( 'Images:/');" class="btn btn-success hide">+</a></div>
=======
                            <div class="sthumb add"><a href="javascript:BroewseFiles( 'Images:/');" class="btn btn-success hide">+</a></div>
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <asp:TextBox runat="server" ID="txtListImgs" CssClass="hide"></asp:TextBox>
            </div>


            <div class="row form-group">
<<<<<<< HEAD
                <div class="tool-bar">
                    <div class="btn-item">
                        <asp:HyperLink runat="server" ID="lbtnClose" NavigateUrl="~/Administrator/Views/CategoryManager.aspx" CssClass="btn btn-danger btn-sm btn-block" Text="Đóng">
                            <i class="fa fa-times"></i>&nbsp; Đóng
                        </asp:HyperLink>
                    </div>
                    <div class="btn-item">
                        <asp:LinkButton runat="server" ID="btnSaveItem" CssClass="btn btn-primary btn-sm btn-block" Text="Lưu lại" OnClick="btnSaveItem_Click">
                            <i class="fa fa-save"></i>&nbsp; Lưu lại
                        </asp:LinkButton>
                    </div>
=======
                <div class="col-md-6">
                </div>
                <div class="col-md-3">
                    <asp:LinkButton runat="server" ID="btnSaveItem" CssClass="btn btn-primary btn-block" Text="Lưu lại" OnClick="btnSaveItem_Click"></asp:LinkButton>
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-6">
<<<<<<< HEAD
                    <asp:Label ID="lbMess" runat="server" CssClass="label label-success pull-left" Style="padding: 5px;"></asp:Label>
                </div>
            </div>

            <div class="hide" id="server-message">
                <asp:Literal runat="server" ID="ltrServerMessage"></asp:Literal>
            </div>
            <div class="hide" id="callback-function">
                <asp:Literal runat="server" ID="ltrCallBackFunction"></asp:Literal>
            </div>

=======
                    <span class="label label-success pull-left hide" style="padding: 5px;">Thông báo ở đây</span>
                </div>
            </div>

>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

<asp:Content ID="Foot" ContentPlaceHolderID="FootExtension" runat="Server">

    <script src="/Editors/ckfinder/popup.js"></script>
    <script src="/Editors/ckfinder/ckfinder.js"></script>

    <%-- Jquery for Update panel animation --%>
    <script src="/Styles/Admin/VNITAdmin/updatepanel.helper.js"></script>

    <script type="text/javascript">
<<<<<<< HEAD
        function BrowseFiles(startupPath) {
=======
        function BroewseFiles(startupPath) {
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
            var finder = new CKFinder();
            finder.selectActionFunction = CreatePreviewImage;
            finder.popup();
        }

        function CreatePreviewImage(fileUrl, data) {
            $('#<%=txtFigure.ClientID %>').val(fileUrl);
            var txtImgs = $("#<%=txtListImgs.ClientID%>");
            appendSthumb(fileUrl);
            if (txtImgs.val() == "") txtImgs.val(fileUrl);
            else txtImgs.val(txtImgs.val() + ";" + fileUrl);
        }

        function appendSthumb(img) {
            var html = "<div class=\"sthumb\"><img src=\"" + img + "\"/><a href=\"javascript:{}\" class=\"fa fa-times text-danger del\"></a></div>";
            $("#sthumb-container").append(html);
        }

        function createImgBar() {
            var txtImgs = $("#<%=txtListImgs.ClientID%>");
            var imgs = txtImgs.val().split(";");
            for (var i = 0; i < imgs.length; i++) {
                if (imgs[i] != "") appendSthumb(imgs[i]);
            }
        }
<<<<<<< HEAD

=======
      
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
        createImgBar();

        $(document).on("click", ".sthumb > a.del", function () {
            var txtImgs = $("#<%=txtListImgs.ClientID%>");
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

<<<<<<< HEAD
        $("#<%=txtFigure.ClientID %>").bind("enterKey", function (e) {
            var imgsrc = $("#<%=txtFigure.ClientID %>").val();
            if (imgsrc != "") {
                //appendSthumb(imgsrc);
                CreatePreviewImage(imgsrc, null);
            }
=======
            $("#<%=txtFigure.ClientID %>").bind("enterKey", function (e) {
            var imgsrc = $("#<%=txtFigure.ClientID %>").val();
            if (imgsrc != "") appendSthumb(imgsrc);
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
        });

        $("#<%=txtFigure.ClientID %>").keyup(function (e) {
            if (e.keyCode == 13) {
                $(this).trigger("enterKey");
            }
        });

<<<<<<< HEAD
        function redirect(id) {
            window.location = "/Administrator/Views/CategoryEdit.aspx?ID=" + id;
        }

=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
    </script>
</asp:Content>

