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
            UpdateMinRVFormLocate();
        }
        Point FrameOffset = new Point(9,30);
        private void button1_Click(object sender, EventArgs e)
        {
            const int maxn = 5;
            Skill[] skill_list = new Skill[maxn];
            skill_list[0] = new Skill("数学分析");
            skill_list[0].addTail(2);
            skill_list[1] = new Skill("高等代数");
            skill_list[1].addTail(2);
            skill_list[2] = new Skill("常微分方程");
            skill_list[3] = new Skill("C++");
            skill_list[3].addTail(4);
            skill_list[4] = new Skill("C#");
      
            MainRV.circleR = 30;
            MainRV.ShowRelation(skill_list);
        }

        private void mainForm_LocationChanged(object sender, EventArgs e)
        {
            UpdateMinRVFormLocate();
        }

        private void UpdateMinRVFormLocate()
        {
            MainRV.FormLocate = this.Location;
            MainRV.FormLocate.Offset(FrameOffset);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainRV.TeacherMode();
        }

        private void sut_Click(object sender, EventArgs e)
        {
            MainRV.StudentMode();
        }
    }
}