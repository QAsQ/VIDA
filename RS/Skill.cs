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
            isLearn = false;    
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
                return tail;
            }
        }
        public string name;
        List<int> succ;  //前驱
        private List<int> tail; //后继    
        public bool isLearn;
    }
}
