using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary.VNITObjects;

public partial class Website_Views_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SupportModel sp = new SupportModel();
        //string chuoi = sp.createNewObjAndShow("Nguyễn Ngọc Hoàng", "1234567890");
        //demo.Text = chuoi;
    }
}