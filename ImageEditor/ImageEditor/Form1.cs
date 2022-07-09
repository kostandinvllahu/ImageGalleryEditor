using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class Form1 : Form
    {

        bool Dragging;
        int xPos;
        int yPos;
        int width;
        int height;
        Image target_Image;
        PaintEventArgs paintEvent;
        public Form1()
        {
            InitializeComponent();
            MakeLabelRounded();
            GalleryList();
            MakeLabelRounded();
           // SizeChanged += (s, a) => Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GalleryList()
        {
            string path = @"F:\ImageEditor\Images";
            var rand = new Random();
            var files = Directory.GetFiles(path, "*.*");
            var images = new Image[files.Length];
            int x = 0;
            int y = 0;
            
           
            for (int i=0; i<files.Length; i++)
            {
                PictureBox pic = new PictureBox();
                Label label = new Label();
                pic.Location = new Point(40,40*(y+1));
                y++;
                pic.Size = new Size(50, 50);
                pic.Padding = new Padding(0);
                pic.Name = "btn" + y.ToString();
                label.Location = new Point(100, 40 * (y + 1));
                label.Text = y.ToString();
                label.Size = new Size(50, 20);
                pic.Text = y.ToString();
                pic.Image = Image.FromFile(files[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.MouseClick += new MouseEventHandler(this.EventClicker);
                panel1.Controls.Add(pic);
                panel1.Controls.Add(label);
            }
        }

        private void MakeLabelRounded()
        {
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(0, 0, 50, 100);
            gp.AddArc(rec, 0, -280);
            label2.Region = new Region(gp);
            label2.Invalidate();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDown.Text = "";
            textBox1.Text = "";
            txtUp.Text = "";
            label2.Text = "TEXT";
            label3.Text = "TEXT";
            ovalPictureBox1.Image = null;
            trackBar1.Value = 100;
            trackBar2.Value = 100;
           
        }

        void EventClicker(object sender, EventArgs e)
        {
            PictureBox btn = sender as PictureBox;
            ovalPictureBox1.Image = btn.Image;
            target_Image = btn.Image;
            height = target_Image.Height;
            width = target_Image.Width;
            ovalPictureBox1.Cursor = Cursors.Hand;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ovalPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Dragging = true;
                xPos = e.Y;
                yPos = e.Y;
            }
        }

        private void ovalPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if(Dragging && c!= null)
            {
                c.Top = e.Y + c.Top - yPos;
                c.Left = e.X + c.Left - xPos;
            }
        }

        private void ovalPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                width = (target_Image.Width * trackBar1.Value) / 100;
                ovalPictureBox1.Image = ResizeNow(width, height);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            try
            {
            height = (target_Image.Height * trackBar2.Value) / 100;
            ovalPictureBox1.Image = ResizeNow(width, height);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private Bitmap ResizeNow(int target_width, int target_height)
        {
            Rectangle dest_rect = new Rectangle(0, 0, target_width, target_height);
            Bitmap destImage = new Bitmap(target_width, target_height);
            destImage.SetResolution(target_Image.HorizontalResolution, target_Image.VerticalResolution);
            using (var g = Graphics.FromImage(destImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using(var wrapmode = new ImageAttributes())
                {
                    wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(target_Image, dest_rect, 0, 0, target_Image.Width, target_Image.Height, GraphicsUnit.Pixel, wrapmode);
                }
            }
            return destImage;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //pEventArg = a;
            label2.Text = txtUp.Text; 
            label3.Text = txtDown.Text;
            SizeChanged += (s, a) => Invalidate();
           // topText(a, txtUp); //error ketu
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test t = new test();
            t.Show();
        }

        //=========TOP HALF CIRCLE TEXT==========
        //private void topText(PaintEventArgs e, TextBox txtUp)
        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
            
            var center = new Point(Width / 2, Height / 2);
            var radius = Math.Min(Width, Height) / 3;
            var text = "Hello";//txtUp.Text;

                var font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                for (var i = 0; i < text.Length; ++i)
                {
                    var c = new String(text[i], 1);


                    var size = e.Graphics.MeasureString(c, font);
                    var charRadius = radius + size.Height;

                    var angle = (((float)i / text.Length) - 2);

                    var x = (int)(center.X + Math.Cos(angle) * charRadius);
                    var y = (int)(center.Y + Math.Sin(angle) * charRadius);


                    e.Graphics.TranslateTransform(x, y);

                    e.Graphics.RotateTransform((float)(90 + 360 * angle / (2 * Math.PI)));
                    e.Graphics.DrawString(c, font, Brushes.Red, 0, 0);

                    e.Graphics.ResetTransform();

                    e.Graphics.DrawArc(new Pen(Brushes.Transparent, 2.0f), center.X - radius, center.Y - radius, radius * 2, radius * 2, 0, 360);
                }
           

        }

        private void ovalPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ovalPictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void ovalPictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Dragging = true;
                xPos = e.X;
                yPos = e.Y;
            }
        }

        private void ovalPictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if(Dragging && c != null)
            {
                c.Top = e.Y + c.Top - yPos;
                c.Left = e.X + c.Left - xPos;
            }
        }

        private void ovalPictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }
        //======================

        /*   protected override void OnPaint(PaintEventArgs e)
           {
               base.OnPaint(e);
               paintEvent = e;  
           }*/

    }
}
