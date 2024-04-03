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
    public partial class frmLaporanStokKeluar : DevExpress.XtraEditors.XtraForm
    {
        public frmLaporanStokKeluar()
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

                    var dataGet = Repository.StokKeluar.getStokKeluars(dateEdit1.DateTime, dateEdit2.DateTime);
                    if (dataGet.Item1)
                    {
                        data = dataGet.Item2;
                    }
                    stokKeluarBindingSource.DataSource = data;
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
                    StokKeluar CurrentData = (StokKeluar)stokKeluarBindingSource.Current;
                    if (CurrentData != null)
                    {
                        if (Utils.Constant.UserLogin.IsAdmin)
                        {
                            if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnDelete_ItemClick", $"Yakin ingin menghapus {(CurrentData.IDType == Constant.stokOutType ? "stok Keluar" : "pengembalian")} item {CurrentData.NamaBarang} di nomor nota ini {CurrentData.DocNo}?") == DialogResult.Yes)
                            {
                                if (CurrentData.IDType == Constant.stokOutType)
                                {
                                    var delete = Repository.StokKeluar.deleteStokKeluar(CurrentData);
                                    if (delete.Item1)
                                    {
                                        mnReload.PerformClick();
                                    }
                                }
                                else
                                {
                                    var delete = Repository.StokPengembalian.deleteStokPengembalian(Constant.mapper.Map<Model.ViewModel.StokKeluar, Model.ViewModel.StokPengembalian>(CurrentData));
                                    if (delete.Item1)
                                    {
                                        mnReload.PerformClick();
                                    }
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

        private List<StokKeluar> data = null;
        private dynamic lookupUser = null;
        private dynamic lookupItem = null;
        private dynamic lookupUOM = null;
        private dynamic lookupBelt = null;
        private dynamic lookupType = null;
        private dynamic lookupCategories = null;
        private void frmLaporanStokKeluar_Load(object sender, EventArgs e)
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

            var lookUpBelt = Repository.Item.getBelts();
            if (lookUpBelt.Item1)
            {
                lookupBelt = lookUpBelt.Item2;
            }
            repositoryItemBelt.DataSource = lookupBelt;
            repositoryItemBelt.ValueMember = "ID";
            repositoryItemBelt.DisplayMember = "Belt";

            var lookUpType = Repository.Item.getTypes();
            if (lookUpType.Item1)
            {
                lookupType = lookUpType.Item2;
            }
            repositoryItemType.DataSource = lookupType;
            repositoryItemType.ValueMember = "ID";
            repositoryItemType.DisplayMember = "Transaksi";

            var lookUpCategories = Repository.Item.getCategories();
            if (lookUpCategories.Item1)
            {
                lookupCategories = lookUpCategories.Item2;
            }
            repositoryItemCategory.DataSource = lookupCategories;
            repositoryItemCategory.ValueMember = "ID";
            repositoryItemCategory.DisplayMember = "Category";

            mnReload.PerformClick();
        }

        private void gridView1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, (GridView)sender);
            ((GridView)sender).Tag = "true";
        }

        private void frmLaporanStokKeluar_FormClosing(object sender, FormClosingEventArgs e)
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
            using (frmEntriStokKeluar frm = new frmEntriStokKeluar(null))
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
                    E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiStokKeluar_ItemClick", ex);
                }
            }
        }

        private void mnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var data = (StokKeluar)stokKeluarBindingSource.Current;
                if (data != null)
                {
                    if (Utils.Constant.UserLogin.IsAdmin)
                    {
                        if (data.IDType == Constant.stokOutType)
                        {
                            using (frmEntriStokKeluar frm = new frmEntriStokKeluar(data))
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
                        else
                        {
                            using (frmEntriStokPengembalian frm = new frmEntriStokPengembalian(Constant.mapper.Map<Model.ViewModel.StokKeluar, Model.ViewModel.StokPengembalian>(data)))
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Dialog.flyoutSummaryItem(this, new Dialog.dlgSummaryItem(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date))
                .ShowFormPopup();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Dialog.flyoutSummaryBelt(this, new Dialog.dlgSummaryBelt(dateEdit1.DateTime.Date, dateEdit2.DateTime.Date))
                .ShowFormPopup();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            mnReload.PerformClick();
        }

        private void btnSummaryItem_Click(object sender, EventArgs e)
        {
            barButtonItem1.PerformClick();
        }

        private void btnSummaryBelt_Click(object sender, EventArgs e)
        {
            barButtonItem2.PerformClick();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            mnDelete.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mnEdit.PerformClick();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mnBaru.PerformClick();
        }
    }
}