using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPack
{
    class Circle : Shape
    {
        public override void DrawShape(Graphics g)
        {
            //Draw circle
            g.DrawEllipse(highlight ? Form1.higlightpen : Form1.pen, Rectangle);
        }
    }
}
