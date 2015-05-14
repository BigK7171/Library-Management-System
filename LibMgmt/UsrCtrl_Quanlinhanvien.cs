using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibMgmt
{
    public partial class UsrCtrl_Quanlinhanvien : UserControl
    {
        public UsrCtrl_Quanlinhanvien()
        {
            InitializeComponent();
        }
        public void ClearTxtBox()
        {
            txtStaffID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";           
            txtContact.Text = "";
            txtLogin.Text = "";
            txtPermission.Text = "";
        }
        public void DisableTxtBox()
        {
            txtStaffID.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtContact.Enabled = false;
            txtLogin.Enabled = false;
            txtPermission.Enabled = false;
        }
        public void EnableTxtBox()
        {
            txtStaffID.Enabled = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtContact.Enabled = true;
            txtLogin.Enabled = true;
            txtPermission.Enabled = true;
        }
        string StaffID;
        public void GetStaffID()
        {
            StaffID = "";
            SQL_Connection sqlcnt = new SQL_Connection();
            SqlCommand cmd = new SqlCommand("SELECT MANHANVIEN from NHANVIEN");
            SqlDataReader dr = sqlcnt.GetDataReader(cmd.CommandText);
            while (dr.Read())  StaffID = dr[0].ToString();
            SQL_Connection.CloseConnection();
            if (StaffID == "") { StaffID = "NV0001"; }
            else
            {
                string str = StaffID.Substring(2, StaffID.Length - 2);
                double i = double.Parse(str);
                i++;
                if (i < 10)
                {
                    str = "NV000" + i.ToString();
                }
                else if (i < 100)
                {
                    str = "NV00" + i.ToString();
                }
                else if (i < 1000)
                {
                    str = "NV0" + i.ToString();
                }
                else if (i < 10000)
                {
                    str = "NV" + i.ToString();
                }
                StaffID = str;
            }
            txtStaffID.Text = StaffID;
        }

        public void LoadDataToGrid()
        {
            panelControl1.Controls.Clear();
            SQL_Connection sqlcnt = new SQL_Connection();
            DataTable data = sqlcnt.GetDataByUsingSP("GetStaffData");
            gridControl1.DataSource = data;
            panelControl1.Controls.Add(gridControl1);

        }

        private void UsrCtrl_Quanlinhanvien_Load(object sender, EventArgs e)
        {
            DisableTxtBox();            
            LoadDataToGrid();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (btnAddStaff.Text == "Thêm")
            {
                EnableTxtBox();
                btnDelStaff.Enabled = false;
                btnAddStaff.Text = "Chấp Nhận";
                GetStaffID();
            }
            else
            {
                Staff NhanVien = new Staff();
                NhanVien.SetStaffID(txtStaffID.Text);
                NhanVien.SetFullName(txtName.Text);
                NhanVien.SetAddress(txtAddress.Text);
                NhanVien.SetPasswd("12345");
                NhanVien.SetPermission(txtPermission.Text);
                NhanVien.SetUserName(txtLogin.Text);
                NhanVien.SetNumberPhone(txtContact.Text);
                if (NhanVien.AddStaff())
                {
                    MessageBox.Show("Cập nhật nhân viên mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LoadDataToGrid();
                    ClearTxtBox();
                    DisableTxtBox();
                }
                else
                {
                    MessageBox.Show("Quá trình cập nhật bị lỗi. Hãy thử lại.","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                btnAddStaff.Text = "Thêm";
                btnDelStaff.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            DisableTxtBox();
            btnAddStaff.Enabled = true;
            btnDelStaff.Enabled = true;
            btnAddStaff.Text = "Thêm";
            btnDelStaff.Text = "Xóa";
        }

        private void btnDelStaff_Click(object sender, EventArgs e)
        {

            if (btnDelStaff.Text == "Xóa")
            {
                btnAddStaff.Enabled = false;
                MessageBox.Show("Nhập mã nhân viên cần xóa", "Thông Báo");
                btnDelStaff.Text = "OK";
                txtStaffID.Enabled = true;
            }
            else if(btnDelStaff.Text == "OK")
            {
                txtStaffID.Enabled = false;
                SQL_Connection sqlcnt = new SQL_Connection();
                SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT *FROM NHANVIEN WHERE MANHANVIEN='" + txtStaffID.Text + "'";                    
                    SqlDataReader dr = sqlcnt.GetDataReader(cmd.CommandText);
                    while (dr.Read())
                    {
                        txtLogin.Text = Convert.ToString(dr["TENDANGNHAP"]);
                        txtName.Text = Convert.ToString(dr["HOTEN"]);
                        txtAddress.Text = Convert.ToString(dr["DIACHI"]);
                        txtPermission.Text = Convert.ToString(dr["QuyenHan"]);
                        txtContact.Text = Convert.ToString(dr["SODIENTHOAI"]);
                    }
                btnDelStaff.Text = "Xác Nhận";
            }
            else if (btnDelStaff.Text == "Xác Nhận")
            {
                DialogResult DlgRs =  MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?","Xác nhận xóa",MessageBoxButtons.YesNo);                
                if (DlgRs == DialogResult.Yes)
                {
                    Staff NhanVien = new Staff();
                    NhanVien.SetStaffID(txtStaffID.Text);
                    if (NhanVien.DelStaff())
                    {
                        MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnThoat_Click(sender,e);
                    }
                    ClearTxtBox();
                    btnDelStaff.Text = "Xóa";
                    btnAddStaff.Enabled = true;                    
                }
                else if (DlgRs == DialogResult.No)
                {
                    btnThoat_Click(sender,e);
                }
            }            
        }
    }
}
