using E4Storage.App.Model;
using E4Storage.App.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace E4Storage.App.UI
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
            this.Text = $"{Constant.NamaApplikasi} [{Application.ProductVersion}]";
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
                bbiLaporanMutasiStok.Enabled = false;
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

                bbiMasterItem.Enabled = Constant.UserLogin.IsAdmin;
                bbiStokKeluar.Enabled = true;
                bbiStokMasuk.Enabled = true;
                bbiLaporanSaldoStok.Enabled = Constant.UserLogin.IsAdmin;
                bbiLaporanKartuStok.Enabled = Constant.UserLogin.IsAdmin;
                bbiLaporanMutasiStok.Enabled = Constant.UserLogin.IsAdmin;
                bbiListBarangKeluar.Enabled = Constant.UserLogin.IsAdmin;
                bbiListBarangMasuk.Enabled = Constant.UserLogin.IsAdmin;

                //Dashboard
                if (Utils.Constant.UserLogin.IsAdmin)
                {
                    System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmDaftarMasterItem) && !o.ControlBox);
                    if (frmOld != null)
                    {
                        frmOld.Show();
                        frmOld.Focus();
                    }
                    else
                    {
                        frmOld = new frmDaftarMasterItem
                        {
                            ControlBox = false,
                            MdiParent = this
                        };
                        frmOld.Show();
                        frmOld.Focus();
                    }
                }
            }
        }

        private void bbiSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmSetting frm = new frmSetting(E4Storage.App.Helper.JSONHelper.CloneObject<AppSetting>(Constant.appSetting)))
            {
                try
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        Constant.appSetting = frm.AppSetting;
                        sharedData.saveAppConfig(Constant.appSetting);

                        // Simpan perubahan ke konfigurasi
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.ConnectionStrings.ConnectionStrings["E4Storage"].ConnectionString = Constant.appSetting.KoneksiString;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("connectionStrings");

                        Application.Restart();
                    }
                }
                catch (Exception ex)
                {
                    E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiSetting_ItemClick", ex);
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
                        DialogResult result = frm.ShowDialog(this);
                        if (result == DialogResult.OK)
                        {
                            activekanUser();
                        }
                        else if (result == DialogResult.Retry)
                        {
                            Application.Restart();
                        }
                    }
                    catch (Exception ex)
                    {
                        E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiSetting_ItemClick", ex);
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

        private bool isLogin()
        {
            return (Constant.UserLogin != null && Constant.UserLogin.UserID != null && Constant.UserLogin.UserID.Length >= 1);
        }

        private void bbiManagementUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmManajemenUser));
                if (frmOld != null)
                {
                    frmOld.Show();
                    frmOld.Focus();
                }
                else
                {
                    frmOld = new frmManajemenUser
                    {
                        MdiParent = this
                    };
                    frmOld.Show();
                    frmOld.Focus();
                }
            }
        }

        private void bbiMasterItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmDaftarMasterItem));
                if (frmOld != null)
                {
                    frmOld.Show();
                    frmOld.Focus();
                }
                else
                {
                    frmOld = new frmDaftarMasterItem
                    {
                        MdiParent = this
                    };
                    frmOld.Show();
                    frmOld.Focus();
                }
            }
        }

        private void bbiStokMasuk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                var dialog = new Dialog.flyoutOptionStokMasuk(this, new Dialog.dlgOptionStokMasuk()).ShowFormPopup();
                if (dialog.Item1 == DialogResult.OK && dialog.Item2 == (int)Constant.TypeTransaction.stokIn)
                {
                    using (frmEntriStokMasuk frm = new frmEntriStokMasuk(null))
                    {
                        try
                        {
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog(this);
                        }
                        catch (Exception ex)
                        {
                            E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiStokMasuk_ItemClick", ex);
                        }
                    }
                }
                else if (dialog.Item1 == DialogResult.OK && dialog.Item2 == (int)Constant.TypeTransaction.stokPengembalian)
                {
                    using (frmEntriStokPengembalian frm = new frmEntriStokPengembalian(null))
                    {
                        try
                        {
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog(this);
                        }
                        catch (Exception ex)
                        {
                            E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiStokMasuk_ItemClick", ex);
                        }
                    }
                }
                else if (dialog.Item1 == DialogResult.OK && dialog.Item2 == (int)Constant.TypeTransaction.stokMasterData)
                {
                    using (frmEntriStokMasterData frm = new frmEntriStokMasterData(null))
                    {
                        try
                        {
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog(this);
                        }
                        catch (Exception ex)
                        {
                            E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiStokMasuk_ItemClick", ex);
                        }
                    }
                }
            }
        }

        private void bbiStokKeluar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                using (frmEntriStokKeluar frm = new frmEntriStokKeluar(null))
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                    }
                    catch (Exception ex)
                    {
                        E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiStokKeluar_ItemClick", ex);
                    }
                }
            }
        }

        private void mnMutasiSaldoStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmLaporanMutasiStok));
                if (frmOld != null)
                {
                    frmOld.Show();
                    frmOld.Focus();
                }
                else
                {
                    frmOld = new frmLaporanMutasiStok
                    {
                        MdiParent = this
                    };
                    frmOld.Show();
                    frmOld.Focus();
                }
            }
        }

        private void bbiListBarangMasuk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmLaporanStokMasuk));
                if (frmOld != null)
                {
                    frmOld.Show();
                    frmOld.Focus();
                }
                else
                {
                    frmOld = new frmLaporanStokMasuk
                    {
                        MdiParent = this
                    };
                    frmOld.Show();
                    frmOld.Focus();
                }
            }
        }

        private void bbiListBarangKeluar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmLaporanStokKeluar));
                if (frmOld != null)
                {
                    frmOld.Show();
                    frmOld.Focus();
                }
                else
                {
                    frmOld = new frmLaporanStokKeluar
                    {
                        MdiParent = this
                    };
                    frmOld.Show();
                    frmOld.Focus();
                }
            }
        }

        private void bbiLaporanSaldoStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmLaporanSaldoStok));
                if (frmOld != null)
                {
                    frmOld.Show();
                    frmOld.Focus();
                }
                else
                {
                    frmOld = new frmLaporanSaldoStok
                    {
                        MdiParent = this
                    };
                    frmOld.Show();
                    frmOld.Focus();
                }
            }
        }

        private void bbiLaporanKartuStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isLogin())
            {
                System.Windows.Forms.Form frmOld = this.MdiChildren.ToList().FirstOrDefault(o => o.GetType() == typeof(frmLaporanKartuStok));
                if (frmOld != null)
                {
                    frmOld.Show();
                    frmOld.Focus();
                }
                else
                {
                    frmOld = new frmLaporanKartuStok
                    {
                        MdiParent = this
                    };
                    frmOld.Show();
                    frmOld.Focus();
                }
            }
        }
    }
}
