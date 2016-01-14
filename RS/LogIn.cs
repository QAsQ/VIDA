using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace RS
{
    public partial class Start : Form
    {
        mainForm mainform = new mainForm();
        public Start()
        {
            InitializeComponent();
            LayoutChange();
            ConnectString = "Data Source = ASATAN-PC;Initial Catalog = RS;"
                             + "integrated security =true";
        }
        string ConnectString;
        SqlDataReader reader;
        SqlConnection conn;
        private void LogIn_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (password.Text == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            string commend = "Select * From userData where userName = '" + username.Text+"'";
            conn = new SqlConnection(ConnectString);
            conn.Open();
            SqlCommand command = new SqlCommand(commend, conn);
            reader = command.ExecuteReader();
            if (reader.Read() == false)
            {
                MessageBox.Show("用户名不存在");
                close();
                return;
            }
            string rightPassword = (string)reader.GetValue(1);
            int mode = (int)reader.GetValue(2);
            close();
            if (password.Text != rightPassword)
            {
                MessageBox.Show("密码错误");
                return;
            }
            switch(mode){
                case 0:
                    MessageBox.Show("该用户版本与当前版本不符，请升级版本");
                    break;
                case 1:
                    mainform.studentMode();
                    mainform.Show();
                    successLogIn();
                    break;
                case 2:
                    mainform.teacherMode();
                    mainform.Show();
                    successLogIn();
                    break;
                default:
                    MessageBox.Show("管理员模式还未开发，请重新登录");
                    break;
            }
            mainform.Work();
        }
        private void close()
        {
            reader.Close(); 
            conn.Close();
            conn.Dispose();
        }
        private void successLogIn()
        {
            this.Visible = false;
        }
        private void LayoutChange()
        {
             //waitUpdate
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            //waitUpdate
        }

        private void Start_SizeChanged(object sender, EventArgs e)
        {
            LayoutChange();
        }
    }
}
