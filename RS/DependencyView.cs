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
    public partial class DependencyView : UserControl
    {
        bool BackspaceIsDown;
        bool MouseLeftButtonIsDown;
        public Point FormLocate;
        enum userMode { student, teacher};
        private userMode Usermode;
        private userMode initUsermode = userMode.student;
        private int count = 1;
        const int Menusize = 11;
        string defaultSkillName = "新技能";
        string fontName = "微软雅黑";
        //刷新;重命名;添加技能;删除技能;学习技能,添加依赖关系,删除依赖关系,检查依赖关系,添加后继,删除后继,重置所有技能;
        bool[,] MenuVisible = {{true, true, false, false, true,false,false,false,false,false,true},       //student
                               {true, true, true, true, false,true,true,true,true,true,false}};       //teacher
        bool[,] AfterSelectVisible = {{true, true, true, true, true,false,false,false,true,true,false},  // 有选择一个skill
                                      {true, false, true, false, false,false,false,true,false,false,true}};  // 没有选择一个skill
        public void StudentMode()
        {
            Usermode = userMode.student;
        }
        public void TeacherMode()
        {
            Usermode = userMode.teacher;
        }
        public List<bool> isLearnState
        {
            get
            {
                return isLearnList;
            }
        }
        public DependencyView()
        {
            InitializeComponent();
        }
        public void ShowRelation(List<Skill> _skillList,List<PointF> _pointList)
        {
            skillList = _skillList;
            circleCenter = _pointList;
            for(int i = 0; i < _skillList.Count; i++)
            {
                drawModeList.Add(SkillDrawMode.Us);
                isLearnList.Add(false);
            }
            resetAllDrawmode();
            redraw_all();
        }     
        private void resetAllDrawmode()
        {
            bool[] vis = new bool[skillList.Count];
            for (int i = 0; i < skillList.Count; i++)
            {
                vis[i] = false;
            }
            for (int i = 0; i < skillList.Count; i++)
            {
                if (isLearnList[i] == false)
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
                if (vis[i] == false && isLearnList[i]==false)
                {
                    drawModeList[i] = SkillDrawMode.Cs;
                }
            }
        }
        private void 添加技能_Click(object sender, EventArgs e)
        {
            addOneSkill(afterMenuMouseLocation);
            redraw_all();
        }
        private void addOneSkill(PointF centerPoint)
        {
            Skill adder = new Skill(defaultSkillName +"("+ count.ToString()+")");
            count++;
            skillList.Add(adder);
            circleCenter.Add(centerPoint);
            drawModeList.Add(SkillDrawMode.Us);
            isLearnList.Add(false);
            resetAllDrawmode();
            reName(skillList.Count- 1);
        }
        Graphics formGraphis;
        enum SkillDrawMode
        {
            Hs, // Had study
            Cs, //Can sdudy
            Us  //Unable study
        };
        FillStyle Hs = new FillStyle(Color.Red, Color.Red,Color.Black);
        FillStyle Cs = new FillStyle(Color.SkyBlue, Color.AliceBlue,Color.Black);
        FillStyle Us = new FillStyle(Color.Red,Color.Red,Color.Black);
        public Color color_font = Color.Black;
        public Color color_background = Control.DefaultBackColor;
        public Color color_anchor = Color.DarkGray;
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
                reNameBox.Font = font_name;
            }
        }
        const int selectedId_None = -1;
        int size_font = 30;
        int selectedId_drag; 
        int selectedId_menu; 
        Font font_name ;
        private Graphics buffer;
        private Point locate_mouse;
        private List<PointF> circleCenter = new List<PointF>();
        private List<Skill> skillList = new List<Skill>();
        private List<bool> isLearnList = new List<bool>();
        private List<SkillDrawMode> drawModeList = new List<SkillDrawMode>();
        public bool changeLearnState(string biter)
        {
            if (biter.Length != isLearnList.Count)
                return false;
            for (int i = 0; i < biter.Length; i++)
            {
                isLearnList[i] = biter[i] == '1';
            }
            for (int i = 0; i < drawModeList.Count; i++)
                drawModeList[i] = isLearnState[i] ? SkillDrawMode.Hs : SkillDrawMode.Us;
            resetAllDrawmode();
            return true;
        }
        private void drawSkill(PointF _center, Skill curr_skill, FillStyle curr_style)
        {
            Point center = Point.Round(_center);
            int r = size_circle;
            int stx = center.X - r,sty = center.Y - r;
            int d = r * 2;
            Rectangle rect = new Rectangle(stx, sty, d, d);
            if (curr_style.edge)
            {
                Pen edgePen;
                edgePen = new Pen(curr_style.edgeColor);
                buffer.DrawEllipse(edgePen,rect);
            }
            if (curr_style.fill)
            {
                Brush fillBush = new SolidBrush(curr_style.fillColor);
                buffer.FillEllipse(fillBush, rect);
            }
            Brush fontbush;
            fontbush = new SolidBrush(curr_style.fontColor);

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
            Pen edPen = new Pen(end.fillColor);
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
            if (currStyle.fill)
            {
                Brush fillBush = new SolidBrush(currStyle.fillColor);
                buffer.FillPolygon(fillBush, PointList);
            }
            if (currStyle.edge)
            {
                Pen edgePen = new Pen(currStyle.edgeColor);
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
        Point afterMenuMouseLocation;
        private void RelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedId_renameBox != selectedId_None)
            {
                startRename();
            }
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
            if( e.Button == MouseButtons.Right)
            {
                selectedId_menu = get_circleID(e.Location);
                ChangeMenuVisible();
                Point currMouseLocation = e.Location + (Size)FormLocate + (Size)Location;
                afterMenuMouseLocation = e.Location + (Size)Location;
                MenuStrip.Show(currMouseLocation);   
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
            reNameBox.Font = font_name;
        }
        private void startRename()
        {
            skillList[selectedId_renameBox].name = reNameBox.Text;
            reNameBox.Hide();
            this.Focus();
            selectedId_renameBox = selectedId_None;
            reNameBox.Location = (Point)Size;
            Flash();
        }
        private void ChangeMenuVisible()
        {
            int selectable;
            if (selectedId_menu == selectedId_None)
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
            selectedId_menu = selectedId_None;
            selectedId_renameBox = selectedId_None;
            Usermode = initUsermode;
            reNameBox.Font = font_name;
            formGraphis = CreateGraphics();
            circleR = 50;
            anchorExist = false;
        }

        private void ButtonStateInit()
        {
            MouseLeftButtonIsDown = false;
            BackspaceIsDown = false;
        }
        private edgeGetForm getedge = new edgeGetForm();
        tailGetForm tailGet = new tailGetForm();
        int selectedId_renameBox;
        private void 重命名_Click(object sender, EventArgs e)
        {
            reName(selectedId_menu);
            selectedId_menu = selectedId_None;     
        }

        private void reName(int selectedId)
        {
            string oldName = skillList[selectedId].name;
            Point sizeOfName = (Point)getNameSize(oldName);
            reNameBox.Size = (Size)sizeOfName;
            Geometric.scale(ref sizeOfName, 1, 2);
            reNameBox.Location = Point.Round(circleCenter[selectedId]) - (Size)sizeOfName;
            reNameBox.Text = oldName;
            reNameBox.Show();
            reNameBox.Focus();
            reNameBox.SelectAll();
            selectedId_renameBox = selectedId;
        }
        private void 刷新_Click(object sender, EventArgs e)
        {
            redraw_all();
            selectedId_menu = selectedId_None;
        }
        private void 删除技能_Click(object sender, EventArgs e)
        {
            if(DialogResult.Cancel ==  MessageBox.Show("确定要删除 " + skillList[selectedId_menu].name + "吗 ? 删除后不可撤销", "Delete", MessageBoxButtons.OKCancel)){
                return;
            }
            skillList.RemoveAt(selectedId_menu);
            drawModeList.RemoveAt(selectedId_menu);
            circleCenter.RemoveAt(selectedId_menu);
            isLearnList.RemoveAt(selectedId_menu);
            foreach (Skill currSkill in skillList)
            {
                currSkill.removeIDAndSub(selectedId_menu);
            }
            selectedId_menu = selectedId_None;
            redraw_all();
        }
        
        private void 学习技能_Click(object sender, EventArgs e)
        {
             if (drawModeList[selectedId_menu] == SkillDrawMode.Us)
            {
                MessageBox.Show("该技能现在不可学习，请先学习该技能的前置技能");
                return;
            }
            isLearnList[selectedId_menu] = true;
            drawModeList[selectedId_menu] = SkillDrawMode.Hs;
            resetAllDrawmode();
            redraw_all();
            selectedId_menu = selectedId_None;
        }

        private void 忘记技能_Click(object sender, EventArgs e)
        {
            if (selectedId_menu != selectedId_None)
            {
                isLearnList[selectedId_menu] = false;
                drawModeList[selectedId_menu] = SkillDrawMode.Cs;
                redraw_all();
            }
            selectedId_menu = selectedId_None;
        }
        private void 添加依赖关系_Click(object sender, EventArgs e)
        {
                int st, ed;
                getedge.getEdge(skillList, true);
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
            selectedId_menu = selectedId_None;
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
        private void RelationView_KeyDown(object sender, KeyEventArgs e)
        {
            changeKeyState(e.KeyCode,true);
            Point mouseLocate = Control.MousePosition - (Size)FormLocate - (Size)Location;
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        addOneSkill(mouseLocate); //posi
                        redraw_all();
                        break;
                }

            }
        }

        private void changeKeyState(Keys k,bool isDown)
        {
            switch (k)
            {
                case Keys.Space:
                    BackspaceIsDown = isDown;
                    break;
            }
        }
        private void RelationView_KeyUp(object sender, KeyEventArgs e)
        {
            changeKeyState(e.KeyCode, false);
        }
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

        private void 添加后继_Click(object sender, EventArgs e)
        {
            int selectedID = selectedId_menu;
            selectedId_menu = selectedId_None;
            tailGet.getTail(selectedID, skillList, true);
            int tailAdded = tailGet.Selected;
            if (tailAdded == -1)
            {
                return;
            }
            skillList[selectedID].addTail(tailAdded);
            int[] temp;
            if (canTopSort(out temp) == false)
            {
                MessageBox.Show("添加这个关系后会导致技能无法学习,添加失败");
                skillList[selectedID].removeTail(tailAdded);
                return;
            }
            redraw_all();
        }
        private void 删除后继_Click(object sender, EventArgs e)
        {
            int selectedID = selectedId_menu;
            selectedId_menu = selectedId_None;
            tailGet.getTail(selectedID, skillList, false);
            if (tailGet.Selected != -1)
            {
                skillList[selectedID].removeTail(tailGet.Selected);
                redraw_all();
            }
        }

        private void reNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startRename();
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
        private void DependencyView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedId_ArrowPoiner = getArrowPioner(e.Location);
            Point aim = new Point(Width / 2, Height / 2);
            if (selectedId_ArrowPoiner != selectedId_None)
            {
                Point dis = Point.Round(circleCenter[selectedId_ArrowPoiner])-(Size)aim;
                if (dis.X == 0 && dis.Y == 0)
                {
                    dis.X = dis.Y = 2;
                }
                moveAllSkill(dis);
            }
            Flash();
        }

        private void DependencyView_SizeChanged(object sender, EventArgs e)
        {
            formGraphis = this.CreateGraphics();
            redraw_all();
        }

        private void 重置所有进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要清空所有学习进度吗?", "重置进度", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < isLearnList.Count; i++)
                {
                    isLearnList[i] = false;
                    drawModeList[i] = SkillDrawMode.Us;
                }
                resetAllDrawmode();
                redraw_all();
            }
        }
    }
}