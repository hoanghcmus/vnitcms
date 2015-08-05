using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
<<<<<<< HEAD
using System.Web.Script.Serialization;
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;
using VNITLibrary.VNITDatabase;

public partial class CategoryEdit : BasePage
{
<<<<<<< HEAD
    public int catID
    {
        get;
        set;
    }
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
<<<<<<< HEAD
            catID = Convert.ToInt32(Request.QueryString["ID"] ?? "0");
            if (catID != 0)
                ltrTitile.Text = "Chỉnh sửa thể loại";
            else ltrTitile.Text = "Thêm mới thể loại";
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
            InitControls();
        }
    }

    protected void InitControls()
    {
<<<<<<< HEAD
        var lc = new List<Category>();
        Category.GetMultiLevelList(0, catID, ref lc, 0);
        LoadData_To_DrlTheLoai(lc);

        LoadData_To_DrlModule(Module.GetList());

        Category c = Category.GetByID(catID);
        if (c != null)
            AssignControlData(c);
        else
            if (catID != 0)
                Response.Redirect("/Administrator/Views/CategoryManager.aspx");
=======
        var id = Convert.ToInt32(Request.QueryString["ID"]);

        var lc = new List<Category>();
        CategoryModel.GetMultiLevelList(0, id, ref lc, 0);
        LoadData_To_DrlTheLoai(lc);

        LoadData_To_DrlModule(ModuleModel.GetList());

        Category c = CategoryModel.GetByID(id);
        if (c != null)
            AssignControlData(c);
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
    }

    protected void LoadData_To_DrlModule(List<Module> lm)
    {
        drlModule.DataTextField = "ModuleName";
        drlModule.DataValueField = "ID";
        drlModule.DataSource = lm;
        drlModule.DataBind();
<<<<<<< HEAD
        drlModule.Items.Insert(0, new ListItem("Chọn loại module", "0"));
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
    }

    protected void LoadData_To_DrlTheLoai(List<Category> lc)
    {
        drlTheLoai.DataTextField = "Title";
        drlTheLoai.DataValueField = "ID";
        drlTheLoai.DataSource = lc;
        drlTheLoai.DataBind();
<<<<<<< HEAD
        drlTheLoai.Items.Insert(0, new ListItem("Chọn thể loại cha", "0"));
        DisableCurrentCatItem(catID.ToString());
    }

    protected void DisableCurrentCatItem(string catID)
    {
        var lc = new List<Category>();
        Category.GetMultiLevelList(Convert.ToInt32(catID), 0, ref lc, 0);

        for (int i = 0; i < drlTheLoai.Items.Count; i++)
        {
            if (!drlTheLoai.Items[i].Value.Equals("0") && drlTheLoai.Items[i].Value.Equals(catID))
            {
                drlTheLoai.Items[i].Attributes.Add("disabled", "disabled");
            }
            if (!catID.Equals("0") && lc != null && lc.Count > 0)
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
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
    }

    protected void AssignControlData(Category c)
    {
        drlTheLoai.SelectedValue = c.ParentID.ToString();
<<<<<<< HEAD
        drlModule.SelectedValue = c.ModuleID.ToString();
        AssignControlDataByLanguage(drlLanguage.SelectedValue, c);

        txtListImgs.Text = c.Figure;
    }

    protected void AssignControlDataByLanguage(string lang, Category c)
    {
        if (lang.Equals("vi"))
        {
            txtTitle.Text = c.Title;
            txtDescription.Text = c.Description;
        }
        else
        {
            var fp = new FilterParams()
            {
                ModuleId = 1,
                ObjType = ObjType.Type1,
                ObjID = c.ID,
                LangID = Language.GetIDByCode(lang)
            };

            fp.ObjField = "title";
            var tsForTitle = Translate.GetObject(fp);
            if (tsForTitle != null && tsForTitle.ID > 0)
                txtTitle.Text = tsForTitle.Translating;

            fp.ObjField = "description";
            var tsForDescription = Translate.GetObject(fp);
            if (tsForDescription != null && tsForDescription.ID > 0)
                txtDescription.Text = tsForDescription.Translating;
        }

    }

    protected void SaveItem()
    {
        ServerMessage sm;
=======
        drlModule.SelectedValue = CategoryModel.GetModuleID(c).ToString();

        txtTitle.Text = c.Title;
        txtDescription.Text = c.Description;
        txtListImgs.Text = c.Figure;
    }

    protected void SaveItem()
    {
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        var c = DB.Categories.FirstOrDefault(i => i.ID == id);
        if (c == null)
            c = new Category();

<<<<<<< HEAD
        c.ModuleID = Convert.ToInt32(drlModule.SelectedValue);
        c.ParentID = Convert.ToInt32(drlTheLoai.SelectedValue);

        String title = txtTitle.Text.Trim();
        String description = txtDescription.Text.Trim();

        if (drlLanguage.SelectedValue.Equals("vi"))
        {
            c.Title = title;
            c.Description = description;
        }

        c.Figure = txtListImgs.Text.Trim();

        int catID = c.ID;
        if (catID <= 0)
            DB.AddToCategories(c);

        if (DB.SaveChanges() > 0)
        {
            var lc = new List<Category>();
            Category.GetMultiLevelList(0, catID, ref lc, 0);
            LoadData_To_DrlTheLoai(lc);

            if (catID <= 0)
            {
                sm = new ServerMessage("Thêm mới thể loại thành công", ServerMessage.SuccessMessage);
                ltrCallBackFunction.Text = JsSerializer.Serialize(new ServerMessage("redirect", ServerMessage.InfoMessage, "", c.ID.ToString()));
            }
            else
            {
                sm = new ServerMessage("Đã cập nhật thông tin thể loại", ServerMessage.SuccessMessage);
                ltrCallBackFunction.Text = JsSerializer.Serialize(new ServerMessage("createImgBar", ServerMessage.InfoMessage));
            }

            SaveOrUpdateTranslate(drlLanguage.SelectedValue, c.ID, new List<KeyValuePair>() { new KeyValuePair() { Key = "title", Value = title }, new KeyValuePair() { Key = "description", Value = description } });
        }
        else
            sm = new ServerMessage("Có lỗi xảy ra", ServerMessage.DangerMessage);

        ltrServerMessage.Text = JsSerializer.Serialize(sm);
        AssignControlData(c);
    }

    protected void SaveOrUpdateTranslate(string lang, int curObjID, List<KeyValuePair> lstFieldsNameAndTranslation)
    {
        if (!lang.Equals("vi"))
        {
            var fp = new FilterParams()
            {
                ModuleId = 1,
                ObjType = ObjType.Type1,
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

    protected int getLangID(string code)
    {
        return Language.GetIDByCode(code);
    }
=======
        c.ParentID = drlTheLoai.SelectedIndex;
        c.Title = txtTitle.Text.Trim();
        c.Description = txtDescription.Text.Trim();
        c.Figure = txtListImgs.Text.Trim();

        if (c.ID <= 0)
            DB.AddToCategories(c);
        DB.SaveChanges();

        AssignControlData(c);
    }
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
    protected void btnSaveItem_Click(object sender, EventArgs e)
    {
        SaveItem();
    }
<<<<<<< HEAD
    protected void ResetForm()
    {
        txtTitle.Text = "";
        txtDescription.Text = "";
        txtFigure.Text = "";
    }
    protected void drlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        catID = Convert.ToInt32(Request.QueryString["ID"] ?? "0");
        Category c = Category.GetByID(catID);
        if (c != null)
            AssignControlData(c);
        ltrCallBackFunction.Text = JsSerializer.Serialize(new ServerMessage("createImgBar", ServerMessage.InfoMessage));
    }
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d
}