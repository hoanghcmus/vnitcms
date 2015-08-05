using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using VNITLibrary.VNITDatabase;

namespace VNITLibrary
{
    public class ConnectDB
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["VNITDatabaseEntities"].ConnectionString;
            }
        }

        public static VNITDatabaseEntities Db()
        {
            return new VNITDatabaseEntities(ConnectionString);
        }
    }
}
