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
using EM4.App.Helper;
using EM4.App.Utils;
using EM4.App.Repository;
using EM4.App.Model.ViewModel;
using EM4.App.Model.Entity;

namespace EM4.App.UI
{
    public partial class frmEntriStokMasuk : DevExpress.XtraEditors.XtraForm
    {
        private Model.ViewModel.StokMasuk data = null;
        public frmEntriStokMasuk(Model.ViewModel.StokMasuk data)
        {
            InitializeComponent();

            this.data = data;
        }

        private void frmEntriStokMasuk_Load(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, dataLayoutControl1);
            if (data == null)
            {
                data = new Model.ViewModel.StokMasuk()
                {
                    ID = Guid.NewGuid(),
                    IDInventor = Guid.Empty,
                    IDUOM = Guid.Empty,
                    IDUserEdit = Guid.Empty,
                    IDUserEntri = Constant.UserLogin.ID,
                    IDUserHapus = Guid.Empty,
                    Keterangan = "",
                    NamaBarang = "",
                    NoPO = "",
                    NoSJ = "",
                    Qty = 0,
                    Supplier = "",
                    Tanggal = DateTime.Now,
                    TglEdit = DateTime.Parse("1900-01-01"),
                    TglEntri = DateTime.Parse("1900-01-01"),
                    TglHapus = DateTime.Parse("1900-01-01")
                };
            }
            refreshLookUp();
            stokMasukBindingSource.DataSource = data;
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

                    dataLayoutControl1.Validate();
                    this.Validate();

                    dxErrorProvider1.ClearErrors();
                    if (data.IDInventor == Guid.Empty || string.IsNullOrEmpty(data.NamaBarang))
                    {
                        dxErrorProvider1.SetError(IDInventorSearchLookUpEdit, "Kode Barang harus diisi!");
                    }

                    if (data.Qty <= 0)
                    {
                        dxErrorProvider1.SetError(QtyTextEdit, "Qty harus diisi dengan benar!");
                    }


                    if (!dxErrorProvider1.HasErrors)
                    {
                        var save = Repository.StokMasuk.saveStokMasuk(data);
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
                Guid.TryParse(IDInventorSearchLookUpEdit.EditValue.ToString(), out Guid IDInventor);
                var item = itemLookUps.FirstOrDefault(o => o.ID == IDInventor);
                if (item != null)
                {
                    data.IDUOM = item.IDUOM;
                    data.NamaBarang = item.Desc;
                    IDUOMSearchLookUpEdit.EditValue = item.IDUOM;
                    NamaBarangTextEdit.EditValue = item.Desc;
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
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshLookUp", ex);
                }
            }
        }

        private void frmEntriStokMasuk_FOrmClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, searchLookUpEdit1View);
            Constant.layoutsHelper.SaveLayouts(this.Name, dataLayoutControl1);
        }

        private void gv1_DataSourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, searchLookUpEdit1View);
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
    }
}