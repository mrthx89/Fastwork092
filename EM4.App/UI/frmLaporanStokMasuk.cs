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
                        if (MsgBoxHelper.MsgQuestionYesNo($"{this.Name}.mnDelete_ItemClick", $"Yakin ingin menghapus stok masuk item {CurrentData.NamaBarang} di nomor nota ini {CurrentData.NoSJ}?") == DialogResult.Yes)
                        {
                            var delete = Repository.StokMasuk.deleteStokMasuk(CurrentData);
                            if (delete.Item1)
                            {
                                mnReload.PerformClick();
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

        private List<StokMasuk> data = null;
        private dynamic lookupUser = null;
        private dynamic lookupItem = null;
        private dynamic lookupUOM = null;
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

            mnReload.PerformClick();
        }

        private void gridView1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);
        }

        private void frmLaporanStokMasuk_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
        }

        private void mnBaru_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    MsgBoxHelper.MsgError($"{this.Name}.mnBaru_ItemClick", ex);
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
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.mnEdit_ItemClick", ex);
            }
        }
    }
}