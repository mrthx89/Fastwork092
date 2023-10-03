
namespace EM4.App.UI
{
    partial class frmLaporanSaldoStok
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tInventorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemUOM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockIns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockOuts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockCards = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserEntri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTglEntri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTglEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserHapus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTglHapus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tInventorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).BeginInit();
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1094, 36);
            this.panelControl1.TabIndex = 0;
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
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Saldo Per";
            // 
            // tInventorBindingSource
            // 
            this.tInventorBindingSource.DataSource = typeof(EM4.App.Model.ViewModel.ItemMaster);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tInventorBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemUser,
            this.repositoryItemUOM});
            this.gridControl1.Size = new System.Drawing.Size(1094, 527);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colPLU,
            this.colDesc,
            this.colIDUOM,
            this.colUOM,
            this.colStockIns,
            this.colStockOuts,
            this.colStockCards,
            this.colIDUserEntri,
            this.colTglEntri,
            this.colIDUserEdit,
            this.colTglEdit,
            this.colIDUserHapus,
            this.colTglHapus,
            this.colSaldo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChange);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colPLU
            // 
            this.colPLU.Caption = "Kode Barang";
            this.colPLU.FieldName = "PLU";
            this.colPLU.Name = "colPLU";
            this.colPLU.Visible = true;
            this.colPLU.VisibleIndex = 0;
            this.colPLU.Width = 84;
            // 
            // colDesc
            // 
            this.colDesc.Caption = "Nama";
            this.colDesc.FieldName = "Desc";
            this.colDesc.Name = "colDesc";
            this.colDesc.Visible = true;
            this.colDesc.VisibleIndex = 1;
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
            // colUOM
            // 
            this.colUOM.FieldName = "UOM";
            this.colUOM.Name = "colUOM";
            // 
            // colStockIns
            // 
            this.colStockIns.FieldName = "StockIns";
            this.colStockIns.Name = "colStockIns";
            // 
            // colStockOuts
            // 
            this.colStockOuts.FieldName = "StockOuts";
            this.colStockOuts.Name = "colStockOuts";
            // 
            // colStockCards
            // 
            this.colStockCards.FieldName = "StockCards";
            this.colStockCards.Name = "colStockCards";
            this.colStockCards.Width = 80;
            // 
            // colIDUserEntri
            // 
            this.colIDUserEntri.Caption = "User Entri";
            this.colIDUserEntri.ColumnEdit = this.repositoryItemUser;
            this.colIDUserEntri.FieldName = "IDUserEntri";
            this.colIDUserEntri.Name = "colIDUserEntri";
            this.colIDUserEntri.Visible = true;
            this.colIDUserEntri.VisibleIndex = 3;
            this.colIDUserEntri.Width = 84;
            // 
            // repositoryItemUser
            // 
            this.repositoryItemUser.AutoHeight = false;
            this.repositoryItemUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemUser.Name = "repositoryItemUser";
            // 
            // colTglEntri
            // 
            this.colTglEntri.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglEntri.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglEntri.FieldName = "TglEntri";
            this.colTglEntri.Name = "colTglEntri";
            this.colTglEntri.Visible = true;
            this.colTglEntri.VisibleIndex = 4;
            // 
            // colIDUserEdit
            // 
            this.colIDUserEdit.Caption = "User Edit";
            this.colIDUserEdit.ColumnEdit = this.repositoryItemUser;
            this.colIDUserEdit.FieldName = "IDUserEdit";
            this.colIDUserEdit.Name = "colIDUserEdit";
            this.colIDUserEdit.Visible = true;
            this.colIDUserEdit.VisibleIndex = 5;
            this.colIDUserEdit.Width = 80;
            // 
            // colTglEdit
            // 
            this.colTglEdit.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglEdit.FieldName = "TglEdit";
            this.colTglEdit.Name = "colTglEdit";
            this.colTglEdit.Visible = true;
            this.colTglEdit.VisibleIndex = 6;
            // 
            // colIDUserHapus
            // 
            this.colIDUserHapus.Caption = "User Hapus";
            this.colIDUserHapus.ColumnEdit = this.repositoryItemUser;
            this.colIDUserHapus.FieldName = "IDUserHapus";
            this.colIDUserHapus.Name = "colIDUserHapus";
            this.colIDUserHapus.Visible = true;
            this.colIDUserHapus.VisibleIndex = 7;
            this.colIDUserHapus.Width = 92;
            // 
            // colTglHapus
            // 
            this.colTglHapus.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglHapus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglHapus.FieldName = "TglHapus";
            this.colTglHapus.Name = "colTglHapus";
            this.colTglHapus.Visible = true;
            this.colTglHapus.VisibleIndex = 8;
            // 
            // colSaldo
            // 
            this.colSaldo.AppearanceCell.Options.UseTextOptions = true;
            this.colSaldo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSaldo.AppearanceHeader.Options.UseTextOptions = true;
            this.colSaldo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSaldo.Caption = "Stok";
            this.colSaldo.DisplayFormat.FormatString = "n0";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:n0}")});
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 9;
            // 
            // frmLaporanSaldoStok
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
            this.Name = "frmLaporanSaldoStok";
            this.Text = "Laporan Saldo Stok";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLaporanSaldoStok_FormClosing);
            this.Load += new System.EventHandler(this.frmLaporanSaldoStok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tInventorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem mnSimpan;
        private DevExpress.XtraBars.BarButtonItem mnReload;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource tInventorBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colPLU;
        private DevExpress.XtraGrid.Columns.GridColumn colDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUOM;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemUOM;
        private DevExpress.XtraGrid.Columns.GridColumn colUOM;
        private DevExpress.XtraGrid.Columns.GridColumn colStockIns;
        private DevExpress.XtraGrid.Columns.GridColumn colStockOuts;
        private DevExpress.XtraGrid.Columns.GridColumn colStockCards;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserEntri;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemUser;
        private DevExpress.XtraGrid.Columns.GridColumn colTglEntri;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colTglEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserHapus;
        private DevExpress.XtraGrid.Columns.GridColumn colTglHapus;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
    }
}