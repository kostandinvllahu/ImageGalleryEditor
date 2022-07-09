using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MakeLabelRounded();
            GalleryList();
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
                
               // Button pic = new Button();
                pic.Location = new Point(40,40*(y+1));
                y++;
                pic.Size = new Size(50, 50);
                pic.Padding = new Padding(0);
                pic.Name = "btn" + y.ToString();
                pic.Text = y.ToString();
                pic.Image = Image.FromFile(files[i]);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                groupBox1.Controls.Add(pic);
            }
        }

        private void MakeLabelRounded()
        {
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(20, 20, 50, 100);
            gp.AddArc(rec, 0 , 180);
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
            test t = new test();
            t.Show();
        }
    }
}
