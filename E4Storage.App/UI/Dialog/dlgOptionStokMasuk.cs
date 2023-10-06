using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Customization;
using E4Storage.App.Utils;

namespace E4Storage.App.UI.Dialog
{
    public partial class dlgOptionStokMasuk : DevExpress.XtraEditors.XtraUserControl
    {
        public int IDJenis { get; set; } = 0;
        public DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog flyoutDialog { get; set; } = null;

        public dlgOptionStokMasuk()
        {
            InitializeComponent();

            IDJenis = 0;
        }

        private void dlgOptionStokMasuk_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IDJenis = 0;
            if (flyoutDialog != null)
            {
                flyoutDialog.DialogResult = DialogResult.Cancel;
                flyoutDialog.Close();
            }
        }

        private void btnPengembalian_Click(object sender, EventArgs e)
        {
            IDJenis = (int)Constant.TypeTransaction.stokPengembalian;
            if (flyoutDialog != null)
            {
                flyoutDialog.DialogResult = DialogResult.OK;
                flyoutDialog.Close();
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            IDJenis = (int)Constant.TypeTransaction.stokIn;
            if (flyoutDialog != null)
            {
                flyoutDialog.DialogResult = DialogResult.OK;
                flyoutDialog.Close();
            }
        }

        private void btnMasterData_Click(object sender, EventArgs e)
        {
            IDJenis = (int)Constant.TypeTransaction.stokMasterData;
            if (flyoutDialog != null)
            {
                flyoutDialog.DialogResult = DialogResult.OK;
                flyoutDialog.Close();
            }
        }
    }
}
