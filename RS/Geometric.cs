﻿using System;
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
        public static Point Rotate(Point anchor, Point before, Point after, Point old)
        {
            //wait updat;
            return after;
        }
    }
}
