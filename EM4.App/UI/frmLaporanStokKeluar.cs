using DevExpress.XtraEditors;
using DevExpress.Utils;
using EM4.App.Helper;
using EM4.App.Model.Entity;
using EM4.App.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EM4.App.Model.ViewModel;

namespace EM4.App.UI
{
    public partial class frmLaporanStokKeluar : DevExpress.XtraEditors.XtraForm
    {
        private static Guid stokOutType = Guid.Parse("6652E843-6C01-4CD0-9F9C-5111565D7844");
        private static Guid stokPengembalianType = Guid.Parse("B536F89C-FA4E-4F7B-AFDB-5B323546D10E");

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
                        if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnDelete_ItemClick", $"Yakin ingin menghapus {(CurrentData.IDType == stokOutType ? "stok Keluar" : "pengembalian")} item {CurrentData.NamaBarang} di nomor nota ini {CurrentData.DocNo}?") == DialogResult.Yes)
                        {
                            if (CurrentData.IDType == stokOutType)
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

            mnReload.PerformClick();
        }

        private void gridView1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);
        }

        private void frmLaporanStokKeluar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
        }

        private void mnBaru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialog = new Dialog.flyoutOptionStokKeluar(this, new Dialog.dlgOptionStokKeluar()).ShowFormPopup();
            if (dialog.Item1 == DialogResult.OK && dialog.Item2 == 1)
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
                        EM4.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiStokKeluar_ItemClick", ex);
                    }
                }
            }
            else if (dialog.Item1 == DialogResult.OK && dialog.Item2 == 2)
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
                        EM4.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.bbiStokKeluar_ItemClick", ex);
                    }
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
                    if (data.IDType == stokOutType)
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
    }
}