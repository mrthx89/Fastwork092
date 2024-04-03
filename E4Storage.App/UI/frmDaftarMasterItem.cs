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
    public partial class frmDaftarMasterItem : DevExpress.XtraEditors.XtraForm
    {
        public frmDaftarMasterItem()
        {
            InitializeComponent();
        }

        private void mnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshData();
        }

        private void frmDaftarMasterItem_Load(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, dataLayoutControl1);
            mnRefresh.PerformClick();
        }

        private void frmDaftarMasterItem_FormCLossing(object sender, FormClosingEventArgs e)
        {
            saveLayouts(gridView1);
            saveLayouts(gridView2);
            saveLayouts(gridView3);
            saveLayouts(gridView4);
            saveLayouts(searchLookUpEdit1View);
            Constant.layoutsHelper.SaveLayouts(this.Name, dataLayoutControl1);
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

        private void saveLayouts(GridView gv1)
        {
            if (gv1.Tag != null && gv1.Tag.ToString() == "true")
                Constant.layoutsHelper.SaveLayouts(this.Name, gv1);
        }

        private void mnBaru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addOrEdit(null);
        }

        private void mnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var item = (ItemMaster)tInventorBindingSource.Current;
                if (item != null)
                {
                    addOrEdit(item);
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
            }
        }

        private void addOrEdit(ItemMaster data)
        {
            //using (frmEntriItem frm = new frmEntriItem(data))
            //{
            //    try
            //    {
            //        if (frm.ShowDialog(this) == DialogResult.OK)
            //        {
            //            mnRefresh.PerformClick();

            //            gridView1.ClearSelection();
            //            gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
            //            gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
            //            gridView1.SelectRow(gridView1.FocusedRowHandle);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MsgBoxHelper.MsgError($"{this.Name}.mnBaru_ItemClick", ex);
            //    }
            //}
            if (data == null)
            {
                tInventorCurrentBindingSource.DataSource = new ItemMaster
                {
                    ID = Guid.NewGuid(),
                    TglEntri = DateTime.Now,
                    IDUserEntri = Utils.Constant.UserLogin.ID,
                    Desc = "",
                    PLU = "",
                    QtyMin = 0.0,
                    QtyMax = 0.0,
                    Saldo = 0.0,
                    IDUOM = Guid.Empty,
                    IDUserEdit = Guid.Empty,
                    IDUserHapus = Guid.Empty,
                    TglEdit = DateTime.Parse("1900-01-01"),
                    TglHapus = DateTime.Parse("1900-01-01")
                };
            }
            else
            {
                tInventorCurrentBindingSource.DataSource = JSONHelper.CloneObject<ItemMaster>(data);
            }
            dataLayoutControl1.Refresh();
            PLUTextEdit.Focus();
        }

        private void mnHapus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var item = (ItemMaster)tInventorBindingSource.Current;
                if (item != null)
                {
                    if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnHapus_ItemClick", $"Yakin ingin menghapus item {item.Desc} ini?") == DialogResult.Yes)
                    {
                        var delete = Repository.Item.deleteInventor(item.ID);
                        if (delete.Item1)
                        {
                            mnRefresh.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.refreshData", ex);
            }
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, (GridView)sender);
            ((GridView)sender).Tag = "true";
        }

        private void refreshLookUp()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data"))
            {
                try
                {
                    var callUOM = Repository.Item.getUOMs();
                    repositoryItemUOM.DataSource = (callUOM.Item1 ? callUOM.Item2 : new List<TUOM>());
                    repositoryItemUOM.ValueMember = "ID";
                    repositoryItemUOM.DisplayMember = "Satuan";

                    IDUOMSearchLookUpEdit.Properties.DataSource = (from x in (callUOM.Item1 ? callUOM.Item2 : new List<TUOM>())
                                                                   select new { x.ID, x.Satuan }).ToList();
                    IDUOMSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUOMSearchLookUpEdit.Properties.DisplayMember = "Satuan";

                    var callUser = Repository.User.getLookUp();
                    repositoryItemUser.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    repositoryItemUser.ValueMember = "ID";
                    repositoryItemUser.DisplayMember = "Nama";

                    IDUserEntriSearchLookUpEdit.Properties.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    IDUserEntriSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEntriSearchLookUpEdit.Properties.DisplayMember = "Nama";
                    IDUserEditSearchLookUpEdit.Properties.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    IDUserEditSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserEditSearchLookUpEdit.Properties.DisplayMember = "Nama";
                    IDUserHapusSearchLookUpEdit.Properties.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    IDUserHapusSearchLookUpEdit.Properties.ValueMember = "ID";
                    IDUserHapusSearchLookUpEdit.Properties.DisplayMember = "Nama";
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshData", ex);
                }
            }
        }

        private List<ItemMaster> data = new List<ItemMaster>();
        private void refreshData()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data"))
            {
                try
                {
                    refreshLookUp();

                    var call = Repository.Item.getInventors(null, null);
                    if (call.Item1)
                    {
                        data = call.Item2;
                    }
                    tInventorBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.refreshData", ex);
                }
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            // Access the underlying data object for the current row
            ItemMaster rowData = gridView1.GetRow(e.RowHandle) as ItemMaster;
            // Check the condition based on your requirements
            if (rowData != null && rowData.QtyMax.GetValueOrDefault() > 0 && rowData.QtyMin.GetValueOrDefault() > 0 &&
                (rowData.Saldo >= rowData.QtyMax.GetValueOrDefault() || rowData.Saldo <= rowData.QtyMin.GetValueOrDefault()))
            {
                // Set the appearance for the current row
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void PLUTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void PLUTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && PLUTextEdit.Text.Length > 1)
            {
                var curData = data.FirstOrDefault(o => o.PLU.Equals(PLUTextEdit.Text));
                if (curData != null)
                {
                    gridView1.ClearSelection();
                    gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, curData.ID.ToString());
                    gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
                    gridView1.SelectRow(gridView1.FocusedRowHandle);
                    addOrEdit((ItemMaster)tInventorBindingSource.Current);
                }
                Application.DoEvents();
            }
        }

        private void IDUOMSearchLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                lookUpSatuan();
            }
        }

        private void mnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ItemMaster currentData = null;
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang menyimpan data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

                    tInventorCurrentBindingSource.EndEdit();
                    currentData = (ItemMaster)tInventorCurrentBindingSource.Current;
                    dataLayoutControl1.Validate();
                    this.Validate();

                    dxErrorProvider1.ClearErrors();
                    if (currentData == null)
                    {
                        dxErrorProvider1.SetError(PLUTextEdit, "Clik Baru dahulu untuk menambahkan item baru!");
                        MsgBoxHelper.MsgWarn($"{this.Name}.mnSimpan_ItemClick", string.Join(", ", (from x in dxErrorProvider1.GetControlsWithError()
                                                                                                   select new { errMsg = dxErrorProvider1.GetError(x) }).Select(o => o.errMsg).ToList()));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(currentData.PLU) || string.IsNullOrWhiteSpace(currentData.PLU))
                        {
                            dxErrorProvider1.SetError(PLUTextEdit, "Kode Barang harus diisi!");
                        }
                        var check1 = Repository.Item.checkPLUExistsInventor(currentData);
                        if (!check1.Item1)
                        {
                            dxErrorProvider1.SetError(PLUTextEdit, "Kode Barang ini sudah dipakai!");
                        }
                        if (string.IsNullOrEmpty(currentData.Desc) || string.IsNullOrWhiteSpace(currentData.Desc))
                        {
                            dxErrorProvider1.SetError(DescTextEdit, "Nama Barang harus diisi!");
                        }
                        check1 = Repository.Item.checkNamaExistsInventor(currentData);
                        if (!check1.Item1)
                        {
                            dxErrorProvider1.SetError(DescTextEdit, "Nama Barang ini sudah dipakai!");
                        }
                        if (currentData.IDUOM == Guid.Empty)
                        {
                            dxErrorProvider1.SetError(IDUOMSearchLookUpEdit, "Satuan harus diisi!");
                        }

                        if (currentData.QtyMax < currentData.QtyMin)
                        {
                            dxErrorProvider1.SetError(DescTextEdit, "Qty maksimum harus diatas qty minimum!");
                        }

                        if (!dxErrorProvider1.HasErrors)
                        {
                            var save = Repository.Item.saveInventor(currentData);
                            if (save.Item1)
                            {
                                currentData = save.Item2;

                                refreshData();
                                gridView1.ClearSelection();
                                gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, currentData.ID.ToString());
                                gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
                                gridView1.SelectRow(gridView1.FocusedRowHandle);
                            }
                        }
                        else
                        {
                            MsgBoxHelper.MsgWarn($"{this.Name}.mnSimpan_ItemClick", string.Join(", ", (from x in dxErrorProvider1.GetControlsWithError()
                                                                                                       select new { errMsg = dxErrorProvider1.GetError(x) }).Select(o => o.errMsg).ToList()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnSimpan_ItemClick", ex);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mnBaru.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mnSave.PerformClick();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            mnHapus.PerformClick();
        }

        private void mnBatal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tInventorCurrentBindingSource.CancelEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mnBatal.PerformClick();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                try
                {
                    addOrEdit((ItemMaster)tInventorBindingSource.Current);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.gridView1_RowClick", ex);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            mnRefresh.PerformClick();
        }
    }
}