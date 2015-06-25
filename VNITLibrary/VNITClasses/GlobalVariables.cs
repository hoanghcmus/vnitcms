using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using VNITLibrary.VNITDatabase;

namespace VNITLibrary.VNITClasses
{
    public class GlobalVariables
    {
        public static UserLogin CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["CurrentUser"] == null)
                    return null;

                return (UserLogin)HttpContext.Current.Session["CurrentUser"];
            }
            set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }
    }
}
