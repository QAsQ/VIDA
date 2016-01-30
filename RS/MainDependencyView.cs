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
    public partial class MainDependencyView : DependencyView
    {
        public Point FormLocate;
        enum userMode { student, teacher};
        private userMode Usermode;
        private userMode initUsermode = userMode.student;
        private int count = 1;
        const int Menusize = 11;
        string defaultSkillName = "新技能";
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
        public List<bool> isLearnState // wait 
        {
            get
            {
                return isLearnList;
            }
        }
        public MainDependencyView()
        {
            InitializeComponent();
            Usermode = initUsermode;
            reNameBox.Font = font_name;
            initScheme();
            ButtonStateInit();
            selectedId_menu = selectedId_None;
            selectedId_renameBox = selectedId_None;
        }
        public void ShowRelation(List<Skill> _skillList, List<PointF> _pointList)
        {
            skillList = _skillList;
            circleCenter = _pointList;
            for (int i = 0; i < _skillList.Count; i++)
            {
                drawModeList.Add(SkillDrawMode.Us);
                isLearnList.Add(false);
            }
            resetAllDrawmode();
            Flash();
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
            Flash();
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
        public DrawStyle[] Fs
        {
            get
            {
                return fs;
            }
            set
            {
                fs = value;
            }
        }
        public Color BackgroundColor
        {
            get
            {
                return color_background;
            }
            set
            {
                color_background = value;
            }
        }
        void initScheme()
        {
            color_background = ColorTranslator.FromHtml("#86CDE8");
            fs[0] = new DrawStyle(Color.Empty
                               , ColorTranslator.FromHtml("#AAAAA2")
                               , ColorTranslator.FromHtml("White"));
            fs[1] = new DrawStyle(Color.Empty
                                , ColorTranslator.FromHtml("#F5F1A5")
                                , ColorTranslator.FromHtml("#2D35D2"));
            fs[2] = new DrawStyle(Color.Empty
                                , ColorTranslator.FromHtml("#C66A8A")
                                , ColorTranslator.FromHtml("White"));
        }
        int selectedId_menu; 
       
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
        Point afterMenuMouseLocation;
        private void MainRelationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedId_renameBox != selectedId_None)
            {
                startRename();
            }
            if( e.Button == MouseButtons.Right)
            {
                selectedId_menu = get_circleID(e.Location);
                ChangeMenuVisible();
                Point currMouseLocation = e.Location + (Size)FormLocate + (Size)Location;
                afterMenuMouseLocation = e.Location + (Size)Location;
                MenuStrip.Show(currMouseLocation);   
            }
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
        private void RelationView_Load(object sender, EventArgs e)
        {
           
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
            reNameBox.Font = font_name;
            string oldName = skillList[selectedId].name;
            Point sizeOfName = (Point)getNameSize(oldName);
            reNameBox.Size = (Size)sizeOfName;
            Geom.scale(ref sizeOfName, 1, 2);
            reNameBox.Location = Point.Round(circleCenter[selectedId]) - (Size)sizeOfName;
            reNameBox.Text = oldName;
            reNameBox.Show();
            reNameBox.Focus();
            reNameBox.SelectAll();
            selectedId_renameBox = selectedId;
        }
        private void 刷新_Click(object sender, EventArgs e)
        {
            Flash();
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
            Flash();
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
            Flash();
            selectedId_menu = selectedId_None;
        }

        private void 忘记技能_Click(object sender, EventArgs e)
        {
            if (selectedId_menu != selectedId_None)
            {
                isLearnList[selectedId_menu] = false;
                drawModeList[selectedId_menu] = SkillDrawMode.Cs;
                Flash();
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
                Flash();
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
                Flash();
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

        private void RelationView_KeyDown(object sender, KeyEventArgs e)
        {
            Point mouseLocate = Control.MousePosition - (Size)FormLocate - (Size)Location;
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        addOneSkill(mouseLocate); //posi
                        Flash();
                        break;
                }

            }
        }

        private void RelationView_KeyUp(object sender, KeyEventArgs e)
        {
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
            Flash();
        }
        private void 删除后继_Click(object sender, EventArgs e)
        {
            int selectedID = selectedId_menu;
            selectedId_menu = selectedId_None;
            tailGet.getTail(selectedID, skillList, false);
            if (tailGet.Selected != -1)
            {
                skillList[selectedID].removeTail(tailGet.Selected);
                Flash();
            }
        }
        private void reNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startRename();
            }
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
                Flash();
            }
        }
    }
}