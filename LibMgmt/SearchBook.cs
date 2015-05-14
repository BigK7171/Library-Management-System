using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LibMgmt
{
    class SearchBook
    {
        public SearchBook() { }
        public DataTable Search(string StrBook, string Author, string TypeOfBook, string Publisher, string Language, string Provider)
        {
            string StrSearh = "select SACH.MASACH, SACH.TENSACH, TACGIA.HOTEN, NGONNGU.NGONNGU, NXB.TENNXB, NHACUNGCAP.TENNCC  from SACH,TACGIA,NGONNGU,NXB,NHACUNGCAP,LOAISACH,SANGTAC where SACH.MANGONNGU = NGONNGU.MANGONNGU and SACH.MANXB = NXB.MANXB and SACH.MANCC = NHACUNGCAP.MANCC and SACH.MALOAISACH = LOAISACH.MALOAISACH and SACH.MASACH = SANGTAC.MASACH and TACGIA.MATACGIA = SANGTAC.MATACGIA and SACH.TENSACH like N'%"+StrBook+"%'";
            if(Author != "") { StrSearh += "and TACGIA.HOTEN = N'" +Author+"'";}
            if (TypeOfBook != "") { StrSearh += "and LOAISACH.TENLOAISACH = N'" + TypeOfBook + "'"; }
            if (Publisher != "") { StrSearh += "and NXB.TENNXB = N'" + Publisher + "'"; }
            if (Language != "") { StrSearh += "and NGONNGU.NGONNGU = N'" + Language + "'"; }
            if (Provider != "") { StrSearh += "and NHACUNGCAP.TENNCC = N'" + Provider + "'"; }
            SQL_Connection sqlcnt = new SQL_Connection();
            DataTable data = sqlcnt.GetDataByUsingCmdText(StrSearh);
            return data;
        }
    }
}
