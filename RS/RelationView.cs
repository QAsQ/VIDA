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
    public partial class RelationView : UserControl
    {
        public RelationView()
        {
            InitializeComponent();
        }
        public void ShowRelation(Skill[] _skillList)
        {
            skillList = _skillList;
            skill_size = skillList.Length;
            circle_center = new Point[skill_size];
            for (int i = 0; i < skill_size; i++)
                circle_center[i] = StartCenter;
            edge = new int[skill_size, skill_size];
            for (int i = 0; i < skill_size; i++)
                for (int j = 0; j < i; j++)
                    edge[i, j] = 1;
            redraw_all();
        }
        public void addEdge(int x, int y)
        {
            edge_Change(x, y, 1);
        }
        public void delEdge(int x, int y)
        {
            edge_Change(x, y, 0);
        }
        public Color circlePen_color = Color.SkyBlue;
        public Color circleBrush_color = Color.SkyBlue;
        public Color font_color = Color.Black;
        public Color line_color = Color.Black;
        public Color backgroundColor = Color.AliceBlue;
        Point StartCenter = new Point(80, 90);
        public int circleR
        {
            set
            {
                if (inBound(value, maxR))
                    circle_R = value;
            }
            get
            {
                return circle_R;
            }
        }
        public int circleSize
        {
            set
            {
                if (inBound(value, maxSize))
                {
                    skill_size = value;
                }
            }
            get
            {
                return skill_size;
            }
        }
        private void edge_Change(int x, int y, int property)
        {
            if (inBound(x, skill_size) == false || inBound(y, skill_size) == false)
                return;
            edge[x, y] = edge[y, x] = property;
        }
        const int maxSize = 300;
        const int maxR = 500;

        private bool inBound(int value, int bound)
        {
            return value >= 0 && value < bound;
        }
        private Skill[] skillList;
        private int circle_R = 50;
        private int skill_size = 5;
        const int noSkill_move = -1;
        int skillId_selected;
        int[,] edge;
        private Graphics g;
        private Point mouse_locate;
        private Point[] circle_center;
        private void drawSkill(Point center, Skill curr_skill)
        {
            int r = circle_R;
            Pen p = new Pen(circlePen_color);
            Brush bush = new SolidBrush(circleBrush_color);
            int stx = center.X - r;
            int sty = center.Y - r;
            int d = r * 2;
            Rectangle rect = new Rectangle(stx, sty, d, d);
            if (curr_skill.isLearn)
                g.FillEllipse(bush, rect);
            else
                g.DrawEllipse(p, rect);
            Font Font = new Font("Arial", 30);
            Brush fontbush;
            if (curr_skill.isLearn)
                fontbush = new SolidBrush(backgroundColor);
            else
                fontbush = new SolidBrush(font_color);
            g.DrawString(curr_skill.name, Font, fontbush, rect);
        }
        void LineDraw(Point st, Point ed, Pen p)  // 画出不和圆相交的线
        {
            double length = Math.Sqrt(Convert.ToDouble(distance_square(st, ed)));
            if (length < circle_R*2)
                return;
            double scale = circle_R / length;
            int offset_X = Convert.ToInt32((ed.X - st.X) * scale);
            int offset_Y = Convert.ToInt32((ed.Y - st.Y) * scale);
            st.X += offset_X;
            ed.X -= offset_X;
            st.Y += offset_Y;
            ed.Y -= offset_Y;
            g.DrawLine(p, st, ed);
        }
        private void redraw_all()
        {
            g.Clear(backgroundColor);
            Pen p = new Pen(line_color);
            for (int i = 0; i < skill_size; i++)
                for (int j = 0; j < i; j++)
                    if (edge[i, j] == 1)
                        LineDraw(circle_center[i], circle_center[j], p);
            for (int i = 0; i < skill_size; i++)
                drawSkill(circle_center[i], skillList[i]);
        }
        private int get_circleID(Point lotated)
        {
            for (int i = 0; i < skill_size; i++)
            {
                if (distance_square(lotated, circle_center[i]) <= circle_R * circle_R)
                {
                    return i;
                }
            }
            return noSkill_move;
        }
        private int distance_square(Point a, Point b)
        {
            int x = a.X - b.X;
            int y = a.Y - b.Y;
            return x * x + y * y;
        }
        private void RelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (circle_center == null)
                return;
            skillId_selected = get_circleID(e.Location);
            mouse_locate = e.Location;
        }
        private void RelationView_MouseMove(object sender, MouseEventArgs e)
        {
            if (skillId_selected != noSkill_move)
            {
                Point offset = new Point(e.Location.X - mouse_locate.X, e.Location.Y - mouse_locate.Y);
                mouse_locate = e.Location;
                circle_center[skillId_selected].Offset(offset);
                redraw_all();
            }
        }
        private void RelationView_MouseUp(object sender, MouseEventArgs e)
        {
            skillId_selected = noSkill_move;
        }

        private void RelationView_Load(object sender, EventArgs e)
        {
            skillId_selected = noSkill_move;
            g = this.CreateGraphics();
        }
    }
}