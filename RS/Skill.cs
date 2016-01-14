using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        public Skill(SqlDataReader reader)
        {
            tail = new List<int>();
            name = (string)reader.GetValue(1);
            int len = (int)reader.GetValue(2);
            if (len != 0)
            {
                string input = (string)reader.GetValue(3);
                string[] inputTail = input.Split(' ');
                foreach (string num in inputTail)
                {
                    if (num != "")
                    {
                        addTail(Convert.ToInt32(num));
                    }
                }
            }
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
