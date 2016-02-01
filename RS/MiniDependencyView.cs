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
            string[] name = new string[4] { "V", "I", "D", "A" };
            PointF[] local = new PointF[4] {new PointF(63,118),
                                            new PointF(158,57),
                                            new PointF(320,106),
                                            new PointF(225,16)};
            for (int i = 0; i < 4; i++)
            {
                skillList.Add(new Skill(name[i]));
                circleCenter.Add(local[i]);
            }
            skillList[0].addTail(1);
            skillList[1].addTail(2);
            skillList[1].addTail(3);
            skillList[2].addTail(3);
            drawModeList.Add(SkillDrawMode.Hs);
            drawModeList.Add(SkillDrawMode.Cs);
            drawModeList.Add(SkillDrawMode.Us);
            drawModeList.Add(SkillDrawMode.Us);
            size_circle = 22;
        }
    }
}
