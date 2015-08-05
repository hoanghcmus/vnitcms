using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VNITLibrary.VNITDatabase
{
    public partial class Article
    {
        public int CatID
        {
            get
            {
                if ((this.CategoryReference.EntityKey != null))
                {
                    return (int)this.CategoryReference.EntityKey.EntityKeyValues[0].Value;
                }
                return 0;
            }
            set
            {
                if ((this.CategoryReference.EntityKey != null))
                {
                    this.CategoryReference = null;
                }
                this.CategoryReference.EntityKey = new EntityKey("VNITDatabaseEntities.Categories", "ID", value);
            }

        }
        public static List<Article> GetAll()
        {
            using (var db = ConnectDB.Db())
            {
                return db.Articles.ToList();
            }
        }

        public static Article GetByID(int id)
        {
            return GetAll().Where(o => o.ID == id).FirstOrDefault();
        }

        public static List<Article> GetList(int catID)
        {
            return GetAll().Where(o => o.CatID == catID).ToList();
        }
        public static List<Article> GetList(FilterParams fp)
        {
            IEnumerable<Article> t = from o in GetAll() select o;

            if (fp.CatId > 0)
                t = t.Where(o => o.CatID == fp.CatId);
            if (fp.Status >= 0)
                t = t.Where(o => o.Status == fp.Status);

            var key = fp.KeyWord.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                key = key.ToUnsigned().ToLower();
                t = t.Where(o => o.Title.ToUnsigned().ToLower().Contains(key) || o.Summary.ToUnsigned().ToLower().Contains(key));
            }
            return t.ToList();
        }
        public static int DeleteByID(int id)
        {
            using (var DB = ConnectDB.Db())
            {
                var entity = DB.Articles.FirstOrDefault(o => o.ID == id);
                DB.DeleteObject(entity);
                return DB.SaveChanges();
            }
        }
    }
}
