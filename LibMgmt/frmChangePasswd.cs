using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LibMgmt
{
    public partial class frmChangePasswd : Form
    {
        public frmChangePasswd()
        {
            InitializeComponent();
            AcceptButton = btnXacnhan;
        }
         string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string Passwd = "";
        string StaffID = "";
        public void GetPasswd()
        {
            StreamReader sr = new StreamReader(path+ "\\luu password.txt");
            Passwd = sr.ReadLine();
            sr.Close();
        }

        public void GetStaff()
        {
            StreamReader sr = new StreamReader(path+ "\\luu nhan vien.txt");
            StaffID = sr.ReadLine();
            sr.Close();
        }

        public void Clear()
        {
            txtCurrentPasswd.Text = "";
            txtNewPasswd.Text = "";
            txtConfirm.Text = "";
        }
        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            GetPasswd();
            GetStaff();
            if (txtCurrentPasswd.Text == Passwd.Trim())
            {
                if (txtNewPasswd.Text != "")
                {
                    if (txtNewPasswd.Text == txtConfirm.Text)
                    {
                        Staff NhanVien = new Staff();
                        NhanVien.SetStaffID(StaffID);
                        NhanVien.SetPasswd(Passwd);
                        if (NhanVien.ChangePasswd(txtConfirm.Text))
                        {
                            StreamWriter sw = new StreamWriter(path+ "\\luu password.txt");
                            sw.WriteLine(txtConfirm.Text);
                            sw.Close();
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Không thay đổi được mật khẩu mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không khớp!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Vui lòng không để trống mật khẩu mới!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Nhập sai mật khẩu hiện tại!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clear();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
