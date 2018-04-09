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
    public partial class EqnSelector : Form
    {
        public EqnSelector()
        {
            InitializeComponent();
        }

        private void EqnSelector_Load(object sender, EventArgs e)
        {

        }

        private void LocationTimeBtn_Click(object sender, EventArgs e)
        {
            LocationTime locationTime = new LocationTime();
            locationTime.Show();
            Close(); 
        }

        private void VelocitySquaredBtn_Click(object sender, EventArgs e)
        {
            VelocitySquared velocitySquared = new VelocitySquared();
            velocitySquared.Show();
            Close();
        }

        private void VelocityTimeBtn_Click(object sender, EventArgs e)
        {
            VelocityTime velocityTime = new VelocityTime();
            velocityTime.Show();
            Close();
        }
        private void EqnSelector_FormClosing(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }
    }
}
