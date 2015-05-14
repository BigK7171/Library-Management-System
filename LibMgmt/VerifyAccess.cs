using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LibMgmt
{
    public class VerifyAccess
    {
        string UserName = "", Passwd = "", Permission = "", StaffID = "", FullName = "", Address = "", NumberPhone = "";
        public VerifyAccess() { }
        public VerifyAccess(string username, string passwd, string permission, string staffid, string fullname, string address, string numberphone)
        {
            this.UserName = username;
            this.Passwd = passwd;
            this.Permission = permission;
            this.StaffID = staffid;
            this.FullName = fullname;
            this.Address = address;
            this.NumberPhone = numberphone;
        }
        #region Các phương thức set
        public void SetUserName(string username)
        {
            this.UserName = username;
        }
        public void SetPasswd(string passwd)
        {
            this.Passwd = passwd;
        }
        public void SetPermission(string permission)
        {
            this.Permission = permission;
        }
        public void SetStaffID(string staffID)
        {
            this.StaffID = staffID; 
        }
        public void SetFullName(string fullname)
        {
            this.FullName = fullname; 
        }
        public void SetAddress(string address)
        {
            this.Address = address;
        }
        public void SetNumberPhone(string numberphone)
        {
            this.NumberPhone = numberphone;
        }
        #endregion
        #region Các phương thức get
        public string GetUserName()
        {
            return UserName;
        }
        public string GetPasswd()
        {
            return Passwd;
        }
        public string GetPermission()
        {
            return Permission;
        }
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
        public string GetNumberPhone()
        {
            return NumberPhone;
        }
        #endregion
        public void SelectStaff(string username, string passwd)
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            SqlDataReader data;
            string cmdText = "select MATKHAU,QUYENHAN,MANHANVIEN,DIACHI,SODIENTHOAI,HOTEN from nhanvien where nhanvien.TENDANGNHAP='" + username + "' and nhanvien.MATKHAU='" + passwd + "'";
            data = sqlcnt.GetDataReader(cmdText);
            while(data.Read())
            {
                this.Passwd = Convert.ToString(data["MATKHAU"]);
                Permission = Convert.ToString(data["quyenhan"]);
                StaffID = Convert.ToString(data["MANHANVIEN"]);
                FullName = Convert.ToString(data["HOTEN"]);
                NumberPhone = Convert.ToString(data["SODIENTHOAI"]);
                this.UserName = username;
                Address = Convert.ToString(data["DIACHI"]);
            }
        }
        public void DelStaff()
        {
            Passwd = Permission = StaffID = FullName = Address = "";
        }
    }
}
