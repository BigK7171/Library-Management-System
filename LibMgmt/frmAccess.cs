using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibMgmt
{
    public partial class frmAccess : Form
    {
        public frmAccess()
        {
            InitializeComponent();
            AcceptButton = btnOK;
            CancelButton = btnCancel;            
        }
        public static VerifyAccess Check = new VerifyAccess();
        public void SetEmptyTxtBox()
        {           
            Check.SetStaffID(Check.GetStaffID().Trim());
            Check.SetPasswd(Check.GetPasswd().Trim());
            Check.SetPermission(Check.GetPermission().Trim());
            Check.SetAddress(Check.GetAddress().Trim());
            Check.SetFullName(Check.GetFullName().Trim());
            Check.SetUserName(Check.GetUserName().Trim());
        }
        public void SelectStaff()
        {            
            Check.SelectStaff(txtUserName.Text,txtPasswd.Text);
        }
        public static string password, username;

        private void btnOK_Click(object sender, EventArgs e)
        {            
            username = txtUserName.Text;
            password = txtPasswd.Text;
            SelectStaff();
            SetEmptyTxtBox();
            if (txtUserName.Text == "" || txtPasswd.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
               // btnOK_Click(sender,e);
                Check.DelStaff();
            }
            else if(Check.GetPasswd() == Convert.ToString(txtPasswd.Text) && Check.GetUserName() == Convert.ToString(txtUserName.Text))
            {
                MessageBox.Show("Đăng nhập thành công với quyền " + Check.GetPermission(), "Quản Lý Thư Viện", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }            
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng nhập chính xác 'Tên đăng nhập' và 'Mật khẩu'.", "Quản Lý Thư Viện", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Check.DelStaff();
                //txtUserName.Text = "";
                //txtPasswd.Text = "";
                btnCancel_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

    }
}
