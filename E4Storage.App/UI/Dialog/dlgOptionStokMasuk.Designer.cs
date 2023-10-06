
namespace E4Storage.App.UI.Dialog
{
    partial class dlgOptionStokMasuk
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKeluar = new DevExpress.XtraEditors.SimpleButton();
            this.btnPengembalian = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnMasterData = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnKeluar
            // 
            this.btnKeluar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeluar.Appearance.Options.UseFont = true;
            this.btnKeluar.Location = new System.Drawing.Point(3, 42);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(230, 33);
            this.btnKeluar.TabIndex = 1;
            this.btnKeluar.Text = "&Stok Masuk";
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // btnPengembalian
            // 
            this.btnPengembalian.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPengembalian.Appearance.Options.UseFont = true;
            this.btnPengembalian.Location = new System.Drawing.Point(3, 81);
            this.btnPengembalian.Name = "btnPengembalian";
            this.btnPengembalian.Size = new System.Drawing.Size(230, 33);
            this.btnPengembalian.TabIndex = 2;
            this.btnPengembalian.Text = "&Pengembalian";
            this.btnPengembalian.Click += new System.EventHandler(this.btnPengembalian_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(3, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(230, 33);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Batal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMasterData
            // 
            this.btnMasterData.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterData.Appearance.Options.UseFont = true;
            this.btnMasterData.Location = new System.Drawing.Point(3, 3);
            this.btnMasterData.Name = "btnMasterData";
            this.btnMasterData.Size = new System.Drawing.Size(230, 33);
            this.btnMasterData.TabIndex = 0;
            this.btnMasterData.Text = "&Master Data";
            this.btnMasterData.Click += new System.EventHandler(this.btnMasterData_Click);
            // 
            // dlgOptionStokMasuk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMasterData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPengembalian);
            this.Controls.Add(this.btnKeluar);
            this.Name = "dlgOptionStokMasuk";
            this.Size = new System.Drawing.Size(236, 158);
            this.Load += new System.EventHandler(this.dlgOptionStokMasuk_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKeluar;
        private DevExpress.XtraEditors.SimpleButton btnPengembalian;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnMasterData;
    }
}
