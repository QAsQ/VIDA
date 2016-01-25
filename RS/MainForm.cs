using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RS
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            UpdateMinRVFormLocate();
        }
        bool haveInAdmin;
        Point FrameOffset = new Point(9,30);
        private void mainForm_LocationChanged(object sender, EventArgs e)
        {
            UpdateMinRVFormLocate();
        }
        private void UpdateMinRVFormLocate()
        {
            Point FormOffset = this.Location;
            FormOffset.Offset(FrameOffset);
            MainDV.FormLocate = FormOffset;
        }
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (DialogResult.Yes == MessageBox.Show("是否保存当前的状态", "Save", MessageBoxButtons.YesNo))
            //{
            //    var list_skill = MainDV.getAllSkill;
            //    foreach (Skill curr in list_skill)
            //    {
            //        MessageBox.Show(curr.ToString());
            //    }
            //}
        }
        private void mainForm_Resize(object sender, EventArgs e)
        {  
            MainDV.Size = this.Size;
            MainDV.Location = new Point(0, 0);
        }
        PasswordForm checkPassword = new PasswordForm();
        private void 管理模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (haveInAdmin == false)
            //{
            //    checkPassword.checkPassword();
            //    if (checkPassword.passwordRight)
            //    {
            //        MainDV.TeacherMode();
            //        haveInAdmin = true;
            //    }
            //}
            menu.Items[2].Visible = false; //教师端没有进度定义
            MainDV.Flash();
        }
        private void 学习模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainDV.StudentMode();
            MainDV.Flash();
            menu.Items[2].Visible = true; //学生端有进度管理
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var skillList = new List<Skill>();
                var pointList = new List<Point>();
                StreamReader reader = new StreamReader(openfile.FileName, Encoding.Default);
                try
                {
                    MainDV.size_circle = Convert.ToInt32(reader.ReadLine());
                    int n = Convert.ToInt32(reader.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Skill curr = (Skill)reader.ReadLine();
                        skillList.Add(curr);
                    }
                    for (int i = 0; i < n; i++)
                    {
                        string[] coordinate = reader.ReadLine().Split(',');
                        int x = Convert.ToInt32(coordinate[0]);
                        int y = Convert.ToInt32(coordinate[1]);
                        pointList.Add(new Point(x, y));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("该文件损坏");
                    return;
                }
                MainDV.ShowRelation(skillList,pointList);
                MainDV.Flash();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(savefile.FileName,false,Encoding.Default);
                var skillList = MainDV.getAllSkill;
                writer.WriteLine(MainDV.size_circle.ToString());
                writer.WriteLine(skillList.Count.ToString());
                foreach (Skill curr in skillList)
                {
                    writer.WriteLine(curr.ToString());
                }
                var pointList = MainDV.PointList;
                foreach (Point poi in pointList)
                {
                    writer.WriteLine(poi.X.ToString() + "," + poi.Y.ToString());
                }
                writer.Flush();
                writer.Close();
            }
        }

        private void MainDV_Load(object sender, EventArgs e)
        {
            haveInAdmin = false;
        }

        private void 获取状态码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<bool> state = MainDV.isLearnState;
            string bit="";
            for (int i = 0; i < state.Count; i++)
            {
                bit += state[i] ? '1' : '0';
            }
            string vcode = VCode.BitToVCode(bit);
            ShowCode codeform = new ShowCode();
            codeform.ShowMeCode(vcode);
        }

        private void 修改状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeGet codeform = new codeGet();
            codeform.getCode();
            string code = codeform.getcode;
            if(MainDV.changeLearnState(VCode.VCodetobit(code))==false){
                MessageBox.Show("该进度代码与当前依赖不匹配，请输入正确的进度代码");
            }
            else{
                MainDV.Flash();
            }
        }
    }
}