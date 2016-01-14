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
        enum userMode { student, teacher};
        enum SkillDrawMode { Learned, canLearn, cantLearn };//已经学过的，可以学的，还不能学的
        private userMode mode;
        const userMode INITMODE = userMode.student;
        private int count = 1;
        const int Menusize = 8;
        string defaultSkillName = "新技能_";
        //刷新;重命名;添加技能;删除技能;学习技能,添加依赖关系,删除依赖关系,检查依赖关系;
        bool[,] MenuVisible = {{true, true, false, false, true,false,false,false},       //student
                               {true, true, true, true, false,true,true,true}};       //teacher
        bool[,] AfterSelectVisible = {{true, true, true, true, true,false,false,false},  // 有选择一个skill
                                      {true, false, true, false, false,true,true,true}};  // 没有选择一个skill
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
            skill_size = _skillList.Length;
            for (int i = 0; i < skill_size; i++)
            {
                drawModeList.Add(SkillDrawMode.cantLearn);
                skillList.Add(_skillList[i]);
                circle_center.Add(StartCenter);
            }
            setAllDrawmode();
            redraw_all();
        }
        private void setAllDrawmode()
        {
            bool[] vis = new bool[skill_size];
            for (int i = 0; i < skill_size; i++)
            {
                vis[i] = false;
            }
            for (int i = 0; i < skill_size; i++)
            {
                if (skillList[i].isLearn == false)
                {
                    List<int> currList = skillList[i].getTail;
                    for (int j = 0; j < currList.Count; j++)
                    {
                        vis[currList[j]] = true;
                    }
                }
            }
            for (int i = 0; i < skill_size; i++)
            {
                if (vis[i] == false && skillList[i].isLearn==false)
                {
                    drawModeList[i] = SkillDrawMode.canLearn;
                }
            }
        }
        private void 添加技能_Click(object sender, EventArgs e)
        {
            Skill adder = new Skill(defaultSkillName+count.ToString());
            count++;
            skillList.Add(adder);
            circle_center.Add(afterMenuMouseLocation);
            drawModeList.Add(SkillDrawMode.cantLearn);
            skill_size++;
            redraw_all();
        }
        public Color canLearn_color = Color.SkyBlue;
        public Color cantLearn_color = Color.Red;
        public Color Learned_color = Color.SkyBlue;
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
        const int maxSize = 300;
        const int maxR = 500;
        private bool inBound(int value, int bound)
        {
            return value >= 0 && value < bound;
        }
        private int circle_R = 50;
        private int skill_size = 5;
        const int noSkill_select = -1;
        private int font_size = 15;
        int skillId_selected;
        int MenuSkillId_selested;
        private Graphics g;
        private Point mouse_locate;
        private List<Point> circle_center = new List<Point>();
        private List<Skill> skillList = new List<Skill>();
        private List<SkillDrawMode> drawModeList = new List<SkillDrawMode>();
        private void drawSkill(Point center, Skill curr_skill,SkillDrawMode curr_mode)
        {
            int r = circle_R;
            int stx = center.X - r,sty = center.Y - r;
            int d = r * 2;
            Rectangle rect = new Rectangle(stx, sty, d, d);
            Pen p;
            switch (curr_mode)
            {
                case SkillDrawMode.Learned:
                    Brush bush = new SolidBrush(Learned_color);
                    g.FillEllipse(bush, rect);
                    break;
                case SkillDrawMode.cantLearn:
                    p = new Pen(cantLearn_color);
                    g.DrawEllipse(p, rect);
                    break;
                case SkillDrawMode.canLearn:
                    p = new Pen(canLearn_color);
                    g.DrawEllipse(p, rect);
                    break;
                default:
                    break;
            }
                    
            Font Font = new Font("Arial", font_size);
            Brush fontbush;
            if (curr_mode == SkillDrawMode.Learned)
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
                drawSkill(circle_center[i], skillList[i],drawModeList[i] );
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
        Point afterMenuMouseLocation;
        private void RelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_locate = e.Location;
                skillId_selected = get_circleID(e.Location);
            }
            if( e.Button == MouseButtons.Right)
            {
                MenuSkillId_selested = get_circleID(e.Location);
                ChangeMenuVisible();
                Point currMouseLocation = e.Location;
                currMouseLocation.Offset(FormLocate);
                currMouseLocation.Offset(this.Location);
                afterMenuMouseLocation = e.Location;
                afterMenuMouseLocation.Offset(this.Location);
                MenuStrip.Show(currMouseLocation);   
            }
        }
        private void ChangeMenuVisible()
        {
            int selectable;
            if (MenuSkillId_selested == noSkill_select)
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
                offset.Offset(circle_center[skillId_selected]);
                circle_center[skillId_selected] = offset;
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
            MenuSkillId_selested = noSkill_select;
            skill_size = 0;
            g = this.CreateGraphics();
        }
        private reNameForm rename = new reNameForm();
        private edgeGetForm getedge = new edgeGetForm();
        private void 重命名_Click(object sender, EventArgs e)
        {
            rename.getName(skillList[MenuSkillId_selested].name);
            if (rename.newName != "")
                skillList[MenuSkillId_selested].name = rename.newName;
            redraw_all();
            MenuSkillId_selested = noSkill_select;
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            redraw_all();
            MenuSkillId_selested = noSkill_select;
        }
        private void 删除技能_Click(object sender, EventArgs e)
        {
            
        }

        private void 学习技能_Click(object sender, EventArgs e)
        {
            skillList[MenuSkillId_selested].isLearn = true;
            drawModeList[MenuSkillId_selested] = SkillDrawMode.Learned;
            setAllDrawmode();
            redraw_all();
            MenuSkillId_selested = noSkill_select;
        }

        private void 忘记技能_Click(object sender, EventArgs e)
        {
            if (MenuSkillId_selested != noSkill_select)
            {
                skillList[MenuSkillId_selested].isLearn = false;
                drawModeList[MenuSkillId_selested] = SkillDrawMode.canLearn;
                redraw_all();
            }
            MenuSkillId_selested = noSkill_select;
        }
        private void 添加依赖关系_Click(object sender, EventArgs e)
        {
            MenuSkillId_selested = noSkill_select;
            int st, ed;
            if (getRelationStartEnd(out st,out ed) == false)
                return;
            int[] temp;
            skillList[st].addTail(ed);
            if (canTopSort(out temp) == false)
            {
                MessageBox.Show("添加这个关系后会有技能无法学习,添加失败");
                skillList[st].removeTail(ed);
                return;
            }
            redraw_all();
        }
        private int getId(string name)
        {
            for (int i = 0; i < skillList.Count; i++)
                if (name == skillList[i].name)
                    return i;
            return noSkill_select;
        }
        private bool getRelationStartEnd(out int st, out int ed)
        {
            getedge.getEdge();
            st = ed = -1;
            if (getedge.start == "" || getedge.end == "")
                return false;
            st = getId(getedge.start);
            if (st == noSkill_select)
            {
                MessageBox.Show("找不到 " + getedge.start + " 请检查您的输入");
                return false;
            }
            ed = getId(getedge.end);
            if (ed == noSkill_select)
            {
                MessageBox.Show("找不到 " + getedge.end + " 请检查您的输入");
                return false;
            }
            return true;
        }
        private void 删除依赖关系_Click(object sender, EventArgs e)
        {
            MenuSkillId_selested = noSkill_select;
            int st, ed;
            if (getRelationStartEnd(out st, out ed) == false)
                return;
            skillList[st].removeTail(ed);
            redraw_all();
        }
        private int getZero(ref bool[] vis,int[] Ind){
            for(int i=0;i<Ind.Length;i++){
                if(vis[i]==false && Ind[i]==0){
                    vis[i]=true;
                    return i;
                }
            }
            return -1;
        }
        private bool canTopSort(out int[] menu)
        {
            int len = skillList.Count;
            menu = new int[len];
            for (int i = 0; i < len; i++)
            {
                menu[i] = -1;
            }
            int[] inDeg = new int[len];
            bool[] vis = new bool[len];
            for (int i = 0; i < len; i++)
            {
                vis[i] = false;
                inDeg[i] = 0;
            }
            List<int> currTail;
            for (int i = 0; i < len; i++)
            {
                currTail = skillList[i].getTail;
                for (int j = 0; j < currTail.Count; j++)
                {
                    inDeg[currTail[j]]++;
                }
            }
            int pos = 0;
            int temp = getZero(ref vis, inDeg);
            while (temp != -1)
            {
                menu[pos] = temp;
                pos++;
                currTail = skillList[temp].getTail;
                for (int i = 0; i < currTail.Count; i++)
                {
                    inDeg[currTail[i]]--;
                }
                temp = getZero(ref vis, inDeg);
            }
            return pos == len;
        }

        private void 检查依赖关系_Click(object sender, EventArgs e)
        {
            int[] menu;
            if (canTopSort(out menu))
            {
                MessageBox.Show("关系合法");
            }
            else
            {
                MessageBox.Show("关系不合法!");
            }
            MenuSkillId_selested = noSkill_select;
        }
    }
}