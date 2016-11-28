using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAA_Project3
{
    public partial class frmMain : Form
    {
        public static frmInfo infoWindow;

        public frmMain()
        {
            InitializeComponent();
            infoWindow = new frmInfo();

            #region Set Button Style
            SetBtnStyle(btnColArt);
            SetBtnStyle(btnBuGao);
            SetBtnStyle(btnTrCtr);
            SetBtnStyle(btnColAE);
            SetBtnStyle(btnYouthSqr);
            SetBtnStyle(btnColPE);
            SetBtnStyle(btnDorm1);
            SetBtnStyle(btnHospital);
            SetBtnStyle(btnDorm21);
            SetBtnStyle(btnSWGate);
            SetBtnStyle(btnLib);
            SetBtnStyle(btn1Bd);
            SetBtnStyle(btn2Ex);
            SetBtnStyle(btnSSComplex);
            SetBtnStyle(btnShawBd);
            SetBtnStyle(btnSGate);
            SetBtnStyle(btn1Ex);
            SetBtnStyle(btnGym);
            SetBtnStyle(btnSEGate);
            SetBtnStyle(btnEGate);
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picMaskHelp.BackColor = Color.Transparent;
            btnHelp.Visible = false;
            btnHelpOK.Visible = true;
        }

        private void btnHelpOK_Click(object sender, EventArgs e)
        {
            btnHelpOK.Visible = false;
            picMaskHelp.BackColor = Color.White;
            btnHelp.Visible = true;
            
        }

        private void SetBtnStyle(Button btn)  //在Form1_Load时候调用
        {

            btn.FlatStyle = FlatStyle.Flat;//样式

            btn.ForeColor = Color.Transparent;//前景

            btn.BackColor = Color.Transparent;//去背景

            btn.FlatAppearance.BorderSize = 0;//去边线

            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过

            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下

        }

        public void showInfoWindow(string name)
        {
            GC.Collect();
            try
            {
                infoWindow.updateContent(Program.db.locList.Find(delegate (loc l) { return l.code == name; }));
                infoWindow.Show();
            }
            catch (ObjectDisposedException)
            {
                infoWindow = new frmInfo();
                infoWindow.updateContent(Program.db.locList.Find(delegate (loc l) { return l.code == name; }));
                infoWindow.Show();
            }
            infoWindow.Activate();
        }

        // The Click Behavior of the Location Buttons
        #region LocBtnClick

        private void btnColArt_Click(object sender, EventArgs e)
        {
            showInfoWindow("ColArt");
        }

        private void btnSSComplex_Click(object sender, EventArgs e)
        {
            showInfoWindow("SSCplx");
        }

        private void btnEGate_Click(object sender, EventArgs e)
        {
            showInfoWindow("EastGate");
        }

        private void btnDorm1_Click(object sender, EventArgs e)
        {
            showInfoWindow("Dorm1");
        }

        private void btn1Bd_Click(object sender, EventArgs e)
        {
            showInfoWindow("TBd1");
        }

        private void btnLib_Click(object sender, EventArgs e)
        {
            showInfoWindow("Lib");
        }

        private void btnShawBd_Click(object sender, EventArgs e)
        {
            showInfoWindow("ShawBd");
        }

        private void btnGym_Click(object sender, EventArgs e)
        {
            showInfoWindow("Gym");
        }

        #endregion

        // The MouseEnter and MouseLeave
        #region MouseEnter and MouseLeave
        private void btnColArt_MouseEnter(object sender, EventArgs e) { btnColArt.FlatAppearance.BorderColor = Color.Black; btnColArt.FlatAppearance.BorderSize = 1; }
        private void btnBuGao_MouseEnter(object sender, EventArgs e) { btnBuGao.FlatAppearance.BorderColor = Color.Black; btnBuGao.FlatAppearance.BorderSize = 1; }
        private void btnTrCtr_MouseEnter(object sender, EventArgs e) { btnTrCtr.FlatAppearance.BorderColor = Color.Black; btnTrCtr.FlatAppearance.BorderSize = 1; }
        private void btnColAE_MouseEnter(object sender, EventArgs e) { btnColAE.FlatAppearance.BorderColor = Color.Black; btnColAE.FlatAppearance.BorderSize = 1; }
        private void btnYouthSqr_MouseEnter(object sender, EventArgs e) { btnYouthSqr.FlatAppearance.BorderColor = Color.Black; btnYouthSqr.FlatAppearance.BorderSize = 1; }
        private void btnColPE_MouseEnter(object sender, EventArgs e) { btnColPE.FlatAppearance.BorderColor = Color.Black; btnColPE.FlatAppearance.BorderSize = 1; }
        private void btnDorm1_MouseEnter(object sender, EventArgs e) { btnDorm1.FlatAppearance.BorderColor = Color.Black; btnDorm1.FlatAppearance.BorderSize = 1; }
        private void btnHospital_MouseEnter(object sender, EventArgs e) { btnHospital.FlatAppearance.BorderColor = Color.Black; btnHospital.FlatAppearance.BorderSize = 1; }
        private void btnDorm21_MouseEnter(object sender, EventArgs e) { btnDorm21.FlatAppearance.BorderColor = Color.Black; btnDorm21.FlatAppearance.BorderSize = 1; }
        private void btnSWGate_MouseEnter(object sender, EventArgs e) { btnSWGate.FlatAppearance.BorderColor = Color.Black; btnSWGate.FlatAppearance.BorderSize = 1; }
        private void btnLib_MouseEnter(object sender, EventArgs e) { btnLib.FlatAppearance.BorderColor = Color.Black; btnLib.FlatAppearance.BorderSize = 1; }
        private void btn1Bd_MouseEnter(object sender, EventArgs e) { btn1Bd.FlatAppearance.BorderColor = Color.Black; btn1Bd.FlatAppearance.BorderSize = 1; }
        private void btn2Ex_MouseEnter(object sender, EventArgs e) { btn2Ex.FlatAppearance.BorderColor = Color.Black; btn2Ex.FlatAppearance.BorderSize = 1; }
        private void btnSSComplex_MouseEnter(object sender, EventArgs e) { btnSSComplex.FlatAppearance.BorderColor = Color.Black; btnSSComplex.FlatAppearance.BorderSize = 1; }
        private void btnShawBd_MouseEnter(object sender, EventArgs e) { btnShawBd.FlatAppearance.BorderColor = Color.Black; btnShawBd.FlatAppearance.BorderSize = 1; }
        private void btnSGate_MouseEnter(object sender, EventArgs e) { btnSGate.FlatAppearance.BorderColor = Color.Black; btnSGate.FlatAppearance.BorderSize = 1; }
        private void btn1Ex_MouseEnter(object sender, EventArgs e) { btn1Ex.FlatAppearance.BorderColor = Color.Black; btn1Ex.FlatAppearance.BorderSize = 1; }
        private void btnGym_MouseEnter(object sender, EventArgs e) { btnGym.FlatAppearance.BorderColor = Color.Black; btnGym.FlatAppearance.BorderSize = 1; }
        private void btnSEGate_MouseEnter(object sender, EventArgs e) { btnSEGate.FlatAppearance.BorderColor = Color.Black; btnSEGate.FlatAppearance.BorderSize = 1; }
        private void btnEGate_MouseEnter(object sender, EventArgs e) { btnEGate.FlatAppearance.BorderColor = Color.Black; btnEGate.FlatAppearance.BorderSize = 1; }

        private void btnColArt_MouseLeave(object sender, EventArgs e) { btnColArt.FlatAppearance.BorderSize = 0; }
        private void btnBuGao_MouseLeave(object sender, EventArgs e) { btnBuGao.FlatAppearance.BorderSize = 0; }
        private void btnTrCtr_MouseLeave(object sender, EventArgs e) { btnTrCtr.FlatAppearance.BorderSize = 0; }
        private void btnColAE_MouseLeave(object sender, EventArgs e) { btnColAE.FlatAppearance.BorderSize = 0; }
        private void btnYouthSqr_MouseLeave(object sender, EventArgs e) { btnYouthSqr.FlatAppearance.BorderSize = 0; }
        private void btnColPE_MouseLeave(object sender, EventArgs e) { btnColPE.FlatAppearance.BorderSize = 0; }
        private void btnDorm1_MouseLeave(object sender, EventArgs e) { btnDorm1.FlatAppearance.BorderSize = 0; }
        private void btnHospital_MouseLeave(object sender, EventArgs e) { btnHospital.FlatAppearance.BorderSize = 0; }
        private void btnDorm21_MouseLeave(object sender, EventArgs e) { btnDorm21.FlatAppearance.BorderSize = 0; }
        private void btnSWGate_MouseLeave(object sender, EventArgs e) { btnSWGate.FlatAppearance.BorderSize = 0; }
        private void btnLib_MouseLeave(object sender, EventArgs e) { btnLib.FlatAppearance.BorderSize = 0; }
        private void btn1Bd_MouseLeave(object sender, EventArgs e) { btn1Bd.FlatAppearance.BorderSize = 0; }
        private void btn2Ex_MouseLeave(object sender, EventArgs e) { btn2Ex.FlatAppearance.BorderSize = 0; }
        private void btnSSComplex_MouseLeave(object sender, EventArgs e) { btnSSComplex.FlatAppearance.BorderSize = 0; }
        private void btnShawBd_MouseLeave(object sender, EventArgs e) { btnShawBd.FlatAppearance.BorderSize = 0; }
        private void btnSGate_MouseLeave(object sender, EventArgs e) { btnSGate.FlatAppearance.BorderSize = 0; }
        private void btn1Ex_MouseLeave(object sender, EventArgs e) { btn1Ex.FlatAppearance.BorderSize = 0; }
        private void btnGym_MouseLeave(object sender, EventArgs e) { btnGym.FlatAppearance.BorderSize = 0; }
        private void btnSEGate_MouseLeave(object sender, EventArgs e) { btnSEGate.FlatAppearance.BorderSize = 0; }
        private void btnEGate_MouseLeave(object sender, EventArgs e) { btnEGate.FlatAppearance.BorderSize = 0; }
        #endregion
    }
}
