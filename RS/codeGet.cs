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
    public partial class codeGet : Form
    {
        public codeGet()
        {
            InitializeComponent();
        }
        string codes;
        public string getcode
        {
            get
            {
                return codes;
            }
        }
        public void getCode()
        {
            code.Text = "";
            this.ShowDialog();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            if (VCode.isLegalVCode(code.Text) == false)
            {
                MessageBox.Show("输入的不是合法的进度代码，请重新输入");
                return;
            }
            codes = code.Text;
            Hide();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            codes = "";
            Hide();
        }
    }
}
