<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Views/Admin.master" AutoEventWireup="true" CodeFile="MenuEdit.aspx.cs" Inherits="Administrator_Views_MenuEdit" %>

<asp:Content ID="Head" ContentPlaceHolderID="HeadExtension" runat="Server">
</asp:Content>
<asp:Content ID="FunctionTitle" ContentPlaceHolderID="FunctionTitlePlaceHolder" runat="Server">
    <asp:Literal runat="server" ID="ltrTitile"></asp:Literal>
</asp:Content>
<asp:Content ID="Breadrum" ContentPlaceHolderID="BreadrumPlaceHolder" runat="Server">
    <a href="Default.aspx">Trang chủ</a> &raquo; <a href="MenuManager.aspx">Thể loại</a> &raquo; <a href="javascript:void();" class="active">Chi tiết thể loại</a>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="CatEditUpdatePanel" runat="server">
        <ContentTemplate>

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=drlTheLoai.ClientID %>">Menu cha</label>
                </div>

                <div class="col-md-3">
                    <asp:DropDownList ID="drlTheLoai" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

            </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=drlLanguage.ClientID %>">Chọn ngôn ngữ</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drlLanguage" runat="server" CssClass="form-control" AutoPostBack="true">
                        <asp:ListItem Value="vi" Text="Tiếng Việt"></asp:ListItem>
                        <asp:ListItem Value="en" Text="Tiếng Anh"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=txtTitle.ClientID %>">Tiêu đề</label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Nhập tiêu đề"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="TitleRequiredFieldValidator" runat="server" ControlToValidate="txtTitle" ErrorMessage="Chưa nhập tiêu đề" CssClass="red">*</asp:RequiredFieldValidator>
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

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=drlLinkType.ClientID %>">Loại liên kết &amp; ID Đối tượng</label>
                </div>

                <div class="col-md-3">
                    <asp:DropDownList ID="drlLinkType" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtIDObject" CssClass="form-control" placeholder="ID đối tượng"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:CompareValidator ID="IDObjectIntegerCompareValidator" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtIDObject" ErrorMessage="ID Đối tượng là số nguyên" />
                    <asp:RequiredFieldValidator ID="LinkTypeRequiredFieldValidator" ControlToValidate="drlLinkType"
                        SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="txtLink" CssClass="form-control" placeholder="Liên kết"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:RequiredFieldValidator ID="LinkRequiredFieldValidator" runat="server" ControlToValidate="txtLink" ErrorMessage="Chưa nhập liên kết" CssClass="red">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=drlPostion.ClientID %>">Vị trí &amp; thứ tự</label>
                </div>

                <div class="col-md-3">
                    <asp:DropDownList ID="drlPostion" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtOrder" CssClass="form-control" placeholder="Thứ tự sắp xếp của menu"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:CompareValidator ID="OrderIntegerCompareValidator" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtOrder" ErrorMessage="ID Đối tượng là số nguyên" />
                    <asp:RequiredFieldValidator ID="PositionRequiredFieldValidator" ControlToValidate="drlPostion"
                        SetFocusOnError="true" Display="Static" CssClass="red" InitialValue="0" runat="server">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                    <label for="<%=txtIcon.ClientID %>">Icon menu</label>
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="txtIcon" CssClass="form-control" placeholder="Chọn icon từ thư viện hoặc từ liên kết ngoài..."></asp:TextBox>
                        <span class="input-group-btn">

                            <a href="javascript:BrowseFilesIcon( 'Images:/');" class="btn btn-default">
                                <i class="fa fa-folder-open"></i>
                            </a></span>
                    </div>
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

                            <a href="javascript:BrowseFilesAvatar( 'Images:/');" class="btn btn-default">
                                <%--<a href="javascript:BrowseServer( 'Images:/','<%=txtFigure.ClientID %>');" class="btn btn-default">--%>
                                <i class="fa fa-folder-open"></i>
                            </a></span>
                    </div>
                </div>
            </div>

            <div class="row form-group">
                <div class="col-md-3">
                </div>
                <div class="col-md-6">
                    <%-- <label>ICON: </label>--%>
                    <div id="sthumb-container-icon"></div>
                    <div id="sthumb-container-avatar"></div>
                </div>
            </div>





            <div class="row form-group">

                <div class="tool-bar">
                    <div class="btn-item">
                        <asp:HyperLink runat="server" ID="lbtnClose" NavigateUrl="~/Administrator/Views/MenuManager.aspx" CssClass="btn btn-danger btn-sm btn-block" Text="Đóng">
                            <i class="fa fa-times"></i>&nbsp; Đóng
                        </asp:HyperLink>
                    </div>
                    <div class="btn-item">
                        <asp:LinkButton runat="server" ID="btnSaveItem" CssClass="btn btn-primary btn-sm btn-block" Text="Lưu lại">
                            <i class="fa fa-save"></i>&nbsp; Lưu lại
                        </asp:LinkButton>
                    </div>

                    <div class="col-md-6">
                    </div>

                    <div class="row form-group">
                        <div class="col-md-6">

                            <asp:Label ID="lbMess" runat="server" CssClass="label label-success pull-left" Style="padding: 5px;"></asp:Label>
                        </div>
                    </div>

                    <div class="hide" id="server-message">
                        <asp:Literal runat="server" ID="ltrServerMessage"></asp:Literal>
                    </div>
                    <div class="hide" id="callback-function">
                        <asp:Literal runat="server" ID="ltrCallBackFunction"></asp:Literal>
                    </div>


                    <span class="label label-success pull-left hide" style="padding: 5px;">Thông báo ở đây</span>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Foot" ContentPlaceHolderID="FootExtension" runat="Server">
    <script src="/Editors/ckfinder/popup.js"></script>
    <script src="/Editors/ckfinder/ckfinder.js"></script>

    <%-- Jquery for Update panel animation --%>
    <script src="/Styles/Admin/VNITAdmin/updatepanel.helper.js"></script>

    <script type="text/javascript">

        function BrowseFilesIcon(startupPath) {
            var finder = new CKFinder();
            finder.selectActionFunction = CreatePreviewImageIcon;
            finder.popup();
        }

        function BrowseFilesAvatar(startupPath) {
            var finder = new CKFinder();
            finder.selectActionFunction = CreatePreviewImageAvatar;
            finder.popup();
        }

        function CreatePreviewImageIcon(fileUrl, data) {
            $('#<%=txtIcon.ClientID %>').val(fileUrl);
            appendSthumb("#sthumb-container-icon", fileUrl, "Icon: ");
        }
        function CreatePreviewImageAvatar(fileUrl, data) {
            $('#<%=txtFigure.ClientID %>').val(fileUrl);
            appendSthumb("#sthumb-container-avatar", fileUrl, "Ảnh đại diện: ");

        }

        function appendSthumb(selector, img, text) {
            var html = "<div class='thumb-text'>  <span> " + text + " </span></div>    <div class=\"sthumb\"><img src=\"" + img + "\"/><a href=\"javascript:{}\" class=\"fa fa-times text-danger del\"></a></div>";
            $(selector).html(html);
        }

        $(document).on("click", ".sthumb > a.del", function () {
            var parentClass = $(this).parent().parent().attr("class");
            alert(parentClass);
            //$(this).parent().parent().html("");

        });



        function redirect(id) {
            window.location = "/Administrator/Views/CategoryEdit.aspx?ID=" + id;
        }


    </script>
</asp:Content>

