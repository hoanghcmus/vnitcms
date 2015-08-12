﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary.VNITDatabase
{
    public partial class Menu
    {
        public static List<Menu> GetAll()
        {
            using (var db = ConnectDB.Db())
            {
                return db.Menus.ToList();
            }
        }

        public static Menu GetByID(int id)
        {
            return GetAll().Where(o => o.ID == id).FirstOrDefault();
        }

        public static List<Menu> GetList(int parentId)
        {
            return GetAll().Where(o => o.ParentID == parentId).ToList();
        }

        public static List<Menu> GetList(FilterParams fp)
        {
            IEnumerable<Menu> t = from o in GetAll() select o;

            //if (fp.ModuleId > 0)
            //    t = t.Where(o => o.ModuleID == fp.ModuleId);

            var key = fp.KeyWord.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                key = key.ToUnsigned().ToLower();
                t = t.Where(o => o.Title.ToUnsigned().ToLower().Contains(key) || o.Description.ToUnsigned().ToLower().Contains(key));
            }
            return t.ToList();
        }

        public static List<Menu> GetMultiLevelList(int parentID, int excludeItemId, ref  List<Menu> lc, int count)
        {
            var categories = GetAll().Where(o => o.ParentID == parentID);
            if (categories.Count() != 0)
            {
                foreach (var catItem in categories)
                {
                    var c = new Menu();
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

        public static int DeleteByID(int id)
        {
            using (var DB = ConnectDB.Db())
            {
                var entity = DB.Menus.FirstOrDefault(o => o.ID == id);
                DB.DeleteObject(entity);
                return DB.SaveChanges();
            }
        }
    }
}
