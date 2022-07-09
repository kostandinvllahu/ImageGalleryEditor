using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

class ovalLabel : Label
{
    public ovalLabel()
    {
        this.BackColor = Color.DarkGray;
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        using (var gp = new GraphicsPath())
        {
          /*  float left = 20;
            float top = 20;
            float right = 50;
            float bottom = 100;
            RectangleF rect = 20, 20, 50, 100;
            float startAngle = 1;
            float sweepAngle = 1;
            gp.AddArc(rect, startAngle, sweepAngle);
            this.Region = new Region(gp);*/
        }
    }
}