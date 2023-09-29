﻿using EM4.App.Model;
using EM4.App.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EM4.App.UI
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void rbgSkins_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            selectedSkins(e.Item.Value.ToString());
        }

        private void selectedSkins(string skinName)
        {
            Constant.appSetting.Theme = skinName;
            Utils.sharedData.saveAppConfig(Constant.appSetting);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ribbonControl1.SelectedPage = ribbonPage1;
            activekanUser();
            bbiLoginOut.PerformClick();
        }

        private void activekanUser()
        {
            if (Constant.UserLogin == null)
            {
                barStatusUser.Caption = "User : (none)";
                bbiSetting.Enabled = true;
                bbiLoginOut.Caption = "Login";
                bbiLoginOut.LargeImageIndex = 1;
                bbiManagementUser.Enabled = false;

                bbiMasterItem.Enabled = false;
                bbiStokKeluar.Enabled = false;
                bbiStokMasuk.Enabled = false;
                bbiLaporanSaldoStok.Enabled = false;
                bbiLaporanKartuStok.Enabled = false;
                bbiListBarangKeluar.Enabled = false;
                bbiListBarangMasuk.Enabled = false;

                foreach (var item in this.MdiChildren)
                {
                    item.DialogResult = DialogResult.Cancel;
                    item.Close();

                    Application.DoEvents();
                }
            }
            else
            {
                barStatusUser.Caption = $"User : {Constant.UserLogin.Nama}";
                bbiSetting.Enabled = false;
                bbiLoginOut.Caption = "Logout";
                bbiLoginOut.LargeImageIndex = 2;
                bbiManagementUser.Enabled = Constant.UserLogin.IsAdmin;

                bbiMasterItem.Enabled = true;
                bbiStokKeluar.Enabled = true;
                bbiStokMasuk.Enabled = true;
                bbiLaporanSaldoStok.Enabled = Constant.UserLogin.IsAdmin;
                bbiLaporanKartuStok.Enabled = Constant.UserLogin.IsAdmin;
                bbiListBarangKeluar.Enabled = Constant.UserLogin.IsAdmin;
                bbiListBarangMasuk.Enabled = Constant.UserLogin.IsAdmin;
            }
        }

        private void bbiSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSetting frm = new frmSetting(EM4.App.Helper.JSONHelper.CloneObject<AppSetting>(Constant.appSetting)))
            {
                try
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        Constant.appSetting = frm.AppSetting;
                        sharedData.saveAppConfig(Constant.appSetting);
                    }
                }
                catch (Exception ex)
                {
                    EM4.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiSetting_ItemClick", ex);
                }
            }
        }

        private void bbiLoginOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Constant.UserLogin == null)
            {
                using (frmLogin frm = new frmLogin())
                {
                    try
                    {
                        ribbonControl1.SelectedPage = ribbonPage1;
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            activekanUser();
                        }
                    }
                    catch (Exception ex)
                    {
                        EM4.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiSetting_ItemClick", ex);
                    }
                }
            }
            else
            {
                Constant.UserLogin = null;
                activekanUser();
                bbiLoginOut.PerformClick();
            }
        }
    }
}
