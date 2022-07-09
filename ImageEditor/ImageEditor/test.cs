using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            MakeLabelRounded();
        }


        private void MakeLabelRounded()
        {
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(10, 10, 100, 100);
            gp.AddArc(rec, 0, 180);
            label1.Region = new Region(gp);
            label1.Invalidate();
        }


        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
