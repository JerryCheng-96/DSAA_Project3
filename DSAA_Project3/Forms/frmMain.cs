using DSAA_Project3.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DSAA_Project3
{
    public partial class frmMain : Form
    {
        public static frmInfo infoWindow = null;
        public static frmRoute routeWindow = null;
        public static Point nowPosition;
        public static Point nowSize;
        public string startPoint = null;
        public string endPoint = null;
        public static frmMain theFrmMain = null;

        public frmMain()
        {
            InitializeComponent();
            nowPosition = new Point(Location.X, Location.Y);
            nowSize = new Point(Size.Width, Size.Height);
            theFrmMain = this;
            assignPicBox(Program.edgeDB, Program.db);

            foreach (Vertex l in Program.db.locList)
            {
                Control[] button = Controls.Find("btn" + l.code, true);
                foreach (Button item in button) { SetBtnStyle(item); }

                Control[] VertexPicBox = Controls.Find(l.code + "_d", true);
                foreach (PictureBox item in VertexPicBox) { l.picDot = item; }
            }

            foreach (Edge e in Program.edgeDB.edgeList)
            {
                Control[] picBox = Controls.Find("routeArrow" + e.id, true);
                foreach (PictureBox item in picBox) { e.picEdge = item; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picMaskHelp.BackColor = Color.Transparent;
            btnHelp.Visible = false;
            btnRoute.Visible = false;
            btnHelpOK.Visible = true;
        }

        private void btnHelpOK_Click(object sender, EventArgs e)
        {
            btnHelpOK.Visible = false;
            picMaskHelp.BackColor = Color.White;
            btnRoute.Visible = true;
            btnHelp.Visible = true;
            
        }

        private void SetBtnStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.Transparent;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        public void showInfoWindow(string name)
        {
            GC.Collect();
            frmInfo nowInfoWindow = getFrmInfo();
            nowInfoWindow.updateContent(Program.db.locList.Find(delegate (Vertex l) { return l.code == name; }));
            nowInfoWindow.StartPosition = FormStartPosition.Manual;
            nowInfoWindow.Location = new Point(nowPosition.X + nowSize.X + 15, nowPosition.Y);
            nowInfoWindow.Show();
            nowInfoWindow.Activate();
        }

        // The Click Behavior of the Location Buttons
        #region VertexBtnClick

        private void btnColArt_Click(object sender, EventArgs e)
        {
            ClickAssist("ColArt");
        }

        private void btnSSComplex_Click(object sender, EventArgs e)
        {
            ClickAssist("SSCplx");
        }

        private void btnEGate_Click(object sender, EventArgs e)
        {
            ClickAssist("EGate");
        }

        private void btnDorm1_Click(object sender, EventArgs e)
        {
            ClickAssist("Dorm1");
        }

        private void btn1Bd_Click(object sender, EventArgs e)
        {
            ClickAssist("TBd1");
        }

        private void btnLib_Click(object sender, EventArgs e)
        {
            ClickAssist("Lib");
        }

        private void btnShawBd_Click(object sender, EventArgs e)
        {
            ClickAssist("ShawBd");
        }

        private void btnGym_Click(object sender, EventArgs e)
        {
            ClickAssist("Gym");
        }

        private void btnDorm21_Click(object sender, EventArgs e)
        {
            ClickAssist("Dorm21");
        }

        private void btnHospital_Click(object sender, EventArgs e)
        {
            ClickAssist("SHos");
        }

        private void btnBuGao_Click(object sender, EventArgs e)
        {
            ClickAssist("BGMt");
        }

        private void btnYouthSqr_Click(object sender, EventArgs e)
        {
            ClickAssist("YSq");
        }

        private void btnColPE_Click(object sender, EventArgs e)
        {
            ClickAssist("ColPE");
        }

        private void btnTrCtr_Click(object sender, EventArgs e)
        {
            ClickAssist("ETC");
        }

        private void btnColAE_Click(object sender, EventArgs e)
        {
            ClickAssist("CAE");
        }

        private void btn2Ex_Click(object sender, EventArgs e)
        {
            ClickAssist("Ex2");
        }

        private void btn1Ex_Click(object sender, EventArgs e)
        {
            ClickAssist("Ex1");
        }

        private void btnSWGate_Click(object sender, EventArgs e)
        {
            ClickAssist("SWGate");
        }

        private void btnSGate_Click(object sender, EventArgs e)
        {
            ClickAssist("SGate");
        }

        private void btnSEGate_Click(object sender, EventArgs e)
        {
            ClickAssist("SEGate");
        }

        #endregion

        // The MouseEnter and MouseLeave
        #region MouseEnter and MouseLeave
        private void btnColArt_MouseEnter(object sender, EventArgs e) { btnColArt.FlatAppearance.BorderColor = Color.Gray; btnColArt.FlatAppearance.BorderSize = 1; }
        private void btnBuGao_MouseEnter(object sender, EventArgs e) { btnBGMt.FlatAppearance.BorderColor = Color.Gray; btnBGMt.FlatAppearance.BorderSize = 1; }
        private void btnTrCtr_MouseEnter(object sender, EventArgs e) { btnETC.FlatAppearance.BorderColor = Color.Gray; btnETC.FlatAppearance.BorderSize = 1; }
        private void btnColAE_MouseEnter(object sender, EventArgs e) { btnCAE.FlatAppearance.BorderColor = Color.Gray; btnCAE.FlatAppearance.BorderSize = 1; }
        private void btnYouthSqr_MouseEnter(object sender, EventArgs e) { btnYSq.FlatAppearance.BorderColor = Color.Gray; btnYSq.FlatAppearance.BorderSize = 1; }
        private void btnColPE_MouseEnter(object sender, EventArgs e) { btnColPE.FlatAppearance.BorderColor = Color.Gray; btnColPE.FlatAppearance.BorderSize = 1; }
        private void btnDorm1_MouseEnter(object sender, EventArgs e) { btnDorm1.FlatAppearance.BorderColor = Color.Gray; btnDorm1.FlatAppearance.BorderSize = 1; }
        private void btnHospital_MouseEnter(object sender, EventArgs e) { btnSHos.FlatAppearance.BorderColor = Color.Gray; btnSHos.FlatAppearance.BorderSize = 1; }
        private void btnDorm21_MouseEnter(object sender, EventArgs e) { btnDorm21.FlatAppearance.BorderColor = Color.Gray; btnDorm21.FlatAppearance.BorderSize = 1; }
        private void btnSWGate_MouseEnter(object sender, EventArgs e) { btnSWGate.FlatAppearance.BorderColor = Color.Gray; btnSWGate.FlatAppearance.BorderSize = 1; }
        private void btnLib_MouseEnter(object sender, EventArgs e) { btnLib.FlatAppearance.BorderColor = Color.Gray; btnLib.FlatAppearance.BorderSize = 1; }
        private void btn1Bd_MouseEnter(object sender, EventArgs e) { btnTBd1.FlatAppearance.BorderColor = Color.Gray; btnTBd1.FlatAppearance.BorderSize = 1; }
        private void btn2Ex_MouseEnter(object sender, EventArgs e) { btnEx2.FlatAppearance.BorderColor = Color.Gray; btnEx2.FlatAppearance.BorderSize = 1; }
        private void btnSSComplex_MouseEnter(object sender, EventArgs e) { btnSSCplx.FlatAppearance.BorderColor = Color.Gray; btnSSCplx.FlatAppearance.BorderSize = 1; }
        private void btnShawBd_MouseEnter(object sender, EventArgs e) { btnShawBd.FlatAppearance.BorderColor = Color.Gray; btnShawBd.FlatAppearance.BorderSize = 1; }
        private void btnSGate_MouseEnter(object sender, EventArgs e) { btnSGate.FlatAppearance.BorderColor = Color.Gray; btnSGate.FlatAppearance.BorderSize = 1; }
        private void btn1Ex_MouseEnter(object sender, EventArgs e) { btnEx1.FlatAppearance.BorderColor = Color.Gray; btnEx1.FlatAppearance.BorderSize = 1; }
        private void btnGym_MouseEnter(object sender, EventArgs e) { btnGym.FlatAppearance.BorderColor = Color.Gray; btnGym.FlatAppearance.BorderSize = 1; }
        private void btnSEGate_MouseEnter(object sender, EventArgs e) { btnSEGate.FlatAppearance.BorderColor = Color.Gray; btnSEGate.FlatAppearance.BorderSize = 1; }
        private void btnEGate_MouseEnter(object sender, EventArgs e) { btnEGate.FlatAppearance.BorderColor = Color.Gray; btnEGate.FlatAppearance.BorderSize = 1; }

        private void btnColArt_MouseLeave(object sender, EventArgs e) { btnColArt.FlatAppearance.BorderSize = 0; }
        private void btnBuGao_MouseLeave(object sender, EventArgs e) { btnBGMt.FlatAppearance.BorderSize = 0; }
        private void btnTrCtr_MouseLeave(object sender, EventArgs e) { btnETC.FlatAppearance.BorderSize = 0; }
        private void btnColAE_MouseLeave(object sender, EventArgs e) { btnCAE.FlatAppearance.BorderSize = 0; }
        private void btnYouthSqr_MouseLeave(object sender, EventArgs e) { btnYSq.FlatAppearance.BorderSize = 0; }
        private void btnColPE_MouseLeave(object sender, EventArgs e) { btnColPE.FlatAppearance.BorderSize = 0; }
        private void btnDorm1_MouseLeave(object sender, EventArgs e) { btnDorm1.FlatAppearance.BorderSize = 0; }
        private void btnHospital_MouseLeave(object sender, EventArgs e) { btnSHos.FlatAppearance.BorderSize = 0; }
        private void btnDorm21_MouseLeave(object sender, EventArgs e) { btnDorm21.FlatAppearance.BorderSize = 0; }
        private void btnSWGate_MouseLeave(object sender, EventArgs e) { btnSWGate.FlatAppearance.BorderSize = 0; }
        private void btnLib_MouseLeave(object sender, EventArgs e) { btnLib.FlatAppearance.BorderSize = 0; }
        private void btn1Bd_MouseLeave(object sender, EventArgs e) { btnTBd1.FlatAppearance.BorderSize = 0; }
        private void btn2Ex_MouseLeave(object sender, EventArgs e) { btnEx2.FlatAppearance.BorderSize = 0; }
        private void btnSSComplex_MouseLeave(object sender, EventArgs e) { btnSSCplx.FlatAppearance.BorderSize = 0; }
        private void btnShawBd_MouseLeave(object sender, EventArgs e) { btnShawBd.FlatAppearance.BorderSize = 0; }
        private void btnSGate_MouseLeave(object sender, EventArgs e) { btnSGate.FlatAppearance.BorderSize = 0; }
        private void btn1Ex_MouseLeave(object sender, EventArgs e) { btnEx1.FlatAppearance.BorderSize = 0; }
        private void btnGym_MouseLeave(object sender, EventArgs e) { btnGym.FlatAppearance.BorderSize = 0; }
        private void btnSEGate_MouseLeave(object sender, EventArgs e) { btnSEGate.FlatAppearance.BorderSize = 0; }
        private void btnEGate_MouseLeave(object sender, EventArgs e) { btnEGate.FlatAppearance.BorderSize = 0; }
        #endregion

        private void frmMain_LocationChanged(object sender, EventArgs e)
        {
            nowPosition = new Point(Location.X, Location.Y);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GC.Collect();
            frmRoute nowRouteWindow = getFrmRoute();
            nowRouteWindow.clearView();
            nowRouteWindow.StartPosition = FormStartPosition.Manual;
            nowRouteWindow.Location = new Point(nowPosition.X + nowSize.X + 15, nowPosition.Y);
            nowRouteWindow.Show();
        }

        public static frmInfo getFrmInfo()
        {
            if (infoWindow == null || infoWindow.IsDisposed)
            {
                infoWindow = new frmInfo();
            }
            return infoWindow;
        }

        public static frmRoute getFrmRoute()
        {
            if (routeWindow == null || routeWindow.IsDisposed)
            {
                routeWindow = new frmRoute();
            }
            return routeWindow;
        }

        public void ClickAssist(string code)
        {
            if (ModifierKeys != Keys.Control)
            {
                showInfoWindow(code);
            }
            else
            {
                if (startPoint == null)
                {
                    startPoint = code;
                    Text = "江安数字平面图 - 从 " + Program.theGraph.vtxCollection.locList.Find(delegate (Vertex v1) { return v1.code == startPoint; }).name;
                }
                else if (startPoint != null && endPoint == null)
                {
                    endPoint = code;
                    Text = "江安数字平面图 - 从 " + Program.theGraph.vtxCollection.locList.Find(delegate (Vertex v1) { return v1.code == startPoint; }).name + " 到 " + Program.theGraph.vtxCollection.locList.Find(delegate (Vertex v2) { return v2.code == endPoint; }).name;
                    GC.Collect();
                    frmRoute nowRouteWindow = getFrmRoute();
                    nowRouteWindow.StartPosition = FormStartPosition.Manual;
                    nowRouteWindow.clearView();
                    nowRouteWindow.updateContent(Program.theGraph.vtxCollection.locList.Find(delegate (Vertex v1) { return v1.code == startPoint; }).name,
                        Program.theGraph.vtxCollection.locList.Find(delegate (Vertex v2) { return v2.code == endPoint; }).name);
                    startPoint = endPoint = null;
                    nowRouteWindow.Location = new Point(nowPosition.X + nowSize.X + 15, nowPosition.Y);
                    nowRouteWindow.Show();
                    nowRouteWindow.Activate();
                }
            }
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            startPoint = endPoint = null;
            Text = "江安数字平面图";
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                Text = "江安数字平面图 - 从 ";
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            startPoint = endPoint = null;
            Text = "江安数字平面图";
            clearArrows(Program.edgeDB);
            clearDots(Program.db);
        }

        //public void showArrow(Edge theEdge)
        //{
        //    Control[] picBox = Controls.Find("routeArrow" + theEdge.id, true);
        //    int temp = new int();

        //    if (int.TryParse(theEdge.id.Substring(theEdge.id.Length - 1), out temp))
        //    {
        //        if (theEdge.id[0] == '_')
        //        {
        //            if (Program.db.locList.FindIndex(delegate (Vertex v1) { return v1 == theEdge.v1; }) 
        //                < Program.db.locList.FindIndex(delegate (Vertex v2) { return v2 == theEdge.v2; }))
        //            {
        //                foreach (PictureBox thePicBox in picBox)
        //                {
        //                    thePicBox.BackgroundImage = Properties.Resources.Arrow_Right;
        //                }
        //            }
        //            else
        //            {
        //                foreach (PictureBox thePicBox in picBox)
        //                {
        //                    thePicBox.BackgroundImage = Properties.Resources.Arrow_Left;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (Program.db.locList.FindIndex(delegate (Vertex v1) { return v1 == theEdge.v1; })
        //                < Program.db.locList.FindIndex(delegate (Vertex v2) { return v2 == theEdge.v2; }))
        //            {
        //                foreach (PictureBox thePicBox in picBox)
        //                {
        //                    thePicBox.BackgroundImage = Properties.Resources.Arrow_Down;
        //                }
        //            }
        //            else
        //            {
        //                foreach (PictureBox thePicBox in picBox)
        //                {
        //                    thePicBox.BackgroundImage = Properties.Resources.Arrow_Up;
        //                }
        //            }
        //        }
        //    }
        //}

        public void showArrow(Edge theEdge)
        {
            int temp = new int();

            if (int.TryParse(theEdge.id.Substring(theEdge.id.Length - 1), out temp))
            {
                if (theEdge.id[0] == '_')
                {
                    if (Program.db.locList.FindIndex(delegate (Vertex v1) { return v1 == theEdge.v1; })
                        < Program.db.locList.FindIndex(delegate (Vertex v2) { return v2 == theEdge.v2; }))
                    {
                        theEdge.picEdge.BackgroundImage = Properties.Resources.Arrow_Right;
                    }
                    else
                    {
                        theEdge.picEdge.BackgroundImage = Properties.Resources.Arrow_Left;
                    }
                }
                else
                {
                    if (Program.db.locList.FindIndex(delegate (Vertex v1) { return v1 == theEdge.v1; })
                        < Program.db.locList.FindIndex(delegate (Vertex v2) { return v2 == theEdge.v2; }))
                    {
                        theEdge.picEdge.BackgroundImage = Properties.Resources.Arrow_Down;                       
                    }
                    else
                    {
                        theEdge.picEdge.BackgroundImage = Properties.Resources.Arrow_Up;
                    }
                }
            }
        }

        public void showDot(Vertex v, Route.posOfLoc pos)
        {
            if (pos == Route.posOfLoc.Start)
            {
                v.picDot.BackgroundImage = Properties.Resources.Purple;
            }
            else if (pos == Route.posOfLoc.Pass)
            {
                v.picDot.BackgroundImage = Properties.Resources.Green;
            }
            else if (pos == Route.posOfLoc.End)
            {
                v.picDot.BackgroundImage = Properties.Resources.Red;
            }
        }

        public void clearArrows(EdgeCollection ec)
        {
            foreach (Edge e in ec.edgeList)
            {
                e.picEdge.BackgroundImage = null;
            }
        }

        public void clearDots(VertexCollection vc)
        {
            foreach (Vertex v in vc.locList)
            {
                v.picDot.BackgroundImage = null;
            }
        }

        private void assignPicBox(EdgeCollection ec, VertexCollection vc)
        {
            Control[] thePicBox = null;

            foreach (Edge e in ec.edgeList)
            {
                thePicBox = Controls.Find("routeArrow" + e.id, true);
                foreach (PictureBox picBox in thePicBox)
                {
                    e.picEdge = picBox;
                }
            }

            foreach (Vertex v in vc.locList)
            {
                thePicBox = Controls.Find(v.code + "_d", true);
                foreach (PictureBox picBox in thePicBox)
                {
                    v.picDot = picBox;
                }
            }
        }

        public static frmMain getFrmMain()
        {
            return theFrmMain;
        }
    }
}
