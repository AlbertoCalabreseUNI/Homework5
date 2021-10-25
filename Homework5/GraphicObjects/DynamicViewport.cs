using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Homework5.GraphicObjects
{
    //Base class for resizable objects
    //In here there must be all the calculations to correctly reize what is being drawn.
    
    public abstract class DynamicViewport
    {
        public bool hit { get; set; }
        public abstract void Draw(Graphics g);
        public abstract bool isHit(int clickX, int clickY);
        public abstract void resize(Point firstPoint, Point temp);
        //public abstract void move(Point firstPoint, Point temp);
        public abstract void move(MouseEventArgs e);
        public abstract void reset();
    }
}
