using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_FDCForLabMonitoringSystem
{
    public partial class RegistrationNew : Form
    {
        public RegistrationNew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.ShowDialog();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {

        }

        private void cntCamera_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
