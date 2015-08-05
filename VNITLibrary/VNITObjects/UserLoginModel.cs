using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VNITLibrary;
using VNITLibrary.VNITDatabase;

<<<<<<< HEAD:VNITLibrary/VNITObjects/UserLogin.cs
namespace VNITLibrary.VNITDatabase
{
    public partial class UserLogin
=======
namespace VNITLibrary
{
    public partial class UserLoginModel : BasePage
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d:VNITLibrary/VNITObjects/UserLoginModel.cs
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
