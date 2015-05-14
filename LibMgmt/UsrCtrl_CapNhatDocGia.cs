using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace LibMgmt
{
    public partial class UsrCtrl_CapNhatDocGia : UserControl
    {
        public UsrCtrl_CapNhatDocGia()
        {
            InitializeComponent();
            DisableTxtBox();
            Load_data();
        }

        public void DisableTxtBox()
        {
            txtReaderID.Enabled = false;
            txtReaderName.Enabled = false;
            txtReaderType.Enabled = false;
            txtSex.Enabled = false;
            txtBirthday.Enabled = false;
            txtAddress.Enabled = false;
            txtDateTime.Enabled = false;
            txtNumberPhone.Enabled = false;
        }

        public void EnableTxtBox()
        {
            txtReaderID.Enabled = true;
            txtReaderName.Enabled = true;
            txtReaderType.Enabled = true;
            txtSex.Enabled = true;
            txtBirthday.Enabled = true;
            txtAddress.Enabled = true;
            txtDateTime.Enabled = true;
            txtNumberPhone.Enabled = true;
        }
        public void Cleartxt()
        {
            txtReaderID.Text = "";
            txtReaderName.Text = "";
            txtReaderType.Text = "";
            txtSex.Text = "";
            txtBirthday.Text = "";
            txtAddress.Text = "";
            txtDateTime.Text = "";
            txtNumberPhone.Text = "";
        }
        public int Indentify()
        {
            int i = 0;
            SQL_Connection sqlcnt = new SQL_Connection();
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "select * from DOCGIA";
            SqlDataReader dr = sqlcnt.GetDataReader(sc.CommandText);
            while (dr.Read())
            {
                if (Convert.ToString(dr["MADOCGIA"])== txtReaderID.Text.Trim())
                    i++;            
            }
            return i;
        } 
        public void Load_data()
        {
            SQL_Connection sqlcnt = new SQL_Connection();           
            SqlDataReader dtReader =  sqlcnt.GetDataReader("select TENLOAIDG from LOAIDOCGIA");
            while (dtReader.Read())
            {
                txtReaderType.Properties.Items.AddRange(new object[]{ dtReader[0].ToString() });
            }
            SQL_Connection.CloseConnection();

        }
        public void LoadDataToGridCtrl()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            DataTable data = sqlcnt.GetDataByUsingSP("LoadDataToUpdate");
            gridControl1.DataSource = data;
        }
        private void UsrCtrl_CapNhatDocGia_Load(object sender, EventArgs e)
        {            
            LoadDataToGridCtrl();
        }
        
        string mathe;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnDel.Enabled = false;
            btnModify.Enabled = false;
            if (btnAdd.Text == "OK")
            {                
                SQL_Connection.OpenConnection();
                DateTime DateVal;
                if (txtReaderID.Text == "" || txtReaderType.Text == "" || DateTime.TryParse(txtBirthday.Text, out DateVal) == false)
                {                    
                    MessageBox.Show("Nhập dữ liệu không hợp lệ.Đảm bảo không để trống mã độc giả.Vui lòng nhập thông tin đầy đủ và chính xác!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    btnHuy_Click(sender,e);
                    btnAdd_Click(sender,e);
                }                
                else
                {
                    try
                    {
                        SQL_Connection sqlcnt = new SQL_Connection();                        
                        Reader ls = new Reader();
                        ls.SetReaderID(txtReaderID.Text);
                        ls.SetBirthDay(Convert.ToDateTime(txtBirthday.Text));
                        ls.SetSex(txtSex.Text);
                        ls.SetReaderName(txtReaderName.Text);
                        ls.SetAddress(txtAddress.Text);
                        ls.SetNumberPhone(txtNumberPhone.Text);
                        SqlDataReader dr = sqlcnt.GetDataReader("select *from loaidocgia");
                        while (dr.Read())
                        {
                            if (Convert.ToString(dr["TENLOAIDG"]) == txtReaderType.Text)
                            {
                                ls.SetTypeID(Convert.ToString(dr["MALOAIDOCGIA"]));
                            }
                        }                        
                        if (ls.AddReader())
                        {
                            SQL_Connection _sqlcnt = new SQL_Connection();
                            SqlCommand sc = new SqlCommand("select mathe from the");
                            SqlDataReader dr1 = _sqlcnt.GetDataReader(sc.CommandText);
                            while (dr1.Read())
                                mathe = dr1[0].ToString();
                            SQL_Connection.CloseConnection();
                            if (mathe == "") mathe = "MT0000";
                            else
                            {
                                string s = mathe.Substring(2, mathe.Length - 2);
                                double i = double.Parse(s);
                                i++;
                                if (i < 10)
                                {
                                    s = "MT000" + i.ToString();
                                }
                                else if (i < 100)
                                {
                                    s = "MT00" + i.ToString();
                                }
                                else if (i < 1000)
                                {
                                    s = "MT0" + i.ToString();
                                }
                                else if (i < 10000)
                                {
                                    s = "MT" + i.ToString();
                                }
                                mathe = s;
                            }
                            string ngayhethan = Convert.ToString(DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + Convert.ToInt16(DateTime.Now.Year + 3));
                            LibCard lt = new LibCard(mathe, txtReaderID.Text, Convert.ToDateTime(txtDateTime.Text), Convert.ToDateTime(ngayhethan));
                            if (lt.AddCard())
                            {
                                panelControl1.Controls.Clear();
                                LoadDataToGridCtrl();
                                panelControl1.Controls.Add(gridControl1);
                                MessageBox.Show("Đã thêm thành công", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                                btnAdd.Text = "Thêm";
                                btnDel.Enabled = true;
                                btnModify.Enabled = true;
                                Cleartxt();
                                DisableTxtBox();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi tạo thẻ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                btnHuy_Click(sender, e);
                                btnAdd_Click(sender, e);
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Lỗi! Mã độc giả vừa nhập đã tồn tại. Vui lòng nhập lại dữ liệu", "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            btnHuy_Click(sender, e);
                            btnAdd_Click(sender, e);
                        }
                    }

                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                    }
                }
            }

            else
            {
                EnableTxtBox();
                btnAdd.Text = "OK";
                txtDateTime.Text = Convert.ToString(DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year);
                txtDateTime.Enabled = false;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            if (btnModify.Text == "Chỉnh sửa")
            {                
                MessageBox.Show("Điền mã độc giả cần chỉnh sửa thông tin.", "Thông Báo");
                txtReaderID.Enabled = true;
                btnModify.Text = "OK";
            }
            else if (btnModify.Text == "OK")
            {                
                SQL_Connection sqlcnt = new SQL_Connection();
                SqlCommand sc = new SqlCommand();
                sc.CommandText = "select * from DOCGIA,LOAIDOCGIA,THE where DOCGIA.MADOCGIA='" + txtReaderID.Text + "' and docgia.MALOAIDOCGIA=LOAIDOCGIA.MALOAIDOCGIA and DOCGIA.MADOCGIA=THE.MADOCGIA";
                SqlDataReader dr = sqlcnt.GetDataReader(sc.CommandText);
                while (dr.Read())
                    {
                        txtReaderName.Text = Convert.ToString(dr["HOTEN"]);
                        txtAddress.Text = Convert.ToString(dr["DIACHI"]);
                        txtSex.Text = Convert.ToString(dr["GIOITINH"]);
                        txtDateTime.Text = Convert.ToString(dr["NGAYCAP"]);
                        txtBirthday.Text = Convert.ToString(dr["NGAYSINH"]);
                        txtReaderType.Text = Convert.ToString(dr["TENLOAIDG"]);
                        txtNumberPhone.Text = Convert.ToString(dr["SODIENTHOAI"]);
                    }
                btnModify.Text = "Chấp nhận";
                EnableTxtBox();
                txtReaderID.Enabled = false;                
            }
            else if (btnModify.Text == "Chấp nhận")
            {
                Reader ldg = new Reader(txtReaderID.Text, txtReaderName.Text, txtReaderType.Text, txtSex.Text, Convert.ToDateTime(txtBirthday.Text), txtAddress.Text,txtNumberPhone.Text);
                SQL_Connection sqlcnt = new SQL_Connection();
                SqlDataReader dr = sqlcnt.GetDataReader("select *from LOAIDOCGIA");
                while (dr.Read())
                {

                    if (Convert.ToString(dr["TENLOAIDG"]) == txtReaderType.Text)
                    {
                        ldg.SetTypeID(Convert.ToString(dr["MALOAIDOCGIA"]));
                    }
                }
                SQL_Connection.OpenConnection();

                if (ldg.UpdateReader())
                {
                    MessageBox.Show("Đã thay đổi dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    panelControl1.Controls.Clear();
                    LoadDataToGridCtrl();
                    panelControl1.Controls.Add(gridControl1);
                    Cleartxt();
                    DisableTxtBox();
                    btnModify.Text = "Chỉnh sửa";
                    btnAdd.Enabled = true;
                    btnDel.Enabled = true;
                }
                else MessageBox.Show("Có lỗi kết nối!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                {
                    Cleartxt();
                    DisableTxtBox();
                    btnModify.Text = "Chỉnh sửa";
                }
            }
        }        

        private void btnDel_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnModify.Enabled = false;            
            if (btnDel.Text == "Xóa")
            {
                MessageBox.Show("Vui lòng nhập mã độc giả cần xóa.", "Thông báo");
                txtReaderID.Enabled = true;
                btnDel.Text = "Xác nhận";
            }
            else if (btnDel.Text == "Xác nhận")
            {                
                SQL_Connection sqlcnt = new SQL_Connection();                             
                SqlCommand sc = new SqlCommand();                
                sc.CommandText = "select * from DOCGIA, LOAIDOCGIA, THE where DOCGIA.MADOCGIA='"+ txtReaderID.Text+"'AND DOCGIA.MALOAIDOCGIA = LOAIDOCGIA.MALOAIDOCGIA AND DOCGIA.MADOCGIA = THE.MADOCGIA ";
                SqlDataReader dr = sqlcnt.GetDataReader(sc.CommandText);
                while (dr.Read())
                {                   
                    txtReaderType.Text = Convert.ToString(dr["TENLOAIDG"]);
                    txtReaderName.Text = Convert.ToString(dr["HOTEN"]);
                    txtSex.Text = Convert.ToString(dr["GIOITINH"]);
                    txtBirthday.Text = Convert.ToString(dr["NGAYSINH"]);
                    txtAddress.Text = Convert.ToString(dr["DIACHI"]);
                    txtDateTime.Text = Convert.ToString(dr["NGAYCAP"]);
                    txtNumberPhone.Text = Convert.ToString(dr["SODIENTHOAI"]);
                }
                btnDel.Text = "OK";
                txtReaderID.Enabled = false;
            }
            else if(btnDel.Text == "OK")
            {               
                Reader docgia = new Reader();
                docgia.SetReaderID(txtReaderID.Text);
                LibCard CardDel = new LibCard();
                CardDel.SetReaderID(txtReaderID.Text);
                if (CardDel.DelCard())
                {
                    if (docgia.DelReader())
                    {
                        MessageBox.Show("Đã xóa thẻ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        panelControl1.Controls.Clear();
                        LoadDataToGridCtrl();
                        panelControl1.Controls.Add(gridControl1);
                        btnDel.Text = "Xóa";
                        Cleartxt();
                        DisableTxtBox();
                        btnAdd.Enabled = true;
                        btnModify.Enabled = true;                        
                    }
                    else MessageBox.Show("Lỗi khi xóa thẻ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Lỗi! Không xóa được thẻ.","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Cleartxt();
            DisableTxtBox();
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
            btnModify.Enabled = true;
            btnAdd.Text = "Thêm";
            btnDel.Text = "Xóa";
            btnModify.Text = "Chỉnh sửa";
            panelControl1.Controls.Clear();
            LoadDataToGridCtrl();
            panelControl1.Controls.Add(gridControl1);
        }
    }
}
