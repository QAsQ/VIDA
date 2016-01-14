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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const int maxn = 7;
            Skill[] skill_list=new Skill[maxn];
            for(int i=0;i<maxn;i++){
                skill_list[i] = new Skill(i.ToString(),maxn);
                skill_list[i].isLearn = i <= maxn / 2;
            }
            MainRV.circleR = 40;
            MainRV.ShowRelation(skill_list);
        }
    }
}