using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMgmt
{
    public class Staff
    {
        string StaffID, FullName, Address, Permission, UserName, Passwd, NumberPhone;
        public Staff()
        { }
        public Staff(string MaNV, string HotenNV, string DiaChi, string QuyenHan, string TenDN, string MatKhau, string Sodienthoai)
        {
            this.StaffID = MaNV;
            this.FullName = HotenNV;
            this.Address = DiaChi;
            this.Permission = QuyenHan;
            this.UserName = TenDN;
            this.Passwd = MatKhau;
            this.NumberPhone = Sodienthoai;
        }
        #region Các phương thức Set

        public void SetStaffID(string MaNV)
        {
            this.StaffID=MaNV;
        }
        public void SetFullName(string hotenNV)
        {
            this.FullName = hotenNV;
        }
        public void SetAddress(string diachi)
        {
            this.Address = diachi;
        }
        public void SetPermission(string quyenhan)
        {
            this.Permission = quyenhan;
        }
        public void SetUserName(string tendangnhap)
        {
            this.UserName = tendangnhap;
        }
        public void SetPasswd(string matkhau)
        {
            this.Passwd = matkhau;
        }
        public void SetNumberPhone(string sodienthoai)
        {
            this.NumberPhone = sodienthoai;
        }
        #endregion
        #region Các phương thức Get

        public string GetStaffID()
        {
            return StaffID;
        }
        public string GetFullName()
        {
            return FullName;
        }
        public string GetAddress()
        {
            return Address;
        }
        public string GetPermission()
        {
            return Permission;
        }
        public string GetUserName()
        {
            return UserName;
        }
        public string GetPasswd()
        {
            return Passwd;
        }
        public string GetNumberPhone()
        {
            return NumberPhone;
        }
        #endregion
        #region Các phương thức hoạt động

        public bool AddStaff()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            if (sqlcnt.ExecuteQuery(" insert into Nhanvien values ('" + StaffID + "',N'" + FullName + "',N'" + Address + "','"+ NumberPhone + "',N'" + UserName + "','" + Passwd + "','" + Permission + "')") == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else return false;
        }
        public bool UpdatePermission(string NewPermission)
        {
            this.Permission = NewPermission;
            SQL_Connection _sqlcnt = new SQL_Connection();
            if (_sqlcnt.ExecuteQuery(" update Nhanvien set quyenhan ='" + NewPermission + "' where manhanvien = '" + StaffID + "'") == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else return false;
        }
        public bool Update()
        {
            SQL_Connection _sqlcnt = new SQL_Connection();
            if (_sqlcnt.ExecuteQuery(" update Nhanvien set hoten=N'" + FullName + "',diachi=N'" + Address + "',sodienthoai='"+ NumberPhone +"',tendangnhap=N'" + UserName + "',matkhau=N'" + Passwd + "' where manhanvien='" + StaffID + "'") == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else return false;
        }
        public bool ChangePasswd(string NewPasswd)
        {
            SQL_Connection _sqlcnt = new SQL_Connection();
            Passwd = NewPasswd;
            if (_sqlcnt.ExecuteQuery(" update Nhanvien set matkhau=N'" + NewPasswd + "' where manhanvien='" + StaffID + "'") == 1)
            {
                 SQL_Connection.CloseConnection();
                return true;
            }
            else return false;
        }
        public bool DelStaff()
        {
            SQL_Connection _sqlcnt = new SQL_Connection();
            if (_sqlcnt.ExecuteQuery(" delete from Nhanvien where manhanvien= '"+ StaffID +"'") == 1)
            {
                SQL_Connection.CloseConnection();
                return true;
            }
            else return false;
        }
        #endregion    
    }
}
