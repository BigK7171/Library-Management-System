using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMgmt
{
    class BookCoupon
    {
        string CouponID, BookID;
        DateTime Deadline, ReturnDate;
        int OutDate, Fine;
        bool IsLost;
        public BookCoupon() { }
        public BookCoupon(string couponid, string bookid, DateTime deadline, DateTime returndate, int outdate, int fine, bool lost)
        {
            this.CouponID = couponid;
            this.BookID = bookid;
            this.Deadline = deadline;
            this.ReturnDate = returndate;
            this.OutDate = outdate;
            this.Fine = fine;
            this.IsLost = lost;
        }
        #region Các phương thức set
        public void SetCouponID(string couponid)
        {
            this.CouponID = couponid;
        }
        public void SetBookID(string bookid)
        {
            this.BookID = bookid;
        }
        public void SetDeadline(DateTime deadline)
        {
            this.Deadline = deadline;
        }
        public void SetReturnDate(DateTime returndate)
        {
            this.ReturnDate = returndate;
        }
        public void SetOutDate(int outdate)
        {
            this.OutDate = outdate;
        }
        public void SetFine(int fine)
        {
            this.Fine = fine;
        }
        public void SetIsLost(bool lost)
        {
            this.IsLost = lost;
        }
        #endregion
        #region Các phương thức get
        public string GetCouponID()
        {
            return CouponID;
        }
        public string GetBookID()
        {
            return BookID;
        }
        public DateTime GetDeadline()
        {
            return Deadline;
        }
        public DateTime GetReturnDate()
        {
            return ReturnDate;
        }
        public int GetOutdate()
        {
            return OutDate;
        }
        public int GetFine()
        {
            return Fine;
        }
        public bool GetLost()
        {
            return IsLost;
        }
        #endregion
        #region Các thao tác
        public bool AddCoupon()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "insert into SACH_PHIEU values('"+CouponID+"','"+BookID+"','"+Deadline+"',NULL,NULL,NULL,NULL)";
            if (sqlcnt.ExecuteQuery(query) == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else
            {
                SQL_Connection.CloseConnection();
                return false;
            }
        }
        public bool UpdateCoupon()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "update SACH_PHIEU set NGAYTRA = '"+ReturnDate+"', SONGAYQUAHAN = '"+OutDate+"', MATSACH = '"+ IsLost+"', TIENPHAT = '"+Fine+"' where MAPHIEU = '"+CouponID+"' and MASACH ='"+BookID+"'";
            if (sqlcnt.ExecuteQuery(query) == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else
            {
                SQL_Connection.CloseConnection();
                return false;
            }
        }
        public bool Renew()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "update SACH_PHIEU set NGAYHETHANTRA = '" + Deadline + "' where MAPHIEU = '" + CouponID + "' and MASACH ='" + BookID + "'";
            if (sqlcnt.ExecuteQuery(query) == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else
            {
                SQL_Connection.CloseConnection();
                return false;
            }
        }
        public bool DelCoupon()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "delete from SACH_PHIEU where MAPHIEU = '"+CouponID+"'" ;
            if (sqlcnt.ExecuteQuery(query) == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else
            {
                SQL_Connection.CloseConnection();
                return false;
            }
        }
        #endregion
    }
}
