
namespace EM4.App.UI
{
    partial class frmLaporanMutasiStok
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.mnReload = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.mnSimpan = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.MutasiStokBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDInventor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemInventor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNamaBarang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemUOM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSaldoAwal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyMasuk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyKeluar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoAkhir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemBelt = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutasiStokBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInventor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemBelt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mnSimpan,
            this.mnReload});
            this.barManager1.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnReload, true)});
            this.bar1.Text = "Tools";
            // 
            // mnReload
            // 
            this.mnReload.Caption = "&Reload [F5]";
            this.mnReload.Id = 1;
            this.mnReload.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.mnReload.Name = "mnReload";
            this.mnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnReload_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1094, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 583);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1094, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 563);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1094, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 563);
            // 
            // mnSimpan
            // 
            this.mnSimpan.Caption = "&Simpan [F6]";
            this.mnSimpan.Id = 0;
            this.mnSimpan.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.mnSimpan.Name = "mnSimpan";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.MutasiStokBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemUser,
            this.repositoryItemUOM,
            this.repositoryItemInventor,
            this.repositoryItemBelt,
            this.repositoryItemType});
            this.gridControl1.Size = new System.Drawing.Size(1094, 527);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // MutasiStokBindingSource
            // 
            this.MutasiStokBindingSource.DataSource = typeof(EM4.App.Model.ViewModel.MutasiStok);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDInventor,
            this.colNamaBarang,
            this.colIDUOM,
            this.colSaldoAwal,
            this.colQtyMasuk,
            this.colQtyKeluar,
            this.colSaldoAkhir});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChange);
            // 
            // colIDInventor
            // 
            this.colIDInventor.Caption = "Kode Barang";
            this.colIDInventor.ColumnEdit = this.repositoryItemInventor;
            this.colIDInventor.FieldName = "IDInventor";
            this.colIDInventor.Name = "colIDInventor";
            this.colIDInventor.Visible = true;
            this.colIDInventor.VisibleIndex = 0;
            this.colIDInventor.Width = 101;
            // 
            // repositoryItemInventor
            // 
            this.repositoryItemInventor.AutoHeight = false;
            this.repositoryItemInventor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemInventor.Name = "repositoryItemInventor";
            // 
            // colNamaBarang
            // 
            this.colNamaBarang.FieldName = "NamaBarang";
            this.colNamaBarang.Name = "colNamaBarang";
            this.colNamaBarang.Visible = true;
            this.colNamaBarang.VisibleIndex = 1;
            this.colNamaBarang.Width = 155;
            // 
            // colIDUOM
            // 
            this.colIDUOM.Caption = "Satuan";
            this.colIDUOM.ColumnEdit = this.repositoryItemUOM;
            this.colIDUOM.FieldName = "IDUOM";
            this.colIDUOM.Name = "colIDUOM";
            this.colIDUOM.Visible = true;
            this.colIDUOM.VisibleIndex = 2;
            // 
            // repositoryItemUOM
            // 
            this.repositoryItemUOM.AutoHeight = false;
            this.repositoryItemUOM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemUOM.Name = "repositoryItemUOM";
            // 
            // colSaldoAwal
            // 
            this.colSaldoAwal.AppearanceCell.Options.UseTextOptions = true;
            this.colSaldoAwal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSaldoAwal.AppearanceHeader.Options.UseTextOptions = true;
            this.colSaldoAwal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSaldoAwal.Caption = "Stok Awal";
            this.colSaldoAwal.DisplayFormat.FormatString = "n0";
            this.colSaldoAwal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldoAwal.FieldName = "SaldoAwal";
            this.colSaldoAwal.Name = "colSaldoAwal";
            this.colSaldoAwal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaldoAwal", "{0:n0}")});
            this.colSaldoAwal.Visible = true;
            this.colSaldoAwal.VisibleIndex = 3;
            this.colSaldoAwal.Width = 97;
            // 
            // colQtyMasuk
            // 
            this.colQtyMasuk.AppearanceCell.Options.UseTextOptions = true;
            this.colQtyMasuk.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQtyMasuk.AppearanceHeader.Options.UseTextOptions = true;
            this.colQtyMasuk.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQtyMasuk.Caption = "Stok Masuk";
            this.colQtyMasuk.DisplayFormat.FormatString = "n0";
            this.colQtyMasuk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyMasuk.FieldName = "QtyMasuk";
            this.colQtyMasuk.Name = "colQtyMasuk";
            this.colQtyMasuk.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyMasuk", "{0:n0}")});
            this.colQtyMasuk.Visible = true;
            this.colQtyMasuk.VisibleIndex = 4;
            this.colQtyMasuk.Width = 88;
            // 
            // colQtyKeluar
            // 
            this.colQtyKeluar.AppearanceCell.Options.UseTextOptions = true;
            this.colQtyKeluar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQtyKeluar.AppearanceHeader.Options.UseTextOptions = true;
            this.colQtyKeluar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQtyKeluar.Caption = "Stok Keluar";
            this.colQtyKeluar.DisplayFormat.FormatString = "n0";
            this.colQtyKeluar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyKeluar.FieldName = "QtyKeluar";
            this.colQtyKeluar.Name = "colQtyKeluar";
            this.colQtyKeluar.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QtyKeluar", "{0:n0}")});
            this.colQtyKeluar.Visible = true;
            this.colQtyKeluar.VisibleIndex = 5;
            this.colQtyKeluar.Width = 84;
            // 
            // colSaldoAkhir
            // 
            this.colSaldoAkhir.AppearanceCell.Options.UseTextOptions = true;
            this.colSaldoAkhir.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSaldoAkhir.AppearanceHeader.Options.UseTextOptions = true;
            this.colSaldoAkhir.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSaldoAkhir.Caption = "Stok Akhir";
            this.colSaldoAkhir.DisplayFormat.FormatString = "n0";
            this.colSaldoAkhir.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldoAkhir.FieldName = "SaldoAkhir";
            this.colSaldoAkhir.Name = "colSaldoAkhir";
            this.colSaldoAkhir.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaldoAkhir", "{0:n0}")});
            this.colSaldoAkhir.Visible = true;
            this.colSaldoAkhir.VisibleIndex = 6;
            this.colSaldoAkhir.Width = 99;
            // 
            // repositoryItemUser
            // 
            this.repositoryItemUser.AutoHeight = false;
            this.repositoryItemUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemUser.Name = "repositoryItemUser";
            // 
            // repositoryItemBelt
            // 
            this.repositoryItemBelt.AutoHeight = false;
            this.repositoryItemBelt.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemBelt.Name = "repositoryItemBelt";
            // 
            // repositoryItemType
            // 
            this.repositoryItemType.AutoHeight = false;
            this.repositoryItemType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemType.Name = "repositoryItemType";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1094, 36);
            this.panelControl1.TabIndex = 0;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = new System.DateTime(2023, 10, 2, 10, 27, 44, 361);
            this.dateEdit2.EnterMoveNextControl = true;
            this.dateEdit2.Location = new System.Drawing.Point(190, 9);
            this.dateEdit2.MenuManager = this.barManager1;
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(169, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(15, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "s/d";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2023, 10, 2, 10, 27, 44, 361);
            this.dateEdit1.EnterMoveNextControl = true;
            this.dateEdit1.Location = new System.Drawing.Point(63, 9);
            this.dateEdit1.MenuManager = this.barManager1;
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Periode";
            // 
            // frmLaporanMutasiStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 583);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmLaporanMutasiStok";
            this.Text = "Laporan Mutasi Stok";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLaporanMutasiStok_FormClosing);
            this.Load += new System.EventHandler(this.frmLaporanMutasiStok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutasiStokBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInventor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemBelt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem mnSimpan;
        private DevExpress.XtraBars.BarButtonItem mnReload;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemUser;
        private System.Windows.Forms.BindingSource MutasiStokBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIDInventor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemInventor;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUOM;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemUOM;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoAwal;
        private DevExpress.XtraGrid.Columns.GridColumn colNamaBarang;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemBelt;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemType;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyMasuk;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyKeluar;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoAkhir;
    }
}