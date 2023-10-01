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
    public partial class frmEntriItem : DevExpress.XtraEditors.XtraForm
    {
        public ItemMaster data;
        public frmEntriItem(ItemMaster data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void frmEntriItem_Load(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, dataLayoutControl1);
            refreshLookUp();
            if (data == null)
            {
                //Create Baru
                data = new ItemMaster
                {
                    ID = Guid.NewGuid(),
                    Desc = "",
                    PLU = "",
                    IDUOM = Guid.Empty,
                    IDUserEdit = Guid.Empty,
                    IDUserEntri = Constant.UserLogin.ID,
                    IDUserHapus = Guid.Empty,
                    Saldo = 0.0,
                    TglEdit = DateTime.Parse("1900-01-01"),
                    TglEntri = DateTime.Now,
                    TglHapus = DateTime.Parse("1900-01-01")
                };
            }
            itemMasterBindingSource.DataSource = data;
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
                    var check1 = Repository.Item.checkPLUExistsInventor(data);
                    if (!check1.Item1)
                    {
                        dxErrorProvider1.SetError(PLUTextEdit, "Kode Barang ini sudah dipakai!");
                    }
                    check1 = Repository.Item.checkNamaExistsInventor(data);
                    if (!check1.Item1)
                    {
                        dxErrorProvider1.SetError(DescTextEdit, "Nama Barang ini sudah dipakai!");
                    }

                    if (!dxErrorProvider1.HasErrors)
                    {
                        var save = Repository.Item.saveInventor(data);
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

        private void frmEntriItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, dataLayoutControl1);
            Constant.layoutsHelper.SaveLayouts(this.Name, searchLookUpEdit1View);
        }

        private void gv1_DataSourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, searchLookUpEdit1View);
        }

        private void IDUOMSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void IDUOMSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                lookUpSatuan();
            }
        }

        private void lookUpSatuan()
        {
            using (frmDaftarSatuan frm = new frmDaftarSatuan())
            {
                try
                {
                    frm.ShowDialog(this);
                    refreshLookUp();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.lookUpSatuan", ex);
                }
            }
        }

        private void refreshLookUp()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang mengambil data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

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
    }
}