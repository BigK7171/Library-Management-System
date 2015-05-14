using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace LibMgmt
{
    public partial class UsrCtrl_SendSMS : UserControl
    { 
        public UsrCtrl_SendSMS()
        {
            InitializeComponent();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string user,passwd, api_id, to, msg;
                user = txtUser.Text;
                passwd = txtPasswd.Text;
                api_id = txtAPI_ID.Text;
                to = txtPhoneNum.Text;
                msg = rtbMsg.Text;
                string baseurl = "http://api.clickatell.com/http/sendmsg?user="+user+"&password="+passwd+"&api_id="+api_id+"&to='"+to+"'&text='"+msg+"'";
                //string baseurl = "http://api.clickatell.com/http/sendmsg?user=monster7171&password=GbVAaIgGTgQFKL&api_id=3504873&to='" + to + "'&text='" + msg + "'";
                client.OpenRead(baseurl);
                MessageBox.Show("Gửi tin nhắn thành công.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string webAdress = "https://www.clickatell.com/Register/";
                System.Diagnostics.Process.Start(webAdress);
            }
            catch
            {
                MessageBox.Show("Link không tồn tại hoặc chưa kết nối Internet.","Cảnh báo!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
