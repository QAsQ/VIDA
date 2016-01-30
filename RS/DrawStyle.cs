using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace RS
{
    public class DrawStyle
    {
        public DrawStyle(Color Edge, Color Fill,Color Font)
        {
            init(Edge, Fill,Font);
        }
        public Color font;
        public Color edge;
        public Color fill;
        public void EdgeClear()
        {
            edge = Color.Empty;
        }
        public void EdgeInit(Color color)
        {
            edge = color;
        }
        public void FillClear(){
            fill = Color.Empty;
        }
        public void FillInit(Color color)
        {
            fill = color;
        }
        public void FontInit(Color color)
        {
            font = color;
        }
        public void init(Color Edge, Color Fill,Color Font)
        {
            EdgeInit(Edge);
            FillInit(Fill);
            FontInit(Font);
        }
    }
}
