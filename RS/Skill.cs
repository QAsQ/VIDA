using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS
{
    public class Skill
    {
        public Skill(string _name)
        {
            name = _name;
            tail = new List<int>();
        }
        public void addTail(int ID)
        {
            tail.Add(ID);
        }
        public List<int> getTail
        {
            get
            {
                return tail;
            }
        }
        public string name;
        List<int> succ;  //后继
        private List<int> tail; //前驱
        public bool isLearn;
    }
}
