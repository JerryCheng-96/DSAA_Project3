using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DSAA_Project3
{
    public class Loc
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
}
