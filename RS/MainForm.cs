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
    public partial class mainForm : Form
    {
        string tableName = "skillData"; //skillData ||　acmData
        Form fatherForm;
        string username;
        string ConnectString;
        SqlConnection conn;
        public void Showme(Form loginForm)
        {   
            ConnectString = "Data Source = ASATAN-PC;Initial Catalog = RS;"
                             + "integrated security =true";
            conn = new SqlConnection(ConnectString);
            conn.Open();
            Text = username + " 登录中";
            Show();
            fatherForm = loginForm;
        }
        public void studentMode(string _username)
        {
            username = _username;
            MainRV.StudentMode();
        }
        public void teacherMode()
        {
            username = "";
            MainRV.TeacherMode();
        }
        public mainForm()
        {
            InitializeComponent();
            UpdateMinRVFormLocate();
        }
        Point FrameOffset = new Point(9,30);
        public void Work()
        {
            DataFromSQL();
        }
        private void mainForm_LocationChanged(object sender, EventArgs e)
        {
            UpdateMinRVFormLocate();
        }
        private void UpdateMinRVFormLocate()
        {
            Point FormOffset = this.Location;
            FormOffset.Offset(FrameOffset);
            MainRV.FormLocate = FormOffset;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataFromSQL();
        }
        private void DataFromSQL()
        {
            string SqlCommand = "Select * From "+tableName; // acmData acmData
            SqlCommand Command = new SqlCommand(SqlCommand, conn);
            SqlDataReader reader = Command.ExecuteReader();
            List<Skill> skill_list = new List<Skill>();
            while (reader.Read())
            {
                skill_list.Add(new Skill(reader));
            }
            reader.Close();
            if (username != "")
            {
                string judgeTable = "Select Count(1) From sysobjects Where name = 'User" + username + "'";
                Command.CommandText = judgeTable;
                bool exist = Convert.ToBoolean(Command.ExecuteScalar());
                if (!exist)
                {
                    string CreatTable = "Create Table User" + username + "\n(\nId int,\nisLearn bit\n)";
                    Command.CommandText = CreatTable;
                    Command.ExecuteNonQuery();
                }
                string studentLearned = "Select isLearn From User" + username;
                Command.CommandText = studentLearned;
                reader = Command.ExecuteReader();
                for (int i = 0; i < skill_list.Count; i++)
                {
                    if (reader.Read())
                        skill_list[i].isLearn = (bool)reader.GetValue(0);
                    else
                    {
                        string addList = "Insert into User" + username + " Values('" + i.ToString() + "',FALSE)";
                    }
                }
            }
            else
            {
                foreach (Skill currSkill in skill_list)
                {
                    currSkill.isLearn = true;
                }
            }
            MainRV.ShowRelation(skill_list);
            reader.Close();
        }
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("是否用当前的状态来覆盖之前的数据？","Save",MessageBoxButtons.YesNo))
                saveSkillInSQL(MainRV.getAllSkill);
            conn.Close();
            conn.Dispose();
            fatherForm.Show();
        }
        private void saveSkillInSQL(List<Skill> skillList)
        {
            if (username == "")
            {
                string SqlCom = "Delete From " + tableName;
                SqlCommand cmd = new SqlCommand(SqlCom, conn);
                cmd.ExecuteNonQuery();
                for (int i = 0; i < skillList.Count; i++)
                {
                    SqlCom = "Insert Into " + tableName + " Values (" + i.ToString() + "," + skillList[i].toSQLstring() + ")";
                    cmd.CommandText = SqlCom;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < skillList.Count; i++)
                {
                    string SqlCom = "Update User" + username + " Set isLearn = '" + skillList[i].isLearn.ToString().ToUpper() + "' Where Id = " + i.ToString();
                    SqlCommand cmd = new SqlCommand(SqlCom, conn);
                    cmd.ExecuteNonQuery();
               }
            }
        }
    }
}