using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSAA_Project3
{
    internal class locDB
    {
        public List<loc> locList;
        
        public locDB()
        {
            locList = new List<loc>();
        }

        public locDB(string path)
        {
            locList = new List<loc>();
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
                loc nowLoc = new loc();
                XmlElement nowElement = (XmlElement)item;

                nowLoc.code = nowElement.SelectSingleNode("Code").InnerText;
                nowLoc.name = nowElement.SelectSingleNode("Name").InnerText;
                nowLoc.engName = nowElement.SelectSingleNode("EngName").InnerText;
                nowLoc.intro = nowElement.SelectSingleNode("Intro").InnerText;
                nowLoc.imgAdd = nowElement.SelectSingleNode("ImgAdd").InnerText;
                nowLoc.type = nowElement.GetAttribute("Type").ToString();

                locList.Add(nowLoc);
            }
        }
    }
}
