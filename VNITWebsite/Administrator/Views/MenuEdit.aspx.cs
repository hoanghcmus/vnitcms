using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VNITLibrary;

public partial class Administrator_Views_MenuEdit : BasePage
{
    public int catID
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            catID = Convert.ToInt32(Request.QueryString["ID"] ?? "0");
            if (catID != 0)
                ltrTitile.Text = "Chỉnh sửa menu";
            else ltrTitile.Text = "Thêm menu mới";

            InitControls();
        }
    }

    protected void InitControls()
    {
        //Load data for Parent menu dropdownlist
        var lc = new List<VNITLibrary.VNITDatabase.Menu>();
        VNITLibrary.VNITDatabase.Menu.GetMultiLevelList(0, catID, ref lc, 0);
        LoadData_To_DrlTheLoai(lc);

        //Load data for link type dropdownlist
        drlLinkType.DataSource = Link.GetLinkTypes();
        drlLinkType.DataValueField = "OptionValue";
        drlLinkType.DataTextField = "OptionName";
        drlLinkType.DataBind();
        drlLinkType.Items.Insert(0, new ListItem("-- Chọn loại liên kết --", "0"));

        //Load data for Parent menu dropdownlist
        drlPostion.DataSource = Link.GetPositionsStatic();
        drlPostion.DataValueField = "OptionValue";
        drlPostion.DataTextField = "OptionName";
        drlPostion.DataBind();
        drlPostion.Items.Insert(0, new ListItem("-- Chọn vị trí hiển thị --", "0"));
    }

    protected void LoadData_To_DrlTheLoai(List<VNITLibrary.VNITDatabase.Menu> lc)
    {
        drlTheLoai.DataTextField = "Title";
        drlTheLoai.DataValueField = "ID";
        drlTheLoai.DataSource = lc;
        drlTheLoai.DataBind();

        drlTheLoai.Items.Insert(0, new ListItem("-- Chọn thể loại cha --", "0"));
        DisableCurrentCatItem(catID.ToString());
    }

    protected void DisableCurrentCatItem(string catID)
    {
        var lc = new List<VNITLibrary.VNITDatabase.Menu>();
        VNITLibrary.VNITDatabase.Menu.GetMultiLevelList(Convert.ToInt32(catID), 0, ref lc, 0);

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
    }

}