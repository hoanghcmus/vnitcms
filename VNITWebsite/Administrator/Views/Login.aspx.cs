using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;
<<<<<<< HEAD
using VNITLibrary.VNITDatabase;
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d

public partial class Administrator_Views_Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        var user = UserLoginModel.FindUser(txtUser.Text.Trim(), txtPass.Text.Trim());
        if (user != null)
        {
            GlobalVariables.CurrentUser = user;
            var returnUrl = Request.QueryString["ReturnUrl"];
            Response.Redirect(returnUrl ?? "/Administrator/Views/Default.aspx");
        }
        else
        {
            ErrorMess.Visible = true;
        }
    }
}