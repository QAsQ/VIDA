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
    public partial class DependencyView : UserControl
    {
        public DependencyView()
        {
            InitializeComponent();
        }
        protected bool BackspaceIsDown;
        protected bool MouseLeftButtonIsDown; 
        protected  List<PointF> circleCenter = new List<PointF>();
        protected List<Skill> skillList = new List<Skill>();
        protected List<bool> isLearnList = new List<bool>();
        protected List<SkillDrawMode> drawModeList = new List<SkillDrawMode>();
        protected enum SkillDrawMode
        {
            Hs, // Had study
            Cs, //Can sdudy
            Us  //Unable study
        };
        protected  FillStyle[] fs = new FillStyle[3];
        protected Color color_background;


    }
}
