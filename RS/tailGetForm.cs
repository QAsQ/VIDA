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
        public void getTail(int selectedID,List<Skill> skiller,bool isAdd)
        {
            selectId = -1;
            To.Items.Clear();
            To.Text = "";
            this.Text = "";
            List<int> tail = skiller[selectedID].getTail;
            this.Text += "请选择" + skiller[selectedID].name + "的后继";
            showId.Clear();
            if (isAdd == false)
            {
                showId = tail;
            }
            else
            {
                for (int i = 0; i < skiller.Count; i++)
                {
                    if (tail.Exists(id => id == i) == false && i != selectedID)
                        showId.Add(i);
                }
            }
            foreach (int id in showId)
            {
                To.Items.Add(skiller[id].name);
            }
            ShowDialog();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            if (To.SelectedIndex != -1)
                selectId = showId[To.SelectedIndex];
            else
                selectId = -1;
            Hide();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            selectId = -1;
            Hide();
        }
    }
}
