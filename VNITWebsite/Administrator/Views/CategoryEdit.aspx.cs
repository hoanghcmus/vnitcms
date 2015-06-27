using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;
using VNITLibrary.VNITDatabase;

public partial class CategoryEdit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitControls();
        }
    }

    protected void InitControls()
    {
        var id = Convert.ToInt32(Request.QueryString["ID"]);

        var lc = new List<Category>();
        CategoryModel.GetMultiLevelList(0, id, ref lc, 0);
        LoadData_To_DrlTheLoai(lc);

        LoadData_To_DrlModule(ModuleModel.GetList());

        Category c = CategoryModel.GetByID(id);
        if (c != null)
            AssignControlData(c);
    }

    protected void LoadData_To_DrlModule(List<Module> lm)
    {
        drlModule.DataTextField = "ModuleName";
        drlModule.DataValueField = "ID";
        drlModule.DataSource = lm;
        drlModule.DataBind();
    }

    protected void LoadData_To_DrlTheLoai(List<Category> lc)
    {
        drlTheLoai.DataTextField = "Title";
        drlTheLoai.DataValueField = "ID";
        drlTheLoai.DataSource = lc;
        drlTheLoai.DataBind();
    }

    protected void AssignControlData(Category c)
    {
        drlTheLoai.SelectedValue = c.ParentID.ToString();
        drlModule.SelectedValue = CategoryModel.GetModuleID(c).ToString();

        txtTitle.Text = c.Title;
        txtDescription.Text = c.Description;
        txtListImgs.Text = c.Figure;
    }

    protected void SaveItem()
    {
        int id = Convert.ToInt32(Request.QueryString["ID"]);
        var c = DB.Categories.FirstOrDefault(i => i.ID == id);
        if (c == null)
            c = new Category();

        c.ParentID = drlTheLoai.SelectedIndex;
        c.Title = txtTitle.Text.Trim();
        c.Description = txtDescription.Text.Trim();
        c.Figure = txtListImgs.Text.Trim();

        if (c.ID <= 0)
            DB.AddToCategories(c);
        DB.SaveChanges();

        AssignControlData(c);
    }
    protected void btnSaveItem_Click(object sender, EventArgs e)
    {
        SaveItem();
    }
}