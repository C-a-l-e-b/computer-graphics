using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphPack
{
    class Square : Shape
    {
        public override void DrawShape(Graphics g)
        {
			try
			{
                Point[] p = new Point[4];

                //Upper left corner
                p[0] = new Point(X, Y);

                //Lower left corner
                p[1] = new Point(X + Width, Y);

                //Lower right corner
                p[2] = new Point(X + Width, Y + Height);

                //Upper right corner 
                p[3] = new Point(X, Y + Height);


                Matrix m = new Matrix();
                m.RotateAt(rotateAmount, Center, MatrixOrder.Prepend);
                m.TransformPoints(p);

                //Connect four corners to make square and draw to screeh
                for (int i = 0; i < p.Length; i++)
                {
                    Point current = p[i];
                    Point next = (i == p.Length - 1) 
                        ? p[0] : p[i + 1];
                    g.DrawLine(highlight ? Form1.higlightpen : Form1.pen, current, next);
                }
            }
			catch (Exception e)
			{
				MessageBox.Show("There was an error drawing that square");
			}
        }
    }
}
