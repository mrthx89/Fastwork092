using DevExpress.XtraEditors;
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

namespace EM4.App.UI
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length >= 1 && textEdit2.Text.Length >= 1)
            {
                Repository.User.eM4Context.Database.Connection.ConnectionString = Constant.appSetting.KoneksiString;
                var login = Repository.User.getLogin(textEdit1.Text, textEdit2.Text);
                if (login.Item1)
                {
                    Constant.UserLogin = login.Item2;

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        // Jika tombol perlu diaktifkan kembali setelah beberapa waktu
        Timer timer = new Timer();
        private void textEdit2_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // Mendapatkan tombol yang ditekan
            var button = e.Button;

            // Menonaktifkan tombol yang ditekan
            button.Enabled = false;
            textEdit2.Properties.PasswordChar = '\0';

            timer.Interval = 2000; // Durasi dalam milidetik (contoh: 2 detik)
            timer.Tick += (s, args) =>
            {
                button.Enabled = true; // Mengaktifkan tombol kembali
                textEdit2.Properties.PasswordChar = Char.Parse("*");
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}