using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
<<<<<<< HEAD:VNITLibrary/VNITObjects/Support.cs

namespace VNITLibrary.VNITDatabase
{
    public partial class Support
=======
using VNITLibrary.VNITDatabase;

namespace VNITLibrary
{
    public partial class SupportModel : BasePage
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d:VNITLibrary/VNITObjects/SupportModel.cs
    {
        public string createNewObjAndShow(string name, string phone)
        {
            string rString = string.Empty;
            using (var db = ConnectDB.Db())
            {
                var sp = new Support { Name = name, Phone = phone };
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
