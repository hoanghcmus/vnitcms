using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;
using VNITLibrary.VNITDatabase;

public partial class Administrator_Views_ArticleEdit : BasePage
{
    public int ID
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        SetUpEditorAndBrowseFileButton();
        if (!IsPostBack)
        {
            ID = Convert.ToInt32(Request.QueryString["ID"] ?? "0");
            if (ID != 0)
                ltrTitile.Text = "Chỉnh sửa bài viết";
            else ltrTitile.Text = "Thêm mới bài viết";
            InitControls();
        }
    }

    protected void SetUpEditorAndBrowseFileButton()
    {
        txtDetail.Language = "vi";
        txtDetail.BasePath = Constants.CKEditorBasePath;
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = Constants.CKFinderBasePath;
        _FileBrowser.SetupCKEditor(txtDetail);

    }

    protected void InitControls()
    {
        var lc = new List<Category>();
        Category.GetMultiLevelList(0, 0, ref lc, 0);
        LoadData_To_DrlTheLoai(lc);

        Article a = Article.GetByID(ID);
        if (a != null && a.ID > 0)
            AssignControlData(a);
        else
            if (ID != 0)
                Response.Redirect("/Administrator/Views/ArticleManager.aspx");
    }


    protected void LoadData_To_DrlTheLoai(List<Category> lc)
    {
        drlTheLoai.DataTextField = "Title";
        drlTheLoai.DataValueField = "ID";
        drlTheLoai.DataSource = lc;
        drlTheLoai.DataBind();
        drlTheLoai.Items.Insert(0, new ListItem("Chọn thể loại bài viết", "0"));
        DisableCurrentCatItem(ID.ToString());
    }

    protected void DisableCurrentCatItem(string ID)
    {
        var lc = new List<Category>();
        Category.GetMultiLevelList(Convert.ToInt32(ID), 0, ref lc, 0);

        for (int i = 0; i < drlTheLoai.Items.Count; i++)
        {
            if (!drlTheLoai.Items[i].Value.Equals("0") && drlTheLoai.Items[i].Value.Equals(ID))
            {
                drlTheLoai.Items[i].Attributes.Add("disabled", "disabled");
            }
            if (!ID.Equals("0") && lc != null && lc.Count > 0)
            {
                foreach (var li in lc)
                {
                    if (drlTheLoai.Items[i].Value.Equals(li.ID.ToString()))
                    {
                        drlTheLoai.Items[i].Attributes.Add("disabled", "disabled");
                    }
                }
            }
        }
    }

    protected void AssignControlData(Article a)
    {
        drlTheLoai.SelectedValue = a.CatID.ToString();
        drlStatus.SelectedValue = a.Status.ToString();

        AssignControlDataByLanguage(drlLanguage.SelectedValue, a);
        txtListImgs.Text = a.Figure;
    }

    protected void AssignControlDataByLanguage(string lang, Article a)
    {
        if (lang.Equals("vi"))
        {
            txtTitle.Text = a.Title;
            txtDescription.Text = a.Summary;
            txtDetail.Text = a.Detail;
        }
        else
        {
            var fp = new FilterParams()
            {
                ModuleId = 1,
                ObjType = ObjType.Type2,
                ObjID = a.ID,
                LangID = Language.GetIDByCode(lang)
            };

            fp.ObjField = "title";
            var tsForTitle = Translate.GetObject(fp);
            if (tsForTitle != null && tsForTitle.ID > 0)
                txtTitle.Text = tsForTitle.Translating;

            fp.ObjField = "summary";
            var tsForSummary = Translate.GetObject(fp);
            if (tsForSummary != null && tsForSummary.ID > 0)
                txtDescription.Text = tsForSummary.Translating;

            fp.ObjField = "detail";
            var tsForDetail = Translate.GetObject(fp);
            if (tsForDetail != null && tsForDetail.ID > 0)
                txtDetail.Text = tsForDetail.Translating;
        }

    }

    protected void SaveItem()
    {
        ServerMessage sm;
        var curUser = GlobalVariables.CurrentUser;
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        var a = DB.Articles.FirstOrDefault(i => i.ID == id);
        if (a == null)
        {
            a = new Article();
            a.CreteDdate = DateTime.Now.ToShortDateString();
            if (curUser != null && curUser.ID > 0)
            {
                a.Creator = curUser.User;
            }
            a.View = 0;
        }
        else
        {
            a.UpdateDate = DateTime.Now.ToShortDateString();
            if (curUser != null && curUser.ID > 0)
            {
                a.Updator = curUser.User;
            }
        }

        a.CatID = Convert.ToInt32(drlTheLoai.SelectedValue);
        a.Status = Convert.ToInt32(drlStatus.SelectedValue);

        String title = txtTitle.Text.Trim();
        String summary = txtDescription.Text.Trim();
        string detail = txtDetail.Text.Trim();

        if (drlLanguage.SelectedValue.Equals("vi"))
        {
            a.Title = title;
            a.Summary = summary;
            a.Detail = detail;
        }

        a.Figure = txtListImgs.Text.Trim();

        int ID = a.ID;
        if (ID <= 0)
            DB.AddToArticles(a);

        if (DB.SaveChanges() > 0)
        {
            var lc = new List<Category>();
            Category.GetMultiLevelList(0, a.CatID, ref lc, 0);
            LoadData_To_DrlTheLoai(lc);

            if (ID <= 0)
            {
                sm = new ServerMessage("Thêm mới bài viết thành công", ServerMessage.SuccessMessage);
                ltrCallBackFunction.Text = JsSerializer.Serialize(new ServerMessage("redirect", ServerMessage.InfoMessage, "", a.ID.ToString()));
            }
            else
            {
                sm = new ServerMessage("Đã cập nhật thông tin bài viết", ServerMessage.SuccessMessage);
                ltrCallBackFunction.Text = JsSerializer.Serialize(new ServerMessage("createImgBar", ServerMessage.InfoMessage));
            }

            SaveOrUpdateTranslate(drlLanguage.SelectedValue, a.ID, new List<KeyValuePair>() { new KeyValuePair() { Key = "title", Value = title }, new KeyValuePair() { Key = "summary", Value = summary }, new KeyValuePair() { Key = "detail", Value = detail } });
        }
        else
            sm = new ServerMessage("Có lỗi xảy ra", ServerMessage.DangerMessage);

        ltrServerMessage.Text = JsSerializer.Serialize(sm);
        AssignControlData(a);
    }

    protected void SaveOrUpdateTranslate(string lang, int curObjID, List<KeyValuePair> lstFieldsNameAndTranslation)
    {
        if (!lang.Equals("vi"))
        {
            var fp = new FilterParams()
            {
                ModuleId = 1,
                ObjType = ObjType.Type2,
                ObjID = curObjID,
                //ObjField = "tieude",
                LangID = Language.GetIDByCode(lang)
            };
            for (int i = 0; i < lstFieldsNameAndTranslation.Count; i++)
            {
                fp.ObjField = lstFieldsNameAndTranslation.ElementAt(i).Key;
                var ts = Translate.GetObject(fp);
                if (ts == null)
                    ts = new Translate();
                else ts = DB.Translates.FirstOrDefault(o => o.ID == ts.ID);

                ts.LangID = fp.LangID;
                ts.Type = fp.ObjType;
                ts.ModuleID = fp.ModuleId;
                ts.ModuleItemID = fp.ObjID;
                ts.ModuleItemField = fp.ObjField;
                ts.Translating = lstFieldsNameAndTranslation.ElementAt(i).Value;

                if (ts.ID <= 0)
                {
                    DB.AddToTranslates(ts);
                }

                DB.SaveChanges();
            }
        }
        else return;
    }

    protected void btnSaveItem_Click(object sender, EventArgs e)
    {
        SaveItem();
    }
    protected void ResetForm()
    {
        txtTitle.Text = String.Empty;
        txtDescription.Text = String.Empty;
        txtFigure.Text = String.Empty;
        txtDetail.Text = String.Empty;
    }
    protected void drlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ID = Convert.ToInt32(Request.QueryString["ID"] ?? "0");
        Article a = Article.GetByID(ID);
        if (a != null && a.ID > 0)
            AssignControlData(a);
        ltrCallBackFunction.Text = JsSerializer.Serialize(new ServerMessage("createImgBar", ServerMessage.InfoMessage));
    }
}