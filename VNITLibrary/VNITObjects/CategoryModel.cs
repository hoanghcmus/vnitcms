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

        public static Category GetByID(int id)
        {
            return GetAll().Where(o => o.ID == id).FirstOrDefault();
        }

        public static List<Category> GetMultiLevelList(int parentID, int excludeItemId, ref  List<Category> lc, int count)
        {
            var categories = GetAll().Where(o => o.ParentID == parentID);
            if (categories.Count() != 0)
            {
                foreach (var catItem in categories)
                {
                    var c = new Category();
                    c.ID = catItem.ID;
                    c.Title = catItem.Title;
                    if (HasChild(catItem.ID))
                    {
                        c.Title = GetMenuLevelString(count) + c.Title;
                        lc.Add(c);
                        ++count;
                        GetMultiLevelList(catItem.ID, excludeItemId, ref lc, count);
                        --count;
                    }
                    else
                    {
                        if (catItem.ParentID != null && catItem.ParentID > 0)
                        {
                            c.Title = GetMenuLevelString(count) + c.Title;
                            lc.Add(c);
                        }
                        else
                            lc.Add(c);
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

        public static int GetModuleID(Category c)
        {
            return (int)c.ModuleReference.EntityKey.EntityKeyValues[0].Value;
        }
        public static int GetModuleID(int id)
        {
            return (int)GetAll().Where(o => o.ID == id).FirstOrDefault().ModuleReference.EntityKey.EntityKeyValues[0].Value;
        }
       
    }
}
