using DevExpress.XtraEditors;
using DevExpress.Utils;
using E4Storage.App.Helper;
using E4Storage.App.Model.Entity;
using E4Storage.App.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E4Storage.App.Model.ViewModel;
using DevExpress.XtraGrid.Views.Grid;

namespace E4Storage.App.UI
{
    public partial class frmLaporanStokMasuk : DevExpress.XtraEditors.XtraForm
    {
        public frmLaporanStokMasuk()
        {
            InitializeComponent();
        }

        private void mnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data ..."))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();
                    dlg.Focus();

                    var dataGet = Repository.StokMasuk.getStokMasuks(dateEdit1.DateTime, dateEdit2.DateTime);
                    if (dataGet.Item1)
                    {
                        data = dataGet.Item2;
                    }
                    stokMasukBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnReload_ItemClick", ex);
                }
            }
        }

        private void mnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    StokMasuk CurrentData = (StokMasuk)stokMasukBindingSource.Current;
                    if (CurrentData != null)
                    {
                        if (Utils.Constant.UserLogin.IsAdmin)
                        {
                            if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnDelete_ItemClick", $"Yakin ingin menghapus stok masuk item {CurrentData.NamaBarang} di nomor nota ini {CurrentData.NoSJ}?") == DialogResult.Yes)
                            {
                                var delete = Repository.StokMasuk.deleteStokMasuk(CurrentData);
                                if (delete.Item1)
                                {
                                    mnReload.PerformClick();
                                }
                            }
                        }
                        else
                        {
                            MsgBoxHelper.MsgInfo($"{this.Name}.mnDelete_ItemClick", "Untuk menghapus data harap menghubungi Admin!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.mnDelete_ItemClick", ex);
            }
        }

        private List<StokMasuk> data = null;
        private dynamic lookupUser = null;
        private dynamic lookupItem = null;
        private dynamic lookupUOM = null;
        private dynamic lookupBelt = null;
        private dynamic lookupCategories = null;
        private void frmLaporanStokMasuk_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now.AddDays(-30);
            dateEdit2.DateTime = dateEdit1.DateTime.AddDays(30);

            var lookUp = Repository.User.getLookUp();
            if (lookUp.Item1)
            {
                lookupUser = lookUp.Item2;
            }
            repositoryItemUser.DataSource = lookupUser;
            repositoryItemUser.ValueMember = "ID";
            repositoryItemUser.DisplayMember = "Nama";

            var lookUpItem = Repository.Item.getLookUpInventors(DateTime.Now, null);
            if (lookUpItem.Item1)
            {
                lookupItem = lookUpItem.Item2;
            }
            repositoryItemInventor.DataSource = lookupItem;
            repositoryItemInventor.ValueMember = "ID";
            repositoryItemInventor.DisplayMember = "PLU";

            var lookUpUOM = Repository.Item.getUOMs();
            if (lookUpUOM.Item1)
            {
                lookupUOM = lookUpUOM.Item2;
            }
            repositoryItemUOM.DataSource = lookupUOM;
            repositoryItemUOM.ValueMember = "ID";
            repositoryItemUOM.DisplayMember = "Satuan";

            var lookUpCategories = Repository.Item.getCategories();
            if (lookUpCategories.Item1)
            {
                lookupCategories = lookUpCategories.Item2;
            }
            repositoryItemCategory.DataSource = lookupCategories;
            repositoryItemCategory.ValueMember = "ID";
            repositoryItemCategory.DisplayMember = "Category";

            var lookUpBelt = Repository.Item.getBelts();
            if (lookUpBelt.Item1)
            {
                lookupBelt = lookUpBelt.Item2;
            }
            repositoryItemBelt.DataSource = lookupBelt;
            repositoryItemBelt.ValueMember = "ID";
            repositoryItemBelt.DisplayMember = "Belt";

            mnReload.PerformClick();
        }

        private void gridView1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, (GridView)sender);
            ((GridView)sender).Tag = "true";
        }

        private void frmLaporanStokMasuk_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveLayouts(gridView1);
        }

        private void saveLayouts(GridView gv1)
        {
            if (gv1.Tag != null && gv1.Tag.ToString() == "true")
                Constant.layoutsHelper.SaveLayouts(this.Name, gv1);
        }

        private void mnBaru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialog = new Dialog.flyoutOptionStokMasuk(this, new Dialog.dlgOptionStokMasuk()).ShowFormPopup();
            if (dialog.Item1 == DialogResult.OK && dialog.Item2 == (int)Constant.TypeTransaction.stokIn)
            {
                using (frmEntriStokMasuk frm = new frmEntriStokMasuk(null))
                {
                    try
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            mnReload.PerformClick();

                            gridView1.ClearSelection();
                            gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
                            gridView1.SelectRow(gridView1.FocusedRowHandle);
                        }
                    }
                    catch (Exception ex)
                    {
                        E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.mnBaru_ItemClick", ex);
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
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            mnReload.PerformClick();

                            gridView1.ClearSelection();
                            gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
                            gridView1.SelectRow(gridView1.FocusedRowHandle);
                        }
                    }
                    catch (Exception ex)
                    {
                        E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.mnBaru_ItemClick", ex);
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
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            mnReload.PerformClick();

                            gridView1.ClearSelection();
                            gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
                            gridView1.SelectRow(gridView1.FocusedRowHandle);
                        }
                    }
                    catch (Exception ex)
                    {
                        E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.mnBaru_ItemClick", ex);
                    }
                }
            }
        }

        private void mnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var data = (StokMasuk)stokMasukBindingSource.Current;
                if (data != null)
                {
                    if (Utils.Constant.UserLogin.IsAdmin)
                    {
                        if (data.IDType == Constant.stokInType)
                        {
                            using (frmEntriStokMasuk frm = new frmEntriStokMasuk(data))
                            {
                                try
                                {
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    if (frm.ShowDialog(this) == DialogResult.OK)
                                    {
                                        mnReload.PerformClick();

                                        gridView1.ClearSelection();
                                        gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
                                        gridView1.SelectRow(gridView1.FocusedRowHandle);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
                                }
                            }
                        }
                        else if (data.IDType == Constant.stokPengembalianType)
                        {
                            using (frmEntriStokPengembalian frm = new frmEntriStokPengembalian(Constant.mapper.Map<Model.ViewModel.StokMasuk, Model.ViewModel.StokPengembalian>(data)))
                            {
                                try
                                {
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    if (frm.ShowDialog(this) == DialogResult.OK)
                                    {
                                        mnReload.PerformClick();

                                        gridView1.ClearSelection();
                                        gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
                                        gridView1.SelectRow(gridView1.FocusedRowHandle);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
                                }
                            }
                        }
                        else if (data.IDType == Constant.stokMasterDataType)
                        {
                            using (frmEntriStokMasterData frm = new frmEntriStokMasterData(Constant.mapper.Map<Model.ViewModel.StokMasuk, Model.ViewModel.StokMasterData>(data)))
                            {
                                try
                                {
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    if (frm.ShowDialog(this) == DialogResult.OK)
                                    {
                                        mnReload.PerformClick();

                                        gridView1.ClearSelection();
                                        gridView1.FocusedRowHandle = gridView1.LocateByDisplayText(0, colID, frm.data.ID.ToString());
                                        gridView1.SelectRow(gridView1.FocusedRowHandle);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
                                }
                            }
                        }
                    }
                    else
                    {
                        MsgBoxHelper.MsgInfo($"{this.Name}.mnEdit_ItemClick", "Untuk mengedit data harap menghubungi Admin!");
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
            }
        }

        private void mnSummaryItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Dialog.flyoutSummaryItemMasuk(this, new Dialog.dlgSummaryItemMasuk(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date))
                .ShowFormPopup();
        }

        private void mnSummaryBelt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Dialog.flyoutSummaryBeltMasuk(this, new Dialog.dlgSummaryBeltMasuk(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date))
                .ShowFormPopup();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            mnReload.PerformClick();
        }

        private void btnSummaryItem_Click(object sender, EventArgs e)
        {
            mnSummaryItem.PerformClick();
        }

        private void btnSummaryBelt_Click(object sender, EventArgs e)
        {
            mnSummaryBelt.PerformClick();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mnBaru.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mnEdit.PerformClick();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            mnDelete.PerformClick();
        }
    }
}