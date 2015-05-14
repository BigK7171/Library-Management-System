using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Net.Mail;
using System.Net;

namespace LibMgmt
{
    public partial class UsrCtrl_Help : UserControl
    {
        public UsrCtrl_Help()
        {
            InitializeComponent();
            this.lblCtrl1.Text = "Phần mềm quản lí thư viện do LCks Team xây dựng và phát triển có một số chức năng chính như sau:";
            this.lblCtrl2.Text = "- Nhóm chức năng quản lí hệ thống: với các thao tác đăng nhập, đăng xuất và cho phép thực hiện chỉnh sửa, cập nhật thông tin các nhân viên làm việc trong thư viện";
            this.lblCtrl3.Text = "- Nhóm chức năng quản lí sách: thực hiện việc tìm kiếm, kiểm tra, cập nhật thông tin sách mượn, trả, in báo cáo thống kê.";
            this.lblCtrl4.Text = "- Nhóm chức năng quản lí độc giả: cập nhật, tạo mới thẻ thư viện, kiểm tra thông tin độc giả, danh sách độc giả,...";
            this.lblCtrl5.Text = "- Nhóm chức năng thống kê: cung cấp một số công cụ xử lý số liệu, thao tác nhanh với dữ liệu, thống kê tình trạng mượn, trả của sách trong thư viện";
            this.lblCtrl6.Text = "- Chức năng liên hệ khách hàng: cho phép gửi tin nhắn sms, email thông báo, liên hệ  với khách hàng.";
            this.lblDirection.Text = "Mọi thắc mắc xin liên hệ với d3vjl_7171 - LCks Team Leader theo một trong các địa chỉ sau: ";
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSendMail sendmail = new frmSendMail();
            sendmail.ShowDialog();        
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                string webAddress = "https://plus.google.com/113217298057277315887";
                System.Diagnostics.Process.Start(webAddress);
            }
            catch
            {
                MessageBox.Show("Liên kết không tồn tại hoặc không kết nối được Internet", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
