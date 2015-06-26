using System;
using System.Collections.Generic;
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
        LoadData_To_DrlTheLoai(CategoryModel.GetMultiLevelList(id));
        LoadData_To_DrlModule(ModuleModel.GetList());
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
}