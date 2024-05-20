using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using E4Storage.App.Helper;
using E4Storage.App.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace E4Storage.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] iProcess = null;
            try
            {
                Helper.LogDataHelper.SetupSerilog();
                Helper.LogDataHelper.TulisLogInformation("Application start ...");

                initFolders();

                if (System.IO.File.Exists(Path.Combine(Environment.CurrentDirectory, "System", "appConfig.json")))
                {
                    Constant.appSetting = JSONHelper.FromJSON<Model.AppSetting>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "System", "appConfig.json")));
                    if ((Constant.appSetting.Theme == null || Constant.appSetting.Theme.Length == 0))
                        Constant.appSetting.Theme = "Office 2016 Colorful";
                }
                if ((Constant.appSetting == null))
                    Constant.appSetting = new Model.AppSetting
                    {
                        KoneksiString = ConfigurationManager.ConnectionStrings["E4Storage"].ConnectionString,
                        Theme = "Office 2016 Colorful"
                    };

                DevExpress.XtraEditors.WindowsFormsSettings.LoadApplicationSettings();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                DevExpress.UserSkins.BonusSkins.Register();
                SkinManager.EnableFormSkins();
                SkinManager.EnableMdiFormSkins();
                
                SetSkin(Constant.appSetting.Theme);
                sharedData.saveAppConfig(Constant.appSetting);

                // Set Tablet Mode
                var fontSize = 9.75F;
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Segoe UI", fontSize);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = new Font("Segoe UI", fontSize);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultPrintFont = new Font("Segoe UI", fontSize);

                // Change current culture
                CultureInfo culture;
                culture = CultureInfo.CreateSpecificCulture("En-US");
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
                iProcess = PrevInstance();
                if (iProcess.Count() > 1)
                {
                    var Question = MsgBoxHelper.MsgQuestionYesNo("mdlPublic.Main", $"Applikasi {Application.ProductName} sudah berjalan. Ingin menutup Applikasi sebelumnya?");
                    if (Question == DialogResult.Yes)
                    {
                        foreach (var Obj in iProcess)
                        {
                            if (Obj.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                            {
                                try
                                {
                                    if (!Obj.HasExited)
                                        Obj.Kill();
                                }
                                catch (Exception ex)
                                {
                                    MsgBoxHelper.MsgError("mdlPublic.Main" + ".CekInstance.ObjKill", ex);
                                }
                            }
                        }
                    }
                    StartUp();
                }
                else
                    StartUp();
            }
            catch (Exception ex)
            {
                LogDataHelper.TulisLogError(ex, "Error Log : " + ex.Message);
            }
            finally
            {
                Helper.LogDataHelper.TulisLogInformation("Application finish ...");
            }
        }

        private static void StartUp()
        {
            try
            {
                initDB();
                Application.Run(new UI.frmMain());
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError("mdlPublic.StartUp", ex);
            }
        }

        public static void SetSkin(string SelectedTheme)
        {
            SetSkinName(SelectedTheme);
        }

        private static Process[] PrevInstance()
        {
            var procs = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Where(m => m.MainModule.FileName.ToLower() == Application.ExecutablePath.ToLower()).ToArray();
            return procs;
        }

        private static void SetSkinName(string SkinName)
        {
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SkinName = SkinName;
            UserLookAndFeel.Default.SetSkinStyle(SkinName);
            Application.DoEvents();
        }

        private static void initFolders()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "System")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "System"));
            }
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "System", "Layouts")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "System", "Layouts"));
            }
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Report")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Report"));
            }
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Log")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Log"));
            }
        }

        private static void initDB()
        {
            try
            {
                // Buat mdf baru jika tidak ada
                string path = AppDomain.CurrentDomain.BaseDirectory; // Direktori aplikasi
                AppDomain.CurrentDomain.SetData("DataDirectory", path);
                Database.SetInitializer(new CreateDatabaseIfNotExists<Data.E4StorageContext>());

                // Buat instance migrator dengan konfigurasi Anda
                var configuration = new Migrations.Configuration(); // Sesuaikan dengan konfigurasi migrasi Anda
                var migrator = new DbMigrator(configuration);

                // Jalankan migrasi
                migrator.Update();
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError("mdlPublic.initDB", ex);
            }
        }
    }
}
