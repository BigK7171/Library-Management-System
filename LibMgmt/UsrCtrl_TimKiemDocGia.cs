using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibMgmt
{
    public partial class UsrCtrl_TimKiemDocGia : UserControl
    {
        public UsrCtrl_TimKiemDocGia()
        {
            InitializeComponent();
        }

        private void UsrCtrl_TimKiemDocGia_Load(object sender, EventArgs e)
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            DataTable dt = sqlcnt.GetDataByUsingSP("SearchReader");
            gridControl1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SQL_Connection sqlcnt = new SQL_Connection();            
            try
            {
                DataTable dt;
                string SearchString="";
                if (txtName.Text!="")
                {
                    SearchString = "SELECT DOCGIA.MADOCGIA,DOCGIA.HOTEN,DOCGIA.GIOITINH,DOCGIA.NGAYSINH,DOCGIA.DIACHI,DOCGIA.SODIENTHOAI,LOAIDOCGIA.TENLOAIDG FROM DOCGIA,LOAIDOCGIA WHERE DOCGIA.HOTEN LIKE N'%" + txtName.Text.Trim() + "%' AND DOCGIA.MALOAIDOCGIA = LOAIDOCGIA.MALOAIDOCGIA";
                    dt = sqlcnt.GetDataByUsingCmdText(SearchString);
                    gridControl1.DataSource = dt;
                }
                else if (txtID.Text !="")
                {
                    SearchString = "SELECT DOCGIA.MADOCGIA,DOCGIA.HOTEN,DOCGIA.GIOITINH,DOCGIA.NGAYSINH,DOCGIA.DIACHI,DOCGIA.SODIENTHOAI,LOAIDOCGIA.TENLOAIDG FROM DOCGIA,LOAIDOCGIA WHERE DOCGIA.MADOCGIA = '" + txtID.Text.Trim() + "'AND DOCGIA.MALOAIDOCGIA = LOAIDOCGIA.MALOAIDOCGIA";
                    dt = sqlcnt.GetDataByUsingCmdText(SearchString);
                    gridControl1.DataSource = dt;
                }               
            }
            catch
            {
                MessageBox.Show("Không có kết quả nào phù hợp với tìm kiếm. Vui lòng thử lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                SQL_Connection.CloseConnection();
            }
        }
    }
}
