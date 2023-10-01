using DevExpress.XtraEditors;
using EM4.App.Model.Entity;
using EM4.App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EM4.App.Helper
{
    public static class MsgBoxHelper
    {
        // No Optional Function, pakai Inherits Function yang sudah saya contohkan dibawah
        public static void MsgError(string Events, XtraForm Parent, Exception Ex)
        {
            LogDataHelper.TulisLogError(Ex, "Pesan Kesalahan : " + Ex.Message + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show(Parent, "Pesan Kesalahan : " + Ex.Message + Environment.NewLine + "Events :" + Events, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MsgError(string Events, Exception Ex)
        {
            LogDataHelper.TulisLogError(Ex, "Pesan Kesalahan : " + Ex.Message + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show("Pesan Kesalahan : " + Ex.Message + Environment.NewLine + "Events :" + Events, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MsgError(string Events, XtraForm Parent, string Promt)
        {
            LogDataHelper.TulisLogError(Promt + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show(Parent, Promt, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MsgError(string Events, string Promt)
        {
            LogDataHelper.TulisLogError(Promt + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show(Promt, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MsgQuestionYesNo(string Events, XtraForm Parent, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Parent, Promt, Constant.NamaApplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult MsgQuestionYesNo(string Events, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Promt, Constant.NamaApplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult MsgQuestionYesNo(string Events, XtraForm Parent, string Promt, MessageBoxDefaultButton DefaultButton)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Parent, Promt, Constant.NamaApplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, DefaultButton);
        }
        public static DialogResult MsgQuestionYesNo(string Events, string Promt, MessageBoxDefaultButton DefaultButton)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Promt, Constant.NamaApplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, DefaultButton);
        }
        public static DialogResult MsgQuestionYesNoCancel(string Events, XtraForm Parent, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Parent, Promt, Constant.NamaApplikasi, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
        }
        public static DialogResult MsgQuestionYesNoCancel(string Events, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Promt, Constant.NamaApplikasi, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
        }
        public static DialogResult MsgQuestionOkCancel(string Events, XtraForm Parent, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Parent, Promt, Constant.NamaApplikasi, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult MsgQuestionOkCancel(string Events, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            return XtraMessageBox.Show(Promt, Constant.NamaApplikasi, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        public static void MsgWarn(string Events, XtraForm Parent, string Promt)
        {
            LogDataHelper.TulisLogWarning(Promt + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show(Parent, Promt, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MsgWarn(string Events, string Promt)
        {
            LogDataHelper.TulisLogWarning(Promt + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show(Promt, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MsgInfo(string Events, XtraForm Parent, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show(Parent, Promt, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MsgInfo(string Events, string Promt)
        {
            LogDataHelper.TulisLogInformation(Promt + Environment.NewLine + "Events :" + Events);
            XtraMessageBox.Show(Promt, Constant.NamaApplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MsgNotFound(string Events)
        {
            MsgWarn(Events, "Maaf data yang Anda cari tidak ditemukan");
        }
        public static void MsgSaveSuccess(string Events)
        {
            MsgInfo(Events, "Data berhasil disimpan!");
        }
        public static void MsgDeleteSuccess(string Events)
        {
            MsgInfo(Events, "Data berhasil dihapus!");
        }
        public static void MsgSaveError(string Events)
        {
            MsgWarn(Events, @"Maaf, Data yang Anda masukkan gagal disimpan !\nSilahkan dicoba lagi.");
        }
        public static void MsgDeleteError(string Events)
        {
            MsgWarn(Events, @"Maaf data gagal dihapus !\nData ini sudah digunakan untuk proses yang lain.");
        }
    }
}
