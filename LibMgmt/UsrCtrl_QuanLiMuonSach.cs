using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using System.Xml;
using System.Collections;

namespace LibMgmt
{
    public partial class UsrCtrl_QuanLiMuonSach : UserControl
    {
        public UsrCtrl_QuanLiMuonSach()
        {
            InitializeComponent();
            txtBookID.Enabled = false;
            txtBorrowCouponID.Enabled = false;
            btnChoMuon.Enabled = false;
            btnCheckBook.Enabled = false;
            DisableTxtBook();
            DisableTxtReader();
        }
        bool CheckReader = false, CheckBook = false;
        int _MaxBorrow, CountBorrow = 0;
        string Staff = "", DateBorrow = "", Deadline = "";
        public void GetStaff()
        {
            StreamReader sr = new StreamReader("luu nhan vien.txt");
            Staff = sr.ReadLine();
            sr.Close();
        }
        public void MaxBorrow()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "select * from DOCGIA, LOAIDOCGIA where DOCGIA.MADOCGIA = '"+txtReaderID.Text+"' and DOCGIA.MALOAIDOCGIA = LOAIDOCGIA.MALOAIDOCGIA";
            SqlDataReader dr = sqlcnt.GetDataReader(query);
            while (dr.Read())
            {
                _MaxBorrow = Convert.ToInt16(dr["SOLUONGMUONTOIDA"]);
            }
        }
        public void ClearTxtReader()
        {
            txtName.Text = "";
            txtTypeOfReader.Text = "";
            txtSex.Text = "";
            txtBirthday.Text = "";
            txtAddress.Text = "";
            txtTimeout.Text = "";
        }
        public void ClearTxtBook()
        {
            txtBookName.Text = "";
            txtTypeOfBook.Text = "";
            txtAuthor.Text = "";
            txtLanguage.Text = "";
            txtPublisher.Text = "";
            txtYearPublish.Text = "";
            txtRePublish.Text = "";
            txtProvider.Text = "";
            txtCost.Text = "";
            txtKho.Text = ""; txtKe.Text = ""; txtNgan.Text = "";
        }
        public void DisableTxtReader()
        {
            txtName.Enabled = false;
            txtTypeOfReader.Enabled = false;
            txtSex.Enabled = false;
            txtBirthday.Enabled = false;
            txtAddress.Enabled = false;
            txtTimeout.Enabled = false;
        }
        public void EnableTxtReader()
        {
            txtName.Enabled = true;
            txtTypeOfReader.Enabled = true;
            txtSex.Enabled = true;
            txtBirthday.Enabled = true;
            txtAddress.Enabled = true;
            txtTimeout.Enabled = true;
        }
        public void DisableTxtBook()
        {
            txtBookName.Enabled = false;
            txtTypeOfBook.Enabled = false;
            txtAuthor.Enabled = false;
            txtLanguage.Enabled = false;
            txtPublisher.Enabled = false;
            txtYearPublish.Enabled = false;
            txtRePublish.Enabled = false;           
            txtProvider.Enabled = false;
            txtCost.Enabled = false;
            txtKho.Enabled = false;
            txtKe.Enabled = false;
            txtNgan.Enabled = false;
        }
        public void EnableTxtBook()
        {
            txtBookName.Enabled = true;
            txtTypeOfBook.Enabled = true;
            txtAuthor.Enabled = true;
            txtLanguage.Enabled = true;
            txtPublisher.Enabled = true;
            txtYearPublish.Enabled = true;
            txtRePublish.Enabled = true;            
            txtProvider.Enabled = true;
            txtCost.Enabled = true;
            txtKho.Enabled = true;
            txtKe.Enabled = true;
            txtNgan.Enabled = true;
        }
        public void GetTempoCoupon()
        {
            TempoCoupon = "";
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "select MAPHIEU from PHIEUMUON";
            SqlDataReader dr = sqlcnt.GetDataReader(query);
            while (dr.Read())
            {
                TempoCoupon = dr["MAPHIEU"].ToString();
            }
            if (TempoCoupon == "")
            {
                TempoCoupon = "PM0001";
            }
            else
            {
                string str = TempoCoupon.Substring(2, TempoCoupon.Length - 2);
                double dn = double.Parse(str);
                dn++;
                if (dn <10)
                {
                    str = "PM000" + dn.ToString();
                }
                else if (dn>=10 && dn < 100 )
                {
                    str = "PM00" + dn.ToString();
                }
                else if (dn>=100 && dn < 1000)
                {
                    str = "PM0" + dn.ToString();
                }
                else if (dn>=1000 && dn < 10000)
                {
                    str = "PM" + dn.ToString();
                }
                TempoCoupon = str;               
            }
            txtBorrowCouponID.Text = TempoCoupon;
            txtBookID.Enabled = true;
        }
        string DefaultDateReturn, TempoCoupon;
        int Day, Month, Year, Timeout_Day, Timeout_Month, Timeout_Year;
        private void UsrCtrl_QuanLiMuonSach_Load(object sender, EventArgs e)
        {

        }          
     
        public void LoadDataToGrid()
        {            
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = String.Format("select * from SACH, DOCGIA, PHIEUMUON, SACH_PHIEU where DOCGIA.MADOCGIA ='{0}' AND PHIEUMUON.MAPHIEU = SACH_PHIEU.MAPHIEU AND PHIEUMUON.MADOCGIA = DOCGIA.MADOCGIA AND SACH.MASACH = SACH_PHIEU.MASACH AND SACH_PHIEU.NGAYTRA IS NULL", txtReaderID.Text);
            try
            {
                DataTable dt = sqlcnt.GetDataByUsingCmdText(query);
                gridControl1.DataSource = dt;
                int CountRows  = dt.Rows.Count;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnCheckReader_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
            ClearTxtReader();
            btnChoMuon.Enabled = false;
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "select * from DOCGIA, LOAIDOCGIA WHERE DOCGIA.MADOCGIA = '"+txtReaderID.Text+"' and DOCGIA.MALOAIDOCGIA = LOAIDOCGIA.MALOAIDOCGIA";
            //DataTable dt = sqlcnt.GetDataByUsingCmdText(query) ;
            //gridControl1.DataSource = dt;
            SqlDataReader dr = sqlcnt.GetDataReader(query);
            while (dr.Read())
            {
                txtName.Text = Convert.ToString(dr["HOTEN"]);
                txtTypeOfReader.Text = Convert.ToString(dr["TENLOAIDG"]);
                txtSex.Text = Convert.ToString(dr["GIOITINH"]);
                txtBirthday.Text = Convert.ToString(dr["NGAYSINH"]);
                txtAddress.Text = Convert.ToString(dr["DIACHI"]) ;
                //txtTimeout.Text = ;
                CheckReader = true;
            }
            
            if (txtName.Text != "")
            {
                Day = Convert.ToInt16(DateTime.Now.Day.ToString());
                Month = Convert.ToInt16(DateTime.Now.Month.ToString());
                Year = Convert.ToInt16(DateTime.Now.Year.ToString());
                string _query = "select * from THE where THE.MADOCGIA = '"+ txtReaderID.Text +"'" ;
                //SQL_Connection sqlcnt = new SQL_Connection();
                SqlDataReader dr1 = sqlcnt.GetDataReader(_query);
                while (dr1.Read())
                {
                    DefaultDateReturn  = Convert.ToString(dr1["NGAYHETHAN"]);
                    txtTimeout.Text = DefaultDateReturn;
                }
                if (DefaultDateReturn.Substring(1, 1) == "/")
                {
                    Timeout_Month = int.Parse(DefaultDateReturn.Substring(0, 1));
                    if (DefaultDateReturn.Substring(3, 1) == "/")
                    {
                        Timeout_Day = int.Parse(DefaultDateReturn.Substring(2, 1));
                        Timeout_Year = Convert.ToInt16(DefaultDateReturn.Substring(4, 4));
                    }
                    else if (DefaultDateReturn.Substring(4, 1) == "/")
                    {
                        Timeout_Day = int.Parse(DefaultDateReturn.Substring(2, 2));
                        Timeout_Year = Convert.ToInt16(DefaultDateReturn.Substring(5, 4));
                    }
                }
                else
                {
                    Timeout_Month = int.Parse(DefaultDateReturn.Substring(0, 2));
                    if (DefaultDateReturn.Substring(4, 1) == "/")
                    {
                        Timeout_Day = int.Parse(DefaultDateReturn.Substring(3, 1));
                        Timeout_Year = Convert.ToInt16(DefaultDateReturn.Substring(5, 4));
                    }
                    else if (DefaultDateReturn.Substring(5, 1) == "/")
                    {
                        Timeout_Day = int.Parse(DefaultDateReturn.Substring(3, 2));
                        Timeout_Year = Convert.ToInt16(DefaultDateReturn.Substring(6, 4));
                    } 
                }
                if (Year > Timeout_Year)
                {
                    MessageBox.Show("Thẻ đã hết hạn sử dụng","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtBookID.Enabled = false;
                    txtBorrowCouponID.Text = "";
                    btnChoMuon.Enabled = false;
                }
                else if (Year == Timeout_Year)
                {
                    if (Month > Timeout_Month)
                    {
                        MessageBox.Show("Thẻ đã hết hạn sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBookID.Enabled = false;
                        txtBorrowCouponID.Text = "";
                        btnChoMuon.Enabled = false;
                    }
                    else if (Month == Timeout_Month)
                    {
                        if (Day > Timeout_Day)
                        {
                            MessageBox.Show("Thẻ đã hết hạn sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtBookID.Enabled = false;
                            txtBorrowCouponID.Text = "";
                            btnChoMuon.Enabled = false;
                        }
                    }
                    else
                    {
                        Timeout_Month = Timeout_Month + 3;
                        if (Timeout_Day > 30)
                        {
                            Timeout_Month = Timeout_Month + 1;
                            Timeout_Day = Timeout_Day - 30;
                        }
                        if (Timeout_Month > 12 || Timeout_Month + 3 > 12)
                        {
                            Timeout_Month = Timeout_Month - 12;
                            Year += 1;
                        }
                        if (Year > Timeout_Year)
                        {
                            MessageBox.Show("Thẻ sắp hết hạn sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            GetTempoCoupon();
                        }
                        else if (Year == Timeout_Year)
                        {
                            if (Month > Timeout_Month)
                            {
                                MessageBox.Show("Thẻ sắp hết hạn sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                GetTempoCoupon();
                            }
                            else if (Month == Timeout_Month)
                            {
                                if (Day > Timeout_Day)
                                {
                                    MessageBox.Show("Thẻ sắp hết hạn sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    GetTempoCoupon();
                                }
                            }
                        }
                    }
                }
                else
                {
                    GetTempoCoupon();
                }
                btnCheckReader.Enabled = false;
                txtReaderID.Enabled = false;
                btnCheckBook.Enabled = true;
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Mã độc giả vừa nhập không tồn tại. Vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReaderID.Text = "";
                txtBookID.Enabled = true;
                //ClearTxtReader();
                //btnCheckReader.Enabled = true;
                // txtReaderID.Enabled = true;                
                // txtBorrowCouponID.Enabled = true;                
            }
            //DisableTxtReader();
            SQL_Connection.CloseConnection();
        }

        private void btnCheckBook_Click(object sender, EventArgs e)
        {
            ClearTxtBook();            
            btnChoMuon.Enabled = true;
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "select * from SACH,LOAISACH,SANGTAC,TACGIA,NGONNGU,NXB,NHACUNGCAP,VITRI WHERE SACH.MASACH='"+txtBookID.Text+"' AND SACH.MALOAISACH = LOAISACH.MALOAISACH AND SACH.MASACH = SANGTAC.MASACH AND SANGTAC.MATACGIA = TACGIA.MATACGIA AND SACH.MANGONNGU = NGONNGU.MANGONNGU AND SACH.MANXB = NXB.MANXB AND SACH.MANCC = NHACUNGCAP.MANCC AND SACH.MAVITRI = VITRI.MAVITRI";
            SqlDataReader dr = sqlcnt.GetDataReader(query);
            while (dr.Read())
            {
                txtBookName.Text = Convert.ToString(dr["TENSACH"]);
                txtTypeOfBook.Text = Convert.ToString(dr["TENLOAISACH"]);
                txtAuthor.Text = Convert.ToString(dr["HOTEN"]);
                txtLanguage.Text = Convert.ToString(dr["NGONNGU"]);
                txtPublisher.Text = Convert.ToString(dr["TENNXB"]);
                txtYearPublish.Text = Convert.ToString(dr["NAMXUATBAN"]);
                txtRePublish.Text = Convert.ToString(dr["LANXUATBAN"]);
                txtProvider.Text = Convert.ToString(dr["TENNCC"]);
                txtCost.Text = Convert.ToString(dr["GIA"]);
                txtKho.Text = Convert.ToString(dr["KHO"]);
                txtKe.Text = Convert.ToString(dr["KE"]);
                txtNgan.Text = Convert.ToString(dr["NGAN"]);
                CheckBook = true;
            }
            if (txtBookName.Text == "")
            {
                MessageBox.Show("Không tồn tại mã sách trên. Vui lòng nhập chính xác mã sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SQL_Connection.CloseConnection();
                SQL_Connection.OpenConnection();
                bool Book = false;
                string BookID = "";
                SqlDataReader dr1 = sqlcnt.GetDataReaderByUsingSP("CheckForBorrow");
                while (dr1.Read())
                {
                    BookID = Convert.ToString(dr1["MASACH"]);
                    if (txtBookID.Text.Equals(BookID.Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        Book = true;
                    }
                }
                if (Book)
                {
                    MessageBox.Show("Sách này đã cho mượn!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    btnChoMuon.Enabled = false;
                }
            }
            txtBorrowCouponID.Enabled = false;
            //txtBookID.Enabled = false;
            //DisableTxtBook();
            SQL_Connection.CloseConnection();
        }

        private void btnHuyThaoTac_Click(object sender, EventArgs e)
        {
            ClearTxtBook();
            ClearTxtReader();
            txtReaderID.Text = "";
            txtBorrowCouponID.Text = "";
            txtBookID.Text = "";
            txtReaderID.Enabled = true;
            txtBookID.Enabled = false;
            txtBorrowCouponID.Enabled = false;
            btnCheckReader.Enabled = true;
            btnCheckBook.Enabled = false;
            btnChoMuon.Enabled = false;
            DisableTxtBook();
            DisableTxtReader();
            groupBox1.Controls.Clear();
            gridControl1.DataSource = null;
            groupBox1.Controls.Add(gridControl1);
        }
        bool CreateBookCoupon = true;

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (CheckReader && CheckBook)
            {
                DateBorrow = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
                int i = 0;
                SQL_Connection sqlcnt = new SQL_Connection();
                string query = "SELECT *FROM SACH,DOCGIA,PHIEUMUON,SACH_PHIEU WHERE DOCGIA.MADOCGIA='" + txtReaderID.Text + "' AND DOCGIA.MADOCGIA=PHIEUMUON.MADOCGIA AND PHIEUMUON.MAPHIEU=SACH_PHIEU.MAPHIEU AND SACH_PHIEU.MASACH=SACH.MASACH AND SACH_PHIEU.NGAYTRA IS NULL";
                SqlDataReader dr = sqlcnt.GetDataReader(query);
                while (dr.Read())
                {
                    i++;
                }
                CountBorrow = i;
                MaxBorrow();
                if (CountBorrow == _MaxBorrow)
                {
                    MessageBox.Show("Số lượng sách đã mượn của khách hàng đã tối đa. Không thể mượn thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ArrayList Arr = new ArrayList();
                    SQL_Connection _sqlcnt = new SQL_Connection();
                    string _query = "SELECT *FROM DOCGIA,PHIEUMUON WHERE DOCGIA.MADOCGIA='" + txtReaderID.Text + "' AND DOCGIA.MADOCGIA=PHIEUMUON.MADOCGIA";
                    SqlDataReader dr1 = _sqlcnt.GetDataReader(query);
                    while (dr1.Read())
                    {
                        Arr.Add(Convert.ToString(dr1["MAPHIEU"]));
                    }
                    for (int j = 0; j < Arr.Count; j++)
                        if (Convert.ToString(Arr[j]).Trim() == TempoCoupon)
                        {
                            CreateBookCoupon = false;
                        }
                    if (CreateBookCoupon)
                    {
                        GetStaff();
                        BorrowCoupon phieumuon = new BorrowCoupon();
                        phieumuon.SetCouponID(TempoCoupon);
                        phieumuon.SetReaderID(txtReaderID.Text);
                        phieumuon.SetStaffID(Staff);
                        phieumuon.SetBorrowDate(Convert.ToDateTime(DateBorrow));                      
                            if(phieumuon.AddCoupon())
                            MessageBox.Show("Tạo thành công phiếu mượn mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            else
                            MessageBox.Show("Không tạo được phiếu mượn.", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);                        
                    }
                    int _Day= Convert.ToInt16(DateTime.Now.Day.ToString());
                    int _Month = Convert.ToInt16(DateTime.Now.Month.ToString());
                    int _Year = Convert.ToInt16(DateTime.Now.Year.ToString());
                    if (_Month + 3 > 12)
                    {
                        _Month = _Month + 3 - 12;
                        _Year += 1;
                    }
                    else _Month += 3;
                    Deadline = Convert.ToString(_Month) + "/" + Convert.ToString(_Day) + "/" + Convert.ToString(_Year);
                    BookCoupon phieusach = new BookCoupon();
                    phieusach.SetCouponID(TempoCoupon);
                    phieusach.SetBookID(txtBookID.Text);
                    phieusach.SetDeadline(Convert.ToDateTime(Deadline));                    
                    
                        if (phieusach.AddCoupon())
                        {
                            CountBorrow++;
                            LoadDataToGrid();
                            MessageBox.Show("Tạo thành công phiếu sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        MessageBox.Show("Không tạo được phiếu sách", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);                    
                }
            }
            else
                MessageBox.Show("Phải kiểm tra thông tin trước khi cho mượn", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            btnChoMuon.Enabled = false;   
        }

        private void bandedGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        } 
                     
    }
}
