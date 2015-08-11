using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;
using VNITLibrary.VNITDatabase;

public partial class Administrator_Views_CategoryManager : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrServerMessage.Text = "";
        if (!IsPostBack)
        {
            InitControls();
            LoadDataTable();
        }
    }

    protected void InitControls()
    {
        LoadData_To_DrlModule(Module.GetList());
    }

    protected void LoadData_To_DrlModule(List<Module> lm)
    {
        drlModule.DataTextField = "ModuleName";
        drlModule.DataValueField = "ID";
        drlModule.DataSource = lm;
        drlModule.DataBind();
        drlModule.Items.Insert(0, new ListItem("Chọn loại module", "0"));
    }

    protected void LoadDataTable()
    {
        var skip = (MainPager.CurrentIndex - 1) * MainPager.PageSize;
        var take = MainPager.PageSize;
        var filterParams = new FilterParams()
        {
            KeyWord = txtSearch.Text.Trim(),
            ModuleId = ConvertType.ToInt32(drlModule.SelectedValue, 0)
        };

        var query = Category.GetList(filterParams);
        var items = query.Skip(skip).Take(take).ToList();
        var count = query.Count();
        if (count > 0)
        {
            MainPager.Visible = true;
            MainPager.ItemCount = count;
        }
        else
        {
            MainPager.Visible = false;
        }
        rptDataTable.DataSource = items.Select(o => new
        {
            o.ID,
            o.Title,
            o.ModuleID,
            ModuleName = Category.GetModuleName(ConvertType.ToInt32(o.ModuleID, 0))
        });
        rptDataTable.DataBind();

        //ltrServerMessage.Text = JsSerializer.Serialize(
        //     items.Select(o => new
        //    {
        //        o.ID,
        //        o.Title,
        //        ModuleName = Category.GetModuleName(o.ModuleID)
        //    })
        //);
        ltrCallBackFunction.Text = JsSerializer.Serialize(new ServerMessage("ReLoadDataTable", ServerMessage.InfoMessage, "", ""));
    }

    protected void PagerCommand(object sender, CommandEventArgs e)
    {
        var currIndex = ConvertType.ToInt(e.CommandArgument);
        MainPager.CurrentIndex = currIndex;
        LoadDataTable();
    }

    protected void ReloadDataTable()
    {
        MainPager.CurrentIndex = 1;
        LoadDataTable();
    }

    protected void lbtnSearch_OnClick(object sender, EventArgs e)
    {
        ReloadDataTable();
    }

    protected void drlModule_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadDataTable();
    }

    protected void lbtnRefresh_Click(object sender, EventArgs e)
    {
        txtSearch.Text = String.Empty;
        drlModule.SelectedIndex = 0;
        ReloadDataTable();
    }
    protected void rptDataTable_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var sm = new ServerMessage();
        if (e.CommandName == "Delete")
        {
            var ltrItemId = (Literal)e.Item.FindControl("ltrItemId");
            var id = ConvertType.ToInt(ltrItemId.Text);
            var t = DB.Categories.FirstOrDefault(o => o.ID == id);
            if (t == null) return;
            var childCats = Category.GetList(id);
            if (childCats.Any())
            {
                sm = new ServerMessage("Thể loại này có chứa thể loại con, vui lòng xóa các thể loại con trước khi xóa thể loại này", ServerMessage.DangerMessage,"","");
            }
            else
            {
                if (Category.DeleteByID(id) > 0)
                    sm = new ServerMessage(String.Format("Đã xóa thể loại có ID {0}", id), ServerMessage.InfoMessage, "", "");
                else
                    sm = new ServerMessage("Có lỗi xảy ra", ServerMessage.InfoMessage, "", "");
            }
        }

        ltrServerMessage.Text = JsSerializer.Serialize(sm);
        var currIndex = MainPager.CurrentIndex;

        if (currIndex > MainPager.PageCount && MainPager.PageCount > 0)
        {
            MainPager.CurrentIndex = MainPager.PageCount;
            //LoadDataTable();
        }
        LoadDataTable();
    }
}