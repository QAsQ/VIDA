using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace RS
{
    class FillStyle
    {
        public bool edge;
        public bool fill;
        public Color edgeColor;
        public Color fillColor;
        public void EdgeClear()
        {
            edge = false;
        }
        public void EdgeInit(Color color)
        {
            edge = true;
            edgeColor = color;
        }
        public void FillClear(){
            fill = false;
        }
        public void FillInit(Color color)
        {
            fill = true;
            fillColor = color;
        }
        public void init(Color Edge, Color Fill)
        {
            EdgeInit(Edge);
            FillInit(Fill);
        }
    }
}
