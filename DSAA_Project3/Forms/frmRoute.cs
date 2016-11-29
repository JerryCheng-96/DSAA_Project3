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
            frmRouteElem elem = new frmRouteElem(Program.theGraph.vtxCollection.locList[0], Route.posOfLoc.Start);
            elem.TopLevel = false;
            panel1.Controls.Add(elem);
            elem.Show();
            frmRouteElem elem2 = new frmRouteElem(Program.theGraph.egdCollection.edgeList[0]);
            elem2.TopLevel = false;
            elem2.Location = new Point(elem.Location.X, elem.Location.Y + 39);
            panel1.Controls.Add(elem2);
            elem2.Show();
            frmRouteElem elem3 = new frmRouteElem(Program.theGraph.vtxCollection.locList[2]);
            elem3.TopLevel = false;
            elem3.Location = new Point(elem.Location.X, elem2.Location.Y + 39);
            panel1.Controls.Add(elem3);
            elem3.Show();
            frmRouteElem elem4 = new frmRouteElem(Program.theGraph.egdCollection.edgeList[1]);
            elem4.TopLevel = false;
            elem4.Location = new Point(elem.Location.X, elem3.Location.Y + 39);
            panel1.Controls.Add(elem4);
            elem4.Show();
            frmRouteElem elem5 = new frmRouteElem(Program.theGraph.vtxCollection.locList[1], Route.posOfLoc.End);
            elem5.TopLevel = false;
            elem5.Location = new Point(elem.Location.X, elem4.Location.Y + 39);
            panel1.Controls.Add(elem5);
            elem5.Show();
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
                this.Text = domainStart.Text + " -> " + domainEnd.Text;
            } 
        }

        public void updateContent(string start)
        {
            this.domainStart.Text = start;
        }

        public void updateContent(string start, string end)
        {
            this.domainStart.Text = start;
            this.domainEnd.Text = end;
        }

        public void updateContent(int numPos, int dist)
        {
            lGlance.Text = "经过 " + numPos.ToString() + " 个地点 · 距离 " + dist.ToString() + " m";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (domainEnd.Text != "（终点）" && domainStart.Text != "（起点）")
            {
                this.Text = domainStart.Text + " -> " + domainEnd.Text;
            }
        }
    }
}
