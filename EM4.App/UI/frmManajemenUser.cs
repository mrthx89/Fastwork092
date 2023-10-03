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

namespace EM4.App.UI
{
    public partial class frmManajemenUser : DevExpress.XtraEditors.XtraForm
    {
        public frmManajemenUser()
        {
            InitializeComponent();
        }

        private Guid notDeleted = Guid.Parse("EC82D19B-14AD-41E6-90BE-ED2B17855BF3");

        private void mnSimpan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (WaitDialogForm dlg = new WaitDialogForm("Sedang menyimpan data"))
            {
                try
                {
                    dlg.TopMost = false;
                    dlg.Show();
                    dlg.Focus();

                    this.Validate();
                    var save = Repository.User.saveUsers(data);
                    if (save.Item1)
                    {
                        data = save.Item2;
                    }
                    tUserBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.repositoryItemPassword_ButtonClick", ex);
                }
            }
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

                    var dataGet = Repository.User.getUsers();
                    if (dataGet.Item1)
                    {
                        data = dataGet.Item2;
                    }
                    tUserBindingSource.DataSource = data;
                    gridControl1.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.mnReload_ItemClick", ex);
                }
            }
        }

        private void mnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    TUser CurrentUser = (TUser)tUserBindingSource.Current;
                    if (CurrentUser != null && CurrentUser.ID != notDeleted)
                    {
                        tUserBindingSource.RemoveCurrent();
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.repositoryItemPassword_ButtonClick", ex);
            }
        }

        private List<TUser> data = null;
        private dynamic lookupUser = null;
        private void frmManajemenUser_Load(object sender, EventArgs e)
        {
            var lookUp = Repository.User.getLookUp();
            if (lookUp.Item1)
            {
                lookupUser = lookUp.Item2;
            }
            repositoryItemUser.DataSource = lookupUser;
            repositoryItemUser.ValueMember = "ID";
            repositoryItemUser.DisplayMember = "Nama";

            mnReload.PerformClick();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                gridView1.SetRowCellValue(e.RowHandle, colID, Guid.NewGuid());
                gridView1.SetRowCellValue(e.RowHandle, colTglEntri, DateTime.Now);
                gridView1.SetRowCellValue(e.RowHandle, colIDUserEntri, Constant.UserLogin.ID);
                gridView1.SetRowCellValue(e.RowHandle, colPassword, "");
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.gridView1_InitNewRow", ex);
            }
        }

        private void gridView1_DataSourceChange(object sender, EventArgs e)
        {
            Constant.layoutsHelper.RestoreLayouts(this.Name, gridView1);
        }

        private void frmManajemenUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.layoutsHelper.SaveLayouts(this.Name, gridView1);
        }

        private void repositoryItemPassword_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Index == 0)
                {
                    TUser CurrentUser = (TUser)tUserBindingSource.Current;
                    if (CurrentUser != null)
                    {
                        changePassword(CurrentUser);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.repositoryItemPassword_ButtonClick", ex);
            }
        }

        private void changePassword(TUser user)
        {
            using (frmChangePassword frm = new frmChangePassword(user.Password))
            {
                try
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        user.Password = frm.PasswordBaru;
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.MsgError($"{this.Name}.changePassword", ex);
                }
            }
        }

        private void gricView1_FocusRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle >= 0 && gridView1.FocusedColumn == colUserID)
                {
                    //Read Only karena SysADMIN
                    colUserID.OptionsColumn.AllowEdit = !(((TUser)tUserBindingSource.Current).ID == notDeleted);
                }
                else if (gridView1.FocusedColumn == colUserID)
                {
                    colUserID.OptionsColumn.AllowEdit = true;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.gricView1_FocusRowChanged", ex);
            }
        }

        private void gricView1_FocusColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                if (e.FocusedColumn == colUserID && gridView1.FocusedRowHandle >= 0)
                {
                    //Read Only karena SysADMIN
                    colUserID.OptionsColumn.AllowEdit = !(((TUser)tUserBindingSource.Current).ID == notDeleted);
                }
                else if (e.FocusedColumn == colID)
                {
                    colUserID.OptionsColumn.AllowEdit = true;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.MsgError($"{this.Name}.gricView1_FocusColumnChanged", ex);
            }
        }
    }
}