using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinematics_Solver
{
    public partial class LocationTime : Form
    {
        double Conv(System.Windows.Forms.TextBox text)
        {
            double res;
            try
            {
                res = Convert.ToDouble(text);
            }
            catch (FormatException)
            {
                res = Double.NaN;
            }
            return res;

        }
        public LocationTime()
        {
            InitializeComponent();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            EquationData equation = new EquationData();
            equation.x = Conv(x);
            equation.x0 = Conv(x0);
            equation.v0 = Conv(v0);
            equation.t = Conv(t);
            equation.t0 = Conv(t0);
            equation.a = Conv(a);
            equation.LocationTime();
            resStrip.Text = equation.result;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
