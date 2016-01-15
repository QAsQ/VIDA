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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            UpdateMinRVFormLocate();
        }
        Point FrameOffset = new Point(9,30);
        private void mainForm_LocationChanged(object sender, EventArgs e)
        {
            UpdateMinRVFormLocate();
        }
        private void UpdateMinRVFormLocate()
        {
            Point FormOffset = this.Location;
            FormOffset.Offset(FrameOffset);
            MainDV.FormLocate = FormOffset;
        }
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否用当前的状态来覆盖之前的数据？", "Save", MessageBoxButtons.YesNo))
                return;
        }
    }
}