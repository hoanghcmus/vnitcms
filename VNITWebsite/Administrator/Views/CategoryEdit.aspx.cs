using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;
using VNITLibrary.VNITClasses;
using VNITLibrary.VNITObjects;

public partial class Administrator_Views_CategoryAddOrEdit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        drlModule.DataTextField = "ModuleName";
        drlModule.DataValueField = "ID";
        drlModule.DataSource = ModuleModel.GetList();
        drlModule.DataBind();
    }
}