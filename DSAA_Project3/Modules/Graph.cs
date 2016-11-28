using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace DSAA_Project3
{
    public abstract class GraphElem { }

    public class Loc : GraphElem
    {
        public string code;
        public string name;
        public string engName;
        public string intro;
        public string type;
        public PictureBox picDot;

        public Loc() { }
        public Loc(string newName, string newEngName)
        {
            name = newName;
            engName = newEngName;
        }

        public bool Equals(Loc target)
        {
            return (code == target.code);
        }
    }

    public class locDB
    {
        public List<Loc> locList;

        public locDB()
        {
            locList = new List<Loc>();
        }

        public locDB(string path)
        {
            locList = new List<Loc>();
            initLocList(path);
        }

        public void initLocList(string path)
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

            XmlNode rootNode = locDB.SelectSingleNode("Locations");
            XmlNodeList nodeList = rootNode.ChildNodes;

            foreach (XmlNode item in nodeList)
            {
                Loc nowLoc = new Loc();
                XmlElement nowElement = (XmlElement)item;

                nowLoc.code = nowElement.SelectSingleNode("Code").InnerText;
                nowLoc.name = nowElement.SelectSingleNode("Name").InnerText;
                nowLoc.engName = nowElement.SelectSingleNode("EngName").InnerText;
                nowLoc.intro = nowElement.SelectSingleNode("Intro").InnerText;
                nowLoc.type = nowElement.GetAttribute("Type").ToString();

                locList.Add(nowLoc);
            }
        }
    }

    public class Edge: GraphElem
    {
        public string id;
        public bool isDir;
        public Loc v1;
        public Loc v2;
        public int len;
        public PictureBox picEdge;

        public Edge()
        {
            id = "";
            isDir = false;
            len = 100000;
        }
    }

    public class Edges
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

    public class Route
    {
        public List<GraphElem> elemList;

        public Route()
        {
            elemList = new List<GraphElem>();
        }

        public void addElem(GraphElem ge)
        {
            if (elemList.Count != 0)
            {
                if (elemList[elemList.Count - 1].GetType() == ge.GetType()) { return; }                
            }
            elemList.Add(ge);
        }
    }

    public class Graph
    {
        public locDB vtxCollection;
        public Edges
    }

}
