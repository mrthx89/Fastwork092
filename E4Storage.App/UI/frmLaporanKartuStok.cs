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

namespace E4Storage.App.UI
{
    public partial class frmLaporanKartuStok : DevExpress.XtraEditors.XtraForm
    {
        public frmLaporanKartuStok()
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
                    Guid IDInventor;
                    Guid.TryParse((IDInventorSearchLookUpEdit.EditValue ?? "").ToString(), out IDInventor);
                    var dataGet = Repository.Report.getKartuStoks(IDInventor, dateEdit1.DateTime, dateEdit2.DateTime);
                    if (dataGet.Item1)
                    {
                        data = dataGet.Item2;
                    }
                    else
                    {
                        data = new List<KartuStok>();
                    }
                    KartuStokBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnReload_ItemClick", ex);
                }
                finally
                {
                    lbSaldoAwal.Text = "Stok Awal : " + (data.FirstOrDefault() != null ? data.FirstOrDefault().SaldoAkhir : 0.0).ToString("n0");
                    lbQtyMasuk.Text = "Stok Masuk : " + data.Sum(o => o.QtyMasuk).ToString("n0");
                    lbQtyKeluar.Text = "Stok Keluar : " + data.Sum(o => o.QtyKeluar).ToString("n0");
                    lbSaldoAkhir.Text = "Stok Akhir : " + (data.LastOrDefault() != null ? data.LastOrDefault().SaldoAkhir : 0.0).ToString("n0");
                }
            }
        }

        private List<KartuStok> data = null;
        private dynamic lookupUser = null;
        private dynamic lookupItem = null;
        private dynamic lookupUOM = null;
        private dynamic lookupBelt = null;
        private dynamic lookupType = null;
        private void refreshLookUp()
        {
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
            IDInventorSearchLookUpEdit.Properties.DataSource = lookupItem;
            IDInventorSearchLookUpEdit.Properties.ValueMember = "ID";
            IDInventorSearchLookUpEdit.Properties.DisplayMember = "Desc";

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
        }
        private void frmLaporanKartuStok_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now.AddDays(-30);
            dateEdit2.DateTime = dateEdit1.DateTime.AddDays(30);

            refreshLookUp();
            mnReload.PerformClick();
        }

        private void gridView1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);

            gridView1.ClearFindFilter();
            gridView1.ClearColumnsFilter();
            gridView1.ClearSorting();
        }

        private void frmLaporanKartuStok_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
            Constant.layoutsHelper.SaveLayouts(this.Name, searchLookUpEdit1View);
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

        private void gv1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, searchLookUpEdit1View);
        }
    }
}