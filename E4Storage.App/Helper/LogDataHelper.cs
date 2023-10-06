using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace E4Storage.App.Helper
{
    public class LogDataHelper
    {
        public static void SetupSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console() // Menyimpan log di konsol
                .WriteTo.File(Path.Combine(Environment.CurrentDirectory, "Log", "LogData.txt"), rollingInterval: RollingInterval.Day) // Menyimpan log ke file dengan rolling harian
                .CreateLogger();
        }

        public static void TulisLogInformation(string Message)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Information(Message);
        }

        public static void TulisLogInformation<T>(string Message, T Object)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Information<T>(Message, Object);
        }

        public static void TulisLogError(string Message)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Error(Message);
        }

        public static void TulisLogError<T>(string Message, T Object)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Error<T>(Message, Object);
        }

        public static void TulisLogError(Exception ex, string Message)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Error(ex, Message);
        }

        public static void TulisLogError<T>(Exception ex, string Message, T Object)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Error<T>(ex, Message, Object);
        }

        public static void TulisLogDebug(string Message)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Debug(Message);
        }

        public static void TulisLogDebug<T>(string Message, T Object)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Debug<T>(Message, Object);
        }

        public static void TulisLogVerbose(string Message)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Verbose(Message);
        }

        public static void TulisLogVerbose<T>(string Message, T Object)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Verbose<T>(Message, Object);
        }

        public static void TulisLogWarning(string Message)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Warning(Message);
        }

        public static void TulisLogWarning<T>(string Message, T Object)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Warning<T>(Message, Object);
        }

        public static void TulisLogFatal(string Message)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Fatal(Message);
        }

        public static void TulisLogFatal<T>(string Message, T Object)
        {
            if (!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            Log.Logger.Fatal<T>(Message, Object);
        }
    }
}
