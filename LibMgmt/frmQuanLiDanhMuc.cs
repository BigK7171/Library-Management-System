using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibMgmt
{
    public partial class frmQuanLiDanhMuc : Form
    {
        public frmQuanLiDanhMuc()
        {
            InitializeComponent();
        }
        public string StrConnect = "";        
        private void btnAuthor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StrConnect = "TACGIA";
            simpleButton1_Click(sender,e);
            panelCtrlNCC.Enabled = false;
            panelCtrlNgonngu.Enabled = false;
            panelCtrlNXB.Enabled = false;
            panelCtrlTacgia.Enabled = true;
            panelCtrlTypeOfBook.Enabled = false;
            txtMatacgia.Enabled = false;
            txtTentacgia.Enabled = false;
            panelCtrlData.Controls.Clear();
            UsrCtrl_Author Author = new UsrCtrl_Author();
            Author.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCtrlData.Controls.Add(Author);
        }

        private void btnLanguage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StrConnect = "NGONNGU";
            simpleButton1_Click(sender, e);
            panelCtrlNCC.Enabled = false;
            panelCtrlNgonngu.Enabled = true;
            panelCtrlNXB.Enabled = false;
            panelCtrlTacgia.Enabled = false;
            panelCtrlTypeOfBook.Enabled = false;
            txtMangongu.Enabled = false;
            txtTenngonngu.Enabled = false;
            panelCtrlData.Controls.Clear();
            UsrCtrl_Language Language = new UsrCtrl_Language();
            Language.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCtrlData.Controls.Add(Language);
        }

        private void btnTypeOfBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StrConnect = "LOAISACH";
            simpleButton1_Click(sender, e);
            panelCtrlNCC.Enabled = false;
            panelCtrlNgonngu.Enabled = false;
            panelCtrlNXB.Enabled = false;
            panelCtrlTacgia.Enabled = false;
            panelCtrlTypeOfBook.Enabled = true;
            txtMaloaisach.Enabled = false;
            txtTentheloai.Enabled = false;
            panelCtrlData.Controls.Clear();
            UsrCtrl_TypeOfBook TypeOfBook = new UsrCtrl_TypeOfBook();
            TypeOfBook.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCtrlData.Controls.Add(TypeOfBook);
        }

        private void btnPublisher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StrConnect = "NXB" ;
            simpleButton1_Click(sender, e);
            panelCtrlNCC.Enabled = false;
            panelCtrlNgonngu.Enabled = false;
            panelCtrlNXB.Enabled = true;
            panelCtrlTacgia.Enabled = false;
            panelCtrlTypeOfBook.Enabled = false;
            txtMaNXB.Enabled = false;
            txtTenNXB.Enabled = false;
            panelCtrlData.Controls.Clear();
            UsrCtrl_Publisher Publisher = new UsrCtrl_Publisher();
            Publisher.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCtrlData.Controls.Add(Publisher);
        }

        private void btnProvider_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StrConnect = "NHACUNGCAP";
            simpleButton1_Click(sender, e);
            panelCtrlNCC.Enabled = true;
            panelCtrlNgonngu.Enabled = false;
            panelCtrlNXB.Enabled = false;
            panelCtrlTacgia.Enabled = false;
            panelCtrlTypeOfBook.Enabled = false;
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            panelCtrlData.Controls.Clear();
            UsrCtrl_Provider Provider = new UsrCtrl_Provider();
            Provider.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCtrlData.Controls.Add(Provider);
        }        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {           
            if (StrConnect == "TACGIA")
            {
                try
                {
                    if (btnThem.Text == "Thêm")
                    {
                        btnCapnhat.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã tác giả và tên tác giả mới!", "Thông báo");
                        txtMatacgia.Enabled = true;
                        txtTentacgia.Enabled = true;
                        btnThem.Text = "OK";
                    }
                    else if (btnThem.Text == "OK")
                    {                        
                        SQL_Connection sqlcnt = new SQL_Connection();                        
                        sqlcnt.ExecuteQuery("insert into TACGIA values('" + txtMatacgia.Text + "',N'" + txtTentacgia.Text + "')");
                        MessageBox.Show("Đã thêm thành công tác giả mới","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        txtMatacgia.Text = "";
                        txtTentacgia.Text = "";
                        txtMatacgia.Enabled = false;
                        txtTentacgia.Enabled = false;
                        btnThem.Text = "Thêm";
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Author Author = new UsrCtrl_Author();
                        Author.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(Author);
                        btnCapnhat.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else if (StrConnect == "NGONNGU")
            {
                try
                {
                    if (btnThem.Text == "Thêm")
                    {
                        btnCapnhat.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã ngôn ngữ và ngôn ngữ mới!", "Thông báo");
                        txtMangongu.Enabled = true;
                        txtTenngonngu.Enabled = true;
                        btnThem.Text = "OK";
                    }
                    else if (btnThem.Text == "OK")
                    {                        
                        SQL_Connection sqlcnt = new SQL_Connection();                        
                        sqlcnt.ExecuteQuery("insert into NGONNGU values('" + txtMangongu.Text + "',N'" + txtTenngonngu.Text + "')");
                        MessageBox.Show("Đã thêm thành công ngôn ngữ mới","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        txtMangongu.Text = "";
                        txtTenngonngu.Text = "";
                        txtMangongu.Enabled = false;
                        txtTenngonngu.Enabled = false;
                        btnThem.Text = "Thêm";
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Language Language = new UsrCtrl_Language();
                        Language.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(Language);
                        btnCapnhat.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                } 
            }
            else if (StrConnect == "LOAISACH")
            {
                try
                {
                    if (btnThem.Text == "Thêm")
                    {
                        btnCapnhat.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã thể loại và thể loại mới!", "Thông báo");
                        txtMaloaisach.Enabled = true;
                        txtTentheloai.Enabled = true;
                        btnThem.Text = "OK";
                    }
                    else if (btnThem.Text == "OK")
                    {
                        SQL_Connection sqlcnt = new SQL_Connection();
                        sqlcnt.ExecuteQuery("insert into LOAISACH values('" + txtMaloaisach.Text + "',N'" + txtTentheloai.Text + "')");
                        MessageBox.Show("Đã thêm thành công thể loại mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMaloaisach.Text = "";
                        txtTentheloai.Text = "";
                        txtMaloaisach.Enabled = false;
                        txtTentheloai.Enabled = false;
                        btnThem.Text = "Thêm";
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_TypeOfBook TypeOfBook = new UsrCtrl_TypeOfBook();
                        TypeOfBook.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(TypeOfBook);
                        btnCapnhat.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else if (StrConnect == "NXB")
            {
                try
                {
                    if (btnThem.Text == "Thêm")
                    {
                        btnCapnhat.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã nhà xuất bản và tên nhà xuất bản mới!", "Thông báo");
                        txtMaNXB.Enabled = true;
                        txtTenNXB.Enabled = true;
                        btnThem.Text = "OK";
                    }
                    else if (btnThem.Text == "OK")
                    {
                        SQL_Connection sqlcnt = new SQL_Connection();
                        sqlcnt.ExecuteQuery("insert into NXB values('" + txtMaNXB.Text + "',N'" + txtTenNXB.Text + "')");
                        MessageBox.Show("Đã thêm thành công nhà xuất bản mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMaNXB.Text = "";
                        txtTenNXB.Text = "";
                        txtMaNXB.Enabled = false;
                        txtTenNXB.Enabled = false;
                        btnThem.Text = "Thêm";
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Publisher NXB = new UsrCtrl_Publisher();
                        NXB.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(NXB);
                        btnCapnhat.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else if (StrConnect == "NHACUNGCAP")
            {
                try
                {
                    if (btnThem.Text == "Thêm")
                    {
                        btnCapnhat.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã nhà cung cấp và tên nhà cung cấp mới!", "Thông báo");
                        txtMaNCC.Enabled = true;
                        txtTenNCC.Enabled = true;
                        btnThem.Text = "OK";
                    }
                    else if (btnThem.Text == "OK")
                    {
                        SQL_Connection sqlcnt = new SQL_Connection();
                        sqlcnt.ExecuteQuery("insert into NHACUNGCAP values('" + txtMaNCC.Text + "',N'" + txtTenNCC.Text + "')");
                        MessageBox.Show("Đã thêm thành công nhà cung cấp mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMaNCC.Text = "";
                        txtTenNCC.Text = "";
                        txtMaNCC.Enabled = false;
                        txtTenNCC.Enabled = false;
                        btnThem.Text = "Thêm";
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Provider NCC = new UsrCtrl_Provider();
                        NCC.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(NCC);
                        btnCapnhat.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {            
            if (StrConnect == "TACGIA")
            {
                try
                {
                    if (btnCapnhat.Text == "Cập nhật")
                    {
                        btnThem.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã tác giả cần cập nhật", "Thông báo");
                        txtMatacgia.Enabled = true;
                        btnCapnhat.Text = "OK";
                    }
                    else if(btnCapnhat.Text == "OK")
                    {
                        txtMatacgia.Enabled = false;
                        txtTentacgia.Enabled = true;
                        SQL_Connection sqlcnt = new SQL_Connection();
                        SqlDataReader dtcheck = sqlcnt.GetDataReaderByUsingSP("CheckAuthor");
                        while (dtcheck.Read())
                        {
                            if (Convert.ToString(dtcheck["MATACGIA"]) == txtMatacgia.Text)
                            {
                                txtTentacgia.Text = Convert.ToString(dtcheck["HOTEN"]);
                            }
                        }
                        btnCapnhat.Text = "Xác nhận";
                    }
                    else if (btnCapnhat.Text == "Xác nhận")
                    {
                        try
                        {
                            SQL_Connection _sqlcnt = new SQL_Connection();
                            _sqlcnt.ExecuteQuery("update TACGIA set HOTEN = N'" + txtTentacgia.Text + "' where MATACGIA = '" + txtMatacgia.Text + "'");
                            MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            btnCapnhat.Text = "Cập nhật";
                            txtTentacgia.Enabled = false;
                            txtMatacgia.Text = "";
                            txtTentacgia.Text = "";
                            panelCtrlData.Controls.Clear();
                            UsrCtrl_Author Author = new UsrCtrl_Author();
                            Author.Dock = System.Windows.Forms.DockStyle.Fill;
                            panelCtrlData.Controls.Add(Author);
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            if (StrConnect == "NGONNGU")
            {
                try
                {
                     if (btnCapnhat.Text == "Cập nhật")
                    {
                        btnThem.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã ngôn ngữ cần cập nhật", "Thông báo");
                        txtMangongu.Enabled = true;
                        btnCapnhat.Text = "OK";
                    }
                    else if(btnCapnhat.Text == "OK")
                    {
                        txtMangongu.Enabled = false;
                        txtTenngonngu.Enabled = true;
                        SQL_Connection sqlcnt = new SQL_Connection();
                        SqlDataReader dtcheck = sqlcnt.GetDataReaderByUsingSP("CheckNgonNgu");
                        while (dtcheck.Read())
                        {
                            if (Convert.ToString(dtcheck["MANGONNGU"]) == txtMangongu.Text)
                            {
                                txtTenngonngu.Text = Convert.ToString(dtcheck["NGONNGU"]);
                            }
                        }
                        btnCapnhat.Text = "Xác nhận";
                    }
                     else if (btnCapnhat.Text == "Xác nhận")
                     {
                         try
                         {
                             SQL_Connection _sqlcnt = new SQL_Connection();
                             _sqlcnt.ExecuteQuery("update NGONNGU set NGONNGU = N'" + txtTenngonngu.Text + "' where MANGONNGU = '" + txtMangongu.Text + "'");
                             MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                             btnCapnhat.Text = "Cập nhật";
                             txtTenngonngu.Enabled = false;
                             txtMangongu.Text = "";
                             txtTenngonngu.Text = "";
                             panelCtrlData.Controls.Clear();
                             UsrCtrl_Language Language = new UsrCtrl_Language();
                             Language.Dock = System.Windows.Forms.DockStyle.Fill;
                             panelCtrlData.Controls.Add(Language);
                             btnThem.Enabled = true;
                             btnXoa.Enabled = true;
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (StrConnect == "LOAISACH")
            {
                try
                {
                    if (btnCapnhat.Text == "Cập nhật")
                    {
                        btnThem.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã thể loại cần cập nhật", "Thông báo");
                        txtMaloaisach.Enabled = true;
                        btnCapnhat.Text = "OK";
                    }
                    else if (btnCapnhat.Text == "OK")
                    {
                        txtMaloaisach.Enabled = false;
                        txtTentheloai.Enabled = true;
                        SQL_Connection sqlcnt = new SQL_Connection();
                        SqlDataReader dtcheck = sqlcnt.GetDataReaderByUsingSP("CheckTypeOfBook");
                        while (dtcheck.Read())
                        {
                            if (Convert.ToString(dtcheck["MALOAISACH"]) == txtMaloaisach.Text)
                            {
                                txtTentheloai.Text = Convert.ToString(dtcheck["TENLOAISACH"]);
                            }
                        }
                        btnCapnhat.Text = "Xác nhận";
                    }
                    else if (btnCapnhat.Text == "Xác nhận")
                    {
                        try
                        {
                            SQL_Connection _sqlcnt = new SQL_Connection();
                            _sqlcnt.ExecuteQuery("update LOAISACH set TENLOAISACH = N'" + txtTentheloai.Text + "' where MALOAISACH = '" + txtMaloaisach.Text + "'");
                            MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            btnCapnhat.Text = "Cập nhật";
                            txtTentheloai.Enabled = false;
                            txtMaloaisach.Text = "";
                            txtTentheloai.Text = "";
                            panelCtrlData.Controls.Clear();
                            UsrCtrl_TypeOfBook TypeOfBook = new UsrCtrl_TypeOfBook();
                            TypeOfBook.Dock = System.Windows.Forms.DockStyle.Fill;
                            panelCtrlData.Controls.Add(TypeOfBook);
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (StrConnect == "NXB")
            {
                try
                {
                    if (btnCapnhat.Text == "Cập nhật")
                    {
                        btnThem.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã nhà xuất bản cần cập nhật", "Thông báo");
                        txtMaNXB.Enabled = true;
                        btnCapnhat.Text = "OK";
                    }
                    else if (btnCapnhat.Text == "OK")
                    {
                        txtMaNXB.Enabled = false;
                        txtTenNXB.Enabled = true;
                        SQL_Connection sqlcnt = new SQL_Connection();
                        SqlDataReader dtcheck = sqlcnt.GetDataReaderByUsingSP("CheckNXB");
                        while (dtcheck.Read())
                        {
                            if (Convert.ToString(dtcheck["MANXB"]) == txtMaNXB.Text)
                            {
                                txtTenNXB.Text = Convert.ToString(dtcheck["TENNXB"]);
                            }
                        }
                        btnCapnhat.Text = "Xác nhận";
                    }
                    else if (btnCapnhat.Text == "Xác nhận")
                    {
                        try
                        {
                            SQL_Connection _sqlcnt = new SQL_Connection();
                            _sqlcnt.ExecuteQuery("update NXB set TENNXB = N'" + txtTenNXB.Text + "' where MANXB = '" + txtMaNXB.Text + "'");
                            MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            btnCapnhat.Text = "Cập nhật";
                            txtTenNXB.Enabled = false;
                            txtMaNXB.Text = "";
                            txtTenNXB.Text = "";
                            panelCtrlData.Controls.Clear();
                            UsrCtrl_Publisher NXB = new UsrCtrl_Publisher();
                            NXB.Dock = System.Windows.Forms.DockStyle.Fill;
                            panelCtrlData.Controls.Add(NXB);
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (StrConnect == "NHACUNGCAP")
            {
                try
                {
                    if (btnCapnhat.Text == "Cập nhật")
                    {
                        btnThem.Enabled = false;
                        btnXoa.Enabled = false;
                        MessageBox.Show("Vui lòng nhập mã nhà cung cấp cần cập nhật", "Thông báo");
                        txtMaNCC.Enabled = true;
                        btnCapnhat.Text = "OK";
                    }
                    else if (btnCapnhat.Text == "OK")
                    {
                        txtMaNCC.Enabled = false;
                        txtTenNCC.Enabled = true;
                        SQL_Connection sqlcnt = new SQL_Connection();
                        SqlDataReader dtcheck = sqlcnt.GetDataReaderByUsingSP("CheckNCC");
                        while (dtcheck.Read())
                        {
                            if (Convert.ToString(dtcheck["MANCC"]) == txtMaNCC.Text)
                            {
                                txtTenNCC.Text = Convert.ToString(dtcheck["TENNCC"]);
                            }
                        }
                        btnCapnhat.Text = "Xác nhận";
                    }
                    else if (btnCapnhat.Text == "Xác nhận")
                    {
                        try
                        {
                            SQL_Connection _sqlcnt = new SQL_Connection();
                            _sqlcnt.ExecuteQuery("update NHACUNGCAP set TENNCC = N'" + txtTenNCC.Text + "' where MANCC = '" + txtMaNCC.Text + "'");
                            MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            btnCapnhat.Text = "Cập nhật";
                            txtTenNCC.Enabled = false;
                            txtMaNCC.Text = "";
                            txtTenNCC.Text = "";
                            panelCtrlData.Controls.Clear();
                            UsrCtrl_Provider NCC = new UsrCtrl_Provider();
                            NCC.Dock = System.Windows.Forms.DockStyle.Fill;
                            panelCtrlData.Controls.Add(NCC);
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtMatacgia.Text = "";         txtMatacgia.Enabled = false;
            txtTentacgia.Text = "";        txtTentacgia.Enabled = false;
            txtMangongu.Text = "";         txtMangongu.Enabled = false;
            txtTenngonngu.Text = "";       txtTenngonngu.Enabled = false;
            txtMaloaisach.Text = "";       txtMaloaisach.Enabled = false;
            txtTentheloai.Text = "";       txtTentheloai.Enabled = false;
            txtMaNXB.Text = "";            txtMaNXB.Enabled = false;
            txtTenNXB.Text = "";           txtTenNXB.Enabled = false;
            txtMaNCC.Text = "";            txtMaNCC.Enabled = false;
            txtTenNCC.Text = "";           txtTenNCC.Enabled = false;
            btnThem.Enabled = true; btnThem.Text = "Thêm";
            btnCapnhat.Enabled = true; btnCapnhat.Text = "Cập nhật";
            btnXoa.Enabled = true; btnXoa.Text = "Xóa";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (StrConnect == "TACGIA")
            {
                if (btnXoa.Text == "Xóa")
                {
                    MessageBox.Show("Hãy nhập mã tác giả cần xóa!","Thông báo");
                    btnThem.Enabled = false;
                    btnCapnhat.Enabled = false;
                    btnXoa.Text = "OK";
                    txtMatacgia.Enabled = true;
                }
                else if (btnXoa.Text == "OK")
                {
                    try
                    {
                        
                        SQL_Connection _sqlcnt = new SQL_Connection();
                        _sqlcnt.ExecuteQuery("delete from TACGIA where MATACGIA = '"+txtMatacgia.Text+"'");
                        MessageBox.Show("Đã xóa thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk );
                        btnXoa.Text = "Xóa";
                        btnThem.Enabled = true;
                        btnCapnhat.Enabled = true;
                        txtMatacgia.Text = "";
                        txtMatacgia.Enabled = false;
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Author Author = new UsrCtrl_Author();
                        Author.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(Author);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            if (StrConnect == "NGONNGU")
            {
                if (btnXoa.Text == "Xóa")
                {
                    MessageBox.Show("Hãy nhập mã ngôn ngữ cần xóa!", "Thông báo");
                    btnThem.Enabled = false;
                    btnCapnhat.Enabled = false;
                    btnXoa.Text = "OK";
                    txtMangongu.Enabled = true;
                }
                else if (btnXoa.Text == "OK")
                {
                    try
                    {

                        SQL_Connection _sqlcnt = new SQL_Connection();
                        _sqlcnt.ExecuteQuery("delete from NGONNGU where MANGONNGU = '" + txtMangongu.Text + "'");
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        btnXoa.Text = "Xóa";
                        btnThem.Enabled = true;
                        btnCapnhat.Enabled = true;
                        txtMangongu.Text = "";
                        txtMangongu.Enabled = false;
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Language Language = new UsrCtrl_Language();
                        Language.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(Language);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (StrConnect == "LOAISACH")
            {
                if (btnXoa.Text == "Xóa")
                {
                    MessageBox.Show("Hãy nhập mã thể loại cần xóa!", "Thông báo");
                    btnThem.Enabled = false;
                    btnCapnhat.Enabled = false;
                    btnXoa.Text = "OK";
                    txtMaloaisach.Enabled = true;
                }
                else if (btnXoa.Text == "OK")
                {
                    try
                    {

                        SQL_Connection _sqlcnt = new SQL_Connection();
                        _sqlcnt.ExecuteQuery("delete from LOAISACH where MALOAISACH = '" + txtMaloaisach.Text + "'");
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        btnXoa.Text = "Xóa";
                        btnThem.Enabled = true;
                        btnCapnhat.Enabled = true;
                        txtMaloaisach.Text = "";
                        txtMaloaisach.Enabled = false;
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_TypeOfBook TypeOfBook = new UsrCtrl_TypeOfBook();
                        TypeOfBook.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(TypeOfBook);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (StrConnect == "NXB")
            {
                if (btnXoa.Text == "Xóa")
                {
                    MessageBox.Show("Hãy nhập mã nhà xuất bản cần xóa!", "Thông báo");
                    btnThem.Enabled = false;
                    btnCapnhat.Enabled = false;
                    btnXoa.Text = "OK";
                    txtMaNXB.Enabled = true;
                }
                else if (btnXoa.Text == "OK")
                {
                    try
                    {

                        SQL_Connection _sqlcnt = new SQL_Connection();
                        _sqlcnt.ExecuteQuery("delete from NXB where MANXB = '" + txtMaNXB.Text + "'");
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        btnXoa.Text = "Xóa";
                        btnThem.Enabled = true;
                        btnCapnhat.Enabled = true;
                        txtMaNXB.Text = "";
                        txtMaNXB.Enabled = false;
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Publisher NXB = new UsrCtrl_Publisher();
                        NXB.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(NXB);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (StrConnect == "NHACUNGCAP")
            {
                if (btnXoa.Text == "Xóa")
                {
                    MessageBox.Show("Hãy nhập mã nhà cung cấp cần xóa!", "Thông báo");
                    btnThem.Enabled = false;
                    btnCapnhat.Enabled = false;
                    btnXoa.Text = "OK";
                    txtMaNCC.Enabled = true;
                }
                else if (btnXoa.Text == "OK")
                {
                    try
                    {

                        SQL_Connection _sqlcnt = new SQL_Connection();
                        _sqlcnt.ExecuteQuery("delete from NHACUNGCAP where MANCC = '" + txtMaNCC.Text + "'");
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        btnXoa.Text = "Xóa";
                        btnThem.Enabled = true;
                        btnCapnhat.Enabled = true;
                        txtMaNCC.Text = "";
                        txtMaNCC.Enabled = false;
                        panelCtrlData.Controls.Clear();
                        UsrCtrl_Provider NCC = new UsrCtrl_Provider();
                        NCC.Dock = System.Windows.Forms.DockStyle.Fill;
                        panelCtrlData.Controls.Add(NCC);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }        
    }
}
