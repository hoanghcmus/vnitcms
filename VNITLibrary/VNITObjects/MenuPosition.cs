using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary.VNITDatabase
{
    public partial class MenuPosition
    {
        public static List<MenuPosition> GetList()
        {
            using (var db = ConnectDB.Db())
            {
                return db.MenuPositions.ToList();
            }
        }
        public static MenuPosition GetByID(int MenuID)
        {
            return GetList().Where(o => o.ID == MenuID).FirstOrDefault();
        }
    }
}
