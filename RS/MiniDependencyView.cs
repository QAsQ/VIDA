using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS
{
    public partial class MiniDependencyView : DependencyView
    {
        public MiniDependencyView()
        {
            InitializeComponent();
            exampleInit();
        }
        public void exampleInit()
        {
            string[] name = new string[4] { "已经学习", "可以学习", "不能学习", "不能学习" };
            PointF[] local = new PointF[4] {new PointF(87,306),
                                            new PointF(146,116),
                                            new PointF(464,64),
                                            new PointF(368,303)};
            for (int i = 0; i < 4; i++)
            {
                skillList.Add(new Skill(name[i]));
                circleCenter.Add(local[i]);
            }
            skillList[0].addTail(1);
            skillList[1].addTail(2);
            skillList[0].addTail(3);
            skillList[1].addTail(3);
            skillList[2].addTail(3);
            drawModeList.Add(SkillDrawMode.Hs);
            drawModeList.Add(SkillDrawMode.Cs);
            drawModeList.Add(SkillDrawMode.Us);
            drawModeList.Add(SkillDrawMode.Us);
        }
    }
}
