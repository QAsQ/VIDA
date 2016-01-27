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
        public ColorView()
        {
            InitializeComponent();
            colorCheck.CheckState = CheckState.Indeterminate;
        }
        Color colors;
        public Color color
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
                if (value.IsEmpty)
                {
                    colorCheck.CheckState = CheckState.Unchecked;
                    colorButton.BackColor = DefaultBackColor;
                }
                else
                {
                    colorCheck.CheckState = CheckState.Checked;
                    colorButton.BackColor = value;
                }
            }
        }
        private void colorChange_Click(object sender, EventArgs e)
        {
            colorGet.Color = color;
            colorGet.ShowDialog();
            color = colorGet.Color;
            colorButton.BackColor = color;
        }
        private void checker_CheckedChanged(object sender, EventArgs e)
        {
            if (colorCheck.CheckState == CheckState.Checked)
            {
                colorButton.Enabled = true;
                colorButton.BackColor = color;
            }
            else
            {
                colorButton.BackColor = DefaultBackColor;
                colorButton.Enabled = false;
                colors = Color.Empty;
            }
        }
        public bool none
        {
            set
            {
                if (value == true)
                {
                    colorCheck.Visible = false;
                    colorButton.Enabled = true;
                }
                else
                {
                    colorCheck.Visible = true;
                }
            }
        }
    }
}
