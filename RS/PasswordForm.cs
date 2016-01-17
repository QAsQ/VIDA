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
    public partial class PasswordForm : Form
    {
        bool passwordOK;
        public PasswordForm()
        {
            InitializeComponent();
        }
        public bool passwordRight
        {
            get
            {
                return passwordOK;
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            if (password.Text != "QAsQ")
            {
                MessageBox.Show("神秘代码错误，请重新输入");
            }
            else{
                passwordOK = true;
                Hide();
            }
        }
        public void checkPassword()
        {
            passwordOK = false;
            password.Text = "";
            ShowDialog();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            passwordOK = false;
            Hide();
        }
    }
}
