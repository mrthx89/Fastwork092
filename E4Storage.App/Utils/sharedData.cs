using DevExpress.Data.Utils;
using E4Storage.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Utils
{
    public class sharedData
    {
        public static void saveAppConfig(AppSetting appConfig)
        {
            using (System.IO.StreamWriter myWriter = new System.IO.StreamWriter(System.IO.Path.Combine(Environment.CurrentDirectory, "System", "appConfig.json"), false))
            {
                try
                {
                    myWriter.AutoFlush = true;
                    myWriter.Write(Helper.JSONHelper.ToJSON(appConfig));
                    myWriter.Flush();
                }
                catch (Exception ex)
                {
                    Helper.MsgBoxHelper.MsgError("sharedData.saveAppConfig", ex);
                }
            }
        }

        public static AppSetting openAppConfig()
        {
            AppSetting appConfig = null;
            if (System.IO.File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "System", "appConfig.json")))
            {
                using (System.IO.StreamReader myReader = new System.IO.StreamReader(System.IO.Path.Combine(Environment.CurrentDirectory, "System", "appConfig.json")))
                {
                    try
                    {
                        appConfig = Helper.JSONHelper.FromJSON<AppSetting>(myReader.ReadToEnd());
                    }
                    catch (Exception ex)
                    {
                        Helper.MsgBoxHelper.MsgError("sharedData.openAppConfig", ex);
                    }
                }
            }
            return appConfig;
        }
    }
}
