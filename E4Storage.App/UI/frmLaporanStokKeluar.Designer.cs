
namespace E4Storage.App.UI
{
    partial class frmLaporanStokKeluar
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
            this.mnBaru = new DevExpress.XtraBars.BarButtonItem();
            this.mnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.mnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.mnReload = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.mnSimpan = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.stokKeluarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTanggal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDBelt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemBelt = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPIC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDInventor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemInventor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIDUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemUOM = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKeterangan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNamaBarang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserEntri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTglEntri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTglEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDUserHapus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTglHapus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIDCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCabinet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnSummaryItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSummaryBelt = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnHapus = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stokKeluarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemBelt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInventor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCategory)).BeginInit();
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
            this.mnReload,
            this.mnDelete,
            this.mnBaru,
            this.mnEdit,
            this.barButtonItem1,
            this.barButtonItem2});
            this.barManager1.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnBaru),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.mnReload, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            // 
            // mnBaru
            // 
            this.mnBaru.Caption = "&Baru [F1]";
            this.mnBaru.Id = 3;
            this.mnBaru.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.mnBaru.Name = "mnBaru";
            this.mnBaru.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnBaru_ItemClick);
            // 
            // mnEdit
            // 
            this.mnEdit.Caption = "&Edit [F2]";
            this.mnEdit.Id = 4;
            this.mnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.mnEdit.Name = "mnEdit";
            this.mnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnEdit_ItemClick);
            // 
            // mnDelete
            // 
            this.mnDelete.Caption = "&Delete [F4]";
            this.mnDelete.Id = 2;
            this.mnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.mnDelete.Name = "mnDelete";
            this.mnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnDelete_ItemClick);
            // 
            // mnReload
            // 
            this.mnReload.Caption = "&Reload [F5]";
            this.mnReload.Id = 1;
            this.mnReload.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.mnReload.Name = "mnReload";
            this.mnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnReload_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Summary &Item";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Summary &Belt";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1196, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 583);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1196, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1196, 20);
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
            this.gridControl1.DataSource = this.stokKeluarBindingSource;
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
            this.repositoryItemType,
            this.repositoryItemCategory});
            this.gridControl1.Size = new System.Drawing.Size(1196, 527);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // stokKeluarBindingSource
            // 
            this.stokKeluarBindingSource.DataSource = typeof(E4Storage.App.Model.ViewModel.StokKeluar);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colPeriode,
            this.colTanggal,
            this.colDocNo,
            this.colIDBelt,
            this.colPIC,
            this.colIDInventor,
            this.colIDUOM,
            this.colQty,
            this.colKeterangan,
            this.colNamaBarang,
            this.colIDUserEntri,
            this.colTglEntri,
            this.colIDUserEdit,
            this.colTglEdit,
            this.colIDUserHapus,
            this.colTglHapus,
            this.colType,
            this.colIDCategory,
            this.colCabinet,
            this.colRow});
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
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colPeriode
            // 
            this.colPeriode.Caption = "Periode";
            this.colPeriode.FieldName = "Periode";
            this.colPeriode.Name = "colPeriode";
            this.colPeriode.Visible = true;
            this.colPeriode.VisibleIndex = 0;
            this.colPeriode.Width = 92;
            // 
            // colTanggal
            // 
            this.colTanggal.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTanggal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTanggal.FieldName = "Tanggal";
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.Visible = true;
            this.colTanggal.VisibleIndex = 1;
            // 
            // colDocNo
            // 
            this.colDocNo.Caption = "No Form";
            this.colDocNo.FieldName = "DocNo";
            this.colDocNo.Name = "colDocNo";
            // 
            // colIDBelt
            // 
            this.colIDBelt.Caption = "Belt";
            this.colIDBelt.ColumnEdit = this.repositoryItemBelt;
            this.colIDBelt.FieldName = "IDBelt";
            this.colIDBelt.Name = "colIDBelt";
            this.colIDBelt.Visible = true;
            this.colIDBelt.VisibleIndex = 7;
            // 
            // repositoryItemBelt
            // 
            this.repositoryItemBelt.AutoHeight = false;
            this.repositoryItemBelt.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemBelt.Name = "repositoryItemBelt";
            // 
            // colPIC
            // 
            this.colPIC.Caption = "PIC";
            this.colPIC.FieldName = "PIC";
            this.colPIC.Name = "colPIC";
            this.colPIC.Visible = true;
            this.colPIC.VisibleIndex = 2;
            // 
            // colIDInventor
            // 
            this.colIDInventor.Caption = "Kode Barang";
            this.colIDInventor.ColumnEdit = this.repositoryItemInventor;
            this.colIDInventor.FieldName = "IDInventor";
            this.colIDInventor.Name = "colIDInventor";
            this.colIDInventor.Visible = true;
            this.colIDInventor.VisibleIndex = 3;
            this.colIDInventor.Width = 79;
            // 
            // repositoryItemInventor
            // 
            this.repositoryItemInventor.AutoHeight = false;
            this.repositoryItemInventor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemInventor.Name = "repositoryItemInventor";
            // 
            // colIDUOM
            // 
            this.colIDUOM.Caption = "Satuan";
            this.colIDUOM.ColumnEdit = this.repositoryItemUOM;
            this.colIDUOM.FieldName = "IDUOM";
            this.colIDUOM.Name = "colIDUOM";
            this.colIDUOM.Visible = true;
            this.colIDUOM.VisibleIndex = 6;
            // 
            // repositoryItemUOM
            // 
            this.repositoryItemUOM.AutoHeight = false;
            this.repositoryItemUOM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemUOM.Name = "repositoryItemUOM";
            // 
            // colQty
            // 
            this.colQty.AppearanceCell.Options.UseTextOptions = true;
            this.colQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQty.DisplayFormat.FormatString = "n0";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 5;
            // 
            // colKeterangan
            // 
            this.colKeterangan.FieldName = "Keterangan";
            this.colKeterangan.Name = "colKeterangan";
            this.colKeterangan.Visible = true;
            this.colKeterangan.VisibleIndex = 8;
            this.colKeterangan.Width = 79;
            // 
            // colNamaBarang
            // 
            this.colNamaBarang.FieldName = "NamaBarang";
            this.colNamaBarang.Name = "colNamaBarang";
            this.colNamaBarang.Visible = true;
            this.colNamaBarang.VisibleIndex = 4;
            this.colNamaBarang.Width = 137;
            // 
            // colIDUserEntri
            // 
            this.colIDUserEntri.Caption = "User Entri";
            this.colIDUserEntri.ColumnEdit = this.repositoryItemUser;
            this.colIDUserEntri.FieldName = "IDUserEntri";
            this.colIDUserEntri.Name = "colIDUserEntri";
            this.colIDUserEntri.Visible = true;
            this.colIDUserEntri.VisibleIndex = 9;
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
            this.colTglEntri.VisibleIndex = 10;
            // 
            // colIDUserEdit
            // 
            this.colIDUserEdit.Caption = "User Edit";
            this.colIDUserEdit.ColumnEdit = this.repositoryItemUser;
            this.colIDUserEdit.FieldName = "IDUserEdit";
            this.colIDUserEdit.Name = "colIDUserEdit";
            this.colIDUserEdit.Visible = true;
            this.colIDUserEdit.VisibleIndex = 11;
            this.colIDUserEdit.Width = 80;
            // 
            // colTglEdit
            // 
            this.colTglEdit.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglEdit.FieldName = "TglEdit";
            this.colTglEdit.Name = "colTglEdit";
            this.colTglEdit.Visible = true;
            this.colTglEdit.VisibleIndex = 12;
            // 
            // colIDUserHapus
            // 
            this.colIDUserHapus.Caption = "User Hapus";
            this.colIDUserHapus.ColumnEdit = this.repositoryItemUser;
            this.colIDUserHapus.FieldName = "IDUserHapus";
            this.colIDUserHapus.Name = "colIDUserHapus";
            this.colIDUserHapus.Width = 92;
            // 
            // colTglHapus
            // 
            this.colTglHapus.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.colTglHapus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglHapus.FieldName = "TglHapus";
            this.colTglHapus.Name = "colTglHapus";
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.ColumnEdit = this.repositoryItemType;
            this.colType.FieldName = "IDType";
            this.colType.Name = "colType";
            this.colType.Width = 169;
            // 
            // repositoryItemType
            // 
            this.repositoryItemType.AutoHeight = false;
            this.repositoryItemType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemType.Name = "repositoryItemType";
            // 
            // colIDCategory
            // 
            this.colIDCategory.Caption = "Category";
            this.colIDCategory.ColumnEdit = this.repositoryItemCategory;
            this.colIDCategory.FieldName = "IDCategory";
            this.colIDCategory.Name = "colIDCategory";
            this.colIDCategory.Visible = true;
            this.colIDCategory.VisibleIndex = 13;
            // 
            // repositoryItemCategory
            // 
            this.repositoryItemCategory.AutoHeight = false;
            this.repositoryItemCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCategory.Name = "repositoryItemCategory";
            // 
            // colCabinet
            // 
            this.colCabinet.AppearanceCell.Options.UseTextOptions = true;
            this.colCabinet.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCabinet.AppearanceHeader.Options.UseTextOptions = true;
            this.colCabinet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCabinet.Caption = "Cabinet";
            this.colCabinet.FieldName = "Cabinet";
            this.colCabinet.Name = "colCabinet";
            this.colCabinet.Visible = true;
            this.colCabinet.VisibleIndex = 14;
            // 
            // colRow
            // 
            this.colRow.Caption = "Row";
            this.colRow.FieldName = "Row";
            this.colRow.Name = "colRow";
            this.colRow.Visible = true;
            this.colRow.VisibleIndex = 15;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnHapus);
            this.panelControl1.Controls.Add(this.btnNew);
            this.panelControl1.Controls.Add(this.btnSummaryBelt);
            this.panelControl1.Controls.Add(this.btnSummaryItem);
            this.panelControl1.Controls.Add(this.btnReload);
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1196, 36);
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
            // btnReload
            // 
            this.btnReload.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Appearance.Options.UseFont = true;
            this.btnReload.Location = new System.Drawing.Point(296, 8);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(98, 22);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "&Reload [F5]";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSummaryItem
            // 
            this.btnSummaryItem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummaryItem.Appearance.Options.UseFont = true;
            this.btnSummaryItem.Location = new System.Drawing.Point(400, 8);
            this.btnSummaryItem.Name = "btnSummaryItem";
            this.btnSummaryItem.Size = new System.Drawing.Size(98, 22);
            this.btnSummaryItem.TabIndex = 5;
            this.btnSummaryItem.Text = "Summary &Item";
            this.btnSummaryItem.Click += new System.EventHandler(this.btnSummaryItem_Click);
            // 
            // btnSummaryBelt
            // 
            this.btnSummaryBelt.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummaryBelt.Appearance.Options.UseFont = true;
            this.btnSummaryBelt.Location = new System.Drawing.Point(504, 8);
            this.btnSummaryBelt.Name = "btnSummaryBelt";
            this.btnSummaryBelt.Size = new System.Drawing.Size(98, 22);
            this.btnSummaryBelt.TabIndex = 6;
            this.btnSummaryBelt.Text = "Summary &Belt";
            this.btnSummaryBelt.Click += new System.EventHandler(this.btnSummaryBelt_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Appearance.Options.UseBackColor = true;
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Location = new System.Drawing.Point(982, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 22);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "&Edit [F2]";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHapus.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnHapus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Appearance.Options.UseBackColor = true;
            this.btnHapus.Appearance.Options.UseFont = true;
            this.btnHapus.Location = new System.Drawing.Point(1086, 8);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(98, 22);
            this.btnHapus.TabIndex = 9;
            this.btnHapus.Text = "&Hapus [F4]";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Location = new System.Drawing.Point(878, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(98, 22);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "&Baru [F1]";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmLaporanStokKeluar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 583);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmLaporanStokKeluar";
            this.Text = "Laporan Stok Keluar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLaporanStokKeluar_FormClosing);
            this.Load += new System.EventHandler(this.frmLaporanStokKeluar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stokKeluarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemBelt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemInventor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCategory)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem mnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemUser;
        private System.Windows.Forms.BindingSource stokKeluarBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTanggal;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNo;
        private DevExpress.XtraGrid.Columns.GridColumn colIDBelt;
        private DevExpress.XtraGrid.Columns.GridColumn colPIC;
        private DevExpress.XtraGrid.Columns.GridColumn colIDInventor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemInventor;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUOM;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemUOM;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colKeterangan;
        private DevExpress.XtraGrid.Columns.GridColumn colNamaBarang;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserEntri;
        private DevExpress.XtraGrid.Columns.GridColumn colTglEntri;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colTglEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colIDUserHapus;
        private DevExpress.XtraGrid.Columns.GridColumn colTglHapus;
        private DevExpress.XtraBars.BarButtonItem mnBaru;
        private DevExpress.XtraBars.BarButtonItem mnEdit;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemBelt;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemType;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colIDCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colCabinet;
        private DevExpress.XtraGrid.Columns.GridColumn colRow;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnSummaryBelt;
        private DevExpress.XtraEditors.SimpleButton btnSummaryItem;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnHapus;
        private DevExpress.XtraEditors.SimpleButton btnNew;
    }
}