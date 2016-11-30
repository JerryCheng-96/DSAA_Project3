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
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }

        public frmInfo(Vertex locToDisp)
        {
            InitializeComponent();
            this.Text = locToDisp.name;
            lName.Text = locToDisp.name;
            lEngName.Text = locToDisp.engName;
            lInfo.Text = locToDisp.intro;
            lType.Text = locToDisp.type;
            pictureBox1.Image = Properties.InfoImage.FindImg(locToDisp.code);
        }
        
        public void updateContent(Vertex locToDisp)
        {
            this.Text = "";
            lName.Text = "";
            lEngName.Text = "";
            lInfo.Text = "";
            lType.Text = "";
            pictureBox1.Image = null;

            this.Text = locToDisp.name;
            lName.Text = locToDisp.name;
            lEngName.Text = locToDisp.engName;
            lInfo.Text = locToDisp.intro;
            lType.Text = locToDisp.type;
            pictureBox1.Image = Properties.InfoImage.FindImg(locToDisp.code);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void lName_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmMain.routeWindow = new Forms.frmRoute();
            frmMain.routeWindow.updateContent(lName.Text);
            frmMain.routeWindow.StartPosition = FormStartPosition.Manual;
            frmMain.routeWindow.Location = new Point(frmMain.nowPosition.X + frmMain.nowSize.X + 15, frmMain.nowPosition.Y);
            frmMain.routeWindow.Show();
            this.Close();
        }
    }
}
