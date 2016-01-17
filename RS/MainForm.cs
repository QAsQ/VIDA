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
            if (DialogResult.Yes == MessageBox.Show("是否保存当前的状态", "Save", MessageBoxButtons.YesNo))
            {
                var list_skill = MainDV.getAllSkill;
                foreach (Skill curr in list_skill)
                {
                    MessageBox.Show(curr.ToString());
                }
            }
        }
        private void mainForm_Resize(object sender, EventArgs e)
        {  
            MainDV.Size = this.Size;
            MainDV.Location = new Point(0, 0);
        }

        private void 管理模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainDV.TeacherMode();
        }
        private void 学习模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainDV.StudentMode();
            MainDV.Flash();
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
                    int n = Convert.ToInt32(reader.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        Skill curr = (Skill)reader.ReadLine();
                        skillList.Add(curr);
                    }
                    for(int i=0;i<n;i++){
                        string[] coordinate = reader.ReadLine().Split(',');
                        int x = Convert.ToInt32(coordinate[0]);
                        int y = Convert.ToInt32(coordinate[1]);
                        pointList.Add(new Point(x, y));
                    }
                }
                catch(Exception ex)
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
    }
}