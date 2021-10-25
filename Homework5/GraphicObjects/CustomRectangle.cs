using System.Drawing;
using System.Windows.Forms;

namespace Homework5.GraphicObjects
{
    public class CustomRectangle : DynamicViewport
    {
        public int x, y, width, height, border;
        private int referX, referY;

        private Pen blackPen;
        private SolidBrush hitColor;
        private SolidBrush rectColor;
        public CustomRectangle(int x, int y, int width, int height)
        {
            this.hit = false;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            this.referX = 0;
            this.referY = 0;

            this.blackPen = new Pen(Color.Black);
            this.hitColor = new SolidBrush(Color.Red);
            this.rectColor = new SolidBrush(Color.Green);
        }

        public override void Draw(Graphics g) 
        {
            if (this.hit)
            {
                g.FillRectangle(this.hitColor, this.x, this.y, this.width, this.height);
                g.DrawRectangle(this.blackPen, this.x, this.y, this.width, this.height);
            }
            else
            {
                g.FillRectangle(this.rectColor, this.x, this.y, this.width, this.height);
                g.DrawRectangle(this.blackPen, this.x, this.y, this.width, this.height);
            }
        }

        //Checks if we're clicking inside the rectangle
        public override bool isHit(int clickX, int clickY)
        {
            if ((clickX >= this.x) && (clickX <= this.x + this.width) && (clickY > this.y ) && (clickY < this.y + this.height ))
                this.hit = true;

            if(this.referX == 0) this.referX = clickX;
            if(this.referY == 0) this.referY = clickY;
            return this.hit;
        }

        public override void resize(Point point, Point temp)
        {
            this.width += temp.X - point.X;
            this.height += temp.Y - point.Y;
        }

        
        public override void move(MouseEventArgs e)
        {
            Point point = e.Location;
            
            this.x += point.X - referX;
            this.referX = point.X;

            this.y += point.Y - referY;
            this.referY = point.Y;
        }
        

        public override void reset()
        {
            this.hit = false;
            this.x = 0;
            this.y = 0;

            this.width = 80;
            this.height = 80;

            this.referX = 0;
            this.referY = 0;
        }
    }
}
