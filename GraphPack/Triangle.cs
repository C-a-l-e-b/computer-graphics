using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPack
{
    class Triangle : Shape
    {
        public override void DrawShape(Graphics g)
        {
            PointF[] p = new PointF[3];
            p[0] = new PointF((End.X + Start.X) / 2, Start.Y);
            p[1] = End; 
            p[2] = new PointF(Start.X, End.Y);

            Matrix m = new Matrix();
            m.RotateAt(rotateAmount, Center, MatrixOrder.Prepend);
            m.TransformPoints(p);

            Pen pen =  highlight ? Form1.higlightpen: Form1.pen;

            //Connect points to make triangle
            g.DrawLine(pen, p[0], p[1]);
            g.DrawLine(pen, p[1], p[2]);
            g.DrawLine(pen, p[2], p[0]);
        }
    }
}
