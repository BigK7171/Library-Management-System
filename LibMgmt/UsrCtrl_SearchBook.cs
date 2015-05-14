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
    public partial class UsrCtrl_SearchBook : UserControl
    {
        public UsrCtrl_SearchBook()
        {
            InitializeComponent();
        }
        //CurrencyManager CM;
        private void Load_FilterInfo()
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            SqlDataReader dr = sqlcnt.GetDataReader("select HOTEN from TACGIA");
            while (dr.Read())
            {
                txtAuthor.Properties.Items.AddRange(new object[]{dr[0].ToString()});
            }
            SQL_Connection.CloseConnection();
            SqlDataReader dr1 = sqlcnt.GetDataReader("select TENLOAISACH from LOAISACH");
            while (dr1.Read())
            {
                txtType.Properties.Items.AddRange(new object[] { dr1[0].ToString() });
            }
            SQL_Connection.CloseConnection();
            SqlDataReader dr2 = sqlcnt.GetDataReader("select TENNXB from NXB");
            while (dr2.Read())
            {
                txtPublisher.Properties.Items.AddRange(new object[] { dr2[0].ToString() });
            }
            SQL_Connection.CloseConnection();
            SqlDataReader dr3 = sqlcnt.GetDataReader("select NGONNGU from NGONNGU");
            while (dr3.Read())
            {
                txtLanguage.Properties.Items.AddRange(new object[] { dr3[0].ToString() });
            }
            SQL_Connection.CloseConnection();
            SqlDataReader dr4 = sqlcnt.GetDataReader("select TENNCC from NHACUNGCAP");
            while (dr4.Read())
            {
                txtProvider.Properties.Items.AddRange(new object[] { dr4[0].ToString() });
            }
            SQL_Connection.CloseConnection();
        }
        private void UsrCtrl_SearchBook_Load(object sender, EventArgs e)
        {
            Load_FilterInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox4.Controls.Clear();
                SearchBook TimKiem = new SearchBook();
                DataTable data = TimKiem.Search(txtNhap.Text, txtAuthor.Text, txtType.Text, txtPublisher.Text, txtLanguage.Text, txtProvider.Text);
                gridControl1.DataSource = data;
                groupBox4.Controls.Add(gridControl1);
               // CM = BindingContext[data] as CurrencyManager;
                //lblCount.Text = CM.Count.ToString();
                lblCount.Text = gridView1.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                UsrCtrl_SearchBook_Load(sender, e);
            }
        }

        private void txtNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnSearch_Click(sender,e);
        }

       
    }
}
