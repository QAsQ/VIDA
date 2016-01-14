using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RS
{
    public partial class Start : Form
    {
        mainForm mainform;
        SignUpForm signup = new SignUpForm();
        public Start()
        {
            InitializeComponent();
            LayoutChange();
            ConnectString = "Data Source = ASATAN-PC;Initial Catalog = RS;"
                             + "integrated security =true";
            conn = new SqlConnection(ConnectString);
            conn.Open();
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
            string sqlCom = "Select * From userData where userName = '" + username.Text+"'";
            SqlCommand command = new SqlCommand(sqlCom, conn);
            reader = command.ExecuteReader();
            if (reader.Read() == false)
            {
                MessageBox.Show("该用户不存在");
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
                    mainform = new mainForm();
                    mainform.studentMode(username.Text);
                    mainform.Showme(this);
                    successLogIn();
                    break;
                case 2:
                    mainform = new mainForm();
                    mainform.teacherMode();
                    mainform.Showme(this);
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
            signup.getInfo();
            string username = signup.Username;
            string password = signup.Password;
            if (password == "" && username == "")
                return;
            string sqlCom = "Select * From userData where userName = '" + username +"'";
            SqlCommand command = new SqlCommand(sqlCom, conn);
            SqlDataReader read =  command.ExecuteReader();
            if (read.Read() == true)
            {
                MessageBox.Show(" 该用户已经存在，请不要重复注册");
                read.Close();
                return;
            }
            read.Close();
            sqlCom = "Insert into userData Values('" + username + "','" + password + "',1)";
            command = new SqlCommand(sqlCom, conn);
            command.ExecuteNonQuery();
            MessageBox.Show("新用户 "+username+" 注册成功");
        }
        private void Start_SizeChanged(object sender, EventArgs e)
        {
            LayoutChange();
        }

        private void Start_ControlRemoved(object sender, ControlEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }
    }
}
