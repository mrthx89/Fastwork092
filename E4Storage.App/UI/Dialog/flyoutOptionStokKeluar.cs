using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E4Storage.App.Helper;
using System.Windows.Forms;
using System.Drawing;

namespace E4Storage.App.UI.Dialog
{
    public class flyoutOptionStokKeluar
    {
        private DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog flyoutDialog;
        private System.Windows.Forms.Form form;
        private FlyoutAction action;
        private dlgOptionStokKeluar userControl;

        public flyoutOptionStokKeluar(System.Windows.Forms.Form form, dlgOptionStokKeluar userControl)
        {
            this.form = form;
            this.userControl = userControl;
            this.action = new FlyoutAction
            {
                Caption = "Opsi Pengeluaran",
                Description = "Opsi Pengeluaran"
            };
            //this.action.Commands.Add(FlyoutCommand.OK);
            //this.action.Commands.Add(FlyoutCommand.Cancel);
            //this.action.SelectedCommand = FlyoutCommand.OK;
        }

        public void flyoutDialog_Closing(Object sender, CancelEventArgs e)
        {
            try
            {
                if (flyoutDialog.DialogResult == DialogResult.OK)
                {
                    flyoutDialog.Validate();
                }
                if (flyoutDialog.DialogResult == DialogResult.OK &&
                    flyoutDialog.Validate() &&
                    flyoutDialog.ValidateChildren() &&
                    flyoutDialog.DialogResult == DialogResult.OK) {
                    e.Cancel = false;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.form.Name}.flyoutDialog_Closing", ex);
                e.Cancel = true;
            }
        }

        public Tuple<DialogResult, int> ShowFormPopup()
        {
            //FlyoutProperties properties = new FlyoutProperties
            //{
            //    HeaderOffset = 0,
            //    Alignment = ContentAlignment.MiddleCenter,
            //    Style = FlyoutStyle.MessageBox,
            //    ShowCaption = true
            //};

            flyoutDialog = new DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog(form, action, userControl);
            flyoutDialog.Properties.HeaderOffset = 0;
            flyoutDialog.Properties.Alignment = ContentAlignment.MiddleCenter;
            flyoutDialog.Properties.Style = FlyoutStyle.MessageBox;
            flyoutDialog.Properties.ShowCaption = DevExpress.Utils.DefaultBoolean.True;
            userControl.flyoutDialog = flyoutDialog;

            //Action
            flyoutDialog.FormClosing += flyoutDialog_Closing;

            var Dialog = flyoutDialog.ShowDialog(form);
            return new Tuple<DialogResult, int>(Dialog, userControl.IDJenis);
        }
    }
}
