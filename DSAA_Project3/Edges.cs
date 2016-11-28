using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSAA_Project3
{
    class Edges
    {
        public List<Edge> edgeList = new List<Edge>();

        public Edges() { }
        public Edges(string path)
        {
            XmlDocument locDB = new XmlDocument();
            try
            {
                locDB.Load(path);
            }
            catch (System.IO.FileNotFoundException)
            {
                throw;
            }

            XmlNode rootNode = locDB.SelectSingleNode("GraphEdges");
            XmlNodeList nodeList = rootNode.ChildNodes;

            foreach (XmlNode item in nodeList)
            {
                Edge nowEdge = new Edge();
                XmlElement nowElement = (XmlElement)item;

                nowEdge.id = nowElement.GetAttribute("id").ToString();
                nowEdge.v1 = Program.db.locList.Find(delegate (Loc l) { return l.code == (nowElement.GetAttribute("v1")); });
                nowEdge.v2 = Program.db.locList.Find(delegate (Loc l) { return l.code == (nowElement.GetAttribute("v2")); });
                nowEdge.len = int.Parse(nowElement.GetAttribute("len"));

                edgeList.Add(nowEdge);
            }
        }
    }

    class Edge
    {
        public string id;
        public Loc v1;
        public Loc v2;
        public int len;

        public Edge()
        {
            id = "";
            len = 100000;
        }
    }
}
