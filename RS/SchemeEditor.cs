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
        int Id_selected;
        public SchemeEditor()
        {
            InitializeComponent();
            Id_selected = -1;
            drawStyleEditor.userChange += new DrawStyleEditor.DrawStyleChangeHandler(ColorChange);
        }
        public void EditScheme(ColorScheme _scheme)
        {
            drawStyleEditor.Visible = false;
            MiniDV.Scheme = _scheme;
            MiniDV.Flash();
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
            drawStyleEditor.Visible = true;
            MiniDV.Scheme.loadByIndex(index, drawStyleEditor.drawStyle);
        }
    }
}