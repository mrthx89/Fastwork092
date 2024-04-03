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
    public partial class frmLaporanMutasiStok : DevExpress.XtraEditors.XtraForm
    {
        public frmLaporanMutasiStok()
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

                    var dataGet = Repository.Report.getMutasiStoks(dateEdit1.DateTime, dateEdit2.DateTime);
                    if (dataGet.Item1)
                    {
                        data = dataGet.Item2;
                    }
                    MutasiStokBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnReload_ItemClick", ex);
                }
            }
        }

        private List<MutasiStok> data = null;
        private dynamic lookupUser = null;
        private dynamic lookupItem = null;
        private dynamic lookupUOM = null;
        private dynamic lookupBelt = null;
        private dynamic lookupType = null;
        private void frmLaporanMutasiStok_Load(object sender, EventArgs e)
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
            Constant.layoutsHelper.RestoreLayouts(this.Name, (GridView)sender);
            ((GridView)sender).Tag = "true";
        }

        private void frmLaporanMutasiStok_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveLayouts(gridView1);
        }

        private void saveLayouts(GridView gv1)
        {
            if (gv1.Tag != null && gv1.Tag.ToString() == "true")
                Constant.layoutsHelper.SaveLayouts(this.Name, gv1);
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            // Access the underlying data object for the current row
            MutasiStok rowData = gridView1.GetRow(e.RowHandle) as MutasiStok;
            // Check the condition based on your requirements
            if (rowData != null && rowData.QtyMax > 0 && rowData.QtyMin > 0 &&
                (rowData.SaldoAkhir >= rowData.QtyMax || rowData.SaldoAkhir <= rowData.QtyMin))
            {
                // Set the appearance for the current row
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            mnReload.PerformClick();
        }
    }
}