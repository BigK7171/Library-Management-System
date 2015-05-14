namespace LibMgmt
{
    partial class frmSendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendMail));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.SenderMail = new DevExpress.XtraEditors.TextEdit();
            this.Passwd = new DevExpress.XtraEditors.TextEdit();
            this.UserName = new DevExpress.XtraEditors.TextEdit();
            this.Subject = new DevExpress.XtraEditors.TextEdit();
            this.RecipientMail = new DevExpress.XtraEditors.TextEdit();
            this.body = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.SmtpSrv = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtAttachment = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.Port = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.SenderMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Passwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Subject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecipientMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpSrv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttachment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(162, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(224, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Vui lòng gửi mail theo mẫu sau";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(19, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 18);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mail người gửi";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(19, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(116, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Mail người nhận";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(19, 107);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 18);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Tiêu đề";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(19, 137);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(89, 18);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Smtp Server";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Location = new System.Drawing.Point(19, 167);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(116, 18);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Tên người dùng";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(19, 197);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(64, 18);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Mật khẩu";
            // 
            // SenderMail
            // 
            this.SenderMail.Location = new System.Drawing.Point(152, 47);
            this.SenderMail.Name = "SenderMail";
            this.SenderMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.SenderMail.Properties.Appearance.Options.UseFont = true;
            this.SenderMail.Size = new System.Drawing.Size(265, 22);
            this.SenderMail.TabIndex = 7;
            // 
            // Passwd
            // 
            this.Passwd.Location = new System.Drawing.Point(152, 197);
            this.Passwd.Name = "Passwd";
            this.Passwd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passwd.Properties.Appearance.Options.UseFont = true;
            this.Passwd.Properties.PasswordChar = '*';
            this.Passwd.Size = new System.Drawing.Size(265, 22);
            this.Passwd.TabIndex = 8;
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(152, 167);
            this.UserName.Name = "UserName";
            this.UserName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.UserName.Properties.Appearance.Options.UseFont = true;
            this.UserName.Size = new System.Drawing.Size(265, 22);
            this.UserName.TabIndex = 9;
            // 
            // Subject
            // 
            this.Subject.Location = new System.Drawing.Point(152, 107);
            this.Subject.Name = "Subject";
            this.Subject.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.Subject.Properties.Appearance.Options.UseFont = true;
            this.Subject.Size = new System.Drawing.Size(265, 22);
            this.Subject.TabIndex = 11;
            // 
            // RecipientMail
            // 
            this.RecipientMail.Location = new System.Drawing.Point(152, 77);
            this.RecipientMail.Name = "RecipientMail";
            this.RecipientMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.RecipientMail.Properties.Appearance.Options.UseFont = true;
            this.RecipientMail.Size = new System.Drawing.Size(265, 22);
            this.RecipientMail.TabIndex = 12;
            // 
            // body
            // 
            this.body.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.body.Location = new System.Drawing.Point(40, 285);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(471, 255);
            this.body.TabIndex = 13;
            this.body.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nội dung";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(220, 549);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 26);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // SmtpSrv
            // 
            this.SmtpSrv.Location = new System.Drawing.Point(152, 137);
            this.SmtpSrv.Name = "SmtpSrv";
            this.SmtpSrv.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.SmtpSrv.Properties.Appearance.Options.UseFont = true;
            this.SmtpSrv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SmtpSrv.Properties.Items.AddRange(new object[] {
            "smtp.gmail.com",
            "smtp.mail.yahoo.com"});
            this.SmtpSrv.Size = new System.Drawing.Size(265, 22);
            this.SmtpSrv.TabIndex = 10;
            // 
            // txtAttachment
            // 
            this.txtAttachment.Location = new System.Drawing.Point(152, 227);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAttachment.Properties.Appearance.Options.UseFont = true;
            this.txtAttachment.Size = new System.Drawing.Size(265, 22);
            this.txtAttachment.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tệp đính kèm";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(456, 227);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(82, 26);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Duyệt tới...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(423, 137);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(30, 18);
            this.labelControl8.TabIndex = 21;
            this.labelControl8.Text = "Port";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(456, 137);
            this.Port.Name = "Port";
            this.Port.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.Port.Properties.Appearance.Options.UseFont = true;
            this.Port.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Port.Properties.Items.AddRange(new object[] {
            "587",
            "465"});
            this.Port.Size = new System.Drawing.Size(82, 22);
            this.Port.TabIndex = 22;
            // 
            // frmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 587);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAttachment);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.body);
            this.Controls.Add(this.RecipientMail);
            this.Controls.Add(this.Subject);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Passwd);
            this.Controls.Add(this.SenderMail);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.SmtpSrv);
            this.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSendMail";
            this.Text = "Gửi Email ";
            this.Load += new System.EventHandler(this.frmSendMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SenderMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Passwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Subject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecipientMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpSrv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttachment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit SenderMail;
        private DevExpress.XtraEditors.TextEdit Passwd;
        private DevExpress.XtraEditors.TextEdit UserName;
        private DevExpress.XtraEditors.TextEdit Subject;
        private DevExpress.XtraEditors.TextEdit RecipientMail;
        private System.Windows.Forms.RichTextBox body;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private DevExpress.XtraEditors.ComboBoxEdit SmtpSrv;
        private DevExpress.XtraEditors.TextEdit txtAttachment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit Port;
    }
}