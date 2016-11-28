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

        public frmInfo(loc locToDisp)
        {
            InitializeComponent();
            this.Text = locToDisp.name;
            lName.Text = locToDisp.name;
            lEngName.Text = locToDisp.engName;
            lInfo.Text = locToDisp.intro;
            lType.Text = locToDisp.type;
            pictureBox1.Image = Properties.InfoImage.FindImg(locToDisp.imgAdd);
        }
        
        public void updateContent(loc locToDisp)
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
            pictureBox1.Image = Properties.InfoImage.FindImg(locToDisp.imgAdd);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void lName_Click(object sender, EventArgs e)
        {

        }
    }
}
