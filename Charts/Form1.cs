using CalcTheoryLab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chartMain.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            string input = "sin(x) + (cos(x))^3 + sqrt(x*PI)";
            chartMain.Series[0].Name = input;

            var dict = ExpressionCalculator.CalculateParametrized(input, "x", 1, 10, 0.1);
            AddPoints(dict);
        }

        private void AddPoints(Dictionary<double, double> pointsDict)
        {
            foreach (var p in pointsDict)
            {
                chartMain.Series[0].Points.AddXY(p.Key, p.Value);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
