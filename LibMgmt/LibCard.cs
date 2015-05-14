using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibMgmt
{
    class LibCard
    {
        string CardID, ReaderID;
        DateTime CreateTime, ExpireTime;
        public LibCard() { }
        public LibCard(string cardID, string readerID, DateTime createTime, DateTime expireTime)
        {
            this.CardID = cardID;
            this.ReaderID = readerID;
            this.CreateTime = createTime;
            this.ExpireTime = expireTime;
        }
        #region Các phương thức set
        public void SetCardID(string str)
        {
            this.CardID = str;
        }
        public void SetReaderID(string str)
        {
            this.ReaderID = str;
        }
        public string GetReaderID()
        {
            return ReaderID;
        }
        #endregion
        #region Thao tác với cơ sở dữ liệu
        public bool AddCard()
        {
            SQL_Connection sqlcnt = new SQL_Connection();            
            string query = "insert into THE values('"+CardID+"','"+ReaderID+"','"+CreateTime+"','"+ExpireTime+"')";
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
        public bool DelCard()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            string query = "delete from THE where MADOCGIA = '"+ ReaderID +"'";
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
