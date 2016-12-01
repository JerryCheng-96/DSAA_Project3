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
        public Route theRoute = null;

        public frmRoute()
        {
            InitializeComponent();
            theRoute = new Route();
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
                button1_Click_1(sender, e);
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
            Text = domainStart.Text + " -> " + domainEnd.Text;
            updateRoute(domainStart.Text, domainEnd.Text);
            refreshShow();
        }

        public void updateContent(int numPos, int dist)
        {
            lGlance.Text = "经过 " + numPos.ToString() + " 个地点 · 距离 " + dist.ToString() + " m";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (domainEnd.Text != "（终点）" && domainStart.Text != "（起点）")
            {
                Text = domainStart.Text + " -> " + domainEnd.Text;
                updateRoute(domainStart.Text, domainEnd.Text);
                refreshShow();
            }
            else
            {
                lGlance.Text = "请选择起点与终点";
            }
        }

        private void showRoute(Route route)
        { frmRouteElem prevFrmElem;
            frmRouteElem nowFrmElem;

            nowFrmElem = new frmRouteElem(route.elemList[0], Route.posOfLoc.Start);
            nowFrmElem.TopLevel = false;
            nowFrmElem.Location = new Point(30, 0);
            panel1.Controls.Add(nowFrmElem);
            nowFrmElem.Show();
            prevFrmElem = nowFrmElem;
            nowFrmElem = null;

            if (route.numVtx != 1)
            {

                for (int i = 1; i < route.elemList.Count - 1; i++)
                {
                    nowFrmElem = new frmRouteElem(route.elemList[i]);
                    nowFrmElem.TopLevel = false;
                    nowFrmElem.Location = new Point(prevFrmElem.Location.X, prevFrmElem.Location.Y + 27);
                    panel1.Controls.Add(nowFrmElem);
                    nowFrmElem.Show();
                    prevFrmElem = nowFrmElem;
                    nowFrmElem = null;
                }

                nowFrmElem = new frmRouteElem(route.elemList[route.elemList.Count - 1], Route.posOfLoc.End);
                nowFrmElem.TopLevel = false;
                nowFrmElem.Location = new Point(prevFrmElem.Location.X, prevFrmElem.Location.Y + 27);
                panel1.Controls.Add(nowFrmElem);
                nowFrmElem.Show();
                prevFrmElem = null;
                nowFrmElem = null;
            }

            updateContent(route.numVtx, route.dist);
        }

        public void showRoute()
        {
            showRoute(theRoute);
        }

        public void updateRoute(string start, string end)
        {
            theRoute = new Route();
            theRoute.PathToRoute(Program.theGraph.DijkstraPath(
                Program.theGraph.vtxCollection.locList.Find(delegate (Vertex v1) { return v1.name == start; }),
                Program.theGraph.vtxCollection.locList.Find(delegate (Vertex v2) { return v2.name == end; })), 
                Program.theGraph);
        }

        public void refreshShow()
        {
            panel1.Controls.Clear();
            showRoute();
        }

        public void clearView()
        {
            panel1.Controls.Clear();
            Text = "寻找路线";
            domainEnd.Text = "（终点）";
            domainStart.Text = "（起点）";
            lGlance.Text = "请选择起点与终点";
        }
    }
}
