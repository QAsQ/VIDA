using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace RS
{
    public class ColorScheme
    {
        public ColorScheme()
        {
            bg = BackGround;
            ds[0] = ds[1] = ds[2] = new DrawStyle();
        }
        public ColorScheme(ColorScheme _scheme)
        {
            this._scheme = _scheme;
            ds = _scheme.ds;
            this.bg= _scheme.BackGround;
        }
        public const int Size = DrawStyle.length * 3 + 1;
        DrawStyle []ds = new DrawStyle[3];
        public DrawStyle Us
        {
            get
            {
                return ds[2];
            }
        }
        public DrawStyle Cs
        {
            get
            {
                return ds[1];
            }
        }
        public DrawStyle Hs
        {
            get
            {
                return ds[0];
            }
        }
        Color bg;
        private ColorScheme _scheme;
        public Color BackGround
        {
            get
            {
                return bg;
            }
        }
        public void loadBackGround(Color backGround)
        {
            bg = backGround;
        }
        public void loadByIndex(int index, DrawStyle inp)
        {
            ds[index] = inp;
        }
        public DrawStyle putByIndex(int index)
        {
            return ds[index];
        }
        public void initInString(string[] lists)
        {
            bg = ColorTranslator.FromHtml(lists[0]);
            int DSlength = DrawStyle.length;
            for (int i = 0; i < 3; i++)
            {
                ds[i] = new DrawStyle(lists[i * DSlength + 1]
                                    ,lists[i * DSlength + 2]
                                    ,lists[i * DSlength + 3]
                                    ,lists[i * DSlength + 4]
                                    ,lists[i * DSlength + 5]
                                    ,lists[i * DSlength + 6]);
            }
        }
        public string[] toStringList()
        {
            List<string> lists = new List<string>();
            lists.Add(ColorTranslator.ToHtml(bg));
            for (int i = 0; i < 3; i++)
            {
                var temp = ds[i].getStringList();
                for (int j = 0; j < temp.Length; j++)
                {
                    lists.Add(temp[j]);
                }
            }
            return lists.ToArray();
        }
        
    }
}
