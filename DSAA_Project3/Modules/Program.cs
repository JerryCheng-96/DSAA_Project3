using System;
using System.Windows.Forms;

namespace DSAA_Project3
{
    static class Program
    {
        public static VertexCollection db;
        public static EdgeCollection edgeDB;
        public static Graph theGraph;
        public static Route testRoute;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            db = new VertexCollection(Application.StartupPath + "..\\DBs\\LocationDB.xml");
            edgeDB = new EdgeCollection(Application.StartupPath + "..\\DBs\\Edge.xml");
            theGraph = new Graph(db, edgeDB);

            //Path testPath = theGraph.DijkstraPath(4, 13);
            Path testPath = theGraph.DijkstraPath(10, 4);
            testRoute = new Route();
            testRoute.PathToRoute(testPath, theGraph);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}


