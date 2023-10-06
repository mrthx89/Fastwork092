using DevExpress.XtraEditors;
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

namespace E4Storage.App.UI
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void repairKoneksi()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            using (DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Initialisasi database"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();

                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";

                    dlg.Caption = "Stoping Service";
                    Application.DoEvents();
                    startInfo.Arguments = $"/C SQLLocalDB STOP MSSQLLocalDB";
                    process.StartInfo = startInfo;
                    process.StartInfo.ErrorDialog = true;
                    process.Start();
                    while (!process.HasExited)
                    {
                        Application.DoEvents();
                    }

                    dlg.Caption = "Deleting Instance Name";
                    Application.DoEvents();
                    //Delete Instance MSSQLLocalDB
                    startInfo.Arguments = $"/C SQLLocalDB DELETE MSSQLLocalDB";
                    process.StartInfo = startInfo;
                    process.StartInfo.ErrorDialog = true;
                    process.Start();
                    while (!process.HasExited)
                    {
                        Application.DoEvents();
                    }

                    dlg.Caption = "Creating Instance Name";
                    Application.DoEvents();
                    //Delete Instance MSSQLLocalDB
                    startInfo.Arguments = $"/C SQLLocalDB CREATE MSSQLLocalDB";
                    process.StartInfo = startInfo;
                    process.StartInfo.ErrorDialog = true;
                    process.Start();
                    while (!process.HasExited)
                    {
                        Application.DoEvents();
                    }

                    dlg.Caption = "Starting Instance Name";
                    Application.DoEvents();
                    //Delete Instance MSSQLLocalDB
                    startInfo.Arguments = $"/C SQLLocalDB STARTING MSSQLLocalDB";
                    process.StartInfo = startInfo;
                    process.StartInfo.ErrorDialog = true;
                    process.Start();
                    while (!process.HasExited)
                    {
                        Application.DoEvents();
                    }

                    E4Storage.App.Helper.MsgBoxHelper.MsgInfo($"{this.Name}.repairKoneksi", "Proses repair koneksi selesai!");
                    DialogResult = DialogResult.Retry;
                    this.Close();
                }
                catch (Exception ex)
                {
                    E4Storage.App.Helper.MsgBoxHelper.MsgError($"{this.Name}.repairKoneksi", ex);
                }
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            repairKoneksi();
        }
    }
}