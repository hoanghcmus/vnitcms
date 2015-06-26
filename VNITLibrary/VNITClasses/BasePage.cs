using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Web.UI;
using VNITLibrary.VNITDatabase;

namespace VNITLibrary
{
    public class BasePage : Page
    {
        protected VNITDatabaseEntities DB = ConnectDB.Db();
        protected JavaScriptSerializer JsSerializer = new JavaScriptSerializer();

        protected override void InitializeCulture()
        {
            string sLang = Convert.ToString(Session["lang"]);
            string culture = VNITLibrary.Culture.GetCulture(sLang);
            /*** 
             * Set Culture for current Thread
             ***/
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }
        protected void CheckLogin()
        {
        }
    }
}
