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
            Font = Color.Empty;
            SkillEdge = Color.Empty;
            SkillFill = Color.Empty;
            ArrowFill = Color.Empty;
            ArrowEdge = Color.Empty;
            ArrowFill = Color.Empty;
        }
        public DrawStyle(Color Font, Color SkillFill, Color SkillEdge,Color ArrowLine,Color ArrowEdge,Color ArrowFill)
        {
            initFromColor(Font, SkillFill, SkillEdge,ArrowLine,ArrowEdge,ArrowFill);
        }
        public DrawStyle(string Font, string SkillFill, string SkillEdge,string ArrowLine,string ArrowEdge,string ArrowFill)
        {
            initFromString(Font, SkillFill, SkillEdge,ArrowLine,ArrowEdge,ArrowFill);
        }
        public const int length = 6;
        public Color Font;
        public Color SkillFill;
        public Color SkillEdge;
        public Color ArrowLine;
        public Color ArrowEdge;
        public Color ArrowFill;
        public void initFromColor(Color font, Color skillFill, Color skillEdge,Color arrowLine,Color arrowEdge,Color arrowFill)
        {
            Font = font;
            SkillFill = skillFill;
            SkillEdge = skillEdge;
            ArrowLine = arrowLine;
            ArrowEdge = arrowEdge;
            ArrowFill = arrowFill;
        }
        Color stringToColor(string col)
        {
            return ColorTranslator.FromHtml(col);
        }
        public void initFromString(string font, string skillFill, string skillEdge,string arrowLine,string arrowEdge,string arrowFill)
        {
            SkillEdge = stringToColor(skillEdge);
            SkillFill = stringToColor(skillFill);
            Font = stringToColor(font);
            ArrowLine = stringToColor(arrowLine);
            ArrowEdge = stringToColor(arrowEdge);
            ArrowFill = stringToColor(arrowFill);
        }

        public string[] getStringList()
        {
            string[] value = new string[length];
            value[0] = ColorTranslator.ToHtml(Font);
            value[1] = ColorTranslator.ToHtml(SkillFill);
            value[2] = ColorTranslator.ToHtml(SkillEdge);
            value[3] = ColorTranslator.ToHtml(ArrowLine);
            value[4] = ColorTranslator.ToHtml(ArrowEdge);
            value[5] = ColorTranslator.ToHtml(ArrowFill);
            return value;
        }
    }
}
