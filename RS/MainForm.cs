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
    public partial class mainForm : Form
    {
        public void studentMode()
        {
            MainRV.StudentMode();
        }
        public void teacherMode()
        {
            MainRV.TeacherMode();
        }
        public mainForm()
        {
            InitializeComponent();
            UpdateMinRVFormLocate();
        }
        Point FrameOffset = new Point(9,30);
        Skill[] oldskill_list;
        private void Debug()
        {
            const int maxn = 5;
            oldskill_list = new Skill[maxn];
            oldskill_list[0] = new Skill("数学分析");
            oldskill_list[0].addTail(2);
            oldskill_list[1] = new Skill("高等代数");
            oldskill_list[1].addTail(2);
            oldskill_list[2] = new Skill("常微分方程");
            oldskill_list[3] = new Skill("C++");
            oldskill_list[3].addTail(4);
            oldskill_list[4] = new Skill("C#");
      
            MainRV.circleR = 30;
            MainRV.ShowRelation(oldskill_list.ToList());
        }
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
            string ConnectString = "Data Source = ASATAN-PC;Initial Catalog = RS;"
                             + "integrated security =true";
            string SqlCommand = "Select * From skillData";
            SqlConnection conn = new SqlConnection(ConnectString);
            SqlCommand Command = new SqlCommand(SqlCommand, conn);
            conn.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Skill> skill_list = new List<Skill>();
            while (reader.Read())
            {
                skill_list.Add(new Skill(reader));
            }
            MainRV.circleR = 30;
            MainRV.ShowRelation(skill_list);
            conn.Close();
            conn.Dispose();
            reader.Close();
        }
    }
}