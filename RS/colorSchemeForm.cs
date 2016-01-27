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
        public void getColor(FillStyle[] _fs, Color bg)
        {
            back_ground.color = bg;
            fs = _fs;
            UpdateColorScheme();
            this.ShowDialog();
        }

        private void UpdateColorScheme()
        {
            MiniDV.BackColor = back_ground.color;
            MiniDV.Fs = fs;
        }
        public FillStyle[] Fs
        {
            get
            {
                return fs;
            }
        }
        public Color backgroundColor
        {
            get
            {
                return backgroundColor;
            }
        }
        List<Skill> sample = new List<Skill>();
        public colorSchemeForm()
        {
            InitializeComponent();
            curr_index = -1;
            Fonts.none = true;
            back_ground.none = true;
            changeVisable(false);
        }
        FillStyle []fs = new FillStyle[3];
        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveColor(curr_index);
            curr_index = Status.SelectedIndex;
            if (curr_index != -1)
                loadStyle(fs[curr_index]);
        }
        private void loadStyle(FillStyle fs)
        {
            Fonts.color = fs.font;
            Edge.color = fs.edge;
            Fill.color = fs.fill;
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
        public void SchemeChange(FillStyle[] _fs)
        {
            fs = _fs;
        }
        private void Flash_Click(object sender, EventArgs e)
        {
            UpdateColorScheme();
            MiniDV.Flash();
        }
    }
}
