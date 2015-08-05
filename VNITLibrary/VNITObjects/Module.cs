using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNITLibrary.VNITDatabase;

namespace VNITLibrary.VNITDatabase
{
    public partial class Module
    {
        public static List<Module> GetList()
        {
            using (var db = ConnectDB.Db())
            {
                return db.Modules.ToList();
            }
        }
        public static Module GetByID(int ModuleID)
        {
            return GetList().Where(o => o.ID == ModuleID).FirstOrDefault();
        }
    }
}
