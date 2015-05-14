using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace LibMgmt
{
    public partial class rptDanhsachcon : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhsachcon()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //SQL_Connection sqlcnt = new SQL_Connection();
            //DataTable dt = sqlcnt.GetDataByUsingSP("GetList_Remain");
            
        }

    }
}
