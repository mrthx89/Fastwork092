using EM4.App.Helper;
using EM4.App.Model;
using EM4.App.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM4.App.Utils
{
    public class Constant
    {
        public static string NamaApplikasi = "EM4 Storage";
        public static AppSetting appSetting = null;
        public static TUser UserLogin = null;
        public static LayoutsHelper layoutsHelper = new LayoutsHelper(Path.Combine(Environment.CurrentDirectory, "System", "Layouts"));
    }
}
