using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNITLibrary.VNITClasses
{
    public class Culture
    {
        public static string GetCulture(string sLang)
        {
            if (sLang.ToLower().CompareTo("vi") == 0)
            {
                return "vi-VN";
            }
            if (sLang.ToLower().CompareTo("en") == 0)
            {
                return "en-US";
            }
            if (sLang.ToLower().CompareTo("ru") == 0)
            {
                return "ru-RU";
            }
            return "vi-VN";
        }
    }
}
