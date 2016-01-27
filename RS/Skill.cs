using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RS
{
    public class Skill
    {
        public Skill(string _name)
        {
            name = _name;
            tail = new List<int>();
        }
        public Skill()
        {
            // TODO: Complete member initialization

            tail = new List<int>();
        }   
        public void addTail(int ID)
        {
            tail.Add(ID);
        }
        public void removeTail(int ID)
        {
            tail.Remove(ID);
        }
        public List<int> getTail
        {
            get
            {
                return new List<int>(tail);
            }
        }
        public string name;
       // List<int> succ;  //前驱
        private List<int> tail; //后继 
        private string taiString()
        {
            string tailString = "";
            foreach (int i in tail)
            {
                tailString += i.ToString() + " ";
            }
            return tailString;
        }
        public void removeIDAndSub(int ID)
        {
            removeTail(ID);
            for (int i = 0; i < tail.Count; i++)
            {
                if (tail[i] > ID)
                {
                    tail[i]--;
                }
            }
        }
        override public string ToString()
        {
            string ret = name;
            ret += "," + tail.Count.ToString();
            ret += "," + taiString();
            return ret;
        }
        static public explicit operator Skill(string _val)
        {
            string[] val = _val.Split(',');
            Skill ret = new Skill();
            ret.name = val[0];
            string[] tails = val[2].Split(' ');
            foreach (string id in tails)
            {
                if (id != "")
                {
                    ret.addTail(Convert.ToInt32(id));
                }
            }
            return ret;
        }
    }
}
