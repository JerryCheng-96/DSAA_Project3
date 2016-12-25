/*
 * College of Life Science, SCU
 * Cheng, Haoyang
 * 2015141244003
 * 
 * Core code implementing the Graph related matters, Dijkstra Algorithm for the shortest path included.
 * For the 3rd project of the Course "Data Structures and Algorithm Analysis",
 * "The Digital Map of Jiang'an Campus"
 * 
 */

using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace DSAA_Project3
{
    public abstract class GraphElem     // The parent class for all the graph elements: vertex and edge
    {
        public enum eType { Vertex, Edge };          // An enum of symbolizing the exact type
        public eType elemType;                       // The variable for the enum
    }

    public class Vertex : GraphElem     // The class for vertices
    {
        public string code;             // The code (key value) for the vertex
        public string name;             // The name of the place
        public string engName;          // The English name 
        public string intro;            // The introduction to the place
        public string type;             // The category of the place
        public PictureBox picDot;       // The PictureBox pointing the place, used in GUI

        public Vertex()                 // Default construction function
        {
            elemType = eType.Vertex;    // Set the type to Vertex
        }

        public Vertex(string newName, string newEngName)    // Construction func. #2
        {
            name = newName;
            engName = newEngName;
            elemType = eType.Vertex;
        }

        public bool Equals(Vertex target)       // Overriding the Equals() by default
        {
            return (code == target.code);       // Two vertices equal if they have the same code
        }
    }

    public class VertexCollection               // The collection for the Vertices
    {
        public List<Vertex> locList;            // The list storing the Vertices
            
        public VertexCollection()               // Default constructor
        {
            locList = new List<Vertex>();       // Initializing the list of Vertices
        }

        public VertexCollection(string xml)     // Construct the list from a .xml
        {
            locList = new List<Vertex>();       
            initVertexList(xml);                
        }

        public void initVertexList(string xml)  // Fill a vertices list from a .xml
        {
            XmlDocument VertexCollection = new XmlDocument();   // Initializing the XmlDocument object

            try
            {
                VertexCollection.Load(new System.IO.StringReader(xml));     // Load the .xml File
            }
            catch (System.IO.FileNotFoundException)     // If file not found
            {
                throw;
            }

            XmlNode rootNode = VertexCollection.SelectSingleNode("Locations");      // Filling the data from the .xml to the instances of Vertices
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

                locList.Add(nowVertex);     // Add the new vertex to the list
            }
        }
    }

    public class Edge : GraphElem           // The class for the edges
    {
        public string id;                   // The id (key value) of the edge
        public bool isDir;                  // Whether the edge is with a direction
        public Vertex v1;                   // Vertex on the one end
        public Vertex v2;                   // Vertex on the other end
        public int len;                     // The length (weight) of the edge
        public PictureBox picEdge;          // The PictureBox for the edge, used in GUI

        public Edge()                       // Default constructor
        {
            id = "";
            isDir = false;
            
            elemType = eType.Edge;
            len = Graph.INFF;               // Set the length to infinity by default
        }

        public Edge(Edge ori, bool isReverse = false)      // Contructing another Edge object from an existing edge. If isReverse == true, the v1 and v2 would be exchanged.
        {
            id = ori.id;                    // Copying the information from the original edge
            isDir = ori.isDir;
            len = ori.len;
            picEdge = ori.picEdge;
            elemType = eType.Edge;

            if (isReverse)                  // Reversing v1 and v2 if necessary
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

    public class EdgeCollection             // The collection for the Edges
    {
        public List<Edge> edgeList = new List<Edge>();      // The list for the edges

        public EdgeCollection() { }         // Default constructor
        public EdgeCollection(string xml)       // Constructing from a .xml
        {
            XmlDocument VertexCollection = new XmlDocument();   
            try
            {
                VertexCollection.Load(new System.IO.StringReader(xml));     // Load the .xml document
            }
            catch (System.IO.FileNotFoundException)
            {
                throw;
            }

            XmlNode rootNode = VertexCollection.SelectSingleNode("GraphEdgeCollection");        // Reading the data from the .xml
            XmlNodeList nodeList = rootNode.ChildNodes;

            foreach (XmlNode item in nodeList)
            {
                Edge nowEdge = new Edge();
                XmlElement nowElement = (XmlElement)item;

                nowEdge.id = nowElement.GetAttribute("id").ToString();
                nowEdge.v1 = Program.db.locList.Find(delegate (Vertex l) { return l.code == (nowElement.GetAttribute("v1")); });        // Matching the vertex's key to the object
                nowEdge.v2 = Program.db.locList.Find(delegate (Vertex l) { return l.code == (nowElement.GetAttribute("v2")); });
                nowEdge.len = int.Parse(nowElement.GetAttribute("len"));

                edgeList.Add(nowEdge);      // Adding the edge
            }
        }

        public Edge FindEdge(Vertex v1, Vertex v2)      // Finding the edge with the given vertices. Return the Edge object with the right direction.
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

    public class Route      // The class for Route, a structure for V-E-V-E-...-V order.
    {
        public enum posOfLoc { Pass, Start, End };      // Identify the position of a vertex on the route
        public List<GraphElem> elemList;                // The list for the Route
        public int numVtx = 0;                          // The number of the vertices
        public int dist = 0;                            // The total length of the Route

        public Route()                                  // Constructor
        {
            elemList = new List<GraphElem>();           // Initializing the list
        }

        public bool addElem(GraphElem ge)               // Adding a element to the Route. Keeping the V-E-V-E-...-V pattern
        {
            if (elemList.Count != 0)
            {
                if (elemList[elemList.Count - 1].elemType == ge.elemType) { return false; }                
            }
            elemList.Add(ge);
            return true;
        }

        public void PathToRoute(Path path, Graph graph)         // Turning a Path into a Route, finding the edges between the vertices
        {
            if (path == null || graph == null)                  // Proceed only when the parameters are legal
            {
                return;
            }
            Queue<int> vtxIndexQueue = new Queue<int>();        // Using a Queue to store the incoming vertices.
            int nowVtxIndex = -1;                               // The index for the present and next element
            int nextVtxIndex = -1;
            foreach (int vtx in path.vtxPath)
            {
                vtxIndexQueue.Enqueue(vtx);                     // Enqueuing all the vertices in the path
            }

            if (path.vtxPath.Count != 1)                        // If not only one vertex in the path
            {
                nowVtxIndex = vtxIndexQueue.Dequeue();          // Get the index of the present vertex
                nextVtxIndex = vtxIndexQueue.Peek();            // Get the index of the next vertex
                elemList.Add(graph.vtxCollection.locList[nowVtxIndex]);     // First add the present vertex to the Route
                while (vtxIndexQueue.Count != 0)
                {
                    elemList.Add(graph.egdCollection.FindEdge(graph.vtxCollection.locList[nowVtxIndex], graph.vtxCollection.locList[nextVtxIndex]));    // Add the Edge between the two vertices
                    elemList.Add(graph.vtxCollection.locList[nextVtxIndex]);        // Add the next Vertex
                    nowVtxIndex = vtxIndexQueue.Dequeue();
                    if (vtxIndexQueue.Count != 0)
                    {
                        nextVtxIndex = vtxIndexQueue.Peek();            // Stop if no more vertices in the Path
                    }
                }
            }
            else
            {
                elemList.Add(graph.vtxCollection.locList[vtxIndexQueue.Dequeue()]); // If only one vertex in the path
            }
            numVtx = path.vtxPath.Count;        // Update parameters for the Route
            dist = path.length;
        }
    }

    public class Path           // The class for the Path, V-V-V-...-V pattern
    {
        public List<int> vtxPath;   // The list for the indices of the vertices
        public int length;          // The length of the path

        public Path()       // Constructor
        {
            vtxPath = new List<int>();  // Initializing
            length = 0;
        }

        public Path(int initIndex)      // Constructor taking the first Vertex as input
        {
            vtxPath = new List<int>();
            length = 0;
            vtxPath.Add(initIndex);     // Add the first Vertex
        }

        public Path(Path oriPath)       // Contructor copying another path
        {
            vtxPath = new List<int>();
            length = 0;
            this.Copy(oriPath);
        }

        public Path(Path oriPath, int nextIndex, int secWeight)     // Constructor that copies a Path and add a vertex to it
        {
            vtxPath = new List<int>();
            length = 0;
            this.Copy(oriPath);
            this.AddVertex(nextIndex, secWeight);
        }

        public void Copy(Path oriPath)      // Copy a Path
        {
            foreach (int vtx in oriPath.vtxPath)        // Copy the indices one by one
            {
                vtxPath.Add(vtx);
            }
            length = oriPath.length;                    // Update the length
        }

        public void AddVertex(int vtxIndex, int secWeight)      // Adding a Vertex to a Path
        {
            vtxPath.Add(vtxIndex);
            length += secWeight;        // Update the length
        }
    }

    public class Graph      // The class for Graph
    {
        public VertexCollection vtxCollection;      // A Graph consists of a collection of the vertices
        public EdgeCollection egdCollection;        // and a collection of the edges
        public int[,] adjMat;                       // The adjacent matrix for the Graph
        public const int INFF = 100000;             // Defining infinity as a very large number, larger than the longest possible path in the Graph

        public Graph() { }      // Default Constructor

        public Graph(VertexCollection vc, EdgeCollection ec)  // Constructor taking both of the collections
        {
            vtxCollection = vc;
            egdCollection = ec;
            adjMat = new int[vc.locList.Count, vc.locList.Count];

            for (int i = 0; i < vc.locList.Count; i++)
            {
                for (int j = 0; j < vc.locList.Count; j++) { adjMat[i, j] = INFF; }         // Initializing the elements in the AdjMat to inf
            }

            this.genAdjMat();       // Generating the AdjMat
        }

        public void genAdjMat()     // The function generating a adjacent matrix from an Edge collection, for directionless and directional graphs
        {
            foreach (Edge item in egdCollection.edgeList)       // Traversing all the edges
            {
                adjMat[(vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == item.v1; })), 
                    (vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == item.v2; }))] = item.len;    // Setting the value at properiate position as the length of the edge
                if (item.isDir == false)        // Whether the Edge is of direction
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

        public Path DijkstraPath(Vertex start, Vertex end)      // Dijkstra taking two Vertex as input. Calling the one taking int as inputs.
        {
            if (start == null || end == null)       // Input valid?
            {
                return null;
            }
            return DijkstraPath(vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == start; }),
                vtxCollection.locList.FindIndex(delegate (Vertex v) { return v == end; }));
        }

        public Path DijkstraPath(int startIndex, int endIndex)      // Dijkstra Algorithm. Finding the shortest path between two vertices whose indices are StartIndex and endIndex
        {
            List<int> vtxRemain = new List<int>();          // The indices of the vertices that hasn't been transferred into the shortest length
            for (int i = 0; i < vtxCollection.locList.Count; i++)
            {
                vtxRemain.Add(i);       // Putting all the vertices into the vixRemain
            }

            List<Path> pathList = new List<Path>();     // The list for all the possible paths found started at startIndex
            pathList.Add(new Path(startIndex));         // Add the path started with startIndex
            if (startIndex == endIndex)                 // The path starts and ends at the same station
            {
                return pathList[0];                     // Return the path with only the vertex
            }

            int nowFront = startIndex;                  // The index of the ending vertex of the farthest shortest path
            int nowMinLen = INFF;                       // The length for the current shortest path
            Path nowMinPath = pathList[0];              // The shortest path

            vtxRemain.Remove(nowFront);                 // 

            do
            {
                foreach (int vtxIndex in vtxRemain)     // Traversing all the vertices in the vixRemain
                {
                    if (nowMinPath.length + adjMat[nowFront, vtxIndex] < INFF)      // If from the nowFront vertex we can arrive at the present vertex
                    {
                        pathList.Add(new Path(nowMinPath, vtxIndex, adjMat[nowFront, vtxIndex]));   // Add the path to the list
                    }
                }
                pathList.Remove(nowMinPath);        // Removing the 'previous' shortest path
                nowMinPath = null;                  // Putting the values to the default
                nowMinLen = INFF;
                foreach (Path nowPath in pathList)      //  Updating the current longest path
                {
                    if (nowPath.length < nowMinLen)
                    {
                        nowMinPath = nowPath;
                        nowMinLen = nowPath.length;
                    }
                }
                if (nowMinLen >= INFF)      // The two vertices are not connected, return null
                {
                    return null;
                }
                nowFront = nowMinPath.vtxPath[nowMinPath.vtxPath.Count - 1];    // Updating the nowFront
                vtxRemain.Remove(nowFront);     // Removing the nowFront in the vtxRemain
            } while (nowFront != endIndex);     // When we haven't reached the destination
            return nowMinPath;                  // Return our findings
        }
    }
}
