using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using VNITLibrary.VNITClasses;
using VNITLibrary.VNITDatabase;

namespace VNITLibrary.VNITObjects
{
    public partial class Support : BasePage
    {
        public string createNewObjAndShow(string name, string phone)
        {
            string rString = string.Empty;
            using (var db = DB)
            {
                var sp = new VNITDatabase.Support { Name = name, Phone = phone };
                db.AddToSupports(sp);
                db.SaveChanges();

                var query = from s in db.Supports
                            orderby s.Name
                            select s;

                foreach (var item in query)
                {
                    rString += item.Name.ToString() + " " + item.Phone + "\n";
                }
            }
            return rString;
        }

        public void getList(VNITDatabaseEntities db)
        {
        }
    }
}
