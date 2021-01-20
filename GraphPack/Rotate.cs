using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphPack
{
    public partial class Rotate : Form
    {
        readonly Shape selectedShape;
        public Rotate(Shape selectedShape)
        {
            InitializeComponent();
            this.selectedShape = selectedShape;
            textBox1.Text = Convert.ToString(selectedShape.rotateAmount);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int val = int.Parse(textBox1.Text);
                selectedShape.rotateAmount = val;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Input a valid number");
                textBox1.Clear();
            }
        }
    }
}
