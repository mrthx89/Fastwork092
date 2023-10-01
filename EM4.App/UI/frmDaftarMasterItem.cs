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
            mnRefresh.PerformClick();
        }

        private void frmDaftarMasterItem_FormCLossing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
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
            using (frmEntriItem frm = new frmEntriItem(data))
            {
                try
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        mnRefresh.PerformClick();

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
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);
        }

        private List<ItemMaster> data = new List<ItemMaster>();
        private void refreshData()
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data"))
            {
                try
                {
                    var callUOM = Repository.Item.getUOMs();
                    repositoryItemUOM.DataSource = (callUOM.Item1 ? callUOM.Item2 : new List<TUOM>());
                    repositoryItemUOM.ValueMember = "ID";
                    repositoryItemUOM.DisplayMember = "Satuan";

                    var callUser = Repository.User.getLookUp();
                    repositoryItemUser.DataSource = (callUser.Item1 ? callUser.Item2 : null);
                    repositoryItemUser.ValueMember = "ID";
                    repositoryItemUser.DisplayMember = "Nama";

                    var call = Repository.Item.getInventors(null);
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
    }
}