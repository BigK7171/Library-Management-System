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
    public partial class UsrCtrl_DanhsachMuon : UserControl
    {
        public UsrCtrl_DanhsachMuon()
        {
            InitializeComponent();
        }

        private void UsrCtrl_DanhsachMuon_Load(object sender, EventArgs e)
        {
            SQL_Connection sqlcnt = new SQL_Connection();
            /*DataTable dt = sqlcnt.GetDataByUsingCmdText(@"select DOCGIA.MADOCGIA,DOCGIA.HOTEN,LOAIDOCGIA.TENLOAIDG,DOCGIA.DIACHI,SACH.MASACH, SACH.TENSACH,PHIEUMUON.NGAYMUON
                                                            from DOCGIA join PHIEUMUON on DOCGIA.MADOCGIA = PHIEUMUON.MADOCGIA 
                                                            join LOAIDOCGIA on DOCGIA.MALOAIDOCGIA=LOAIDOCGIA.MALOAIDOCGIA
                                                            join SACH_PHIEU on PHIEUMUON.MAPHIEU=SACH_PHIEU.MAPHIEU
                                                            join SACH on SACH_PHIEU.MASACH=SACH.MASACH");*/
            DataTable dt = sqlcnt.GetDataByUsingSP("GetList_Borrow");
            gridControl1.DataSource = dt;           
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //gridControl1.ShowPrintPreview();
            rptDanhsachMuon dsMuon = new rptDanhsachMuon();
            dsMuon.ShowPreview();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Pdf File (.pdf)|*.pdf";
            if (saveDialog.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = saveDialog.FileName;
                string fileExtenstion = new FileInfo(exportFilePath).Extension;                
                switch (fileExtenstion)
                {
                    case ".pdf":
                        gridControl1.ExportToPdf(exportFilePath);
                        break;                    
                    default: break;
                }
            }         
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveFileDialog exportExcel = new SaveFileDialog();
            exportExcel.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010)(.xlsx)|*.xlsx";
            if (exportExcel.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = exportExcel.FileName;
                string fileExtension = new FileInfo(exportFilePath).Extension;
                switch (fileExtension)
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
