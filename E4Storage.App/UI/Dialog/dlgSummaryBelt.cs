using DevExpress.XtraEditors;
using DevExpress.Utils;
using System;
using E4Storage.App.Model.Entity;
using E4Storage.App.Utils;
using E4Storage.App.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E4Storage.App.Model.ViewModel;
using AutoMapper;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;

namespace E4Storage.App.UI.Dialog
{
    public partial class dlgSummaryBelt : DevExpress.XtraEditors.XtraUserControl
    {
        private DateTime TglDari, TglSampai;
        public dlgSummaryBelt(DateTime TglDari, DateTime TglSampai)
        {
            InitializeComponent();
            this.TglDari = TglDari;
            this.TglSampai = TglSampai;
        }

        private void IDInventorSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang merefresh data"))
            {
                try
                {
                    var data = Repository.StokKeluar.getStokKeluars(dateEdit1.DateTime, dateEdit2.DateTime);
                    if (data.Item1)
                    {
                        Guid IDBelt = Guid.Empty;
                        Guid.TryParse((IDBeltSearchLookUpEdit.EditValue == null ? "" : IDBeltSearchLookUpEdit.EditValue).ToString(), out IDBelt);
                        this.data = (from x in data.Item2.Where(o => o.IDBelt == IDBelt)
                                     where x.IDBelt != Guid.Empty
                                     group x by new { x.IDInventor, x.NamaBarang, x.IDUOM, Tanggal = x.Tanggal.Date, x.IDBelt } into grp
                                     select new Model
                                     {
                                         NamaBarang = grp.Key.NamaBarang,
                                         IDInventor = grp.Key.IDInventor,
                                         IDUOM = grp.Key.IDUOM,
                                         Tanggal = grp.Key.Tanggal,
                                         IDBelt = grp.Key.IDBelt.GetValueOrDefault(),
                                         Qty = grp.Sum(o => o.Qty)
                                     }).ToList();
                    }
                    gridControl1.DataSource = this.data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.simpleButton1_Click", ex);
                }
            }
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

        private List<Model> data = new List<Model>();
        private class Model
        {
            public DateTime Tanggal { get; set; }
            public Guid IDInventor { get; set; }
            public Guid IDUOM { get; set; }
            public float Qty { get; set; }
            public string NamaBarang { get; set; }
            public Guid IDBelt { get; set; }
            //ViewModel
            public string Periode
            {
                get
                {
                    return (Tanggal == null ? DateTime.Now : Tanggal).ToString("MMMM");
                }
            }
        }

        private void gv1_DatasourceChanged(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, (GridView)sender);
        }

        private void dlgSummaryBelt_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = TglDari;
            dateEdit2.DateTime = TglSampai;
            refreshLookUp();
            simpleButton1.PerformClick();
        }

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
            IDBeltSearchLookUpEdit.Properties.DataSource = lookupBelt;
            IDBeltSearchLookUpEdit.Properties.ValueMember = "ID";
            IDBeltSearchLookUpEdit.Properties.DisplayMember = "Belt";

            var lookUpType = Repository.Item.getTypes();
            if (lookUpType.Item1)
            {
                lookupType = lookUpType.Item2;
            }
            repositoryItemType.DataSource = lookupType;
            repositoryItemType.ValueMember = "ID";
            repositoryItemType.DisplayMember = "Transaksi";

            IDBeltSearchLookUpEdit.Properties.Buttons[1].Visible = Utils.Constant.UserLogin.IsAdmin;
        }

        public void saveLayouts()
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
            Constant.layoutsHelper.SaveLayouts(this.Name, searchLookUpEdit1View);
        }
    }
}
