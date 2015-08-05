<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Views/Admin.master" AutoEventWireup="true" CodeFile="ArticleManager.aspx.cs" Inherits="Administrator_Views_ArticleManager" %>

<asp:Content ID="Title" ContentPlaceHolderID="FunctionTitlePlaceHolder" runat="Server">
    Danh sách bài viết
    <asp:Label ID="tam" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Breadcrum" ContentPlaceHolderID="BreadrumPlaceHolder" runat="Server">
    <a href="Default.aspx">Trang chủ</a> &raquo; <a href="javascript:void();" class="active">Bài viết</a> &raquo; <a href="javascript:void();" class="active">Danh sách bài viết</a>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="HeadExtension" runat="Server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="CatEditUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="col-md-12" style="margin-bottom: 10px;">
                <div class="col-md-3">
                    <asp:DropDownList ID="drlCategory" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drlModule_OnSelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="drlStatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drlStatus_SelectedIndexChanged">
                        <asp:ListItem Value="-1" Text="Chọn trạng thái"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Xuất bản"></asp:ListItem>
                        <asp:ListItem Value="0" Text="Không xuất bản"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <div class="pull-left search-box-manage">
                        <asp:Panel ID="SearchPanel" runat="server" CssClass="input-group" DefaultButton="lbtnSearch">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Tìm kiếm ..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:LinkButton runat="server" ID="lbtnSearch" CssClass="btn btn-default" OnClick="lbtnSearch_OnClick"><i class="fa fa-search"></i></asp:LinkButton>
                            </span>
                        </asp:Panel>
                    </div>
                </div>

                <div class="tool-bar">
                    <div class="btn-item">
                        <asp:LinkButton runat="server" ID="lbtnRefresh" CssClass="btn btn-info btn-sm with-confirm" OnClick="lbtnRefresh_Click" ToolTip="Làm mới"><i class="fa fa-refresh"></i></asp:LinkButton>
                    </div>

                    <div class="btn-item">
                        <asp:HyperLink runat="server" ID="hlnkAddNew" NavigateUrl="~/Administrator/Views/ArticleEdit.aspx" CssClass="btn btn-primary btn-sm with-confirm" ToolTip="Thêm bài mới"><i class="fa fa-plus-circle"></i></asp:HyperLink>
                    </div>

                    <div class="btn-item">
                        <a id="btnDelete" class="btn btn-danger btn-sm with-confirm multidelete" title="Xóa bài viết được chọn" onclick="DeleteItems();"><i class="fa fa-times"></i></a>
                        <%--<asp:LinkButton runat="server" ID="hlnkDelete" CssClass="btn btn-danger btn-sm with-confirm multidelete" ToolTip="Xóa bài viết được chọn" OnClientClick="return false; alert('hoang');"><i class="fa fa-times"></i> </asp:LinkButton>--%>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <table class="table table-striped list" id="dttb" style="border-left: 1px solid #C0C0C0; border-right: 1px solid #C0C0C0;">
                    <thead class="thead">
                        <tr>
                            <th>
                                <input type="checkbox" id="chkAll" onclick="checkAll();" /></th>

                            <th>Hình ảnh</th>
                            <th>Tiêu đề</th>
                            <th>Lượt xem</th>
                            <th>Người tạo</th>
                            <th>Ngày tạo</th>
                            <th>ID</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptDataTable" OnItemCommand="rptDataTable_ItemCommand" OnItemDataBound="rptDataTable_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input type="checkbox" name='cid' value='<%#Eval("ID") %>' class="ckb" />
                                    </td>

                                    <td>
                                        <div class="figure">
                                            <img src="<%#ShowInfos(Container.DataItem,"figure")%>" alt="Hình ảnh" class="img" />
                                        </div>
                                    </td>
                                    <td><%#Eval("Title") %></td>
                                    <td><%#Eval("View") %></td>
                                    <td><%#Eval("Creator") %></td>
                                    <td><%#Eval("CreteDdate") %></td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrItemId" Text='<%#Eval("Id") %>'></asp:Literal>
                                    </td>
                                    <td class="tcenter">
                                        <asp:LinkButton ID="lbtnPublish" runat="server" CssClass="btn btn-success btn-xs" CommandName="UpdateStatus">
                                            <i class="fa fa-check"></i>
                                        </asp:LinkButton>
                                    </td>
                                    <td class="tcenter">
                                        <a href="ArticleEdit.aspx?ID=<%#Eval("Id") %>" class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
            <div class="col-md-12">
                <asp:AdminPager runat="server" PageSize="10" ID="MainPager" GenerateFirstLastSection="True" GenerateGoToSection="True" OnCommand="PagerCommand" />
                <div class="hide" id="server-message">
                    <asp:Literal runat="server" ID="ltrServerMessage"></asp:Literal>
                </div>
                <div class="hide" id="callback-function">
                    <asp:Literal runat="server" ID="ltrCallBackFunction"></asp:Literal>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="MainPager" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Footer" ContentPlaceHolderID="FootExtension" runat="Server">
    <script src="/Styles/Admin/VNITAdmin/updatepanel.helper.js"></script>

    <script src="/Styles/Datatables/jquery.highlight.js"></script>
    <script type="text/javascript">
        function ReLoadDataTable() {
            var table = $('#dttb').DataTable({
                "columnDefs": [
                    { "orderable": false, "targets": 0 },
                    { "orderable": false, "targets": 1 },
                    { "orderable": false, "targets": 4 },
                    { "orderable": false, "targets": 7 },
                    { "orderable": false, "targets": 8 }
                ],
                paging: false,
                stateSave: true,
                info: false
            });

            table.on('draw', function () {
                var body = $(table.table().body());
                body.unhighlight();
                body.highlight(table.search());
            });

            $('#<%=txtSearch.ClientID%>').keyup(function () {
                table.search($(this).val()).draw();
            })

            table.search('').columns().search('').draw();
        }
        ReLoadDataTable();

        function DeleteItems() {
            var n = $("table.list input:checkbox[name$=cid]:checked").length;
            if (n == 0) {
                alert('Vui lòng chọn ít nhất một dòng để xóa!');
                return false;
            }
            else {
                var choose = confirm('Chú ý: Các hàng được chọn sẽ bị xóa vĩnh viễn. Bạn có muốn tiếp tục không?');
                if (choose == true) {
                    var sId = "";
                    $("table.list input:checkbox[name$=cid]:checked").each(function () {
                        sId += $(this).val() + ",";
                    });

                    $.ajax({
                        type: "POST",
                        url: 'ArticleManager.aspx/DeleteItem',
                        data: "{ids:'" + sId + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            window.location = "/Administrator/Views/ArticleManager.aspx";
                        },
                        error: function (e) {
                            alert("Có lỗi xảy ra");
                        }
                    });

                } else {
                    return false;
                }

            }
        }

        function checkAll() {
            if ($("#chkAll").is(':checked')) {
                $(".ckb").each(function () {
                    $(this).prop("checked", true);
                }); s

            } else {
                $(".ckb").each(function () {
                    $(this).prop("checked", false);
                });
            }
        }
    </script>

</asp:Content>
