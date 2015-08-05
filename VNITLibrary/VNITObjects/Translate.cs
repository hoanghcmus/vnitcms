using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VNITLibrary.VNITDatabase
{
    public partial class Translate
    {
        public int LangID
        {
            get
            {
                if ((this.LanguageReference.EntityKey != null))
                {
                    return (int)this.LanguageReference.EntityKey.EntityKeyValues[0].Value;
                }
                return 0;
            }
            set
            {
                if ((this.LanguageReference.EntityKey != null))
                {
                    this.LanguageReference = null;
                }
                this.LanguageReference.EntityKey = new EntityKey("VNITDatabaseEntities.Languages", "ID", value);
            }
        }
        public int ModuleID
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
        }

        public static List<Translate> GetAll()
        {
            using (var db = ConnectDB.Db())
            {
                return db.Translates.ToList();
            }
        }

        public static Translate GetByID(int id)
        {
            return GetAll().Where(o => o.ID == id).FirstOrDefault();
        }
        public static List<Translate> GetList(FilterParams fp)
        {
            IEnumerable<Translate> t = from o in GetAll() select o;

            if (!String.IsNullOrEmpty(fp.ObjType))
                t = t.Where(o => o.Type.ToUnsigned().ToLower().Contains(fp.ObjType.ToUnsigned().ToLower()));

            if (fp.ObjID > 0)
                t = t.Where(o => o.ModuleItemID == fp.ObjID);

            if (!String.IsNullOrEmpty(fp.ObjField))
                t = t.Where(o => o.ModuleItemField.ToUnsigned().ToLower().Contains(fp.ObjField.ToUnsigned().ToLower()));

            if (fp.LangID > 0)
                t = t.Where(o => o.LangID == fp.LangID);

            return t.ToList();
        }
        public static void DeleteByList(List<Translate> listTS)
        {
            if (listTS != null && listTS.Count > 0)
            {
                for (int i = 0; i < listTS.Count; i++)
                {
                    using (var db = ConnectDB.Db())
                    {
                        int id = listTS.ElementAt(i).ID;
                        var ts = db.Translates.FirstOrDefault(o => o.ID == id);
                        db.DeleteObject(ts);
                        db.SaveChanges();
                    }
                }
            }
        }


        public static Translate GetObject(FilterParams fp)
        {
            return GetList(fp).FirstOrDefault();
        }

    }
}
