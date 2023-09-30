
namespace EM4.App.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollectionSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.barStatusUser = new DevExpress.XtraBars.BarStaticItem();
            this.rgbSkins = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bbiSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoginOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMasterItem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStokMasuk = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStokKeluar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLaporanSaldoStok = new DevExpress.XtraBars.BarButtonItem();
            this.bbiListBarangMasuk = new DevExpress.XtraBars.BarButtonItem();
            this.bbiListBarangKeluar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLaporanKartuStok = new DevExpress.XtraBars.BarButtonItem();
            this.bbiManagementUser = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollectionLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Images = this.imageCollectionSmall;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barStatusUser,
            this.rgbSkins,
            this.bbiSetting,
            this.bbiLoginOut,
            this.bbiMasterItem,
            this.bbiStokMasuk,
            this.bbiStokKeluar,
            this.bbiLaporanSaldoStok,
            this.bbiListBarangMasuk,
            this.bbiListBarangKeluar,
            this.bbiLaporanKartuStok,
            this.bbiManagementUser});
            this.ribbonControl1.LargeImages = this.imageCollectionLarge;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsTouch.ShowTouchUISelectorInQAT = true;
            this.ribbonControl1.OptionsTouch.ShowTouchUISelectorVisibilityItemInQATMenu = true;
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.Size = new System.Drawing.Size(1146, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // imageCollectionSmall
            // 
            this.imageCollectionSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionSmall.ImageStream")));
            this.imageCollectionSmall.InsertImage(global::EM4.App.Properties.Resources.properties_16x16, "properties_16x16", typeof(global::EM4.App.Properties.Resources), 0);
            this.imageCollectionSmall.Images.SetKeyName(0, "properties_16x16");
            this.imageCollectionSmall.InsertImage(global::EM4.App.Properties.Resources.bouser_16x16, "bouser_16x16", typeof(global::EM4.App.Properties.Resources), 1);
            this.imageCollectionSmall.Images.SetKeyName(1, "bouser_16x16");
            this.imageCollectionSmall.InsertImage(global::EM4.App.Properties.Resources.bopermission_16x16, "bopermission_16x16", typeof(global::EM4.App.Properties.Resources), 2);
            this.imageCollectionSmall.Images.SetKeyName(2, "bopermission_16x16");
            this.imageCollectionSmall.InsertImage(global::EM4.App.Properties.Resources.usergroup_16x16, "usergroup_16x16", typeof(global::EM4.App.Properties.Resources), 3);
            this.imageCollectionSmall.Images.SetKeyName(3, "usergroup_16x16");
            // 
            // barStatusUser
            // 
            this.barStatusUser.Caption = "User : (none)";
            this.barStatusUser.Id = 1;
            this.barStatusUser.ImageOptions.SvgImage = global::EM4.App.Properties.Resources.actions_user;
            this.barStatusUser.Name = "barStatusUser";
            this.barStatusUser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // rgbSkins
            // 
            this.rgbSkins.Caption = "skinRibbonGalleryBarItem1";
            this.rgbSkins.Id = 2;
            this.rgbSkins.Name = "rgbSkins";
            this.rgbSkins.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rbgSkins_GalleryItemClick);
            // 
            // bbiSetting
            // 
            this.bbiSetting.Caption = "App Setting";
            this.bbiSetting.Id = 3;
            this.bbiSetting.ImageOptions.LargeImageIndex = 0;
            this.bbiSetting.Name = "bbiSetting";
            this.bbiSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetting_ItemClick);
            // 
            // bbiLoginOut
            // 
            this.bbiLoginOut.Caption = "Login";
            this.bbiLoginOut.Id = 4;
            this.bbiLoginOut.ImageOptions.LargeImageIndex = 1;
            this.bbiLoginOut.Name = "bbiLoginOut";
            this.bbiLoginOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLoginOut_ItemClick);
            // 
            // bbiMasterItem
            // 
            this.bbiMasterItem.Caption = "Master Item";
            this.bbiMasterItem.Id = 5;
            this.bbiMasterItem.Name = "bbiMasterItem";
            // 
            // bbiStokMasuk
            // 
            this.bbiStokMasuk.Caption = "Stok Masuk";
            this.bbiStokMasuk.Id = 6;
            this.bbiStokMasuk.Name = "bbiStokMasuk";
            // 
            // bbiStokKeluar
            // 
            this.bbiStokKeluar.Caption = "Stok Keluar";
            this.bbiStokKeluar.Id = 7;
            this.bbiStokKeluar.Name = "bbiStokKeluar";
            // 
            // bbiLaporanSaldoStok
            // 
            this.bbiLaporanSaldoStok.Caption = "Laporan Saldo Stok";
            this.bbiLaporanSaldoStok.Id = 8;
            this.bbiLaporanSaldoStok.Name = "bbiLaporanSaldoStok";
            // 
            // bbiListBarangMasuk
            // 
            this.bbiListBarangMasuk.Caption = "List Barang Masuk";
            this.bbiListBarangMasuk.Id = 9;
            this.bbiListBarangMasuk.Name = "bbiListBarangMasuk";
            // 
            // bbiListBarangKeluar
            // 
            this.bbiListBarangKeluar.Caption = "List Barang Keluar";
            this.bbiListBarangKeluar.Id = 10;
            this.bbiListBarangKeluar.Name = "bbiListBarangKeluar";
            // 
            // bbiLaporanKartuStok
            // 
            this.bbiLaporanKartuStok.Caption = "Laporan Kartu Stok";
            this.bbiLaporanKartuStok.Id = 11;
            this.bbiLaporanKartuStok.Name = "bbiLaporanKartuStok";
            // 
            // bbiManagementUser
            // 
            this.bbiManagementUser.Caption = "Manajemen User";
            this.bbiManagementUser.Id = 12;
            this.bbiManagementUser.ImageOptions.LargeImageIndex = 3;
            this.bbiManagementUser.Name = "bbiManagementUser";
            this.bbiManagementUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiManagementUser_ItemClick);
            // 
            // imageCollectionLarge
            // 
            this.imageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionLarge.ImageStream")));
            this.imageCollectionLarge.InsertImage(global::EM4.App.Properties.Resources.properties_32x32, "properties_32x32", typeof(global::EM4.App.Properties.Resources), 0);
            this.imageCollectionLarge.Images.SetKeyName(0, "properties_32x32");
            this.imageCollectionLarge.InsertImage(global::EM4.App.Properties.Resources.bouser_32x32, "bouser_32x32", typeof(global::EM4.App.Properties.Resources), 1);
            this.imageCollectionLarge.Images.SetKeyName(1, "bouser_32x32");
            this.imageCollectionLarge.InsertImage(global::EM4.App.Properties.Resources.bopermission_32x32, "bopermission_32x32", typeof(global::EM4.App.Properties.Resources), 2);
            this.imageCollectionLarge.Images.SetKeyName(2, "bopermission_32x32");
            this.imageCollectionLarge.InsertImage(global::EM4.App.Properties.Resources.usergroup_32x321, "usergroup_32x321", typeof(global::EM4.App.Properties.Resources), 3);
            this.imageCollectionLarge.Images.SetKeyName(3, "usergroup_32x321");
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage3});
            this.ribbonPageCategory1.Text = "Tools";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Settings";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.rgbSkins);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Skin";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiSetting);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiLoginOut, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiManagementUser, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Settings";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Menu Utama";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.bbiMasterItem);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Master";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiStokMasuk);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiStokKeluar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Transaksi";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiLaporanSaldoStok);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiLaporanKartuStok);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiListBarangMasuk, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiListBarangKeluar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Laporan";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barStatusUser);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 633);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1146, 24);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 657);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "EM4 Storage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem barStatusUser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem rgbSkins;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.Utils.ImageCollection imageCollectionSmall;
        private DevExpress.XtraBars.BarButtonItem bbiSetting;
        private DevExpress.Utils.ImageCollection imageCollectionLarge;
        private DevExpress.XtraBars.BarButtonItem bbiLoginOut;
        private DevExpress.XtraBars.BarButtonItem bbiMasterItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem bbiStokMasuk;
        private DevExpress.XtraBars.BarButtonItem bbiStokKeluar;
        private DevExpress.XtraBars.BarButtonItem bbiLaporanSaldoStok;
        private DevExpress.XtraBars.BarButtonItem bbiListBarangMasuk;
        private DevExpress.XtraBars.BarButtonItem bbiListBarangKeluar;
        private DevExpress.XtraBars.BarButtonItem bbiLaporanKartuStok;
        private DevExpress.XtraBars.BarButtonItem bbiManagementUser;
    }
}

