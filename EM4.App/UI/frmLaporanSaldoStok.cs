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
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);
        }

        private void frmLaporanSaldoStok_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
        }
    }
}