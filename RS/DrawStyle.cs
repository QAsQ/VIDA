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
        public DrawStyle()
        {
            font = Color.Empty;
            edge = Color.Empty;
            fill = Color.Empty;
        }
        public DrawStyle(Color Edge, Color Fill,Color Font)
        {
            initFromColor(Edge, Fill,Font);
        }
        public DrawStyle(string Edge, string Fill, string Font)
        {
            initFromString(Edge, Fill, Font);
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
        public void initFromColor(Color Edge, Color Fill,Color Font)
        {
            EdgeInit(Edge);
            FillInit(Fill);
            FontInit(Font);
        }
        Color stringToColor(string col)
        {
            return ColorTranslator.FromHtml(col);
        }
        public void initFromString(string Edge, string Fill, string Font)
        {
            edge = stringToColor(Edge);
            fill = stringToColor(Fill);
            font = stringToColor(Font);
        }
    }
}
