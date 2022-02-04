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
    public partial class Class_Schedule : Form
    {
        public Class_Schedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.ShowDialog();
        }

        private void Class_Schedule_Load(object sender, EventArgs e)
        {
           
        }

        //public void DisableDIU()
        //{
        //    btn_Delete.Visible = false;
        //    btn_Add.Visible = false;
        //    btn_Update.Visible = false;
          
        //}

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            EDP_Txt.Text = "";
            SubjectName_Txt.Text = "";
            SubjestDes_Txt.Text = "";
            Units_Txt.Text = "";
        }
    }
}
