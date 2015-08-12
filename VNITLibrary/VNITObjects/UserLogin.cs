using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary.VNITDatabase
{
    public partial class UserLogin
    {
        public static UserLogin FindUser(string user, string pass)
        {
            var encPass = StringUltil.GetMd5Hash(pass);
            using (var db = ConnectDB.Db())
            {
                var t = db.UserLogins.Where(o => o.User == user && o.Pass == encPass);
                return t.FirstOrDefault();
            }
        }
    }
}
