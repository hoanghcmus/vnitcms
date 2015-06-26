using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using VNITLibrary.VNITDatabase;

namespace VNITLibrary
{
    public partial class CategoryModel : BasePage
    {
        public static List<Category> GetAll()
        {
            using (var db = ConnectDB.Db())
            {
                return db.Categories.ToList();
            }
        }

        public static List<Category> GetMultiLevelList(int parentID, int excludeItemId, DropDownList drl)
        {
            var categories = GetAll().Where(o => o.ParentID == parentID && o.ID != excludeItemId);
            if (categories.Count() != 0)
            {
                foreach (var catItem in categories)
                {
                    if (HasChild(catItem.ID))
                    {
                        drl.Items.Add(new ListItem(GetMenuLevelString(count) + ShowTitle(theLoai.TieuDe_Vn), theLoai.ID.ToString()));
                        count += 1;
                        GetMultiLevelList(theLoai.ID, count);
                        count -= 1;
                    }
                    else
                    {
                        if (theLoai.IDParent != null && theLoai.IDParent > 0)
                            drl.Items.Add(new ListItem(GetMenuLevelString(count) + ShowTitle(theLoai.TieuDe_Vn), theLoai.ID.ToString()));
                        else
                            drl.Items.Add(new ListItem(ShowTitle(theLoai.TieuDe_Vn), theLoai.ID.ToString()));

                    }
                }
            }
            return null;
        }

        public static bool HasChild(int catID)
        {
            var lc = GetAll().Where(o => o.ID == catID);
            if (lc.Count() != 0)
                return true;
            return false;
        }

        public static string GetMenuLevelString(int lenght)
        {
            string ls = String.Empty;
            for (int i = 0; i < lenght; i++)
                ls += "- ";
            return ls;
        }

    }
}
