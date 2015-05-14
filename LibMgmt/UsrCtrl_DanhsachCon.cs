using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LibMgmt
{
    public partial class UsrCtrl_DanhsachCon : UserControl
    {
        public UsrCtrl_DanhsachCon()
        {
            InitializeComponent();
        }

        private void UsrCtrl_DanhsachCon_Load(object sender, EventArgs e)
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            DataTable dt = sqlcnt.GetDataByUsingSP("GetList_Remain");
            gridControl1.DataSource = dt;            
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveFileDialog exportExcel = new SaveFileDialog();
            exportExcel.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010)(.xlsx)|*.xlsx";
            if (exportExcel.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = exportExcel.FileName;
                string fileExtension = new FileInfo(exportFilePath).Extension;
                switch(fileExtension)
                {
                    case ".xls": 
                        gridControl1.ExportToXls(exportFilePath);
                        break;
                    case ".xlsx":
                        gridControl1.ExportToXlsx(exportFilePath);
                        break;
                    default: break;
                }
            }
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveFileDialog exportPdf = new SaveFileDialog();
            exportPdf.Filter = "Pdf File (.pdf)|*.pdf";
            if (exportPdf.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = exportPdf.FileName;
                string exportExtension = new FileInfo(exportFilePath).Extension;
                switch(exportExtension)
                {
                    case ".pdf":
                        gridControl1.ExportToPdf(exportFilePath);
                        break;
                    default: break;
                }
            }
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //gridControl1.ShowPrintPreview();
            rptDanhsachcon Dscon = new rptDanhsachcon();
            Dscon.ShowPreview();
        }
    }
}
