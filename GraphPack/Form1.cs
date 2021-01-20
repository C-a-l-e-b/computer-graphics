using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphPack
{
    public partial class Form1 : Form
    {
        private bool isDrawing;
        private bool isDrag;
        private Point mouseLocation;
        private Point start, end;
        public static Pen pen;
        public static Pen higlightpen;
        public List<Shape> shapes;

        private Shape selectedShape;

        private bool IsSelect => selectToolStripMenuItem.Checked == true;

        public Form1()
        {
            InitializeComponent();

            pen = Pens.Black;
            higlightpen = Pens.Red;
            shapes = new List<Shape>();

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirm =
                MessageBox.Show("Are you sure you want to exit? ",
                "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        private void drawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            if (selectedShape != null && selectedShape.Rectangle.Contains(e.Location))
            {
                isDrag = true;
                return;
            }

            if (IsSelect)
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.Rectangle.Contains(e.Location))
                    {
                        selectedShape = shape;
                        shape.highlight = true;
                        Redraw();
                        shape.highlight = false;

                        break;
                    }
                }
                return;
            }
            isDrawing = true;

        }

        private void drawingBoard_MouseMove(object sender, MouseEventArgs e)
        {
            end = mouseLocation = e.Location;

            if (isDrag)
            {
                int xDifference = e.Location.X - start.X;
                int yDifference = e.Location.Y - start.Y;
                start = end;
                selectedShape.UpdateLocation(xDifference, yDifference);
                Redraw();
                return;
            }
            if (!isDrawing)
            {
                return;
            }

            Redraw();

            Shape currentShape;
            if (squareToolStripMenuItem.Checked)
            {
                currentShape = new Square();
            }
            else if (circleToolStripMenuItem.Checked)
            {
                currentShape = new Circle();
            }
            else if (triangleToolStripMenuItem.Checked)
            {
                currentShape = new Triangle();
            }
            else
            {
                return;
            }

            currentShape.SetPosition(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));
            currentShape.SetSize(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
            currentShape.SetStartEnd(start, end);
            currentShape.DrawShape(drawingBoard.CreateGraphics());
        }

        private void drawingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            if (isDrag)
            {
                isDrag = false;
                return;
            }
            Redraw();

            Shape currentShape;
            if (squareToolStripMenuItem.Checked)
            {
                currentShape = new Square();
            }
            else if (circleToolStripMenuItem.Checked)
            {
                currentShape = new Circle();
            }
            else if (triangleToolStripMenuItem.Checked)
            {
                currentShape = new Triangle();
            }
            else
            {
                return;
            }

            currentShape.SetPosition(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));
            currentShape.SetSize(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
            currentShape.SetStartEnd(start, end);

            if (currentShape.Rectangle.Width < 10 || currentShape.Rectangle.Height < 10)
            {
                return;
            }

            currentShape.DrawShape(drawingBoard.CreateGraphics());
            shapes.Add(currentShape);
        }

        private void Redraw()
        {
            Graphics g = drawingBoard.CreateGraphics();
            g.Clear(drawingBoard.BackColor); //Clear old graphics

            foreach (Shape shape in shapes)
            {
                if (shape == selectedShape)
                {
                    shape.highlight = true;
                    shape.DrawShape(g);
                    shape.highlight = false;
                }
                else
                {
                    shape.DrawShape(g);
                }
            }
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeselectOptions();
            squareToolStripMenuItem.Checked = true;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeselectOptions();
            circleToolStripMenuItem.Checked = true;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeselectOptions();
            triangleToolStripMenuItem.Checked = true;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectOption();
        }
        private void DeselectOptions()
        {
            squareToolStripMenuItem.Checked = false;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            selectToolStripMenuItem.Checked = false;
        }
        private void SelectOption()
        {
            DeselectOptions();
            selectToolStripMenuItem.Checked = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                DialogResult confirm =
               MessageBox.Show("Are you sure you want to delete shape ? ",
               "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    shapes.Remove(selectedShape);
                    selectedShape = null;
                    Redraw();
                }
            }
            else
            {
                MessageBox.Show("No shape is selected");
            }
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShape = null;
            Redraw();
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                Rotate r = new Rotate(selectedShape);
                r.ShowDialog();
                Redraw();
            }
            else
            {
                MessageBox.Show("No shape is selected");
            }
        }

    }
}
