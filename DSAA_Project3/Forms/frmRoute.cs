using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAA_Project3.Forms
{
    public partial class frmRoute : Form
    {
        public frmRoute()
        {
            InitializeComponent();
        }

        private void frmRoute_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            if (domainEnd.Text != "（终点）" && domainStart.Text != "（起点）")
            {
                string temp;
                temp = domainEnd.Text;
                domainEnd.Text = domainStart.Text;
                domainStart.Text = temp;
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
