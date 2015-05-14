using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Reflection;
using DevExpress;
using System.IO;

namespace LibMgmt
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public frmMain()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("The Asphalt World");
            OriginalLogin();
            timer1.Start();
        }
        public static Staff Nhanvien = new Staff();
        public static frmAccess Dangnhap = new frmAccess();
        /*private void btnAuthor_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
           UsrCtrl_Introduce Data = new UsrCtrl_Introduce();
           // UserControl_Introduce Data = new UserControl_Introduce();
            //this.Text = String.Format("Giới thiệu {0}", AssemblyTitle);
            Data.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(Data);
        }*/
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        private void btnAuthor_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_Introduce Data = new UsrCtrl_Introduce();
            Data.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(Data);
        }

        private void btnHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_Help Help = new UsrCtrl_Help();
            Help.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(Help);
        }

        private void btnCal_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void btnMSWord_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.EXE");
        }

        private void btnMSExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("EXCEL.EXE");
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
            //panel_Info.Controls.Clear();            
        }

        private void btnSMS_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_SendSMS sendingSMS = new UsrCtrl_SendSMS();
            sendingSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(sendingSMS);
        }

        private void btnMail_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSendMail sendMail = new frmSendMail();
            sendMail.ShowDialog();
        }

        private void btnBookIssue_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_DanhsachMuon Muon = new UsrCtrl_DanhsachMuon();
            Muon.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(Muon);
        }

        private void btnRemain_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_DanhsachCon dscon = new UsrCtrl_DanhsachCon();
            dscon.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(dscon);
        }

        private void btnSearchClient_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_TimKiemDocGia searchReader = new UsrCtrl_TimKiemDocGia();
            searchReader.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(searchReader);
        }

        private void btnClientUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_CapNhatDocGia updateReader = new UsrCtrl_CapNhatDocGia();
            updateReader.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(updateReader);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_Quanlinhanvien Manage = new UsrCtrl_Quanlinhanvien();
            Manage.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(Manage);
        }

        private void OriginalLogin()
        {
            btnLogin.Enabled = true;
            btnLogout.Enabled = false;
            btnExit.Enabled = true;
            btnAdd.Enabled = false;
            btnChangePwd.Enabled = false;    
            btnIssue.Enabled = false;
            btnReturn.Enabled = false;
            btnInfo.Enabled = false;
            btnUpdate.Enabled = false;
            btnSearch.Enabled = false;
            btnClientUpdate.Enabled = false;
            btnSearchClient.Enabled = false;
            //btnRegularClient.Enabled = false;
            //btnPunish.Enabled = false;
            btnBookIssue.Enabled = false;
            btnRemain.Enabled = false;
            btnMSWord.Enabled = false;
            btnMSExcel.Enabled = false;
            btnCal.Enabled = false;
            btnSMS.Enabled = false;
            btnMail.Enabled = false;
            btnAuthor.Enabled = false;
            btnHelp.Enabled = false;
        }
        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            barStaticTxt.Caption = "Login as:        ";
            OriginalLogin();
        }

        private void btnInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLiDanhMuc Quanlidanhmuc = new frmQuanLiDanhMuc();
            Quanlidanhmuc.ShowDialog();
        }

        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
             string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             Dangnhap = new frmAccess();           
             Dangnhap.ShowDialog();
            if (Dangnhap.DialogResult == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter( path + "\\luu nhan vien.txt");
                sw.WriteLine(frmAccess.Check.GetStaffID());
                sw.Close();
                StreamWriter sw1 = new StreamWriter( path+ "\\luu password.txt");
                sw1.WriteLine(frmAccess.Check.GetPasswd());
                sw1.Close();
                Nhanvien = new Staff(frmAccess.Check.GetStaffID(), frmAccess.Check.GetFullName(), frmAccess.Check.GetAddress(), frmAccess.Check.GetPermission(), frmAccess.Check.GetUserName(),frmAccess.Check.GetPasswd(),frmAccess.Check.GetNumberPhone());
            }
            if (frmAccess.Check.GetPermission().Equals("ADMIN", StringComparison.CurrentCultureIgnoreCase))
            {
                barStaticTxt.Caption = "Login as: " + frmAccess.Check.GetUserName();
                btnLogin.Enabled = false;
                btnLogout.Enabled = true;
                btnExit.Enabled = true;
                btnAdd.Enabled = true;
                btnChangePwd.Enabled = true;               
                btnIssue.Enabled = true;
                btnReturn.Enabled = true;
                btnInfo.Enabled = true;
                btnUpdate.Enabled = true;
                btnSearch.Enabled = true;
                btnClientUpdate.Enabled = true;
                btnSearchClient.Enabled = true;
                //btnRegularClient.Enabled = true;
                //btnPunish.Enabled = true;
                btnBookIssue.Enabled = true;
                btnRemain.Enabled = true;
                btnMSWord.Enabled = true;
                btnMSExcel.Enabled = true;
                btnCal.Enabled = true;
                btnSMS.Enabled = true;
                btnMail.Enabled = true;
                btnAuthor.Enabled = true;
                btnHelp.Enabled = true;
            }

            else if (frmAccess.Check.GetPermission().Equals("MUONTRA", StringComparison.CurrentCultureIgnoreCase))
            {
                barStaticTxt.Caption = "Login as: " + frmAccess.Check.GetUserName();
                btnLogin.Enabled = false;
                btnLogout.Enabled = true;
                btnExit.Enabled = true;
                btnAdd.Enabled = false;
                btnChangePwd.Enabled = true;             
                btnIssue.Enabled = true;
                btnReturn.Enabled = true;
                btnInfo.Enabled = false;
                btnUpdate.Enabled = false;
                btnSearch.Enabled = false;
                btnClientUpdate.Enabled = false;
                btnSearchClient.Enabled = false;
                //btnRegularClient.Enabled = false;
                //btnPunish.Enabled = false;
                btnBookIssue.Enabled = true;
                btnRemain.Enabled = true;
                btnMSWord.Enabled = true;
                btnMSExcel.Enabled = true;
                btnCal.Enabled = true;
                btnSMS.Enabled = true;
                btnMail.Enabled = true;
                btnAuthor.Enabled = true;
                btnHelp.Enabled = true;
            }

            else if (frmAccess.Check.GetPermission().Equals("THUKHO", StringComparison.CurrentCultureIgnoreCase))
            {
                barStaticTxt.Caption = "Login as: " + frmAccess.Check.GetUserName();
                btnLogin.Enabled = false;
                btnLogout.Enabled = true;
                btnExit.Enabled = true;
                btnAdd.Enabled = false;
                btnChangePwd.Enabled = true;
                btnIssue.Enabled = false;
                btnReturn.Enabled = false;
                btnInfo.Enabled = true;
                btnUpdate.Enabled = true;
                btnSearch.Enabled = true;
                btnClientUpdate.Enabled = false;
                btnSearchClient.Enabled = false;
                //btnRegularClient.Enabled = false;
                //btnPunish.Enabled = false;
                btnBookIssue.Enabled = true;
                btnRemain.Enabled = true;
                btnMSWord.Enabled = true;
                btnMSExcel.Enabled = true;
                btnCal.Enabled = true;
                btnSMS.Enabled = true;
                btnMail.Enabled = true;
                btnAuthor.Enabled = true;
                btnHelp.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = true;
                btnLogout.Enabled = false;
                btnExit.Enabled = true;
                btnAdd.Enabled = false;
                btnChangePwd.Enabled = false;
                btnIssue.Enabled = false;
                btnReturn.Enabled = false;
                btnInfo.Enabled = false;
                btnUpdate.Enabled = false;
                btnSearch.Enabled = false;
                btnClientUpdate.Enabled = false;
                btnSearchClient.Enabled = false;
                //btnRegularClient.Enabled = false;
                //btnPunish.Enabled = false;
                btnBookIssue.Enabled = false;
                btnRemain.Enabled = false;
                btnMSWord.Enabled = false;
                btnMSExcel.Enabled = false;
                btnCal.Enabled = false;
                btnSMS.Enabled = false;
                btnMail.Enabled = false;
                btnAuthor.Enabled = false;
                btnHelp.Enabled = false;
            }   
        } 

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime timer1 = DateTime.Now;
            barStaticItem1.Caption = timer1.ToString();
        }

        private void SkinList_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void SkinList_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(SkinList.EditValue.ToString());
        }

        /*private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime timer1 = DateTime.Now;
            barStaticItem1.Caption = timer1.ToString();
        } */

        private void btnChangePwd_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChangePasswd ChangePasswd = new frmChangePasswd();
            ChangePasswd.ShowDialog();
        }

        private void btnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_SearchBook TimKiem = new UsrCtrl_SearchBook();
            TimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(TimKiem);
        }

        private void btnUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_UpdateBook CapNhatSach = new UsrCtrl_UpdateBook();
            CapNhatSach.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(CapNhatSach);
        }

        private void btnIssue_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_QuanLiMuonSach quanlimuon = new UsrCtrl_QuanLiMuonSach();
            quanlimuon.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(quanlimuon);
        }

        private void btnReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel_Info.Controls.Clear();
            UsrCtrl_ReturnBook TraSach = new UsrCtrl_ReturnBook();
            TraSach.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Info.Controls.Add(TraSach);
        }

        


        /*public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }*/
        #endregion
    }
}