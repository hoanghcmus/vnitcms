using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;
using VNITLibrary.VNITDatabase;

public partial class Administrator_Views_ArticleManager : BasePage
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
        var lc = new List<Category>();
        Category.GetMultiLevelList(0, 0, ref lc, 0);
        LoadData_To_DrlCategory(lc);

    }

    protected void LoadData_To_DrlCategory(List<Category> lc)
    {
        drlCategory.DataTextField = "Title";
        drlCategory.DataValueField = "ID";
        drlCategory.DataSource = lc;
        drlCategory.DataBind();
        drlCategory.Items.Insert(0, new ListItem("Chọn thể loại bài viết", "0"));
    }

    protected void LoadDataTable()
    {
        var skip = (MainPager.CurrentIndex - 1) * MainPager.PageSize;
        var take = MainPager.PageSize;
        var filterParams = new FilterParams()
        {
            CatId = Convert.ToInt32(drlCategory.SelectedValue),
            KeyWord = txtSearch.Text.Trim(),
            Status = Convert.ToInt32(drlStatus.SelectedValue)

        };

        var query = Article.GetList(filterParams);
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

        rptDataTable.DataSource = items;
        rptDataTable.DataBind();

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
        drlCategory.SelectedIndex = 0;
        drlStatus.SelectedIndex = 0;
        ReloadDataTable();
    }
    protected void rptDataTable_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var sm = new ServerMessage();
        if (e.CommandName == "Delete")
        {
            var ltrItemId = (Literal)e.Item.FindControl("ltrItemId");
            var id = ConvertType.ToInt(ltrItemId.Text);
            var t = DB.Articles.FirstOrDefault(o => o.ID == id);
            if (t == null) return;

            if (Article.DeleteByID(id) > 0)
                sm = new ServerMessage(String.Format("Đã xóa bài viết có ID {0}", id), ServerMessage.InfoMessage, String.Empty, String.Empty);
            else
                sm = new ServerMessage("Có lỗi xảy ra", ServerMessage.InfoMessage, String.Empty, String.Empty);

        }

        if (e.CommandName == "UpdateStatus")
        {
            var ltrItemId = (Literal)e.Item.FindControl("ltrItemId");
            var id = ConvertType.ToInt(ltrItemId.Text);
            var a = DB.Articles.FirstOrDefault(o => o.ID == id);
            var lbtnPublish = (LinkButton)e.Item.FindControl("lbtnPublish");
            if (a.Status == 0)
            {
                a.Status = 1;
                //lbtnPublish.Text = "On";
                lbtnPublish.CssClass = "btn btn-primary btn-xs";
            }
            else
            {
                a.Status = 0;
                //lbtnPublish.Text = "Off";
                lbtnPublish.CssClass = "btn btn-danger btn-xs";
            }
            DB.SaveChanges();

        }

        ltrServerMessage.Text = JsSerializer.Serialize(sm);
        var currIndex = MainPager.CurrentIndex;

        if (currIndex > MainPager.PageCount && MainPager.PageCount > 0)
        {
            MainPager.CurrentIndex = MainPager.PageCount;
        }
        LoadDataTable();
    }
    public string ShowInfos(object sender, string func)
    {
        var article = sender as Article;
        switch (func)
        {
            case "figure":
                if (!article.Figure.Equals(String.Empty))
                {
                    return article.Figure.Split(';').First().ToString();
                }
                return String.Empty;
            default: return String.Empty;
        }
    }
    protected void rptDataTable_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var lbtnPublish = (LinkButton)e.Item.FindControl("lbtnPublish");
        var article = (Article)e.Item.DataItem;
        if (article.Status == 0)
        {
            //lbtnPublish.Text = "Off";
            lbtnPublish.CssClass = "btn btn-danger btn-xs";
        }
        else
        {
            //lbtnPublish.Text = "On";
            lbtnPublish.CssClass = "btn btn-success btn-xs";
        }
    }
    protected void drlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadDataTable();
    }

    [WebMethod]
    public static void DeleteItem(string ids)
    {
        if (ids != "")
        {
            foreach (string id in ids.Split(','))
            {
                if (!id.Equals(""))
                {
                    int iid = Convert.ToInt32(id);
                    using (var db = ConnectDB.Db())
                    {
                        var a = db.Articles.FirstOrDefault(o => o.ID == iid);
                        db.DeleteObject(a);
                        if (db.SaveChanges() > 0)
                        {
                            var listTS = Translate.GetList(new FilterParams() { ObjType = ObjType.Type2, ObjID = iid });
                            if (listTS != null && listTS.Count > 0)
                                Translate.DeleteByList(listTS);
                        }
                    }
                }
            }

        }
    }
}