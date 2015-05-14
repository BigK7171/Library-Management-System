using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net.Mail;
using System.IO;
using DevExpress;

namespace LibMgmt
{
    public partial class frmSendMail : Form
    {
        public frmSendMail()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins");
        }

        public void frmSendMail_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage(SenderMail.Text.Trim(), RecipientMail.Text.Trim(), Subject.Text, body.Text);
            //Smtp Server. Vi du: Gmail: smtp.gmail.com, yahoo: smtp.yahoo.com
            SmtpClient client = new SmtpClient(SmtpSrv.SelectedText.Trim());
            client.Port = int.Parse(Port.SelectedText);
            client.Credentials = new System.Net.NetworkCredential(UserName.Text.Trim(),Passwd.Text.Trim());
            client.EnableSsl = true;
            if (!String.IsNullOrEmpty(this.txtAttachment.Text))
            {
                Attachment attachment = new Attachment(this.txtAttachment.Text);
                mail.Attachments.Add(attachment);
            }
            try
            {
                client.Send(mail);
                MessageBox.Show("Gửi mail thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Không gửi được mail! Vui lòng kiểm tra lại thông tin","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog fileBrowseDialog = new OpenFileDialog();
            if (fileBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileBrowseDialog.FileName;
            }
            this.txtAttachment.Text = filePath;
        }
    }
}
