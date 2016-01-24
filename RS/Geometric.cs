using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RS
{
    static class Geometric
    {
        static public int Distance(Point st, Point ed)
        {
            int dx = st.X - ed.X;
            int dy = st.Y - ed.Y;
            int ans = dx * dx + dy * dy;
            return (int)Math.Sqrt((double)ans);
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
                return ;
            poi.X *= Zoomin; poi.Y *= Zoomin;
            poi.X /= Zoomout; poi.Y /= Zoomout;
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
        
        public static Point Rotate(Point anchor, PointF b, PointF a, PointF old)
        {
            // b:before a:after
            b -= (Size)anchor;
            old -= (Size)anchor;
            a -= (Size)anchor;
            float zou = -(b.X * b.X + b.Y * b.Y);
            float cos = -b.Y * old.Y - old.X * b.X;
            float sin = b.Y * old.X - old.Y * b.X;
            cos /= zou;
            sin /= zou;
            float rx = cos * a.X - sin * a.Y;
            float ry = cos * a.X + sin * a.Y;
            PointF ret = new PointF(rx,ry);
            float ro = LengthF(ret);
            float ri = LengthF(old);
            scale(ref ret, ri, ro);
            ret += (Size)anchor; 
            return new Point((int)ret.X,(int)ret.Y);
        }

        private static void scale(ref Point Poi, double zi, double zo)
        {
            double x = Poi.X * zi / zo;
            double y = Poi.Y * zi / zo;
            Poi.X = (int)x;
            Poi.Y = (int)y;
        }
    }
}
