namespace LibMgmt
{
    partial class frmChangePasswd
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePasswd));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnXacnhan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.txtCurrentPasswd = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPasswd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtConfirm = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPasswd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPasswd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(51, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mật khẩu hiện tại";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 11.25F);
            this.labelControl2.Location = new System.Drawing.Point(51, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 17);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mật khẩu mới";
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.Appearance.Font = new System.Drawing.Font("Arial", 11.25F);
            this.btnXacnhan.Appearance.Options.UseFont = true;
            this.btnXacnhan.Location = new System.Drawing.Point(279, 176);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacnhan.TabIndex = 2;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Arial", 11.25F);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Location = new System.Drawing.Point(398, 176);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtCurrentPasswd
            // 
            this.txtCurrentPasswd.Location = new System.Drawing.Point(220, 47);
            this.txtCurrentPasswd.Name = "txtCurrentPasswd";
            this.txtCurrentPasswd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtCurrentPasswd.Properties.Appearance.Options.UseFont = true;
            this.txtCurrentPasswd.Properties.PasswordChar = '*';
            this.txtCurrentPasswd.Size = new System.Drawing.Size(253, 24);
            this.txtCurrentPasswd.TabIndex = 4;
            // 
            // txtNewPasswd
            // 
            this.txtNewPasswd.Location = new System.Drawing.Point(220, 87);
            this.txtNewPasswd.Name = "txtNewPasswd";
            this.txtNewPasswd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtNewPasswd.Properties.Appearance.Options.UseFont = true;
            this.txtNewPasswd.Properties.PasswordChar = '*';
            this.txtNewPasswd.Size = new System.Drawing.Size(253, 24);
            this.txtNewPasswd.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 11.25F);
            this.labelControl3.Location = new System.Drawing.Point(51, 129);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(155, 17);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Xác nhận mật khẩu mới";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(220, 126);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtConfirm.Properties.Appearance.Options.UseFont = true;
            this.txtConfirm.Properties.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(253, 24);
            this.txtConfirm.TabIndex = 7;
            // 
            // frmChangePasswd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 231);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtNewPasswd);
            this.Controls.Add(this.txtCurrentPasswd);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacnhan);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChangePasswd";
            this.Text = "Thay đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPasswd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPasswd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirm.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnXacnhan;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.TextEdit txtCurrentPasswd;
        private DevExpress.XtraEditors.TextEdit txtNewPasswd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtConfirm;
    }
}