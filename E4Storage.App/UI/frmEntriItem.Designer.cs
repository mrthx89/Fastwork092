
namespace E4Storage.App.UI
{
    partial class frmEntriItem
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
            this.mnSimpan = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.PLUTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.itemMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DescTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TglEntriDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.TglEditDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.IDUOMSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDUserEntriSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDUserEditSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPLU = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDesc = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIDUOM = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIDUserEntri = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTglEntri = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIDUserEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTglEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PLUTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUOMSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEntriSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEditSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPLU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEntri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEntri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
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
            this.mnSimpan});
            this.barManager1.MaxItemId = 1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnSimpan)});
            this.bar1.Text = "Tools";
            // 
            // mnSimpan
            // 
            this.mnSimpan.Caption = "&Simpan [F6]";
            this.mnSimpan.Id = 0;
            this.mnSimpan.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            this.mnSimpan.Name = "mnSimpan";
            this.mnSimpan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnSimpan_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(325, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 235);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(325, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 215);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(325, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 215);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.PLUTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DescTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TglEntriDateEdit);
            this.dataLayoutControl1.Controls.Add(this.TglEditDateEdit);
            this.dataLayoutControl1.Controls.Add(this.IDUOMSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.IDUserEntriSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.IDUserEditSearchLookUpEdit);
            this.dataLayoutControl1.DataSource = this.itemMasterBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 20);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(325, 215);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // PLUTextEdit
            // 
            this.PLUTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemMasterBindingSource, "PLU", true));
            this.PLUTextEdit.EnterMoveNextControl = true;
            this.PLUTextEdit.Location = new System.Drawing.Point(76, 12);
            this.PLUTextEdit.MenuManager = this.barManager1;
            this.PLUTextEdit.Name = "PLUTextEdit";
            this.PLUTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.PLUTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PLUTextEdit.Size = new System.Drawing.Size(237, 20);
            this.PLUTextEdit.StyleController = this.dataLayoutControl1;
            this.PLUTextEdit.TabIndex = 4;
            // 
            // itemMasterBindingSource
            // 
            this.itemMasterBindingSource.DataSource = typeof(E4Storage.App.Model.ViewModel.ItemMaster);
            // 
            // DescTextEdit
            // 
            this.DescTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemMasterBindingSource, "Desc", true));
            this.DescTextEdit.EnterMoveNextControl = true;
            this.DescTextEdit.Location = new System.Drawing.Point(76, 36);
            this.DescTextEdit.MenuManager = this.barManager1;
            this.DescTextEdit.Name = "DescTextEdit";
            this.DescTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DescTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DescTextEdit.Size = new System.Drawing.Size(237, 20);
            this.DescTextEdit.StyleController = this.dataLayoutControl1;
            this.DescTextEdit.TabIndex = 5;
            // 
            // TglEntriDateEdit
            // 
            this.TglEntriDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemMasterBindingSource, "TglEntri", true));
            this.TglEntriDateEdit.EditValue = null;
            this.TglEntriDateEdit.EnterMoveNextControl = true;
            this.TglEntriDateEdit.Location = new System.Drawing.Point(76, 108);
            this.TglEntriDateEdit.MenuManager = this.barManager1;
            this.TglEntriDateEdit.Name = "TglEntriDateEdit";
            this.TglEntriDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.TglEntriDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEntriDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEntriDateEdit.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm:ss";
            this.TglEntriDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.TglEntriDateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TglEntriDateEdit.Properties.ReadOnly = true;
            this.TglEntriDateEdit.Size = new System.Drawing.Size(237, 20);
            this.TglEntriDateEdit.StyleController = this.dataLayoutControl1;
            this.TglEntriDateEdit.TabIndex = 8;
            // 
            // TglEditDateEdit
            // 
            this.TglEditDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemMasterBindingSource, "TglEdit", true));
            this.TglEditDateEdit.EditValue = null;
            this.TglEditDateEdit.EnterMoveNextControl = true;
            this.TglEditDateEdit.Location = new System.Drawing.Point(76, 156);
            this.TglEditDateEdit.MenuManager = this.barManager1;
            this.TglEditDateEdit.Name = "TglEditDateEdit";
            this.TglEditDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.TglEditDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEditDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TglEditDateEdit.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm:ss";
            this.TglEditDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.TglEditDateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TglEditDateEdit.Properties.ReadOnly = true;
            this.TglEditDateEdit.Size = new System.Drawing.Size(237, 20);
            this.TglEditDateEdit.StyleController = this.dataLayoutControl1;
            this.TglEditDateEdit.TabIndex = 10;
            // 
            // IDUOMSearchLookUpEdit
            // 
            this.IDUOMSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemMasterBindingSource, "IDUOM", true));
            this.IDUOMSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDUOMSearchLookUpEdit.Location = new System.Drawing.Point(76, 60);
            this.IDUOMSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDUOMSearchLookUpEdit.Name = "IDUOMSearchLookUpEdit";
            this.IDUOMSearchLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.IDUOMSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.IDUOMSearchLookUpEdit.Properties.NullText = "";
            this.IDUOMSearchLookUpEdit.Properties.PopupView = this.searchLookUpEdit1View;
            this.IDUOMSearchLookUpEdit.Size = new System.Drawing.Size(237, 20);
            this.IDUOMSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDUOMSearchLookUpEdit.TabIndex = 11;
            this.IDUOMSearchLookUpEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.IDUOMSearchLookUpEdit_ButtonClick);
            this.IDUOMSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.IDUOMSearchLookUpEdit_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            // 
            // IDUserEntriSearchLookUpEdit
            // 
            this.IDUserEntriSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemMasterBindingSource, "IDUserEntri", true));
            this.IDUserEntriSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDUserEntriSearchLookUpEdit.Location = new System.Drawing.Point(76, 84);
            this.IDUserEntriSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDUserEntriSearchLookUpEdit.Name = "IDUserEntriSearchLookUpEdit";
            this.IDUserEntriSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDUserEntriSearchLookUpEdit.Properties.NullText = "";
            this.IDUserEntriSearchLookUpEdit.Properties.PopupView = this.gridView1;
            this.IDUserEntriSearchLookUpEdit.Properties.ReadOnly = true;
            this.IDUserEntriSearchLookUpEdit.Size = new System.Drawing.Size(237, 20);
            this.IDUserEntriSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDUserEntriSearchLookUpEdit.TabIndex = 12;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // IDUserEditSearchLookUpEdit
            // 
            this.IDUserEditSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemMasterBindingSource, "IDUserEdit", true));
            this.IDUserEditSearchLookUpEdit.EnterMoveNextControl = true;
            this.IDUserEditSearchLookUpEdit.Location = new System.Drawing.Point(76, 132);
            this.IDUserEditSearchLookUpEdit.MenuManager = this.barManager1;
            this.IDUserEditSearchLookUpEdit.Name = "IDUserEditSearchLookUpEdit";
            this.IDUserEditSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDUserEditSearchLookUpEdit.Properties.NullText = "";
            this.IDUserEditSearchLookUpEdit.Properties.PopupView = this.gridView2;
            this.IDUserEditSearchLookUpEdit.Properties.ReadOnly = true;
            this.IDUserEditSearchLookUpEdit.Size = new System.Drawing.Size(237, 20);
            this.IDUserEditSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.IDUserEditSearchLookUpEdit.TabIndex = 13;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(325, 215);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPLU,
            this.ItemForDesc,
            this.ItemForIDUOM,
            this.ItemForIDUserEntri,
            this.ItemForTglEntri,
            this.ItemForIDUserEdit,
            this.ItemForTglEdit});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(305, 195);
            // 
            // ItemForPLU
            // 
            this.ItemForPLU.Control = this.PLUTextEdit;
            this.ItemForPLU.Location = new System.Drawing.Point(0, 0);
            this.ItemForPLU.Name = "ItemForPLU";
            this.ItemForPLU.Size = new System.Drawing.Size(305, 24);
            this.ItemForPLU.Text = "Kode Barang";
            this.ItemForPLU.TextSize = new System.Drawing.Size(61, 13);
            // 
            // ItemForDesc
            // 
            this.ItemForDesc.Control = this.DescTextEdit;
            this.ItemForDesc.Location = new System.Drawing.Point(0, 24);
            this.ItemForDesc.Name = "ItemForDesc";
            this.ItemForDesc.Size = new System.Drawing.Size(305, 24);
            this.ItemForDesc.Text = "Nama";
            this.ItemForDesc.TextSize = new System.Drawing.Size(61, 13);
            // 
            // ItemForIDUOM
            // 
            this.ItemForIDUOM.Control = this.IDUOMSearchLookUpEdit;
            this.ItemForIDUOM.Location = new System.Drawing.Point(0, 48);
            this.ItemForIDUOM.Name = "ItemForIDUOM";
            this.ItemForIDUOM.Size = new System.Drawing.Size(305, 24);
            this.ItemForIDUOM.Text = "Satuan";
            this.ItemForIDUOM.TextSize = new System.Drawing.Size(61, 13);
            // 
            // ItemForIDUserEntri
            // 
            this.ItemForIDUserEntri.Control = this.IDUserEntriSearchLookUpEdit;
            this.ItemForIDUserEntri.Location = new System.Drawing.Point(0, 72);
            this.ItemForIDUserEntri.Name = "ItemForIDUserEntri";
            this.ItemForIDUserEntri.Size = new System.Drawing.Size(305, 24);
            this.ItemForIDUserEntri.Text = "ID User Entri";
            this.ItemForIDUserEntri.TextSize = new System.Drawing.Size(61, 13);
            // 
            // ItemForTglEntri
            // 
            this.ItemForTglEntri.Control = this.TglEntriDateEdit;
            this.ItemForTglEntri.Location = new System.Drawing.Point(0, 96);
            this.ItemForTglEntri.Name = "ItemForTglEntri";
            this.ItemForTglEntri.Size = new System.Drawing.Size(305, 24);
            this.ItemForTglEntri.Text = "Tgl Entri";
            this.ItemForTglEntri.TextSize = new System.Drawing.Size(61, 13);
            // 
            // ItemForIDUserEdit
            // 
            this.ItemForIDUserEdit.Control = this.IDUserEditSearchLookUpEdit;
            this.ItemForIDUserEdit.Location = new System.Drawing.Point(0, 120);
            this.ItemForIDUserEdit.Name = "ItemForIDUserEdit";
            this.ItemForIDUserEdit.Size = new System.Drawing.Size(305, 24);
            this.ItemForIDUserEdit.Text = "ID User Edit";
            this.ItemForIDUserEdit.TextSize = new System.Drawing.Size(61, 13);
            // 
            // ItemForTglEdit
            // 
            this.ItemForTglEdit.Control = this.TglEditDateEdit;
            this.ItemForTglEdit.Location = new System.Drawing.Point(0, 144);
            this.ItemForTglEdit.Name = "ItemForTglEdit";
            this.ItemForTglEdit.Size = new System.Drawing.Size(305, 51);
            this.ItemForTglEdit.Text = "Tgl Edit";
            this.ItemForTglEdit.TextSize = new System.Drawing.Size(61, 13);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // frmEntriItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 235);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmEntriItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entri Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntriItem_FormClosing);
            this.Load += new System.EventHandler(this.frmEntriItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PLUTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEntriDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TglEditDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUOMSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEntriSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDUserEditSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPLU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEntri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEntri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIDUserEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTglEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
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
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraBars.BarButtonItem mnSimpan;
        private DevExpress.XtraEditors.TextEdit PLUTextEdit;
        private System.Windows.Forms.BindingSource itemMasterBindingSource;
        private DevExpress.XtraEditors.TextEdit DescTextEdit;
        private DevExpress.XtraEditors.DateEdit TglEntriDateEdit;
        private DevExpress.XtraEditors.DateEdit TglEditDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPLU;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDesc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDUOM;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDUserEntri;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTglEntri;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIDUserEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTglEdit;
        private DevExpress.XtraEditors.SearchLookUpEdit IDUOMSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit IDUserEntriSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit IDUserEditSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}