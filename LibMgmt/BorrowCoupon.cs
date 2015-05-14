using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMgmt
{
    class BorrowCoupon
    {
        string CouponID, ReaderID, StaffID;
        DateTime BorrowDate;
        public BorrowCoupon() { }
        public BorrowCoupon(string couponid, string readerid, string staffid, DateTime borrowdate)
        {
            this.CouponID = couponid;
            this.ReaderID = readerid;
            this.StaffID = staffid;
            this.BorrowDate = borrowdate;
        }
        #region Các phương thức set
        public void SetCouponID(string couponid)
        {
            this.CouponID = couponid;
        }
        public void SetReaderID(string readerid)
        {
            this.ReaderID = readerid;
        }
        public void SetStaffID(string staffid)
        {
            this.StaffID = staffid;
        }
        public void SetBorrowDate(DateTime borrowdate)
        {
            this.BorrowDate = borrowdate;
        }
        #endregion
        #region Các phương thức get
        public string GetCouponID()
        {
            return CouponID;
        }
        public string GetReaderID()
        {
            return ReaderID;
        }
        public string GetStaffID()
        {
            return StaffID;
        }
        public DateTime GetBorrowDate()
        {
            return BorrowDate;
        }
        #endregion
        public bool AddCoupon()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "insert into PHIEUMUON values('"+ CouponID +"','"+ ReaderID + "','" +StaffID+"','"+ BorrowDate +"')";
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
            string query = "delete from PHIEUMUON where MAPHIEU = '" + CouponID +"'";
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
            string query = "update  PHIEUMUON set MADOCGIA = '"+ ReaderID+ "', MANHANVIEN ='"+ StaffID +"', NGAYMUON = '"+ BorrowDate + "' where MAPHIEU = '" + CouponID + "'";
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
    }
}
