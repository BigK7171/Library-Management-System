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
    public partial class UsrCtrl_UpdateBook : UserControl
    {
        public UsrCtrl_UpdateBook()
        {
            InitializeComponent();
            ClearTxtBox();
            DisableTxtBox();
        }

        public void ClearTxtBox()
        {
            txtBookID.Text = "";
            txtBookName.Text = "";
            txtType.Text = "";
            txtAuthor.Text = "";
            txtLanguage.Text = "";
            txtCost.Text = "";
            txtPublisher.Text = "";
            txtYearPublish.Text = "";
            txtRePublish.Text = "";
            txtProvider.Text = "";
            txtLocation.Text = "";
        }
        public void DisableTxtBox()
        {
            txtBookID.Enabled = false;
            txtBookName.Enabled = false;
            txtType.Enabled = false;
            txtAuthor.Enabled = false;
            txtLanguage.Enabled = false;
            txtCost.Enabled = false;
            txtPublisher.Enabled = false;
            txtYearPublish.Enabled = false;
            txtRePublish.Enabled = false;
            txtProvider.Enabled = false;
            txtLocation.Enabled = false; 
        }
        public void EnableTxtBox()
        {
            txtBookID.Enabled = true;
            txtBookName.Enabled = true;
            txtType.Enabled = true;
            txtAuthor.Enabled = true;
            txtLanguage.Enabled = true;
            txtCost.Enabled = true;
            txtPublisher.Enabled = true;
            txtYearPublish.Enabled = true;
            txtRePublish.Enabled = true;
            txtProvider.Enabled = true;
            txtLocation.Enabled = true; 
        }
        private void UsrCtrl_UpdateBook_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
            //LoadFilterInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearTxtBox();
            DisableTxtBox();
            btnAdd.Enabled = true; btnAdd.Text = "Thêm";
            btnModify.Enabled = true; btnModify.Text = "Chỉnh sửa";
            btnDel.Enabled = true; btnDel.Text = "Xóa";
        }
        public void LoadDataToGrid()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            DataTable data = sqlcnt.GetDataByUsingSP("UpdateBookInfo");
            gridControl1.DataSource = data;
            panelControl1.Controls.Add(gridControl1);
        }
        public void LoadFilterInfo()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            SqlDataReader dr = sqlcnt.GetDataReader("select MAVITRI from VITRI");
            while (dr.Read())
            {
                txtLocation.Properties.Items.AddRange(new object[] { dr[0].ToString() });
            }
            //SQL_Connection.CloseConnection();

            SqlDataReader dr1 = sqlcnt.GetDataReader("select TENLOAISACH from LOAISACH");
            while (dr1.Read())
            {
                txtType.Properties.Items.AddRange(new object[] { dr1[0].ToString() });
            }
            //SQL_Connection.CloseConnection();
            SqlDataReader dr2 = sqlcnt.GetDataReader("select HOTEN from TACGIA");
            while (dr2.Read())
            {
                txtAuthor.Properties.Items.AddRange(new object[] { dr2[0].ToString() });
            }
            //SQL_Connection.CloseConnection();
            SqlDataReader dr3 = sqlcnt.GetDataReader("select NGONNGU from NGONNGU");
            while (dr3.Read())
            {
                txtLanguage.Properties.Items.AddRange(new object[] { dr3[0].ToString() });
            }
            //SQL_Connection.CloseConnection();
            SqlDataReader dr4 = sqlcnt.GetDataReader("select TENNXB from NXB");
            while (dr4.Read())
            {
                txtPublisher.Properties.Items.AddRange(new object[] { dr4[0].ToString() });
            }
            //SQL_Connection.CloseConnection();
            SqlDataReader dr5 = sqlcnt.GetDataReader("select TENNCC from NHACUNGCAP");
            while (dr5.Read())
            {
                txtProvider.Properties.Items.AddRange(new object[] { dr5[0].ToString() });
            }
            SQL_Connection.CloseConnection();
        }

        string BookID;
        public void SetBookID()
        {
            BookID = "";
            SQL_Connection sqlcnt = new SQL_Connection();           
            SqlDataReader dr = sqlcnt.GetDataReader("select MASACH from SACH");
            while (dr.Read()) BookID = dr[0].ToString();
            SQL_Connection.CloseConnection();
            if (BookID == "") { BookID = "S0001"; }
            else
            {
                string str = BookID.Substring(1, BookID.Length - 1);
                double i = double.Parse(str);
                i++;
                if (i < 10)
                {
                    str = "S000" + i.ToString();
                }
                else if (i < 100)
                {
                    str = "S00" + i.ToString();
                }
                else if (i < 1000)
                {
                    str = "S0" + i.ToString();
                }
                else if (i < 10000)
                {
                    str = "S" + i.ToString();
                }
                BookID = str;
            }
            txtBookID.Text = BookID;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Thêm")
            {               
                EnableTxtBox();
                LoadFilterInfo();
                btnAdd.Text = "Chấp nhận";
                SetBookID();
                btnModify.Enabled = false;
                btnDel.Enabled = false;
            }
            else if (btnAdd.Text == "Chấp nhận")
            {
                try
                {
                    string typeid, languageid, authorid, publisherid, providerid;
                    Book Sach = new Book();                    
                    Sach.SetBookID(txtBookID.Text);
                    Sach.SetCost(Convert.ToInt16(txtCost.Text));
                    Sach.SetBookName(txtBookName.Text);
                    Sach.SetYearPublish(Convert.ToInt16(txtYearPublish.Text));
                    Sach.SetRePublish(Convert.ToInt16(txtRePublish.Text));
                    Sach.SetLocationID(txtLocation.Text);
                    SQL_Connection sqlcnt = new SQL_Connection();
                    SqlDataReader dr1 = sqlcnt.GetDataReader("select *from NGONNGU");
                    while (dr1.Read())
                    {
                        if (Convert.ToString(dr1["NGONNGU"]) == txtLanguage.Text)
                        {
                            languageid = Convert.ToString(dr1["MANGONNGU"]);
                            Sach.SetLanguageID(languageid);
                        }
                    }
                    //SQL_Connection.CloseConnection();

                    SqlDataReader dr2 = sqlcnt.GetDataReader("select *from LOAISACH");
                    while (dr2.Read())
                    {
                        if (Convert.ToString(dr2["TENLOAISACH"]) == txtType.Text)
                        {
                            typeid = Convert.ToString(dr2["MALOAISACH"]);
                            Sach.SetTypeID(typeid);
                        }
                    }
                    //SQL_Connection.CloseConnection();                   
                    SqlDataReader dr3 = sqlcnt.GetDataReader("select *from NXB");
                    while (dr3.Read())
                    {
                        if (Convert.ToString(dr3["TENNXB"]) == txtPublisher.Text)
                        {
                            publisherid = Convert.ToString(dr3["MANXB"]);
                            Sach.SetPublisherID(publisherid);
                        }
                    }
                    //SQL_Connection.CloseConnection();
                    
                    SqlDataReader dr4 = sqlcnt.GetDataReader("select *from TACGIA");
                    while (dr4.Read())
                    {
                        if (Convert.ToString(dr4["HOTEN"]) == txtAuthor.Text)
                        {
                            authorid = Convert.ToString(dr4["MATACGIA"]);
                            Sach.SetAuthorID(authorid);
                        }
                    }
                    //SQL_Connection.CloseConnection();
                    
                    SqlDataReader dr5 = sqlcnt.GetDataReader("SELECT *FROM NHACUNGCAP");
                    while (dr5.Read())
                    {
                        if (Convert.ToString(dr5["TENNCC"]) == txtProvider.Text)
                        {
                            providerid = Convert.ToString(dr5["MANCC"]);
                            Sach.SetProviderID(providerid);
                        }
                    }
                    //SQL_Connection.CloseConnection();   
                    if (Sach.AddBook())
                    {
                        if (Sach.Add_St())
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            UsrCtrl_UpdateBook_Load(sender,e);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật thông tin sáng tác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                btnAdd.Text = "Thêm";
                ClearTxtBox();
                DisableTxtBox();
                btnModify.Enabled = true;
                btnDel.Enabled = true;                
            }
        }

        bool kt = false;
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text == "Chỉnh sửa")
            {
                txtBookID.Enabled = true;
                MessageBox.Show("Nhập vào mã sách cần chỉnh sửa", "Thông Báo");
                btnModify.Text = "Xác nhận";
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
            }

            else if (btnModify.Text == "Xác nhận")
            {
                SQL_Connection sqlcnt = new SQL_Connection();
                SqlDataReader dr1 = sqlcnt.GetDataReader("SELECT SACH.MASACH FROM SACH");
                while (dr1.Read())
                {
                    if (txtBookID.Text.Equals(dr1["MASACH"].ToString().Trim(), StringComparison.CurrentCultureIgnoreCase))
                        kt = true;
                }

                if (kt)
                {
                    LoadFilterInfo();
                    SQL_Connection _sqlcnt = new SQL_Connection();                    
                    string query = "select *from SACH,LOAISACH,NGONNGU,NXB,TACGIA,SANGTAC,NHACUNGCAP,VITRI where SACH.MASACH='" + txtBookID.Text + "' AND SACH.MANGONNGU=NGONNGU.MANGONNGU AND SACH.MALOAISACH=LOAISACH.MALOAISACH AND SACH.MAVITRI=VITRI.MAVITRI AND SACH.MANCC=NHACUNGCAP.MANCC AND SACH.MANXB=NXB.MANXB AND SACH.MASACH=SANGTAC.MASACH AND TACGIA.MATACGIA=SANGTAC.MATACGIA";
                    SqlDataReader dr = _sqlcnt.GetDataReader(query);
                    while (dr.Read())
                    {
                        txtBookName.Text = Convert.ToString(dr["TENSACH"]);
                        txtCost.Text = Convert.ToString(dr["GIA"]);
                        txtProvider.Text = Convert.ToString(dr["TENNCC"]);
                        txtLocation.Text = Convert.ToString(dr["MAVITRI"]);
                        txtYearPublish.Text = Convert.ToString(dr["NAMXUATBAN"]);
                        txtLanguage.Text = Convert.ToString(dr["NGONNGU"]);
                        txtAuthor.Text = Convert.ToString(dr["HOTEN"]);
                        txtType.Text = Convert.ToString(dr["TENLOAISACH"]);
                        txtPublisher.Text = Convert.ToString(dr["TENNXB"]);
                        txtRePublish.Text = Convert.ToString(dr["LANXUATBAN"]);
                    }
                    btnModify.Text = "Chấp nhận";
                    EnableTxtBox();
                    txtBookID.Enabled = false;
                }
                else MessageBox.Show("Hãy chắc chắn bạn đã nhập đúng mã sách", "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (btnModify.Text == "Chấp nhận")
            {
                string typeid, authorid, languageid, publisherid, providerid;
                Book Sach = new Book();
                Sach.SetBookID(txtBookID.Text);
                Sach.SetCost(Convert.ToInt16(txtCost.Text.Substring(0,5)));
                Sach.SetBookName(txtBookName.Text);
                Sach.SetRePublish(Convert.ToInt16(txtRePublish.Text));
                Sach.SetYearPublish(Convert.ToInt16(txtYearPublish.Text));
                Sach.SetLocationID(txtLocation.Text);
                SQL_Connection __sqlcnt = new SQL_Connection();               
                SqlDataReader dr1 = __sqlcnt.GetDataReader("select *from NGONNGU");
                while (dr1.Read())
                {
                    if (Convert.ToString(dr1["NGONNGU"]) == txtLanguage.Text)
                    {
                        languageid = Convert.ToString(dr1["MANGONNGU"]);
                        Sach.SetLanguageID(languageid);
                    }
                }
                SQL_Connection.CloseConnection();
                
                SqlDataReader dr2 = __sqlcnt.GetDataReader("select *from NXB");
                while (dr2.Read())
                {
                    if (Convert.ToString(dr2["TENNXB"]) == txtPublisher.Text)
                    {
                        publisherid = Convert.ToString(dr2["MANXB"]);
                        Sach.SetPublisherID(publisherid);                        
                    }
                }
                SQL_Connection.CloseConnection();

                SqlDataReader dr3 = __sqlcnt.GetDataReader("select *from LOAISACH");
                while (dr3.Read())
                {
                    if (Convert.ToString(dr3["TENLOAISACH"]) == txtType.Text)
                    {
                        typeid = Convert.ToString(dr3["MALOAISACH"]);
                        Sach.SetTypeID(typeid);                        
                    }
                }
                SQL_Connection.CloseConnection();
                
                SqlDataReader dr4 = __sqlcnt.GetDataReader("select *from TACGIA");
                while (dr4.Read())
                {
                    if (Convert.ToString(dr4["HOTEN"]) == txtAuthor.Text)
                    {
                        authorid = Convert.ToString(dr4["MATACGIA"]);
                        Sach.SetAuthorID(authorid);                        
                    }
                }
                SQL_Connection.CloseConnection();
                
                SqlDataReader dr5 = __sqlcnt.GetDataReader("select *from NHACUNGCAP");
                while (dr5.Read())
                {
                    if (Convert.ToString(dr5["TENNCC"]) == txtProvider.Text)
                    {
                        providerid = Convert.ToString(dr5["MANCC"]);
                        Sach.SetProviderID(providerid);                        
                    }
                }
                SQL_Connection.CloseConnection();
                if (Sach.UpdateBook())
                {
                    if (Sach.Update_St())
                    {
                        MessageBox.Show("Đã cập nhật thành công.", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        UsrCtrl_UpdateBook_Load(sender, e);
                        btnAdd.Enabled = true;
                        btnDel.Enabled = true;
                    }
                    else MessageBox.Show("Lỗi khi cập nhật thông tin sáng tác.", "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else MessageBox.Show("Không cập nhật được sách.", "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ClearTxtBox();
                DisableTxtBox();
                btnModify.Text = "Chỉnh sửa";
                btnAdd.Enabled = true;
                btnDel.Enabled = true;                
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(btnDel.Text == "Xóa")
            {
                txtBookID.Enabled = true;
                MessageBox.Show("Nhập mã sách cần xóa","Thông báo");
                btnDel.Text = "Xác nhận";
                btnAdd.Enabled = false;
                btnModify.Enabled = false;
            }
            else if(btnDel.Text == "Xác nhận")
            {
                txtBookID.Enabled = false;
                SQL_Connection sqlcnt = new SQL_Connection();
                string query = "select SACH.TENSACH, SACH.MAVITRI, LOAISACH.TENLOAISACH,NGONNGU.NGONNGU, NXB.TENNXB, NHACUNGCAP.TENNCC, SACH.NAMXUATBAN, SACH.LANXUATBAN, SACH.GIA,TACGIA.HOTEN  from SACH,LOAISACH,NGONNGU,NXB,NHACUNGCAP,SANGTAC,TACGIA where SACH.MASACH = '" + txtBookID.Text + "' and SACH.MALOAISACH = LOAISACH.MALOAISACH and SACH.MANGONNGU = NGONNGU.MANGONNGU and SACH.MANXB = NXB.MANXB and SACH.MANCC = NHACUNGCAP.MANCC and SACH.MASACH= SANGTAC.MASACH and SANGTAC.MATACGIA = TACGIA.MATACGIA ";
                SqlDataReader dr = sqlcnt.GetDataReader(query);
                while (dr.Read())
                {
                    txtBookName.Text = Convert.ToString(dr["TENSACH"]);
                    txtType.Text = Convert.ToString(dr["TENLOAISACH"]);
                    txtLanguage.Text = Convert.ToString(dr["NGONNGU"]);
                    txtAuthor.Text = Convert.ToString(dr["HOTEN"]);
                    txtCost.Text = Convert.ToString(dr["GIA"]);
                    txtPublisher.Text = Convert.ToString(dr["TENNXB"]);
                    txtYearPublish.Text = Convert.ToString(dr["NAMXUATBAN"]);
                    txtRePublish.Text = Convert.ToString(dr["LANXUATBAN"]);
                    txtProvider.Text = Convert.ToString(dr["TENNCC"]);
                    txtLocation.Text = Convert.ToString(dr["MAVITRI"]);
                }
                btnDel.Text = "Chấp nhận";
            }
            else if (btnDel.Text == "Chấp nhận")
            {
                DialogResult dlg =  MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == DialogResult.No)
                {
                    btnCancel_Click(sender, e);
                }
                else if (dlg == DialogResult.Yes)
                {
                    Book Sach = new Book();
                    Sach.SetBookID(txtBookID.Text);
                    if (Sach.Del_St())
                    {
                        if (Sach.DelBook())
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            UsrCtrl_UpdateBook_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa thông tin sáng tác!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    ClearTxtBox();
                    DisableTxtBox();
                    btnDel.Text = "Xóa";
                    btnAdd.Enabled = true;
                    btnModify.Enabled = true;
                }
            }
        }
    }
}
