using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RS;

namespace RS
{
    public partial class colorSchemeForm : Form
    {
        public void getColor(DrawStyle[] _fs, Color bg)
        {
            notUserAct = true;
            changeScheme = false;
            back_ground.color = bg;
            fs = _fs;
            UpdateColorScheme();
            this.ShowDialog();
            notUserAct = false;
        }

        private void UpdateColorScheme()
        {
            MiniDV.BackgroundColor = back_ground.color;
            MiniDV.Fs = fs;
        }
        public DrawStyle[] Fs
        {
            get
            {
                return fs;
            }
        }
        public Color BackgroundColor
        {
            get
            {
                return back_ground.color;
            }
        }
        public bool ChangeColor
        {
            get
            {
                return changeScheme;
            }
        }
        List<Skill> sample = new List<Skill>();
        public colorSchemeForm()
        {
            notUserAct = true;
            InitializeComponent();
            notUserAct = false;
            curr_index = -1;
            Fonts.none = true;
            back_ground.none = true;
            changeVisable(false);
        }
        bool notUserAct;
        DrawStyle []fs = new DrawStyle[3];
        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveColor(curr_index);
            if (Status.SelectedIndex != -1)
            {
                loadStyle(fs[Status.SelectedIndex]);
            }
            curr_index = Status.SelectedIndex;
        }
        private void loadStyle(DrawStyle fs)
        {
            notUserAct = true;
            Fonts.color = fs.font;
            Edge.color = fs.edge;
            Fill.color = fs.fill;
            notUserAct = false;
            changeVisable(true);
        }
        int curr_index;
        private void saveColor(int index)
        {
            if (index == -1)
            {
                changeVisable(false);
                return;
            }
            fs[index].edge = Edge.color;
            fs[index].fill = Fill.color;
            fs[index].font = Fonts.color;
            changeVisable(true);
        }
        void changeVisable(bool value)
        {
            Fonts.Visible = Edge.Visible = Fill.Visible = value;
            字色.Visible = 填充.Visible = 描边.Visible = value;
        }
        private void colorSchemeForm_Load(object sender, EventArgs e)
        {
            MiniDV.Flash();
        }
        public void SchemeChange(DrawStyle[] _fs)
        {
            fs = _fs;
        }
        private void Flash_Click(object sender, EventArgs e)
        {
            saveColor(Status.SelectedIndex);
            UpdateColorScheme();
            MiniDV.Flash();
        }
        bool changeScheme;
        private void OK_Click(object sender, EventArgs e)
        {
            changeScheme = true;
            Hide();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            changeScheme = false;
            Hide();
        }
        private void Color_Change(object sender)
        {
            if (!notUserAct)
            {
                saveColor(curr_index);
                UpdateColorScheme();
                MiniDV.Flash();
            }
        }

    }
}
