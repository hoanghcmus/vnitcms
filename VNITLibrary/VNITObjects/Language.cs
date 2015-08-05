using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary.VNITDatabase
{
    public partial class Language
    {
        public static List<Language> GetAll()
        {
            using (var db = ConnectDB.Db())
            {
                return db.Languages.ToList();
            }
        }

        public static Language GetByID(int id)
        {
            return GetAll().Where(o => o.ID == id).FirstOrDefault();
        }
        public static int GetIDByCode(string code)
        {
            Language lg = GetAll().Where(o => o.LangCode.Trim().Equals(code.Trim())).FirstOrDefault();
            if (lg != null && lg.ID > 0)
                return lg.ID;
            else return 0;
        }
    }
}
