using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace DSAA_Project3
{
    public abstract class GraphElem { }

    public class Vertex : GraphElem
    {
        public string code;
        public string name;
        public string engName;
        public string intro;
        public string type;
        public PictureBox picDot;

        public Vertex() { }
        public Vertex(string newName, string newEngName)
        {
            name = newName;
            engName = newEngName;
        }

        public bool Equals(Vertex target)
        {
            return (code == target.code);
        }
    }

    public class VertexCollection
    {
        public List<Vertex> locList;

        public VertexCollection()
        {
            locList = new List<Vertex>();
        }

        public VertexCollection(string path)
        {
            locList = new List<Vertex>();
            initVertexList(path);
        }

        public void initVertexList(string path)
        {
            XmlDocument VertexCollection = new XmlDocument();
            try
            {
                VertexCollection.Load(path);
            }
            catch (System.IO.FileNotFoundException)
            {
                throw;
            }

            XmlNode rootNode = VertexCollection.SelectSingleNode("Locations");
            XmlNodeList nodeList = rootNode.ChildNodes;

            foreach (XmlNode item in nodeList)
            {
                Vertex nowVertex = new Vertex();
                XmlElement nowElement = (XmlElement)item;

                nowVertex.code = nowElement.SelectSingleNode("Code").InnerText;
                nowVertex.name = nowElement.SelectSingleNode("Name").InnerText;
                nowVertex.engName = nowElement.SelectSingleNode("EngName").InnerText;
                nowVertex.intro = nowElement.SelectSingleNode("Intro").InnerText;
                nowVertex.type = nowElement.GetAttribute("Type").ToString();

                locList.Add(nowVertex);
            }
        }
    }

    public class Edge : GraphElem
    {
        public string id;
        public bool isDir;
        public Vertex v1;
        public Vertex v2;
        public int len;
        public PictureBox picEdge;

        public Edge()
        {
            id = "";
            isDir = false;
            len = 100000;
        }
    }

    public class EdgeCollection
    {
        public List<Edge> edgeList = new List<Edge>();

        public EdgeCollection() { }
        public EdgeCollection(string path)
        {
            XmlDocument VertexCollection = new XmlDocument();
            try
            {
                VertexCollection.Load(path);
            }
            catch (System.IO.FileNotFoundException)
            {
                throw;
            }

            XmlNode rootNode = VertexCollection.SelectSingleNode("GraphEdgeCollection");
            XmlNodeList nodeList = rootNode.ChildNodes;

            foreach (XmlNode item in nodeList)
            {
                Edge nowEdge = new Edge();
                XmlElement nowElement = (XmlElement)item;

                nowEdge.id = nowElement.GetAttribute("id").ToString();
                nowEdge.v1 = Program.db.locList.Find(delegate (Vertex l) { return l.code == (nowElement.GetAttribute("v1")); });
                nowEdge.v2 = Program.db.locList.Find(delegate (Vertex l) { return l.code == (nowElement.GetAttribute("v2")); });
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
        public VertexCollection vtxCollection;
        public EdgeCollection egdCollection;
        public int[,] adjMat; 

        public Graph() { }

        public Graph(VertexCollection vc, EdgeCollection ec)
        {
            vtxCollection = vc;
            egdCollection = ec;
            adjMat = new int[vc.locList.Count, vc.locList.Count];

            for (int i = 0; i < vc.locList.Count; i++)
            {
                for (int j = 0; j < vc.locList.Count; j++) { adjMat[i, j] = 0; }
            }

            this.genAdjMat();
        }

        public void genAdjMat()
        {
            foreach (Edge item in egdCollection.edgeList)
            {
                adjMat[(vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == item.v1; })), 
                    (vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == item.v2; }))] = item.len;
                if (item.isDir == false)
                {
                    adjMat[(vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == item.v2; })), 
                        (vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == item.v1; }))] = item.len;
                }
            }
        }
    }

}
