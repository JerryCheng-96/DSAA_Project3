using System;
using System.Windows.Forms;

namespace DSAA_Project3.Forms
{
    public partial class frmRouteElem : Form
    {
        public frmRouteElem()
        {
            InitializeComponent();
            GEIcon.BackgroundImage = null;
            lInfo.Text = null;
        }

        public frmRouteElem(GraphElem ge, Route.posOfLoc pos = Route.posOfLoc.Pass)
        {
            InitializeComponent();

            switch (ge.elemType)
            {
                case GraphElem.eType.Vertex:
                    switch (pos)
                    {
                        case Route.posOfLoc.Pass:
                            GEIcon.BackgroundImage = Properties.Resources.Station;
                            break;
                        case Route.posOfLoc.Start:
                            GEIcon.BackgroundImage = Properties.Resources.Station_Start;
                            break;
                        case Route.posOfLoc.End:
                            GEIcon.BackgroundImage = Properties.Resources.Station_End;
                            break;
                        default:
                            GEIcon.BackgroundImage = null;
                            break;
                    }
                    lInfo.Text = ((Vertex)ge).name;
                    break;
                case GraphElem.eType.Edge:
                    GEIcon.BackgroundImage = Properties.Resources.Road;
                    lInfo.ForeColor = System.Drawing.Color.Gray;
                    lInfo.Text = ((Edge)ge).len.ToString() + " m";
                    break;
                default:
                    GEIcon.BackgroundImage = null;
                    break;
            }
        }

        private void frmRouteElem_Load(object sender, EventArgs e)
        {

        }
    }
}
