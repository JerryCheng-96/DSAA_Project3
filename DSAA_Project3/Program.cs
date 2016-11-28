using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAA_Project3
{
    static class Program
    {
        public static locDB db;
        public static Edges edgeDB;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            db = new locDB(Application.StartupPath + "\\LocationDB.xml");
            edgeDB = new Edges(Application.StartupPath + "\\Edge.xml");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static void readLocDB()
        {
            ;
        }
    }
}


