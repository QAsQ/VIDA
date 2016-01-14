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
    public partial class reNameForm : Form
    {
        public reNameForm()
        {
            InitializeComponent();
        }
        public string newName
        {
            get
            {
                return inputBox.Text;
            }
        }
        public void getName(String oldName)
        {
            inputBox.Text = oldName;
            this.ShowDialog();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
            this.Close();
        }
        private void reNameForm_Activated(object sender, EventArgs e)
        {
            inputBox.Focus();
            inputBox.SelectAll();
        }
    }
}
