using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNITLibrary.VNITDatabase;

namespace VNITLibrary
{
    public partial class ModuleModel : BasePage
    {
        public static List<Module> GetList()
        {
            using (var db = ConnectDB.Db())
            {
                return db.Modules.ToList();
            }
        }
    }
}
