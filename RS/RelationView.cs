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
            skill_size = _skillList.Count;
            for(int i = 0; i < skill_size; i++)
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
                circle_center.Add(StartCenter);
                StartCenter.X += circle_R * 2;
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
            drawModeList.Add(SkillDrawMode.Learned);
            skill_size++;
            redraw_all();
        }
        public Color canLearn_color = Color.SkyBlue;
        public Color cantLearn_color = Color.Red;
        public Color Learned_color = Color.SkyBlue;
        public Color font_color = Color.Black;
        public Color line_color = Color.Black;
        public Color backgroundColor = Control.DefaultBackColor;
        Point StartCenter = new Point(circle_R, circle_R);
        const int maxSize = 300;
        const int maxR = 500;
        private bool inBound(int value, int bound)
        {
            return value >= 0 && value < bound;
        }
        const int circle_R = 50;
        private int skill_size = 5;
        const int noSkill_select = -1;
        private int font_size = 25;
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
                    ret = new Pen(canLearn_color);
                    break;
                case SkillDrawMode.cantLearn:
                    ret = new Pen(cantLearn_color);
                    break;
                case SkillDrawMode.Learned:
                    ret = new Pen(Learned_color);
                    break;
                default:
                    ret = new Pen(line_color);
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
            if (length <= circle_R * 2)
                return;
            Point vR = ed - (Size)st;  // 从圆心到圆周的向量
            Scale(ref vR, circle_R, length);
            st += (Size)vR;
            ed -= (Size)vR; 
            Point Vst_ed = ed - (Size)st; // 向量 
            int LengthV = distance(new Point(0, 0), Vst_ed);
            Scale(ref Vst_ed,5,8);
            if (LengthV * 5> circle_R * 16 )
            {
                Scale(ref Vst_ed, circle_R * 16, LengthV * 5);
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
            if (LengthPerp * 8 < circle_R * 5 && LengthPerp * 5 > circle_R * 8)
            { // length * 618 / 1000 = circle_R
                Scale(ref perp, circle_R, LengthPerp);
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
                Brush bush = new SolidBrush(Learned_color);
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
            g.Clear(backgroundColor);
            Pen p = new Pen(line_color);
            for (int i = 0; i < skill_size; i++)
            {
                List<int> currTail = skillList[i].getTail;
                foreach (int end in currTail)
                {
                    DrawArrow(circle_center[i], circle_center[end],drawModeList[i],drawModeList[end]);
                }
            }
            for (int i = 0; i < skill_size; i++)
                drawSkill(circle_center[i], skillList[i],drawModeList[i] );
        }
        private int get_circleID(Point lotated)
        {
            for (int i = 0; i < skill_size; i++)
            {
                if (distance(lotated, circle_center[i]) <= circle_R )
                {
                    return i;
                }
            }
            return noSkill_select;
        }
        Point afterMenuMouseLocation;
        private void RelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = true;
                mouse_locate = e.Location;
                skillId_selected = get_circleID(e.Location);
                spaceMouseLocate = e.Location;
            }
            if( e.Button == MouseButtons.Right)
            {
                MenuSkillId_selested = get_circleID(e.Location);
                ChangeMenuVisible();
                Point currMouseLocation = e.Location + (Size)FormLocate + (Size)Location;
                afterMenuMouseLocation = e.Location + (Size)Location;
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
            if (skillId_selected != noSkill_select && MouseLeftButtonIsDown)
            {
                Point offset = e.Location - (Size)mouse_locate;
                mouse_locate = e.Location;
                offset.Offset(circle_center[skillId_selected]);
                circle_center[skillId_selected] = offset;
                redraw_all();
            }
            if (BackspaceIsDown == true && MouseLeftButtonIsDown)
            {
                Point deviaion;
                deviaion = mouse_locate - (Size)e.Location;
                mouse_locate = e.Location;
                for (int i = 0; i < skill_size; i++)
                {
                    circle_center[i] = circle_center[i] - (Size)deviaion;
                }
                redraw_all();
            }
        }
        private void RelationView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftButtonIsDown = false;
                skillId_selected = noSkill_select;
                spaceMouseLocate.X = spaceMouseLocate.Y = 0;
            }
        }
        private void RelationView_Load(object sender, EventArgs e)
        {
            MouseLeftButtonIsDown = false;
            BackspaceIsDown = false;
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
            if(DialogResult.Cancel ==  MessageBox.Show("确定要删除 " + skillList[MenuSkillId_selested].name + "吗 ? 删除后不可撤销", "Delete", MessageBoxButtons.OKCancel)){
                return;
            }
            skill_size--;
            skillList.RemoveAt(MenuSkillId_selested);
            drawModeList.RemoveAt(MenuSkillId_selested);
            circle_center.RemoveAt(MenuSkillId_selested);
            foreach (Skill currSkill in skillList)
            {
                currSkill.removeIDAndSub(MenuSkillId_selested);
            }
            MenuSkillId_selested = noSkill_select;
            redraw_all();
        }
        
        private void 学习技能_Click(object sender, EventArgs e)
        {
             if (drawModeList[MenuSkillId_selested] == SkillDrawMode.cantLearn)
            {
                MessageBox.Show("该技能现在不可学习，请先学习该技能的前置技能");
                return;
            }
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
            MenuSkillId_selested = noSkill_select;
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
            MenuSkillId_selested = noSkill_select;
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