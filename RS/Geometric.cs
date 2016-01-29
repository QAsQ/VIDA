using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RS
{
    static class Geom
    {
        static public int Distance(Point st, Point ed)
        {
            int dx = st.X - ed.X;
            int dy = st.Y - ed.Y;
            int ans = dx * dx + dy * dy;
            return (int)Math.Sqrt((double)ans);
        }
        static public float DistanceF(PointF st, PointF ed)
        {
            float dx = st.X - ed.X;
            float dy = st.Y - ed.Y;
            float ans = dx * dx + dy * dy;
            return (float)Math.Sqrt((double)ans);
        }
        static int xmult(Point p1, Point p2, Point p)
        {
            p1 -= (Size)p;
            p2 -= (Size)p;
            return p1.X * p2.Y - p2.X * p1.Y;
        }
        static public int Length(Point p)
        {
            return Distance(new Point(0, 0), p);
        }
        static public float LengthF(PointF p)
        {
            return (float)Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }
        static public void scale(ref Point poi, int Zoomin, int Zoomout)
        {
            if (Zoomout == 0)
                return;
            poi.X *= Zoomin; poi.Y *= Zoomin;
            poi.X /= Zoomout; poi.Y /= Zoomout;
        }
        static public Point scale(Point poi, int Zoomin, int Zoomout)
        {
            if (Zoomout == 0)
                return poi;
            poi.X *= Zoomin; poi.Y *= Zoomin;
            poi.X /= Zoomout; poi.Y /= Zoomout;
            return poi;
        }
        static public void scale(ref PointF poi, float Zoomin, float Zoomout)
        {
            if (Zoomout == 0)
                return;
            poi.X *= Zoomin; poi.Y *= Zoomin;
            poi.X /= Zoomout; poi.Y /= Zoomout;
        }
        static public PointF scale(PointF poi, float Zoomin, float Zoomout)
        {
            if (Zoomout == 0)
                return poi;
            poi.X *= Zoomin; poi.Y *= Zoomin;
            poi.X /= Zoomout; poi.Y /= Zoomout;
            return poi;
        }
        public static bool pointInArrowHand(Point locate, Point[] pointList)
        {
            Point center = pointList[1] + (Size)pointList[3];
            scale(ref center, 1, 2);
            for (int i = 0; i < pointList.Length; i++)
            {
                if (xmult(pointList[i],locate,pointList[(i+1)%pointList.Length])
                    *xmult(pointList[i],center,pointList[(i+1)%pointList.Length])< 0)
                    return false;
            }
            return true;
        }
        
        public static PointF Rotate(Point anchor, PointF b, PointF a, PointF old)
        {
            // b:before a:after
            b -= (Size)anchor;
            old -= (Size)anchor;
            a -= (Size)anchor;

            float zi = LengthF(a);
            float zo = LengthF(b);
            scale(ref b, zi, zo);
            zi = LengthF(a);
            zo = LengthF(b);

            float zou = -b.Y * b.Y - b.X * b.X;
            float sin = a.X * b.Y - b.X * a.Y;
            float cos = -b.Y * a.Y - b.X * a.X;
            sin /= zou;
            cos /= zou;
            float x = -old.Y * sin + old.X * cos;
            float y = old.X * sin + old.Y * cos;
            PointF ret = new PointF(x,y);
            zo = LengthF(ret);
            zi = LengthF(old);
            scale(ref ret, zi, zo);
            return  ret+(Size)anchor;
        }
        public static void scaleLine(ref Point st, ref Point ed,int size_circle)
        {
            Point vR = ed - (Size)st;  // 从圆心到圆周的向量
            int length = Geom.Distance(st, ed);
            Geom.scale(ref vR, size_circle, length);
            st += (Size)vR;
            ed -= (Size)vR;
        }
        public static Point[] getArrowHead(PointF _st, PointF _ed, int size_circle)
        {
            Point st = Point.Round(_st);
            Point ed = Point.Round(_ed);
            scaleLine(ref st,ref ed,size_circle);
            Point Vst_ed = ed - (Size)st; // 向量 
            int LengthV = Distance(new Point(0, 0), Vst_ed);
            scale(ref Vst_ed, 5, 8);
            if (LengthV * 5 > size_circle * 16)
            {
                scale(ref Vst_ed, size_circle * 16, LengthV * 5);
            }
            var nst = ed - (Size)Vst_ed;   // new start
            Point mid = ed - (Size)nst;
            scale(ref mid, 5, 8);
            mid = ed - (Size)mid;
            scale(ref Vst_ed, 5, 8);
            var perp = new Point(Vst_ed.Y, -Vst_ed.X);
            scale(ref perp, 3, 8);
            int LengthPerp = Geom.Distance(new Point(0, 0), perp);
            LengthPerp = LengthPerp * 8 / 5;
            if (LengthPerp * 8 < size_circle * 5 && LengthPerp * 5 > size_circle * 8)
            {
                Geom.scale(ref perp, size_circle, LengthPerp);
            }
            var top = mid + (Size)perp;
            var button = mid - (Size)perp;
            return new Point[]{nst,top,ed,button};
        }
    }
}
