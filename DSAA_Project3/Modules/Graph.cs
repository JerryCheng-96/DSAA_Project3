using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace DSAA_Project3
{
    public abstract class GraphElem
    {
        public enum eType { Vertex, Edge };       
        public eType elemType;
    }

    public class Vertex : GraphElem
    {
        public string code;
        public string name;
        public string engName;
        public string intro;
        public string type;
        public PictureBox picDot;

        public Vertex()
        {
            elemType = eType.Vertex;
        }

        public Vertex(string newName, string newEngName)
        {
            name = newName;
            engName = newEngName;
            elemType = eType.Vertex;
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
            
            elemType = eType.Edge;
            len = Graph.INFF;
        }

        public Edge(Edge ori, bool isReverse = false)
        {
            id = ori.id;
            isDir = ori.isDir;
            len = ori.len;
            picEdge = ori.picEdge;
            elemType = eType.Edge;

            if (isReverse)
            {
                v1 = ori.v2;
                v2 = ori.v1;
            }
            else
            {
                v1 = ori.v1;
                v2 = ori.v2;
            }
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

        public Edge FindEdge(Vertex v1, Vertex v2)
        {
            Edge nowEdge = edgeList.Find(delegate (Edge e1) { return (v1.Equals(e1.v1) && v2.Equals(e1.v2)); });
            if (nowEdge != null)
            {
                return nowEdge;
            }
            else
            {
                nowEdge = edgeList.Find(delegate (Edge e2) { return (v1.Equals(e2.v2) && v2.Equals(e2.v1)); });
                return new Edge(nowEdge, true);
            }
        }
    }

    public class Route
    {
        public enum posOfLoc { Pass, Start, End };
        public List<GraphElem> elemList;
        public int numVtx = 0;
        public int dist = 0;

        public Route()
        {
            elemList = new List<GraphElem>();
        }

        public bool addElem(GraphElem ge)
        {
            if (elemList.Count != 0)
            {
                if (elemList[elemList.Count - 1].elemType == ge.elemType) { return false; }                
            }
            elemList.Add(ge);
            return true;
        }

        public void PathToRoute(Path path, Graph graph)
        {
            if (path == null || graph == null)
            {
                return;
            }
            Queue<int> vtxIndexQueue = new Queue<int>();
            int nowVtxIndex = -1;
            int nextVtxIndex = -1;
            foreach (int vtx in path.vtxPath)
            {
                vtxIndexQueue.Enqueue(vtx);
            }

            if (path.vtxPath.Count != 1)
            {
                nowVtxIndex = vtxIndexQueue.Dequeue();
                nextVtxIndex = vtxIndexQueue.Peek();
                elemList.Add(graph.vtxCollection.locList[nowVtxIndex]);
                while (vtxIndexQueue.Count != 0)
                {
                    elemList.Add(graph.egdCollection.FindEdge(graph.vtxCollection.locList[nowVtxIndex], graph.vtxCollection.locList[nextVtxIndex]));
                    elemList.Add(graph.vtxCollection.locList[nextVtxIndex]);
                    nowVtxIndex = vtxIndexQueue.Dequeue();
                    if (vtxIndexQueue.Count != 0)
                    {
                        nextVtxIndex = vtxIndexQueue.Peek();
                    }
                }
            }
            else
            {
                elemList.Add(graph.vtxCollection.locList[vtxIndexQueue.Dequeue()]);
            }
            numVtx = path.vtxPath.Count;
            dist = path.length;
        }
    }

    public class Path
    {
        public List<int> vtxPath;
        public int length;

        public Path()
        {
            vtxPath = new List<int>();
            length = 0;
        }

        public Path(int initIndex)
        {
            vtxPath = new List<int>();
            length = 0;
            vtxPath.Add(initIndex);
        }

        public Path(Path oriPath)
        {
            vtxPath = new List<int>();
            length = 0;
            this.Copy(oriPath);
        }

        public Path(Path oriPath, int nextIndex, int secWeight)
        {
            vtxPath = new List<int>();
            length = 0;
            this.Copy(oriPath);
            this.AddVertex(nextIndex, secWeight);
        }

        public void Copy(Path oriPath)
        {
            foreach (int vtx in oriPath.vtxPath)
            {
                vtxPath.Add(vtx);
            }
            length = oriPath.length;
        }

        public void AddVertex(int vtxIndex, int secWeight)
        {
            vtxPath.Add(vtxIndex);
            length += secWeight;
        }
    }

    public class Graph
    {
        public VertexCollection vtxCollection;
        public EdgeCollection egdCollection;
        public int[,] adjMat;
        public const int INFF = 100000;

        public Graph() { }

        public Graph(VertexCollection vc, EdgeCollection ec)
        {
            vtxCollection = vc;
            egdCollection = ec;
            adjMat = new int[vc.locList.Count, vc.locList.Count];

            for (int i = 0; i < vc.locList.Count; i++)
            {
                for (int j = 0; j < vc.locList.Count; j++) { adjMat[i, j] = INFF; }
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

        public Route routeFromTo(Vertex start, Vertex end)
        {
            return null;
        }

        public Path DijkstraPath(Vertex start, Vertex end)
        {
            if (start == null || end == null)
            {
                return null;
            }
            return DijkstraPath(vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == start; }),
                vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == end; }));
        }

        public Path DijkstraPath(int startIndex, int endIndex)
        {
            List<int> vtxRemain = new List<int>();
            for (int i = 0; i < vtxCollection.locList.Count; i++)
            {
                vtxRemain.Add(i);
            }

            List<Path> pathList = new List<Path>();
            pathList.Add(new Path(startIndex));
            if (startIndex == endIndex)
            {
                return pathList[0];
            }

            int nowFront = startIndex;
            int nowMinLen = INFF;
            Path nowMinPath = pathList[0];

            vtxRemain.Remove(nowFront);

            do
            {
                foreach (int vtxIndex in vtxRemain)
                {
                    if (nowMinPath.length + adjMat[nowFront, vtxIndex] < INFF)
                    {
                        pathList.Add(new Path(nowMinPath, vtxIndex, adjMat[nowFront, vtxIndex]));
                    }
                }
                pathList.Remove(nowMinPath);
                nowMinPath = null;
                nowMinLen = INFF;
                foreach (Path nowPath in pathList)
                {
                    if (nowPath.length < nowMinLen)
                    {
                        nowMinPath = nowPath;
                        nowMinLen = nowPath.length;
                    }
                }
                if (nowMinLen >= INFF)
                {
                    return null;
                }
                nowFront = nowMinPath.vtxPath[nowMinPath.vtxPath.Count - 1];
                vtxRemain.Remove(nowFront);
            } while (nowFront != endIndex);
            return nowMinPath;
        }
    }
}
