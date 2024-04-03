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
    public partial class frmLaporanSaldoStok : DevExpress.XtraEditors.XtraForm
    {
        public frmLaporanSaldoStok()
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

                    var dataGet = Repository.Item.getInventors(null, dateEdit1.DateTime);
                    if (dataGet.Item1)
                    {
                        data = dataGet.Item2;
                    }
                    tInventorBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnReload_ItemClick", ex);
                }
            }
        }

        private List<ItemMaster> data = null;
        private dynamic lookupUser = null;
        private dynamic lookupUOM = null;
        private void frmLaporanSaldoStok_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;

            var lookUp = Repository.User.getLookUp();
            if (lookUp.Item1)
            {
                lookupUser = lookUp.Item2;
            }
            repositoryItemUser.DataSource = lookupUser;
            repositoryItemUser.ValueMember = "ID";
            repositoryItemUser.DisplayMember = "Nama";

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
            Constant.layoutsHelper.RestoreLayouts(this.Name, (GridView)sender);
            ((GridView)sender).Tag = "true";
        }

        private void frmLaporanSaldoStok_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            mnReload.PerformClick();
        }
    }
}