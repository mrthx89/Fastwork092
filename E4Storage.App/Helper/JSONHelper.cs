using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Helper
{
    public class JSONHelper
    {
        private static IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
        public static string ToJSON(object Obj)
        {
            try
            {
                timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                return JsonConvert.SerializeObject(Obj, Newtonsoft.Json.Formatting.Indented, timeFormat);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static T FromJSON<T>(string JSON)
        {
            try
            {
                timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                return JsonConvert.DeserializeObject<T>(JSON, timeFormat);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static string ToJSON(object Obj, string dateFormat)
        {
            try
            {
                timeFormat.DateTimeFormat = dateFormat;
                return JsonConvert.SerializeObject(Obj, Newtonsoft.Json.Formatting.Indented, timeFormat);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static T FromJSON<T>(string JSON, string dateFormat)
        {
            try
            {
                timeFormat.DateTimeFormat = dateFormat;
                return JsonConvert.DeserializeObject<T>(JSON, timeFormat);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static T CloneObject<T>(object Obj)
        {
            try
            {
                return FromJSON<T>(ToJSON(Obj));
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
