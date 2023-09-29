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

namespace EM4.App.UI
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        public Model.AppSetting AppSetting;
        public frmSetting(Model.AppSetting AppSetting)
        {
            InitializeComponent();

            this.AppSetting = AppSetting;
        }

        private void mnSimpan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Data.EM4Context context = new Data.EM4Context(AppSetting.KoneksiString))
            {
                try
                {
                    this.Validate();
                    
                    context.Database.Connection.Open();
                    EM4.App.Helper.MsgBoxHelper.MsgInfo($"{this.Name}.mnSimpan_ItemClick", "Koneksi terhubung!");

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    EM4.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.mnSimpan_ItemClick", ex);
                }
            }
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            appSettingBindingSource.DataSource = AppSetting;
        }
    }
}