using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPack
{
    public abstract class Shape
    {
        protected int X { get; set; }
        protected int Y { get; set; }
        protected int Width { get; set; }
        protected int Height { get; set; }

        public Rectangle Rectangle => new Rectangle(X, Y, Width, Height);

        public bool highlight = false;

        public float rotateAmount;

        public Point End {get; set;}
        public Point Start { get; set; }
        protected Point Center => new Point(X + Width / 2, Y + Height / 2);

        public void UpdateLocation(int x, int y)
        {
            Start = new Point(Start.X + x, Start.Y + y);
            End = new Point(End.X + x, End.Y + y);
            X += x;
            Y += y; 
        }

        public void SetStartEnd(Point start, Point end)
        {
            Start = start; End = end;
        }

        public void SetPosition(int x, int y)
        {
            X = x; Y = y;
        }

        public void SetSize(int width, int height)
        {
            Width = width; Height = height;
        }

        public abstract void DrawShape(Graphics g);
    }
}
