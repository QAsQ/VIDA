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
    public partial class tailGetForm : Form
    {
        public tailGetForm()
        {
            InitializeComponent();
        }
        List<int> showId = new List<int>();
        int selectId;
        public int Selected
        {
            get
            {
                return selectId;
            }
        }
        public void getTail(int selectedID,List<Skill> skillList,bool isAdd)
        {
            selectId = -1;
            To.Items.Clear();
            To.Text = "";
            var tail = skillList[selectedID].getTail;
            if (isAdd)
                this.Text = "添加";
            else
                this.Text = "删除";
            this.Text += " "+skillList[selectedID].name +" 的后继";
            showId.Clear();
            if (isAdd == false)
            {
                showId = tail;
            }
            else
            {
                for (int i = 0; i < skillList.Count; i++)
                {
                    if (tail.Exists(id => id == i) == false && i != selectedID)
                        showId.Add(i);
                }
            }
            foreach (int id in showId)
            {
                To.Items.Add(skillList[id].name);
            }
            ShowDialog();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            if(To.SelectedIndex != -1)
            selectId = showId[To.SelectedIndex];
            Hide();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            selectId = -1;
            Hide();
        }
    }
}
