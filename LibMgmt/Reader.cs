using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMgmt
{
    class Reader
    {
        string ReaderID, ReaderName, ReaderTypeID, Sex, Address, NumberPhone;
        DateTime BirthDay;
        public Reader() { }
        public Reader(string ID, string Name, string TypeID, string Sex, DateTime birthday, string address,string numberphone)
        {
            this.ReaderID = ID;
            this.ReaderName = Name;
            this.ReaderTypeID = TypeID;
            this.Sex = Sex;
            this.BirthDay = birthday;
            this.Address = address;
            this.NumberPhone = numberphone;
        }

        #region Khởi tạo giá trị cho các thuộc tính
        public void SetReaderID(string ID)
        { 
            this.ReaderID = ID;
        }
        public void SetReaderName(string Name)
        {
            this.ReaderName = Name;
        }
        public void SetTypeID(string TypeID)
        {
            this.ReaderTypeID = TypeID;
        }
        public void SetSex(string sex)
        {
            this.Sex = sex;
        }
        public void SetAddress(string address)
        {
            this.Address = address;
        }
        public void SetBirthDay(DateTime birthday)
        {
            this.BirthDay = birthday;
        }
        public void SetNumberPhone(string numberphone)
        {
            this.NumberPhone = numberphone;
        }
        #endregion

        #region Các phương thức get
        public bool AddReader()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string command = "insert into DOCGIA(MADOCGIA,MALOAIDOCGIA,HOTEN,GIOITINH,NGAYSINH,DIACHI,SODIENTHOAI) values('" + ReaderID + "','" + ReaderTypeID + "',N'" + ReaderName + "',N'" + Sex + "','" + BirthDay + "',N'" + Address + "','"+NumberPhone+"')";
            if (sqlcnt.ExecuteQuery(command)==1)
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
        public bool UpdateReader()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string command = "update  DOCGIA set MALOAIDOCGIA='"+ReaderTypeID+"', HOTEN = N'"+ReaderName+"', GIOITINH =N'"+Sex+"',NGAYSINH = '"+BirthDay+"',DIACHI = N'"+Address+"',SODIENTHOAI = '" + NumberPhone + "' where MADOCGIA = '"+ReaderID+"'";
            if (sqlcnt.ExecuteQuery(command) == 1)
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
        public bool DelReader()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string command = "delete from DOCGIA where MADOCGIA = '"+ ReaderID+"'";
            if (sqlcnt.ExecuteQuery(command) == 1)
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
