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
    public partial class UsrCtrl_ReturnBook : UserControl
    {
        public UsrCtrl_ReturnBook()
        {
            InitializeComponent();
            btnCheckReader.Enabled = true;
            btnCheckBook.Enabled = false;
            btnRenew.Enabled = false;
            btnReturn.Enabled = false;
            txtBookID.Enabled = false;
            txtReaderID.Enabled = true;
            txtReaderName.Enabled = false;
            txtCountBook.Enabled = false;
            txtCountOutDate.Enabled = false;
            txtPunish.Enabled = false;
        }

        private void UsrCtrl_ReturnBook_Load(object sender, EventArgs e)
        {
            //btnCancel_Click(sender,e);
        }

        private void ClearText()
        {
            txtReaderID.Text = "";
            txtReaderName.Text = "";
            txtBookID.Text = "";
            txtCountBook.Text = "";
            txtCountOutDate.Text = "";
            txtPunish.Text = "";
            checkIsLost.Checked = false;
        }
        private void EnableText()
        {
            txtReaderID.Enabled = true;
            txtReaderName.Enabled = true;
            txtBookID.Enabled = true;
            txtCountBook.Enabled = true;
            txtCountOutDate.Enabled = true;
            txtPunish.Enabled = true;
            checkIsLost.Checked = false;             
        }
        private void DisableText()
        {
            txtReaderID.Enabled = false;
            txtReaderName.Enabled = false;
            txtBookID.Enabled = false;
            txtCountBook.Enabled = false;
            txtCountOutDate.Enabled = false;
            txtPunish.Enabled = false;           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
            btnCheckReader.Enabled = true;
            btnCheckBook.Enabled = false;
            btnRenew.Enabled = false;
            btnReturn.Enabled = false;
            txtBookID.Enabled = false;
            txtReaderID.Enabled = true;
            txtReaderName.Enabled = false;
            txtCountBook.Enabled = false;
            txtCountOutDate.Enabled = false;
            txtPunish.Enabled = false;          
            groupBox3.Controls.Clear();
            gridControl1.DataSource = null;
            groupBox3.Controls.Add(gridControl1);
        }
        public void LoadDataToGrid()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "select SACH.MASACH, SACH.TENSACH, PHIEUMUON.NGAYMUON from SACH,PHIEUMUON,SACH_PHIEU,DOCGIA where DOCGIA.MADOCGIA = '" + txtReaderID.Text +"' AND SACH.MASACH = SACH_PHIEU.MASACH AND SACH_PHIEU.MAPHIEU = PHIEUMUON.MAPHIEU AND PHIEUMUON.MADOCGIA = DOCGIA.MADOCGIA and SACH_PHIEU.NGAYTRA IS NULL";
            try
            {
                DataTable dt = sqlcnt.GetDataByUsingCmdText(query);
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }            
        }
        int CountBorrowBook;

        private void btnCheckReader_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                SQL_Connection sqlcnt = new SQL_Connection();
                string query = "select * from SACH,PHIEUMUON,SACH_PHIEU,DOCGIA where DOCGIA.MADOCGIA = '" + txtReaderID.Text + "' AND SACH.MASACH = SACH_PHIEU.MASACH AND SACH_PHIEU.MAPHIEU = PHIEUMUON.MAPHIEU AND PHIEUMUON.MADOCGIA = DOCGIA.MADOCGIA and SACH_PHIEU.NGAYTRA IS NULL";
                SqlDataReader dr = sqlcnt.GetDataReader(query);
                while (dr.Read())
                {
                    txtReaderName.Text = Convert.ToString(dr["HOTEN"]);
                    i++;
                }
                if (txtReaderName.Text == "")
                {
                    MessageBox.Show("Không tồn tại mã độc giả trên hoặc độc giả không mượn sách nào","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    btnCancel_Click(sender,e);
                }
                else
                {
                    txtCountBook.Text = Convert.ToString(i);
                    CountBorrowBook = i;
                    LoadDataToGrid();
                    txtBookID.Enabled = true;
                    txtReaderID.Enabled = false;
                    btnCheckReader.Enabled = false;
                    btnCheckBook.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        string ReturnDate;
        int Borrow_Month, Borrow_Day, Borrow_Year;
        int CountOutDate;

        private void btnCheckBook_Click(object sender, EventArgs e)
        {
           
            int Month = Convert.ToInt16(DateTime.Now.Month);
            int Day = Convert.ToInt16(DateTime.Now.Day);
            int Year = Convert.ToInt16(DateTime.Now.Year);
            string query = "select * from SACH_PHIEU,SACH where SACH.MASACH = '"+ txtBookID.Text +"' AND SACH_PHIEU.MASACH = SACH.MASACH";
            SQL_Connection sqlcnt = new SQL_Connection();
            int i = 0;
            string _query = "select * from SACH,PHIEUMUON,SACH_PHIEU,DOCGIA where DOCGIA.MADOCGIA = '" + txtReaderID.Text + "' AND SACH.MASACH = SACH_PHIEU.MASACH AND SACH_PHIEU.MAPHIEU = PHIEUMUON.MAPHIEU AND PHIEUMUON.MADOCGIA = DOCGIA.MADOCGIA and SACH_PHIEU.NGAYTRA IS NULL";
            SqlDataReader dr1 = sqlcnt.GetDataReader(_query);
            while (dr1.Read())
            {
                i++;
            }
            txtCountBook.Text = Convert.ToString(i);
            SqlDataReader dr = sqlcnt.GetDataReader(query);
            while (dr.Read())
            {
                ReturnDate = Convert.ToString(dr["NGAYHETHANTRA"]);
            }
            if(ReturnDate.Substring(1,1)=="/")
            {
                Borrow_Month = int.Parse(ReturnDate.Substring(0,1));
                if (ReturnDate.Substring(3, 1) == "/")
                {
                    Borrow_Day = int.Parse(ReturnDate.Substring(2,1));
                    Borrow_Year = Convert.ToInt16(ReturnDate.Substring(4,4));
                }
                else if (ReturnDate.Substring(4, 1) == "/")
                {
                    Borrow_Day = int.Parse(ReturnDate.Substring(2, 2));
                    Borrow_Year = Convert.ToInt16(ReturnDate.Substring(5,4));
                }

            }
            else if (ReturnDate.Substring(2, 1) == "/")
            {
                Borrow_Month = int.Parse(ReturnDate.Substring(0, 2));
                if (ReturnDate.Substring(4, 1) == "/")
                {
                    Borrow_Day = int.Parse(ReturnDate.Substring(3, 1));
                    Borrow_Year = Convert.ToInt16(ReturnDate.Substring(5, 4));
                }
                else if (ReturnDate.Substring(5, 1) == "/")
                {
                    Borrow_Day = int.Parse(ReturnDate.Substring(3, 2));
                    Borrow_Year = Convert.ToInt16(ReturnDate.Substring(6, 4));
                } 
            }
            CountOutDate = (Year - Borrow_Year) * 365 + (Month - Borrow_Month) * 30 + (Day - Borrow_Day);
            if (CountOutDate < 0) CountOutDate = 0;
            txtCountOutDate.Text = Convert.ToString(CountOutDate);
            txtPunish.Text = "";
            btnReturn.Enabled = true;
            btnRenew.Enabled = true;            
        }
        string CouponID = "";
        int Fine, Cost;
        bool IsLost = false;

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string Punish;
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "SELECT *FROM SACH,DOCGIA,PHIEUMUON,SACH_PHIEU WHERE DOCGIA.MADOCGIA='" + txtReaderID.Text + "' AND SACH.MASACH='" + txtBookID.Text + "' AND DOCGIA.MADOCGIA=PHIEUMUON.MADOCGIA AND PHIEUMUON.MAPHIEU=SACH_PHIEU.MAPHIEU AND SACH_PHIEU.MASACH=SACH.MASACH AND SACH_PHIEU.NGAYTRA IS NULL";
            SqlDataReader dr = sqlcnt.GetDataReader(query);
            while (dr.Read())
            {
                CouponID = Convert.ToString(dr["MAPHIEU"]);
                Cost = Convert.ToInt16(dr["GIA"]);
            }
            if (checkIsLost.Checked)
            {
                Punish = "MATSACH";
                IsLost = true;
            }
            else if (CountOutDate > 0)
            {
                Punish = "TREHAN";
            }
            else Punish = "";           
            string query1 = "SELECT THAMSOXUPHAT.MUCPHAT FROM THAMSOXUPHAT WHERE THAMSOXUPHAT.TENXUPHAT='" + Punish + "'";
            SqlDataReader dr1 = sqlcnt.GetDataReader(query1);
            while (dr1.Read())
            {
                Fine = Convert.ToInt16(dr1["MUCPHAT"]);
            }
            int Mucphat = Fine;
            if (Punish == "MATSACH")
            {
                Fine = Fine * Cost;
            }
            else Fine = Fine * CountOutDate;
            string Today = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
           BookCoupon Phieusach = new BookCoupon();
           Phieusach.SetCouponID(CouponID);
           Phieusach.SetIsLost(IsLost);
           Phieusach.SetReturnDate(Convert.ToDateTime(Today));
           Phieusach.SetOutDate(CountOutDate);
           Phieusach.SetFine(Fine);
           Phieusach.SetBookID(txtBookID.Text);           
            if (Phieusach.UpdateCoupon())
            {
                if (IsLost == true)
                {
                    MessageBox.Show("Độc giả phải đền gấp " + Mucphat + " lần giá trị quyển sách", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    CountBorrowBook--;
                    txtPunish.Text = Convert.ToString(Phieusach.GetFine());                   
                }
                else if (CountOutDate > 0)
                {
                    MessageBox.Show("Độc giả đã trả sách trễ hạn " + CountOutDate + " ngày", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    CountBorrowBook--;
                    txtPunish.Text = Convert.ToString(Phieusach.GetFine());
                }
                else
                {
                    MessageBox.Show("Đã trả sách thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    CountBorrowBook--;
                    txtCountBook.Text = Convert.ToString(CountBorrowBook);
                }
            }
            else
                MessageBox.Show("Không cập nhật được phiếu mượn", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            int i = 0;
            string _query = "select * from SACH,PHIEUMUON,SACH_PHIEU,DOCGIA where DOCGIA.MADOCGIA = '" + txtReaderID.Text + "' AND SACH.MASACH = SACH_PHIEU.MASACH AND SACH_PHIEU.MAPHIEU = PHIEUMUON.MAPHIEU AND PHIEUMUON.MADOCGIA = DOCGIA.MADOCGIA and SACH_PHIEU.NGAYTRA IS NULL";
            SqlDataReader dr2 = sqlcnt.GetDataReader(_query);
            while (dr2.Read())
            {
                i++;
            }
            txtCountBook.Text = Convert.ToString(i);

            LoadDataToGrid();
        }
        string RenewCouponID = "";
        string NewDeadline = "";

        private void btnRenew_Click(object sender, EventArgs e)
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "SELECT PHIEUMUON.MAPHIEU FROM PHIEUMUON,SACH_PHIEU,DOCGIA,SACH WHERE DOCGIA.MADOCGIA='" + txtReaderID.Text + "' AND DOCGIA.MADOCGIA=PHIEUMUON.MADOCGIA AND PHIEUMUON.MAPHIEU=SACH_PHIEU.MAPHIEU AND SACH_PHIEU.MASACH = SACH.MASACH";
            SqlDataReader dr = sqlcnt.GetDataReader(query);
            while (dr.Read())
            {
                RenewCouponID = Convert.ToString(dr["MAPHIEU"]);
            }
            string Today = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            int Day = Convert.ToInt16(DateTime.Now.Day.ToString());
            int Month = Convert.ToInt16(DateTime.Now.Month.ToString());
            int Year = Convert.ToInt16(DateTime.Now.Year.ToString());
            if (Month + 3 > 12)
            {
                Month = Month + 3 - 12;
                Year += 1;
            }
            else Month += 3;
            NewDeadline = Convert.ToString(Month) + "/" + Convert.ToString(Day) + "/" + Convert.ToString(Year);
            BookCoupon Phieusach = new BookCoupon();
            Phieusach.SetCouponID(RenewCouponID);
            Phieusach.SetBookID(txtBookID.Text);
            Phieusach.SetDeadline(Convert.ToDateTime(NewDeadline));            
            if (Phieusach.Renew())
            {
                MessageBox.Show("Gia hạn thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                LoadDataToGrid();
            }
            else MessageBox.Show("Gia hạn thất bại", "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

    }
}
