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
        public Color BackGround
        {
            get
            {
                return bg;
            }
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
            for (int i = 0; i < 3; i++)
            {
                ds[i] = new DrawStyle(lists[i * 3 + 1], lists[i * 3 + 2], lists[i * 3 + 3]);
            }
        }
        public string[] toStringList()
        {
            // todo upadte
            string[] lists = new string[10];
            return lists;
        }

    }
}
