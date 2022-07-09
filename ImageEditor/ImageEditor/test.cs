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
            //  SizeChanged += (s, e) => Invalidate();
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(20, 20, 50, 100);
            gp.AddArc(rec, 190, -1190);
            label1.Region = new Region(gp);
            label1.Invalidate();
        }

        private void test_Load(object sender, EventArgs e)
        {

        }

        /*  protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var center = new Point(Width / 2, Height / 2);
            var radius = Math.Min(Width, Height) / 3;
            var text = "OLLEH";

            var font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
            for (var i = 0; i < text.Length; ++i)
            {
                var c = new String(text[i], 1);

                var size = e.Graphics.MeasureString(c, font);
                var charRadius = radius + size.Height;

                var angle = (((float)i / text.Length)- 5);

                var x = (int)(center.X + Math.Cos(angle) * charRadius);
                var y = (int)(center.Y + Math.Sin(angle) * charRadius);


                e.Graphics.TranslateTransform(x, y);

                e.Graphics.RotateTransform((float)(270 + 360  * angle / (2 * Math.PI)));
                e.Graphics.DrawString(c, font, Brushes.Red, 0, 0);

                e.Graphics.ResetTransform();


                e.Graphics.DrawArc(new Pen(Brushes.Transparent, 2.0f), center.X - radius, center.Y - radius, radius * 2, radius * 2, 0, 180);
            }
        }*/

   
    }
}




      

      
    