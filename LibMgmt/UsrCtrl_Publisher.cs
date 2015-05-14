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
    public partial class UsrCtrl_Publisher : UserControl
    {
        public UsrCtrl_Publisher()
        {
            InitializeComponent();
        }

        private void UsrCtrl_Publisher_Load(object sender, EventArgs e)
        {
            try
            {
                SQL_Connection sqlcnt = new SQL_Connection();
                DataTable data = sqlcnt.GetDataByUsingSP("CheckNXB");
                gridControl1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
