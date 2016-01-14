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
        public Point FormLocate;
        enum userMode { student, teacher, };
        private userMode mode;
        const userMode INITMODE = userMode.student;
        const int Menusize = 8;

        //刷新;重命名;添加技能;删除技能;学习技能;忘记技能,添加依赖关系,删除依赖关系;
        bool[,] MenuVisible = {{true, true, false, false, true, true,false,false},       //student
                               {true, true, true, true, false, false,true,true}};       //teacher
        bool[,] AfterSelectVisible = {{true, true, true, true, true, true,false,false},  // 有选择一个skill
                                      {true, false, true, false, false, false,true,true}};  // 没有选择一个skill

        public void StudentMode()
        {
            mode = userMode.student;
        }
        public void TeacherMode()
        {
            mode = userMode.teacher;
        }

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
        public Color backgroundColor = Control.DefaultBackColor;
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
        const int noSkill_select = -1;
        private int font_size = 15;
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
            int stx = center.X - r,sty = center.Y - r;
            int d = r * 2;
            Rectangle rect = new Rectangle(stx, sty, d, d);
            if (curr_skill.isLearn)
                g.FillEllipse(bush, rect);
            else
                g.DrawEllipse(p, rect);
            Font Font = new Font("Arial", font_size);
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
            st.X += offset_X; ed.X -= offset_X;
            st.Y += offset_Y; ed.Y -= offset_Y;
            g.DrawLine(p, st, ed);
        }
        private void redraw_all()
        {
            g.Clear(backgroundColor);
            Pen p = new Pen(line_color);
            for (int i = 0; i < skill_size; i++)
                for(int j = 0;j<skillList[i].getTail.Count ;j++)
                        LineDraw(circle_center[i], circle_center[skillList[i].getTail[j]], p);
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
            return noSkill_select;
        }
        private int distance_square(Point a, Point b)
        {
            int x = a.X - b.X;
            int y = a.Y - b.Y;
            return x * x + y * y;
        }
        private void RelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_locate = e.Location;
                skillId_selected = get_circleID(e.Location);
            }
            if( e.Button == MouseButtons.Right)
            {
                
                skillId_selected = get_circleID(e.Location);
                ChangeMenuVisible();
                Point currMouseLocation = e.Location;
                currMouseLocation.Offset(FormLocate);
                currMouseLocation.Offset(this.Location);
                MenuStrip.Show(currMouseLocation);   
            }
        }
        private void ChangeMenuVisible()
        {
            int selectable;
            if (skillId_selected == noSkill_select)
                selectable = 1;
            else
                selectable = 0;
            int modes;
            switch (mode)
            {
                case userMode.student:
                    modes = 0; break;
                case userMode.teacher:
                    modes = 1; break;
                default:
                    modes = 0; break;
            }
            for (int i = 0; i < Menusize; i++)
            {
                MenuStrip.Items[i].Visible = MenuVisible[modes, i] && AfterSelectVisible[selectable,i];
            }
        }
        private void RelationView_MouseMove(object sender, MouseEventArgs e)
        {
            if (skillId_selected != noSkill_select)
            {
                Point offset = new Point(e.Location.X - mouse_locate.X, e.Location.Y - mouse_locate.Y);
                mouse_locate = e.Location;
                circle_center[skillId_selected].Offset(offset);
                redraw_all();
            }
        }
        private void RelationView_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                skillId_selected = noSkill_select;
        }

        private void RelationView_Load(object sender, EventArgs e)
        {
            mode = INITMODE;
            skillId_selected = noSkill_select;
            skill_size = 0;
            g = this.CreateGraphics();
        }
        private reNameForm rename = new reNameForm();
        private void 重命名_Click(object sender, EventArgs e)
        {
            rename.getName(skillList[skillId_selected].name);
            if (rename.newName != "")
                skillList[skillId_selected].name = rename.newName;
            redraw_all();
            skillId_selected = noSkill_select;
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            redraw_all();
            skillId_selected = noSkill_select;
        }

        private void 添加技能_Click(object sender, EventArgs e)
        {

        }

        private void 删除技能_Click(object sender, EventArgs e)
        {
            
        }

        private void 学习技能_Click(object sender, EventArgs e)
        {
            if (skillId_selected != noSkill_select)
            {
                skillList[skillId_selected].isLearn = true;
                redraw_all();
            }
            skillId_selected = noSkill_select;
        }

        private void 忘记技能_Click(object sender, EventArgs e)
        {
            if (skillId_selected != noSkill_select)
            {
                skillList[skillId_selected].isLearn = false;
                redraw_all();
            }
            skillId_selected = noSkill_select;
        }

        private void 添加依赖关系_Click(object sender, EventArgs e)
        {

        }

        private void 删除依赖关系_Click(object sender, EventArgs e)
        {

        }
    }
}