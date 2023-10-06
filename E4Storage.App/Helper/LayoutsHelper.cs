using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Helper
{
    public class LayoutsHelper
    {
        private string pathLayoutsSetting = Path.Combine(Environment.CurrentDirectory, "System", "Layouts");
        public bool IsRestoreLayout { get; set; }
        public LayoutsHelper(string pathLayouts)
        {
            changePathLayouts(pathLayouts);
        }

        public void changePathLayouts(string pathLayouts)
        {
            if (Directory.Exists(pathLayouts))
            {
                this.pathLayoutsSetting = pathLayouts;
            }
            else
            {
                MsgBoxHelper.MsgInfo("LayoutsHelper.changePathLayouts", null, $"Path Layouts {pathLayouts} tidak ditemukan!");
                this.pathLayoutsSetting = Path.Combine(Environment.CurrentDirectory, "System", "Layouts");
            }
        }

        private string FolderLayouts()
        {
            if (IsRestoreLayout)
                return Path.Combine(pathLayoutsSetting, "Default");
            else
                return pathLayoutsSetting;
        }

        private string FolderMRU()
        {
            return Path.Combine(Environment.CurrentDirectory, "System", "MRU");
        }

        public void LoadMRU(string FormName, SearchControl Control)
        {
            try
            {
                if (System.IO.File.Exists(Path.Combine(FolderMRU(), FormName + Control.Name + ".xml")))
                {
                    Control.Properties.LoadItemsFromXml(Path.Combine(FolderMRU(), FormName + Control.Name + ".xml"));
                    Control.Properties.ShowMRUButton = true;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.RestoreMRU_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }

        public void RestoreLayouts(string FormName, LayoutControl Control)
        {
            try
            {
                if (System.IO.File.Exists(Path.Combine(FolderLayouts(), FormName + Control.Name + ".xml")))
                {
                    if (IsRestoreLayout)
                        System.IO.File.Copy(Path.Combine(pathLayoutsSetting, "Default", FormName + Control.Name + ".xml"),
                            Path.Combine(pathLayoutsSetting, FormName + Control.Name + ".xml"), true);
                    Control.RestoreLayoutFromXml(Path.Combine(FolderLayouts(), FormName + Control.Name + ".xml"));
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.RestoreLayouts_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }

        public void RestoreLayouts(string FormName, DevExpress.XtraDataLayout.DataLayoutControl Control)
        {
            try
            {
                if (System.IO.File.Exists(Path.Combine(FolderLayouts(), FormName + Control.Name + ".xml")))
                {
                    if (IsRestoreLayout)
                        System.IO.File.Copy(Path.Combine(pathLayoutsSetting, "Default", FormName + Control.Name + ".xml"),
                            Path.Combine(pathLayoutsSetting, FormName + Control.Name + ".xml"), true);
                    Control.RestoreLayoutFromXml(Path.Combine(FolderLayouts(), FormName + Control.Name + ".xml"));
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.RestoreLayouts_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }

        public void RestoreLayouts(string FormName, GridView Control)
        {
            try
            {
                if (System.IO.File.Exists(Path.Combine(FolderLayouts(), FormName + Control.Name + Control.LevelName + ".xml")))
                {
                    if (IsRestoreLayout)
                        System.IO.File.Copy(Path.Combine(pathLayoutsSetting, "Default", FormName + Control.Name + Control.LevelName + ".xml"),
                            Path.Combine(pathLayoutsSetting, FormName + Control.Name + ".xml"), true);
                    Control.RestoreLayoutFromXml(Path.Combine(FolderLayouts(), FormName + Control.Name + Control.LevelName + ".xml"));
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.RestoreLayouts_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }

        public void SaveMRU(string FormName, SearchControl Control)
        {
            try
            {
                if (!System.IO.Directory.Exists(FolderMRU()))
                    System.IO.Directory.CreateDirectory(FolderMRU());
                Control.Properties.SaveItemsToXml(Path.Combine(FolderMRU(), FormName + Control.Name + ".xml"));
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.SaveMRU_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }

        public void SaveLayouts(string FormName, LayoutControl Control)
        {
            try
            {
                if (!System.IO.Directory.Exists(pathLayoutsSetting))
                    System.IO.Directory.CreateDirectory(pathLayoutsSetting);
                Control.SaveLayoutToXml(Path.Combine(pathLayoutsSetting, FormName + Control.Name + ".xml"));
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.SaveLayouts_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }

        public void SaveLayouts(string FormName, DevExpress.XtraDataLayout.DataLayoutControl Control)
        {
            try
            {
                if (!System.IO.Directory.Exists(pathLayoutsSetting))
                    System.IO.Directory.CreateDirectory(pathLayoutsSetting);
                Control.SaveLayoutToXml(Path.Combine(pathLayoutsSetting, FormName + Control.Name + ".xml"));
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.SaveLayouts_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }

        public void SaveLayouts(string FormName, GridView Control)
        {
            try
            {
                if (!System.IO.Directory.Exists(pathLayoutsSetting))
                    System.IO.Directory.CreateDirectory(pathLayoutsSetting);
                Control.SaveLayoutToXml(Path.Combine(pathLayoutsSetting, FormName + Control.Name + Control.LevelName + ".xml"));
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgWarn("LayoutsHelper.SaveLayouts_" + FormName + Control.Name, "Error : " + ex.Message);
            }
        }
    }
}
