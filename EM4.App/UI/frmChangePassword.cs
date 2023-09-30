using DevExpress.XtraEditors;
using EM4.App.Helper;
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
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public string PasswordBaru = "";
        private string PasswordLama = "";
        public frmChangePassword(string PasswordLama)
        {
            InitializeComponent();

            this.PasswordLama = PasswordLama;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dxErrorProvider1.ClearErrors();

            if (!string.IsNullOrEmpty(this.PasswordLama) && string.IsNullOrEmpty(txtPassLama.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtPassLama, "Password lama harus diisi");
            }

            if (string.IsNullOrEmpty(txtPassBaru.Text.Trim()))
            {
                dxErrorProvider1.SetError(txtPassBaru, "Password baru harus diisi");
            }

            if (txtPassBaru.Text != txtRePassBaru.Text)
            {
                dxErrorProvider1.SetError(txtRePassBaru, "Password baru belum sesuai");
            }

            if (!string.IsNullOrEmpty(this.PasswordLama) && (Repository.Utils.GetHash(txtPassLama.Text.ToUpper()) != PasswordLama || (PasswordLama ?? "") == txtPassLama.Text))
            {
                dxErrorProvider1.SetError(txtPassLama, "Password lama yang anda isikan salah!");
            }

            if (!dxErrorProvider1.HasErrors)
            {
                this.PasswordBaru = Repository.Utils.GetHash(txtPassBaru.Text.ToUpper());
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MsgBoxHelper.MsgWarn($"{this.Name}.barButtonItem1_ItemClick", string.Join(", ", (from x in dxErrorProvider1.GetControlsWithError()
                                                                                                 select new { errMsg = dxErrorProvider1.GetError(x) }).Select(o => o.errMsg).ToList()));
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}