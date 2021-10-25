using Homework5.GraphicObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework5
{
    public partial class Form1 : Form
    {
        public List<DynamicViewport> viewports;
        public Point firstPoint;
        public Form1()
        {
            InitializeComponent();

            //Initialize an empty list for viewports
            this.viewports = new List<DynamicViewport>();
            //Better drawing performance
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            this.UpdateStyles();

            //Initialize custom method for Paint Event in picturebox
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Controls.Add(this.pictureBox1);
            //Every 50 ms the paint event is called
            this.timer1.Interval = 50;
            this.timer1.Start();
        }

        //Redraw everything in the picturebox
        private void timer1_Tick(object sender, EventArgs e) { this.pictureBox1.Refresh(); }
        //With this method we'll be able to draw dynamic viewports
        private void pictureBox1_Paint(object sender, PaintEventArgs e) 
        {
            Graphics g = e.Graphics;
            foreach (DynamicViewport element in this.viewports)
                element.Draw(g);
        }

        private void Picturebox_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            foreach (DynamicViewport element in this.viewports)
                element.isHit(firstPoint.X, firstPoint.Y);
        }

        private void Picturebox_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (DynamicViewport element in this.viewports)
                if(element.hit) element.hit = false;        
        }

        private void Picturebox_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (DynamicViewport element in this.viewports)
            {
                if (e.Button == MouseButtons.Left && element.isHit(e.Location.X, e.Location.Y))
                        element.move(e);
                else if (e.Button == MouseButtons.Right && element.isHit(e.Location.X, e.Location.Y))
                    element.resize(firstPoint, e.Location);
            }      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomRectangle rect = new CustomRectangle(0,0,80,80);
            this.viewports.Add(rect);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DynamicViewport element in this.viewports)
                element.reset();
        }
    }
}
