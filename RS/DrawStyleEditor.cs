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
    public partial class DrawStyleEditor : UserControl
    {
        public DrawStyleEditor()
        {
            InitializeComponent();
            FontCV.nonempty();
            SkillFillCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            SkillEdgeCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            FontCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            ArrowFillCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            ArrowEdgeCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            ArrowLineCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            SkillFillCV.Texts = "填充";
            SkillEdgeCV.Texts = "描边";
            FontCV.Texts = "字色";
        }
        public delegate void DrawStyleChangeHandler(object sender);
        public event DrawStyleChangeHandler userChange;
        public DrawStyle drawStyle
        {
            get
            {
                return new DrawStyle(FontCV.color, SkillFillCV.color, SkillEdgeCV.color,
                                    ArrowLineCV.color,ArrowEdgeCV.color,ArrowFillCV.color);
            }
            set
            {
                SkillEdgeCV.init(value.SkillEdge);
                SkillFillCV.init(value.SkillFill);
                FontCV.init(value.Font);
                ArrowLineCV.init(value.ArrowLine);
                ArrowFillCV.init(value.ArrowFill);
                ArrowEdgeCV.init(value.ArrowEdge);
            }
        }
        void userChageDrawStyle(object sender)
        {
            userChange(sender);
        }
    }
}
