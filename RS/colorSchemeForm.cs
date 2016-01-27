using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniRS;

namespace RS
{
    public partial class colorSchemeForm : Form
    {
        List<Skill> sample = new List<Skill>();
        public colorSchemeForm()
        {
            InitializeComponent();
            curr_index = -1;
            Font.none = true;
            back_ground.none = true;
            changeVisable(false);
            debug();
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
            Font.color = fs.font;
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
            fs[index].font = Font.color;
            changeVisable(true);
        }
        void changeVisable(bool value)
        {
            Font.Visible = Edge.Visible = Fill.Visible = value;
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
        public void debug()
        {
            FillStyle Hs = new FillStyle(ColorTranslator.FromHtml("#aba5a2")
                                    , ColorTranslator.FromHtml("#aaaaa2")
                                    , ColorTranslator.FromHtml("#7d7d64"));
            FillStyle Cs = new FillStyle(ColorTranslator.FromHtml("#43c1ca")
                                        , ColorTranslator.FromHtml("#c7d2d3")
                                        , ColorTranslator.FromHtml("#90bbbe"));
            FillStyle Us = new FillStyle(ColorTranslator.FromHtml("#894a60")
                                        , ColorTranslator.FromHtml("#c66a8a")
                                        , ColorTranslator.FromHtml("#000000"));
            fs[0] = Hs;
            fs[1] = Cs;
            fs[2] = Us;
        }

        private void Flash_Click(object sender, EventArgs e)
        {
            MiniDV.Flash();
        }
    }
}
