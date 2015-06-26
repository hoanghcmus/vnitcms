using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;

public partial class Administrator_Views_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // CheckLogin();
        //ltrUserProfile.Text = StringUltil.UCFirst(GlobalVariables.CurrentUser.User.ToString());
    }
    protected void HLLanguage_Click(object sender, EventArgs e)
    {
        LinkButton lbt = sender as LinkButton;
        SetSessionForlanguage(lbt.CommandArgument);
        Response.Redirect(Request.Url.ToString());
    }
    protected void SetSessionForlanguage(string sLang)
    {
        Session["lang"] = sLang;
    }
    protected void CheckLogin()
    {
        if (GlobalVariables.CurrentUser == null)
            Response.Redirect("/Administrator/Views/Login.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.RawUrl));
    }
    protected void btnSingOut_Click(object sender, EventArgs e)
    {
        GlobalVariables.CurrentUser = null;
        Response.Redirect("/Administrator/Views/Login.aspx");
    }
}