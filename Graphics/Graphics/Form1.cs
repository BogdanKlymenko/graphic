using System;
using System.Windows.Forms;

namespace Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender,EventArgs e)
        {
            if (comboBox1.SelectedItem == null) {
                MessageBox.Show("Choose function");
                return;
            }
            chart1.Series[0].Name = comboBox1.SelectedItem.ToString();
            try
            {
                bool sin = comboBox1.SelectedItem.ToString().Equals("y = sin(x)");
                bool cos = comboBox1.SelectedItem.ToString().Equals("y = cos(x)");       
                double Xmin = double.Parse(textBox1.Text);
                double Xmax = double.Parse(textBox2.Text);  
            
                if(Xmin >= Xmax)
                {
                    MessageBox.Show("x1>x2");
                    return;
                }

                int count = (int)Math.Ceiling((Xmax - Xmin) )+ 1;
                double[] x = new double[count];
                double[] y1 = new double[count];

                double[] y2 = new double[count];
                for (int i = 0; i < count; i++)
                {
                    x[i] = Xmin + i;
                    if (sin)
                    {
                        y1[i] = Math.Sin(x[i]);
                    }
                    else if (cos)
                    {
                        y1[i] = Math.Cos(x[i]);
                    }
                  
                }
            
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;
                chart1.Series[0].Points.DataBindXY(x, y1);
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
