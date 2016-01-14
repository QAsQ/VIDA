using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS
{
    public class Skill
    {
        public Skill(string _name, int len)
        {
            name = _name;
            tril = new bool[len];
            for(int i=0;i<len;i++)
                tril[i] = false;
        }
        public string name;
        public int[] succ;  //后继
        public bool[] tril; //前驱
        public bool isLearn;
    }
}
