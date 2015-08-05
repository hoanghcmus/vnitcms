using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
<<<<<<< HEAD
using VNITLibrary.VNITDatabase;
=======
>>>>>>> 7648eca1a6faf9b6f177b05455b8a0369d075e3d

namespace VNITLibrary
{
    class SysConfig
    {
        public static List<ConfigModel> GetAll()
        {
            var t = new List<ConfigModel>();
            return t;
        }
        private static string GetStringValue(int configID)
        {
            return "";
        }

        private static void UpdateConfig(int configID, object value)
        {
            using (var db = ConnectDB.Db())
            {
                var t = db.Configs.FirstOrDefault(o => o.Id == configID);
                if (t == null) return;
                t.ConfigValue = value.ToString();
                db.SaveChanges();
            }
        }
        public static int MaxUploadSize
        {
            get { return 1050000; }
        }
        public static MailAddress FromMailAddress
        {
            get { return new MailAddress("no-reply@" + WebsiteDomain, "[" + WebsiteName + "]"); }
        }
        public static string WebsiteTitle
        {
            get { return GetStringValue(1); }
            set { UpdateConfig(1, value); }
        }

        public static string WebsiteKeyword
        {
            get { return GetStringValue(2); }
            set { UpdateConfig(2, value); }
        }

        public static string WebsiteDescription
        {
            get { return GetStringValue(3); }
            set { UpdateConfig(3, value); }
        }
        public static string DefaultImagePath
        {
            get { return GetStringValue(4); }
            set { UpdateConfig(4, value); }
        }
        public static string WebsiteName
        {
            get { return GetStringValue(5); }
            set { UpdateConfig(5, value); }
        }
        public static string WebsiteDomain
        {
            get { return GetStringValue(6); }
            set { UpdateConfig(6, value); }
        }
    }
}
