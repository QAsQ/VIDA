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
    public partial class edgeGetForm : Form
    {
        public edgeGetForm()
        {
            InitializeComponent();
        }
        public string start
        {
            get
            {
                return st;
            }
        }
        public string end
        {
            get
            {
                return ed;
            }
        }
        string st, ed;
        public void getEdge()
        {
            st = ed = "";
            from.Text = to.Text = "";
            this.ShowDialog();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            st = from.Text;
            ed = to.Text;
            Close();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            st = ed = "";
            Close();
        }
    }
}
