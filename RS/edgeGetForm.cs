using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS
{
    public partial class edgeGetForm : Form
    {
        public edgeGetForm()
        {
            InitializeComponent();
        }
        bool isAdded;
        List<Skill> skillList;
        public int start
        {
            get
            {
                return st;
            }
        }
        public int end
        {
            get
            {
                return ed;
            }
        }
        int st, ed;
        public void getEdge(List<Skill> _skillList,bool _isAdded)
        {
            skillList = _skillList;
            From.Items.Clear();
            To.Items.Clear();
            From.Text = "";
            To.Text = "";
            isAdded = _isAdded;
            foreach (Skill currSkill in skillList)
            {
                From.Items.Add(currSkill.name);
                if (isAdded)
                {
                    To.Items.Add(currSkill.name); ;
                }
            }
            this.ShowDialog(); 
        }
        private int getId(string _name)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                if (skillList[i].name == _name)
                {
                    return i;
                }
            }
            return -1;
        }
        private void OK_Click(object sender, EventArgs e)
        {
            st = From.SelectedIndex;
            if(st!=-1)
                ed = getId(To.SelectedItem.ToString());
            Close();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            st = ed = -1;
            Close();
        }

        private void From_SelectedIndexChanged(object sender, EventArgs e)
        {
           To.Items.Clear();
           List<int> tail = skillList[From.SelectedIndex].getTail;
           for(int i=0;i<skillList.Count;i++){
               if(tail.Contains(i) != isAdded){
                   To.Items.Add(skillList[i].name);
               }
           }
        }
    }
}
