using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RS
{
    public partial class RelationView : UserControl
    {
        bool BackspaceIsDown;
        bool MouseLeftButtonIsDown;
        public Point FormLocate;
        enum userMode { student, teacher};
        enum SkillDrawMode { Learned, canLearn, cantLearn };//已经学过的，可以学的，还不能学的
        private userMode Usermode;
        private userMode initUsermode = userMode.teacher;
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
            Usermode = userMode.student;
        }
        public void TeacherMode()
        {
            Usermode = userMode.teacher;
        }

        public RelationView()
        {
            InitializeComponent();  
        }
        public void ShowRelation(List<Skill> _skillList)
        {
            for(int i = 0; i < _skillList.Count; i++)
            {
                SkillDrawMode curr_state;
                if (userMode.teacher == Usermode)
                {
                    curr_state = SkillDrawMode.Learned;
                }
                else
                {
                    if (_skillList[i].isLearn)
                        curr_state = SkillDrawMode.Learned;
                    else
                        curr_state = SkillDrawMode.cantLearn;
                }
                drawModeList.Add(curr_state); 
                skillList.Add(_skillList[i]);
                circleCenter.Add(default_StartCenter);
                default_StartCenter.X += size_circle * 2;
            }
            setAllDrawmode();
            redraw_all();
        }
        private void setAllDrawmode()
        {
            bool[] vis = new bool[skillList.Count];
            for (int i = 0; i < skillList.Count; i++)
            {
                vis[i] = false;
            }
            for (int i = 0; i < skillList.Count; i++)
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
            for (int i = 0; i < skillList.Count; i++)
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
            circleCenter.Add(afterMenuMouseLocation);
            drawModeList.Add(SkillDrawMode.Learned);
            redraw_all();
        }
        public Color color_canLearnr = Color.SkyBlue;
        public Color color_cantLearn = Color.Red;
        public Color color_Learned = Color.SkyBlue;
        public Color color_font = Color.Black;
        public Color color_line = Color.Black;
        public Color color_background = Control.DefaultBackColor;
        Point default_StartCenter = new Point(size_circle, size_circle);
        const int size_circle = 50;
        const int selected_noSkill = -1;
        private int font_size = 25;
        int selected_idSkill; // wait update
        int selested_idSkillMenu;
        private Graphics g;
        private Point locate_mouse;
        private List<Point> circleCenter = new List<Point>();
        private List<Skill> skillList = new List<Skill>();
        private List<SkillDrawMode> drawModeList = new List<SkillDrawMode>();
        private void drawSkill(Point center, Skill curr_skill,SkillDrawMode curr_mode)
        {
            int r = size_circle;
            int stx = center.X - r,sty = center.Y - r;
            int d = r * 2;
            Rectangle rect = new Rectangle(stx, sty, d, d);
            Pen p;
            switch (curr_mode)
            {
                case SkillDrawMode.Learned:
                    Brush bush = new SolidBrush(color_Learned);
                    g.FillEllipse(bush, rect);
                    break;
                case SkillDrawMode.cantLearn:
                    p = new Pen(color_cantLearn);
                    g.DrawEllipse(p, rect);
                    break;
                case SkillDrawMode.canLearn:
                    p = new Pen(color_canLearnr);
                    g.DrawEllipse(p, rect);
                    break;
                default:
                    break;
            }   
            Font Font = new Font("Arial", font_size);
            Brush fontbush;
            if (curr_mode == SkillDrawMode.Learned)
                fontbush = new SolidBrush(Color.Gray);
            else
                fontbush = new SolidBrush(Color.Black);
            SizeF fontSize = g.MeasureString(curr_skill.name,Font);
            Point DrawStringPoint = center;
            DrawStringPoint.X -= (int)fontSize.Width / 2;
            DrawStringPoint.Y -= (int)fontSize.Height / 2;
            g.DrawString(curr_skill.name, Font, fontbush, DrawStringPoint);
        }
        int distance(Point st, Point ed)
        {
            int dx = st.X - ed.X;
            int dy = st.Y - ed.Y;
            int ans = dx * dx + dy * dy;
            return (int)Math.Sqrt((double)ans);
        }
        private Pen getDrawModePen(SkillDrawMode currDrawMode)
        {
            Pen ret;
            switch (currDrawMode)
            {
                case SkillDrawMode.canLearn:
                    ret = new Pen(color_canLearnr);
                    break;
                case SkillDrawMode.cantLearn:
                    ret = new Pen(color_cantLearn);
                    break;
                case SkillDrawMode.Learned:
                    ret = new Pen(color_Learned);
                    break;
                default:
                    ret = new Pen(color_line);
                    break;
            }
            return ret;
        }
        private void Scale(ref Point poi,int Zoomin,int Zoomout){
            if (Zoomout == 0)
                return;
            poi.X *= Zoomin ; poi.Y *= Zoomin;
            poi.X /= Zoomout; poi.Y /= Zoomout;
        }
        private void DrawArrow(Point st, Point ed, SkillDrawMode startMode, SkillDrawMode endMode)
        {
            int length = distance(st, ed);
            if (length <= size_circle * 2)
                return;
            Point vR = ed - (Size)st;  // 从圆心到圆周的向量
            Scale(ref vR, size_circle, length);
            st += (Size)vR;
            ed -= (Size)vR; 
            Point Vst_ed = ed - (Size)st; // 向量 
            int LengthV = distance(new Point(0, 0), Vst_ed);
            Scale(ref Vst_ed,5,8);
            if (LengthV * 5> size_circle * 16 )
            {
                Scale(ref Vst_ed, size_circle * 16, LengthV * 5);
            }
            Point nst = ed - (Size)Vst_ed;   // new start
            Point mid = ed - (Size)nst;
            Scale(ref mid, 5,8);
            mid = ed - (Size)mid;
            Scale(ref Vst_ed,5,8);
            Point perp = new Point(Vst_ed.Y, -Vst_ed.X);
            Scale(ref perp, 3, 8);
            int LengthPerp = distance(new Point(0, 0), perp);
            LengthPerp = LengthPerp * 8 / 5;
            if (LengthPerp * 8 < size_circle * 5 && LengthPerp * 5 > size_circle * 8)
            { 
                Scale(ref perp, size_circle, LengthPerp);
            }
            Pen edPen = getDrawModePen(startMode);
            g.DrawLine(edPen, st, nst);
            Point top = mid + (Size)perp;
            Point button = mid - (Size)perp;

            Point[] pointList = new Point[] { nst, top, ed, button };
            DrawArrow(pointList, startMode);
        }
        private void DrawArrow(Point[] PointList, SkillDrawMode currMode)
        {
            if (currMode == SkillDrawMode.Learned)
            {
                Brush bush = new SolidBrush(color_Learned);
                g.FillPolygon(bush, PointList);
            }
            else
            {
                Pen pen = getDrawModePen(currMode);
                g.DrawPolygon(pen, PointList);
            }
        }
        private void redraw_all()
        {
            g.Clear(color_background);
            Pen p = new Pen(color_line);
            for (int i = 0; i < skillList.Count; i++)
            {
                List<int> currTail = skillList[i].getTail;
                foreach (int end in currTail)
                {
                    DrawArrow(circleCenter[i], circleCenter[end],drawModeList[i],drawModeList[end]);
                }
            }
            for (int i = 0; i < skillList.Count; i++)
                drawSkill(circleCenter[i], skillList[i],drawModeList[i] );
        }
        private int get_circleID(Point lotated)
        {
            for (int i = 0; i < skillList.Count; i++)
            {
                if (distance(lotated, circleCenter[i]) <= size_circle )
                {
                    return i;
                }
            }
            return selected_noSkill;
        }
        Point afterMenuMouseLocation;
        private void RelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = true;
                locate_mouse = e.Location;
                selected_idSkill = get_circleID(e.Location);
                spaceMouseLocate = e.Location;
            }
            if( e.Button == MouseButtons.Right)
            {
                selested_idSkillMenu = get_circleID(e.Location);
                ChangeMenuVisible();
                Point currMouseLocation = e.Location + (Size)FormLocate + (Size)Location;
                afterMenuMouseLocation = e.Location + (Size)Location;
                MenuStrip.Show(currMouseLocation);   
            }
        }
        private void ChangeMenuVisible()
        {
            int selectable;
            if (selested_idSkillMenu == selected_noSkill)
                selectable = 1;
            else
                selectable = 0;
            int modes;
            switch (Usermode)
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
        Point spaceMouseLocate;
        private void RelationView_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected_idSkill != selected_noSkill && MouseLeftButtonIsDown)
            {
                Point offset = e.Location - (Size)locate_mouse;
                locate_mouse = e.Location;
                offset.Offset(circleCenter[selected_idSkill]);
                circleCenter[selected_idSkill] = offset;
                redraw_all();
            }
            if (BackspaceIsDown == true && MouseLeftButtonIsDown)
            {
                Point deviaion;
                deviaion = locate_mouse - (Size)e.Location;
                locate_mouse = e.Location;
                for (int i = 0; i < skillList.Count; i++)
                {
                    circleCenter[i] = circleCenter[i] - (Size)deviaion;
                }
                redraw_all();
            }
        }
        private void RelationView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = false;
                selected_idSkill = selected_noSkill;
                spaceMouseLocate.X = spaceMouseLocate.Y = 0;
            }
        }
        private void RelationView_Load(object sender, EventArgs e)
        {
            MouseLeftButtonIsDown = false;
            BackspaceIsDown = false;
            selected_idSkill = selected_noSkill;
            selested_idSkillMenu = selected_noSkill;
            Usermode = initUsermode;
            g = this.CreateGraphics();
        }
        private reNameForm rename = new reNameForm();
        private edgeGetForm getedge = new edgeGetForm();
        private void 重命名_Click(object sender, EventArgs e)
        {
            rename.getName(skillList[selested_idSkillMenu].name);
            if (rename.newName != "")
                skillList[selested_idSkillMenu].name = rename.newName;
            redraw_all();
            selested_idSkillMenu = selected_noSkill;
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            redraw_all();
            selested_idSkillMenu = selected_noSkill;
        }
        private void 删除技能_Click(object sender, EventArgs e)
        {
            if(DialogResult.Cancel ==  MessageBox.Show("确定要删除 " + skillList[selested_idSkillMenu].name + "吗 ? 删除后不可撤销", "Delete", MessageBoxButtons.OKCancel)){
                return;
            }
            skillList.RemoveAt(selested_idSkillMenu);
            drawModeList.RemoveAt(selested_idSkillMenu);
            circleCenter.RemoveAt(selested_idSkillMenu);
            foreach (Skill currSkill in skillList)
            {
                currSkill.removeIDAndSub(selested_idSkillMenu);
            }
            selested_idSkillMenu = selected_noSkill;
            redraw_all();
        }
        
        private void 学习技能_Click(object sender, EventArgs e)
        {
             if (drawModeList[selested_idSkillMenu] == SkillDrawMode.cantLearn)
            {
                MessageBox.Show("该技能现在不可学习，请先学习该技能的前置技能");
                return;
            }
            skillList[selested_idSkillMenu].isLearn = true;
            drawModeList[selested_idSkillMenu] = SkillDrawMode.Learned;
            setAllDrawmode();
            redraw_all();
            selested_idSkillMenu = selected_noSkill;
        }

        private void 忘记技能_Click(object sender, EventArgs e)
        {
            if (selested_idSkillMenu != selected_noSkill)
            {
                skillList[selested_idSkillMenu].isLearn = false;
                drawModeList[selested_idSkillMenu] = SkillDrawMode.canLearn;
                redraw_all();
            }
            selested_idSkillMenu = selected_noSkill;
        }
        private void 添加依赖关系_Click(object sender, EventArgs e)
        {
            selested_idSkillMenu = selected_noSkill;
            int st, ed;
            getedge.getEdge(skillList,true);
            st = getedge.start;
            ed = getedge.end;
            if (st == -1 || ed == -1)
                return;
            int[] temp;
            skillList[st].addTail(ed);
            if (canTopSort(out temp) == false)
            {
                MessageBox.Show("添加这个关系后会导致技能无法学习,添加失败");
                skillList[st].removeTail(ed);
                return;
            }
            redraw_all();
        }
        private void 删除依赖关系_Click(object sender, EventArgs e)
        {
            selested_idSkillMenu = selected_noSkill;
            int st, ed;
            getedge.getEdge(skillList, false);
            st = getedge.start;
            ed = getedge.end;
            if (st == -1 || ed == -1)
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
            selested_idSkillMenu = selected_noSkill;
        }
        public List<Skill> getAllSkill
        {
            get
            {
                return skillList;
            }
        }

        private void RelationView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                BackspaceIsDown = true;
            }
        }

        private void RelationView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                BackspaceIsDown = false;
            }
        }
    }
}