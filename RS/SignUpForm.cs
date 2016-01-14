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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        public string Username
        {
            get
            {
                return username.Text;
            }
        }
        public string Password
        {
            get
            {
                return password.Text;
            }
        }
        private void SignUp_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (checkUsername(username.Text) == false)
            {
                MessageBox.Show("用户名不能包含数字和字母之外的字符");
                return;
            }
            if (password.Text == "")
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            username.Text = password.Text = "";
            Close();
        }
        public void getInfo()
        {
            username.Text = password.Text = "";
            ShowDialog();
        }
        private bool checkUsername(string name)
        {
            foreach (char c in name)
            {
                if (char.IsDigit(c) == false && char.IsLetter(c) == false && char.IsUpper(c) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
