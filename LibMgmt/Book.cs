using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMgmt
{
    class Book
    {
        string BookID, BookName, TypeID, ProviderID, LanguageID, PublisherID, LocationID, AuthorID;
        int YearPublish, RePublish, Cost;
        #region Các phương thức set
        public Book() { }
        public void SetBookID(string bookid)
        {
            this.BookID = bookid;
        }
        public void SetBookName(string bookname)
        {
            this.BookName = bookname;
        }
        public void SetTypeID(string typeid)
        {
            this.TypeID = typeid;
        }
        public void SetProviderID(string providerid)
        {
            this.ProviderID = providerid;
        }
        public void SetLanguageID(string languageid)
        {
            this.LanguageID = languageid;
        }
        public void SetPublisherID(string publisherid)
        {
            this.PublisherID = publisherid;
        }
        public void SetLocationID(string locationid)
        {
            this.LocationID = locationid;
        }
        public void SetAuthorID(string authorid)
        {
            this.AuthorID = authorid;
        }
        public void SetYearPublish(int yearpublish)
        {
            this.YearPublish = yearpublish;
        }
        public void SetRePublish(int republish)
        {
            this.RePublish = republish;
        }
        public void SetCost(int cost)
        {
            this.Cost = cost; 
        }
        #endregion
        #region Các phương thức get
        public string GetBookID()
        {
            return BookID;
        }
        public string GetBookName()
        {
            return BookName;
        }
        public string GetTypeID()
        {
            return TypeID;
        }
        public string GetProviderID()
        {
            return ProviderID;
        }
        public string GetLanguageID()
        {
            return LanguageID;
        }
        public string GetPublisherID()
        {
            return PublisherID;
        }
        public string GetLocationID()
        {
            return LocationID;
        }
        public string GetAuthorID()
        {
            return AuthorID;
        }
        public int GetYearPublish()
        {
            return YearPublish;
        }
        public int GetRePublish()
        {
            return RePublish;
        }
        public int GetCost()
        {
            return Cost;
        }
        #endregion
        #region Thao tác với bảng SACH
        public bool AddBook()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "insert into SACH values('" + BookID + "',N'" + BookName + "','" + LocationID + "','" + TypeID + "','" + LanguageID + "','" + PublisherID + "','" + ProviderID + "','" + YearPublish + "','" + RePublish + "','" + Cost + "')";
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
        public bool UpdateBook()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "update SACH set TENSACH = N'" + BookName + "', MAVITRI = '" + LocationID + "', MALOAISACH = '" + TypeID + "', MANGONNGU = '" + LanguageID + "', MANXB = '" + PublisherID + "', MANCC = '" + ProviderID + "', NAMXUATBAN = '" + YearPublish + "', LANXUATBAN = '" + RePublish + "', GIA = '" + Cost + "' where MASACH = '"+ BookID +"'";
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
        public bool DelBook()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "delete from SACH where MASACH = '"+ BookID +"'";
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
        #region Thao tác với bảng SANGTAC
        public bool Add_St()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "insert into SANGTAC values('"+ BookID +"','"+ AuthorID +"')";
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
        public bool Update_St()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "update SANGTAC set MATACGIA = '" + AuthorID + "' where MASACH = '" + BookID + "'";
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
        public bool Del_St()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "delete from SANGTAC where MASACH = '" + BookID + "'";
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
