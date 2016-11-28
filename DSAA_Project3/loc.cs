using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSAA_Project3
{
    public class loc
    {
        public string code;
        public string name;
        public string engName;
        public string intro;
        public string type;
        public string imgAdd;

        public loc() { }
        public loc(string newName, string newEngName)
        {
            name = newName;
            engName = newEngName;
        }

        public bool Equals(loc target)
        {
            return (code == target.code);
        }
    }
}
