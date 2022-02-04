using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace _1._1_FDCForLabMonitoringSystem
{
    public partial class MainMenu : Form
    {
        public SerialPort myport;

        public void Unlock()
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = "COM8";
            myport.Open();
            myport.WriteLine("O");
            myport.Close();

        }
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Login
            LoginPage Lp = new LoginPage();
            this.Hide();
            Lp.ShowDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        //MANAGE USERS
        private void btnManage_Click(object sender, EventArgs e)
        {
            System_Users su = new System_Users();
            su.Owner = this;          
            su.ShowDialog();
        }

        //TIME IN AND OUT
        private void btn2ndScreen_Click(object sender, EventArgs e)
        {
            RecogniseFace rf = new RecogniseFace();
            rf.Show();

        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            RegisterDetect rc = new RegisterDetect();
            rc.Owner = this;            
            rc.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            RecogniseFaceOut ro = new RecogniseFaceOut();
            ro.Owner = this;
            ro.Show();
        }

        private void btnExt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //BTN CLASS SCHEDULE
        private void button3_Click(object sender, EventArgs e)
        {
            ViewEnrollmentPerSubject view = new ViewEnrollmentPerSubject();
            view.Owner = this;
            view.Show();
        }
        
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Date.Text = DateTime.Now.ToLongTimeString();
            Time.Text = DateTime.Now.ToLongDateString();

            label4.Text = this.Tag.ToString();

            //Enable if Administrator
            if (this.Tag.ToString() == "Administrator")
            {
                btnManage.Enabled = true;
                SytemUsers.Enabled = true;                
            }
            else
            {
                btnManage.Enabled = false;
                SytemUsers.Enabled = false;
            }
          

        }

        private void MainMenu_Activate(object sender, EventArgs e)
        {           
            //Enable if Administrator
            if( this.Tag.ToString() == "Administrator")
            {
                btnManage.Enabled = true;
                SytemUsers.Enabled = true;
            }
            else
            {
                btnManage.Enabled = false;
                SytemUsers.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Date.Text = DateTime.Now.ToLongTimeString();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
    
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //BTN SYSTEM MAINTENANCE
        private void SytemUsers_Click(object sender, EventArgs e)
        {
            MiscTabForms su = new MiscTabForms();
            su.Owner = this;            
            su.ShowDialog();            
        }

        //BTN ENROLLMENT
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            EnrollmentList el = new EnrollmentList();
            el.Owner = this;
            el.Show();
        }

        //DOOR UNLOCK
        private void button1_Click(object sender, EventArgs e)
        {
            Unlock();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        //BTN REPORTS
        private void button8_Click(object sender, EventArgs e)
        {
            //Reports re = new Reports();
            //re.Owner = this;
            //re.Show();


            ReportAttendance re = new ReportAttendance();
            re.Owner = this;
            re.Show();
        }
    }
}
