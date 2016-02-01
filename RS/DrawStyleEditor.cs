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
            FillCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            EdgeCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            FontCV.userChange += new ColorView.ColorChangeHandler(userChageDrawStyle);
            FillCV.Texts = "填充";
            EdgeCV.Texts = "描边";
            FontCV.Texts = "字色";
        }
        public delegate void DrawStyleChangeHandler(object sender);
        public event DrawStyleChangeHandler userChange;
        public DrawStyle drawStyle
        {
            get
            {
                return new DrawStyle(EdgeCV.color, FillCV.color, FontCV.color);
                return new DrawStyle();
            }
            set
            {
                EdgeCV.init(value.edge);
                FillCV.init(value.fill);
                FontCV.init(value.font);
            }
        }
        void userChageDrawStyle(object sender)
        {
            userChange(sender);
        }
    }
}
