using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (DialogResult.Yes == MessageBox.Show("是否用当前的状态来覆盖之前的数据？", "Save", MessageBoxButtons.YesNo))
            {
                var list_skill = MainDV.getAllSkill;
                foreach (Skill curr in list_skill)
                {
                    MessageBox.Show(curr.ToString());
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Skill[] skiller = new Skill[2];
            skiller[0] = (Skill)"QAQ,0,";
            skiller[1] = (Skill)"orz,1,0";
            MainDV.ShowRelation(skiller.ToList());
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {  
            MainDV.Size = this.Size;
            MainDV.Location = new Point(0, 0);
        }
    }
}