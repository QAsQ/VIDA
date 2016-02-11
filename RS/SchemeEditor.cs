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
    public partial class SchemeEditor : Form
    {
        bool isChange;
        public bool ChangeScheme
        {
            get
            {
                return isChange;
            }
        }
        int Id_selected;
        public SchemeEditor()
        {
            InitializeComponent();
            Id_selected = -1;
            drawStyleEditor.userChange += new DrawStyleEditor.DrawStyleChangeHandler(ColorChange);
            backGroundColor.userChange += new ColorView.ColorChangeHandler(ColorChange); 
            backGroundColor.nonempty();
        }
        public void EditScheme(ColorScheme _scheme)
        {
            drawStyleEditor.Visible = false;
            backGroundColor.init(_scheme.BackGround);
            MiniDV.setScheme(_scheme);
            MiniDV.Flash();
            isChange = false;
            ShowDialog();
        }
        public ColorScheme scheme
        {
            get
            {
                return MiniDV.Scheme;
            }
        }
        private void StateChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currId = StateChoice.SelectedIndex;
            if (currId != -1)
            {
                loadDS(currId);
            }
            Id_selected = currId;
        }
        /// <summary>
        /// from MiniDV to editor
        /// </summary>
        /// <param name="Id_selected"></param>
        private void loadDS(int index)
        {
            drawStyleEditor.drawStyle = MiniDV.Scheme.putByIndex(index);
            drawStyleEditor.Visible = true;
        }
        public void ColorChange(object sender)
        {
            saveDS(StateChoice.SelectedIndex);
        }
        /// <summary>
        /// from editor to MainDV
        /// </summary>
        /// <param name="index"></param>
        private void saveDS(int index)
        {
            if (index != -1)
            {
                drawStyleEditor.Visible = true;
                MiniDV.Scheme.loadByIndex(index, drawStyleEditor.drawStyle);
            }
            MiniDV.Scheme.loadBackGround(backGroundColor.color);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            isChange = true;
            Hide();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            isChange = false;
            Hide();
        }
    }
}