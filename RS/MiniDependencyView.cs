﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RS;

namespace MiniRS
{
    public partial class MiniDependencyView : UserControl
    {
        bool BackspaceIsDown;
        bool MouseLeftButtonIsDown;
        string fontName = "微软雅黑";
        public MiniDependencyView()
        {
            InitializeComponent();
            initSkill();
        }

        private void initSkill()
        {
            skillList.Clear();
            skillList.Add(new Skill("V"));
            skillList.Add(new Skill("I"));
            skillList.Add(new Skill("D"));
            skillList.Add(new Skill("A"));
            skillList[0].addTail(1);
            skillList[1].addTail(2);
            skillList[2].addTail(3);
            circleCenter.Add(new PointF(115, 254));
            circleCenter.Add(new PointF(312, 97));
            circleCenter.Add(new PointF(684, 171));
            circleCenter.Add(new PointF(485, 328));
            drawModeList.Add(SkillDrawMode.Hs);
            drawModeList.Add(SkillDrawMode.Cs);
            drawModeList.Add(SkillDrawMode.Us);
            drawModeList.Add(SkillDrawMode.Us);
        }  
        Graphics formGraphis;
        enum SkillDrawMode
        {
            Hs, // Had study
            Cs, //Can sdudy
            Us  //Unable study
        };
        FillStyle Hs = new FillStyle(ColorTranslator.FromHtml("#aba5a2")
                                    , ColorTranslator.FromHtml("#aaaaa2")
                                    , ColorTranslator.FromHtml("#7d7d64"));
        FillStyle Cs = new FillStyle(ColorTranslator.FromHtml("#43c1ca")
                                    , ColorTranslator.FromHtml("#c7d2d3")
                                    , ColorTranslator.FromHtml("#90bbbe"));
        FillStyle Us = new FillStyle(ColorTranslator.FromHtml("#894a60")
                                    , ColorTranslator.FromHtml("#c66a8a")
                                    , ColorTranslator.FromHtml("#552334"));
        public Color color_background = ColorTranslator.FromHtml("#1e7a92");
        public Color color_anchor = Color.DarkGray;
        const int lineW = 3;
        double circleR;
        public int size_circle
        {
            get
            {
                return (int)circleR;
            }
            set
            {
                if (value < minCircleSize)
                    circleR = minCircleSize;
                circleR = value;
                size_font = size_circle * 5 / 8;
                font_name = new Font(fontName, size_font);
            }
        }
        const int selectedId_None = -1;
        int size_font = 30;
        int selectedId_drag; 
        Font font_name ;
        private Graphics buffer;
        private Point locate_mouse;
        private List<PointF> circleCenter = new List<PointF>();
        private List<Skill> skillList = new List<Skill>();
        private List<SkillDrawMode> drawModeList = new List<SkillDrawMode>();
        private void drawSkill(PointF _center, Skill curr_skill, FillStyle curr_style)
        {
            Point center = Point.Round(_center);
            int r = size_circle;
            int stx = center.X - r,sty = center.Y - r;
            int d = r * 2;
            Rectangle rect = new Rectangle(stx, sty, d, d);
            if (curr_style.edge.IsEmpty == false)
            {
                Pen edgePen;
                edgePen = new Pen(curr_style.edge);
                edgePen.Width = lineW;
                buffer.DrawEllipse(edgePen,rect);
            }
            if (curr_style.fill.IsEmpty == false)
            {
                Brush fillBush = new SolidBrush(curr_style.fill);
                buffer.FillEllipse(fillBush, rect);
            }
            Brush fontbush;
            fontbush = new SolidBrush(curr_style.font);

            Point fontSize = (Point)getNameSize(curr_skill.name);
            Point DrawStringPoint = center;
            Geometric.scale(ref fontSize, 1, 2);
            DrawStringPoint -= (Size)fontSize;
            buffer.DrawString(curr_skill.name, font_name, fontbush, DrawStringPoint);
        }
        private Size getNameSize(string name)
        {
            return formGraphis.MeasureString(name, font_name).ToSize();
        }
        FillStyle getFillSytle(SkillDrawMode curr)
        {
            switch (curr)
            {
                case SkillDrawMode.Cs:
                    return Cs;
                case SkillDrawMode.Hs:
                    return Hs;
                case SkillDrawMode.Us:
                    return Us;
                default:
                    return Cs;
            }
        }
        private void DrawArrow(PointF _st, PointF _ed, FillStyle start,FillStyle end)
        {
            Point st = Point.Round(_st);
            Point ed = Point.Round(_ed);
            int length = Geometric.Distance(st, ed);
            if (length <= size_circle * 2)
                return;
            Pen edPen = new Pen(end.fill);
            edPen.Width = lineW;
            Point[] pointList = getArrowHead(st,ed);
            scaleLine(ref st,ref ed);
            buffer.DrawLine(edPen, st, pointList[0]);
            DrawArrow(pointList, start);
        }
        private void scaleLine(ref Point st,ref Point ed){
            Point vR = ed - (Size)st;  // 从圆心到圆周的向量
            int length = Geometric.Distance(st, ed);
            Geometric.scale(ref vR, size_circle, length);
            st += (Size)vR;
            ed -= (Size)vR;
        }
        private Point[] getArrowHead(PointF _st,PointF _ed)
        {
            Point st = Point.Round(_st);
            Point ed = Point.Round(_ed);
            scaleLine(ref st,ref ed);
            Point Vst_ed = ed - (Size)st; // 向量 
            int LengthV = Geometric.Distance(new Point(0, 0), Vst_ed);
            Geometric.scale(ref Vst_ed, 5, 8);
            if (LengthV * 5 > size_circle * 16)
            {
                Geometric.scale(ref Vst_ed, size_circle * 16, LengthV * 5);
            }
            var nst = ed - (Size)Vst_ed;   // new start
            Point mid = ed - (Size)nst;
            Geometric.scale(ref mid, 5, 8);
            mid = ed - (Size)mid;
            Geometric.scale(ref Vst_ed, 5, 8);
            var perp = new Point(Vst_ed.Y, -Vst_ed.X);
            Geometric.scale(ref perp, 3, 8);
            int LengthPerp = Geometric.Distance(new Point(0, 0), perp);
            LengthPerp = LengthPerp * 8 / 5;
            if (LengthPerp * 8 < size_circle * 5 && LengthPerp * 5 > size_circle * 8)
            {
                Geometric.scale(ref perp, size_circle, LengthPerp);
            }
            var top = mid + (Size)perp;
            var button = mid - (Size)perp;
            return new Point[]{nst,top,ed,button};
        }
        private void DrawArrow(Point[] PointList, FillStyle currStyle)
        {
            if (currStyle.fill.IsEmpty==false)
            {
                Brush fillBush = new SolidBrush(currStyle.fill);
                buffer.FillPolygon(fillBush, PointList);
            }
            if (currStyle.edge.IsEmpty==false)
            {
                Pen edgePen = new Pen(currStyle.edge);
                edgePen.Width = lineW;
                buffer.DrawPolygon(edgePen, PointList);
            }
        }
        private void redraw_all()
        {
            Bitmap BUF = new Bitmap(this.Width, this.Height);
            buffer = Graphics.FromImage(BUF);
            buffer.Clear(color_background);
            for (int i = skillList.Count - 1; i >= 0; i--)
            {
                List<int> currTail = skillList[i].getTail;
                for (int j = currTail.Count - 1; j >= 0; j--)
                {
                    int end = currTail[j];
                    DrawArrow(circleCenter[i], circleCenter[end],
                              getFillSytle(drawModeList[i]), 
                              getFillSytle(drawModeList[end]));
                }
            }
            for (int i = skillList.Count - 1; i >= 0; i--)
            {
                drawSkill(circleCenter[i], skillList[i], getFillSytle(drawModeList[i]));
            }
          //  drawAncher(new Point(Width/2,Height/2),5);
            if (anchorExist)
            {
                drawAnchor(Anchors, size_anchor, buffer);
            }
            formGraphis.DrawImage(BUF, 0, 0);
            GC.Collect();
        }
        private void drawAnchor(Point center, int r ,Graphics aimer)
        {
            Rectangle rect = new Rectangle(center.X - r, center.Y - r, r * 2, r * 2);
            aimer.DrawLine(new Pen(color_anchor), center.X - r * 3 / 2, center.Y, center.X + r * 3 / 2, center.Y);
            aimer.DrawLine(new Pen(color_anchor), center.X, center.Y - r * 3 / 2, center.X, center.Y + r * 3 / 2);
            aimer.DrawEllipse(new Pen(color_anchor), rect);
        }
        private int get_circleID(Point lotated)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                if (Geometric.DistanceF(lotated, circleCenter[i]) <= size_circle)
                {
                    return i;
                }
            }
            return selectedId_None;
        }
        private void RelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (anchorExist == false)
                {
                    anchorExist = true;
                    Anchors = e.Location;
                    drawAnchor(Anchors, 5, formGraphis);
                }
                else
                {
                    anchorExist = false;
                    redraw_all();
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = true;
                locate_mouse = e.Location;
                selectedId_drag = get_circleID(e.Location);
                spaceMouseLocate = e.Location;
                rotateMouseLocate = e.Location;
            }
            if (anchorExist)
                rotateMouseLocate = e.Location;
        }
        void scaleOther(int Zoomin,int Zoomout){
            circleR *= Zoomin;
            circleR /= Zoomout;
            size_font = size_circle * 5 / 8;
            if (size_font <= 0)
                size_font = 1;
            font_name = new Font (fontName, size_font);
        }
        Point spaceMouseLocate;
        Point rotateMouseLocate;
        private void RelationView_MouseMove(object sender, MouseEventArgs e)
        {
            if (anchorExist == true && selectedId_drag == selectedId_None && MouseLeftButtonIsDown)
            {
                if(Geometric.Distance(e.Location,Anchors) > size_anchor)
                   moveAllCenter(Anchors, rotateMouseLocate, e.Location);
                rotateMouseLocate = e.Location;
                Flash();
            }
            if (selectedId_drag != selectedId_None && MouseLeftButtonIsDown)
            {
                Point offset = locate_mouse - (Size)e.Location;
                locate_mouse = e.Location;
                circleCenter[selectedId_drag] -= (Size)offset;
                redraw_all();
            }
            if (BackspaceIsDown == true && MouseLeftButtonIsDown)
            {
                Point deviaion;
                deviaion = locate_mouse - (Size)e.Location;
                locate_mouse = e.Location;
                deviaion = moveAllSkill(deviaion);
                redraw_all();
            }
        }

        private void moveAllCenter(Point Anchor, Point before, Point after)
        {
            float zo = Geometric.LengthF(before - (Size)Anchor);
            float zi = Geometric.LengthF(after - (Size)Anchor);
            spinAllCenter(Anchor, before, after);
            if (size_circle > minCircleSize || zo < zi)
            {
                scaleAllCenter(Anchor, before, after);
            }
        }

        private void spinAllCenter(Point Anchor, Point before, Point after)
        {
            for (int i = 0; i < circleCenter.Count; i++)
                circleCenter[i] = Geometric.Rotate(Anchor, before, after, circleCenter[i]);
        }

        private void scaleAllCenter(Point Anchor, Point before, Point after)
        {
            Point anc = Anchor;
            int zo = Geometric.Length(before - (Size)Anchor);
            int zi = Geometric.Length(after - (Size)Anchor);
            scaleOther(zi,zo);
            for (int i = 0; i < circleCenter.Count; i++)
            {
                circleCenter[i] = Geometric.scale(circleCenter[i], zi, zo);
            }
            anc = Geometric.scale(anc, zi, zo);
            anc -= (Size)Anchor;
            panAllCircle(anc);
        }

        private void panAllCircle(Point anc)
        {
            for (int i = 0; i < circleCenter.Count; i++)
                circleCenter[i] -= (Size)anc;
        }
        private Point moveAllSkill(Point deviaion)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                circleCenter[i] = circleCenter[i] - (Size)deviaion;
            }
            return deviaion;
        }
        private void RelationView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = false;
                selectedId_drag = selectedId_None;
                spaceMouseLocate.X = spaceMouseLocate.Y = 0;
            }
        }
        private void RelationView_Load(object sender, EventArgs e)
        {
            font_name = new Font(fontName, size_font);
            ButtonStateInit();
            selectedId_drag = selectedId_None;
            formGraphis = CreateGraphics();
            circleR = 50;
            anchorExist = false;
        }

        private void ButtonStateInit()
        {
            MouseLeftButtonIsDown = false;
            BackspaceIsDown = false;
        }
        public List<Skill> getAllSkill
        {
            get
            {
                return skillList;
            }
        }
        Point Anchors;
        bool anchorExist;
        const int minCircleSize = 10;
        int size_anchor = 5;
        public void Flash()
        {
            redraw_all();
        }
        public List<PointF> PointList
        {
            get
            {
                return circleCenter;
            }
        }
        int getArrowPioner(Point locate)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                var currTail = skillList[i].getTail;
                foreach (int ed in currTail)
                {
                    if (Geometric.pointInArrowHand(locate, getArrowHead(circleCenter[i], circleCenter[ed])))
                        return i;
                }
            }                                                 
            return selectedId_None;
        }

        private void MiniDependencyView_SizeChanged(object sender, EventArgs e)
        {
            formGraphis = CreateGraphics();
            Flash();
        }

        private void MiniDependencyView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                BackspaceIsDown = true;
        }

        private void MiniDependencyView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                BackspaceIsDown = false;
        }
    }
}