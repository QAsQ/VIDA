using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS
{
    public partial class DependencyView : UserControl
    {
        public DependencyView()
        {
            InitializeComponent();
            selectedId_drag = selectedId_None;
            anchorExist = false;
            circleR = 50;
            font_name = new Font(fontName, size_font);
        }
        protected ColorScheme colorScheme = new ColorScheme();
        protected bool BackspaceIsDown;
        protected bool MouseLeftButtonIsDown; 
        protected  List<PointF> circleCenter = new List<PointF>();
        protected List<Skill> skillList = new List<Skill>();
        protected List<bool> isLearnList = new List<bool>();
        protected List<SkillDrawMode> drawModeList = new List<SkillDrawMode>();
        protected enum SkillDrawMode
        {
            Hs, // Had study
            Cs, //Can sdudy
            Us  //Unable study
        };
        public ColorScheme Scheme
        {
            get
            {
                return colorScheme;
            }
            set
            {
                colorScheme = value;
            }
        }
        private double circleR;
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
        Graphics formGraphis;
        int size_font = 30;
        const int minCircleSize = 10;
        const int maxCircleSize = 1000000;
        const int lineW = 2;
        private Graphics buffer;
        protected Size getNameSize(string name)
        {
            return formGraphis.MeasureString(name, font_name).ToSize();
        }
        protected Font font_name;
        string fontName = "微软雅黑";
        private void drawSkill(PointF _center, Skill curr_skill, DrawStyle curr_style)
        {
            Point center = Point.Round(_center);
            int r = size_circle;
            int stx = center.X - r, sty = center.Y - r;
            int d = r * 2;
            Rectangle rect = new Rectangle(stx, sty, d, d);
            if (curr_style.SkillEdge.IsEmpty == false)
            {
                Pen edgePen;
                edgePen = new Pen(curr_style.SkillEdge);
                edgePen.Width = lineW;
                buffer.DrawEllipse(edgePen, rect);
            }
            if (curr_style.SkillFill.IsEmpty == false)
            {
                Brush fillBush = new SolidBrush(curr_style.SkillFill);
                buffer.FillEllipse(fillBush, rect);
            }
            Brush fontbush;
            fontbush = new SolidBrush(curr_style.Font);

            Point fontSize = (Point)getNameSize(curr_skill.name);
            Point DrawStringPoint = center;
            Geom.scale(ref fontSize, 1, 2);
            DrawStringPoint -= (Size)fontSize;
            buffer.DrawString(curr_skill.name, font_name, fontbush, DrawStringPoint);
        }

        private void DependencyView_Load(object sender, EventArgs e)
        {
            formGraphis = CreateGraphics();
        }
        private void DrawArrow(PointF _st, PointF _ed, DrawStyle start)
        {
            Point st = Point.Round(_st);
            Point ed = Point.Round(_ed);
            int length = Geom.Distance(st, ed);
            if (length <= size_circle * 2)
                return;
            Point[] pointList = Geom.getArrowHead(st, ed, size_circle);
            Geom.scaleLine(ref st, ref ed, size_circle);
            if (start.ArrowLine.IsEmpty == false)
            {
                Pen edPen = new Pen(start.ArrowLine);
                edPen.Width = lineW;
                buffer.DrawLine(edPen, st, pointList[0]);
            }
            DrawArrow(pointList, start);
        }
        private void DrawArrow(Point[] PointList, DrawStyle currStyle)
        {
            if (currStyle.ArrowFill.IsEmpty == false)
            {
                Brush fillBush = new SolidBrush(currStyle.ArrowFill);
                buffer.FillPolygon(fillBush, PointList);
            }
            if (currStyle.ArrowEdge.IsEmpty == false)
            {
                Pen edgePen = new Pen(currStyle.ArrowEdge);
                edgePen.Width = lineW;
                buffer.DrawPolygon(edgePen, PointList);
            }
        }
        DrawStyle getFillSytle(SkillDrawMode curr)
        {
            switch (curr)
            {
                case SkillDrawMode.Hs:
                    return colorScheme.Hs;
                case SkillDrawMode.Cs:
                    return colorScheme.Cs;
                case SkillDrawMode.Us:
                    return colorScheme.Us;
                default:
                    return colorScheme.Hs;
            }
        }
        Bitmap BUF;
        private void redraw_all()
        {
            try
            {
                 BUF = new Bitmap(this.Width, this.Height);
            }
            catch(Exception ex){
                GC.Collect();
                return;
            }
            buffer = Graphics.FromImage(BUF);
            buffer.Clear(colorScheme.BackGround);
            for (int i = skillList.Count - 1; i >= 0; i--)
            {
                List<int> currTail = skillList[i].getTail;
                for (int j = currTail.Count - 1; j >= 0; j--)
                {
                    int end = currTail[j];
                    DrawArrow(circleCenter[i], circleCenter[end],
                              getFillSytle(drawModeList[i]));
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
            try
            {
                formGraphis.DrawImage(BUF, 0, 0);
            }
            catch (OutOfMemoryException ex)
            {
                GC.Collect();
            }
        }
        int size_anchor = 5;
        private void drawAnchor(Point center, int r, Graphics aimer)
        {
            Rectangle rect = new Rectangle(center.X - r, center.Y - r, r * 2, r * 2);
            aimer.DrawLine(new Pen(color_anchor), center.X - r * 3 / 2, center.Y, center.X + r * 3 / 2, center.Y);
            aimer.DrawLine(new Pen(color_anchor), center.X, center.Y - r * 3 / 2, center.X, center.Y + r * 3 / 2);
            aimer.DrawEllipse(new Pen(color_anchor), rect);
        }
        Point Anchors;
        bool anchorExist;
        Color color_anchor = Color.SlateGray;
        public void Flash()
        {
            redraw_all();
        }
        void scaleOther(int Zoomin, int Zoomout)
        {
            circleR *= Zoomin;
            circleR /= Zoomout;
            size_font = size_circle * 5 / 8;
            if (size_font <= 0)
                size_font = 1;
            font_name = new Font(fontName, size_font);
        }
        private Point locate_mouse;
        private void DependencyView_MouseMove(object sender, MouseEventArgs e)
        {
            if (anchorExist == true && selectedId_drag == selectedId_None && MouseLeftButtonIsDown)
            {
                if (Geom.Distance(e.Location, Anchors) > size_anchor)
                    moveAllCenter(Anchors, rotateMouseLocate, e.Location);
            }
            if (selectedId_drag != selectedId_None && MouseLeftButtonIsDown)
            {
                Point offset = locate_mouse - (Size)e.Location;
                circleCenter[selectedId_drag] -= (Size)offset;
            }
            if (BackspaceIsDown == true && MouseLeftButtonIsDown)
            {
                Point deviaion;
                deviaion = locate_mouse - (Size)e.Location;
                deviaion = moveAllSkill(deviaion);
            }
            rotateMouseLocate = e.Location;
            locate_mouse = e.Location;
            Flash();
        }
        private void moveAllCenter(Point Anchor, Point before, Point after)
        {
            float zo = Geom.LengthF(before - (Size)Anchor);
            float zi = Geom.LengthF(after - (Size)Anchor);
            spinAllCenter(Anchor, before, after);
            if ((size_circle > minCircleSize || zo < zi) && (size_circle < maxCircleSize || zo > zi))
            {
                scaleAllCenter(Anchor, before, after);
            }
        }
        private void spinAllCenter(Point Anchor, Point before, Point after)
        {
            for (int i = 0; i < circleCenter.Count; i++)
                circleCenter[i] = Geom.Rotate(Anchor, before, after, circleCenter[i]);
        }
        private void scaleAllCenter(Point Anchor, Point before, Point after)
        {
            Point anc = Anchor;
            int zo = Geom.Length(before - (Size)Anchor);
            int zi = Geom.Length(after - (Size)Anchor);
            scaleOther(zi, zo);
            for (int i = 0; i < circleCenter.Count; i++)
            {
                circleCenter[i] = Geom.scale(circleCenter[i], zi, zo);
            }
            anc = Geom.scale(anc, zi, zo);
            anc -= (Size)Anchor;
            panAllCircle(anc);
        }
        private void panAllCircle(Point anc)
        {
            for (int i = 0; i < circleCenter.Count; i++)
                circleCenter[i] -= (Size)anc;
        }

        private void DependencyView_KeyDown(object sender, KeyEventArgs e)
        {
            changeKeyState(e.KeyCode, true);
        }

        private void DependencyView_KeyUp(object sender, KeyEventArgs e)
        {
            changeKeyState(e.KeyCode, false);
        }
        private void changeKeyState(Keys k, bool isDown)
        {
            switch (k)
            {
                case Keys.Space:
                    BackspaceIsDown = isDown;
                    if (anchorExist && MouseLeftButtonIsDown)
                    {
                        anchorExist = false;
                    }
                    break;
            }
        }
        int getArrowPioner(Point locate)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                var currTail = skillList[i].getTail;
                foreach (int ed in currTail)
                {
                    if (Geom.pointInArrowHand(locate, Geom.getArrowHead(circleCenter[i], circleCenter[ed], size_circle)))
                        return i;
                }
            }
            return selectedId_None;
        }
        protected const int selectedId_None = -1;
        int selectedId_drag;

        private Point moveAllSkill(Point deviaion)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                circleCenter[i] = circleCenter[i] - (Size)deviaion;
            }
            return deviaion;
        }
        Point spaceMouseLocate;
        Point rotateMouseLocate;
        private void DependencyView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = true;
                locate_mouse = e.Location;
                selectedId_drag = get_circleID(e.Location);
                rotateMouseLocate = e.Location;
                if (anchorExist)
                {
                    rotateMouseLocate = e.Location;
                }
                if (BackspaceIsDown)
                {
                    spaceMouseLocate = e.Location;
                    anchorExist = false;
                }
            }
        }
        protected int get_circleID(Point lotated)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                if (Geom.DistanceF(lotated, circleCenter[i]) <= size_circle)
                {
                    return i;
                }
            }
            return selectedId_None;
        }
        private void DependencyView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = false;
                selectedId_drag = selectedId_None;
                spaceMouseLocate.X = spaceMouseLocate.Y = 0;
            }
        }

        private void DependencyView_SizeChanged(object sender, EventArgs e)
        {
            formGraphis = this.CreateGraphics();
            Flash();
        }

        private void DependencyView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedId_ArrowPoiner = getArrowPioner(e.Location);
            Point aim = new Point(Width / 2, Height / 2);
            if (selectedId_ArrowPoiner != selectedId_None)
            {
                Point dis = Point.Round(circleCenter[selectedId_ArrowPoiner]) - (Size)aim;
                if (dis.X == 0 && dis.Y == 0)
                {
                    dis.X = dis.Y = 2;
                }
                moveAllSkill(dis);
            }
            Flash();
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
    }
}
