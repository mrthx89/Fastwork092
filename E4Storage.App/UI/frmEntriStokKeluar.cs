using DevExpress.XtraEditors;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E4Storage.App.Helper;
using E4Storage.App.Utils;
using E4Storage.App.Repository;
using E4Storage.App.Model.ViewModel;
using E4Storage.App.Model.Entity;
using DevExpress.XtraGrid.Views.Grid;

namespace E4Storage.App.UI
{
    public partial class frmEntriStokKeluar : DevExpress.XtraEditors.XtraForm
    {
        public Model.ViewModel.StokKeluar data = null;
        public frmEntriStokKeluar(Model.ViewModel.StokKeluar data)
        {
            InitializeComponent();

            this.data = data;

            this.gridView1.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            this.gridView2.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            this.gridView3.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            this.gridView4.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            this.gvIDCategory.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
        }

        private void frmEntriStokKeluar_Load(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, dataLayoutControl1);
            if (data == null)
            {
                data = new Model.ViewModel.StokKeluar()
                {
                    ID = Guid.NewGuid(),
                    IDInventor = Guid.Empty,
                    IDUOM = Guid.Empty,
                    IDUserEdit = Guid.Empty,
                    IDUserEntri = Constant.UserLogin.ID,
                    IDUserHapus = Guid.Empty,
                    Keterangan = "",
                    NamaBarang = "",
                    DocNo = "",
                    PIC = "",
                    IDBelt = Guid.Empty,
                    Qty = 0,
                    Tanggal = DateTime.Now,
                    TglEdit = DateTime.Parse("1900-01-01"),
                    TglEntri = DateTime.Parse("1900-01-01"),
                    TglHapus = DateTime.Parse("1900-01-01"),
                    Cabinet = 0,
                    IDCategory = Guid.Empty,
                    Row = ""
                };
            }
            else
            {
                data.Saldo = Repository.StokKeluar.getSaldoStok(data.IDInventor, data.Tanggal, data.ID, Constant.TypeTransaction.stokOut).Item2;
            }
            refreshLookUp();
            StokKeluarBindingSource.DataSource = data;
            dataLayoutControl1.Refresh();
        }

        private void mnSimpan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang menyimpan data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

                    data.Saldo = Repository.StokKeluar.getSaldoStok(data.IDInventor, data.Tanggal, data.ID, Constant.TypeTransaction.stokOut).Item2;
                    SaldoTextEdit.EditValue = data.Saldo;

                    dataLayoutControl1.Validate();
                    this.Validate();

                    dxErrorProvider1.ClearErrors();
                    if (data.IDInventor == Guid.Empty || string.IsNullOrEmpty(data.NamaBarang))
                    {
                        dxErrorProvider1.SetError(IDInventorSearchLookUpEdit, "Kode Barang harus diisi!");
                    }

                    if (data.IDBelt == Guid.Empty || string.IsNullOrEmpty(IDBeltSearchLookUpEdit.Text))
                    {
                        dxErrorProvider1.SetError(IDBeltSearchLookUpEdit, "Belt harus diisi!");
                    }

                    if (data.IDCategory == Guid.Empty || string.IsNullOrEmpty(IDCategorySearchLookUpEdit.Text))
                    {
                        dxErrorProvider1.SetError(IDCategorySearchLookUpEdit, "Category harus diisi!");
                    }

                    if (data.Qty <= 0)
                    {
                        dxErrorProvider1.SetError(QtyCalcEdit, "Qty harus diisi dengan benar!");
                    }

                    if (data.Saldo < data.Qty)
                    {
                        var dialog = MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnSimpan_ItemClick",
                                                                   $"Saldo item {data.NamaBarang} ini sebanyak {data.Saldo.ToString("n0")} sedangkan pengeluaran sebanyak {data.Qty.ToString("n0")}, hal ini akan menyebabkan saldo item menjadi minus.{Environment.NewLine}Yakin ingin melanjutkan penyimpanan?",
                                                                   MessageBoxDefaultButton.Button2);
                        if (dialog == DialogResult.No)
                        {
                            dxErrorProvider1.SetError(QtyCalcEdit, "Qty harus diisi dengan benar!");
                        }
                    }

                    if (!dxErrorProvider1.HasErrors)
                    {
                        var save = Repository.StokKeluar.saveStokKeluar(data);
                        if (save.Item1)
                        {
                            this.data = save.Item2;
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        MsgBoxHelper.MsgWarn($"{this.Name}.mnSimpan_ItemClick", string.Join(", ", (from x in dxErrorProvider1.GetControlsWithError()
                                                                                                   select new { errMsg = dxErrorProvider1.GetError(x) }).Select(o => o.errMsg).ToList()));
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnSimpan_ItemClick", ex);
                }
            }
        }

        private void IDInventorSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IDInventorSearchLookUpEdit.EditValue != null)
                {
                    Guid.TryParse(IDInventorSearchLookUpEdit.EditValue.ToString(), out Guid IDInventor);
                    var item = itemLookUps.FirstOrDefault(o => o.ID == IDInventor);
                    if (item != null)
                    {
                        data.IDUOM = item.IDUOM;
                        data.NamaBarang = item.Desc;
                        data.Saldo = Repository.StokKeluar.getSaldoStok(IDInventor, data.Tanggal, data.ID, Constant.TypeTransaction.stokOut).Item2;

                        IDUOMSearchLookUpEdit.EditValue = item.IDUOM;
                        NamaBarangTextEdit.EditValue = item.Desc;
                        SaldoTextEdit.EditValue = data.Saldo;
                    }
                }
                else
                {
                    data.IDUOM = Guid.Empty;
                    data.NamaBarang = "";
                    data.Saldo = 0;

                    IDUOMSearchLookUpEdit.EditValue = data.IDUOM;
                    NamaBarangTextEdit.EditValue = data.NamaBarang;
                    SaldoTextEdit.EditValue = data.Saldo;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.IDInventorSearchLookUpEdit_EditValueChanged", ex);
            }
        }

        private List<ItemLookUp> itemLookUps = new List<ItemLookUp>();
        private void refreshLookUp()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang mengambil data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

                    var callItems = Repository.Item.getLookUpInventors(data.Tanggal, null);
                    if (callItems.Item1)
                    {
                        itemLookUps = callItems.Item2;
                    }
                    else
                    {
                        itemLookUps = new List<ItemLookUp>();
                    }
                    IDInventorSearchLookUpEdit.Properties.DataSource = itemLookUps;
                    IDInventorSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDInventorSearchLookUpEdit.Properties.DisplayMember = "PLU";

                    var call = Repository.Item.getUOMs();
                    if (call.Item1)
                    {
                        IDUOMSearchLookUpEdit.Properties.DataSource = (from x in call.Item2
                                                                       select new { x.ID, x.Satuan }).ToList();
                    }
                    else
                    {
                        IDUOMSearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDUOMSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUOMSearchLookUpEdit.Properties.DisplayMember = "Satuan";

                    var callBelt = Repository.Item.getBelts();
                    if (callBelt.Item1)
                    {
                        IDBeltSearchLookUpEdit.Properties.DataSource = (from x in callBelt.Item2
                                                                        select new { x.ID, x.Belt }).ToList();
                    }
                    else
                    {
                        IDBeltSearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDBeltSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDBeltSearchLookUpEdit.Properties.DisplayMember = "Belt";

                    var callCategories = Repository.Item.getCategories();
                    if (callCategories.Item1)
                    {
                        IDCategorySearchLookUpEdit.Properties.DataSource = (from x in callCategories.Item2
                                                                            select new { x.ID, x.Category }).ToList();
                    }
                    else
                    {
                        IDCategorySearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDCategorySearchLookUpEdit.Properties.ValueMember = "ID";
                    IDCategorySearchLookUpEdit.Properties.DisplayMember = "Category";

                    var callUser = Repository.User.getLookUp();
                    if (callUser.Item1)
                    {
                        IDUserEditSearchLookUpEdit.Properties.DataSource = callUser.Item2;
                        IDUserEntriSearchLookUpEdit.Properties.DataSource = callUser.Item2;
                    }
                    else
                    {
                        IDUserEditSearchLookUpEdit.Properties.DataSource = null;
                        IDUserEntriSearchLookUpEdit.Properties.DataSource = null;
                    }
                    IDUserEntriSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEntriSearchLookUpEdit.Properties.DisplayMember = "Nama";
                    IDUserEditSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEditSearchLookUpEdit.Properties.DisplayMember = "Nama";

                    IDInventorSearchLookUpEdit.Properties.Buttons[1].Visible = Utils.Constant.UserLogin.IsAdmin;
                    IDBeltSearchLookUpEdit.Properties.Buttons[1].Visible = Utils.Constant.UserLogin.IsAdmin;
                    IDCategorySearchLookUpEdit.Properties.Buttons[1].Visible = Utils.Constant.UserLogin.IsAdmin;
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshLookUp", ex);
                }
            }
        }

        private void frmEntriStokKeluar_FOrmClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, dataLayoutControl1);

            saveLayouts(gridView1);
            saveLayouts(gridView2);
            saveLayouts(gridView3);
            saveLayouts(gridView4);
            saveLayouts(searchLookUpEdit1View);
            saveLayouts(gvIDCategory);
        }

        private void saveLayouts(GridView gv1)
        {
            if (gv1.Tag != null && gv1.Tag.ToString() == "true")
                Constant.layoutsHelper.SaveLayouts(this.Name, gv1);
        }

        private void gv1_DataSourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, (GridView)sender);
            ((GridView)sender).Tag = "true";
            if (((GridView)sender).Columns["ID"] != null)
            {
                ((GridView)sender).Columns["ID"].Visible = false;
            }
        }

        private void IDInventorSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmDaftarMasterItem frm = new frmDaftarMasterItem())
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                        refreshLookUp();
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.MsgError($"{this.Name}.IDInventorSearchLookUpEdit_ButtonClick", ex);
                    }
                }
            }
        }

        private void TanggalDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                data.Saldo = Repository.StokKeluar.getSaldoStok(data.IDInventor, TanggalDateEdit.DateTime, data.ID, Constant.TypeTransaction.stokOut).Item2;
                QtyCalcEdit.EditValue = data.Saldo;
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.TanggalDateEdit_EditValueChanged", ex);
            }
        }

        private void IDBeltSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmDaftarBelt frm = new frmDaftarBelt())
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                        refreshLookUp();
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.MsgError($"{this.Name}.IDBeltSearchLookUpEdit_ButtonClick", ex);
                    }
                }
            }
        }

        private void IDCategorySearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmDaftarCategory frm = new frmDaftarCategory())
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                        refreshLookUp();
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.MsgError($"{this.Name}.IDCategorySearchLookUpEdit_ButtonClick", ex);
                    }
                }
            }
        }

        private void mnBatal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mnSimpan.PerformClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mnBatal.PerformClick();
        }
    }
}