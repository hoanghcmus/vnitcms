<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Views/Admin.master" AutoEventWireup="true" CodeFile="CategoryManager.aspx.cs" Inherits="Administrator_Views_CategoryManager" %>


<asp:Content ID="Title" ContentPlaceHolderID="FunctionTitlePlaceHolder" runat="Server">
    Danh sách thể loại
</asp:Content>
<asp:Content ID="Breadcrum" ContentPlaceHolderID="BreadrumPlaceHolder" runat="Server">
    <a href="Default.aspx">Trang chủ</a> &raquo; <a href="javascript:void();" class="active">Thể loại</a> &raquo; <a href="javascript:void();" class="active">Danh sách thể loại</a>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="HeadExtension" runat="Server">
    <script src="/Styles/Admin/SBAdmin/angular.min.js"></script>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="CatEditUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="col-md-12" style="margin-bottom: 10px;">
                <div class="col-md-3">
                    <asp:DropDownList ID="drlModule" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drlModule_OnSelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <div class="pull-left search-box-manage">
                        <asp:Panel ID="SearchPanel" runat="server" CssClass="input-group" DefaultButton="lbtnSearch">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Tìm kiếm theo tiêu đề..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:LinkButton runat="server" ID="lbtnSearch" CssClass="btn btn-default" OnClick="lbtnSearch_OnClick"><i class="fa fa-search"></i></asp:LinkButton>
                            </span>
                        </asp:Panel>
                    </div>
                </div>

                <div class="tool-bar">
                    <div class="btn-item">

                        <asp:LinkButton runat="server" ID="lbtnRefresh" CssClass="btn btn-info btn-sm with-confirm" OnClick="lbtnRefresh_Click"><i class="fa fa-refresh"></i> </asp:LinkButton>
                    </div>
                    <div class="btn-item">
                        <asp:HyperLink runat="server" ID="hlnkAddNew" NavigateUrl="~/Administrator/Views/CategoryEdit.aspx" CssClass="btn btn-primary btn-sm with-confirm"><i class="fa fa-plus-circle"></i> </asp:HyperLink>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <table class="table table-striped" id="dttb">
                    <thead class="thead">
                        <tr>
                            <th class="w8pc">ID</th>
                            <th class="w50pc">Tiêu đề</th>
                            <th class="w30pc">Loại module</th>
                            <th class="w5pc"></th>
                            <th class="w5pc"></th>
                        </tr>
                    </thead>
                    <tbody data-ng-app="myApp" data-ng-controller="customersCtrl">

                        <%--<tr data-ng-repeat="x in names" id="tbrecords">
                            <td>{{x.ID}}</td>
                            <td>{{x.Title}}</td>
                            <td>{{x.ModuleName}}</td>
                            <td>
                                <a href="CategoryEdit.aspx?ID={{x.ID}}" class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i>&nbsp; Sửa</a>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lbtnDelete" CssClass="btn btn-danger btn-xs with-confirm" CommandName="Delete"><i class="fa fa-times"></i>&nbsp; Xóa</asp:LinkButton>
                            </td>
                        </tr>--%>

                        <asp:Repeater runat="server" ID="rptDataTable" OnItemCommand="rptDataTable_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrItemId" Text='<%#Eval("Id") %>'></asp:Literal></td>
                                    <td><%#Eval("Title") %></td>
                                    <td><%#Eval("ModuleName") %></td>
                                    <td>
                                        <a href="CategoryEdit.aspx?ID=<%#Eval("Id") %>" class="btn btn-primary btn-xs"><i class="fa fa-pencil"></i>&nbsp; Sửa</a>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="lbtnDelete" CssClass="btn btn-danger btn-xs with-confirm" CommandName="Delete"><i class="fa fa-times"></i>&nbsp; Xóa</asp:LinkButton>
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

        //function LoadDataTatable() {
        //    var app = angular.module('myApp', []);
        //    app.controller('customersCtrl', function ($scope, $compile) {
        //        $scope.names = parseJson($("#server-message").html());

        //        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (sender, args) {
        //            var elem = angular.element(document.getElementById("tbrecords"));
        //            elem.replaceWith($compile(elem)($scope));
        //            $scope.$apply();
        //        });
        //    });
        //}
        //LoadDataTatable();

        function ReLoadDataTable() {
            var table = $('#dttb').DataTable({
                "columnDefs": [
                   { "orderable": false, "targets": 3 },
                   { "orderable": false, "targets": 4 }
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

    </script>

</asp:Content>
