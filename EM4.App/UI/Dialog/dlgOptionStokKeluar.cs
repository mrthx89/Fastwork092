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

namespace EM4.App.UI.Dialog
{
    public partial class dlgOptionStokKeluar : DevExpress.XtraEditors.XtraUserControl
    {
        public int IDJenis { get; set; } = 0;
        public DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog flyoutDialog { get; set; } = null;

        public dlgOptionStokKeluar()
        {
            InitializeComponent();

            IDJenis = 0;
        }

        private void dlgOptionStokKeluar_Load(object sender, EventArgs e)
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
            IDJenis = 2;
            if (flyoutDialog != null)
            {
                flyoutDialog.DialogResult = DialogResult.OK;
                flyoutDialog.Close();
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            IDJenis = 1;
            if (flyoutDialog != null)
            {
                flyoutDialog.DialogResult = DialogResult.OK;
                flyoutDialog.Close();
            }
        }
    }
}
