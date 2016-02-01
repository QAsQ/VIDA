using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS
{
    public partial class ColorView : UserControl
    {
        public delegate void ColorChangeHandler(object sender);
        public event ColorChangeHandler userChange;
        Color theColor;
        public Color color
        {
            get
            {
                return theColor;
            }
        }
        bool userAct;
        public ColorView()
        {
            userAct = false;
            InitializeComponent();
            checker.CheckState = CheckState.Unchecked;
            button.Enabled = false;
            button.BackColor = Color.Empty;
            theColor = Color.Empty;
            Texts = "null";
        }
        private void checker_CheckStateChanged(object sender, EventArgs e)
        {
            if (checker.CheckState == CheckState.Unchecked)
            {
                button.BackColor = Color.Empty;
                theColor = Color.Empty;
                button.Enabled = false;
            }
            if (checker.CheckState == CheckState.Checked)
            {
                button.Enabled = true;
            }
            if (userAct)
                userChange(this);
        }
        private void button_Click(object sender, EventArgs e)
        {
            ColorGeter.Color = button.BackColor;
            ColorGeter.ShowDialog();
            button.BackColor = ColorGeter.Color;
            theColor = ColorGeter.Color;
            userChange(this);
        }
        public void init(Color color)
        {
            userAct = false;
            button.BackColor = color;
            theColor = color;
            if (color.IsEmpty)
            {
                checker.CheckState = CheckState.Unchecked;
                button.Enabled = false;
            }
            else
            {
                checker.CheckState = CheckState.Checked;
                button.Enabled = true;
            }
            userAct = true;
        }
        public void nonempty()
        {
            userAct = false;
            checker.Visible = false;
            button.Enabled = true;
            userAct = true;
        }
        public string Texts
        {
            set
            {
                lable.Text = value;
            }
            get
            {
                return lable.Text;
            }
        }
    }
}
