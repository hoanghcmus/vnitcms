using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace VNITLibrary.VNITDatabase
{
    public partial class Category
    {
        public Category()
        {
        }
        public Category(int ID)
        {
            this.ID = ID;
        }

        /* public int ModuleID
         {
             get
             {
                 if ((this.ModuleReference.EntityKey != null))
                 {
                     return (int)this.ModuleReference.EntityKey.EntityKeyValues[0].Value;
                 }
                 return 0;
             }
             set
             {
                 if ((this.ModuleReference.EntityKey != null))
                 {
                     this.ModuleReference = null;
                 }
                 this.ModuleReference.EntityKey = new EntityKey("VNITDatabaseEntities.Modules", "ID", value);
             }
         } */

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

        public static List<Category> GetList(int parentId)
        {
            return GetAll().Where(o => o.ParentID == parentId).ToList();
        }
        public static List<Category> GetList(FilterParams fp)
        {
            IEnumerable<Category> t = from o in GetAll() select o;

            if (fp.ModuleId > 0)
                t = t.Where(o => o.ModuleID == fp.ModuleId);

            var key = fp.KeyWord.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                key = key.ToUnsigned().ToLower();
                t = t.Where(o => o.Title.ToUnsigned().ToLower().Contains(key) || o.Description.ToUnsigned().ToLower().Contains(key));
            }
            return t.ToList();
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

        public static string GetModuleName(int ModuleID)
        {
            Module md = Module.GetByID(ModuleID);
            if (md != null)
                return md.ModuleName;
            else
                return "";
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


        public static int DeleteByID(int id)
        {
            using (var DB = ConnectDB.Db())
            {
                var entity = DB.Categories.FirstOrDefault(o => o.ID == id);
                DB.DeleteObject(entity);
                return DB.SaveChanges();
            }
        }
    }
}
